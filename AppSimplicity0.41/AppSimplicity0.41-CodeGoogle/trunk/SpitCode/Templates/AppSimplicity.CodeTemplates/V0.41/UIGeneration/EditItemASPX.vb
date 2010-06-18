Imports SpitCodeEngine

Public Class EditItemASPX
    Inherits CodeGeneration.CodeTemplate

    Public Overrides Sub Initialize(ByVal pSettings As SpitCodeEngine.CodeGeneration.TemplateSettings)
        pSettings.Description = "v0.41 - Edit Item ASPX"
        pSettings.TemplateType = CodeGeneration.CodeTemplateType.TableTemplate
        pSettings.OverWriteFiles = True
    End Sub

    Public Overrides Function OutputFileDirectory() As String
        Return String.Format("App_Code\{0}\UI\Application\{0}\{1}", Me.CurrentProvider.GeneratedNamespace, Me.CurrentTable.PluralClassName)
    End Function

    Public Overrides Function OutputFileName() As String
        If (Me.EntityType = CodeGeneration.EntityTypes.Table) Then
            Return String.Format("Edit{0}.aspx", Me.CurrentTable.ClassName)
        End If

        If (Me.EntityType = CodeGeneration.EntityTypes.View) Then
            Return String.Format("Edit{0}.aspx", Me.CurrentView.ClassName)
        End If

        Return "undefined.txt"
    End Function

    Public Overrides Sub ProduceCode(ByRef Output As System.IO.StreamWriter)
        Dim lOutput As String = My.Resources.UI_CodeGenStrings.EditItem_ASPX

        lOutput = lOutput.Replace("[$ClassName]", Me.CurrentTable.ClassName)
        lOutput = lOutput.Replace("[$PluralClassName]", Me.CurrentTable.PluralClassName)
        lOutput = lOutput.Replace("[$GeneratedNamespace]", Me.CurrentTable.Provider.GeneratedNamespace)
        lOutput = lOutput.Replace("[$PKPropertyName]", Me.CurrentTable.PKColumn.PropertyName)

        Output.Write(lOutput)
    End Sub

    Public Overrides Function ValidateCodeFile() As Boolean
        If (Me.CurrentTable.ClassName.ToLower.EndsWith("map")) Then
            Return False
        End If
        Return True
    End Function

End Class