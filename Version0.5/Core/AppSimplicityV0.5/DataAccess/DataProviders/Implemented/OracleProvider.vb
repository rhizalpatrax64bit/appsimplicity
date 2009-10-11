Namespace DataAccess.Providers
    Public Class OracleProvider
        Inherits Provider

        Public Sub New(ByVal pDataSource As DataSource)
            MyBase.New(pDataSource)
        End Sub

        Public Overrides Function GetFactory() As System.Data.Common.DbProviderFactory
            Return System.Data.OracleClient.OracleClientFactory.Instance
        End Function
    End Class
End Namespace

