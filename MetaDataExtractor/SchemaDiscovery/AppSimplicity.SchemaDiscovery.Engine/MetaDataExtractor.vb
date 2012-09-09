Imports System.Configuration
Imports System.Threading

Public Class MetaDataExtractor

    Private _WorkerProcess As System.ComponentModel.BackgroundWorker = Nothing

    Private _Overall As Integer = 100
    Private _CurrentProgress As Integer = 0

    Public Sub AttachBackgroundProcess(ByVal pBP As System.ComponentModel.BackgroundWorker)
        _WorkerProcess = pBP
    End Sub

    Private Sub ReportActivity(Optional ByVal pMessage As String = "")
        If (_WorkerProcess Is Nothing) Then
            Console.WriteLine(pMessage)
        Else
            If (Me._Overall > 0) Then
                If (pMessage = String.Empty) Then
                    _WorkerProcess.ReportProgress(Math.Round((_CurrentProgress * 100) / _Overall))
                Else
                    _WorkerProcess.ReportProgress(Math.Round((_CurrentProgress * 100) / _Overall), pMessage)
                End If
            End If
        End If
    End Sub

    Public Sub DetachBackgroundProcess()
        _WorkerProcess = Nothing
    End Sub

    Private Sub GetTableData(state As Object)
        Dim _state As ThreadableDB = state
        Try
            _state.table.Columns = _state.metaProvider.GetColumns(_state.table)
            _state.table.Keys = _state.metaProvider.GetKeys(_state.table)

            ReportActivity(_state.table.QualifiedName)
        Finally
            If (_state.resetEvent IsNot Nothing) Then
                _state.resetEvent.Set()
            End If
        End Try
    End Sub

    Private Sub GetViewData(state As Object)
        Dim _state As ThreadableDB = state
        Try
            _state.view.Columns = _state.metaProvider.GetColumns(_state.view)

            ReportActivity(_state.view.QualifiedName)
        Finally
            If (_state.resetEvent IsNot Nothing) Then
                _state.resetEvent.Set()
            End If
        End Try
    End Sub

    Private Sub GetSprocData(state As Object)
        Dim _state As ThreadableDB = state
        Try
            _state.sproc.Parameters = _state.metaProvider.GetStoredProcedureParameters(_state.sproc)

            ReportActivity(_state.sproc.QualifiedName)
        Finally
            If (_state.resetEvent IsNot Nothing) Then
                _state.resetEvent.Set()
            End If
        End Try
    End Sub

    Private Sub FixTableNames(state As Object)
        Dim _state As ThreadableDB = state
        Try
            _state.table.ClassName = NameFixer.GetSingularClassName(_state.table.Name)
            _state.table.PluralClassName = NameFixer.GetPluralClassName(_state.table.Name)

        Finally
            If (_state.resetEvent IsNot Nothing) Then
                _state.resetEvent.Set()
            End If
        End Try
    End Sub

    Private Sub FixViewNames(state As Object)
        Dim _state As ThreadableDB = state
        Try
            _state.view.ClassName = NameFixer.GetSingularClassName(_state.view.Name)
            _state.view.PluralClassName = NameFixer.GetPluralClassName(_state.view.Name)

        Finally
            If (_state.resetEvent IsNot Nothing) Then
                _state.resetEvent.Set()
            End If
        End Try
    End Sub

    ''' <summary>
    ''' This will populate all the objects that we found in a database.
    ''' Since this can have a big overload has been prepared to use multiple threads which improves the performance.
    ''' </summary>
    ''' <param name="project">Project that contains the information of DB</param>
    ''' <param name="metaProviders">Provider that specify which database to connect</param>
    ''' <remarks></remarks>
    Private Sub PopulateDBObjects(ByRef project As Entities.Project, metaProviders As Dictionary(Of String, IMetaDataProvider))
        For Each lDatasource As Entities.DataSource In project.DataSources
            Dim lMetaDataProvider As IMetaDataProvider = metaProviders(lDatasource.DataSourceName)

            Dim i As Integer = 0

            If (lDatasource.Tables.Count > 0) Then


                Dim resetEvents(lDatasource.Tables.Count - 1) As ManualResetEvent
                Dim state As ThreadableDB
                i = 0

                ReportActivity()
                ReportActivity("Now fetching tables metadata...")

                For Each lTable As Entities.Table In lDatasource.Tables
                    'Creating the manualResetEvent to know when this thread completes
                    resetEvents(i) = New ManualResetEvent(False)
                    'Pass this custom class as a parameter to the new thread
                    state = New ThreadableDB(lTable, lMetaDataProvider, resetEvents(i))
                    'Adding to the ThreadPool and specifying the method to be executed
                    ThreadPool.QueueUserWorkItem(AddressOf GetTableData, state)
                    ''lTable.Columns = lMetaDataProvider.GetColumns(lTable)
                    ''lTable.Keys = lMetaDataProvider.GetKeys(lTable)
                    ''ReportActivity(lTable.QualifiedName)
                    ''Me.ReportActivity()
                    _CurrentProgress += 1
                    i += 1
                Next

                'Since this is a STA (Single Thread App) we need to wait one for one all the threads created
                For Each manual As ManualResetEvent In resetEvents
                    manual.WaitOne()
                Next

                resetEvents = Nothing
                state = Nothing
            End If


            If (lDatasource.Views.Count > 0) Then

                Dim resetEvents(lDatasource.Views.Count - 1) As ManualResetEvent
                Dim state As ThreadableDB
                i = 0

                ReportActivity()
                ReportActivity("Now fetching views metadata...")
                For Each lView As Entities.View In lDatasource.Views
                    'Creating the manualResetEvent to know when this thread completes
                    resetEvents(i) = New ManualResetEvent(False)
                    'Pass this custom class as a parameter to the new thread
                    state = New ThreadableDB(lView, lMetaDataProvider, resetEvents(i))
                    'Adding to the ThreadPool and specifying the method to be executed
                    ThreadPool.QueueUserWorkItem(AddressOf GetViewData, state)
                    ''lView.Columns = lMetaDataProvider.GetColumns(lView)
                    ''ReportActivity(lView.QualifiedName)
                    ''ReportActivity()
                    _CurrentProgress += 1
                    i += 1
                Next

                'Since this is a STA (Single Thread App) we need to wait one for one all the threads created
                For Each manual As ManualResetEvent In resetEvents
                    manual.WaitOne()
                Next

                resetEvents = Nothing
                state = Nothing
            End If

            If (lDatasource.StoredProcedures.Count > 0) Then

                Dim resetEvents(lDatasource.StoredProcedures.Count - 1) As ManualResetEvent
                Dim state As ThreadableDB
                i = 0

                ReportActivity()
                ReportActivity("Now fetching stored procedures metadata...")
                For Each lSp As Entities.StoredProcedure In lDatasource.StoredProcedures
                    'Creating the manualResetEvent to know when this thread completes
                    resetEvents(i) = New ManualResetEvent(False)
                    'Pass this custom class as a parameter to the new thread
                    state = New ThreadableDB(lSp, lMetaDataProvider, resetEvents(i))
                    'Adding to the ThreadPool and specifying the method to be executed
                    ThreadPool.QueueUserWorkItem(AddressOf GetSprocData, state)
                    ''lSp.Parameters = lMetaDataProvider.GetStoredProcedureParameters(lSp)
                    ''ReportActivity(lSp.QualifiedName)
                    ''Me.ReportActivity()
                    _CurrentProgress += 1
                    i += 1
                Next

                'Since this is a STA (Single Thread App) we need to wait one for one all the threads created
                For Each manual As ManualResetEvent In resetEvents
                    manual.WaitOne()
                Next

                resetEvents = Nothing
                state = Nothing
            End If

            lDatasource.SetProject(project)
            ReportActivity(String.Format("Extraction from [{0}] completed successfully.", lDatasource.DataSourceName))
        Next
    End Sub

    Public Function LoadProject() As Entities.Project
        Dim lProject As New Entities.Project

        'Load current vbproj/csproj settings:
        Dim lVSProject As VisualStudio.Project = VisualStudio.Project.GetCurrentProject()
        If Not (lVSProject Is Nothing) Then
            lProject.AssemblyName = lVSProject.AssemblyName
            lProject.RootNamespace = lVSProject.RootNamespace
        End If

        ReportActivity("Running schema extraction")
        ReportActivity("Looking for connections in .config file...")

        Me._Overall = 0
        Me._CurrentProgress = 0

        Dim lMetaProviders As New Dictionary(Of String, IMetaDataProvider)

        For Each lCS As ConnectionStringSettings In Configuration.ConnectionSettings.GetAllConnectionStringsFromLocalConfiguration()
            ReportActivity(String.Format("Runing metadata extraction for [{0}]", lCS.Name))
            Dim lMetaDataProvider As IMetaDataProvider = MetaDataProviderFactory.GetInstance(lCS.ProviderName)

            If (lMetaDataProvider Is Nothing) Then
                ReportActivity(String.Format("Unable to find metadata provider for [{0}].", lCS.Name))
            Else
                lMetaDataProvider.SetConnectionString(lCS.ConnectionString)

                ReportActivity(String.Format("Instance of metadata provider [{0}] has been loaded.", lMetaDataProvider.GetType().FullName))
                ReportActivity("Proceeding to run extraction...")
                ReportActivity()

                Dim lDataSource As New Entities.DataSource()

                lDataSource.DataSourceName = lCS.Name
                lDataSource.GeneratedNamespace = lCS.Name
                lDataSource.ProviderName = lCS.ProviderName

                lMetaProviders.Add(lDataSource.DataSourceName, lMetaDataProvider)

                lDataSource.Tables = lMetaDataProvider.GetTables()

                Dim resetEvents(lDataSource.Tables.Count - 1) As ManualResetEvent
                Dim i As Integer
                i = 0
                Dim state As ThreadableDB

                For Each lTable As Entities.Table In lDataSource.Tables
                    'Creating the manualResetEvent to know when this thread completes
                    resetEvents(i) = New ManualResetEvent(False)
                    'Pass this custom class as a parameter to the new thread
                    state = New ThreadableDB(lTable, Nothing, resetEvents(i))
                    'Adding to the ThreadPool and specifying the method to be executed
                    ThreadPool.QueueUserWorkItem(AddressOf FixTableNames, state)
                    i += 1
                    'lTable.ClassName = NameFixer.GetSingularClassName(lTable.Name)
                    'lTable.PluralClassName = NameFixer.GetPluralClassName(lTable.Name)
                Next

                For Each manualEvents As ManualResetEvent In resetEvents
                    manualEvents.WaitOne()
                Next
                resetEvents = Nothing
                state = Nothing

                lDataSource.Tables.Sort()
                ReportActivity(String.Format("Found {0} tables.", lDataSource.Tables.Count))

                lDataSource.Views = lMetaDataProvider.GetViews()

                Dim resetEventsView(lDataSource.Views.Count - 1) As ManualResetEvent
                i = 0

                For Each lView As Entities.View In lDataSource.Views
                    'Creating the manualResetEvent to know when this thread completes
                    resetEventsView(i) = New ManualResetEvent(False)
                    'Pass this custom class as a parameter to the new thread
                    state = New ThreadableDB(lView, Nothing, resetEventsView(i))
                    'Adding to the ThreadPool and specifying the method to be executed
                    ThreadPool.QueueUserWorkItem(AddressOf FixViewNames, state)
                    i += 1
                    'lView.ClassName = NameFixer.GetSingularClassName(lView.Name)
                    'lView.PluralClassName = NameFixer.GetPluralClassName(lView.Name)
                Next

                For Each manualEvents As ManualResetEvent In resetEventsView
                    manualEvents.WaitOne()
                Next
                resetEventsView = Nothing
                state = Nothing

                lDataSource.Views.Sort()
                ReportActivity(String.Format("Found {0} views.", lDataSource.Views.Count))

                lDataSource.StoredProcedures = lMetaDataProvider.GetStoredProcedures()
                lDataSource.StoredProcedures.Sort()
                ReportActivity(String.Format("Found {0} stored procedures.", lDataSource.StoredProcedures.Count))

                Me._Overall = Me._Overall + lDataSource.Tables.Count + lDataSource.Views.Count + lDataSource.StoredProcedures.Count

                lProject.DataSources.Add(lDataSource)
                ReportActivity()
            End If
        Next

        'Fill columns and parameters, etc.
        Me.PopulateDBObjects(lProject, lMetaProviders)

        ReportActivity()
        ReportActivity("Extraction process is now completed.")
        ReportActivity()

        lProject.UpdateLanguageMappings()
        Return lProject
    End Function

    Private Sub PersistInfo(ByVal SourceObject As Object, ByRef TargetObject As Object)
        Dim SourceType As Type = SourceObject.GetType()

        Dim lProperties As System.Reflection.PropertyInfo() = SourceType.GetProperties()

        For Each lProp As System.Reflection.PropertyInfo In lProperties
            Dim lCustomAttribute As ComponentModel.PersistAfterRefreshSchemaAttribute = CType(Attribute.GetCustomAttribute(lProp, GetType(ComponentModel.PersistAfterRefreshSchemaAttribute)), ComponentModel.PersistAfterRefreshSchemaAttribute)

            If Not (lCustomAttribute Is Nothing) Then
                If (lCustomAttribute.Persist) Then
                    TargetObject.GetType().GetProperty(lProp.Name).SetValue(TargetObject, SourceObject.GetType().GetProperty(lProp.Name).GetValue(SourceObject, Nothing), Nothing)
                End If
            End If
        Next
    End Sub


    ''' <summary>
    ''' Sets the parent for each element in the hierarchy tree.
    ''' </summary>
    Public Sub UpdateParenthood(ByRef project As Entities.Project)
        If Not (project Is Nothing) Then
            For Each lDatasource As Entities.DataSource In project.DataSources
                lDatasource.SetProject(project)

                For Each lTable As Entities.Table In lDatasource.Tables
                    lTable.SetDataSource(lDatasource)
                Next

                For Each lView As Entities.View In lDatasource.Views
                    lView.SetDataSource(lDatasource)
                Next

                For Each lSP As Entities.StoredProcedure In lDatasource.StoredProcedures
                    lSP.SetDataSource(lDatasource)
                Next
            Next
        End If
    End Sub



    Private Function FilterTables(ByVal filter As String, ByVal tables As List(Of Entities.Table)) As List(Of Entities.Table)
        Dim lReturnValue As New List(Of Entities.Table)

        For Each lTable As Entities.Table In tables
            If (lTable.Name.ToLower().StartsWith(filter.ToLower())) Then
                lReturnValue.Add(lTable)
            End If
        Next

        Return lReturnValue
    End Function

    Private Function FilterViews(ByVal filter As String, ByVal views As List(Of Entities.View)) As List(Of Entities.View)
        Dim lReturnValue As New List(Of Entities.View)

        For Each lView As Entities.View In views
            If (lView.Name.ToLower().StartsWith(filter.ToLower())) Then
                lReturnValue.Add(lView)
            End If
        Next

        Return lReturnValue
    End Function

    Private Function FilterSPs(ByVal filter As String, ByVal sps As List(Of Entities.StoredProcedure)) As List(Of Entities.StoredProcedure)
        Dim lReturnValue As New List(Of Entities.StoredProcedure)

        For Each lSP As Entities.StoredProcedure In sps
            If (lSP.Name.ToLower().StartsWith(filter.ToLower())) Then
                lReturnValue.Add(lSP)
            End If
        Next

        Return lReturnValue
    End Function

    Private Sub ApplyFilters(ByRef project As Entities.Project)
        For Each lDS As Entities.DataSource In project.DataSources
            If (lDS.IncludePrefixes <> String.Empty) Then
                Dim lAllFilters As String() = lDS.IncludePrefixes.Split(",")

                Dim lAllTables As List(Of Entities.Table) = lDS.Tables
                Dim lAllViews As List(Of Entities.View) = lDS.Views
                Dim lAllSps As List(Of Entities.StoredProcedure) = lDS.StoredProcedures

                lDS.Tables = New List(Of Entities.Table)
                lDS.Views = New List(Of Entities.View)
                lDS.StoredProcedures = New List(Of Entities.StoredProcedure)

                For Each lFilter As String In lAllFilters
                    lDS.Tables.AddRange(FilterTables(Trim(lFilter), lAllTables))
                    lDS.Views.AddRange(FilterViews(Trim(lFilter), lAllViews))
                    lDS.StoredProcedures.AddRange(FilterSPs(Trim(lFilter), lAllSps))
                Next
            End If
        Next
    End Sub

    Public Sub UpdateProject(ByRef pProject As Entities.Project)
        Dim lNewProject As Entities.Project = Nothing
        Dim lOldProject As Entities.Project = Me.LoadProjectFromFile()

        If (lOldProject Is Nothing) Then
            pProject = Me.LoadProject()
        Else
            lNewProject = Me.LoadProject()

            PersistInfo(pProject, lNewProject)
            For Each lSourceDataSource As Entities.DataSource In pProject.DataSources
                For Each lTargetDataSource As Entities.DataSource In lNewProject.DataSources
                    If (lSourceDataSource.DataSourceName = lTargetDataSource.DataSourceName) Then
                        PersistInfo(lSourceDataSource, lTargetDataSource)

                        For Each lTargetTable As Entities.Table In lTargetDataSource.Tables
                            For Each lSourceTable As Entities.Table In lSourceDataSource.Tables
                                If ((lSourceTable.Name = lTargetTable.Name) And (lSourceTable.Schema = lTargetTable.Schema)) Then
                                    PersistInfo(lSourceTable, lTargetTable)
                                    For Each lTargetColumn As Entities.Column In lTargetTable.Columns
                                        For Each lSourceColumn As Entities.Column In lSourceTable.Columns
                                            If (lSourceColumn.ColumnName = lTargetColumn.ColumnName) Then
                                                PersistInfo(lSourceColumn, lTargetColumn)
                                                Exit For
                                            End If
                                        Next
                                    Next
                                    Exit For
                                End If
                            Next
                        Next

                        For Each lTargetView As Entities.View In lTargetDataSource.Views
                            For Each lSourceView As Entities.View In lSourceDataSource.Views
                                If ((lSourceView.Name = lTargetView.Name) And (lSourceView.Schema = lTargetView.Schema)) Then
                                    PersistInfo(lSourceView, lTargetView)
                                    For Each lTargetColumn As Entities.Column In lTargetView.Columns
                                        For Each lSourceColumn As Entities.Column In lSourceView.Columns
                                            If (lSourceColumn.ColumnName = lTargetColumn.ColumnName) Then
                                                PersistInfo(lSourceColumn, lTargetColumn)
                                                Exit For
                                            End If
                                        Next
                                    Next
                                    Exit For
                                End If
                            Next
                        Next

                        For Each lTargetSP As Entities.StoredProcedure In lTargetDataSource.StoredProcedures
                            For Each lSourceSP As Entities.StoredProcedure In lSourceDataSource.StoredProcedures
                                If ((lSourceSP.Name = lTargetSP.Name) And (lSourceSP.Schema = lTargetSP.Schema)) Then
                                    PersistInfo(lSourceSP, lTargetSP)
                                    For Each lTargetParameter As Entities.StoredProcedureParameter In lTargetSP.Parameters
                                        For Each lSourceParameter As Entities.StoredProcedureParameter In lSourceSP.Parameters
                                            If (lSourceParameter.ParameterName = lTargetParameter.ParameterName) Then
                                                PersistInfo(lSourceParameter, lTargetParameter)
                                                Exit For
                                            End If
                                        Next
                                    Next
                                    Exit For
                                End If
                            Next
                        Next

                        Exit For
                    End If
                Next
            Next

            UpdateParenthood(lNewProject)
            ApplyFilters(lNewProject)
            pProject = lNewProject
            pProject.UpdateLanguageMappings()
            pProject.UpdateRelationShips()
        End If
    End Sub

    Private Function GetLocalConfigurationProjectFileName(ByVal pPathToFile As String) As String
        Dim lFileName As String = pPathToFile

        If (lFileName = String.Empty) Then
            lFileName = System.IO.Path.Combine( _
                System.IO.Directory.GetCurrentDirectory(), _
                String.Format("{0}\{1}", _
                Common.Constants.SCHEMA_PATH, _
                Common.Constants.SCHEMADISCOVERY_CONFIGURATION_FILE))
        End If

        Return lFileName
    End Function

    Public Sub SaveProjectToFile(ByVal pProject As Entities.Project, Optional ByVal pPathToFile As String = "")
        Dim lSerializer As New AppSimplicity.SchemaDiscovery.Serialization.XMLSerializer(Of Entities.Project)

        Dim lFileName As String = GetLocalConfigurationProjectFileName(pPathToFile)
        If Not (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(lFileName))) Then
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(lFileName))
        End If

        ReportActivity(String.Format("Persisting project settings to [{0}].", lFileName))
        System.IO.File.WriteAllText(lFileName, lSerializer.SerializeToString(pProject))
        ReportActivity("Settings were succesfully saved.")
    End Sub

    ''' <summary>
    ''' Loads an SchemaDiscovery project from file.
    ''' </summary>
    ''' <param name="pPathToFile">Indicates the full path of the configuration file.</param>
    ''' <returns>If deserialization was succesful returns the instance of the project.</returns>
    Public Function LoadProjectFromFile(Optional ByVal pPathToFile As String = "") As Entities.Project
        Dim lReturnValue As Entities.Project = Nothing

        Dim lFileName As String = Me.GetLocalConfigurationProjectFileName(pPathToFile)

        If (System.IO.File.Exists(lFileName)) Then
            ReportActivity(String.Format("Reading project from [{0}]...", lFileName))
            Dim lSerializer As New Serialization.XMLSerializer(Of Entities.Project)
            lReturnValue = lSerializer.DeserializeFromString(System.IO.File.ReadAllText(lFileName))

            ReportActivity("Project succesfully loaded.")
        Else
            ReportActivity("Project file was not found, proceeding to update schema from scratch...")
            lReturnValue = LoadProject()
        End If

        Me.UpdateParenthood(lReturnValue)

        Return lReturnValue
    End Function

#Region "Shared methods"
    Public Shared Function LoadProjectFromDisk(Optional ByVal pathToFile As String = "") As Entities.Project
        Dim lExtractor As New MetaDataExtractor()
        Return lExtractor.LoadProjectFromFile(pathToFile)
    End Function

    Public Shared Sub PersistProjectToDisk(ByVal project As Entities.Project, Optional ByVal pathToFile As String = "")
        Dim lExtractor As New MetaDataExtractor()
        lExtractor.SaveProjectToFile(project, pathToFile)
    End Sub
#End Region

End Class