﻿Imports AppSimplicity
Imports AppSimplicity.SchemaDiscovery

Public Class SQLServerDataScripter

    Private _Provider As DataAccess.DataService
    Private _InsertBlockSize As Integer = 100

    Public Sub New(ByVal pDataService As DataAccess.DataService)
        _Provider = pDataService
    End Sub

    Private Function GetSelectStatement(ByVal pTable As Entities.Table) As String
        Dim lReturnValue As String = String.Empty
        Dim lStatement = "SELECT {0} FROM {1}"

        Dim lColumnList As New List(Of String)
        For Each lColumn As Entities.Column In pTable.Columns
            lColumnList.Add(String.Format("[{0}]", lColumn.ColumnName))
        Next

        lReturnValue = String.Format(lStatement, String.Join(", ", lColumnList.ToArray()), String.Format("[{0}].[{1}]", pTable.Schema, pTable.Name))
        Return lReturnValue
    End Function

    Private Function GetSQLCastDateTimeValue(ByVal pValue As Object) As String
        'Format is:'20100315 16:40:31'
        Dim lFormat As String = "'{0:0000}{1:00}{2:00} {3:00}:{4:00}:{5:00}'"

        Dim lData As DateTime = CType(pValue, DateTime)
        Dim lReturnValue As String = String.Format(lFormat, _
            lData.Year, _
            lData.Month, _
            lData.Day, _
            lData.Hour, _
            lData.Minute, _
            lData.Millisecond)

        Return lReturnValue
    End Function

    Private Function GetRowValue(ByVal pValue As Object, ByVal pColumn As Entities.Column) As String
        Dim lReturnValue As String = String.Empty

        If (pValue Is System.DBNull.Value) Then
            lReturnValue = "NULL"
        Else
            Select Case (pValue.GetType().Name.ToLower)
                Case "string"
                    Dim lOutput As String = pValue
                    'Fix single quote:
                    If (lOutput.Contains("'")) Then
                        lOutput = lOutput.Replace("'", "[SINGLE_QUOTE$]").Replace("[SINGLE_QUOTE$]", "''")
                    End If

                    lReturnValue = String.Format("N'{0}'", lOutput)
                Case "int32", "int64", "decimal"
                    lReturnValue = System.Convert.ToString(pValue)
                Case "boolean"
                    lReturnValue = IIf(CType(pValue, Boolean), "1", "0")
                Case "date", "datetime"
                    Select Case (pColumn.SQLType)
                        Case "datetime"
                            lReturnValue = String.Format("CAST ({0} AS DateTime)", Me.GetSQLCastDateTimeValue(pValue))
                        Case "smalldatetime"
                            lReturnValue = String.Format("CAST ({0} AS SmallDateTime)", Me.GetSQLCastDateTimeValue(pValue))
                    End Select
                Case Else
                    Throw New Exception(String.Format("Unable to script value type [{0}]", pValue.GetType().Name))
            End Select
        End If

        Return lReturnValue
    End Function

    Private Function Get_INSERT_Statement(ByVal pRow As System.Data.DataRow, ByVal pTable As Entities.Table) As String
        Dim lStatement As String = "INSERT {0} ({1}) VALUES ({2})"

        Dim lColumnList As New List(Of String)

        For Each lColumn As Entities.Column In pTable.Columns
            lColumnList.Add(String.Format("[{0}]", lColumn.ColumnName))
        Next

        Dim lValueList As New List(Of String)
        For Each lColumn As Entities.Column In pTable.Columns
            lValueList.Add(GetRowValue(pRow.Item(lColumn.ColumnName), lColumn))
        Next

        Return String.Format(lStatement, _
            String.Format("[{0}].[{1}]", pTable.Schema, pTable.Name), _
            String.Join(", ", lColumnList.ToArray()), _
            String.Join(", ", lValueList.ToArray()))
    End Function

    Public Sub ScriptData(ByVal pTable As Entities.Table, ByRef pOutputScript As System.IO.StreamWriter)
        Console.WriteLine("Fetching data for [{0}].[{1}]", pTable.Schema, pTable.Name)

        pOutputScript.WriteLine("PRINT 'Now inserting data for [{0}].[{1}]...'", pTable.Schema, pTable.Name)
        pOutputScript.WriteLine("PRINT 'Cleaning up table data.'")
        pOutputScript.WriteLine("DELETE FROM [{0}].[{1}]", pTable.Schema, pTable.Name)
        pOutputScript.WriteLine("GO", pTable.Schema, pTable.Name)

        Dim lDS As DataSet = _Provider.CreateCommand(Me.GetSelectStatement(pTable)).ExecuteDataset()
        Console.WriteLine("Found {0} records.", lDS.Tables(0).Rows.Count)

        Dim lRowCount As Integer = 0
        Dim lOverallCount As Integer = 0
        Dim lTotalCount As Integer = lDS.Tables(0).Rows.Count()

        'If (pTable.HasIdentity) Then
        '    pOutputScript.WriteLine("SET IDENTITY_INSERT [{0}].[{1}] ON", pTable.Schema, pTable.Name)
        'End If

        For Each lDR As DataRow In lDS.Tables(0).Rows
            pOutputScript.WriteLine(Me.Get_INSERT_Statement(lDR, pTable))

            lRowCount = lRowCount + 1
            lOverallCount = lOverallCount + 1
            If (lRowCount > _InsertBlockSize) Then
                pOutputScript.WriteLine("GO")

                pOutputScript.WriteLine("PRINT 'Processed {0} total records of {1} ({2:0.00}%).'", lOverallCount, lTotalCount, (lOverallCount * 100) / lTotalCount)
                lRowCount = 0
            End If
        Next

        'If (pTable.HasIdentity) Then
        '    pOutputScript.WriteLine("SET IDENTITY_INSERT [{0}].[{1}] OFF", pTable.Schema, pTable.Name)
        'End If

        pOutputScript.WriteLine("GO")
        pOutputScript.WriteLine("PRINT 'Data for insertion for [{0}].[{1}] completed successfully.'", pTable.Schema, pTable.Name)
        pOutputScript.WriteLine("PRINT 'Total {0} records were inserted.'", lDS.Tables(0).Rows.Count)
        pOutputScript.WriteLine("PRINT ' '")

        Console.WriteLine("Scripting for [{0}].[{1}] completed sucessfully.", pTable.Schema, pTable.Name)
        Console.WriteLine()

        pOutputScript.Flush()
    End Sub

End Class
