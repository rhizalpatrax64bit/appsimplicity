Namespace Entities
    <Serializable()> _
    Public Class StoredProcedureParameter

        Private _ParameterName As String
        <Category("Metadata"), DisplayName("Parameter name"), Description("The name of the stored procedure parameter"), [ReadOnly](True)> _
        Public Property ParameterName() As String
            Get
                Return _ParameterName
            End Get
            Set(ByVal value As String)
                _ParameterName = value
            End Set
        End Property

        Private _SQLType As String
        <Category("Metadata"), DisplayName("SQL type"), Description("The SQL type of the parameter"), [ReadOnly](True)> _
        Public Property SQLType() As String
            Get
                Return _SQLType
            End Get
            Set(ByVal value As String)
                _SQLType = value
            End Set
        End Property

        Private _CharMaxLength As Integer
        <Category("Metadata"), DisplayName("Max length"), Description("The maximum character length. Applies only for text parameters."), [ReadOnly](True)> _
        Public Property CharMaxLength() As Integer
            Get
                Return _CharMaxLength
            End Get
            Set(ByVal value As Integer)
                _CharMaxLength = value
            End Set
        End Property

        Private _CLRTargetType As String
        <Category("Metadata"), DisplayName("CLR target type"), Description("The name of the CLR target type for this parameter"), [ReadOnly](True)>
        Public Property CLRTargetType() As String
            Get
                Return _CLRTargetType
            End Get
            Set(ByVal value As String)
                _CLRTargetType = value
            End Set
        End Property

        Private _ParameterDirection As System.Data.ParameterDirection = Data.ParameterDirection.Input
        <Category("Metadata"), DisplayName("Parameter direction"), Description("Indicates the direction of the parameter."), [ReadOnly](True)> _
        Public Property ParameterDirection() As System.Data.ParameterDirection
            Get
                Return _ParameterDirection
            End Get
            Set(ByVal value As System.Data.ParameterDirection)
                _ParameterDirection = value
            End Set
        End Property
    End Class
End Namespace

