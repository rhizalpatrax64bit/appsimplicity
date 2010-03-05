Namespace DataAccess.Providers
    Public Class SQLiteV3Provider
        Inherits ADONetProvider

        Public Sub New(ByVal pDataSource As DataAccess.DataSource)
            MyBase.New(pDataSource)
        End Sub

        Public Overrides Function GetFactory() As System.Data.Common.DbProviderFactory
            Return System.Data.SqlClient.SqlClientFactory.Instance
        End Function
    End Class
End Namespace

