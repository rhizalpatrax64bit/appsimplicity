Namespace SomeERP
    ''' <summary>
    ''' Summary description for CustomerAddresses
    ''' </summary>
    Partial Public Class CustomerAddress

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

        Private _Customer_Id As Integer
        ''' <summary>
        ''' Customer_Id
        ''' </summary>
        Public Property Customer_Id() As Integer
            Get
                Return _Customer_Id
            End Get
            Set(ByVal value As Integer)
                _Customer_Id = value
            End Set
        End Property		

        Private _Address As String
        ''' <summary>
        ''' Address
        ''' </summary>
        Public Property Address() As String
            Get
                Return _Address
            End Get
            Set(ByVal value As String)
                _Address = value
            End Set
        End Property		

        Private _City As String
        ''' <summary>
        ''' City
        ''' </summary>
        Public Property City() As String
            Get
                Return _City
            End Get
            Set(ByVal value As String)
                _City = value
            End Set
        End Property		

        Private _Region_Id As Integer
        ''' <summary>
        ''' Region_Id
        ''' </summary>
        Public Property Region_Id() As Integer
            Get
                Return _Region_Id
            End Get
            Set(ByVal value As Integer)
                _Region_Id = value
            End Set
        End Property		

        Private _PostalCode As String
        ''' <summary>
        ''' PostalCode
        ''' </summary>
        Public Property PostalCode() As String
            Get
                Return _PostalCode
            End Get
            Set(ByVal value As String)
                _PostalCode = value
            End Set
        End Property		

        Private _CreatedOn As DateTime
        ''' <summary>
        ''' CreatedOn
        ''' </summary>
        Public Property CreatedOn() As DateTime
            Get
                Return _CreatedOn
            End Get
            Set(ByVal value As DateTime)
                _CreatedOn = value
            End Set
        End Property		

        Private _CreatedBy As String
        ''' <summary>
        ''' CreatedBy
        ''' </summary>
        Public Property CreatedBy() As String
            Get
                Return _CreatedBy
            End Get
            Set(ByVal value As String)
                _CreatedBy = value
            End Set
        End Property		

        Private _ModifiedOn As DateTime
        ''' <summary>
        ''' ModifiedOn
        ''' </summary>
        Public Property ModifiedOn() As DateTime
            Get
                Return _ModifiedOn
            End Get
            Set(ByVal value As DateTime)
                _ModifiedOn = value
            End Set
        End Property		

        Private _ModifiedBy As String
        ''' <summary>
        ''' ModifiedBy
        ''' </summary>
        Public Property ModifiedBy() As String
            Get
                Return _ModifiedBy
            End Get
            Set(ByVal value As String)
                _ModifiedBy = value
            End Set
        End Property		


    End Class
End Namespace
			
