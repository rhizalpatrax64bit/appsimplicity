Imports SpitCodeEngine

Public Class ToolBarEditItemASCX
    Inherits CodeGeneration.CodeTemplate

    Public Overrides Sub Initialize(ByVal pSettings As SpitCodeEngine.CodeGeneration.TemplateSettings)
        pSettings.Description = "v0.41 - List Item Manager Component - ASCX"
        pSettings.TemplateType = CodeGeneration.CodeTemplateType.TableTemplate
        pSettings.OverWriteFiles = True
    End Sub

    Public Overrides Function OutputFileDirectory() As String
        Return String.Format("App_Code\{0}\UI\CustomControls\{0}\{1}", Me.CurrentProvider.GeneratedNamespace, Me.CurrentTable.PluralClassName)
    End Function

    Public Overrides Function OutputFileName() As String
        If (Me.EntityType = CodeGeneration.EntityTypes.Table) Then
            Return String.Format("ListManager_{0}.ascx", Me.CurrentTable.PluralClassName)
        End If

        If (Me.EntityType = CodeGeneration.EntityTypes.View) Then
            Return String.Format("ListManager_{0}.ascx", Me.CurrentView.PluralClassName)
        End If

        Return "undefined.txt"
    End Function

    Public Overrides Sub ProduceCode(ByRef Output As System.IO.StreamWriter)
        Dim lASCX As String = My.Resources.UI_CodeGenStrings.ListManager_ASCX

        lASCX = lASCX.Replace("[$ClassName]", Me.CurrentTable.ClassName)
        lASCX = lASCX.Replace("[$GeneratedNamespace]", Me.CurrentTable.Provider.GeneratedNamespace)
        lASCX = lASCX.Replace("[$PluralClassName]", Me.CurrentTable.PluralClassName)
        lASCX = lASCX.Replace("[$TableName]", Me.CurrentTable.Name)
        lASCX = lASCX.Replace("[$PKPropertyName]", Me.CurrentTable.PKColumn.PropertyName)
        lASCX = lASCX.Replace("[$PKColumnName]", Me.CurrentTable.PKColumn.Name)

        Output.Write(lASCX)
    End Sub

    Public Overrides Function ValidateCodeFile() As Boolean
        If (Me.CurrentTable.ClassName.ToLower.EndsWith("map")) Then
            Return False
        End If
        Return True
    End Function

End Class