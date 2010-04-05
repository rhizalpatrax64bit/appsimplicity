Imports System.Text
Imports SpitCodeEngine

Public Class DataContextGenerator
    Inherits CodeGeneration.CodeTemplate

    Public Overrides Sub Initialize(ByVal pSettings As SpitCodeEngine.CodeGeneration.TemplateSettings)
        pSettings.Description = "v0.41 - DataContext Generator"
        pSettings.TemplateType = CodeGeneration.CodeTemplateType.ProviderTemplate
        pSettings.OverWriteFiles = True
    End Sub

    Public Overrides Function OutputFileDirectory() As String
        Return String.Format("App_Code\{0}\Classes", Me.CurrentProvider.GeneratedNamespace)
    End Function

    Public Overrides Function OutputFileName() As String
        Return "DataContext.vb"
    End Function

    Private Function GetScope(ByVal pProvider As MetaDiscovery.Provider) As String

        Select Case (pProvider.DataServiceScope)
            Case MetaDiscovery.Provider.DataServiceScopeTypes._Friend
                Return "Friend"
            Case MetaDiscovery.Provider.DataServiceScopeTypes._Public
                Return "Public"
        End Select

        Return "Public"
    End Function

    Public Overrides Sub ProduceCode(ByRef Output As System.IO.StreamWriter)
        Output.Write(String.Format(My.Resources.ClassGeneratorStrings.DataContextGenerator, _
                                   Me.CurrentProvider.GeneratedNamespace, _
                                   Me.CurrentProvider.Name, _
                                   IIf(Me.CurrentProvider.UseSPs = True, "True", "False"), _
                                   Me.GetScope(Me.CurrentProvider)))
    End Sub
End Class
