Imports AppSimplicity.SchemaDiscovery

Namespace Engine
    Public Class CodeGenerator

        Private _TemplateConfigurationFile As String
        Private _Templates As List(Of TemplateDefinition)
        Public ReadOnly Property Templates() As List(Of TemplateDefinition)
            Get
                Return _Templates
            End Get
        End Property

        Private Function ParseTemplateConfigurationFile() As List(Of TemplateDefinition)
            Dim lReturnValue As New List(Of TemplateDefinition)

            If (System.IO.File.Exists(_TemplateConfigurationFile)) Then
                Dim lDS As New System.Data.DataSet

                lDS.ReadXml(_TemplateConfigurationFile)

                For Each lDR As DataRow In lDS.Tables(0).Rows
                    Dim lItem As TemplateDefinition = New TemplateDefinition()
                    lItem.Name = lDR.Item("Name").ToString()
                    lItem.Description = lDR.Item("Description").ToString()
                    lItem.ProviderType = lDR.Item("ProviderType").ToString()
                    lItem.TemplateSet = lDR.Item("TemplateSet").ToString()
                    lReturnValue.Add(lItem)
                Next
            End If

            Return lReturnValue
        End Function

        Public Function GetAllTemplateSets() As List(Of String)
            Dim lReturnValue As New List(Of String)

            For Each lTemplate As TemplateDefinition In Me.Templates
                If Not (lReturnValue.Contains(lTemplate.TemplateSet)) Then
                    lReturnValue.Add(lTemplate.TemplateSet)
                End If
            Next

            lReturnValue.Sort()
            Return lReturnValue
        End Function

        Private Function FilterTemplateSet(templateSet As String) As List(Of TemplateDefinition)
            Dim lReturnValue As New List(Of TemplateDefinition)

            For Each lTemplate As TemplateDefinition In Me.Templates
                If (lTemplate.TemplateSet.ToLower() = templateSet.ToLower) Then
                    lReturnValue.Add(lTemplate)
                End If
            Next

            Return lReturnValue
        End Function

        Private Sub RenderCode(project As Entities.Project, templates As List(Of TemplateDefinition))
            For Each lTemplate As TemplateDefinition In templates
                Dim lObject As Object = Activator.CreateInstance(Type.GetType(lTemplate.ProviderType))

                If (TypeOf (lObject) Is CodeGenerationTemplate(Of SchemaDiscovery.Entities.Project)) Then
                    CType(lObject, CodeGenerationTemplate(Of SchemaDiscovery.Entities.Project)).RunTemplate(project)
                End If

                For Each lDataSource As SchemaDiscovery.Entities.DataSource In project.DataSources
                    If (TypeOf (lObject) Is CodeGenerationTemplate(Of SchemaDiscovery.Entities.DataSource)) Then
                        CType(lObject, CodeGenerationTemplate(Of SchemaDiscovery.Entities.DataSource)).RunTemplate(lDataSource)
                    End If

                    If (TypeOf (lObject) Is CodeGenerationTemplate(Of SchemaDiscovery.Entities.Table)) Then
                        For Each lTable As SchemaDiscovery.Entities.Table In lDataSource.Tables
                            If (lTable.IncludeInCodeGeneration) Then
                                lTable.SetDataSource(lDataSource)
                                CType(lObject, CodeGenerationTemplate(Of SchemaDiscovery.Entities.Table)).RunTemplate(lTable)
                            End If
                        Next
                    End If

                    If (TypeOf (lObject) Is CodeGenerationTemplate(Of SchemaDiscovery.Entities.View)) Then
                        For Each lView As SchemaDiscovery.Entities.View In lDataSource.Views
                            If (lView.IncludeInCodeGeneration) Then
                                lView.SetDataSource(lDataSource)
                                CType(lObject, CodeGenerationTemplate(Of SchemaDiscovery.Entities.View)).RunTemplate(lView)
                            End If
                        Next
                    End If

                    If (TypeOf (lObject) Is CodeGenerationTemplate(Of SchemaDiscovery.Entities.StoredProcedure)) Then
                        For Each lSP As SchemaDiscovery.Entities.StoredProcedure In lDataSource.StoredProcedures
                            If (lSP.IncludeInCodeGeneration) Then
                                lSP.SetDataSource(lDataSource)
                                CType(lObject, CodeGenerationTemplate(Of SchemaDiscovery.Entities.StoredProcedure)).RunTemplate(lSP)
                            End If
                        Next
                    End If
                Next
            Next
        End Sub

        Public Sub SpitCode(ByVal project As SchemaDiscovery.Entities.Project, ByVal templateSet As String)
            Try
                If (templateSet Is Nothing Or templateSet = String.Empty) Then
                    Throw New Exception("Code generation template set was not specified. No code generation this time.")
                Else
                    Dim lTemplates As List(Of TemplateDefinition) = FilterTemplateSet(templateSet)
                    If (lTemplates.Count > 0) Then
                        RenderCode(project, lTemplates)
                    Else
                        Throw New Exception(String.Format("Unable to find code generation templates under the template set name [{0}]", templateSet))
                    End If
                End If
            Catch ex As Exception
                Console.WriteLine("Oops, something went wrong when trying to generate some code:")
                Console.WriteLine(ex.Message)
            End Try
        End Sub

        Public Sub New(ByVal pTemplateConfigurationFile As String)
            _TemplateConfigurationFile = pTemplateConfigurationFile
            _Templates = Me.ParseTemplateConfigurationFile()
        End Sub

    End Class
End Namespace
