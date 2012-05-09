Imports AppSimplicity.SchemaDiscovery

Namespace Query
    Public Class Comparison

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

        Private _Query As QueryBuilder
        Public ReadOnly Property Query() As QueryBuilder
            Get
                Return _Query
            End Get
        End Property

        Private _LogicalOperator As LogicalOperatorType
        ''' <summary>
        ''' Indica el tipo de operador lógico que se utilizará para la sentencia
        ''' </summary>
        Public Property LogicalOperator() As LogicalOperatorType
            Get
                Return Me._LogicalOperator
            End Get
            Set(ByVal value As LogicalOperatorType)
                Me._LogicalOperator = value
            End Set
        End Property

        Private _Parameters As List(Of DataAccess.DataCommandParameter)
        ''' <summary>
        ''' Almacena los parametros para realizar la consulta
        ''' </summary>
        Public ReadOnly Property Parameters() As List(Of DataAccess.DataCommandParameter)
            Get
                If (_Parameters Is Nothing) Then
                    _Parameters = New List(Of DataAccess.DataCommandParameter)
                End If
                Return _Parameters
            End Get
        End Property

        Private _ComparisonType As ComparisonOperation
        Public Property ComparisonType() As ComparisonOperation
            Get
                Return _ComparisonType
            End Get
            Set(ByVal value As ComparisonOperation)
                _ComparisonType = value
            End Set
        End Property

        Public Sub New(ByVal pQuery As QueryBuilder, ByVal pLogicalOperator As LogicalOperatorType, ByVal pColumn As Entities.Column)
            Me._LogicalOperator = LogicalOperator
            Me._Query = pQuery
            Me._Column = pColumn
        End Sub

        Private _Column As Entities.Column
        Public Property Column() As Entities.Column
            Get
                Return _Column
            End Get
            Set(ByVal value As Entities.Column)
                _Column = value
            End Set
        End Property
    End Class

End Namespace
