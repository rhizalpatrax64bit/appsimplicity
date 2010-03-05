Namespace ActiveRecord.Query
    Public Class Join

        Private _JoinColumn As SchemaColumn
        Public ReadOnly Property JoinColumn() As SchemaColumn
            Get
                Return _JoinColumn
            End Get
        End Property

        Public ReadOnly Property ForeignQuery() As QueryBuilder
            Get
                Return _ForeignQuery
            End Get
        End Property

        Private _ForeignQuery As QueryBuilder

        Public Sub New(ByVal pJoinColumn As SchemaColumn, ByVal pForeignQuery As QueryBuilder)
            _JoinColumn = pJoinColumn
            _ForeignQuery = pForeignQuery
        End Sub

    End Class
End Namespace

