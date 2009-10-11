Namespace ActiveRecord
    Public MustInherit Class SchemaFactory

        Private _Schemas As Dictionary(Of String, Schema)

        Public ReadOnly Property Schemas() As Dictionary(Of String, Schema)
            Get
                If (_Schemas Is Nothing) Then
                    _Schemas = New Dictionary(Of String, Schema)
                End If
                Return _Schemas
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal pSchemaName As String) As Schema
            Get
                Dim lSchema As Schema

                If (Me.Schemas.ContainsKey(pSchemaName)) Then
                    lSchema = Me.Schemas(pSchemaName)
                Else
                    lSchema = Me.FetchSchemaByName(pSchemaName)

                    If Not (lSchema Is Nothing) Then
                        Me.Schemas(pSchemaName) = lSchema
                    End If
                End If

                Return lSchema
            End Get
        End Property

        Private _DataService As DataAccess.DataService
        Public ReadOnly Property DataService() As DataAccess.DataService
            Get
                Return _DataService
            End Get
        End Property

        Public Sub New(ByVal pDataService As DataAccess.DataService)
            Me._DataService = pDataService
        End Sub

        Public MustOverride Function FetchSchemaByName(ByVal pSchemaName As String) As Schema
    End Class
End Namespace

