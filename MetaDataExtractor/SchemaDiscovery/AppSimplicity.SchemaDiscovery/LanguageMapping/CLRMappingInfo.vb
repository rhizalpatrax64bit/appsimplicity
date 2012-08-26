Public Class CLRMappingInfo

    Private _DBSourceType As String
    Public Property DBSourceType() As String
        Get
            Return _DBSourceType
        End Get
        Set(ByVal value As String)
            _DBSourceType = value
        End Set
    End Property

    Private _TargetType As String
    Public Property CLRTargetType() As String
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
