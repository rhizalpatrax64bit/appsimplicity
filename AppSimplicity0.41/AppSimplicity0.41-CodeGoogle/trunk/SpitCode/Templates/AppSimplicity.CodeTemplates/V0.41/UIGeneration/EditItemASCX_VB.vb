﻿Imports System.Text
Imports SpitCodeEngine

Public Class EditItemASCX_VB
    Inherits CodeGeneration.CodeTemplate

    Public Overrides Sub Initialize(ByVal pSettings As SpitCodeEngine.CodeGeneration.TemplateSettings)
        pSettings.Description = "v0.41 - Edit Item Web User Custom Control - ASCX (Code Behind)"
        pSettings.TemplateType = CodeGeneration.CodeTemplateType.TableTemplate
        pSettings.OverWriteFiles = True
    End Sub

    Public Overrides Function OutputFileDirectory() As String
        Return String.Format("App_Code\{0}\UI\CustomControls\{0}\{1}", Me.CurrentProvider.GeneratedNamespace, Me.CurrentTable.PluralClassName)
    End Function

    Public Overrides Function OutputFileName() As String
        If (Me.EntityType = CodeGeneration.EntityTypes.Table) Then
            Return String.Format("Edit_{0}.ascx.vb", Me.CurrentTable.ClassName)
        End If

        If (Me.EntityType = CodeGeneration.EntityTypes.View) Then
            Return String.Format("Edit_{0}.ascx.vb", Me.CurrentView.ClassName)
        End If

        Return "undefined.txt"
    End Function

    Public Overrides Sub ProduceCode(ByRef Output As System.IO.StreamWriter)
        Output.Write(My.Resources.UI_CodeGenStrings.EditItem_ASCvb, Me.CurrentTable.Provider.GeneratedNamespace, Me.CurrentTable.ClassName, "")
    End Sub
End Class
