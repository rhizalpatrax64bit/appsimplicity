Namespace DataAccess
    Public Class DataSource

        Private _DataSourceName As String
        Public ReadOnly Property DataSourceName() As String
            Get
                Return _DataSourceName
            End Get
        End Property

        Private _ProviderType As ProviderTypes
        Public Property ProviderType() As ProviderTypes
            Get
                Return _ProviderType
            End Get
            Set(ByVal value As ProviderTypes)
                Select Case value
                    Case ProviderTypes.MySQL
                        _ProviderName = "SQLServer"
                    Case ProviderTypes.Oracle
                        _ProviderName = "Oracle"
                    Case ProviderTypes.Oracle10g
                        _ProviderName = "Oracle10g"
                    Case ProviderTypes.SQLite
                        _ProviderName = "SQLite"
                End Select
                _ProviderType = value
            End Set
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
                    _ProviderName = "SQLServer"
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

        Private _ValidProviderNames As String() = {"SQLServer", "MySQL", "Oracle", "Oracle10g", "SQLite"}
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

