Imports SpitCodeEngine
Imports System.Text

Public Class SelectDataProcedureGenerator
    Inherits CodeGeneration.CodeTemplate

    Public Overrides Sub Initialize(ByVal pSettings As SpitCodeEngine.CodeGeneration.TemplateSettings)
        pSettings.Description = "v0.41 - Custom Stored Procedure Generator"
        pSettings.TemplateType = CodeGeneration.CodeTemplateType.ProviderTemplate
        pSettings.OverWriteFiles = True
    End Sub

    Public Overrides Function OutputFileDirectory() As String
        Return String.Format("App_Code\{0}\SQL", Me.CurrentProvider.GeneratedNamespace)
    End Function

    Public Overrides Function OutputFileName() As String
        Return String.Format("{0}_SPs.sql", Me.CurrentProvider.GeneratedNamespace)
    End Function

    Private Function GetGeneratedSPs(ByVal pTable As MetaDiscovery.Table) As String
        Dim lReturnValue As String = String.Empty

        Dim lGenerate As Boolean = True

        If (pTable.Name.ToLower.EndsWith("map")) Then
            lGenerate = False
        End If

        If (lGenerate) Then
            Dim lProcedureName As String = String.Format("[dbo].[CPG_{0}_SP_SELECTBY_{1}]", pTable.Name.ToUpper, "")

            lReturnValue = My.Resources.SPSelectGenerationStrings.SPWrapper

            lReturnValue = lReturnValue.Replace("[$ProcedureName]", lProcedureName)
            lReturnValue = lReturnValue.Replace("[$ProjectName]", pTable.Provider.Project.Name)
            lReturnValue = lReturnValue.Replace("[$DatabaseName]", pTable.Provider.DatabaseName)
            lReturnValue = lReturnValue.Replace("[$IdentityName]", "Javier Pitalúa Cobos")

            lReturnValue = lReturnValue.Replace("[$GeneratedOn]", String.Format("{0}", Date.Now))

            lReturnValue = lReturnValue.Replace("[$SpCode]", " ")

            lReturnValue = lReturnValue & vbCrLf
        End If

        Return lReturnValue
    End Function

    Public Overrides Sub ProduceCode(ByRef Output As System.IO.StreamWriter)
        For Each lTable As MetaDiscovery.Table In Me.CurrentProvider.Tables
            Output.Write(Me.GetGeneratedSPs(lTable))
        Next
    End Sub
End Class
