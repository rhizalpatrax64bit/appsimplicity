Namespace DataAccess
    Public Class DataService

        Private _DataServiceName As String
        ''' <summary>
        ''' Returns the DataService name
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DataServiceName() As String
            Get
                Return _DataServiceName
            End Get
        End Property

        Private _DataSource As DataSource
        ''' <summary>
        ''' Holds an instance of the DataSource object.  
        ''' Every DataService instance must have an instance of a DataSource
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>DataSource can be specified at runtime using OnSetDataSource event.</remarks>
        Public ReadOnly Property DataSource() As DataSource
            Get
                If _DataSource Is Nothing Then
                    RaiseEvent OnSetDataSource(_DataSource)

                    If (_DataSource Is Nothing) Then
                        _DataSource = DataSource.GetDataSourceFromConfigFile(Me._DataServiceName)
                    End If

                    If (_DataSource Is Nothing) Then
                        Throw New Exception(String.Format(My.Resources.LocalizableMessages.DataSourceNotFound, Me.DataServiceName))
                    End If
                End If
                Return _DataSource
            End Get
        End Property

        Private _Provider As Providers.Provider
        Public ReadOnly Property Provider() As Providers.Provider
            Get
                If _Provider Is Nothing Then
                    _Provider = Providers.ProviderFactory.GetInstance(Me.DataSource)
                End If
                Return _Provider
            End Get
        End Property

        Private _Dialect As Dialect.DialectBase
        Public ReadOnly Property Dialect() As Dialect.DialectBase
            Get
                If _Dialect Is Nothing Then
                    _Dialect = DataAccess.Dialect.DialectFactory.GetDialectInstance(Me)
                End If
                Return _Dialect
            End Get
        End Property

        Private _UseSPsForCRUD As Boolean
        ''' <summary>
        ''' Indicates if dialect must use Stored Procedures to generate CRUD statements
        ''' </summary>        
        Public Property UseSPsForCRUD() As Boolean
            Get
                Return _UseSPsForCRUD
            End Get
            Set(ByVal value As Boolean)
                _UseSPsForCRUD = value
                RaiseEvent OnCommandTypeSelection()
            End Set
        End Property

        Public Event OnCommandTypeSelection()

        Private _SchemaFactory As ActiveRecord.SchemaFactory
        Public ReadOnly Property SchemaFactory() As ActiveRecord.SchemaFactory
            Get
                Return _SchemaFactory
            End Get
        End Property

        Private _Helper As ActiveRecord.ActiveHelper
        Public ReadOnly Property Helper() As ActiveRecord.ActiveHelper
            Get
                If (_Helper Is Nothing) Then
                    _Helper = New ActiveRecord.ActiveHelper(Me)
                End If
                Return _Helper
            End Get
        End Property
#Region "Events"
        Public Event OnSetDataSource(ByRef pDataSource As DataSource)
#End Region

#Region ".ctors"
        ''' <summary>
        ''' Constructor for dataservice instance
        ''' </summary>
        ''' <param name="pDataServiceName">A DataService name (usually this is the very same name for connection string)</param>
        ''' <param name="pUseSPsForCRUD">Indicates if dialect must use Stored Procedures to generate CRUD statements</param>
        Public Sub New(ByVal pDataServiceName As String, ByVal pFactory As ActiveRecord.SchemaFactory, ByVal pUseSPsForCRUD As Boolean)
            If (pDataServiceName = String.Empty) Then
                Throw New Exception(My.Resources.LocalizableMessages.DataServiceNameNotSpecified)
            End If

            Me._DataServiceName = pDataServiceName
            Me._SchemaFactory = pFactory
            _UseSPsForCRUD = pUseSPsForCRUD
        End Sub
#End Region

#Region "Command Functions"
        Public Function CreateCommand(ByVal pSQLStatement As String, ByVal pType As System.Data.CommandType) As DataCommand
            Return Me.Provider.CreateCommand(pSQLStatement, pType)
        End Function

        Public Function CreateSPCommand(ByVal pSQLStatement As String) As DataCommand
            Return Me.Provider.CreateSPCommand(pSQLStatement)
        End Function
#End Region

    End Class
End Namespace

