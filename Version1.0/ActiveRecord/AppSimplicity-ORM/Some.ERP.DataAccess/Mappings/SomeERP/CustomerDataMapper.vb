Imports SomeERP.SomeERP

Namespace Mappings
    Public Class CustomerDataMapper
        Inherits AppSimplicity.ActiveRecord.EntityDataMapper(Of SomeERP.SomeERP.Customer)

        Public Overrides Function LoadInstance(ByVal dbRow As AppSimplicity.DataAccess.ResultSetRow) As SomeERP.SomeERP.Customer
            Dim lItem As New Customer

            lItem.Id = dbRow.GetValue("Id")
            lItem.ModifiedBy = dbRow.GetValue("ModifiedBy")

            Return lItem
        End Function

        Public Sub New()
            MyBase.New("SomeERP")
        End Sub
    End Class
End Namespace

