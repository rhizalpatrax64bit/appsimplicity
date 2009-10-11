Imports System.Data.SQLite
Namespace DataAccess.Providers
    Public Class SQLiteProvider
        Inherits ProviderBase

        Public Overrides Function GetDBFactory() As System.Data.Common.DbProviderFactory
            Return SQLite.SQLiteFactory.Instance
        End Function

        Public Sub New(ByVal pDataSource As DataSource)
            MyBase.New(pDataSource)
        End Sub
    End Class
End Namespace

