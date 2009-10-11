Namespace ActiveRecord
    ''' <summary>
    ''' Contiene los métodos y propiedades que definen a una dependencia lógica del esquema de una tabla
    ''' </summary>
    Public Class ForeignDependency
        Private _BelongsToSchema As Schema
        ''' <summary>
        ''' Contiene el esquema de la tabla referenciada
        ''' </summary>        
        Public ReadOnly Property BelongsToSchema() As Schema
            Get
                Return _BelongsToSchema
            End Get
        End Property

        Private _BelongsToColumn As SchemaColumn
        ''' <summary>
        ''' Contiene el nombre de la columna que hace referencia a la entidad externa
        ''' </summary>        
        Public ReadOnly Property BelongsToColumn() As SchemaColumn
            Get
                Return _BelongsToColumn
            End Get
        End Property

        ''' <summary>
        ''' Crea una instancia de una dependencia lógica
        ''' </summary>
        ''' <param name="pForeignSchema">Contiene la definición del esquema de la tabla foránea</param>
        ''' <param name="pBelongsToColumn">El nombre de la columna que hace referencia a la entidad externa</param>
        Public Sub New(ByVal pForeignSchema As Schema, ByVal pBelongsToColumn As SchemaColumn)
            Me._BelongsToSchema = pForeignSchema
            Me._BelongsToColumn = pBelongsToColumn
        End Sub
    End Class
End Namespace