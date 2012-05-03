Public Class PersistAfterRefreshSchemaAttribute
    Inherits Attribute

    Private _Persist As Boolean
    Public Property Persist() As Boolean
        Get
            Return _Persist
        End Get
        Set(ByVal value As Boolean)
            _Persist = value
        End Set
    End Property

    Public Sub New(ByVal PersistAfterRefreshSchema As Boolean)
        _Persist = PersistAfterRefreshSchema
    End Sub

End Class


