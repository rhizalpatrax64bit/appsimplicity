Namespace MetaDiscovery
    Public Class Parameter
        Private _MetaParameter As MyMeta.IParameter

        Private _Procedure As MetaDiscovery.Procedure
        <Browsable(False)> _
        Public ReadOnly Property Procedure() As MetaDiscovery.Procedure
            Get
                Return _Procedure
            End Get
        End Property

        ''' <summary>
        ''' The formatted display
        ''' </summary>        
        <System.ComponentModel.DisplayName("Display Name"), Category("Metadata"), Description("The formatted display")> _
        Public ReadOnly Property DisplayName() As String
            Get
                Return Me.GetFunctionName()
            End Get
        End Property

        <System.ComponentModel.DisplayName("Code Documentation"), Category("Code Documentation"), Description("A brief description of what the procedure does")> _
        Public Property Summary() As String
            Get
                Dim lKey As String = "Summary"

                Me.ValidatePropertyInstance(lKey, String.Format("Code description for parameter {0}", Me.Name))

                Return _MetaParameter.Properties(lKey).Value
            End Get
            Set(ByVal value As String)
                Dim lKey As String = "Summary"
                Me.ValidatePropertyInstance(lKey, String.Format("Code description for parameter {0}", Me.Name))

                _MetaParameter.Properties(lKey).Value = value
                Me.SaveData()
            End Set
        End Property

        Protected Sub ValidatePropertyInstance(ByVal pKey As String, ByVal pDefaultValue As String)
            If _MetaParameter.Properties(pKey) Is Nothing Then
                _MetaParameter.Properties.AddKeyValue(pKey, pDefaultValue)
                Me.SaveData()
            End If
        End Sub

        Private Sub SaveData()
            _Procedure.SaveData()
        End Sub


        ''' <summary>
        ''' The name of the undelying database object
        ''' </summary>        
        <System.ComponentModel.DisplayName("Name"), Category("Metadata"), Description("The name of the undelying database object")> _
        Public ReadOnly Property Name() As String
            Get
                Return _MetaParameter.Name
            End Get
        End Property

        ''' <summary>
        ''' The database type of the parameter
        ''' </summary>        
        <System.ComponentModel.DisplayName("Database Type"), Category("Metadata"), Description("The database type of the parameter")> _
        Public ReadOnly Property DBType() As String
            Get
                Return Me._MetaParameter.DataTypeNameComplete.ToUpper
            End Get
        End Property

        <System.ComponentModel.DisplayName("Max Length"), Category("Metadata"), Description("The character max length of the parameter")> _
        Public ReadOnly Property CharacterMaxLength() As Integer
            Get
                Return _MetaParameter.CharacterMaxLength
            End Get
        End Property

        <System.ComponentModel.DisplayName("Language Type"), Category("Metadata"), Description("The type of this parameter for code generation")> _
        Public ReadOnly Property LanguageType() As String
            Get
                Return _MetaParameter.LanguageType
            End Get
        End Property

        Private Function GetFunctionName() As String
            Dim lReturnValue As String = _MetaParameter.Name

            lReturnValue = lReturnValue.Replace("@", "").Replace("_", "").Replace(" ", "")
            Return lReturnValue
        End Function

        ''' <summary>
        ''' The mode that this parameter operates in
        ''' </summary>        
        <System.ComponentModel.DisplayName("Parameter Mode"), Category("Metadata"), Description("The mode that this parameter operates in")> _
        Public ReadOnly Property ParameterMode() As MyMeta.ParamDirection
            Get
                Return _MetaParameter.Direction
            End Get
        End Property

        ''' <summary>
        ''' The query parameter
        ''' </summary>
        <System.ComponentModel.DisplayName("QueryParameter"), Category("Metadata"), Description("The query parameter")> _
        Public ReadOnly Property QueryParameter() As String
            Get
                Return _MetaParameter.DataTypeNameComplete
            End Get
        End Property

        ''' <summary>
        ''' What kind of variable type this parameter is on Visual Basic
        ''' </summary>
        <System.ComponentModel.DisplayName("Variable Type"), Category("Metadata"), Description("What kind of variable type this parameter is on Visual Basic")> _
        Public ReadOnly Property VariableType() As String
            Get
                Return Me._MetaParameter.DbTargetType
            End Get
        End Property

        Public Sub New(ByVal pUnderlyingParameter As MyMeta.IParameter, ByVal pProcedure As MetaDiscovery.Procedure)
            _Procedure = pProcedure
            _MetaParameter = pUnderlyingParameter
        End Sub
    End Class
End Namespace
