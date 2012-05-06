Imports AppSimplicity.ActiveRecord
Imports AppSimplicity.DataAccess

Namespace SomeERP
    Partial Public Class CustomerDataManager
        Inherits EntityDataManager(Of Customer)

        Public Function GetByKey(ByVal Id As Integer) As Customer
            Dim lCommand As DataCommand = CreateCommand("cgp_CUSTOMERS_GET_BY_KEY", System.Data.CommandType.StoredProcedure)

            lCommand.AddParameter("@Id", System.Data.DbType.Int32, Id)

            Dim lMapper As New CustomerDataMapper()
            Return lMapper.FetchFirst(lCommand)
        End Function

        Public Function CreateCustomer(ByRef Item As Customer) As Boolean
            Dim lReturnValue As Boolean = False
            Dim lCommand As DataCommand = CreateCommand("cgp_CUSTOMERS_INSERT", System.Data.CommandType.StoredProcedure)

            lCommand.AddParameter("@Id", System.Data.DbType.Int32, Item.Id)

            Dim lService As New DataService(ConnectionSource.GetConnection(""))
            For Each lRow As AppSimplicity.DataAccess.ResultSetRow In lService.RunCommand(lCommand).ExecuteResultSet()
                Item.Id = lRow.GetValue("NEW_INSERTED_ID")
                Item.IsLoadedFromDB = True
            Next

            Return lReturnValue
        End Function

        Public Function DeleteCustomer(ByVal Item As Customer)

        End Function


    End Class
End Namespace

