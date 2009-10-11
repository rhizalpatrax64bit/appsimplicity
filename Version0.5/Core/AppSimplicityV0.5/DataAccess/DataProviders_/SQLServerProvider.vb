Imports System.Data.SqlClient
Namespace DataAccess.Providers
    Public Class SQLServerProvider
        Inherits ProviderBase

        Public Overrides Function GetDBFactory() As System.Data.Common.DbProviderFactory
            Return SqlClient.SqlClientFactory.Instance
        End Function

        Public Sub New(ByVal pDataSource As DataSource)
            MyBase.New(pDataSource)
        End Sub
    End Class
End Namespace

