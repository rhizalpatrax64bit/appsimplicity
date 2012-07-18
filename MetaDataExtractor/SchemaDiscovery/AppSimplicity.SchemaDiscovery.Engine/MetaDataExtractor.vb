Imports SchemaDiscovery.Entities

Public Class MetaDataExtractor

    Public Function LoadProject() As Project

    End Function

    'Private _WorkerProcess As System.ComponentModel.BackgroundWorker = Nothing

    'Private _Overall As Integer = 100
    'Private _CurrentProgress As Integer = 0

    'Public Sub AttachBackgroundProcess(ByVal pBP As System.ComponentModel.BackgroundWorker)
    '    _WorkerProcess = pBP
    'End Sub

    'Private Sub ReportActivity(Optional ByVal pMessage As String = "")
    '    If (_WorkerProcess Is Nothing) Then
    '        Console.WriteLine(pMessage)
    '    Else
    '        If (pMessage = String.Empty) Then
    '            _WorkerProcess.ReportProgress(Math.Round((_CurrentProgress * 100) / _Overall))
    '        Else
    '            _WorkerProcess.ReportProgress(Math.Round((_CurrentProgress * 100) / _Overall), pMessage)
    '        End If
    '    End If
    'End Sub

    'Public Sub DetachBackgroundProcess()
    '    _WorkerProcess = Nothing
    'End Sub

    'Public Function LoadProject() As Entities.Project
    '    Dim lProject As New Entities.Project

    '    'Load current vbproj/csproj settings:
    '    Dim lVSProject As VisualStudio.Project = VisualStudio.Project.GetCurrentProject()
    '    If Not (lVSProject Is Nothing) Then
    '        lProject.AssemblyName = lVSProject.AssemblyName
    '        lProject.RootNamespace = lVSProject.RootNamespace
    '    End If

    '    ReportActivity("Running schema extraction")
    '    ReportActivity("Looking for connections in .config file...")

    '    For Each lCS As ConnectionStringSettings In Utilities.ConnectionSettings.GetAllConnections()
    '        ReportActivity(String.Format("Runing metadata extraction for [{0}]", lCS.Name))
    '        Dim lMetaDataProvider As IMetaDataProvider = MetaDataProviderFactory.LoadProvider(lCS.ProviderName)

    '        If (lMetaDataProvider Is Nothing) Then
    '            ReportActivity(String.Format("Unable to find metadata provider for [{0}].", lCS.Name))
    '        Else
    '            lMetaDataProvider.SetConnectionSettings(lCS)
    '            ReportActivity(String.Format("Instance of metadata provider [{0}] has been loaded.", lMetaDataProvider.GetType().FullName))
    '            ReportActivity("Proceeding to run extraction...")
    '            ReportActivity()

    '            Dim lDataSource As New Entities.DataSource()

    '            lDataSource.DataSourceName = lCS.Name
    '            lDataSource.GeneratedNamespace = lCS.Name
    '            lDataSource.ProviderName = lCS.ProviderName

    '            lDataSource.Tables = lMetaDataProvider.GetTables()
    '            ReportActivity(String.Format("Found {0} tables.", lDataSource.Tables.Count))
    '            lDataSource.Views = lMetaDataProvider.GetViews()
    '            ReportActivity(String.Format("Found {0} views.", lDataSource.Views.Count))
    '            lDataSource.StoredProcedures = lMetaDataProvider.GetStoredProcedures()
    '            ReportActivity(String.Format("Found {0} stored procedures.", lDataSource.StoredProcedures.Count))

    '            Me._Overall = lDataSource.Tables.Count + lDataSource.Views.Count + lDataSource.StoredProcedures.Count

    '            If (lDataSource.Tables.Count > 0) Then
    '                ReportActivity()
    '                ReportActivity("Now fetching tables metadata...")
    '                For Each lTable As Entities.Table In lDataSource.Tables
    '                    lTable.Columns = lMetaDataProvider.GetColumns(lTable)
    '                    lTable.Keys = lMetaDataProvider.GetKeys(lTable)
    '                    ReportActivity(lTable.QualifiedName)
    '                    _CurrentProgress += 1
    '                    Me.ReportActivity()
    '                Next
    '            End If

    '            If (lDataSource.Views.Count > 0) Then
    '                ReportActivity()
    '                ReportActivity("Now fetching views metadata...")
    '                For Each lView As Entities.View In lDataSource.Views
    '                    lView.Columns = lMetaDataProvider.GetColumns(lView)
    '                    ReportActivity(lView.QualifiedName)
    '                    _CurrentProgress += 1
    '                    ReportActivity()
    '                Next
    '            End If

    '            If (lDataSource.StoredProcedures.Count > 0) Then
    '                ReportActivity()
    '                ReportActivity("Now fetching stored procedures metadata...")
    '                For Each lSp As Entities.StoredProcedure In lDataSource.StoredProcedures
    '                    lSp.Parameters = lMetaDataProvider.GetStoredProcedureParameters(lSp)
    '                    ReportActivity(lSp.QualifiedName)
    '                    _CurrentProgress += 1
    '                    Me.ReportActivity()
    '                Next
    '            End If

    '            lDataSource.SetProject(lProject)
    '            lProject.DataSources.Add(lDataSource)
    '            ReportActivity()
    '            ReportActivity(String.Format("Extraction from [{0}] completed successfully.", lDataSource.DataSourceName))
    '        End If
    '    Next

    '    _CurrentProgress = 0

    '    ReportActivity()
    '    ReportActivity("Extraction process is now completed.")
    '    ReportActivity()

    '    Return lProject
    'End Function


    'Private Sub PersistInfo(ByVal SourceObject As Object, ByRef TargetObject As Object)
    '    Dim SourceType As Type = SourceObject.GetType()

    '    Dim lProperties As System.Reflection.PropertyInfo() = SourceType.GetProperties()

    '    For Each lProp As System.Reflection.PropertyInfo In lProperties
    '        Dim lCustomAttribute As PersistAfterRefreshSchemaAttribute = CType(Attribute.GetCustomAttribute(lProp, GetType(PersistAfterRefreshSchemaAttribute)), PersistAfterRefreshSchemaAttribute)

    '        If Not (lCustomAttribute Is Nothing) Then
    '            If (lCustomAttribute.Persist) Then
    '                TargetObject.GetType().GetProperty(lProp.Name).SetValue(TargetObject, SourceObject.GetType().GetProperty(lProp.Name).GetValue(SourceObject, Nothing), Nothing)
    '            End If
    '        End If
    '    Next
    'End Sub



    'Public Sub UpdateProject(ByRef pProject As Entities.Project)
    '    Dim lNewProject As Entities.Project = Nothing
    '    Dim lOldProject As Entities.Project = Me.LoadProjectFromFile()

    '    If (lOldProject Is Nothing) Then
    '        pProject = Me.LoadProject()
    '    Else
    '        lNewProject = Me.LoadProject()

    '        PersistInfo(pProject, lNewProject)
    '        For Each lSourceDataSource As Entities.DataSource In pProject.DataSources
    '            For Each lTargetDataSource As Entities.DataSource In lNewProject.DataSources
    '                If (lSourceDataSource.DataSourceName = lTargetDataSource.DataSourceName) Then
    '                    PersistInfo(lSourceDataSource, lTargetDataSource)

    '                    For Each lTargetTable As Entities.Table In lTargetDataSource.Tables
    '                        For Each lSourceTable As Entities.Table In lSourceDataSource.Tables
    '                            If ((lSourceTable.Name = lTargetTable.Name) And (lSourceTable.Schema = lTargetTable.Schema)) Then
    '                                PersistInfo(lSourceTable, lTargetTable)
    '                                For Each lTargetColumn As Entities.Column In lTargetTable.Columns
    '                                    For Each lSourceColumn As Entities.Column In lSourceTable.Columns
    '                                        If (lSourceColumn.ColumnName = lTargetColumn.ColumnName) Then
    '                                            PersistInfo(lSourceColumn, lTargetColumn)
    '                                            Exit For
    '                                        End If
    '                                    Next
    '                                Next
    '                                Exit For
    '                            End If
    '                        Next
    '                    Next

    '                    For Each lTargetView As Entities.View In lTargetDataSource.Views
    '                        For Each lSourceView As Entities.View In lSourceDataSource.Views
    '                            If ((lSourceView.Name = lTargetView.Name) And (lSourceView.Schema = lTargetView.Schema)) Then
    '                                PersistInfo(lSourceView, lTargetView)
    '                                For Each lTargetColumn As Entities.Column In lTargetView.Columns
    '                                    For Each lSourceColumn As Entities.Column In lSourceView.Columns
    '                                        If (lSourceColumn.ColumnName = lTargetColumn.ColumnName) Then
    '                                            PersistInfo(lSourceColumn, lTargetColumn)
    '                                            Exit For
    '                                        End If
    '                                    Next
    '                                Next
    '                                Exit For
    '                            End If
    '                        Next
    '                    Next

    '                    For Each lTargetSP As Entities.StoredProcedure In lTargetDataSource.StoredProcedures
    '                        For Each lSourceSP As Entities.StoredProcedure In lSourceDataSource.StoredProcedures
    '                            If ((lSourceSP.Name = lTargetSP.Name) And (lSourceSP.Schema = lTargetSP.Schema)) Then
    '                                PersistInfo(lSourceSP, lTargetSP)
    '                                For Each lTargetParameter As Entities.StoredProcedureParameter In lTargetSP.Parameters
    '                                    For Each lSourceParameter As Entities.StoredProcedureParameter In lSourceSP.Parameters
    '                                        If (lSourceParameter.ParameterName = lTargetParameter.ParameterName) Then
    '                                            PersistInfo(lSourceParameter, lTargetParameter)
    '                                            Exit For
    '                                        End If
    '                                    Next
    '                                Next
    '                                Exit For
    '                            End If
    '                        Next
    '                    Next

    '                    Exit For
    '                End If
    '            Next
    '        Next

    '        For Each lDS As Entities.DataSource In lNewProject.DataSources
    '            lDS.SetProject(lNewProject)
    '            lDS.UpdateLanguageMappings()
    '        Next

    '        pProject = lNewProject
    '    End If
    'End Sub

    'Private Function GetLocalConfigurationProjectFileName(ByVal pPathToFile As String) As String
    '    Dim lFileName As String = pPathToFile

    '    If (lFileName = String.Empty) Then
    '        lFileName = System.IO.Path.Combine( _
    '            System.IO.Directory.GetCurrentDirectory(), _
    '            String.Format("{0}\{1}", _
    '            Common.Constants.SCHEMA_PATH, _
    '            Common.Constants.SCHEMADISCOVERY_CONFIGURATION_FILE))
    '    End If

    '    Return lFileName
    'End Function

    'Public Sub SaveProjectToFile(ByVal pProject As Entities.Project, Optional ByVal pPathToFile As String = "")
    '    Dim lSerializer As New Utilities.XMLSerializer(Of Entities.Project)

    '    Dim lFileName As String = GetLocalConfigurationProjectFileName(pPathToFile)
    '    If Not (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(lFileName))) Then
    '        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(lFileName))
    '    End If

    '    ReportActivity(String.Format("Persisting project settings to [{0}].", lFileName))
    '    Utilities.File.WriteToFile(lFileName, lSerializer.SerializeToString(pProject))
    '    ReportActivity("Settings were succesfully saved.")
    'End Sub

    ' ''' <summary>
    ' ''' Loads an SchemaDiscovery project from file.
    ' ''' </summary>
    ' ''' <param name="pPathToFile">Indicates the full path of the configuration file.</param>
    ' ''' <returns>If deserialization was succesful returns the instance of the project.</returns>
    'Public Function LoadProjectFromFile(Optional ByVal pPathToFile As String = "") As Entities.Project
    '    Dim lReturnValue As Entities.Project = Nothing

    '    Dim lSerializer As New Utilities.XMLSerializer(Of Entities.Project)
    '    Dim lFileName As String = Me.GetLocalConfigurationProjectFileName(pPathToFile)

    '    If (System.IO.File.Exists(lFileName)) Then
    '        ReportActivity(String.Format("Reading project from [{0}]...", lFileName))
    '        lReturnValue = lSerializer.DeserializeFromString(Utilities.File.GetFileText(lFileName))
    '        If Not (lReturnValue Is Nothing) Then
    '            For Each lDS As Entities.DataSource In lReturnValue.DataSources
    '                lDS.SetProject(lReturnValue)
    '                lDS.UpdateLanguageMappings()
    '            Next
    '        End If
    '        ReportActivity("Project succesfully loaded.")
    '    Else
    '        ReportActivity("Project file was not found, proceeding to update schema from scratch...")
    '        lReturnValue = LoadProject()
    '    End If

    '    lReturnValue.UpdateParenthood()

    '    Return lReturnValue
    'End Function

#Region "Shared methods"
    Public Shared Function LoadProjectFromDisk(Optional ByVal pathToFile As String = "") As Entities.Project
        'Dim lFactory As New Project()
        'Return lFactory.LoadProjectFromFile(pathToFile)
    End Function

    Public Shared Sub PersistProjectToDisk(ByVal project As Entities.Project, Optional ByVal pathToFile As String = "")
        'Dim lFactory As New Project
        'lFactory.SaveProjectToFile(project, pathToFile)
    End Sub
#End Region

End Class
