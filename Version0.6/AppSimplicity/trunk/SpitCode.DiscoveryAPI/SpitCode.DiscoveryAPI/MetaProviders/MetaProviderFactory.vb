Namespace MetaProviders
    Public Class MetaProviderFactory

        Public Shared Function GetInstance(ByVal pDataSource As AppSimplicity.DataAccess.DataSource) As MetaProviders.DiscoveryProvider
            Select Case (pDataSource.ProviderType)
                Case AppSimplicity.DataAccess.DataSource.ProviderTypes.SQLServer

                Case AppSimplicity.DataAccess.DataSource.ProviderTypes.MySQL

                Case AppSimplicity.DataAccess.DataSource.ProviderTypes.SQLite

                Case AppSimplicity.DataAccess.DataSource.ProviderTypes.Oracle

                Case AppSimplicity.DataAccess.DataSource.ProviderTypes.Oracle10g
            End Select

            Return Nothing
        End Function



    End Class
End Namespace

