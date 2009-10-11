Namespace DataAccess.Providers
    Public Class SQLiteProvider
        Inherits Provider

        Public Sub New(ByVal pDataSource As DataSource)
            MyBase.New(pDataSource)
        End Sub

        Public Overrides Function GetFactory() As System.Data.Common.DbProviderFactory
            Return SQLite.SQLiteFactory.Instance
        End Function
    End Class
End Namespace

