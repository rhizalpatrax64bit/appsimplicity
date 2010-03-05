Namespace ActiveRecord.Query
#Region "Clase Order"
    Public Class OrderBy
        Public Enum OrderByDirections
            ASC
            DESC
        End Enum

        Private _Column As SchemaColumn
        Public Property Column() As SchemaColumn
            Get
                Return _Column
            End Get
            Set(ByVal value As SchemaColumn)
                _Column = value
            End Set
        End Property

        Public Sub New(ByVal pColumn As SchemaColumn, ByVal pDirection As OrderByDirections)
            _Column = pColumn
            _Direction = pDirection
        End Sub

        Private _Direction As OrderByDirections
        Public Property DirectionOrder() As OrderByDirections
            Get
                Return _Direction
            End Get
            Set(ByVal value As OrderByDirections)
                _Direction = value
            End Set
        End Property
    End Class
#End Region

End Namespace
