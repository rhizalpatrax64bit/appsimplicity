Public Class CustomerDataManager
    Implements ICustomerDataManager

    Public Function Delete(ByVal Customer As SomeERP.Customer) As Object Implements ICustomerDataManager.Delete

    End Function

    Public Function DeleteAll(ByVal Customers As System.Collections.Generic.List(Of SomeERP.Customer)) As Object Implements ICustomerDataManager.DeleteAll

    End Function

    Public Function DeleteByKey(ByVal key As Object) As Boolean Implements ICustomerDataManager.DeleteByKey

    End Function

    Public Function GetAll() As System.Collections.Generic.List(Of SomeERP.Customer) Implements ICustomerDataManager.GetAll

    End Function

    Public Function GetAllActive() As System.Collections.Generic.List(Of SomeERP.Customer) Implements ICustomerDataManager.GetAllActive

    End Function

    Public Function GetByKey(ByVal Key As Object) As SomeERP.Customer Implements ICustomerDataManager.GetByKey

    End Function

    Public Function Insert(ByVal Customer As SomeERP.Customer) As Object Implements ICustomerDataManager.Insert

    End Function

    Public Function InsertAll(ByVal Customers As System.Collections.Generic.List(Of SomeERP.Customer)) As Object Implements ICustomerDataManager.InsertAll

    End Function

    Public Function Update(ByVal Customer As SomeERP.Customer) As Object Implements ICustomerDataManager.Update

    End Function

    Public Function UpdateAll(ByVal Customers As System.Collections.Generic.LinkedList(Of SomeERP.Customer)) As Object Implements ICustomerDataManager.UpdateAll

    End Function
End Class
