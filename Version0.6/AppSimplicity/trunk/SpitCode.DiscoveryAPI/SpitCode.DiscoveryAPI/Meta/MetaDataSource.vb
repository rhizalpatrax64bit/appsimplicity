Public Class MetaDataSource

    Public Enum DataSourceStatus
        Connected
        NotConnected
    End Enum

    Private _MetaProvider As Providers.DiscoveryProvider
    Public ReadOnly Property Meta() As Providers.DiscoveryProvider
        Get
            If _MetaProvider Is Nothing Then
                _MetaProvider = Providers.MetaProviderFactory.GetInstance(Me._DataSource)
            End If
            Return _MetaProvider
        End Get
    End Property

    Private _DataSource As AppSimplicity.DataAccess.DataSource

    Public Sub New(ByVal pDataSource As AppSimplicity.DataAccess.DataSource)
        _DataSource = pDataSource
    End Sub

    Private _Tables As List(Of MetaTable)
    Public ReadOnly Property Tables() As List(Of MetaTable)
        Get
            If _Tables Is Nothing Then

            End If
            Return _Tables
        End Get
    End Property

    ''' <summary>
    ''' Fetchs a project given the connection 
    ''' </summary>
    ''' <param name="pConnectionStringName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FetchDataSource(ByVal pConnectionStringName As String) As MetaDataSource
        Dim lDS As AppSimplicity.DataAccess.DataSource
        Dim lDataSource As MetaDataSource = Nothing
        lDS = AppSimplicity.DataAccess.DataSource.GetDataSourceFromConfigFile(pConnectionStringName)

        If Not (lDS Is Nothing) Then
            'lProject = New MetaProject(lDS)
        End If

        'Return lProject
    End Function

End Class
