Public Class DataCommandParameter

    Private _Name As String
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    Private _Value As Object
    Public Property Value() As Object
        Get
            Return _Value
        End Get
        Set(ByVal value As Object)
            _Value = value
        End Set
    End Property

    Private _Type As System.Data.DbType
    Public Property Type() As System.Data.DbType
        Get
            Return _Type
        End Get
        Set(ByVal value As System.Data.DbType)
            _Type = value
        End Set
    End Property

    Private _Direction As System.Data.ParameterDirection = ParameterDirection.Input
    Public Property Direction() As System.Data.ParameterDirection
        Get
            Return _Direction
        End Get
        Set(ByVal value As System.Data.ParameterDirection)
            _Direction = value
        End Set
    End Property

    Public Sub New(ByVal pParameterName As String, ByVal pType As System.Data.DbType, ByVal pValue As Object)
        Me.Name = pParameterName
        Me.Type = pType
        Me.Value = pValue
    End Sub

    Public Sub New(ByVal pParameterName As String)
        Me.Name = pParameterName
    End Sub

End Class
