Namespace DataAccess
    Public Class DataParameter
        Private _Name As String
        Public ReadOnly Property Name() As String
            Get
                Return _Name
            End Get
        End Property

        Private _Value As Object
        Public ReadOnly Property Value() As Object
            Get
                Return _Value
            End Get
        End Property

        Public Sub New(ByVal pName As String, ByVal pValue As Object)
            Me._Name = pName
            Me._Value = pValue
        End Sub
    End Class
End Namespace

