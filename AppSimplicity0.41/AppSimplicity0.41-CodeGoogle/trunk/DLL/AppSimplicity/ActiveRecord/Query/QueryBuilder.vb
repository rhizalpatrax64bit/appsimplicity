Namespace ActiveRecord.Query
    Public MustInherit Class QueryBuilder

        Private _Schema As ActiveRecord.Schema
        Public ReadOnly Property Schema() As ActiveRecord.Schema
            Get
                Return _Schema
            End Get
        End Property

        Public Sub New(ByVal pSchema As ActiveRecord.Schema)
            _Schema = pSchema
        End Sub

        Private _Limit As Integer
        Public ReadOnly Property Limit() As Integer
            Get
                Return _Limit
            End Get
        End Property

        Private _UseQualifiedNames As Boolean = True
        Public Property UseQualifiedNames() As Boolean
            Get
                Return _UseQualifiedNames
            End Get
            Set(ByVal value As Boolean)
                _UseQualifiedNames = False
            End Set
        End Property

        Private _ColumnsList As List(Of SchemaColumn)
        Public ReadOnly Property ColumnsList() As List(Of SchemaColumn)
            Get
                If (_ColumnsList Is Nothing) Then
                    _ColumnsList = New List(Of SchemaColumn)
                End If
                Return _ColumnsList
            End Get
        End Property

        Public ReadOnly Property UseDataReaders() As Boolean
            Get
                Return False
            End Get
        End Property

        Private _Joins As Dictionary(Of String, Join)
        Public ReadOnly Property Joins() As Dictionary(Of String, Join)
            Get
                If (_Joins Is Nothing) Then
                    _Joins = New Dictionary(Of String, Join)
                End If
                Return _Joins
            End Get
        End Property

        Private _ParamCount As Integer = 0
        ''' <summary>
        ''' Lleva el contador de parámetros
        ''' </summary>
        Public ReadOnly Property ParamCount() As Integer
            Get
                _ParamCount = _ParamCount + 1
                Return _ParamCount
            End Get
        End Property

        Private _Comparisons As List(Of Comparison)
        Public Property Comparisons() As List(Of Comparison)
            Get
                If (_Comparisons Is Nothing) Then
                    _Comparisons = New List(Of Comparison)
                End If
                Return _Comparisons
            End Get
            Set(ByVal value As List(Of Comparison))
                _Comparisons = value
            End Set
        End Property

        Private _OrderByList As List(Of OrderBy)
        Public ReadOnly Property OrderByList() As List(Of OrderBy)
            Get
                If (_OrderByList Is Nothing) Then
                    _OrderByList = New List(Of OrderBy)
                End If
                Return _OrderByList
            End Get
        End Property

#Region "Methods"
        Private Sub AddJoinComparisons(ByVal pParentQuery As QueryBuilder, ByVal pCommand As DataAccess.DataCommand)
            For Each lKey As String In pParentQuery.Joins.Keys
                For Each lComparison As Comparison In pParentQuery.Joins(lKey).ForeignQuery.Comparisons
                    For Each lParameter As DataAccess.DataCommandParameter In lComparison.Parameters
                        pCommand.AddParameter(lParameter)
                    Next
                Next

                Me.AddJoinComparisons(pParentQuery.Joins(lKey).ForeignQuery, pCommand)
            Next
        End Sub

        Private Function GetCommand() As DataAccess.DataCommand
            Dim lCommand As DataAccess.DataCommand

            lCommand = Me.Schema.DataService.CreateCommand(Me.Schema.DataService.Dialect.Get_QueryBuilderStatement(Me), CommandType.Text)

            For Each lComparison As Comparison In Me.Comparisons
                For Each lParameter As DataAccess.DataCommandParameter In lComparison.Parameters
                    lCommand.AddParameter(lParameter)
                Next
            Next

            Me.AddJoinComparisons(Me, lCommand)

            Return lCommand
        End Function

        Protected Function GetComparisonMethods(ByVal pColumn As ActiveRecord.SchemaColumn, ByVal pOperator As Comparison.LogicalOperatorType) As ComparisonConditions
            Dim lComparison As New Comparison(Me, pOperator, pColumn)

            Return New ComparisonConditions(Me, lComparison)
        End Function


        Public Sub SetLimit(ByVal pLimit As Integer)
            If (pLimit < 0) Then
                _Limit = 0
            Else
                _Limit = pLimit
            End If
        End Sub

        Public Overridable Sub Reset()
            Me._ParamCount = 0
            Me.SetLimit(0)
            Me.Comparisons.Clear()
            Me.OrderByList.Clear()
        End Sub

        Public Function GetDataSet() As System.Data.DataSet
            Return Me.Schema.DataService.ExecuteDataSet(Me.GetCommand)
        End Function

        Public Sub AddOrderByStatement(ByVal pColumn As SchemaColumn, ByVal pDirection As OrderBy.OrderByDirections)
            Dim lOrderBy As New OrderBy(pColumn, pDirection)
            Me.OrderByList.Add(lOrderBy)
        End Sub

        Public Function CreateComparisonCondition(ByVal pColumnName As String, Optional ByVal pOperator As Query.Comparison.LogicalOperatorType = Comparison.LogicalOperatorType._AND_) As Query.ComparisonConditions
            Dim lComparison As New Query.Comparison(Me, pOperator, Me.Schema(pColumnName))

            Dim lComparisonCondition As New Query.ComparisonConditions(Me, lComparison)

            Return lComparisonCondition
        End Function
#End Region

    End Class

End Namespace
