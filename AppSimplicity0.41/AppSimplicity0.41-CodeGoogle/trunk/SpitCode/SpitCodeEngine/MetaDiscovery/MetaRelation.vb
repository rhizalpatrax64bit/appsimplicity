Namespace MetaDiscovery
    Public Enum RelationType
        BelongsTo
        HasMany
    End Enum

    Public Class MetaRelation
        Private _CurrentTable As MetaDiscovery.Table
        Private _ForeignKey As MyMeta.ForeignKey
        Private _Relation As RelationType

        <System.ComponentModel.DisplayName("Name of the datasource provider"), Category("Metadata"), Description("The name of the data source provider")> _
        Public ReadOnly Property Provider() As String
            Get
                Return Me._CurrentTable.Provider.Name
            End Get
        End Property

        <System.ComponentModel.DisplayName("Child column"), Category("Metadata"), Description("The column name that refers to foreign object")> _
        Public ReadOnly Property RelatedColumn() As String
            Get
                Select Case (Me._Relation)
                    Case RelationType.BelongsTo
                        Return Me.ExternalReferenceColumn.Name
                    Case RelationType.HasMany
                        Return Me._ForeignColumn.Name
                End Select
                Return Me._ExternalReferenceColumn.Name
            End Get
        End Property

        <System.ComponentModel.DisplayName("Belongs to Table"), Category("Metadata"), Description("The foreign related table")> _
        Public ReadOnly Property BelongsTo() As String
            Get
                Select Case (Me._Relation)
                    Case RelationType.BelongsTo
                        Return Me._ForeignEntity.Name
                    Case RelationType.HasMany
                        Return Me._CurrentTable.Name
                End Select

                Return Me._ForeignEntity.Name
            End Get
        End Property


        ''' <summary>
        ''' Determina el tipo de la relación con la entidad foránea
        ''' </summary>        
        <Browsable(False)> _
        Public ReadOnly Property Relation() As RelationType
            Get
                Return _Relation
            End Get
        End Property

        Private _ForeignEntity As MetaDiscovery.Table
        <Browsable(False)> _
        Public ReadOnly Property ForeignEntity() As MetaDiscovery.Table
            Get
                Return _ForeignEntity
            End Get
        End Property

        Private _ForeignColumn As MetaDiscovery.Column
        <Browsable(False)> _
        Public ReadOnly Property ForeignColumn() As MetaDiscovery.Column
            Get
                Return _ForeignColumn
            End Get
        End Property

        Private _ExternalReferenceColumn As MetaDiscovery.Column
        <Browsable(False)> _
        Public ReadOnly Property ExternalReferenceColumn() As MetaDiscovery.Column
            Get
                Return _ExternalReferenceColumn
            End Get
        End Property

        Public Sub New(ByVal pCurrentTable As MetaDiscovery.Table, ByVal pForeignKey As MyMeta.ForeignKey)
            _CurrentTable = pCurrentTable
            _ForeignKey = pForeignKey

            Me.Initialize()
        End Sub

        Private Function FindTableInstance(ByVal pTableName) As MetaDiscovery.Table
            Dim lResultValue As MetaDiscovery.Table = Nothing
            For Each lTable As MetaDiscovery.Table In Me._CurrentTable.Provider.Tables
                'la tabla que sea diferente de la actual
                If (_CurrentTable.Name <> lTable.Name) Then
                    If (pTableName = lTable.Name) Then
                        lResultValue = lTable
                        Exit For
                    End If
                End If
            Next
            Return lResultValue
        End Function

        Private Sub BuildBelongsToRelation()
            Me._ForeignEntity = Me.FindTableInstance(Me._ForeignKey.PrimaryTable.Name)
            Me._ForeignColumn = Me._ForeignEntity.FindColumnInstance(CType(Me._ForeignKey.PrimaryColumns(0), MyMeta.Column).Name)
            Me._ExternalReferenceColumn = Me._CurrentTable.FindColumnInstance(CType(Me._ForeignKey.ForeignColumns(0), MyMeta.Column).Name)
        End Sub

        Private Sub BuildHasManyRelation()
            Me._ForeignEntity = Me.FindTableInstance(Me._ForeignKey.ForeignTable.Name)
            Me._ForeignColumn = Me._ForeignEntity.FindColumnInstance(CType(Me._ForeignKey.ForeignColumns(0), MyMeta.Column).Name)
            Me._ExternalReferenceColumn = Me._CurrentTable.FindColumnInstance(CType(Me._ForeignKey.PrimaryColumns(0), MyMeta.Column).Name)
        End Sub

        Private Sub Initialize()
            If (_ForeignKey.PrimaryTable.Name = _CurrentTable.Name) Then
                Me._Relation = RelationType.HasMany
                Me.BuildHasManyRelation()

                Console.WriteLine(String.Format("Found that [{0}] has many [{1}]", Me._CurrentTable.ClassName, Me._ForeignEntity.Name))
            Else
                Me._Relation = RelationType.BelongsTo
                Me.BuildBelongsToRelation()

                Console.WriteLine(String.Format("Found that [{0}] belongs to one [{1}]", Me._CurrentTable.ClassName, Me._ForeignEntity.ClassName))
            End If
        End Sub
    End Class
End Namespace
