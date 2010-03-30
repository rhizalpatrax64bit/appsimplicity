Imports System.IO
Imports System.Text

Namespace Utilities.Excel
    Public Class ExcelExporter

#Region "Shared"
        ''' <summary>
        ''' Shared method to render a System.Data.DataTable to a Excel file in openxml format
        ''' </summary>
        ''' <param name="pTable">The table to render to file</param>
        ''' <param name="pFileAbsolutePath ">The complete file path to generate</param>
        ''' <param name="pCompressToZip">If this parameter is true it will compress file to zip.</param>
        ''' <param name="pSelectList">
        ''' Only columns in this list will be rendered to the excel file,<br/> 
        ''' if this parameter is nothing all columns in the table will be rendered.
        ''' 
        ''' Column renaming is allowed if a column name is specified 
        ''' in the following format:
        ''' 
        ''' "ColumnName|HumanReadableColumnName"
        ''' 
        ''' (The pipe character is required)
        ''' </param>
        ''' <remarks>If a column name is specified in the column name list it must exists in the datatable, 
        ''' otherwise an exception will be thrown.
        ''' </remarks>
        Public Shared Sub RenderTableToExcelFile(ByVal pTable As System.Data.DataTable, ByVal pFileAbsolutePath As String, Optional ByVal pSelectList As String() = Nothing, Optional ByVal pRenderHeader As Boolean = True, Optional ByVal pCompressToZip As Boolean = False, Optional ByVal pDeleteAfterZip As Boolean = True)
            Dim lExcelUtilities As New ExcelExporter
            lExcelUtilities.RenderDataTableToExcelFile(pTable, pFileAbsolutePath, pSelectList, pRenderHeader, pCompressToZip, pDeleteAfterZip)
        End Sub
#End Region

#Region "Public"
        ''' <summary>
        ''' Renders a System.Data.DataTable to a Excel file in OpenXml format
        ''' </summary>
        ''' <param name="pTable">The table to render to file</param>
        ''' <param name="pFileAbsolutePath ">The complete file path to generate</param>
        ''' <param name="pCompressToZip">If this parameter is true it will compress file to zip.</param>
        ''' <param name="pSelectList">
        ''' Only columns in this list will be rendered to the excel file,<br/> 
        ''' if this parameter is nothing all columns in the table will be rendered.
        ''' 
        ''' Column renaming is allowed if a column name is specified 
        ''' in the following format:
        ''' 
        ''' "ColumnName|HumanReadableColumnName"
        ''' 
        ''' (The pipe character is required)
        ''' </param>
        ''' <remarks>If a column name is specified in the column name list it must exists in the datatable, 
        ''' otherwise an exception will be thrown.
        ''' </remarks>
        Public Sub RenderDataTableToExcelFile(ByVal pTable As System.Data.DataTable, ByVal pFileAbsolutePath As String, Optional ByVal pSelectList As String() = Nothing, Optional ByVal pRenderHeader As Boolean = True, Optional ByVal pCompressToZip As Boolean = False, Optional ByVal pDeleteAfterZip As Boolean = True)
            Dim sWriter As StreamWriter
            Dim lSelectList As New List(Of ColumnMeta)

            If Not (pSelectList Is Nothing) Then
                For Each lColumnName As String In pSelectList
                    Dim lMeta As New ColumnMeta(lColumnName)

                    If (pTable.Columns.Contains(lMeta.ColumnName)) Then
                        lMeta.DataType = pTable.Columns(lMeta.ColumnName).DataType
                        lSelectList.Add(lMeta)
                    Else
                        Throw New Exception(String.Format("La columna [{0}] no se encuentra definida dentro del esquema de la tabla", lMeta.ColumnName))
                    End If
                Next
            Else
                For Each lColumn As System.Data.DataColumn In pTable.Columns
                    Dim lMeta As New ColumnMeta(lColumn.ColumnName)
                    lMeta.DataType = lColumn.DataType
                    lSelectList.Add(lMeta)
                Next
            End If

            sWriter = New StreamWriter(pFileAbsolutePath, False, System.Text.Encoding.UTF8)


            'Writing to file:
            '____________________________________________________________________________
            'XML Header:

            Dim lHeader As String = My.Resources.ExcelDataRenderer.ExcelXMLFileHeader

            Dim lAuthor As String = "Undefined"
            If Not (System.Web.HttpContext.Current Is Nothing) Then
                lAuthor = System.Web.HttpContext.Current.User.Identity.Name
            End If

            lHeader = lHeader.Replace("[$Author]", lAuthor)
            lHeader = lHeader.Replace("[$CreatedOn]", Convert.ToString(Date.Now))

            sWriter.WriteLine(lHeader)
            sWriter.WriteLine(String.Format("<Worksheet ss:Name=""{0}"">", pTable.TableName))
            sWriter.WriteLine(String.Format("  <Table ss:ExpandedColumnCount=""{0}"" ss:ExpandedRowCount=""{1}"" x:FullColumns=""1"" x:FullRows=""1"">", lSelectList.Count, pTable.Rows.Count + 1))


            If (pRenderHeader) Then
                '____________________________________________________________________________
                'Row Header:
                For Each lColumn As ColumnMeta In lSelectList
                    sWriter.WriteLine(String.Format("    <Column>{0}</Column>", lColumn.HumanReadableColumnName))
                Next

                'Open tag:
                sWriter.WriteLine()
                sWriter.WriteLine("<Row>")

                For Each lColumn As ColumnMeta In lSelectList
                    sWriter.WriteLine(String.Format("  <Cell ss:StyleID=""s1""><Data ss:Type=""String"">{0}</Data></Cell>", lColumn.HumanReadableColumnName))
                Next

                'Close tag:
                sWriter.WriteLine("</Row>")
                sWriter.WriteLine()
            End If

            '____________________________________________________________________________
            'Rows :

            For Each lRow As System.Data.DataRow In pTable.Rows
                sWriter.Write(Me.GetXMLRowString(lRow, lSelectList))
            Next

            'Closing tags:
            sWriter.WriteLine("</Table>")
            sWriter.WriteLine("</Worksheet>")
            sWriter.WriteLine("</Workbook>")

            sWriter.Close()
            sWriter.Dispose()

            If (pCompressToZip) Then
                Utilities.Compression.ZipFile(pFileAbsolutePath)
            End If
        End Sub
#End Region

#Region "Private"
        Private Function GetXMLRowString(ByVal pDR As DataRow, ByVal pSelectList As List(Of ColumnMeta)) As String
            Dim lReturnValue As New StringBuilder
            Dim lDataValue As Object
            Dim lValueType As System.Type
            Dim lXMLStringValue As String

            lReturnValue.AppendLine("<Row>")

            For Each lMeta As ColumnMeta In pSelectList
                lDataValue = pDR.Item(lMeta.ColumnName)
                lXMLStringValue = String.Empty

                If Not (lDataValue Is System.DBNull.Value) Then
                    lValueType = lDataValue.GetType

                    Select Case (lValueType.Name)
                        Case "DateTime", "Date"
                            Dim lDateValue As DateTime = lDataValue

                            Dim lInitDate As New DateTime(lDateValue.Year, lDateValue.Month, lDateValue.Day)
                            Dim lSpan As TimeSpan = lDateValue.Subtract(lInitDate)
                            Dim lHasTime As Boolean = False

                            If (lSpan.Minutes <> 0) Then
                                lHasTime = True
                            End If

                            If (lHasTime) Then
                                lXMLStringValue = String.Format("{0:00}/{1:00}/{2:0000} {3:00}:{4:00}", lDateValue.Day, lDataValue.Month, lDateValue.Year, lDateValue.Hour, lDateValue.Minute)
                            Else
                                lXMLStringValue = String.Format("{0:00}/{1:00}/{2:0000}", lDateValue.Day, lDataValue.Month, lDateValue.Year)
                            End If
                        Case "String"
                            lXMLStringValue = lDataValue
                        Case "Boolean"
                            lXMLStringValue = IIf(lDataValue, "1", "0")
                        Case Else
                            Try
                                lXMLStringValue = Trim(Convert.ToString(lDataValue))
                            Catch ex As Exception
                                lXMLStringValue = ex.Message
                            End Try
                    End Select
                End If

                lReturnValue.AppendFormat("  <Cell ss:StyleID=""s2""><Data ss:Type=""String"">{0}</Data></Cell>" & vbCrLf, lXMLStringValue)
            Next

            lReturnValue.AppendLine("</Row>")
            lReturnValue.AppendLine()

            Return lReturnValue.ToString
        End Function
#End Region

#Region "Column Meta"
        Private Class ColumnMeta
            Private _ColumnName As String
            Public ReadOnly Property ColumnName() As String
                Get
                    Return _ColumnName
                End Get
            End Property

            Public ReadOnly Property HumanReadableColumnName() As String
                Get
                    Return _HumanReadableColumnName
                End Get
            End Property

            Private _HumanReadableColumnName As String

            Private _DataType As System.Type
            Public Property DataType() As System.Type
                Get
                    Return _DataType
                End Get
                Set(ByVal value As System.Type)
                    _DataType = value
                End Set
            End Property

            Public Sub New(ByVal pColumnName As String)
                If (pColumnName.Contains("|")) Then
                    Dim lSplitted As String() = pColumnName.Split("|")

                    _ColumnName = lSplitted(0)
                    _HumanReadableColumnName = lSplitted(1)
                Else
                    _ColumnName = pColumnName
                    _HumanReadableColumnName = pColumnName
                End If
            End Sub
        End Class
#End Region

    End Class
End Namespace


