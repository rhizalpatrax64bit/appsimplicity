Imports System.Data.Common

Namespace ActiveRecord
    Public Class QueryBuilder

#Region "Enums"
        Public Enum OrderByStatements
            ASC
            DESC
        End Enum

        Public Enum ComparisonOperation
            ValueEqualsTo
            ValueIsBetween
            DateIsBetween
            TextIsLike
            ValueIsGreaterThan
            ValueIsGreaterThanOrEqualsTo
            ValueIsLessThan
            ValueIsLessThanOrEqualsTo
            ValueIsDifferentFrom
        End Enum

        Public Enum LogicalOperatorType
            _AND_
            _AND_NOT_
            _OR_
            _OR_NOT_
            _UNDEFINED_
        End Enum

        Public Enum RelationFormat
            ''' <summary>
            ''' Brings only all columns from mapped table, no external relations are included in the select list
            ''' </summary>
            None
            ''' <summary>
            ''' Brings all columns from mapped table and all columns from external relations too
            ''' </summary>
            All
            ''' <summary>
            ''' Brings all columns from mapped table, and columns marked as description in external relations
            ''' </summary>
            JustDescriptions
        End Enum
#End Region

#Region "Propiedades"
        Private _ParamCount As Integer = 0

        Private _QueryType As RelationFormat = RelationFormat.None
        Public Property QueryType() As RelationFormat
            Get
                Return _QueryType
            End Get
            Set(ByVal value As RelationFormat)
                _QueryType = value
            End Set
        End Property

        Private _OrderByList As New List(Of Order)
        ''' <summary>
        ''' Contiene la lista de ordenamiento
        ''' </summary>
        Public ReadOnly Property OrderByList() As List(Of Order)
            Get
                If (_OrderByList Is Nothing) Then
                    _OrderByList = New List(Of Order)
                End If
                Return _OrderByList
            End Get
        End Property

        Private _TopValue As Integer = 0

        Private _Comparisons As List(Of Comparison)
        ''' <summary>
        ''' Obtiene la lista de las comparaciones de el constructor de querys
        ''' </summary>        
        Public ReadOnly Property Comparisons() As List(Of Comparison)
            Get
                If (_Comparisons Is Nothing) Then
                    _Comparisons = New List(Of Comparison)
                End If
                Return _Comparisons
            End Get
        End Property

        ''' <summary>
        ''' Si la consulta está limitada devuelve el límite de registros
        ''' </summary>
        Public ReadOnly Property Limit() As Integer
            Get
                Return Me._TopValue
            End Get
        End Property

        Private _Schema As Schema
        ''' <summary>
        ''' Contiene el esquema de la tabla mapeada de la base de datos
        ''' </summary>        
        Public ReadOnly Property Schema() As Schema
            Get
                Return _Schema
            End Get
        End Property

        Private _Joins As List(Of QueryBuilder)
        Public ReadOnly Property Joins() As List(Of QueryBuilder)
            Get
                If (_Joins Is Nothing) Then
                    _Joins = New List(Of QueryBuilder)
                End If
                Return _Joins
            End Get
        End Property

        ''' <summary>
        ''' Lleva el contador de parámetros
        ''' </summary>
        Public ReadOnly Property ParamCount() As Integer
            Get
                _ParamCount = _ParamCount + 1
                Return _ParamCount
            End Get
        End Property

        Public Sub AddJoin(ByVal pBuilder As QueryBuilder)
            Me.Joins.Add(pBuilder)
        End Sub

        Protected _PendingOperator As LogicalOperatorType = LogicalOperatorType._UNDEFINED_
        Protected ReadOnly Property PendingOperator() As LogicalOperatorType
            Get
                Dim lValue As LogicalOperatorType = Me._PendingOperator

                If (lValue = LogicalOperatorType._UNDEFINED_) Then
                    lValue = LogicalOperatorType._AND_
                End If

                Me._PendingOperator = LogicalOperatorType._UNDEFINED_
                Return lValue
            End Get
        End Property

        Private Function GetParameter(ByVal pValue As Object) As DataAccess.DataParameter
            Return New DataAccess.DataParameter(String.Format("Param{0}", Me.ParamCount), pValue)
        End Function
#End Region

#Region "Metodos Públicos"
        ''' <summary>
        ''' Reinicia la lista de comparaciones
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Reset()
            Me.Comparisons.Clear()
            Me.Joins.Clear()
            Me._ParamCount = 0
        End Sub

        Public Function Perform() As DataAccess.DataCommand
            Dim lCommand As New DataAccess.DataCommand(Me.Schema.DataService.Provider)
            'TODO: Llenar esto
            Return lCommand
        End Function

#Region "Logic Operators"
        Public Function And_() As QueryBuilder
            Me._PendingOperator = LogicalOperatorType._AND_
            Return Me
        End Function

        Public Function And_Not_() As QueryBuilder
            Me._PendingOperator = LogicalOperatorType._AND_NOT_
            Return Me
        End Function

        Public Function Or_() As QueryBuilder
            Me._PendingOperator = LogicalOperatorType._OR_
            Return Me
        End Function

        Public Function Or_Not_() As QueryBuilder
            Me._PendingOperator = LogicalOperatorType._OR_NOT_
            Return Me
        End Function
#End Region

#Region "WhereValueEqualsTo"
        ''' <summary>
        ''' Agrega una comparación a la sentencia sql para consulta
        ''' </summary>
        ''' <param name="pColumnName">El nombre de la columna que se busca comparar</param>
        ''' <param name="pValue"></param>
        ''' <returns>Devuelve un objeto QueryBuilder para continuar agregando sentencias</returns>
        Protected Function WhereValueEqualsTo(ByVal pColumnName As String, ByVal pValue As Object) As QueryBuilder
            Me.Schema.ValidateColumnName(pColumnName)

            Dim lComparison As New Comparison(Me, PendingOperator, Schema(pColumnName), ComparisonOperation.ValueEqualsTo)
            lComparison.Parameters.Add(Me.GetParameter(pValue))

            Me.Comparisons.Add(lComparison)

            Return Me
        End Function
#End Region

#Region "WhereValueIsBetween"
        Protected Function WhereValueIsBetween(ByVal pColumnName As String, ByVal pMinValue As Object, ByVal pMaxValue As Object) As QueryBuilder
            Me.Schema.ValidateColumnName(pColumnName)

            Dim lComparison As New Comparison(Me, PendingOperator, Schema(pColumnName), ComparisonOperation.ValueIsBetween)
            lComparison.Parameters.Add(Me.GetParameter(pMinValue))
            lComparison.Parameters.Add(Me.GetParameter(pMaxValue))

            Me.Comparisons.Add(lComparison)
            Return Me
        End Function
#End Region

#Region "WhereDateIsBetween"
        Protected Function WhereDateIsBetween(ByVal pColumnName As String, ByVal pMinValue As DateTime, ByVal pMaxValue As DateTime) As QueryBuilder
            Me.Schema.ValidateColumnName(pColumnName)

            If Not (Me.Schema.Item(pColumnName).IsDate) Then
                Throw New Exception(String.Format("La columna ""{0}"" no es un campo de fecha", pColumnName))
            End If

            Dim lComparison As New Comparison(Me, PendingOperator, Schema(pColumnName), ComparisonOperation.DateIsBetween)
            lComparison.Parameters.Add(Me.GetParameter(pMinValue))
            lComparison.Parameters.Add(Me.GetParameter(pMaxValue))

            Me.Comparisons.Add(lComparison)
            Return Me
        End Function
#End Region

#Region "WhereTextIsLike"
        Protected Function WhereTextIsLike(ByVal pColumnName As String, ByVal pTextToFind As String) As QueryBuilder
            Me.Schema.ValidateColumnName(pColumnName)

            If Not (Me.Schema.Item(pColumnName).IsText) Then
                Throw New Exception(String.Format("La columna ""{0}"" no es un campo de tipo texto", pColumnName))
            End If

            Dim lComparison As New Comparison(Me, PendingOperator, Schema(pColumnName), ComparisonOperation.TextIsLike)
            lComparison.Parameters.Add(Me.GetParameter(pTextToFind))

            Me.Comparisons.Add(lComparison)
            Return Me
        End Function
#End Region

#Region "WhereValueIsGreaterThan"
        Protected Function WhereValueIsGreaterThan(ByVal pColumnName As String, ByVal pValue As Object) As QueryBuilder
            Me.Schema.ValidateColumnName(pColumnName)

            Dim lComparison As New Comparison(Me, PendingOperator, Schema(pColumnName), ComparisonOperation.ValueIsGreaterThan)
            lComparison.Parameters.Add(Me.GetParameter(pValue))

            Me.Comparisons.Add(lComparison)
            Return Me
        End Function
#End Region

#Region "WhereValueIsGreaterThanOrEqualsTo"
        Protected Function WhereValueIsGreaterThanOrEqualsTo(ByVal pColumnName As String, ByVal pValue As Object) As QueryBuilder
            Me.Schema.ValidateColumnName(pColumnName)

            Dim lComparison As New Comparison(Me, PendingOperator, Schema(pColumnName), ComparisonOperation.ValueIsGreaterThanOrEqualsTo)
            lComparison.Parameters.Add(Me.GetParameter(pValue))

            Me.Comparisons.Add(lComparison)
            Return Me
        End Function
#End Region

#Region "WhereValueIsLessThan"
        Protected Function WhereValueIsLessThan(ByVal pColumnName As String, ByVal pValue As Object) As QueryBuilder
            Me.Schema.ValidateColumnName(pColumnName)

            Dim lComparison As New Comparison(Me, PendingOperator, Schema(pColumnName), ComparisonOperation.ValueIsLessThan)
            lComparison.Parameters.Add(Me.GetParameter(pValue))

            Me.Comparisons.Add(lComparison)
            Return Me
        End Function
#End Region

#Region "WhereValueIsLessThanOrEqualsTo"
        Protected Function WhereValueIsLessThanOrEqualsTo(ByVal pColumnName As String, ByVal pValue As Object) As QueryBuilder
            Me.Schema.ValidateColumnName(pColumnName)

            Dim lComparison As New Comparison(Me, PendingOperator, Schema(pColumnName), ComparisonOperation.ValueIsLessThanOrEqualsTo)
            lComparison.Parameters.Add(Me.GetParameter(pValue))

            Me.Comparisons.Add(lComparison)
            Return Me
        End Function
#End Region

#Region "WhereDateIs"
        Protected Function WhereDateIs(ByVal pColumnName As String, ByVal pValue As DateTime) As QueryBuilder
            Me.Schema.ValidateColumnName(pColumnName)

            If Not (Me.Schema.Item(pColumnName).IsDate) Then
                Throw New Exception(String.Format("La columna ""{0}"" no es un campo de fecha", pColumnName))
            End If

            Dim lThisDay As DateTime
            lThisDay = New DateTime(pValue.Year, pValue.Month, pValue.Day)

            If (lThisDay.Subtract(pValue).TotalSeconds = 0) Then
                Dim lInitialDate As DateTime
                Dim lFinalDate As DateTime

                lInitialDate = lThisDay
                lFinalDate = lInitialDate.AddDays(1).AddSeconds(-1)

                Me.WhereDateIsBetween(pColumnName, lInitialDate, lFinalDate)
            Else
                Me.WhereValueEqualsTo(pColumnName, pValue)
            End If

            Return Me
        End Function
#End Region

#Region "WhereValueIsDifferentFrom"
        Protected Function WhereValueIsDifferentFrom(ByVal pColumnName As String, ByVal pValue As Object) As QueryBuilder
            Me.Schema.ValidateColumnName(pColumnName)

            Dim lComparison As New Comparison(Me, PendingOperator, Schema(pColumnName), ComparisonOperation.ValueIsDifferentFrom)
            lComparison.Parameters.Add(Me.GetParameter(pValue))

            Me.Comparisons.Add(lComparison)
            Return Me
        End Function
#End Region

#Region "Order By"
        Public Function OrderBy(ByVal pColumnName As String, ByVal pDirectionOrder As OrderByStatements) As QueryBuilder
            Dim lOrder As New Order

            lOrder.Column = Me.Schema(pColumnName)
            lOrder.DirectionOrder = pDirectionOrder

            Me.OrderByList.Add(lOrder)

            Return Me
        End Function
#End Region

#Region "Top"
        Public Function Top(ByVal pTopRecords As Integer) As QueryBuilder
            If (pTopRecords < 0) Then
                Me._TopValue = 0
            Else
                Me._TopValue = pTopRecords
            End If

            Return Me
        End Function
#End Region

#Region "Join"
        Protected Function Join(ByVal pQuery As QueryBuilder) As QueryBuilder
            Me.Joins.Add(pQuery)
            Return pQuery
        End Function
#End Region

#End Region

#Region "Internal Classes"

#Region "Comparison Class"
        Public Class Comparison
            Private _Query As QueryBuilder
            Public ReadOnly Property Query() As QueryBuilder
                Get
                    Return _Query
                End Get
            End Property

            Private _LogicalOperator As LogicalOperatorType
            ''' <summary>
            ''' Wich operator will use the sentence
            ''' </summary>
            Public Property LogicalOperator() As LogicalOperatorType
                Get
                    Return Me._LogicalOperator
                End Get
                Set(ByVal value As LogicalOperatorType)
                    Me._LogicalOperator = value
                End Set
            End Property

            Private _Parameters As List(Of DataAccess.DataParameter)
            ''' <summary>
            ''' Stores a list of parameters
            ''' </summary>
            Public ReadOnly Property Parameters() As List(Of DataAccess.DataParameter)
                Get
                    If (_Parameters Is Nothing) Then
                        _Parameters = New List(Of DataAccess.DataParameter)
                    End If
                    Return _Parameters
                End Get
            End Property

            Private _ComparisonType As QueryBuilder.ComparisonOperation
            Public ReadOnly Property ComparisonType() As QueryBuilder.ComparisonOperation
                Get
                    Return _ComparisonType
                End Get
            End Property

            Public Sub New(ByVal pQuery As QueryBuilder, ByVal pLogicalOperator As LogicalOperatorType, ByVal pColumn As SchemaColumn, ByVal pComparisonType As QueryBuilder.ComparisonOperation)
                Me._LogicalOperator = LogicalOperator
                Me._Query = pQuery
                Me._Column = pColumn
                Me._ComparisonType = pComparisonType
            End Sub

            Private _Column As SchemaColumn
            Public Property Column() As SchemaColumn
                Get
                    Return _Column
                End Get
                Set(ByVal value As SchemaColumn)
                    _Column = value
                End Set
            End Property
        End Class
#End Region

#Region "Clase Order"
        Public Class Order
            Private _Column As SchemaColumn
            Public Property Column() As SchemaColumn
                Get
                    Return _Column
                End Get
                Set(ByVal value As SchemaColumn)
                    _Column = value
                End Set
            End Property

            Private _DirectionOrder As QueryBuilder.OrderByStatements
            Public Property DirectionOrder() As QueryBuilder.OrderByStatements
                Get
                    Return _DirectionOrder
                End Get
                Set(ByVal value As QueryBuilder.OrderByStatements)
                    _DirectionOrder = value
                End Set
            End Property

            Private _ParameterOrder As Integer
            Public Property ParameterOrder() As Integer
                Get
                    Return _ParameterOrder
                End Get
                Set(ByVal value As Integer)
                    _ParameterOrder = value
                End Set
            End Property
        End Class
#End Region

#End Region

#Region ".ctors"
        Public Sub New(ByVal pSchema As Schema, Optional ByVal pQueryType As RelationFormat = RelationFormat.None)
            Me._Schema = pSchema
            Me._QueryType = pQueryType
        End Sub
#End Region

    End Class
End Namespace

