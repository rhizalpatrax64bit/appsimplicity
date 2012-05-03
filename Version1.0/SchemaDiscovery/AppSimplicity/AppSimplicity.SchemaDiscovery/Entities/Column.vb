Namespace Entities
    Public Class Column

        Private _ColumnName As String
        <Category("Metadata"), DisplayName("Column name"), Description("The name of the column in the table"), [ReadOnly](True)> _
        Public Property ColumnName() As String
            Get
                Return _ColumnName
            End Get
            Set(ByVal value As String)
                _ColumnName = value
            End Set
        End Property

        Private _PropertyName As String = String.Empty
        <Category("Code generation"), DisplayName("Property name"), Description("The name of the CLR target property."), PersistAfterRefreshSchema(True)> _
        Public Property PropertyName() As String
            Get
                If (_PropertyName = String.Empty) Then
                    _PropertyName = Me.ColumnName
                End If
                Return _PropertyName
            End Get
            Set(ByVal value As String)
                _PropertyName = value
            End Set
        End Property

        Private _SQLType As String
        <[ReadOnly](True), Category("Metadata"), DisplayName("SQL source type")> _
        Public Property SQLType() As String
            Get
                Return _SQLType
            End Get
            Set(ByVal value As String)
                _SQLType = value
            End Set
        End Property

        Private _CharMaxLength As Integer
        <[ReadOnly](True), Category("Metadata"), DisplayName("Max char length"), Description("The maximumn number of characters for this column. Applies only for text columns.")> _
        Public Property CharMaxLength() As Integer
            Get
                Return _CharMaxLength
            End Get
            Set(ByVal value As Integer)
                _CharMaxLength = value
            End Set
        End Property

        Private _IsNullable As Boolean
        <Category("Metadata"), DisplayName("Is nullable"), Description("Determines if this property can be set to a null value."), [ReadOnly](True)> _
        Public Property IsNullable() As Boolean
            Get
                Return _IsNullable
            End Get
            Set(ByVal value As Boolean)
                _IsNullable = value
            End Set
        End Property

        Private _IsIdentity As Boolean
        <Category("Metadata"), DisplayName("Is identity"), Description("Determines if this column is an identity field."), [ReadOnly](True)> _
        Public Property IsIdentity() As Boolean
            Get
                Return _IsIdentity
            End Get
            Set(ByVal value As Boolean)
                _IsIdentity = value
            End Set
        End Property

        Private _CLRTargetType As String
        <Category("Code generation"), DisplayName("CLR target type"), Description("Sets the CLR target property type"), [ReadOnly](True)> _
        Public Property CLRTargetType() As String
            Get
                Return _CLRTargetType
            End Get
            Set(ByVal value As String)
                _CLRTargetType = value
            End Set
        End Property

    End Class
End Namespace

