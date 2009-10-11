Imports System.Text
Namespace DataAccess.Dialect
    Public MustInherit Class DialectBase

#Region "Column Formatters"
        Public Overridable Function GetBracketedColumnName(ByVal pColumn As ActiveRecord.SchemaColumn) As String
            Return String.Format("[{0}]", pColumn.ColumnName)
        End Function

        Public Overridable Function GetQualifiedColumnName(ByVal pColumn As ActiveRecord.SchemaColumn) As String
            Return String.Format("{0}.{1}", pColumn.Schema.TableName, pColumn.ColumnName)
        End Function

        Public Overridable Function GetParameterName(ByVal pColumn As ActiveRecord.SchemaColumn) As String
            Return String.Format("@{0}", pColumn.ColumnName)
        End Function

        Public Overridable Function GetColumnJoinFieldName(ByVal pColumn As ActiveRecord.SchemaColumn) As String
            Return String.Format("{0}.{1}", pColumn.Schema.TableName, pColumn.ColumnName)
        End Function

        Public Overridable Function GetColumnJoinAlias(ByVal pColumn As ActiveRecord.SchemaColumn) As String
            Return String.Format("[{0}.{1}]", pColumn.Schema.TableName, pColumn.ColumnName)
        End Function

        Public Overridable Function GetQualifiedTableName(ByVal pSchema As ActiveRecord.Schema) As String
            Return String.Format("[{0}]", pSchema.TableName)
        End Function

        Public Overridable Function GetValidParameterName(ByVal pParameterName As String) As String
            Return String.Format("@{0}", pParameterName)
        End Function

        Public Overridable Function GetLastInsertedIdStatement() As String
            Return "SELECT @@IDENTITY"
        End Function

#Region "CRUD SPs"
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
        
#End Region

        Private _DataService As DataAccess.DataService

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

        ''' <summary>
        ''' Obtiene la lista de columnas en una cadena
        ''' </summary>
        ''' <param name="pSchema">El esquema que contiene la lista de columnas</param>
        ''' <param name="pIncludeIdentity">Determina si se debe incluir el campo identidad</param>
        ''' <param name="pFormat">Determina él formato de la lista de parametros</param>
        ''' <returns>Devuelve la lista de columnas en una cadena</returns>
        ''' 
        Public Overridable Function GetCommaSeparatedColumns(ByVal pSchema As ActiveRecord.Schema, ByVal pIncludeIdentity As Boolean, ByVal pFormat As ColumnFormat) As String
            Dim SB As New StringBuilder

            Dim lColumn As ActiveRecord.SchemaColumn
            Dim lFirst As Boolean = True
            Dim lHasToAppend As Boolean
            Dim lStringToAppend As String = ""
            Dim lFormattedColumn As String

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
                    lFormattedColumn = String.Empty
                    Select Case (pFormat)
                        Case ColumnFormat.ColumnName
                            lFormattedColumn = Me.GetBracketedColumnName(lColumn)
                        Case ColumnFormat.ParameterName
                            lFormattedColumn = Me.GetParameterName(lColumn)
                        Case ColumnFormat.ValueToParameterAssignment
                            lFormattedColumn = String.Format("{0} = {1}", Me.GetQualifiedColumnName(lColumn), Me.GetParameterName(lColumn))
                        Case ColumnFormat.JoinAlias
                            lFormattedColumn = String.Format("{0} AS {1}", Me.GetQualifiedColumnName(lColumn), Me.GetColumnJoinAlias(lColumn))
                    End Select

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
#End Region

#Region "Construcción de Sentencias CRUD"
        Public Overridable Function GetInsertStatement(ByVal pSchema As ActiveRecord.Schema) As String
            Dim lResult As String = String.Empty

            If Not (pSchema.DataService.UseSPsForCRUD) Then

                If (pSchema.IdIsAutogenerated) Then
                    lResult = String.Format("INSERT INTO {0} ({1}) VALUES ({2}); {3};", _
                                        pSchema.TableName, _
                                        GetCommaSeparatedColumns(pSchema, False, ColumnFormat.ColumnName), _
                                        GetCommaSeparatedColumns(pSchema, False, ColumnFormat.ParameterName), _
                                        GetLastInsertedIdStatement())
                Else
                    lResult = String.Format("INSERT INTO {0} ({1}) VALUES ({2}); {3};", _
                                        pSchema.TableName, _
                                        GetCommaSeparatedColumns(pSchema, True, ColumnFormat.ColumnName), _
                                        GetCommaSeparatedColumns(pSchema, True, ColumnFormat.ParameterName), _
                                        GetLastInsertedIdStatement())
                End If
            Else
                lResult = Get_INSERT_Procedure(pSchema)
            End If

            Return lResult
        End Function

        Public Overridable Function GetDeletetStatement(ByVal pSchema As ActiveRecord.Schema) As String
            Dim lResult As String = String.Empty

            If Not (pSchema.DataService.UseSPsForCRUD) Then
                lResult = String.Format("DELETE FROM {0} WHERE {1} = {2};", _
                            Me.GetQualifiedTableName(pSchema), _
                            Me.GetQualifiedColumnName(pSchema.PrimaryKey), _
                            Me.GetParameterName(pSchema.PrimaryKey))
            Else
                lResult = Get_DELETE_Procedure(pSchema)
            End If

            Return lResult
        End Function

        Public Overridable Function GetSelectByIdStatement(ByVal pSchema As ActiveRecord.Schema) As String
            Dim lResult As String = String.Empty

            If Not (pSchema.DataService.UseSPsForCRUD) Then
                lResult = String.Format("SELECT {0} FROM {1} WHERE {2} = {3};", _
                            GetCommaSeparatedColumns(pSchema, True, ColumnFormat.JoinAlias), _
                            Me.GetQualifiedTableName(pSchema), _
                            Me.GetQualifiedColumnName(pSchema.PrimaryKey), _
                            Me.GetParameterName(pSchema.PrimaryKey))
            Else
                lResult = Get_SELECT_Procedure(pSchema)
            End If

            Return lResult
        End Function

        Public Overridable Function GetUpdateStatement(ByVal pSchema As ActiveRecord.Schema) As String
            Dim lResult As String = String.Empty

            If Not (pSchema.DataService.UseSPsForCRUD) Then
                lResult = String.Format("UPDATE {0} SET {1} WHERE {2} = {3};", _
                            Me.GetQualifiedTableName(pSchema), _
                            GetCommaSeparatedColumns(pSchema, False, ColumnFormat.ValueToParameterAssignment), _
                            Me.GetQualifiedColumnName(pSchema.PrimaryKey), _
                            Me.GetParameterName(pSchema.PrimaryKey))
            Else
                lResult = Get_UPDATE_Procedure(pSchema)
            End If

            Return lResult
        End Function
#End Region

#Region "QueryBuilder Strings"

#Region "Sentencia SELECT "
        Public Overridable Function BuildSELECTStatement(ByVal pQuery As ActiveRecord.QueryBuilder) As String
            Dim lResult As String = String.Empty

            lResult = String.Format("SELECT {0} {1} FROM {2} {3} {4} {5}", _
                                    TopStatement(pQuery), _
                                    GetColumnList(pQuery), _
                                    Me.GetQualifiedTableName(pQuery.Schema), _
                                    GetJoins(pQuery), _
                                    Get_WHERE_Statement(pQuery), _
                                    GetOrderByStatement(pQuery))

            Return lResult
        End Function

#Region "TOP/LIMIT"
        Public Overridable Function TopStatement(ByVal pQueryBuilder As ActiveRecord.QueryBuilder) As String
            If (pQueryBuilder.Limit <> 0) Then
                Return String.Format("TOP {0}", pQueryBuilder.Limit)
            End If
            Return String.Empty
        End Function
#End Region

#Region "GetColumnList"
        Public Overridable Function GetColumnList(ByVal pQuery As ActiveRecord.QueryBuilder) As String
            Dim lReturnValue As String = String.Empty

            Select Case (pQuery.QueryType)
                Case ActiveRecord.QueryBuilder.RelationFormat.None
                    lReturnValue = GetCommaSeparatedColumns(pQuery.Schema, True, ColumnFormat.JoinAlias)
                Case ActiveRecord.QueryBuilder.RelationFormat.JustDescriptions
                    Dim lSB As New StringBuilder
                    lSB.Append(GetCommaSeparatedColumns(pQuery.Schema, True, ColumnFormat.JoinAlias))

                    For Each lDependency As ActiveRecord.ForeignDependency In pQuery.Schema.Dependencies
                        lSB.AppendFormat(", {0} AS {1}", _
                            Me.GetQualifiedColumnName(lDependency.BelongsToSchema.PrimaryKey), _
                            Me.GetColumnJoinAlias(lDependency.BelongsToSchema.PrimaryKey))

                        For Each lDescriptionKey As String In lDependency.BelongsToSchema.DescriptionColumns
                            lSB.AppendFormat(", {0} AS {1}", _
                            Me.GetQualifiedColumnName(lDependency.BelongsToSchema(lDescriptionKey)), _
                            Me.GetColumnJoinAlias(lDependency.BelongsToSchema(lDescriptionKey)))
                        Next
                    Next

                    lReturnValue = lSB.ToString()
                Case ActiveRecord.QueryBuilder.RelationFormat.All
                    Dim lSB As New StringBuilder
                    lSB.Append(GetCommaSeparatedColumns(pQuery.Schema, True, ColumnFormat.JoinAlias))

                    For Each lDependency As ActiveRecord.ForeignDependency In pQuery.Schema.Dependencies
                        lSB.Append(String.Format(", {0}", GetCommaSeparatedColumns(lDependency.BelongsToSchema, True, ColumnFormat.JoinAlias)))
                    Next

                    lReturnValue = lSB.ToString()
            End Select

            Return lReturnValue
        End Function
#End Region

#Region "GetJoins"
        Public Overridable Function GetJoins(ByVal pQuery As ActiveRecord.QueryBuilder) As String
            Dim lReturnValue As String = String.Empty

            If (pQuery.Schema.Dependencies.Count > 0) Then
                Dim lSB As New StringBuilder

                For Each lDependency As ActiveRecord.ForeignDependency In pQuery.Schema.Dependencies
                    lSB.AppendFormat(" LEFT JOIN {0} ON {1} = {2} ", _
                    Me.GetQualifiedTableName(lDependency.BelongsToSchema), _
                    Me.GetQualifiedColumnName(lDependency.BelongsToSchema.PrimaryKey), _
                    Me.GetQualifiedColumnName(lDependency.BelongsToColumn))
                Next

                lReturnValue = lSB.ToString
            End If

            Return lReturnValue
        End Function
#End Region

#Region "Get_WHERE_Statement"
        Public Overridable Function Get_WHERE_Statement(ByVal pQuery As ActiveRecord.QueryBuilder) As String
            Dim lReturnValue As String = String.Empty

            If (pQuery.Comparisons.Count > 0) Then
                Dim lSB As New StringBuilder

                Dim First As Boolean = True
                For Each lComparison As ActiveRecord.QueryBuilder.Comparison In pQuery.Comparisons
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

        Public Function GetComparisonString(ByVal pComparison As ActiveRecord.QueryBuilder.Comparison, ByVal pIncludeOperator As Boolean) As String
            Dim lResult As String = String.Empty
            If (pIncludeOperator) Then
                lResult = String.Format(" {0} ({1}) ", GetLogicalOperatorString(pComparison), GetComparisonStatement(pComparison))
            Else
                lResult = String.Format(" ({0}) ", GetComparisonStatement(pComparison))
            End If
            Return lResult
        End Function

        Public Function GetLogicalOperatorString(ByVal pComparison As ActiveRecord.QueryBuilder.Comparison) As String
            Dim lResult As String = String.Empty
            Select Case (pComparison.LogicalOperator)
                Case ActiveRecord.QueryBuilder.LogicalOperatorType._AND_, ActiveRecord.QueryBuilder.LogicalOperatorType._UNDEFINED_
                    lResult = "AND"
                Case ActiveRecord.QueryBuilder.LogicalOperatorType._AND_NOT_
                    lResult = "AND NOT"
                Case ActiveRecord.QueryBuilder.LogicalOperatorType._OR_
                    lResult = "OR"
                Case ActiveRecord.QueryBuilder.LogicalOperatorType._OR_NOT_
                    lResult = "OR NOT"
            End Select
            Return lResult
        End Function

        Public Overridable Function GetComparisonStatement(ByVal pComparison As ActiveRecord.QueryBuilder.Comparison) As String
            Dim lResult As String = String.Empty

            Select Case (pComparison.ComparisonType)
                Case ActiveRecord.QueryBuilder.ComparisonOperation.ValueEqualsTo
                    lResult = String.Format(" {0} = {1} ", _
                                            Me.GetQualifiedColumnName(pComparison.Column), _
                                            Me.GetValidParameterName(pComparison.Parameters(0).Name))

                Case ActiveRecord.QueryBuilder.ComparisonOperation.ValueIsBetween, ActiveRecord.QueryBuilder.ComparisonOperation.DateIsBetween
                    lResult = String.Format(" {0} BETWEEN {1} AND {2} ", _
                                            Me.GetQualifiedColumnName(pComparison.Column), _
                                            Me.GetValidParameterName(pComparison.Parameters(0).Name), _
                                            Me.GetValidParameterName(pComparison.Parameters(1).Name))

                Case ActiveRecord.QueryBuilder.ComparisonOperation.TextIsLike
                    lResult = String.Format(" {0} LIKE {1} ", _
                                            Me.GetQualifiedColumnName(pComparison.Column), _
                                            Me.GetValidParameterName(pComparison.Parameters(0).Name))

                Case ActiveRecord.QueryBuilder.ComparisonOperation.ValueIsGreaterThan
                    lResult = String.Format(" {0} > {1} ", _
                                            Me.GetQualifiedColumnName(pComparison.Column), _
                                            Me.GetValidParameterName(pComparison.Parameters(0).Name))

                Case ActiveRecord.QueryBuilder.ComparisonOperation.ValueIsGreaterThanOrEqualsTo
                    lResult = String.Format(" {0} >= {1} ", _
                                            Me.GetQualifiedColumnName(pComparison.Column), _
                                            Me.GetValidParameterName(pComparison.Parameters(0).Name))

                Case ActiveRecord.QueryBuilder.ComparisonOperation.ValueIsLessThan
                    lResult = String.Format(" {0} < {1} ", _
                                            Me.GetQualifiedColumnName(pComparison.Column), _
                                            Me.GetValidParameterName(pComparison.Parameters(0).Name))

                Case ActiveRecord.QueryBuilder.ComparisonOperation.ValueIsLessThanOrEqualsTo
                    lResult = String.Format(" {0} <= {1} ", _
                                            Me.GetQualifiedColumnName(pComparison.Column), _
                                            Me.GetValidParameterName(pComparison.Parameters(0).Name))
                Case ActiveRecord.QueryBuilder.ComparisonOperation.ValueIsDifferentFrom
                    lResult = String.Format(" {0} <> {1} ", _
                                            Me.GetQualifiedColumnName(pComparison.Column), _
                                            Me.GetValidParameterName(pComparison.Parameters(0).Name))

            End Select

            Return lResult
        End Function
#End Region

#Region "ORDER BY"
        Public Overridable Function GetOrderByStatement(ByVal pQuery As ActiveRecord.QueryBuilder) As String
            Dim lReturnValue As String = String.Empty

            If (pQuery.OrderByList.Count > 0) Then
                Dim lSB As New StringBuilder

                Dim First As Boolean = True
                For Each lOrder As ActiveRecord.QueryBuilder.Order In pQuery.OrderByList

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

        Public Overridable Function GetOrderByDirection(ByVal pOrder As ActiveRecord.QueryBuilder.Order) As String
            Dim lResult As String = "ASC"

            Select Case pOrder.DirectionOrder
                Case ActiveRecord.QueryBuilder.OrderByStatements.ASC
                    lResult = "ASC"
                Case ActiveRecord.QueryBuilder.OrderByStatements.DESC
                    lResult = "DESC"
            End Select

            Return lResult
        End Function
#End Region

#End Region

#End Region

        Public Sub New()

        End Sub
    End Class
End Namespace
