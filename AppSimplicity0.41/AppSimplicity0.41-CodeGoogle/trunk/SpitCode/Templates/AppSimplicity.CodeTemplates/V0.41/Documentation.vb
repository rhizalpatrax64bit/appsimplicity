Imports System.Text
Imports SpitCodeEngine

Public Class Documentation
    Inherits CodeGeneration.CodeTemplate


    Public Overrides Sub Initialize(ByVal pSettings As SpitCodeEngine.CodeGeneration.TemplateSettings)
        pSettings.Description = "v0.41 - Document Generator"
        pSettings.TemplateType = CodeGeneration.CodeTemplateType.ProviderTemplate
        pSettings.OverWriteFiles = True
    End Sub

    Public Overrides Function OutputFileDirectory() As String
        Return String.Format("App_Code\{0}\Documentation", Me.CurrentProvider.GeneratedNamespace)
    End Function

    Public Overrides Function OutputFileName() As String
        Return "DBObjects.txt"
    End Function

    Public Overrides Sub ProduceCode(ByRef Output As System.IO.StreamWriter)
        Dim lSB As New System.Text.StringBuilder

        lSB.AppendLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", _
                        "Tipo de Objeto", _
                        "Nombre", _
                        "Parametro", _
                        "Tipo", _
                        "Longitud", _
                        "Permite Nulos", _
                        "Documentacion"))

        For Each lTable As MetaDiscovery.Table In Me.CurrentProvider.Tables
            For Each lColumn As MetaDiscovery.Column In lTable.Columns
                lSB.AppendLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", _
                        "Tabla", _
                        lTable.Name, _
                        lColumn.Name, _
                        lColumn.NativeParameterType, _
                        lColumn.MaxLength, _
                        IIf(lColumn.IsNullable, "Si", "No"), _
                        lColumn.CodeDocumentation))
            Next
        Next

        For Each lView As MetaDiscovery.View In Me.CurrentProvider.Views
            For Each lColumn As MetaDiscovery.Column In lView.Columns
                lSB.AppendLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", _
                        "Vista", _
                        lView.Name, _
                        lColumn.Name, _
                        lColumn.NativeParameterType, _
                        lColumn.MaxLength, _
                        IIf(lColumn.IsNullable, "Si", "No"), _
                        lColumn.CodeDocumentation))
            Next
        Next

        For Each lSP As MetaDiscovery.Procedure In Me.CurrentProvider.Procedures
            For Each lparameter As MetaDiscovery.Parameter In lSP.Parameters
                lSB.AppendLine(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", _
                        "Procedimiento", _
                        lSP.SchemaName, _
                        lparameter.Name, _
                        lparameter.DBType, _
                        lparameter.CharacterMaxLength, _
                        " ", _
                        " "))
            Next
        Next

        Output.Write(lSB.ToString)
    End Sub
End Class
