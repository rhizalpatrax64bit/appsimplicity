Imports AppSimplicity.ActiveRecord

Namespace SomeERP
    ''' <summary>
    ''' Summary description for Customers
    ''' </summary>
    Partial Public Class Customer
        Implements IActiveRecord, IEntity

        Private _Id As Integer
        ''' <summary>
        ''' Id
        ''' </summary>        
        Public Property Id As Integer Implements AppSimplicity.ActiveRecord.IActiveRecord.Id
            Get
                Return _Id
            End Get
            Set(ByVal value As Integer)
                _Id = value
            End Set
        End Property

        Private _Name As String
        ''' <summary>
        ''' Name
        ''' </summary>
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property	
			
        Private _TaxId As String
        ''' <summary>
        ''' TaxId
        ''' </summary>
        Public Property TaxId() As String
            Get
                Return _TaxId
            End Get
            Set(ByVal value As String)
                _TaxId = value
            End Set
        End Property	
			
        Private _Phone As String
        ''' <summary>
        ''' Phone
        ''' </summary>
        Public Property Phone() As String
            Get
                Return _Phone
            End Get
            Set(ByVal value As String)
                _Phone = value
            End Set
        End Property	
			
        Private _Email As String
        ''' <summary>
        ''' Email
        ''' </summary>
        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(ByVal value As String)
                _Email = value
            End Set
        End Property	
			
        Private _CompanyName As String
        ''' <summary>
        ''' CompanyName
        ''' </summary>
        Public Property CompanyName() As String
            Get
                Return _CompanyName
            End Get
            Set(ByVal value As String)
                _CompanyName = value
            End Set
        End Property	
			
        Private _CreatedOn As Nullable(Of DateTime)
        ''' <summary>
        ''' CreatedOn
        ''' </summary>
        Public Property CreatedOn() As Nullable(Of DateTime)
            Get
                Return _CreatedOn
            End Get
            Set(ByVal value As Nullable(Of DateTime))
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
			
        Private _ModifiedOn As Nullable(Of DateTime)
        ''' <summary>
        ''' ModifiedOn
        ''' </summary>
        Public Property ModifiedOn() As Nullable(Of DateTime)
            Get
                Return _ModifiedOn
            End Get
            Set(ByVal value As Nullable(Of DateTime))
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
			
        Private _Active As Nullable(Of Boolean)
        ''' <summary>
        ''' Active
        ''' </summary>
        Public Property Active() As Nullable(Of Boolean)
            Get
                Return _Active
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _Active = value
            End Set
        End Property	
			
        Private _CustomerTypeId As Nullable(Of Integer)
        ''' <summary>
        ''' CustomerTypeId
        ''' </summary>
        Public Property CustomerTypeId() As Nullable(Of Integer)
            Get
                Return _CustomerTypeId
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _CustomerTypeId = value
            End Set
        End Property	
			
        Private _IsLoadedFromDB As Boolean = False
        Public Property IsLoadedFromDB As Boolean Implements AppSimplicity.ActiveRecord.IEntity.IsLoadedFromDB
            Get
                Return _IsLoadedFromDB
            End Get
            Set(ByVal value As Boolean)
                _IsLoadedFromDB = value
            End Set
        End Property

    End Class
End Namespace
			
