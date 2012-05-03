Namespace Entities
    <Serializable()> _
    Public Class AbstractDataObject

        Private _Name As String
        <Category("Metadata"), DisplayName("Object name"), Description("The name of the object in the source database"), [ReadOnly](True)> _
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Private _Schema As String
        <Category("Metadata"), DisplayName("Schema name"), Description("The name of the schema owner in the source database"), [ReadOnly](True)> _
        Public Property Schema() As String
            Get
                Return _Schema
            End Get
            Set(ByVal value As String)
                _Schema = value
            End Set
        End Property

        <Category("Metadata"), DisplayName("Qualified name"), Description("The full qualified name of the object")> _
        Public ReadOnly Property QualifiedName() As String
            Get
                If (Schema <> String.Empty) Then
                    Return String.Format("{0}.{1}", Me.Schema, Me.Name)
                End If
                Return Me.Name
            End Get
        End Property

        Private _IncludeInCodeGeneration As Boolean = True
        <Category("Code generation"), DisplayName("Include in code generation"), Description("Sets if this object should be included for code generation"), PersistAfterRefreshSchema(True)> _
        Public Property IncludeInCodeGeneration() As Boolean
            Get
                Return _IncludeInCodeGeneration
            End Get
            Set(ByVal value As Boolean)
                _IncludeInCodeGeneration = value
            End Set
        End Property

        Private _DataSource As DataSource
        <Browsable(False)> _
        Public ReadOnly Property DataSource() As DataSource
            Get
                Return _DataSource
            End Get
        End Property

        Public Sub SetDataSource(ByVal pDataSource As DataSource)
            _DataSource = pDataSource
        End Sub
    End Class
End Namespace

