
Namespace SomeERP
    ''' <summary>
    ''' Summary description for Regions
    ''' </summary>
    Partial Public Class Region
        Implements AppSimplicity.ActiveRecord.IActiveRecord

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
			
        Private _Active As Boolean
        ''' <summary>
        ''' Active
        ''' </summary>
        Public Property Active() As Boolean
            Get
                Return _Active
            End Get
            Set(ByVal value As Boolean)
                _Active = value
            End Set
        End Property	
			
        Private _IsLoadedFromDB As Boolean = False
        Public Property IsLoadedFromDB As Boolean Implements AppSimplicity.ActiveRecord.IActiveRecord.IsLoadedFromDB
            Get
                Return _IsLoadedFromDB
            End Get
            Set(ByVal value As Boolean)
                _IsLoadedFromDB = value
            End Set
        End Property

    End Class
End Namespace
			
