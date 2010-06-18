Namespace MetaDiscovery
    Public Enum UIControlType As Integer
        TextField = 1
        CheckBox = 2
        IntegerNumberTextField = 3
        DateField = 4
        HTMLEditor = 5
        TextAreaField = 6
        FloatNumberTextField = 7
        ListOfValues = 8
        File = 9
    End Enum

    Public Enum AuditModes
        NotAuditable
        CreatedOn
        CreatedBy
        ModifiedOn
        ModifiedBy
    End Enum

    Public Class Column

        Private _MetaColumn As MyMeta.Column

#Region "Exposed Properties"
        <System.ComponentModel.DisplayName("Name"), Category("Metadata"), Description("Gets the name for this column")> _
        ReadOnly Property Name() As String
            Get
                Return Me._MetaColumn.Name
            End Get
        End Property


        <System.ComponentModel.DisplayName("Audit Mode"), Category("Metadata"), Description("Gets if this column acts as an audit column")> _
        ReadOnly Property AuditMode() As AuditModes
            Get
                Dim lReturnValue As AuditModes = AuditModes.NotAuditable

                Select Case (Me.Name.ToLower)
                    Case "createdon", "fechacreacion"
                        lReturnValue = AuditModes.CreatedOn

                    Case "createdby", "creadopor"
                        lReturnValue = AuditModes.CreatedBy

                    Case "modifiedon", "fechamodificacion"
                        lReturnValue = AuditModes.ModifiedOn

                    Case "modifiedby", "modificadopor"
                        lReturnValue = AuditModes.ModifiedBy

                End Select

                Return lReturnValue
            End Get
        End Property


        <System.ComponentModel.DisplayName("Field label"), Category("UI Control Generation"), Description("Describes a human readable description for this column")> _
        Public Property FieldLabel() As String
            Get
                Dim lKey As String = "ClassName"
                Me.ValidatePropertyInstance(lKey, Me.Name)

                Return _MetaColumn.Properties(lKey).Value
            End Get
            Set(ByVal value As String)
                Dim lKey As String = "ClassName"
                Me.ValidatePropertyInstance(lKey, Me.Name)

                _MetaColumn.Properties(lKey).Value = value
                Me.SaveData()
            End Set
        End Property

        <System.ComponentModel.DisplayName("Hint Text"), Category("UI Control Generation"), Description("Outputs hint for input editing.")> _
        Public Property HintText() As String
            Get
                Dim lKey As String = "HintText"
                Me.ValidatePropertyInstance(lKey, String.Format("Input {0} field.", Me.PropertyName))

                Return _MetaColumn.Properties(lKey).Value
            End Get
            Set(ByVal value As String)
                Dim lKey As String = "HintText"
                Me.ValidatePropertyInstance(lKey, Me.PropertyName)

                _MetaColumn.Properties(lKey).Value = value
                Me.SaveData()
            End Set
        End Property

        <System.ComponentModel.DisplayName("Show Hint when editing"), Category("UI Control Generation"), Description("Outputs hint for input editing.")> _
        Public Property DisplayHint() As Boolean
            Get
                Dim lKey As String = "DisplayHint"
                Me.ValidatePropertyInstance(lKey, True)

                Return _MetaColumn.Properties(lKey).Value
            End Get
            Set(ByVal value As Boolean)
                Dim lKey As String = "DisplayHint"
                Me.ValidatePropertyInstance(lKey, True)

                _MetaColumn.Properties(lKey).Value = value
                Me.SaveData()
            End Set
        End Property


        Private Function GetUIWidth(ByVal pColumn As MetaDiscovery.Column) As Integer
            Dim lReturnValue As Integer = 200

            If (pColumn.HasBelongsToReference) Then
                lReturnValue = 250
            Else

                Select Case (pColumn.DbTargetType)
                    Case _
                            "DbType.Byte", "DbType.UInt16", "DbType.UInt32", "DbType.UInt64", "DbType.Double", _
                            "DbType.Int16", "DbType.Int32", "DbType.Int64", "DbType.SByte", "DbType.Single"
                        lReturnValue = 130

                    Case _
                            "DbType.AnsiString", "DbType.AnsiStringFixedLength", "DbType.Guid", _
                            "DbType.Xml", "DbType.String", "DbType.StringFixedLength"
                        If (pColumn.MaxLength > 255) Then
                            lReturnValue = 600
                        Else
                            Dim lWidth As Decimal = pColumn.MaxLength * 600

                            lWidth = lWidth / 255

                            If (lWidth < 200) Then
                                lWidth = 200
                            End If

                            lReturnValue = Math.Floor(lWidth)
                        End If

                    Case "DbType.Boolean"
                        lReturnValue = 150

                    Case "DbType.Currency", "DbType.Decimal", "DbType.VarNumeric"
                        lReturnValue = 130

                    Case "DbType.Date", "DbType.DateTime"
                        lReturnValue = 200

                    Case "DbType.Object", "DbType.Binary"
                        lReturnValue = 400

                End Select

            End If

            Return lReturnValue
        End Function

        <System.ComponentModel.DisplayName("UI Control Width"), Category("UI Control Generation"), Description("Defines the width for ui generated control")> _
        Public Property UIControlWidth() As Integer
            Get
                Dim lKey As String = "UIControlWidth"
                Me.ValidatePropertyInstance(lKey, Convert.ToString(Me.GetUIWidth(Me)))

                If (Me.HasBelongsToReference) Then
                    _MetaColumn.Properties(lKey).Value = Convert.ToString(Me.GetUIWidth(Me))
                End If

                Return _MetaColumn.Properties(lKey).Value
            End Get
            Set(ByVal value As Integer)
                Dim lKey As String = "UIControlWidth"
                Me.ValidatePropertyInstance(lKey, "200")

                _MetaColumn.Properties(lKey).Value = value
                Me.SaveData()
            End Set
        End Property

        <System.ComponentModel.DisplayName("Allow filter by this column"), Category("UI Control Generation"), Description("Defines if the generated UI will allow to filter by this column")> _
        Public Property AllowFilter() As Boolean
            Get
                Dim lKey As String = "AllowFilter"
                Me.ValidatePropertyInstance(lKey, False)

                Return _MetaColumn.Properties(lKey).Value
            End Get
            Set(ByVal value As Boolean)
                Dim lKey As String = "AllowFilter"
                Me.ValidatePropertyInstance(lKey, False)

                _MetaColumn.Properties(lKey).Value = value
                Me.SaveData()
            End Set
        End Property

        <System.ComponentModel.DisplayName("Has a BelongsTo Reference"), Category("UI Control Generation"), Description("Wether or not this column describes an external BelongsTo reference")> _
        Public ReadOnly Property HasBelongsToReference() As Boolean
            Get
                Dim lReturnValue As Boolean = False

                If Not (Me.Table Is Nothing) Then
                    For Each lReference As MetaDiscovery.MetaRelation In Me.Table.BelongsToRelations
                        If (lReference.ExternalReferenceColumn.Name = Me.Name) Then
                            lReturnValue = True
                            Exit For
                        End If
                    Next
                End If

                Return lReturnValue
            End Get
        End Property


        Private Function GetEditUIType(ByVal pColumn As MetaDiscovery.Column) As MetaDiscovery.UIControlType
            Dim lReturnValue As MetaDiscovery.UIControlType = MetaDiscovery.UIControlType.TextField

            If (pColumn.HasBelongsToReference) Then
                lReturnValue = MetaDiscovery.UIControlType.ListOfValues
            Else
                Select Case (pColumn.DbTargetType)
                    Case _
                            "DbType.Byte", "DbType.UInt16", "DbType.UInt32", "DbType.UInt64", "DbType.Double", _
                            "DbType.Int16", "DbType.Int32", "DbType.Int64", "DbType.SByte", "DbType.Single"
                        lReturnValue = MetaDiscovery.UIControlType.IntegerNumberTextField

                    Case _
                            "DbType.AnsiString", "DbType.AnsiStringFixedLength", "DbType.Guid", _
                            "DbType.Xml", "DbType.String", "DbType.StringFixedLength"
                        If (pColumn.MaxLength > 255) Then
                            lReturnValue = MetaDiscovery.UIControlType.TextAreaField
                        Else
                            lReturnValue = MetaDiscovery.UIControlType.TextField
                        End If

                    Case "DbType.Boolean"
                        lReturnValue = MetaDiscovery.UIControlType.CheckBox

                    Case "DbType.Currency", "DbType.Decimal", "DbType.VarNumeric"
                        lReturnValue = MetaDiscovery.UIControlType.FloatNumberTextField

                    Case "DbType.Date", "DbType.DateTime"
                        lReturnValue = MetaDiscovery.UIControlType.DateField

                    Case "DbType.Object", "DbType.Binary"
                        lReturnValue = MetaDiscovery.UIControlType.File

                End Select

            End If

            Return lReturnValue
        End Function

        ''' <summary>
        ''' Obtiene la referencia de la tabla 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetForeignRelation() As MetaDiscovery.MetaRelation
            Dim lReturnValue As MetaDiscovery.MetaRelation = Nothing

            For Each lRelation As MetaDiscovery.MetaRelation In Me.Table.BelongsToRelations
                If (lRelation.ExternalReferenceColumn.Name = Me.Name) Then
                    lReturnValue = lRelation
                    Exit For
                End If
            Next

            Return lReturnValue
        End Function

        <System.ComponentModel.DisplayName("UI Control Type"), Category("UI Control Generation"), Description("Sets the UI predefined control")> _
        Public Property UIControlType() As MetaDiscovery.UIControlType
            Get
                Dim lKey As String = "UIControlType"
                Me.ValidatePropertyInstance(lKey, Me.GetEditUIType(Me))

                If (Me.HasBelongsToReference) Then
                    _MetaColumn.Properties(lKey).Value = Me.GetEditUIType(Me)
                End If

                Return _MetaColumn.Properties(lKey).Value
            End Get
            Set(ByVal value As UIControlType)
                Dim lKey As String = "UIControlType"
                Me.ValidatePropertyInstance(lKey, MetaDiscovery.UIControlType.TextField)

                _MetaColumn.Properties(lKey).Value = value
                Me.SaveData()
            End Set
        End Property

        <System.ComponentModel.DisplayName("UI Control ID"), Category("UI Control Generation"), Description("Gets the UI control generated id")> _
       Public ReadOnly Property UIControlID() As String
            Get
                Return String.Format("ctrl_{0}", Me.Name.ToLower)
            End Get
        End Property

        <System.ComponentModel.DisplayName("Net Language Target Type"), Category("Metadata"), Description("Gets the NET CLR target type for column")> _
        Public ReadOnly Property DbTargetType() As String
            Get
                Return _MetaColumn.DbTargetType
            End Get
        End Property

        <System.ComponentModel.DisplayName("Grid Column Caption"), Category("UI Grid Presentation"), Description("Defines the caption for generated grid presentation control")> _
        Public Property GridColumnCaption() As String
            Get
                Dim lKey As String = "GridColumnCaption"
                Me.ValidatePropertyInstance(lKey, Me.Name)

                Return _MetaColumn.Properties(lKey).Value
            End Get
            Set(ByVal value As String)
                Dim lKey As String = "GridColumnCaption"
                Me.ValidatePropertyInstance(lKey, Me.Name)

                _MetaColumn.Properties(lKey).Value = value
                Me.SaveData()
            End Set
        End Property

        <System.ComponentModel.DisplayName("Grid Column Width"), Category("UI Grid Presentation"), Description("Defines the width for the generated grid presentation control")> _
        Public Property GridColumnWidth() As Integer
            Get
                Dim lKey As String = "GridColumnWidth"
                Me.ValidatePropertyInstance(lKey, "80")

                Return _MetaColumn.Properties(lKey).Value
            End Get
            Set(ByVal value As Integer)
                Dim lKey As String = "GridColumnWidth"
                Me.ValidatePropertyInstance(lKey, "80")

                _MetaColumn.Properties(lKey).Value = value
                Me.SaveData()
            End Set
        End Property

        <System.ComponentModel.DisplayName("Property Name"), Category("Metadata"), Description("The name of the generated property")> _
        Public Property PropertyName() As String
            Get
                Dim lKey As String = "PropertyName"
                Me.ValidatePropertyInstance(lKey, Me.GetPropertyName)

                Return _MetaColumn.Properties(lKey).Value
            End Get
            Set(ByVal value As String)
                Dim lKey As String = "PropertyName"
                Me.ValidatePropertyInstance(lKey, Me.GetPropertyName)

                _MetaColumn.Properties(lKey).Value = value
                Me.SaveData()
            End Set
        End Property


        <System.ComponentModel.DisplayName("Is Description"), Category("Metadata"), Description("Whether or not this column describes an entity")> _
        Public Property IsDescription() As Boolean
            Get
                Dim lKey As String = "IsDescription"
                Me.ValidateIsDescriptionInstance(lKey)

                Return Convert.ToBoolean(_MetaColumn.Properties(lKey).Value)
            End Get
            Set(ByVal value As Boolean)
                Dim lKey As String = "IsDescription"
                Me.ValidateIsDescriptionInstance(lKey)

                _MetaColumn.Properties(lKey).Value = value.ToString
                Me.SaveData()
            End Set
        End Property

        <System.ComponentModel.DisplayName("Include in Serialization"), Category("Code Generation"), Description("Whether or not this column must be qualified as serializable")> _
        Public Property IncludeInSerialization() As Boolean
            Get
                Dim lKey As String = "IncludeInSerialization"
                Me.ValidatePropertyInstance(lKey, True)

                Return Convert.ToBoolean(_MetaColumn.Properties(lKey).Value)
            End Get
            Set(ByVal value As Boolean)
                Dim lKey As String = "IncludeInSerialization"
                Me.ValidatePropertyInstance(lKey, True)

                _MetaColumn.Properties(lKey).Value = value.ToString
                Me.SaveData()
            End Set
        End Property

        <System.ComponentModel.DisplayName("Code Documentation"), Category("Code Generation"), Description("Summary for code documentation")> _
        Public Property CodeDocumentation() As String
            Get
                Dim lKey As String = "CodeDocumentation"
                Me.ValidatePropertyInstance(lKey, Me.GetPropertyName)

                Return _MetaColumn.Properties(lKey).Value
            End Get
            Set(ByVal value As String)
                Dim lKey As String = "CodeDocumentation"
                Me.ValidatePropertyInstance(lKey, Me.GetPropertyName)

                _MetaColumn.Properties(lKey).Value = value
                Me.SaveData()
            End Set
        End Property



        <System.ComponentModel.DisplayName("Is Nullable"), Category("Metadata"), Description("Whether or not this property is nullable")> _
        Public ReadOnly Property IsNullable() As Boolean
            Get
                Return _MetaColumn.IsNullable
            End Get
        End Property

        Private _Table As MetaDiscovery.Table
        <Browsable(False)> _
        Public ReadOnly Property Table() As MetaDiscovery.Table
            Get
                Return _Table
            End Get
        End Property

        Private _View As MetaDiscovery.View
        <Browsable(False)> _
        Public ReadOnly Property View() As MetaDiscovery.View
            Get
                Return _View
            End Get
        End Property


        <System.ComponentModel.DisplayName("Visual Basic Code Generated Variable Type"), Category("Metadata"), Description("The type of the property in visual basic")> _
        Public ReadOnly Property NETVariableType() As String
            Get
                Return _MetaColumn.LanguageType
            End Get
        End Property

        <System.ComponentModel.DisplayName("Maximum Length"), Category("Metadata"), Description("The maximum length of this property value")> _
        Public ReadOnly Property MaxLength() As Integer
            Get
                Return _MetaColumn.CharacterMaxLength
            End Get
        End Property

        <System.ComponentModel.DisplayName("Autoincrement"), Category("Metadata"), Description("Whether or not this column property is autogenerated")> _
        Public ReadOnly Property AutoIncrement() As Boolean
            Get
                Return _MetaColumn.IsAutoKey
            End Get
        End Property

        <System.ComponentModel.DisplayName("Is Primary Key"), Category("Metadata"), Description("Whether or not this column is a primary key")> _
        Public ReadOnly Property IsPrimaryKey() As Boolean
            Get
                Return _MetaColumn.IsInPrimaryKey
            End Get
        End Property

        <System.ComponentModel.DisplayName("SQL Data Type"), Category("Metadata"), Description("The database type")> _
        Public ReadOnly Property SQLType() As String
            Get
                Return _MetaColumn.DataTypeName
            End Get
        End Property

        <System.ComponentModel.DisplayName("SQL Parameter Accestype"), Category("Metadata"), Description("The type of the parameter for CRUD operations")> _
        Public ReadOnly Property NativeParameterType() As String
            Get
                Return _MetaColumn.DataTypeNameComplete.ToUpper
            End Get
        End Property

#End Region

        Private Function GetPropertyName() As String
            Dim lReturnValue As String = Me.Name

            lReturnValue = lReturnValue.Replace(" ", "").Replace("_", "")
            lReturnValue = Common.GetValidName(lReturnValue)

            Return lReturnValue
        End Function

        Protected Sub ValidatePropertyInstance(ByVal pKey As String, ByVal pDefaultValue As String)
            If _MetaColumn.Properties(pKey) Is Nothing Then
                _MetaColumn.Properties.AddKeyValue(pKey, pDefaultValue)
                Me.SaveData()
            End If
        End Sub

        Protected Sub ValidateIsDescriptionInstance(ByVal pKey As String)
            If _MetaColumn.Properties(pKey) Is Nothing Then
                _MetaColumn.Properties.AddKeyValue(pKey, CheckIsDescription)
                Me.SaveData()
            End If
        End Sub

        Public Function CheckIsDescription() As Boolean
            Dim lReturnValue As Boolean = False
            If (Me.NETVariableType = "String") Then
                lReturnValue = True
            End If

            Return lReturnValue
        End Function


        Private Sub SaveData()
            If (_MetaColumn.Table Is Nothing) Then
                _MetaColumn.View.Database.Root.SaveUserMetaData()
            Else
                _MetaColumn.Table.Database.Root.SaveUserMetaData()
            End If
        End Sub

        Public Sub New(ByVal pColumn As MyMeta.IColumn, ByVal pTable As MetaDiscovery.Table)
            Me._MetaColumn = pColumn
            Me._Table = pTable
        End Sub

        Public Sub New(ByVal pColumn As MyMeta.IColumn, ByVal pView As MetaDiscovery.View)
            Me._MetaColumn = pColumn
            Me._View = pView
        End Sub

    End Class
End Namespace
