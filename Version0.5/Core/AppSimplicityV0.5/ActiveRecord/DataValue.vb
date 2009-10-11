Namespace ActiveRecord
    ''' <summary>
    ''' Instances derived from this class can store data information from columns 
    ''' of a physical mapped record
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DataValue

        Private _Column As SchemaColumn
        ''' <summary>
        ''' Holds an instance of a mapped column
        ''' </summary>
        Public ReadOnly Property Column() As SchemaColumn
            Get
                Return _Column
            End Get
        End Property

        ''' <summary>
        ''' Contains data from a column of a physical mapped record without no transformations
        ''' </summary>        
        Public ReadOnly Property UnderlyingValue() As Object
            Get
                If (_Value Is Nothing) Then
                    Return System.DBNull.Value
                End If
                Return _Value
            End Get
        End Property

        Private _Value As Object
        ''' <summary>
        ''' Establece u obtiene el valor almacenado en la columna, 
        ''' cuando el valor de la tabla física contiene NULL el valor Nothing 
        ''' será devuelto a la propiedad.
        ''' </summary>
        ''' <value>Si el valor es una cadena string, el maximo valor será validado</value>
        ''' <returns>Devuelve el valor almacenado</returns>
        Public Property Value() As Object
            Get
                If (_Value Is System.DBNull.Value) Then
                    If (Me.Column.IsDate) Then
                        Return Nothing
                    End If

                    If (Me.Column.IsText) Then
                        Return String.Empty
                    End If

                    If (Me.Column.IsNumeric) Then
                        Return 0
                    End If

                    If (Me.Column.DataType = DbType.Boolean) Then
                        Return False
                    End If

                    Return Nothing
                End If

                Return _Value
            End Get
            Set(ByVal value As Object)
                If (value Is Nothing) Then
                    value = System.DBNull.Value
                End If

                _Value = value
            End Set
        End Property

        ''' <summary>
        ''' Determina si el valor almacenado es un valur NULL
        ''' </summary>
        ''' <returns>Devuelve verdadero cuando el valor almacenado es NULL</returns>
        Public ReadOnly Property IsDBNull() As Boolean
            Get
                If (_Value Is System.DBNull.Value) Then
                    Return True
                End If
                Return False
            End Get
        End Property

#Region ".ctors"
        ''' <summary>
        ''' Inicializa el objeto del valor con la definición de la columna
        ''' </summary>
        ''' <param name="pColumn">Requiere un objeto TableColumn para ser instanciado</param>
        Public Sub New(ByVal pColumn As SchemaColumn)
            Me._Column = pColumn
            Me._Value = System.DBNull.Value
        End Sub
#End Region

    End Class
End Namespace

