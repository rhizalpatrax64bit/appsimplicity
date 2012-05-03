Namespace SomeERP
    ''' <summary>
    ''' Summary description for CustomerTypes
    ''' </summary>
    Partial Public Class CustomerType

        Private _Id As Integer
        ''' <summary>
        ''' Id
        ''' </summary>
        Public Property Id() As Integer
            Get
                Return _Id
            End Get
            Set(ByVal value As Integer)
                _Id = value
            End Set
        End Property		

        Private _Description As String
        ''' <summary>
        ''' Description
        ''' </summary>
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
			
