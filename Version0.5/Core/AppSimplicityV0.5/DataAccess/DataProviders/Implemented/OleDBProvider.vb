﻿Namespace DataAccess.Providers
    Public Class OleDBProvider
        Inherits Provider

        Public Sub New(ByVal pDataSource As DataSource)
            MyBase.New(pDataSource)
        End Sub

        Public Overrides Function GetFactory() As System.Data.Common.DbProviderFactory
            Return System.Data.OleDb.OleDbFactory.Instance
        End Function
    End Class
End Namespace