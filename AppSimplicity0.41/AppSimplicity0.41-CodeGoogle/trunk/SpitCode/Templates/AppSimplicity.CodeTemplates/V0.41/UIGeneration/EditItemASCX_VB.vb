Imports System.Text
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

    Public Function GetFillFormCode(ByVal pTable As MetaDiscovery.Table) As String
        Dim lSB As New StringBuilder

        lSB.AppendLine()

        For Each lColumn As MetaDiscovery.Column In pTable.Columns
            Dim lInclude As Boolean = True

            If (lColumn.IsPrimaryKey) Then
                If (lColumn.AutoIncrement) Then
                    lInclude = False
                End If
            Else
                If Not (lColumn.AuditMode = MetaDiscovery.AuditModes.NotAuditable) Then
                    lInclude = False
                Else
                    If lColumn.IsPrimaryKey Then
                        If (lColumn.AutoIncrement) Then
                            lInclude = False
                        End If
                    End If
                End If
            End If

            If (lInclude) Then
                lSB.AppendFormat("        Me.{0}.Value = pItem.{1}" & vbCrLf, lColumn.UIControlID, lColumn.PropertyName)
            End If
        Next

        Return lSB.ToString
    End Function

    Private Function GetFillDDLCombos(ByVal pTable As MetaDiscovery.Table) As String
        Dim lSB As New StringBuilder

        lSB.AppendLine()

        For Each lColumn As MetaDiscovery.Column In pTable.Columns

            If (lColumn.HasBelongsToReference) Then
                If (lColumn.UIControlType = MetaDiscovery.UIControlType.ListOfValues) Then
                    Dim lRelation As MetaDiscovery.MetaRelation = lColumn.GetForeignRelation()

                    lSB.AppendFormat("        Me.{0}.Fill({1}.{2}.FetchAll)" & vbCrLf, lColumn.UIControlID, pTable.Provider.GeneratedNamespace, lRelation.ForeignEntity.PluralClassName)
                End If
            End If
        Next

        Return lSB.ToString
    End Function

    Public Function GetRunValidationsCode(ByVal pTable As MetaDiscovery.Table) As String
        Dim lSB As New StringBuilder

        lSB.AppendLine()

        For Each lColumn As MetaDiscovery.Column In pTable.Columns
            Dim lInclude As Boolean = True

            If Not (lColumn.AuditMode = MetaDiscovery.AuditModes.NotAuditable) Then
                lInclude = False
            Else
                If lColumn.IsPrimaryKey Then
                    If (lColumn.AutoIncrement) Then
                        lInclude = False
                    End If
                End If
            End If

            If (lInclude) Then
                lSB.AppendFormat(My.Resources.UI_CodeGenStrings.RunValidationCodeBlock & vbCrLf & vbCrLf, lColumn.UIControlID)
            End If
        Next

        Return lSB.ToString
    End Function


    Public Function GetResetControlsCode(ByVal pTable As MetaDiscovery.Table) As String
        Dim lSB As New StringBuilder

        lSB.AppendLine()

        For Each lColumn As MetaDiscovery.Column In pTable.Columns
            Dim lInclude As Boolean = True

            If Not (lColumn.AuditMode = MetaDiscovery.AuditModes.NotAuditable) Then
                lInclude = False
            Else
                If lColumn.IsPrimaryKey Then
                    If (lColumn.AutoIncrement) Then
                        lInclude = False
                    End If
                End If
            End If

            If (lInclude) Then
                lSB.AppendFormat("        Me.{0}.ResetControl()" & vbCrLf, lColumn.UIControlID)
            End If
        Next

        Return lSB.ToString
    End Function

    Public Function GetFillPropertiesCode(ByVal pTable As MetaDiscovery.Table) As String
        Dim lSB As New StringBuilder

        lSB.AppendLine()

        For Each lColumn As MetaDiscovery.Column In pTable.Columns
            Dim lInclude As Boolean = True

            If Not (lColumn.AuditMode = MetaDiscovery.AuditModes.NotAuditable) Then
                lInclude = False
            Else
                If lColumn.IsPrimaryKey Then
                    If (lColumn.AutoIncrement) Then
                        lInclude = False
                    End If
                End If
            End If

            If (lInclude) Then

                lSB.AppendFormat("        pItem.{0} = Me.{1}.Value" & vbCrLf, lColumn.PropertyName, lColumn.UIControlID)

            End If
        Next

        Return lSB.ToString
    End Function

    Public Overrides Sub ProduceCode(ByRef Output As System.IO.StreamWriter)
      
        Dim lOutput As String = My.Resources.UI_CodeGenStrings.EditItem_ASCvb

        lOutput = lOutput.Replace("[$GeneratedNamespace]", Me.CurrentTable.Provider.GeneratedNamespace)
        lOutput = lOutput.Replace("[$ClassName]", Me.CurrentTable.ClassName)
        lOutput = lOutput.Replace("[$PKPropertyName]", Me.CurrentTable.PKColumn.PropertyName)
        lOutput = lOutput.Replace("[$PluralClassName]", Me.CurrentTable.PluralClassName)
        lOutput = lOutput.Replace("[$FillForm]", Me.GetFillFormCode(Me.CurrentTable))
        lOutput = lOutput.Replace("[$FillDDls]", Me.GetFillDDLCombos(Me.CurrentTable))
        lOutput = lOutput.Replace("[$ResetControls]", Me.GetResetControlsCode(Me.CurrentTable))
        lOutput = lOutput.Replace("[$RunValidations]", Me.GetRunValidationsCode(Me.CurrentTable))
        lOutput = lOutput.Replace("[$FillProperties]", Me.GetFillPropertiesCode(Me.CurrentTable))

        Output.Write(lOutput)
    End Sub

    Public Overrides Function ValidateCodeFile() As Boolean
        If (Me.CurrentTable.ClassName.ToLower.EndsWith("map")) Then
            Return False
        End If
        Return True
    End Function
End Class
