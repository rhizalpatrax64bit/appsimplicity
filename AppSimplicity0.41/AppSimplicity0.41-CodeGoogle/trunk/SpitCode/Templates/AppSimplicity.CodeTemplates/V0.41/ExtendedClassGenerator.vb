Imports System.Text
Imports SpitCodeEngine

Public Class ExtendedClassGenerator
    Inherits CodeGeneration.CodeTemplate

    Public Overrides Sub Initialize(ByVal pSettings As SpitCodeEngine.CodeGeneration.TemplateSettings)
        pSettings.Description = "v0.41 - Extended Class Generator"
        pSettings.TemplateType = CodeGeneration.CodeTemplateType.TableTemplate
        pSettings.OverWriteFiles = False
    End Sub

    Public Overrides Function OutputFileDirectory() As String
        Return String.Format("App_Code\{0}\Extended", Me.CurrentProvider.GeneratedNamespace)
    End Function

    Public Overrides Function OutputFileName() As String
        If (Me.EntityType = CodeGeneration.EntityTypes.Table) Then
            Return String.Format("{0}.vb", Me.CurrentTable.ClassName)
        End If

        If (Me.EntityType = CodeGeneration.EntityTypes.View) Then
            Return String.Format("{0}.vb", Me.CurrentView.ClassName)
        End If

        Return "undefined.txt"
    End Function

    Private Function GetScope(ByVal pTable As MetaDiscovery.Table) As String
        Dim lScope As String = String.Empty

        Select Case (Me.CurrentTable.ClassScope)
            Case MetaDiscovery.Table.ScopeTypes._Friend
                lScope = "Friend"
            Case MetaDiscovery.Table.ScopeTypes._Protected
                lScope = "Protected"
            Case MetaDiscovery.Table.ScopeTypes._Public
                lScope = "Public"
        End Select

        Return lScope
    End Function

    Private Function GetExtendedPluralClass(ByVal pTable As MetaDiscovery.Table) As String

        If (pTable.Name.ToLower.EndsWith("map")) Then
            Return String.Empty
        Else
            Return String.Format(My.Resources.ClassGeneratorStrings.ExtendedPluralClassWrapper, _
                               Me.GetScope(pTable), _
                               pTable.PluralClassName)
        End If

    End Function

    Public Overrides Sub ProduceCode(ByRef Output As System.IO.StreamWriter)
        Output.Write(String.Format(My.Resources.ClassGeneratorStrings.ExtendedClassGenerator, _
                                   Me.CurrentProvider.GeneratedNamespace, _
                                   Me.GetScope(Me.CurrentTable), _
                                   Me.CurrentTable.ClassName, _
                                   Me.GetExtendedPluralClass(Me.CurrentTable)))
    End Sub
End Class
