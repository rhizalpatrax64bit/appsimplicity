Public Class SomeERPDataContext_

End Class

Public Interface ICustomerDataManager

    Function GetByKey(ByVal Key As Object) As SomeERP.Customer

    Function Delete(ByVal Customer As SomeERP.Customer)
    Function DeleteByKey(ByVal key As Object) As Boolean
    Function DeleteAll(ByVal Customers As List(Of SomeERP.Customer))

    Function Insert(ByVal Customer As SomeERP.Customer)
    Function InsertAll(ByVal Customers As List(Of SomeERP.Customer))

    Function Update(ByVal Customer As SomeERP.Customer)
    Function UpdateAll(ByVal Customers As LinkedList(Of SomeERP.Customer))

    Function GetAll() As List(Of SomeERP.Customer)
    Function GetAllActive() As List(Of SomeERP.Customer)

End Interface