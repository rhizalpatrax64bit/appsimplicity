Imports System.Text
Imports SpitCodeEngine

Public Class ExtendedDataContext
    Inherits CodeGeneration.CodeTemplate

    Public Overrides Sub Initialize(ByVal pSettings As SpitCodeEngine.CodeGeneration.TemplateSettings)
        pSettings.Description = "v0.41 - Extended DataContext Generator"
        pSettings.TemplateType = CodeGeneration.CodeTemplateType.ProviderTemplate
        pSettings.OverWriteFiles = False
    End Sub

    Public Overrides Function OutputFileDirectory() As String
        Return String.Format("App_Code\{0}\Extended", Me.CurrentProvider.GeneratedNamespace)
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
        Output.Write(String.Format(My.Resources.ClassGeneratorStrings.ExtendedDataContextGenerator, _
                                    Me.CurrentProvider.GeneratedNamespace, _
                                    Me.GetScope(Me.CurrentProvider), _
                                    Me.CurrentProvider.Name))
    End Sub
End Class
