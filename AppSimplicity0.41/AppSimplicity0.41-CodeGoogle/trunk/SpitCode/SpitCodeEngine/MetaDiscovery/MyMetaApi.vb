Imports System.Configuration
Imports System.IO

Namespace MetaDiscovery
    Public Class MyMetaAPI

        Private _LanguageType As NetLanguageType

        Private ReadOnly Property SettingsPath() As String
            Get
                'TODO: Read this from registry
                Return String.Format("{0}\Settings\", Me._Project.WorkingDirectory)
            End Get
        End Property

        Private Function GetLanguageMapping() As String
            Dim lLanguage As String = String.Empty
            Select Case (Me._LanguageType)
                Case NetLanguageType.VBNET
                    Select Case Me.DataAccessDriver
                        Case MyMeta.dbDriver.SQL
                            lLanguage = "VB.NET"
                        Case MyMeta.dbDriver.SQLite
                            lLanguage = "VB.NET (SQLite v3.x)"
                        Case MyMeta.dbDriver.MySql2
                            lLanguage = "MySQL Connector/Net (VB.NET)"
                    End Select
                Case NetLanguageType.CSharp
                    lLanguage = "C#"
            End Select
            Return lLanguage
        End Function

        Private ReadOnly Property LanguageMappingFileName() As String
            Get
                Return String.Format("{0}Languages.xml", Me.SettingsPath)
            End Get
        End Property

        Private ReadOnly Property DbTargetMappingFileName() As String
            Get
                Return String.Format("{0}DbTargets.xml", Me.SettingsPath)
            End Get
        End Property

        'TODO: Add more providers:
        Private ReadOnly Property DBTarget() As String
            Get
                Select Case DataAccessDriver
                    Case MyMeta.dbDriver.SQL
                        Return "DbType"
                    Case MyMeta.dbDriver.SQLite
                        Return "SQLite.NET v3.x"
                    Case MyMeta.dbDriver.MySql2
                        Return "Net DbType"
                End Select
                Return "DbType"
            End Get
        End Property

        Private _CS As ConnectionStringSettings
        Private ReadOnly Property DataAccessDriver() As MyMeta.dbDriver
            Get
                'TODO: Add more providers:
                Dim lReturnValue As MyMeta.dbDriver = MyMeta.dbDriver.SQL

                Select Case _CS.ProviderName
                    Case "System.Data.SqlClient", "System.Data.Odbc", "System.Data.OleDb", "System.Data.SqlServerCe.3.5", "Microsoft.SqlServerCe.Client.3.5"
                        lReturnValue = MyMeta.dbDriver.SQL

                    Case "System.Data.OracleClient"
                        lReturnValue = MyMeta.dbDriver.Oracle
                    
                    Case "MySql.Data.MySqlClient"
                        lReturnValue = MyMeta.dbDriver.MySql

                    Case "System.Data.SQLite"
                        lReturnValue = MyMeta.dbDriver.SQLite

                End Select

                Return lReturnValue
            End Get
        End Property

        Private ReadOnly Property ConfigFileName() As String
            Get
                Return String.Format("{0}\{1}.xml", Directory.GetCurrentDirectory, _DBRoot.DefaultDatabase.Name.Replace(" ", "").Replace("_", ""))
            End Get
        End Property

        Private _DBRoot As MyMeta.dbRoot
        Public ReadOnly Property DbRoot() As MyMeta.dbRoot
            Get
                If _DBRoot Is Nothing Then
                    _DBRoot = New MyMeta.dbRoot

                    _DBRoot.Connect(Me.DataAccessDriver, Me._CS.ConnectionString)


                    _DBRoot.DbTargetMappingFileName = Me.DbTargetMappingFileName
                    _DBRoot.DbTarget = Me.DBTarget

                    _DBRoot.LanguageMappingFileName = Me.LanguageMappingFileName
                    _DBRoot.Language = Me.GetLanguageMapping

                    _DBRoot.UserMetaDataFileName = Me.ConfigFileName
                End If
                Return _DBRoot
            End Get
        End Property

        Private _Project As MetaDiscovery.Project

        'TODO: Agregar mapas de lenguajes para otros proveedores:
        Public Sub New(ByVal pLanguage As NetLanguageType, ByVal pCS As ConnectionStringSettings, ByVal pProject As MetaDiscovery.Project)
            _LanguageType = pLanguage
            _CS = pCS
            _Project = pProject
        End Sub

    End Class
End Namespace

