Namespace ActiveRecord
    ''' <summary>
    ''' Representa las intancias de de cada columna de las tablas 
    ''' mapeadas desde la base de datos.
    ''' </summary>
    Public Class SchemaColumn
#Region "Properties"
        Private _ColumnName As String
        ''' <summary>
        ''' Establece u obtiene el nombre de la columna
        ''' </summary>
        ''' <value>Una cadena que contiene el nombre de la columna</value>
        ''' <returns>El nombre de la columna en la tabla física</returns>
        Public Property ColumnName() As String
            Get
                Return _ColumnName
            End Get
            Set(ByVal value As String)
                _ColumnName = value
            End Set
        End Property

        Private _Schema As Schema
        ''' <summary>
        ''' Obtiene o establece el esquema de la tabla a la que pertenece la columna
        ''' </summary>        
        Public Property Schema() As Schema
            Get
                Return _Schema
            End Get
            Set(ByVal value As Schema)
                _Schema = value
            End Set
        End Property

        Private _DataType As System.Data.DbType
        ''' <summary>
        ''' Obtiene el tipo de dato que se puede almacenar en la columna
        ''' </summary>
        Public Property DataType() As System.Data.DbType
            Get
                Return _DataType
            End Get
            Set(ByVal value As System.Data.DbType)
                _DataType = value
            End Set
        End Property

        ''' <summary>
        ''' Determina si la columna puede contener valor de texto
        ''' </summary>
        Public ReadOnly Property IsText() As Boolean
            Get
                Dim lResult As Boolean = False

                Select Case Me.DataType
                    Case DbType.String, DbType.AnsiString, DbType.AnsiStringFixedLength, DbType.StringFixedLength
                        lResult = True
                End Select
                Return lResult
            End Get
        End Property

        ''' <summary>
        ''' Determina si la columna puede contener un valor numérico
        ''' </summary>
        Public ReadOnly Property IsNumeric() As Boolean
            Get
                Dim lResult As Boolean = False

                Select Case Me.DataType
                    Case DbType.Int16, DbType.Int32, DbType.Int64, _
                         DbType.Decimal, DbType.Double, _
                         DbType.Byte, DbType.Single, _
                         DbType.UInt16, DbType.UInt32, DbType.UInt64, _
                         DbType.VarNumeric
                        lResult = True
                End Select

                Return lResult
            End Get
        End Property

        ''' <summary>
        ''' Determina si la columna puede contener un valor de fecha
        ''' </summary>
        Public ReadOnly Property IsDate() As Boolean
            Get
                Dim lResult As Boolean = False

                Select Case Me.DataType
                    Case DbType.Date, DbType.DateTime, DbType.DateTime2
                        lResult = True
                End Select
                Return lResult
            End Get
        End Property

        Private _FieldLabel As String
        ''' <summary>
        ''' Obtiene el título del control de la interfaz de usuario
        ''' </summary>        
        Public Property FieldLabel() As String
            Get
                Return _FieldLabel
            End Get
            Set(ByVal value As String)
                _FieldLabel = value
            End Set
        End Property

        Private _GridCaption As String
        ''' <summary>
        ''' Obtiene la descripción de una columna
        ''' </summary>        
        ''' <remarks>Esta propiedad se utiliza para propósitos de presentación únicamente</remarks>
        Public Property GridCaption() As String
            Get
                Return _GridCaption
            End Get
            Set(ByVal value As String)
                _GridCaption = value
            End Set
        End Property

        Private _IsDescription As Boolean
        ''' <summary>
        ''' Determina si una columna contiene una descripción para el registro
        ''' </summary>
        ''' <returns>A boolean that indicates if the column contains a description value</returns>
        Public Property IsDescription() As Boolean
            Get
                Return _IsDescription
            End Get
            Set(ByVal value As Boolean)
                _IsDescription = value
            End Set
        End Property

        Private _MaxLength As Integer
        ''' <summary>
        ''' Establece la longitud máxima en caracteres del campo
        ''' </summary>
        ''' <remarks>Aplica únicamente para columnas que pueden almacenar datos de tipo cadena (como son VARCHAR, CHAR, TEXT, etc.)</remarks>
        Public Property MaxLength() As Integer
            Get
                Return _MaxLength
            End Get
            Set(ByVal value As Integer)
                _MaxLength = value
            End Set
        End Property

        Private _AutoIncrement As Boolean
        ''' <summary>
        ''' Propiedad que determina si una columna es autoincremental
        ''' </summary>        
        Public Property AutoIncrement() As Boolean
            Get
                Return _AutoIncrement
            End Get
            Set(ByVal value As Boolean)
                _AutoIncrement = value
            End Set
        End Property

        Private _IsNullable As Boolean
        ''' <summary>
        ''' Establece si el contenido de la columna puede ser un valor de tipo a System.DBnull.Value
        ''' </summary>
        Public Property IsNullable() As Boolean
            Get
                Return _IsNullable
            End Get
            Set(ByVal value As Boolean)
                _IsNullable = value
            End Set
        End Property

        Private _IsPrimaryKey As Boolean
        ''' <summary>
        ''' Determina si la columna se define como llave primaria 
        ''' </summary>
        Public Property IsPrimaryKey() As Boolean
            Get
                Return _IsPrimaryKey
            End Get
            Set(ByVal value As Boolean)
                _IsPrimaryKey = value
            End Set
        End Property
#End Region
    End Class
End Namespace

