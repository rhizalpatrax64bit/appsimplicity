Namespace Entities
    Public Class RelationShip

        Dim _ForeignEntityName As String
        Public Property ForeignEntityName() As String
            Get
                Return _ForeignEntityName
            End Get
            Set(ByVal value As String)
                _ForeignEntityName = value
            End Set
        End Property

        Dim _RelationshipColumn As String
        Public Property RelationshipColumn() As String
            Get
                Return _RelationshipColumn
            End Get
            Set(ByVal value As String)
                _RelationshipColumn = value
            End Set
        End Property

    End Class
End Namespace
