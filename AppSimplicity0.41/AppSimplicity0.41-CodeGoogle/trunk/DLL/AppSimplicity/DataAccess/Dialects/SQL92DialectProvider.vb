Imports System.Text

Namespace DataAccess.Providers
    Public MustInherit Class SQL92DialectProvider
        Implements IDialectProvider

        Private _UseSPsForCRUD As Boolean

        Private ReadOnly Property UseSPsForCRUD() As Boolean
            Get
                Return _UseSPsForCRUD
            End Get
        End Property

        Public Sub New(ByVal pUseSPsForCRUD As Boolean)
            _UseSPsForCRUD = pUseSPsForCRUD
        End Sub

#Region "Interface Methods"

        Public Function Get_SELECTBYID_Statement(ByVal pSchema As ActiveRecord.Schema) As String Implements IDialectProvider.Get_SELECTBYID_Statement
            Return GetSelectByIdStatement(pSchema, Me.UseSPsForCRUD)
        End Function

        Public Function Get_INSERT_Statement(ByVal pSchema As ActiveRecord.Schema) As String Implements IDialectProvider.Get_INSERT_Statement
            Return GetInsertStatement(pSchema, Me.UseSPsForCRUD)
        End Function

        Public Function Get_DELETE_Statement(ByVal pSchema As ActiveRecord.Schema) As String Implements IDialectProvider.Get_DELETE_Statement
            Return GetDeletetStatement(pSchema, Me.UseSPsForCRUD)
        End Function

        Public Function Get_UPDATE_Statement(ByVal pSchema As ActiveRecord.Schema) As String Implements IDialectProvider.Get_UPDATE_Statement
            Return GetUpdateStatement(pSchema, Me.UseSPsForCRUD)
        End Function

        Public Function Get_ParameterName(ByVal pColumn As ActiveRecord.SchemaColumn) As String Implements IDialectProvider.Get_ParameterName
            Return String.Format("@{0}", pColumn.ColumnName)
        End Function

        Public Function Get_ParameterName(ByVal pParameterName As String) As String Implements IDialectProvider.Get_ParameterName
            Return String.Format("@{0}", pParameterName)
        End Function

        Public Function Get_QueryBuilderStatement(ByVal pQuery As ActiveRecord.Query.QueryBuilder) As String Implements IDialectProvider.Get_QueryBuilderStatement
            Return BuildSELECTStatement(pQuery)
        End Function

#End Region

#Region "Column Formatters"
        Public Overridable Function GetBracketedColumnName(ByVal pColumn As ActiveRecord.SchemaColumn) As String
            Return String.Format("[{0}]", pColumn.ColumnName)
        End Function

        Public Overridable Function GetQualifiedColumnName(ByVal pColumn As ActiveRecord.SchemaColumn) As String
            Return String.Format("[{0}].[{1}]", pColumn.Schema.TableName, pColumn.ColumnName)
        End Function

        'Public Overridable Function GetColumnJoinFieldName(ByVal pColumn As ActiveRecord.SchemaColumn) As String
        '    Return String.Format("[{0}].[{1}]", pColumn.Schema.TableName, pColumn.ColumnName)
        'End Function

        Public Overridable Function GetColumnJoinAlias(ByVal pColumn As ActiveRecord.SchemaColumn) As String
            Return String.Format("[{0}.{1}]", pColumn.Schema.TableName, pColumn.ColumnName)
        End Function

        Public Overridable Function GetQualifiedTableName(ByVal pSchema As ActiveRecord.Schema) As String
            Return String.Format("[{0}]", pSchema.TableName)
        End Function

        Public Overridable Function GetLastInsertedIdStatement() As String
            Return "SELECT @@IDENTITY"
        End Function

        Public Overridable Function Get_INSERT_Procedure(ByVal pSchema As ActiveRecord.Schema) As String
            Return String.Format("{0}_SP_INSERT", pSchema.TableName.ToUpper)
        End Function

        Public Overridable Function Get_UPDATE_Procedure(ByVal pSchema As ActiveRecord.Schema) As String
            Return String.Format("{0}_SP_UPDATE", pSchema.TableName.ToUpper)
        End Function

        Public Overridable Function Get_DELETE_Procedure(ByVal pSchema As ActiveRecord.Schema) As String
            Return String.Format("{0}_SP_DELETE", pSchema.TableName.ToUpper)
        End Function

        Public Overridable Function Get_SELECT_Procedure(ByVal pSchema As ActiveRecord.Schema) As String
            Return String.Format("{0}_SP_SELECT", pSchema.TableName.ToUpper)
        End Function
#End Region

#Region "Misc Statements"

        Public Enum ColumnFormat
            ColumnName
            ParameterName
            ValueToParameterAssignment
            JoinAlias
        End Enum

        Public Enum JoinFormats
            JustDescriptions
            All
        End Enum

        Public Overridable Function GetCommaSeparatedColumns(ByVal pList As List(Of ActiveRecord.SchemaColumn), ByVal pFormat As ColumnFormat) As String
            Dim SB As New StringBuilder
            Dim lFirst As Boolean = True

            For Each lColumn As ActiveRecord.SchemaColumn In pList
                If (lFirst) Then
                    SB.Append(GetFormattedColumn(lColumn, pFormat))
                    lFirst = False
                Else
                    SB.AppendFormat(", {0}", GetFormattedColumn(lColumn, pFormat))
                End If
            Next

            Return SB.ToString
        End Function

        ''' <summary>
        ''' Obtiene la lista de columnas en una cadena
        ''' </summary>
        ''' <param name="pSchema">El esquema que contiene la lista de columnas</param>
        ''' <param name="pIncludeIdentity">Determina si se debe incluir el campo identidad</param>
        ''' <param name="pFormat">Determina él formato de la lista de parametros</param>
        ''' <returns>Devuelve la lista de columnas en una cadena</returns>
        Public Overridable Function GetCommaSeparatedColumns(ByVal pSchema As ActiveRecord.Schema, ByVal pIncludeIdentity As Boolean, ByVal pFormat As ColumnFormat) As String
            Dim SB As New StringBuilder

            Dim lColumn As ActiveRecord.SchemaColumn
            Dim lFirst As Boolean = True
            Dim lHasToAppend As Boolean
            Dim lStringToAppend As String = ""
            Dim lFormattedColumn As String = ""

            For Each lkey As String In pSchema.AllColumns
                lColumn = pSchema(lkey)

                lHasToAppend = False

                If (lColumn.IsPrimaryKey) Then
                    If (pIncludeIdentity) Then
                        lHasToAppend = True
                    End If
                Else
                    lHasToAppend = True
                End If

                If (lHasToAppend) Then
                    'Obtener la cadena formateada:
                    lFormattedColumn = GetFormattedColumn(lColumn, pFormat)

                    'Agregar valores separados por coma
                    If (lFirst) Then
                        lStringToAppend = lFormattedColumn
                        lFirst = False
                    Else
                        lStringToAppend = String.Format(", {0}", lFormattedColumn)
                    End If

                    SB.Append(lStringToAppend)
                End If
            Next

            Return SB.ToString
        End Function


        Public Overridable Function GetFormattedColumn(ByVal pColumn As ActiveRecord.SchemaColumn, ByVal pFormat As ColumnFormat) As String
            Dim lFormattedColumn As String = String.Empty

            lFormattedColumn = String.Empty
            Select Case (pFormat)
                Case ColumnFormat.ColumnName
                    lFormattedColumn = Me.GetBracketedColumnName(pColumn)
                Case ColumnFormat.ParameterName
                    lFormattedColumn = Me.Get_ParameterName(pColumn)
                Case ColumnFormat.ValueToParameterAssignment
                    lFormattedColumn = String.Format("{0} = {1}", Me.GetQualifiedColumnName(pColumn), Me.Get_ParameterName(pColumn))
                Case ColumnFormat.JoinAlias
                    lFormattedColumn = String.Format("{0} AS {1}", Me.GetQualifiedColumnName(pColumn), Me.GetColumnJoinAlias(pColumn))
            End Select

            Return lFormattedColumn
        End Function

        
#End Region

#Region "Construcción de Sentencias CRUD"
        Public Overridable Function GetInsertStatement(ByVal pSchema As ActiveRecord.Schema, Optional ByVal pUseStoredProceduresForCRUD As Boolean = False) As String
            Dim lResult As String = String.Empty

            If Not (pUseStoredProceduresForCRUD) Then

                If (pSchema.IdIsAutoGenerated) Then
                    lResult = String.Format("INSERT INTO {0} ({1}) VALUES ({2}) {3}", _
                                        Me.GetQualifiedTableName(pSchema), _
                                        GetCommaSeparatedColumns(pSchema, False, ColumnFormat.ColumnName), _
                                        GetCommaSeparatedColumns(pSchema, False, ColumnFormat.ParameterName), _
                                        GetLastInsertedIdStatement())
                Else
                    lResult = String.Format("INSERT INTO {0} ({1}) VALUES ({2}) ", _
                                        Me.GetQualifiedTableName(pSchema), _
                                        GetCommaSeparatedColumns(pSchema, True, ColumnFormat.ColumnName), _
                                        GetCommaSeparatedColumns(pSchema, True, ColumnFormat.ParameterName))
                End If
            Else
                lResult = Get_INSERT_Procedure(pSchema)
            End If

            Return lResult
        End Function

        Public Overridable Function GetDeletetStatement(ByVal pSchema As ActiveRecord.Schema, Optional ByVal pUseStoredProceduresForCRUD As Boolean = False) As String
            Dim lResult As String = String.Empty

            If Not (pUseStoredProceduresForCRUD) Then
                lResult = String.Format("DELETE FROM {0} WHERE {1} = {2} ", _
                            Me.GetQualifiedTableName(pSchema), _
                            Me.GetQualifiedColumnName(pSchema.PKColumn), _
                            Me.Get_ParameterName(pSchema.PKColumn))
            Else
                lResult = Get_DELETE_Procedure(pSchema)
            End If

            Return lResult
        End Function

        Public Overridable Function GetSelectByIdStatement(ByVal pSchema As ActiveRecord.Schema, Optional ByVal pUseStoredProceduresForCRUD As Boolean = False) As String
            Dim lResult As String = String.Empty

            If Not (pUseStoredProceduresForCRUD) Then
                lResult = String.Format("SELECT {0} FROM {1} WHERE {2} = {3}", _
                            GetCommaSeparatedColumns(pSchema, True, ColumnFormat.JoinAlias), _
                            Me.GetQualifiedTableName(pSchema), _
                            Me.GetQualifiedColumnName(pSchema.PKColumn), _
                            Me.Get_ParameterName(pSchema.PKColumn))
            Else
                lResult = Get_SELECT_Procedure(pSchema)
            End If

            Return lResult
        End Function

        Public Overridable Function GetUpdateStatement(ByVal pSchema As ActiveRecord.Schema, Optional ByVal pUseStoredProceduresForCRUD As Boolean = False) As String
            Dim lResult As String = String.Empty

            If Not (pUseStoredProceduresForCRUD) Then
                lResult = String.Format("UPDATE {0} SET {1} WHERE {2} = {3}", _
                            Me.GetQualifiedTableName(pSchema), _
                            GetCommaSeparatedColumns(pSchema, False, ColumnFormat.ValueToParameterAssignment), _
                            Me.GetQualifiedColumnName(pSchema.PKColumn), _
                            Me.Get_ParameterName(pSchema.PKColumn))
            Else
                lResult = Get_UPDATE_Procedure(pSchema)
            End If

            Return lResult
        End Function
#End Region

#Region "QueryBuilder Strings"

#Region "Sentencia SELECT "

#End Region
        Public Overridable Function BuildSELECTStatement(ByVal pQuery As ActiveRecord.Query.QueryBuilder) As String
            Dim lResult As String = String.Empty

            lResult = String.Format(" SELECT {0} {1} FROM {2} {3} {4} {5} ", _
                                      TopStatement(pQuery), _
                                      GetColumnList(pQuery), _
                                      Me.GetQualifiedTableName(pQuery.Schema), _
                                      Me.GetJoinList(pQuery), _
                                      Get_WHERE_Statement(pQuery), _
                                      GetOrderByStatement(pQuery))


            'TODO: agregar el orderby recursivo

            Return lResult
        End Function

#Region "ORDER BY"
        Public Overridable Function GetOrderByStatement(ByVal pQuery As ActiveRecord.Query.QueryBuilder) As String
            Dim lReturnValue As String = String.Empty

            If (pQuery.OrderByList.Count > 0) Then
                Dim lSB As New StringBuilder

                Dim First As Boolean = True
                For Each lOrder As ActiveRecord.Query.OrderBy In pQuery.OrderByList

                    If (First) Then
                        lSB.AppendFormat("{0} {1}", Me.GetQualifiedColumnName(lOrder.Column), GetOrderByDirection(lOrder))
                        First = False
                    Else
                        lSB.AppendFormat(",{0} {1}", Me.GetQualifiedColumnName(lOrder.Column), GetOrderByDirection(lOrder))
                    End If
                Next

                lReturnValue = String.Format("ORDER BY {0}", lSB.ToString)
            End If

            Return lReturnValue
        End Function

        Public Overridable Function GetOrderByDirection(ByVal pOrder As ActiveRecord.Query.OrderBy) As String
            Dim lResult As String = "ASC"

            Select Case pOrder.DirectionOrder
                Case ActiveRecord.Query.OrderBy.OrderByDirections.ASC
                    lResult = "ASC"
                Case ActiveRecord.Query.OrderBy.OrderByDirections.DESC
                    lResult = "DESC"
            End Select

            Return lResult
        End Function
#End Region

#Region "TOP/LIMIT"
        Public Overridable Function TopStatement(ByVal pQueryBuilder As ActiveRecord.Query.QueryBuilder) As String
            If (pQueryBuilder.Limit <> 0) Then
                Return String.Format("TOP {0}", pQueryBuilder.Limit)
            End If
            Return String.Empty
        End Function
#End Region

        Private Sub GetRecursiveJoinList(ByVal pQuery As ActiveRecord.Query.QueryBuilder, ByRef pJoinTables As List(Of String))
            For Each lKey As String In pQuery.Joins.Keys

                pJoinTables.Add(String.Format("LEFT JOIN {0} ON {1} = {2}", _
                        Me.GetQualifiedTableName(pQuery.Joins(lKey).ForeignQuery.Schema), _
                                Me.GetQualifiedColumnName(pQuery.Joins(lKey).JoinColumn), _
                                Me.GetQualifiedColumnName(pQuery.Joins(lKey).ForeignQuery.Schema.PKColumn)))

                GetRecursiveJoinList(pQuery.Joins(lKey).ForeignQuery, pJoinTables)

            Next
        End Sub

        Private Function GetJoinList(ByVal pQuery As ActiveRecord.Query.QueryBuilder) As String
            Dim lReturnValue As String = String.Empty
            Dim lFirst As Boolean = True
            Dim lSB As New StringBuilder

            If (pQuery.Joins.Count > 0) Then
                Dim lJoinList As New List(Of String)

                GetRecursiveJoinList(pQuery, lJoinList)

                For Each lJoin As String In lJoinList
                    lSB.AppendFormat(" {0} ", lJoin)
                Next

                lReturnValue = lSB.ToString
            End If

            Return lReturnValue
        End Function

        Private Sub RecursiveSelectList(ByVal pQuery As ActiveRecord.Query.QueryBuilder, ByRef pSelectList As List(Of ActiveRecord.SchemaColumn))
            For Each lColumn As ActiveRecord.SchemaColumn In pQuery.ColumnsList
                pSelectList.Add(lColumn)
            Next

            For Each lkey As String In pQuery.Joins.Keys
                Dim lQuery As ActiveRecord.Query.QueryBuilder = pQuery.Joins(lkey).ForeignQuery

                RecursiveSelectList(lQuery, pSelectList)
            Next
        End Sub

#Region "GetColumnList"
        Public Overridable Function GetColumnList(ByVal pQuery As ActiveRecord.Query.QueryBuilder) As String
            Dim lReturnValue As String = String.Empty

            Dim lList As New List(Of ActiveRecord.SchemaColumn)

            RecursiveSelectList(pQuery, lList)

            If (lList.Count > 0) Then
                lReturnValue = Me.GetCommaSeparatedColumns(lList, ColumnFormat.JoinAlias)
            Else
                lReturnValue = Me.GetCommaSeparatedColumns(pQuery.Schema, True, ColumnFormat.JoinAlias)
            End If

            Return lReturnValue
        End Function
#End Region

#Region "Get_WHERE_Statement"

        Private Sub RecursiveWhereStatement(ByVal pQuery As ActiveRecord.Query.QueryBuilder, ByRef pComparisons As List(Of ActiveRecord.Query.Comparison))
            For Each lComparison As ActiveRecord.Query.Comparison In pQuery.Comparisons
                pComparisons.Add(lComparison)
            Next

            For Each lJoin As String In pQuery.Joins.Keys
                RecursiveWhereStatement(pQuery.Joins(lJoin).ForeignQuery, pComparisons)
            Next
        End Sub

        Public Overridable Function Get_WHERE_Statement(ByVal pQuery As ActiveRecord.Query.QueryBuilder) As String
            Dim lReturnValue As String = String.Empty

            Dim lTotalComparisons As New List(Of ActiveRecord.Query.Comparison)

            RecursiveWhereStatement(pQuery, lTotalComparisons)

            If (lTotalComparisons.Count > 0) Then
                Dim lSB As New StringBuilder

                Dim First As Boolean = True

                For Each lComparison As ActiveRecord.Query.Comparison In lTotalComparisons

                    If (First) Then
                        lSB.AppendFormat(" WHERE {0} ", GetComparisonString(lComparison, False))
                        First = False
                    Else
                        lSB.Append(GetComparisonString(lComparison, True))
                    End If

                Next

                lReturnValue = lSB.ToString
            End If

            Return lReturnValue
        End Function

        ''' <summary>
        ''' Obtiene la cadena de comparación en SQL
        ''' </summary>
        ''' <param name="pIncludeOperator">Determina si debe incluir el operador lógico o no</param>          
        Public Function GetComparisonString(ByVal pComparison As ActiveRecord.Query.Comparison, ByVal pIncludeOperator As Boolean) As String
            Dim lResult As String = String.Empty
            If (pIncludeOperator) Then
                lResult = String.Format(" {0} ({1}) ", GetLogicalOperatorString(pComparison), GetComparisonStatement(pComparison))
            Else
                lResult = String.Format(" ({0}) ", GetComparisonStatement(pComparison))
            End If
            Return lResult
        End Function

        Public Function GetLogicalOperatorString(ByVal pComparison As ActiveRecord.Query.Comparison) As String
            Dim lResult As String = String.Empty
            Select Case (pComparison.LogicalOperator)
                Case ActiveRecord.Query.Comparison.LogicalOperatorType._AND_, ActiveRecord.Query.Comparison.LogicalOperatorType._UNDEFINED_
                    lResult = "AND"
                Case ActiveRecord.Query.Comparison.LogicalOperatorType._AND_NOT_
                    lResult = "AND NOT"
                Case ActiveRecord.Query.Comparison.LogicalOperatorType._OR_
                    lResult = "OR"
                Case ActiveRecord.Query.Comparison.LogicalOperatorType._OR_NOT_
                    lResult = "OR NOT"
            End Select
            Return lResult
        End Function


        Public Overridable Function GetComparisonStatement(ByVal pComparison As ActiveRecord.Query.Comparison) As String
            Dim lResult As String = String.Empty

            Select Case (pComparison.ComparisonType)
                Case ActiveRecord.Query.Comparison.ComparisonOperation.ValueEqualsTo
                    lResult = String.Format(" {0} = {1} ", _
                                            Me.GetQualifiedColumnName(pComparison.Column), _
                                            pComparison.Parameters(0).Name)

                Case ActiveRecord.Query.Comparison.ComparisonOperation.ValueIsBetween, ActiveRecord.Query.Comparison.ComparisonOperation.DateIsBetween
                    lResult = String.Format(" {0} BETWEEN {1} AND {2} ", _
                                            Me.GetQualifiedColumnName(pComparison.Column), _
                                            pComparison.Parameters(0).Name, _
                                            pComparison.Parameters(1).Name)

                Case ActiveRecord.Query.Comparison.ComparisonOperation.TextIsLike
                    lResult = String.Format(" {0} LIKE {1} ", _
                                            Me.GetQualifiedColumnName(pComparison.Column), _
                                            pComparison.Parameters(0).Name)

                Case ActiveRecord.Query.Comparison.ComparisonOperation.ValueIsGreaterThan
                    lResult = String.Format(" {0} > {1} ", _
                                            Me.GetQualifiedColumnName(pComparison.Column), _
                                            pComparison.Parameters(0).Name)

                Case ActiveRecord.Query.Comparison.ComparisonOperation.ValueIsGreaterThanOrEqualsTo
                    lResult = String.Format(" {0} >= {1} ", _
                                            Me.GetQualifiedColumnName(pComparison.Column), _
                                            pComparison.Parameters(0).Name)

                Case ActiveRecord.Query.Comparison.ComparisonOperation.ValueIsLessThan
                    lResult = String.Format(" {0} < {1} ", _
                                            Me.GetQualifiedColumnName(pComparison.Column), _
                                            pComparison.Parameters(0).Name)

                Case ActiveRecord.Query.Comparison.ComparisonOperation.ValueIsLessThanOrEqualsTo
                    lResult = String.Format(" {0} <= {1} ", _
                                            Me.GetQualifiedColumnName(pComparison.Column), _
                                            pComparison.Parameters(0).Name)
                Case ActiveRecord.Query.Comparison.ComparisonOperation.ValueIsDifferentFrom
                    lResult = String.Format(" {0} <> {1} ", _
                                            Me.GetQualifiedColumnName(pComparison.Column), _
                                            pComparison.Parameters(0).Name)

            End Select

            Return lResult
        End Function
#End Region


#End Region

    End Class
End Namespace
