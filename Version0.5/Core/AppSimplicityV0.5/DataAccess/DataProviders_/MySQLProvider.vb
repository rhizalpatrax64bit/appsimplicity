Imports MySql.Data
Namespace DataAccess.Providers
    Public Class MySQLProvider
        Inherits ProviderBase

        Public Overrides Function GetDBFactory() As System.Data.Common.DbProviderFactory
            Return MySqlClient.MySqlClientFactory.Instance
        End Function

        Public Sub New(ByVal pDataSource As DataSource)
            MyBase.New(pDataSource, True)
        End Sub
    End Class
End Namespace
