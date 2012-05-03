Namespace DependencyInjection
    Public Class ProviderDefinition

        Private _Name As String
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Private _ProviderType As String
        Public Property ProviderType() As String
            Get
                Return _ProviderType
            End Get
            Set(ByVal value As String)
                _ProviderType = value
            End Set
        End Property

        Private _Description As String
        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property

    End Class
End Namespace

