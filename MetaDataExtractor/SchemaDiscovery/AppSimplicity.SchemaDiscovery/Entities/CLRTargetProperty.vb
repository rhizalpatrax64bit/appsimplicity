Public Class CLRTargetProperty

    Private _TargetType As String
    Public Property TargetType() As String
        Get
            Return _TargetType
        End Get
        Set(ByVal value As String)
            _TargetType = value
        End Set
    End Property

    Private _IsCLRNullable As Boolean
    Public Property IsCLRNullable() As Boolean
        Get
            Return _IsCLRNullable
        End Get
        Set(ByVal value As Boolean)
            _IsCLRNullable = value
        End Set
    End Property

End Class
