''' <summary>
''' The intended purpose for this class is to wrap the connection settings for data access.
''' Connection settings will be retrieved through IConnectionProvider concrete classes.
''' </summary>
<Serializable()> _
Public Class ConnectionInfo

    Private _DataSourceName As String
    ''' <summary>
    ''' The unique name of the datasource in the connection 
    ''' </summary>
    ''' <value></value>
    Public Property DataSourceName() As String
        Get
            Return _DataSourceName
        End Get
        Set(ByVal value As String)
            _DataSourceName = value
        End Set
    End Property

    Private _ConnectionString As String
    ''' <summary>
    ''' The connection string.
    ''' </summary>    
    Public Property ConnectionString() As String
        Get
            Return _ConnectionString
        End Get
        Set(ByVal value As String)
            _ConnectionString = value
        End Set
    End Property

    Private _ConnectionTimeOut As Integer = 6000
    ''' <summary>
    ''' Gets or sets maximum time to wait for an execution of a dataccess command. 
    ''' If this time its exceeded dataservice provider will throw an exception.
    ''' </summary>    
    Public Property ConnectionTimeOut() As Integer
        Get
            Return _ConnectionTimeOut
        End Get
        Set(ByVal value As Integer)
            _ConnectionTimeOut = value
        End Set
    End Property

    Private _ProviderName As String
    ''' <summary>
    ''' The invariant Ado.Net provider factory Namespace.
    ''' </summary>    
    Public Property ProviderName() As String
        Get
            Return _ProviderName
        End Get
        Set(ByVal value As String)
            _ProviderName = value
        End Set
    End Property

    Public Sub New(ByVal pDataSourceName As String)
        _DataSourceName = pDataSourceName
    End Sub

    Public Sub New()
        _DataSourceName = "Undefined"
    End Sub

    Public Sub LoadSettings(ConnectionSettings As System.Configuration.ConnectionStringSettings)
        Me.ProviderName = ConnectionSettings.ProviderName
        Me.DataSourceName = ConnectionSettings.Name
        Me.ConnectionString = ConnectionSettings.ConnectionString
    End Sub

End Class


