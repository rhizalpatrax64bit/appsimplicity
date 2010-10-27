Imports System.Configuration

Namespace MetaDiscovery
    Public Class Provider

        Private _LanguageType As NetLanguageType

        Private _CS As ConnectionStringSettings

        Private _MetaData As MyMetaAPI
        <Browsable(False)> _
        Public ReadOnly Property MetaData() As MyMetaAPI
            Get
                If (_MetaData Is Nothing) Then
                    _MetaData = New MyMetaAPI(_LanguageType, _CS, Me._Project)
                End If
                Return _MetaData
            End Get
        End Property

        Private _Project As MetaDiscovery.Project
        <Browsable(False)> _
        Public ReadOnly Property Project() As MetaDiscovery.Project
            Get
                Return _Project
            End Get
        End Property

#Region "Exposed Properties"
        <System.ComponentModel.DisplayName("Provider Type"), Category("Metadata"), Description("The database type of the provider")> _
        Public ReadOnly Property Type() As String
            Get
                Return MetaData.DbRoot.DriverString
            End Get
        End Property

        <System.ComponentModel.DisplayName("Name"), Category("Metadata"), Description("Gets the name of the provider (given by connection string)")> _
        ReadOnly Property Name() As String
            Get
                Return _CS.Name
            End Get
        End Property

        <System.ComponentModel.DisplayName("DatabaseName"), Category("Metadata"), Description("Gets the name of the underlying Database")> _
        ReadOnly Property DatabaseName() As String
            Get
                Return MetaData.DbRoot.DefaultDatabase.Name
            End Get
        End Property

        Private _Tables As New List(Of MetaDiscovery.Table)
        <Browsable(False)> _
        Public ReadOnly Property Tables() As List(Of MetaDiscovery.Table)
            Get
                Return _Tables
            End Get
        End Property

        Private _Views As New List(Of MetaDiscovery.View)
        <Browsable(False)> _
        Public ReadOnly Property Views() As List(Of MetaDiscovery.View)
            Get
                Return _Views
            End Get
        End Property

        Private _Procedures As New List(Of MetaDiscovery.Procedure)
        <Browsable(False)> _
        Public ReadOnly Property Procedures() As List(Of MetaDiscovery.Procedure)
            Get
                Return _Procedures
            End Get
        End Property

        <System.ComponentModel.DisplayName("Generate foreign keys as properties"), Category("Code Generation"), Description("Wether or not foreign keys must be generated as properties in generated classes")> _
        Public Property GenerateRelationsAsProperties() As Boolean
            Get
                Dim lKey As String = "GenerateRelationsAsProperties"
                Me.ValidatePropertyInstance(lKey, True)

                Return MetaData.DbRoot.DefaultDatabase.Properties(lKey).Value
            End Get
            Set(ByVal value As Boolean)
                Dim lKey As String = "GenerateRelationsAsProperties"
                Me.ValidatePropertyInstance(lKey, True)

                MetaData.DbRoot.DefaultDatabase.Properties(lKey).Value = value
                Me.SaveChanges()
            End Set
        End Property

        Public Enum DataServiceScopeTypes
            _Public
            _Friend
        End Enum

        <System.ComponentModel.DisplayName("Scope for the DataService Generated Class"), Category("Code Generation"), Description("Sets the scope for the DataService Generated Class")> _
        Public Property DataServiceScope() As DataServiceScopeTypes
            Get
                Dim lKey As String = "DataServiceScope"
                Me.ValidatePropertyInstance(lKey, DataServiceScopeTypes._Public)

                Return MetaData.DbRoot.DefaultDatabase.Properties(lKey).Value
            End Get
            Set(ByVal value As DataServiceScopeTypes)
                Dim lKey As String = "DataServiceScope"
                Me.ValidatePropertyInstance(lKey, DataServiceScopeTypes._Public)

                MetaData.DbRoot.DefaultDatabase.Properties(lKey).Value = value
                Me.SaveChanges()
            End Set
        End Property

        <System.ComponentModel.DisplayName("Generated Namespace"), Category("Code Generation"), Description("Gets or sets the name for this provider")> _
        Public Property GeneratedNamespace() As String
            Get
                Dim lKey As String = "GeneratedNamespace"
                Me.ValidatePropertyInstance(lKey, Me.DatabaseName)

                Return MetaData.DbRoot.DefaultDatabase.Properties(lKey).Value
            End Get
            Set(ByVal value As String)
                Dim lKey As String = "GeneratedNamespace"
                Me.ValidatePropertyInstance(lKey, Me.DatabaseName)

                MetaData.DbRoot.DefaultDatabase.Properties(lKey).Value = value
                Me.SaveChanges()
            End Set
        End Property


        <System.ComponentModel.DisplayName("Include Prefix"), Category("Code Generation"), Description("If this property is set only objects with this prefix will be included")> _
        Public Property IncludePrefix() As String
            Get
                Dim lKey As String = "IncludePrefix"
                Me.ValidatePropertyInstance(lKey, "")

                Return MetaData.DbRoot.DefaultDatabase.Properties(lKey).Value
            End Get
            Set(ByVal value As String)
                Dim lKey As String = "IncludePrefix"
                Me.ValidatePropertyInstance(lKey, "")

                MetaData.DbRoot.DefaultDatabase.Properties(lKey).Value = value
                Me.SaveChanges()
            End Set
        End Property


        <System.ComponentModel.DisplayName("Use Stored Procedures for CRUD "), Category("Code Generation"), Description("Gets or sets if provider should use Stored procedures for CRUD")> _
        Public Property UseSPs() As Boolean
            Get
                Dim lKey As String = "UseSPs"
                Me.ValidatePropertyInstance(lKey, False)

                Return MetaData.DbRoot.DefaultDatabase.Properties(lKey).Value
            End Get
            Set(ByVal value As Boolean)
                Dim lKey As String = "UseSPs"
                Me.ValidatePropertyInstance(lKey, False)

                MetaData.DbRoot.DefaultDatabase.Properties(lKey).Value = value
                Me.SaveChanges()
            End Set
        End Property

        Protected Sub ValidatePropertyInstance(ByVal pKey As String, ByVal pDefaultValue As String)
            If MetaData.DbRoot.DefaultDatabase.Properties(pKey) Is Nothing Then
                MetaData.DbRoot.DefaultDatabase.Properties.AddKeyValue(pKey, pDefaultValue)
                Me.SaveChanges()
            End If
        End Sub
#End Region

        Private Sub ExtractForeignKeys()
            Console.WriteLine("Extracting foreign keys...")
            For Each lTable As MetaDiscovery.Table In Me.Tables
                Try
                    lTable.ExtractForeignKeys()
                Catch ex As Exception
                    Console.WriteLine("Ooops, something went wrong trying to read a foreign key")
                    Console.WriteLine("Details:")
                    Console.WriteLine(ex.Message)
                End Try
            Next
        End Sub

        Public Sub FillEntityList()
            Console.WriteLine("Retrieving Tables...")
            Console.WriteLine(" ")
            For Each lTable As MyMeta.Table In MetaData.DbRoot.DefaultDatabase.Tables
                Try
                    Dim lIncludeTable As Boolean = True

                    Select Case lTable.GetType.FullName
                        Case "MyMeta.SQLite.SQLiteTable"
                            If (lTable.Name.ToLower = "sqlite_master") Then
                                lIncludeTable = False
                            End If

                            If (lTable.Name.ToLower = "sqlite_sequence") Then
                                lIncludeTable = False
                            End If

                            If (lTable.Name.ToLower = "xp_proc") Then
                                lIncludeTable = False
                            End If
                        Case Else

                    End Select

                    If (Me.IncludePrefix <> String.Empty) Then
                        If lTable.Name.StartsWith(Me.IncludePrefix) Then
                            lIncludeTable = True
                        Else
                            lIncludeTable = False
                        End If
                    End If

                    If (lIncludeTable) Then
                        Dim TableItem As New MetaDiscovery.Table(lTable, Me)
                        Me.Tables.Add(TableItem)
                    End If

                Catch ex As Exception
                    Console.WriteLine("Ooops, something went wrong trying to read a table")
                    Console.WriteLine("Details:")
                    Console.WriteLine(ex.Message)
                End Try
            Next
            Console.WriteLine(String.Format("Found {0} Tables", Me.Tables.Count))
            Console.WriteLine(" ")

            Console.WriteLine("Retrieving Views...")
            For Each lView As MyMeta.View In MetaData.DbRoot.DefaultDatabase.Views
                Try
                    Dim TableItem As New MetaDiscovery.View(lView, Me)


                    Dim lIncludeView As Boolean = True
                    If (Me.IncludePrefix <> String.Empty) Then
                        If lView.Name.StartsWith(Me.IncludePrefix) Then
                            lIncludeView = True
                        Else
                            lIncludeView = False
                        End If
                    End If

                    If (lIncludeView) Then
                        Me.Views.Add(TableItem)
                    End If

                Catch ex As Exception
                    Console.WriteLine("Ooops, something went wrong trying to read a view")
                    Console.WriteLine("Details:")
                    Console.WriteLine(ex.Message)
                End Try
            Next
            Console.WriteLine(String.Format("Found {0} Views", Me.Views.Count))
            Console.WriteLine(" ")

            Console.WriteLine("Retrieving Procedures...")
            For Each lProcedure As MyMeta.Procedure In MetaData.DbRoot.DefaultDatabase.Procedures
                Try
                    Dim lIncludeProcedure As Boolean = True

                    If (lProcedure.Name.ToLower.StartsWith("sp_")) Then
                        lIncludeProcedure = False
                    End If

                    If (lProcedure.Name.ToLower.StartsWith("xp_")) Then
                        lIncludeProcedure = False
                    End If

                    If (lProcedure.Name.ToLower.StartsWith("dt_")) Then
                        lIncludeProcedure = False
                    End If

                    If (Me.IncludePrefix <> String.Empty) Then
                        If lProcedure.Name.StartsWith(Me.IncludePrefix) Then
                            lIncludeProcedure = True
                        Else
                            lIncludeProcedure = False
                        End If
                    End If

                    If (lIncludeProcedure) Then
                        If Not (lProcedure.Schema.ToLower = "sys") Then
                            Dim lProcedureItem As New MetaDiscovery.Procedure(lProcedure, Me)
                            Me.Procedures.Add(lProcedureItem)
                        End If
                    End If

                Catch ex As Exception
                    Console.WriteLine("Oops, something went wrong trying to read a stored procedure")
                    Console.WriteLine("Details:")
                    Console.WriteLine(ex.Message)
                End Try
            Next

            Console.WriteLine(String.Format("Found {0} Stored Procedures", Me.Procedures.Count))
            Console.WriteLine(" ")

            ExtractForeignKeys()
        End Sub

        Public Sub InitializeConfigurationFile()
            Dim lKey As String = "GeneratedNamespace"
            If (MetaData.DbRoot.DefaultDatabase.Properties(lKey) Is Nothing) Then
                MetaData.DbRoot.DefaultDatabase.Properties.AddKeyValue(lKey, Me.DatabaseName)
                MetaData.DbRoot.SaveUserMetaData()
            End If
        End Sub

        Public Sub SaveChanges()
            Me.MetaData.DbRoot.SaveUserMetaData()
        End Sub

        Private Sub FixOleDBConnectionString()
            If (_CS.ProviderName.ToLower = "System.Data.SQLClient".ToLower) Then
                If Not (_CS.ConnectionString.ToUpper.Contains("SQLOLEDB")) Then
                    If (_CS.ConnectionString.EndsWith(";")) Then
                        Me._CS.ConnectionString = String.Format("{0};Provider=SQLOLEDB;", Me._CS.ConnectionString)
                    Else
                        Me._CS.ConnectionString = String.Format("{0}Provider=SQLOLEDB;", Me._CS.ConnectionString)
                    End If
                End If
            End If
        End Sub

        Public Sub New(ByVal pCS As ConnectionStringSettings, ByVal pProject As MetaDiscovery.Project, Optional ByVal pLanguage As NetLanguageType = NetLanguageType.VBNET)
            _LanguageType = pLanguage
            _Project = pProject
            _CS = pCS

            FixOleDBConnectionString()

            FillEntityList()
            InitializeConfigurationFile()
        End Sub
    End Class
End Namespace

