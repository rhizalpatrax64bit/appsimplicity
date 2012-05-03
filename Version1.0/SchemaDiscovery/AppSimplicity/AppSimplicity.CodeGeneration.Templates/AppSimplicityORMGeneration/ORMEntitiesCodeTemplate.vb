Imports AppSimplicity.SchemaDiscovery

Namespace AppSimplicityORM
    Public Class ORMEntitiesCodeTemplate
        Inherits AppSimplicity.CodeGeneration.Engine.CodeGenerationTemplate(Of Entities.Table)

        Public Overrides Function GetOutputFileName(pEntity As SchemaDiscovery.Entities.Table) As Object
            Return String.Format("{0}\Generated\{1}.vb", pEntity.DataSource.GeneratedNamespace, pEntity.ClassName)
        End Function

        Public Overrides ReadOnly Property OverwriteIfExists As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides Sub WriteCode(pEntity As SchemaDiscovery.Entities.Table, pOutput As System.IO.StreamWriter)
            pOutput.Write("some code")
        End Sub
    End Class
End Namespace

