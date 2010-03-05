Namespace DataAccess.Providers
    ''' <summary>
    ''' It encapsulates the behavior of a data provider for SQLClient namespace
    ''' </summary>
    ''' <remarks></remarks>
    Public Class SQLServerProvider
        Inherits ADONetProvider

        Public Sub New(ByVal pDataSource As DataAccess.DataSource)
            MyBase.New(pDataSource)
        End Sub

        Public Overrides Function GetFactory() As System.Data.Common.DbProviderFactory
            Return System.Data.SqlClient.SqlClientFactory.Instance
        End Function
    End Class
End Namespace
