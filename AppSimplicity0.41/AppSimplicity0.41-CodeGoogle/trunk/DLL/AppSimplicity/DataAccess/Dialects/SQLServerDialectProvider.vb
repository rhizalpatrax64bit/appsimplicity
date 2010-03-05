Namespace DataAccess.Providers
    Public Class SQLServerDialectProvider
        Inherits SQL92DialectProvider

        Public Sub New(ByVal pUseSPsForCRUD As Boolean)
            MyBase.New(pUseSPsForCRUD)
        End Sub
    End Class
End Namespace

