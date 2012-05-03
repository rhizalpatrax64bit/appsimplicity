Imports AppSimplicity.DataAccess
Imports AppSimplicity.SchemaDiscovery
Imports NUnit.Framework

<TestFixture()> _
Public Class SQLServerSchemaDiscoveryTests

    Private Const ConnectionName As String = "SomeERP"

    <Test()> _
    Public Sub RunTableExtractions()
        Dim Provider As New AppSimplicity.SchemaDiscovery.Providers.SqlServer.SqlServerMetaDataProvider(ConnectionName)

        Console.WriteLine()
        Console.WriteLine("Extracting tables from [{0}]...", ConnectionName)
        Console.WriteLine()

        Dim Tables As List(Of Entities.Table) = Provider.GetTables()
        Assert.AreNotEqual(Tables.Count, 0)

        For Each Table As Entities.Table In Tables
            Console.WriteLine("Extracting columns for [{0}]...", Table.QualifiedName)
            Table.Columns = Provider.GetColumns(Table)
            Assert.AreNotEqual(Table.Columns.Count, 0)
        Next

        Console.WriteLine("Table extractions completed successfully.")
        Console.WriteLine()
    End Sub

    <Test()> _
    Public Sub RunViewExtractions()
        Dim Provider As New AppSimplicity.SchemaDiscovery.Providers.SqlServer.SqlServerMetaDataProvider(ConnectionName)

        Console.WriteLine()
        Console.WriteLine("Extracting views from [{0}]...", ConnectionName)
        Console.WriteLine()

        Dim Views As List(Of Entities.View) = Provider.GetViews()
        Assert.AreNotEqual(Views.Count, 0)

        For Each View As Entities.View In Views
            Console.WriteLine("Extracting columns for [{0}]...", View.QualifiedName)
            View.Columns = Provider.GetColumns(View)
            Assert.AreNotEqual(View.Columns.Count, 0)
        Next
        Console.WriteLine("View extractions completed successfully.")
    End Sub

    <Test()> _
    Public Sub RunStoredProcedureExtractions()
        Dim lProvider As New AppSimplicity.SchemaDiscovery.Providers.SqlServer.SqlServerMetaDataProvider(ConnectionName)

        Console.WriteLine()
        Console.WriteLine("Extracting stored procedures from [{0}]...", ConnectionName)
        Console.WriteLine()

        Dim lSPs As List(Of Entities.StoredProcedure) = lProvider.GetStoredProcedures()
        Assert.AreNotEqual(lSPs.Count, 0)

        For Each lSP As Entities.StoredProcedure In lSPs
            Console.WriteLine("Extracting parameters for [{0}]...", lSP.QualifiedName)
            lSP.Parameters = lProvider.GetStoredProcedureParameters(lSP)
            Assert.AreNotEqual(lSP.Parameters.Count, 0)
        Next
        Console.WriteLine("Stored procedure extractions completed successfully.")
    End Sub

End Class
