Imports AppSimplicityV0
Imports System.Xml.Serialization
Imports System.Data.Common
Imports System.ComponentModel

Namespace Dummy

#Region "Clase de Acceso a Datos para la Entidad [Customers]"
    ''' <summary>
    ''' Summary description for Customer class
    ''' </summary>
    <Serializable()> _
    Partial Public Class Customer
        Inherits ActiveRecord.ActiveRecord

#Region "Propiedades"
        ''' <summary>
        ''' Id
        ''' </summary>                
        <XmlAttribute("Id"), Bindable(True)> _
        Public Property Id() As Integer
            Get
                Return Me.Item("Id").Value
            End Get
            Set(ByVal value As Integer)
                Me.Item("Id").Value = value
            End Set
        End Property

        ''' <summary>
        ''' Name
        ''' </summary>                
        <XmlAttribute("Name"), Bindable(True)> _
        Public Property Name() As String
            Get
                Return Me.Item("Name").Value
            End Get
            Set(ByVal value As String)
                Me.Item("Name").Value = value
            End Set
        End Property

        ''' <summary>
        ''' Address
        ''' </summary>                
        <XmlAttribute("Address"), Bindable(True)> _
        Public Property Address() As String
            Get
                Return Me.Item("Address").Value
            End Get
            Set(ByVal value As String)
                Me.Item("Address").Value = value
            End Set
        End Property

        ''' <summary>
        ''' Phone
        ''' </summary>                
        <XmlAttribute("Phone"), Bindable(True)> _
        Public Property Phone() As String
            Get
                Return Me.Item("Phone").Value
            End Get
            Set(ByVal value As String)
                Me.Item("Phone").Value = value
            End Set
        End Property

        ''' <summary>
        ''' BirthOn
        ''' </summary>                
        <XmlAttribute("BirthOn"), Bindable(True)> _
        Public Property BirthOn() As DateTime
            Get
                Return Me.Item("BirthOn").Value
            End Get
            Set(ByVal value As DateTime)
                Me.Item("BirthOn").Value = value
            End Set
        End Property

        ''' <summary>
        ''' AnnualIncoming
        ''' </summary>                
        <XmlAttribute("AnnualIncoming"), Bindable(True)> _
        Public Property AnnualIncoming() As Decimal
            Get
                Return Me.Item("AnnualIncoming").Value
            End Get
            Set(ByVal value As Decimal)
                Me.Item("AnnualIncoming").Value = value
            End Set
        End Property

        ''' <summary>
        ''' Active
        ''' </summary>                
        <XmlAttribute("Active"), Bindable(True)> _
        Public Property Active() As Boolean
            Get
                Return Me.Item("Active").Value
            End Get
            Set(ByVal value As Boolean)
                Me.Item("Active").Value = value
            End Set
        End Property

        ''' <summary>
        ''' Average
        ''' </summary>                
        <XmlAttribute("Average"), Bindable(True)> _
        Public Property Average() As Double
            Get
                Return Me.Item("Average").Value
            End Get
            Set(ByVal value As Double)
                Me.Item("Average").Value = value
            End Set
        End Property

        ''' <summary>
        ''' UserTypeId
        ''' </summary>                
        <XmlAttribute("UserType_Id"), Bindable(True)> _
        Public Property UserTypeId() As Integer
            Get
                Return Me.Item("UserType_Id").Value
            End Get
            Set(ByVal value As Integer)
                Me.Item("UserType_Id").Value = value
            End Set
        End Property


#End Region

#Region "Propiedades Extendidas"





#End Region

#Region "Esquema"
        Private Shared _SchemaInstance As ActiveRecord.Schema = Nothing
        Public Shared ReadOnly Property SchemaInstance() As ActiveRecord.Schema
            Get
                If _SchemaInstance Is Nothing Then
                    _SchemaInstance = GetSchema()
                End If
                Return _SchemaInstance
            End Get
        End Property

        Public Shared Function GetSchema(Optional ByVal pIncludeDependencies As Boolean = True) As ActiveRecord.Schema
            Dim lSchema As New ActiveRecord.Schema("Customers", DataService.Instance, False)
            Dim lColumn As ActiveRecord.SchemaColumn

            lColumn = New ActiveRecord.SchemaColumn()
            lColumn.ColumnName = "Id"
            lColumn.DataType = DbType.Int32
            lColumn.MaxLength = 0
            lColumn.AutoIncrement = True
            lColumn.IsNullable = False
            lColumn.IsPrimaryKey = True
            lColumn.FieldLabel = "Id"
            lColumn.GridCaption = "Id"
            lColumn.IsDescription = True
            lSchema.AddColumn(lColumn)

            lColumn = New ActiveRecord.SchemaColumn()
            lColumn.ColumnName = "Name"
            lColumn.DataType = DbType.AnsiString
            lColumn.MaxLength = 50
            lColumn.AutoIncrement = False
            lColumn.IsNullable = True
            lColumn.IsPrimaryKey = False
            lColumn.FieldLabel = "Name"
            lColumn.GridCaption = "Name"
            lColumn.IsDescription = True
            lSchema.AddColumn(lColumn)

            lColumn = New ActiveRecord.SchemaColumn()
            lColumn.ColumnName = "Address"
            lColumn.DataType = DbType.AnsiString
            lColumn.MaxLength = 2147483647
            lColumn.AutoIncrement = False
            lColumn.IsNullable = False
            lColumn.IsPrimaryKey = False
            lColumn.FieldLabel = "Address"
            lColumn.GridCaption = "Address"
            lColumn.IsDescription = True
            lSchema.AddColumn(lColumn)

            lColumn = New ActiveRecord.SchemaColumn()
            lColumn.ColumnName = "Phone"
            lColumn.DataType = DbType.AnsiString
            lColumn.MaxLength = 20
            lColumn.AutoIncrement = False
            lColumn.IsNullable = False
            lColumn.IsPrimaryKey = False
            lColumn.FieldLabel = "Phone"
            lColumn.GridCaption = "Phone"
            lColumn.IsDescription = True
            lSchema.AddColumn(lColumn)

            lColumn = New ActiveRecord.SchemaColumn()
            lColumn.ColumnName = "BirthOn"
            lColumn.DataType = DbType.DateTime
            lColumn.MaxLength = 0
            lColumn.AutoIncrement = False
            lColumn.IsNullable = False
            lColumn.IsPrimaryKey = False
            lColumn.FieldLabel = "BirthOn"
            lColumn.GridCaption = "BirthOn"
            lColumn.IsDescription = True
            lSchema.AddColumn(lColumn)

            lColumn = New ActiveRecord.SchemaColumn()
            lColumn.ColumnName = "AnnualIncoming"
            lColumn.DataType = DbType.Currency
            lColumn.MaxLength = 0
            lColumn.AutoIncrement = False
            lColumn.IsNullable = False
            lColumn.IsPrimaryKey = False
            lColumn.FieldLabel = "AnnualIncoming"
            lColumn.GridCaption = "AnnualIncoming"
            lColumn.IsDescription = True
            lSchema.AddColumn(lColumn)

            lColumn = New ActiveRecord.SchemaColumn()
            lColumn.ColumnName = "Active"
            lColumn.DataType = DbType.Boolean
            lColumn.MaxLength = 0
            lColumn.AutoIncrement = False
            lColumn.IsNullable = False
            lColumn.IsPrimaryKey = False
            lColumn.FieldLabel = "Active"
            lColumn.GridCaption = "Active"
            lColumn.IsDescription = True
            lSchema.AddColumn(lColumn)

            lColumn = New ActiveRecord.SchemaColumn()
            lColumn.ColumnName = "Average"
            lColumn.DataType = DbType.Double
            lColumn.MaxLength = 0
            lColumn.AutoIncrement = False
            lColumn.IsNullable = False
            lColumn.IsPrimaryKey = False
            lColumn.FieldLabel = "Average"
            lColumn.GridCaption = "Average"
            lColumn.IsDescription = True
            lSchema.AddColumn(lColumn)

            lColumn = New ActiveRecord.SchemaColumn()
            lColumn.ColumnName = "UserType_Id"
            lColumn.DataType = DbType.Int32
            lColumn.MaxLength = 0
            lColumn.AutoIncrement = False
            lColumn.IsNullable = False
            lColumn.IsPrimaryKey = False
            lColumn.FieldLabel = "UserType_Id"
            lColumn.GridCaption = "UserType_Id"
            lColumn.IsDescription = True
            lSchema.AddColumn(lColumn)


            'Dependencias:
            If (pIncludeDependencies) Then

            End If

            Return lSchema
        End Function
#End Region

#Region "Campos"
        Private Shared _Fields As String() = { _
            "Id" _
            , "Name" _
            , "Address" _
            , "Phone" _
            , "BirthOn" _
            , "AnnualIncoming" _
            , "Active" _
            , "Average" _
            , "UserType_Id" _
        }

        Public Shared ReadOnly Property Fields() As String()
            Get
                Return _Fields
            End Get
        End Property

        Public Enum Columns
            Id = 0
            Name = 1
            Address = 2
            Phone = 3
            BirthOn = 4
            AnnualIncoming = 5
            Active = 6
            Average = 7
            UserTypeId = 8
        End Enum

#End Region

#Region "Funciones ById"
        ''' <summary>
        ''' Obtiene la instancia de un objeto a partir del la llave primaria
        ''' </summary>
        ''' <param name="pId">El valor de la identidad del objeto</param>
        ''' <remarks>Si el objeto no existe en el origen de datos devolverá una instancia nula</remarks>
        Public Shared Function FetchById(ByVal pId As Object) As Dummy.Customer
            Dim lInstance As Dummy.Customer = Nothing
            Dim lCollection As New CustomerCollection

            lCollection.Query.WhereValueEqualsTo(Columns.Id, pId).FillCollection()

            If (lCollection.HasItems) Then
                lInstance = lCollection(0)
            End If

            Return lInstance
        End Function

        ''' <summary>
        ''' Elimina un registro en el origen de datos a partir de la llave primaria
        ''' </summary>
        ''' <param name="pId">El valor de la identidad del objeto</param>
        ''' <remarks>Si la eliminación se realiza con éxito devuelve un valor verdadero</remarks>
        Public Shared Function DeleteById(ByVal pId As Object) As Boolean
            Dim lReturnValue As Boolean = False
            Dim lCollection As New CustomerCollection

            lCollection.Query.WhereValueEqualsTo(Columns.Id, pId).FillCollection()

            If (lCollection.HasItems) Then
                If (lCollection(0).Delete() <> 0) Then
                    lReturnValue = True
                End If
            End If

            Return lReturnValue
        End Function
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New(Dummy.Customer.SchemaInstance)
        End Sub
#End Region

    End Class
#End Region

#Region "Lista Activa"
    ''' <summary>
    ''' Encapsula el comportamiento de una colección de elementos de tipo Dummy.Customer
    ''' </summary>
    Partial Public Class CustomerCollection
        Inherits ActiveRecord.AbstractList(Of Dummy.Customer)

        Private _QueryBuilder As CustomerQueryBuilder
        ''' <summary>
        ''' Contiene la instancia del constructor de consultas dinámicas
        ''' </summary>        
        Public ReadOnly Property QueryBuilder() As CustomerQueryBuilder
            Get
                If (_QueryBuilder Is Nothing) Then
                    _QueryBuilder = New CustomerQueryBuilder(Me)
                End If
                Return _QueryBuilder
            End Get
        End Property

        ''' <summary>
        ''' Genera las instancias de los objetos a partir de un lector conectado
        ''' </summary>
        ''' <param name="pDR">La instancia del lector conectado al origen de datos</param>
        Public Overloads Overrides Sub FillCollection(ByVal pDR As System.Data.Common.DbDataReader)
            Dim lEntity As Dummy.Customer

            If (pDR.HasRows) Then
                While pDR.Read
                    lEntity = New Dummy.Customer
                    lEntity.Read(pDR, Me.QueryBuilder.QueryType)
                    Me.Add(lEntity)
                End While
            End If

            pDR.Close()
        End Sub

        ''' <summary>
        ''' Genera las instancias de los objetos a partir de un origen de datos
        ''' </summary>
        ''' <param name="pDS">La instancia del conjunto de datos</param>
        Public Overloads Overrides Sub FillCollection(ByVal pDS As System.Data.DataSet)
            Dim lEntity As Dummy.Customer

            If Not pDS Is Nothing Then
                If pDS.Tables.Count > 0 Then
                    For Each DR As DataRow In pDS.Tables(0).Rows
                        lEntity = New Dummy.Customer
                        lEntity.Read(DR, Me.QueryBuilder.QueryType)

                        Me.Add(lEntity)
                    Next
                End If
            End If
        End Sub

        ''' <summary>
        ''' Reinicia el constructor de querys
        ''' </summary>
        Public Sub ResetQueryBuilder()
            If Not (Me._QueryBuilder Is Nothing) Then
                Me.QueryBuilder.Comparisons.Clear()
            End If
        End Sub

        ''' <summary>
        ''' Obtiene los datos de la base de datos
        ''' </summary>
        Public Function GetDataSet() As System.Data.DataSet
            Return Me.QueryBuilder.Perform.ExecuteDataSet
        End Function

        ''' <summary>
        ''' Invoca el método Delete de todas las instancias de esta colección
        ''' </summary>        
        Public Sub DeleteAll()
            Dim N As Integer

            For N = 0 To Me.Count - 1
                Me(N).Delete()
            Next
        End Sub

        ''' <summary>
        ''' Invoca el método Save de todas las instancias de esta colección
        ''' </summary>        
        Public Sub SaveAll()
            Dim N As Integer

            For N = 0 To Me.Count - 1
                Me(N).Save()
            Next
        End Sub

#Region "Constructor"
        Public Sub New()
            MyBase.New(Customer.SchemaInstance)
        End Sub
#End Region

#Region "Querys"
        ''' <summary>
        ''' Prepara una consulta sobre una tabla mapeada a la colección
        ''' </summary>
        Public ReadOnly Property Query() As CustomerQueryBuilder
            Get
                Me.QueryBuilder.QueryType = ActiveRecord.QueryBuilder.RelationFormat.None
                Return Me.QueryBuilder
            End Get
        End Property

        ''' <summary>
        ''' Prepara una consulta sobre una tabla mapeada a la colección, la consulta se realizará incluyendo las dependencias de las relaciones
        ''' </summary>
        Public ReadOnly Property QueryWithDependencies() As CustomerQueryBuilder
            Get
                Me.QueryBuilder.QueryType = ActiveRecord.QueryBuilder.RelationFormat.All
                Return Me.QueryBuilder
            End Get
        End Property

        ''' <summary>
        ''' Prepara una consulta sobre una tabla mapeada a la colección, la consulta se realizará incluyendo las descripciones de las relaciones
        ''' </summary>
        Public ReadOnly Property QueryWithDescriptions() As CustomerQueryBuilder
            Get
                Me.QueryBuilder.QueryType = ActiveRecord.QueryBuilder.RelationFormat.JustDescriptions
                Return Me.QueryBuilder
            End Get
        End Property
#End Region

    End Class
#End Region

#Region "Constructor de Consultas"
    Partial Public Class CustomerQueryBuilder
        Inherits ActiveRecord.QueryBuilder

        Private _Collection As Dummy.CustomerCollection

#Region "Where methods"
        Public Shadows Function WhereValueEqualsTo(ByVal pColumn As Customer.Columns, ByVal pValue As Object) As CustomerQueryBuilder
            MyBase.WhereValueEqualsTo(Customer.Fields(pColumn), pValue)
            Return Me
        End Function

        Public Shadows Function WhereValueIsBetween(ByVal pColumn As Customer.Columns, ByVal pMinValue As Object, ByVal pMaxValue As Object) As CustomerQueryBuilder
            MyBase.WhereValueIsBetween(Customer.Fields(pColumn), pMinValue, pMaxValue)
            Return Me
        End Function

        Public Shadows Function WhereDateIsBetween(ByVal pColumn As Customer.Columns, ByVal pMinDate As DateTime, ByVal pMaxDate As Object) As CustomerQueryBuilder
            MyBase.WhereDateIsBetween(Customer.Fields(pColumn), pMinDate, pMaxDate)
            Return Me
        End Function

        Public Shadows Function WhereDateIs(ByVal pColumn As Customer.Columns, ByVal pValue As DateTime) As CustomerQueryBuilder
            MyBase.WhereDateIs(Customer.Fields(pColumn), pValue)
            Return Me
        End Function

        Public Shadows Function WhereValueIsGreaterThan(ByVal pColumn As Customer.Columns, ByVal pValue As Object) As CustomerQueryBuilder
            MyBase.WhereValueIsGreaterThan(Customer.Fields(pColumn), pValue)
            Return Me
        End Function

        Public Shadows Function WhereValueIsGreaterThanOrEqualsTo(ByVal pColumn As Customer.Columns, ByVal pValue As Object) As CustomerQueryBuilder
            MyBase.WhereValueIsGreaterThanOrEqualsTo(Customer.Fields(pColumn), pValue)
            Return Me
        End Function

        Public Shadows Function WhereValueIsLessThan(ByVal pColumn As Customer.Columns, ByVal pValue As Object) As CustomerQueryBuilder
            MyBase.WhereValueIsLessThan(Customer.Fields(pColumn), pValue)
            Return Me
        End Function

        Public Shadows Function WhereValueIsLessThanOrEqualsTo(ByVal pColumn As Customer.Columns, ByVal pValue As Object) As CustomerQueryBuilder
            MyBase.WhereValueIsLessThanOrEqualsTo(Customer.Fields(pColumn), pValue)
            Return Me
        End Function

        Public Shadows Function WhereTextIsLike(ByVal pColumn As Customer.Columns, ByVal pTextToFind As String) As CustomerQueryBuilder
            MyBase.WhereTextIsLike(Customer.Fields(pColumn), pTextToFind)
            Return Me
        End Function

        Public Shadows Function Top(ByVal pTopRecords As Integer) As CustomerQueryBuilder
            MyBase.Top(pTopRecords)
            Return Me
        End Function
#End Region


#Region "Ordenamiento"
        Public Shadows Function OrderBy(ByVal pColumn As Customer.Columns, Optional ByVal pDirectionOrder As ActiveRecord.QueryBuilder.OrderByStatements = OrderByStatements.ASC) As CustomerQueryBuilder
            MyBase.OrderBy(Customer.Fields(pColumn), pDirectionOrder)
            Return Me
        End Function
#End Region

#Region "Operadores Lógicos"
        Public Shadows Function And_() As CustomerQueryBuilder
            Me._PendingOperator = LogicalOperatorType._AND_
            Return Me
        End Function

        Public Shadows Function And_Not_() As CustomerQueryBuilder
            Me._PendingOperator = LogicalOperatorType._AND_NOT_
            Return Me
        End Function

        Public Shadows Function Or_() As CustomerQueryBuilder
            Me._PendingOperator = LogicalOperatorType._OR_
            Return Me
        End Function

        Public Shadows Function Or_Not_() As CustomerQueryBuilder
            Me._PendingOperator = LogicalOperatorType._OR_NOT_
            Return Me
        End Function
#End Region

        Public Sub New(ByVal pCollection As ActiveRecord.AbstractList(Of Dummy.Customer), Optional ByVal pQueryType As RelationFormat = RelationFormat.None)
            MyBase.New(pCollection.Schema, pQueryType)
            Me._Collection = pCollection
        End Sub
        
        Public Sub New(ByVal pSchema As ActiveRecord.Schema, Optional ByVal pQueryType As RelationFormat = RelationFormat.None)
            MyBase.New(pSchema, pQueryType)
        End Sub

        ''' <summary>
        ''' Llena la colección con la información obtenida de la consulta
        ''' </summary>
        Public Sub FillCollection()
            If Not (Me._Collection Is Nothing) Then
                Select Case (Me.Schema.DataService.Provider.DataAccessMode)
                    Case DataAccess.Providers.ProviderBase.DataAccesModes.ConnectedReaders
                        Me._Collection.FillCollection(Me.Perform.ExecuteDatareader)
                    Case DataAccess.Providers.ProviderBase.DataAccesModes.DisconnectedDataSets
                        Me._Collection.FillCollection(Me.Perform.ExecuteDataSet)
                End Select
            End If
        End Sub
    End Class
#End Region

End Namespace