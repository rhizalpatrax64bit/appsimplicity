Namespace DataManagers
    Public Class CustomerDataManager
        Implements SomeERP.SomeERP.ICustomerDataManager

        Public Function Delete(ByVal Customer As SomeERP.SomeERP.Customer) As Object Implements SomeERP.SomeERP.ICustomerDataManager.Delete

        End Function

        Public Function DeleteAll(ByVal Customers As System.Collections.Generic.List(Of SomeERP.SomeERP.Customer)) As Object Implements SomeERP.SomeERP.ICustomerDataManager.DeleteAll

        End Function

        Public Function DeleteByKey(ByVal key As Object) As Boolean Implements SomeERP.SomeERP.ICustomerDataManager.DeleteByKey

        End Function

        Public Function GetAll() As System.Collections.Generic.List(Of SomeERP.SomeERP.Customer) Implements SomeERP.SomeERP.ICustomerDataManager.GetAll

        End Function

        Public Function GetAllActive() As System.Collections.Generic.List(Of SomeERP.SomeERP.Customer) Implements SomeERP.SomeERP.ICustomerDataManager.GetAllActive

        End Function

        Public Function GetByKey(ByVal Key As Object) As SomeERP.SomeERP.Customer Implements SomeERP.SomeERP.ICustomerDataManager.GetByKey

        End Function

        Public Function Insert(ByVal Customer As SomeERP.SomeERP.Customer) As Object Implements SomeERP.SomeERP.ICustomerDataManager.Insert

        End Function

        Public Function InsertAll(ByVal Customers As System.Collections.Generic.List(Of SomeERP.SomeERP.Customer)) As Object Implements SomeERP.SomeERP.ICustomerDataManager.InsertAll

        End Function

        Public Function Update(ByVal Customer As SomeERP.SomeERP.Customer) As Object Implements SomeERP.SomeERP.ICustomerDataManager.Update

        End Function

        Public Function UpdateAll(ByVal Customers As System.Collections.Generic.List(Of SomeERP.SomeERP.Customer)) As Object Implements SomeERP.SomeERP.ICustomerDataManager.UpdateAll

        End Function
    End Class
End Namespace

