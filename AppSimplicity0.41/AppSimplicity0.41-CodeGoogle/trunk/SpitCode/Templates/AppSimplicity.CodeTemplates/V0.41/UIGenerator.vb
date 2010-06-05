Imports System.Text
Imports SpitCodeEngine

Public Class UIGenerator
    Inherits CodeGeneration.CodeTemplate

    Public Overrides Sub Initialize(ByVal pSettings As SpitCodeEngine.CodeGeneration.TemplateSettings)

    End Sub

    Public Overrides Function OutputFileDirectory() As String
        Return String.Format("App_Code\{0}\UI\Application\{0}\{1}", Me.CurrentProvider.GeneratedNamespace, Me.CurrentTable.PluralClassName)
    End Function

    Public Overrides Function OutputFileName() As String

    End Function

    Public Overrides Sub ProduceCode(ByRef Output As System.IO.StreamWriter)

    End Sub
End Class
