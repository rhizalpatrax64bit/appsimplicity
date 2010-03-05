Namespace ActiveRecord.Query
    Public MustInherit Class QueryProperty

        Private _Query As QueryBuilder

        Protected ReadOnly Property Query() As QueryBuilder
            Get
                Return _Query
            End Get
        End Property

        Protected ReadOnly Property Schema() As ActiveRecord.Schema
            Get
                Return _Query.Schema
            End Get
        End Property

        Public Sub New(ByVal pQuery As QueryBuilder)
            _Query = pQuery
        End Sub

    End Class
End Namespace

