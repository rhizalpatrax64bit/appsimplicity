Namespace DataAccess
    Public Class DataProvider
        Private _DataSource As DataAccess.DataSource

        Public Sub New(ByVal pDataSource As DataSource)
            Me._DataSource = pDataSource
        End Sub
    End Class

End Namespace
