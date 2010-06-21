Imports SpitCodeEngine
Imports System.Text

Public Class ListManagerASCXVB
    Inherits CodeGeneration.CodeTemplate

    Public Overrides Sub Initialize(ByVal pSettings As SpitCodeEngine.CodeGeneration.TemplateSettings)
        pSettings.Description = "v0.41 - List Item Manager Component - ASCX (Code Behind)"
        pSettings.TemplateType = CodeGeneration.CodeTemplateType.TableTemplate
        pSettings.OverWriteFiles = True
    End Sub

    Public Overrides Function OutputFileDirectory() As String
        Return String.Format("App_Code\{0}\UI\CustomControls\{0}\{1}", Me.CurrentProvider.GeneratedNamespace, Me.CurrentTable.PluralClassName)
    End Function

    Public Overrides Function OutputFileName() As String
        If (Me.EntityType = CodeGeneration.EntityTypes.Table) Then
            Return String.Format("ListManager_{0}.ascx.vb", Me.CurrentTable.PluralClassName)
        End If

        If (Me.EntityType = CodeGeneration.EntityTypes.View) Then
            Return String.Format("ListManager_{0}.ascx.vb", Me.CurrentView.PluralClassName)
        End If

        Return "undefined.txt"
    End Function

    Private Function GetJoinList(ByVal pTable As MetaDiscovery.Table)
        Dim lSB As New StringBuilder

        For Each lMetaRelation As MetaDiscovery.MetaRelation In pTable.BelongsToRelations

            Dim lcode As String = My.Resources.UI_CodeGenStrings.FKJoinQueryCode

            lcode = lcode.Replace("[$FKPluralClassName]", lMetaRelation.ForeignEntity.PluralClassName)
            lcode = lcode.Replace("[$GeneratedNamespace]", pTable.Provider.GeneratedNamespace)
            lcode = lcode.Replace("[$FKPKPropertyName]", lMetaRelation.ForeignEntity.PKColumn.PropertyName)

            Dim lColumn As MetaDiscovery.Column = lMetaRelation.ForeignEntity.GetDescriptionColumn

            lcode = lcode.Replace("[$FKDescriptionPropertyName]", lColumn.PropertyName)

            lSB.Append(lcode)
            lSB.AppendLine(vbCrLf)

        Next

        Return lSB.ToString
    End Function

    Public Overrides Sub ProduceCode(ByRef Output As System.IO.StreamWriter)
        Dim lASCX As String = My.Resources.UI_CodeGenStrings.ListManagerASCXvb

        lASCX = lASCX.Replace("[$ClassName]", Me.CurrentTable.ClassName)
        lASCX = lASCX.Replace("[$GeneratedNamespace]", Me.CurrentTable.Provider.GeneratedNamespace)
        lASCX = lASCX.Replace("[$PluralClassName]", Me.CurrentTable.PluralClassName)
        lASCX = lASCX.Replace("[$TableName]", Me.CurrentTable.Name)
        lASCX = lASCX.Replace("[$PKPropertyName]", Me.CurrentTable.PKColumn.PropertyName)
        lASCX = lASCX.Replace("[$PKColumnName]", Me.CurrentTable.PKColumn.Name)

        Dim lDescription As MetaDiscovery.Column = Me.CurrentTable.GetDescriptionColumn

        lASCX = lASCX.Replace("[$DescriptionColumnPropertyName]", lDescription.PropertyName)
        lASCX = lASCX.Replace("[$DescriptionColumnUIWidth]", lDescription.UIControlWidth)
        lASCX = lASCX.Replace("[$DescriptionColumnUILabel]", lDescription.FieldLabel)

        lASCX = lASCX.Replace("[$JoinList]", Me.GetJoinList(Me.CurrentTable))

        Output.Write(lASCX)
    End Sub

    Public Overrides Function ValidateCodeFile() As Boolean
        If (Me.CurrentTable.ClassName.ToLower.EndsWith("map")) Then
            Return False
        End If
        Return True
    End Function

End Class