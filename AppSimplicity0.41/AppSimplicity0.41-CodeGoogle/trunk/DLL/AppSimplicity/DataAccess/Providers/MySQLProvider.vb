Namespace DataAccess.Providers
    Public Class MySQLProvider
        Inherits ADONetProvider

        Public Sub New(ByVal pDataSource As DataSource)
            MyBase.New(pDataSource)
        End Sub

        Public Overrides Function GetFactory() As System.Data.Common.DbProviderFactory
            Return MySql.Data.MySqlClient.MySqlClientFactory.Instance
        End Function
    End Class
End Namespace

