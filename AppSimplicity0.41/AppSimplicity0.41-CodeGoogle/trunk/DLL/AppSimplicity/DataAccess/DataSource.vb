Namespace DataAccess
    Public Class DataSource

        Private _DataSourceName As String
        Public ReadOnly Property DataSourceName() As String
            Get
                Return _DataSourceName
            End Get
        End Property

        Private Function GetProviderType() As ProviderTypes
            Dim lReturnValue As ProviderTypes = ProviderTypes.Undefined

            Select Case Me._ProviderName
                Case "System.Data.Odbc"
                    lReturnValue = ProviderTypes.ODBC

                Case "System.Data.OleDb"
                    lReturnValue = ProviderTypes.OleDB

                Case "System.Data.OracleClient"
                    lReturnValue = ProviderTypes.Oracle

                Case "System.Data.SqlClient"
                    lReturnValue = ProviderTypes.SQLServer

                Case "System.Data.SqlServerCe.3.5", "Microsoft.SqlServerCe.Client.3.5"
                    lReturnValue = ProviderTypes.SQLServerCE

                Case "MySql.Data.MySqlClient"
                    lReturnValue = ProviderTypes.MySQL

                Case "System.Data.SQLite"
                    lReturnValue = ProviderTypes.SQLite

            End Select

            Return lReturnValue
        End Function

        Public ReadOnly Property ProviderType() As ProviderTypes
            Get
                Return Me.GetProviderType
            End Get
        End Property

        Private _ConnectionString As String
        Public Property ConnectionString() As String
            Get
                Return _ConnectionString
            End Get
            Set(ByVal value As String)
                _ConnectionString = value
            End Set
        End Property

        Private _ConnectionTimeOut As Integer
        Public Property ConnectionTimeOut() As Integer
            Get
                Return _ConnectionTimeOut
            End Get
            Set(ByVal value As Integer)
                _ConnectionTimeOut = value
            End Set
        End Property

        Private _ProviderName As String
        Public Property ProviderName() As String
            Get
                Return _ProviderName
            End Get
            Set(ByVal value As String)
                If (value = String.Empty) Then
                    _ProviderName = "System.Data.SqlClient"
                Else
                    _ProviderName = value
                End If

                Me.ValidateProviderName()
            End Set
        End Property

        Private Sub ValidateProviderName()
            Dim lIsValid As Boolean = False

            For Each lProviderName As String In Me.ValidProviderNames
                If (_ProviderName.ToLower = lProviderName.ToLower) Then
                    lIsValid = True
                    Exit For
                End If
            Next

            If Not (lIsValid) Then
                Throw New Exception(String.Format(My.Resources.ExceptionMessages.InvalidProviderName, _
                                                  _DataSourceName, _
                                                  String.Join(", ", Me.ValidProviderNames)))

            End If
        End Sub

        Private _ValidProviderNames As String() = { _
                    "System.Data.Odbc", _
                    "System.Data.OleDb", _
                    "System.Data.OracleClient", _
                    "System.Data.SqlClient", _
                    "System.Data.SqlServerCe.3.5", _
                    "MySql.Data.MySqlClient", _
                    "System.Data.SQLite", _
                    "Microsoft.SqlServerCe.Client.3.5"}

        Public ReadOnly Property ValidProviderNames() As String()
            Get
                Return _ValidProviderNames
            End Get
        End Property

        Public ReadOnly Property ConnectsThroughWebService() As Boolean
            Get
                Dim lReturnValue As Boolean = False

                If (Me.ConnectionString.ToLower.StartsWith("http://")) Then
                    lReturnValue = True
                End If

                If (Me.ConnectionString.ToLower.StartsWith("https://")) Then
                    lReturnValue = True
                End If

                Return lReturnValue
            End Get
        End Property

        Public Sub New(ByVal pDataSourceName As String)
            _DataSourceName = pDataSourceName
        End Sub

        Public Shared Function GetDataSourceFromConfigFile(ByVal pDataServiceName As String) As DataSource
            Dim lReturnValue As DataSource = Nothing

            Dim lCS As System.Configuration.ConnectionStringSettings = Nothing

            lCS = System.Configuration.ConfigurationManager.ConnectionStrings(pDataServiceName)

            If (lCS Is Nothing) Then
                Throw New Exception(String.Format(My.Resources.ExceptionMessages.CantReadConnectionString, pDataServiceName))
            Else
                lReturnValue = New DataSource(pDataServiceName)

                lReturnValue.ConnectionString = lCS.ConnectionString
                lReturnValue.ProviderName = lCS.ProviderName
                lReturnValue.ConnectionTimeOut = 60000
            End If

            Return lReturnValue
        End Function
    End Class
End Namespace

