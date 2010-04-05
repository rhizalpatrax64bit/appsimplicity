Namespace MetaDiscovery
    Public Class View
        Inherits DBEntity

#Region "Exposed Properties"
        <System.ComponentModel.DisplayName("Name"), Category("Metadata"), Description("Gets the name for this view")> _
        ReadOnly Property Name() As String
            Get
                Return Me._UnderlyingMeta.Name
            End Get
        End Property

        <System.ComponentModel.DisplayName("Code Documentation"), Category("Code Generation"), Description("Code documentation")> _
        Public Property CodeDocumentation() As String
            Get
                Dim lKey As String = "SummaryDocumentation"
                Me.ValidatePropertyInstance(lKey, String.Format("Summary description for {0} class", Me.ClassName))

                Return _UnderlyingMeta.Properties(lKey).Value
            End Get
            Set(ByVal value As String)
                Dim lKey As String = "SummaryDocumentation"
                Me.ValidatePropertyInstance(lKey, String.Format("Summary description for {0} class", Me.ClassName))

                _UnderlyingMeta.Properties(lKey).Value = value
                Me.SaveData()
            End Set
        End Property

        <System.ComponentModel.DisplayName("Plural Class Name"), Category("Code Generation"), Description("Plural Class Name")> _
        Public Property PluralClassName() As String
            Get
                Dim lKey As String = "PluralClassName"
                Me.ValidatePropertyInstance(lKey, Common.GetPluralClassName(Me.Name))

                Return _UnderlyingMeta.Properties(lKey).Value
            End Get
            Set(ByVal value As String)
                Dim lKey As String = "PluralClassName"
                Me.ValidatePropertyInstance(lKey, Common.GetPluralClassName(Me.ClassName))

                _UnderlyingMeta.Properties(lKey).Value = value
                Me.SaveData()
            End Set
        End Property

        <System.ComponentModel.DisplayName("Class Name"), Category("Metadata"), Description("The name of the generated class")> _
        Public Property ClassName() As String
            Get
                Dim lKey As String = "ClassName"
                Me.ValidatePropertyInstance(lKey, Common.GetClassName(Me.Name))

                Return _UnderlyingMeta.Properties(lKey).Value
            End Get
            Set(ByVal value As String)
                Dim lKey As String = "ClassName"
                Me.ValidatePropertyInstance(lKey, Common.GetClassName(Me.Name))

                _UnderlyingMeta.Properties(lKey).Value = value
                Me.SaveData()
            End Set
        End Property

        <System.ComponentModel.DisplayName("Include this object for code generation"), Category("Code Generation"), Description("Wether or not this object must be included in generation list")> _
       Public Property IncludeInGeneration() As Boolean
            Get
                Dim lKey As String = "IncludeInGeneration"
                Me.ValidatePropertyInstance(lKey, True)

                Return _UnderlyingMeta.Properties(lKey).Value
            End Get
            Set(ByVal value As Boolean)
                Dim lKey As String = "IncludeInGeneration"
                Me.ValidatePropertyInstance(lKey, True)

                _UnderlyingMeta.Properties(lKey).Value = value
                Me.SaveData()
            End Set
        End Property
        
        <Browsable(False)> _
        Public ReadOnly Property ViewId() As String
            Get
                Return String.Format("{0}.{1}", Me.Provider.DatabaseName.ToLower, Me.Name.ToLower)
            End Get
        End Property

        Private _Columns As New List(Of MetaDiscovery.Column)
        <Browsable(False)> _
        Public ReadOnly Property Columns() As List(Of MetaDiscovery.Column)
            Get
                Return _Columns
            End Get
        End Property

        Private _PKColumn As MetaDiscovery.Column
        <Browsable(False)> _
        Public ReadOnly Property PKColumn() As MetaDiscovery.Column
            Get
                If (_PKColumn Is Nothing) Then
                    _PKColumn = Me.GetPKColumn()
                End If
                Return _PKColumn
            End Get
        End Property
#End Region

        Private _HasManyRelations As New List(Of MetaRelation)
        <Browsable(False)> _
        Public ReadOnly Property HasManyRelations() As List(Of MetaRelation)
            Get
                Return _HasManyRelations
            End Get
        End Property

        Private _BelongsToRelations As New List(Of MetaRelation)
        <Browsable(False)> _
        Public ReadOnly Property BelongsToRelations() As List(Of MetaRelation)
            Get
                Return _BelongsToRelations
            End Get
        End Property

        Protected Sub ValidatePropertyInstance(ByVal pKey As String, ByVal pDefaultValue As String)
            If _UnderlyingMeta.Properties(pKey) Is Nothing Then
                _UnderlyingMeta.Properties.AddKeyValue(pKey, pDefaultValue)
                Me.SaveData()
            End If
        End Sub

        Private Function GetPKColumn() As MetaDiscovery.Column
            Dim lReturnValue As MetaDiscovery.Column = Nothing
            For Each lColumn As MetaDiscovery.Column In Me.Columns
                If (lColumn.IsPrimaryKey) Then
                    lReturnValue = lColumn
                    Exit For
                End If
            Next
            Return lReturnValue
        End Function

        Private Sub SaveData()
            _UnderlyingMeta.Database.Root.SaveUserMetaData()
        End Sub

        Private _UnderlyingMeta As MyMeta.View

        Public Sub FillColumns()
            For Each lColumn As MyMeta.Column In Me._UnderlyingMeta.Columns
                Dim lItemColumn As New MetaDiscovery.Column(lColumn, Me)
                Me.Columns.Add(lItemColumn)
            Next
        End Sub

        Public Function FindColumnInstance(ByVal pColumnName As String) As MetaDiscovery.Column
            Dim lReturnValue As MetaDiscovery.Column = Nothing

            For Each lColumn As MetaDiscovery.Column In Me.Columns
                If (lColumn.Name = pColumnName) Then
                    lReturnValue = lColumn
                    Exit For
                End If
            Next

            Return lReturnValue
        End Function

        Public Sub New(ByVal pUnderlyingView As MyMeta.View, ByVal pProvider As MetaDiscovery.Provider)
            MyBase.New(pProvider)
            _UnderlyingMeta = pUnderlyingView

            Me.FillColumns()
        End Sub
    End Class
End Namespace
