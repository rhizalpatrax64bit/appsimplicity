Namespace DataAccess
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

        Public Sub New(ByVal pParameterName As String, ByVal pValue As Object)
            Me.Name = pParameterName
            Me.Value = pValue
        End Sub

        Public Sub New()

        End Sub
    End Class

End Namespace

