Imports System.Data
Namespace DataAccess.Providers
    Public Class MSAccessProvider
        Inherits ProviderBase

        Public Overrides Function GetDBFactory() As System.Data.Common.DbProviderFactory
            Return System.Data.OleDb.OleDbFactory.Instance
        End Function

        Public Sub New(ByVal pDataSource As DataSource)
            MyBase.New(pDataSource)
        End Sub
    End Class
End Namespace

