Imports SpitCodeEngine
Imports System.Text

Public Class GridViewGeneratorASCX
    Inherits CodeGeneration.CodeTemplate

    Public Overrides Sub Initialize(ByVal pSettings As SpitCodeEngine.CodeGeneration.TemplateSettings)
        pSettings.Description = "v0.41 - GridView Generator ASCX"
        pSettings.TemplateType = CodeGeneration.CodeTemplateType.TableTemplate
        pSettings.OverWriteFiles = True
    End Sub

    Public Overrides Function OutputFileDirectory() As String
        Return String.Format("App_Code\{0}\UI\CustomControls\{0}\{1}", Me.CurrentProvider.GeneratedNamespace, Me.CurrentTable.PluralClassName)
    End Function

    Public Overrides Function OutputFileName() As String
        If (Me.EntityType = CodeGeneration.EntityTypes.Table) Then
            Return String.Format("GridView_{0}.ascx", Me.CurrentTable.PluralClassName)
        End If

        If (Me.EntityType = CodeGeneration.EntityTypes.View) Then
            Return String.Format("GridView_{0}.ascx", Me.CurrentView.PluralClassName)
        End If

        Return "undefined.txt"
    End Function

    Private Function GetColumnsMarkup(ByVal pTable As MetaDiscovery.Table) As String
        Dim lSB As New StringBuilder

        For Each lColumn As MetaDiscovery.Column In pTable.Columns
            Dim lInclude As Boolean = True
            Dim lS As String = String.Empty

            If (lColumn.IsPrimaryKey) Then
                lInclude = False
            End If

            Select Case lColumn.BasicType
                Case MetaDiscovery.Column.BasicTypes.BooleanType
                    lS = My.Resources.UI_CodeGenStrings.GridColumn_Boolean

                Case MetaDiscovery.Column.BasicTypes.StringType
                    If (lColumn.MaxLength > 255) Then
                        lInclude = False
                    Else
                        lS = My.Resources.UI_CodeGenStrings.GridColumn_String
                    End If
                Case MetaDiscovery.Column.BasicTypes.BinaryType
                    lInclude = False

                Case MetaDiscovery.Column.BasicTypes.DateType


            End Select

            lS = lS.Replace("[$TableName]", pTable.Name)
            lS = lS.Replace("[$ColumnName]", lColumn.Name)
            lS = lS.Replace("[$GridCaption]", lColumn.GridColumnCaption)
            lS = lS.Replace("[$Width]", lColumn.GridColumnWidth)

            If (lInclude) Then
                lSB.Append(lS)
                lSB.AppendLine()

                If (lColumn.HasBelongsToReference) Then

                End If
            End If

        Next

        Return lSB.ToString
    End Function

    Public Overrides Sub ProduceCode(ByRef Output As System.IO.StreamWriter)
        Dim lOutput As String = My.Resources.UI_CodeGenStrings.GridViewASCX

        lOutput = lOutput.Replace("[$ClassName]", Me.CurrentTable.ClassName)
        lOutput = lOutput.Replace("[$TableName]", Me.CurrentTable.Name)
        lOutput = lOutput.Replace("[$PluralClassName]", Me.CurrentTable.PluralClassName)
        lOutput = lOutput.Replace("[$GeneratedNamespace]", Me.CurrentTable.Provider.GeneratedNamespace)
        lOutput = lOutput.Replace("[$PKPropertyName]", Me.CurrentTable.PKColumn.PropertyName)

        lOutput = lOutput.Replace("[$Columns]", Me.GetColumnsMarkup(Me.CurrentTable))

        Output.Write(lOutput)
    End Sub

    Public Overrides Function ValidateCodeFile() As Boolean
        If (Me.CurrentTable.ClassName.ToLower.EndsWith("map")) Then
            Return False
        End If
        Return True
    End Function

End Class
