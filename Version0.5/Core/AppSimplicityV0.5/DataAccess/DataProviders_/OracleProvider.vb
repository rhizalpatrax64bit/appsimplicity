Imports System.Data.OracleClient

Namespace DataAccess.Providers
    Public Class OracleProvider
        Inherits ProviderBase

        Public Overrides Function GetDBFactory() As System.Data.Common.DbProviderFactory
            Return OracleClient.OracleClientFactory.Instance
        End Function

        Public Sub New(ByVal pDataSource As DataSource)
            MyBase.New(pDataSource)
        End Sub
    End Class

End Namespace
