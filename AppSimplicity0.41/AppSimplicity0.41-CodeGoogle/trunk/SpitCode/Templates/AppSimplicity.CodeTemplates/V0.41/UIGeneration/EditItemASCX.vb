﻿Imports System.Text
Imports SpitCodeEngine

Namespace UI
    Public Class EditItemASCX

        Inherits CodeGeneration.CodeTemplate

        Public Overrides Sub Initialize(ByVal pSettings As SpitCodeEngine.CodeGeneration.TemplateSettings)
            pSettings.Description = "v0.41 - Edit Item Web User Custom Control - ASCX"
            pSettings.TemplateType = CodeGeneration.CodeTemplateType.TableTemplate
            pSettings.OverWriteFiles = True
        End Sub

        Public Overrides Function OutputFileDirectory() As String
            Return String.Format("App_Code\{0}\UI\CustomControls\{0}\{1}", Me.CurrentProvider.GeneratedNamespace, Me.CurrentTable.PluralClassName)
        End Function

        Public Overrides Function OutputFileName() As String
            If (Me.EntityType = CodeGeneration.EntityTypes.Table) Then
                Return String.Format("Edit_{0}.ascx", Me.CurrentTable.ClassName)
            End If

            If (Me.EntityType = CodeGeneration.EntityTypes.View) Then
                Return String.Format("Edit_{0}.ascx", Me.CurrentView.ClassName)
            End If

            Return "undefined.txt"
        End Function

        Private Function GetControlList(ByVal pTable As MetaDiscovery.Table) As String
            Dim lSB As New StringBuilder

            For Each lColumn As MetaDiscovery.Column In pTable.Columns
                Dim lIncludeInList As Boolean = True

                If (lColumn.IsPrimaryKey) Then
                    If (lColumn.AutoIncrement) Then
                        lIncludeInList = False
                    End If
                End If

                If (lIncludeInList) Then
                    lSB.AppendFormat("                                <li>" & vbCrLf)

                    Select Case lColumn.UIControlType
                        Case MetaDiscovery.UIControlType.TextField

                            lSB.AppendFormat("{0}<TextEditControl:TextEditControl ID=""{1}"" runat=""server"" Label=""{2}"" DisplayHint=""{3}"" Hint=""{4}"" Width=""{5}""/>", _
                                                "                                    ", _
                                                lColumn.UIControlID, _
                                                lColumn.FieldLabel, _
                                                Convert.ToString(lColumn.DisplayHint).ToLower, _
                                                lColumn.HintText, _
                                                lColumn.UIControlWidth)

                            '<TextEditControl:TextEditControl ID="TextEditControl6" runat="server" Label="Nombre" DisplayHint="true" Hint="" Width="400"/>                    

                            'lSB.AppendFormat("                                    <TextEditControl:TextEditControl ID=""{0}"" runat=""server"" Label=""{1}"" Width=""{2}"" />" & vbCrLf, lColumn.UIControlID, lColumn.FieldLabel, lColumn.UIControlWidth)

                            'Case MetaDiscovery.UIControlType.IntegerNumberTextField
                            '    lSB.AppendFormat("                                    <TextEditControl:TextEditControl ID=""ctrl{0}"" runat=""server"" Label=""Id"" Width=""120"" />" & vbCrLf, lColumn.PropertyName)


                    End Select

                    lSB.AppendFormat("                                <\li>" & vbCrLf)
                End If
            Next

            Return lSB.ToString
        End Function

        Public Overrides Sub ProduceCode(ByRef Output As System.IO.StreamWriter)
            Dim lASCX As String = My.Resources.UI_CodeGenStrings.EditItem_ASCX
            Dim lControlList As String = String.Empty

            lASCX = lASCX.Replace("[$ClassName]", Me.CurrentTable.ClassName)
            lASCX = lASCX.Replace("[$Controls]", Me.GetControlList(Me.CurrentTable))

            Output.Write(lASCX)
        End Sub
    End Class

End Namespace
