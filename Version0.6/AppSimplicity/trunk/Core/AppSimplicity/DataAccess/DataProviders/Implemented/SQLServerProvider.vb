Namespace DataAccess.Providers
    Public Class SQLServerProvider
        Inherits Provider

        Public Overrides Function GetFactory() As System.Data.Common.DbProviderFactory
            Return System.Data.SqlClient.SqlClientFactory.Instance
        End Function

        Public Sub New(ByVal pDataSource As DataSource)
            MyBase.New(pDataSource)
        End Sub
    End Class
End Namespace
