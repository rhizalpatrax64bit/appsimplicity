Imports AppSimplicity.DataAccess
Imports AppSimplicity.ActiveRecord

Namespace SomeERP
    Public Class CustomerDataMapper
        Inherits EntityDataMapper(Of Customer)

        Public Overrides Function LoadInstance(ByVal dbRow As AppSimplicity.DataAccess.ResultSetRow) As Customer
            Dim lItem As New Customer()

            lItem.Id = dbRow.GetValue("Id")
            lItem.Email = dbRow.GetValue("Email")

            Return lItem
        End Function

        Public Sub New()
            MyBase.New("SomeERP")
        End Sub
    End Class
End Namespace

