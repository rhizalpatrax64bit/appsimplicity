Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports AppSimplicity.SchemaDiscovery

Namespace SqlServer
    Public Class SQLServerMetaDataProvider
        Inherits BaseProvider
        Implements IMetaDataProvider

        Private _ConnectionString As String

        Public Function GetTables() As System.Collections.Generic.List(Of Entities.Table) Implements IMetaDataProvider.GetTables
            Dim lReturnValue As New List(Of SchemaDiscovery.Entities.Table)

            Dim lDS As DataSet = SqlHelper.ExecuteDataset(_ConnectionString, commandType:=CommandType.Text, commandText:=My.Resources.SQLServerExtractionScripts.GET_TABLES)
            For Each lDR As DataRow In lDS.Tables(0).Rows
                Dim lTable As New SchemaDiscovery.Entities.Table

                lTable.Name = lDR.Item("TABLE_NAME").ToString()
                lTable.ClassName = lDR.Item("TABLE_NAME").ToString()
                lTable.Schema = lDR.Item("TABLE_SCHEMA").ToString()

                lReturnValue.Add(lTable)
            Next

            Return lReturnValue
        End Function

        Private Function GetAllColumns(ByVal pTable As Entities.AbstractDataObject) As List(Of Entities.Column)
            Dim lReturnValue As New List(Of SchemaDiscovery.Entities.Column)

            Dim lParameters As New List(Of SqlClient.SqlParameter)
            lParameters.Add(New SqlParameter("@TABLE_SCHEMA", pTable.Schema))
            lParameters.Add(New SqlParameter("@TABLE_NAME", pTable.Name))

            Dim lDS As DataSet = SqlHelper.ExecuteDataset(_ConnectionString, CommandType.Text, My.Resources.SQLServerExtractionScripts.GET_TABLE_COLUMNS, lParameters.ToArray())

            For Each lDR As DataRow In lDS.Tables(0).Rows
                Dim lColumn As New SchemaDiscovery.Entities.Column
                lColumn.ColumnName = lDR.Item("COLUMN_NAME").ToString()
                lColumn.IsNullable = IIf(lDR.Item("IS_NULLABLE").ToString() = "YES", True, False)
                lColumn.SQLType = lDR.Item("DATA_TYPE").ToString()
                lColumn.CharMaxLength = IIf(lDR.IsNull("CHARACTER_MAXIMUM_LENGTH"), 0, lDR.Item("CHARACTER_MAXIMUM_LENGTH"))
                lColumn.IsIdentity = IIf(lDR.Item("IS_IDENTITY") = "YES", True, False)

                Dim CLRMappingInfo As CLRMappingInfo = MyBase.GetTargetCLRType("SQL", "VB.NET", lDR.Item("DATA_TYPE").ToString())
                If Not (CLRMappingInfo Is Nothing) Then
                    lColumn.CLRTargetType = CLRMappingInfo.CLRTargetType
                    lColumn.IsCLRNullable = CLRMappingInfo.IsCLRNullable
                End If
                
                lReturnValue.Add(lColumn)
            Next

            Return lReturnValue
        End Function

        Public Function GetColumns(ByVal pTable As Entities.Table) As System.Collections.Generic.List(Of Entities.Column) Implements IMetaDataProvider.GetColumns
            Return Me.GetAllColumns(pTable)
        End Function

        Public Function GetColumns(ByVal pView As Entities.View) As System.Collections.Generic.List(Of Entities.Column) Implements IMetaDataProvider.GetColumns
            Return Me.GetAllColumns(pView)
        End Function

        Public Function GetStoredProcedureParameters(ByVal storedProcedure As Entities.StoredProcedure) As System.Collections.Generic.List(Of Entities.StoredProcedureParameter) Implements IMetaDataProvider.GetStoredProcedureParameters
            Dim lReturnValue As New List(Of SchemaDiscovery.Entities.StoredProcedureParameter)

            Dim lParameters As New List(Of SqlClient.SqlParameter)
            lParameters.Add(New SqlParameter("@SPECIFIC_SCHEMA", storedProcedure.Schema))
            lParameters.Add(New SqlParameter("@SPECIFIC_NAME", storedProcedure.Name))

            Dim lDS As DataSet = SqlHelper.ExecuteDataset(_ConnectionString, CommandType.Text, My.Resources.SQLServerExtractionScripts.GET_STOREDPROCEDURE_PARAMETERS, lParameters.ToArray())

            For Each lDR As DataRow In lDS.Tables(0).Rows
                Dim lParameter As New Entities.StoredProcedureParameter

                lParameter.ParameterName = lDR.Item("PARAMETER_NAME").ToString()
                lParameter.SQLType = lDR.Item("DATA_TYPE").ToString()
                lParameter.CharMaxLength = IIf(lDR.Item("CHARACTER_MAXIMUM_LENGTH") Is System.DBNull.Value, 0, lDR.Item("CHARACTER_MAXIMUM_LENGTH"))
                lParameter.ParameterDirection = ParameterDirection.Input

                Dim CLRMappingInfo As CLRMappingInfo = MyBase.GetTargetCLRType("SQL", "VB.NET", lDR.Item("DATA_TYPE").ToString())
                If Not (CLRMappingInfo Is Nothing) Then
                    lParameter.CLRTargetType = CLRMappingInfo.CLRTargetType
                    lParameter.IsCLRNullable = CLRMappingInfo.IsCLRNullable
                End If

                lReturnValue.Add(lParameter)
            Next

            Return lReturnValue
        End Function

        Public Function GetStoredProcedures() As System.Collections.Generic.List(Of Entities.StoredProcedure) Implements IMetaDataProvider.GetStoredProcedures
            Dim lReturnValue As New List(Of SchemaDiscovery.Entities.StoredProcedure)

            Dim lDS As DataSet = SqlHelper.ExecuteDataset(_ConnectionString, CommandType.Text, My.Resources.SQLServerExtractionScripts.GET_STORED_PROCEDURES)

            For Each lDR As DataRow In lDS.Tables(0).Rows
                Dim lProc As New SchemaDiscovery.Entities.StoredProcedure

                lProc.Schema = lDR.Item("SPECIFIC_SCHEMA").ToString()
                lProc.Name = lDR.Item("SPECIFIC_NAME").ToString()

                lReturnValue.Add(lProc)
            Next

            Return lReturnValue
        End Function

        Public Function GetViews() As System.Collections.Generic.List(Of Entities.View) Implements IMetaDataProvider.GetViews
            Dim lReturnValue As New List(Of SchemaDiscovery.Entities.View)

            Dim lDS As DataSet = SqlHelper.ExecuteDataset(_ConnectionString, CommandType.Text, My.Resources.SQLServerExtractionScripts.GET_VIEWS)

            For Each lDR As DataRow In lDS.Tables(0).Rows
                Dim lView As New SchemaDiscovery.Entities.View

                lView.Name = lDR.Item("TABLE_NAME").ToString()
                lView.ClassName = lDR.Item("TABLE_NAME").ToString()
                lView.Schema = lDR.Item("TABLE_SCHEMA").ToString()

                lReturnValue.Add(lView)
            Next

            Return lReturnValue
        End Function

        Public Function GetCLRTargetType(ByVal sqlType As String, ByVal type As TargetLanguages) As String Implements IMetaDataProvider.GetCLRTargetType
            Dim lDataTypesDS As DataSet = New DataSet()
            Dim xmlFile As String
            If type = TargetLanguages.CSharp Then
                xmlFile = "SQLCSharp.xml"
            Else
                xmlFile = "SQLVB.xml"
            End If
            lDataTypesDS.ReadXml(xmlFile)

            Dim lDR As DataRow() = lDataTypesDS.Tables(0).Select(String.Format("[SourceType] = '{0}'", sqlType))

            If (lDR.Length > 0) Then
                Return lDR(0).Item("NetCLRTargetType").ToString
            End If

            Return String.Empty
        End Function

        Public Sub ScriptData(ByVal table As Entities.Table, ByRef OutputStream As System.IO.Stream) Implements IMetaDataProvider.ScriptData
            Dim lScripter As New SQLServerDataScripter(_ConnectionString)
            Dim lStreamWriter As New System.IO.StreamWriter(OutputStream, System.Text.Encoding.Unicode)
            lScripter.ScriptData(table, lStreamWriter)
        End Sub

        Public Function GetKeys(ByVal table As Entities.Table) As System.Collections.Generic.List(Of Entities.TableKey) Implements IMetaDataProvider.GetKeys
            Dim lReturnValue As New List(Of Entities.TableKey)

            Dim lParameters As New List(Of SqlClient.SqlParameter)
            lParameters.Add(New SqlParameter("@SCHEMA_NAME", table.Schema))
            lParameters.Add(New SqlParameter("@TABLE_NAME", table.Name))

            Dim lDS As DataSet = SqlHelper.ExecuteDataset(_ConnectionString, CommandType.Text, My.Resources.SQLServerExtractionScripts.GET_TABLE_KEYS, lParameters.ToArray())

            If (lDS.Tables.Count > 1) Then
                If (lDS.Tables.Count > 1) Then
                    For Each lRow As System.Data.DataRow In lDS.Tables(0).Rows
                        Dim lKey As New Entities.TableKey

                        lKey.Name = lRow.Item("KEY_NAME")
                        lKey.KeyType = Entities.KeyTypes.Index
                        If (lRow.Item("KEY_TYPE").ToString() = "PRIMARY_KEY") Then
                            lKey.KeyType = Entities.KeyTypes.PrimaryKey
                        End If

                        For Each lColRow As DataRow In lDS.Tables(1).Rows
                            If (lColRow.Item("KEY_NAME") = lKey.Name) Then
                                Dim lCol As New Entities.KeyColumn
                                lCol.ColumnName = lColRow.Item("COLUMN_NAME")
                                lCol.SortDirection = Entities.SortDirection.Ascending
                                If lColRow.Item("SORT_DIRECTION").ToString() = "DESC" Then
                                    lCol.SortDirection = Entities.SortDirection.Descending
                                End If
                                lKey.Columns.Add(lCol)
                            End If
                        Next

                        lReturnValue.Add(lKey)
                    Next
                End If
            End If

            Return lReturnValue
        End Function

        Public Sub SetConnectionString(ByVal ConnectionString As String) Implements IMetaDataProvider.SetConnectionString
            _ConnectionString = ConnectionString
        End Sub
    End Class
End Namespace

