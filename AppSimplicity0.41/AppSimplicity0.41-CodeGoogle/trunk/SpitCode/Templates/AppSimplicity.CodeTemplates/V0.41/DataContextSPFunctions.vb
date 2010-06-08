Imports System.Text
Imports SpitCodeEngine

Public Class DataContextSPFunctions
    Inherits CodeGeneration.CodeTemplate

    Public Overrides Sub Initialize(ByVal pSettings As SpitCodeEngine.CodeGeneration.TemplateSettings)
        pSettings.Description = "v0.41 - DataContext SPs Class Generator"
        pSettings.TemplateType = CodeGeneration.CodeTemplateType.ProviderTemplate
        pSettings.OverWriteFiles = True
    End Sub

    Public Overrides Function OutputFileDirectory() As String
        Return String.Format("App_Code\{0}\Classes", Me.CurrentProvider.GeneratedNamespace)
    End Function

    Public Overrides Function OutputFileName() As String
        Return "DataContext.SPs.vb"
    End Function

    Private Function GetScope(ByVal pProvider As MetaDiscovery.Provider) As String

        Select Case (pProvider.DataServiceScope)
            Case MetaDiscovery.Provider.DataServiceScopeTypes._Friend
                Return "Friend"
            Case MetaDiscovery.Provider.DataServiceScopeTypes._Public
                Return "Public"
        End Select

        Return "Public"
    End Function


    Private Function GetSPParameters(ByVal pProcedure As MetaDiscovery.Procedure) As String
        Dim lSB As New StringBuilder

        If (pProcedure.Parameters.Count > 0) Then
            lSB.AppendFormat(" _" & vbCrLf)
            
            Dim lParameters As New List(Of String)

            For Each lParameter As MetaDiscovery.Parameter In pProcedure.Parameters

                lParameters.Add(String.Format("                    ByVal p{0} As {1}", lParameter.DisplayName, lParameter.LanguageType))

            Next

            lSB.Append(String.Join(", _" & vbCrLf, lParameters.ToArray))
        End If

        Return lSB.ToString
    End Function

    Private Function GetCommandParameters(ByVal pProcedure As MetaDiscovery.Procedure) As String
        Dim lSB As New StringBuilder

        For Each lParameter As MetaDiscovery.Parameter In pProcedure.Parameters
            lSB.AppendFormat("                lCommand.AddParameter(""{0}"", {1}, p{2})" & vbCrLf, lParameter.Name, lParameter.VariableType, lParameter.DisplayName)
        Next

        Return lSB.ToString
    End Function

    Private Function GetSPs(ByVal pProvider As MetaDiscovery.Provider) As String
        Dim lSB As New StringBuilder

        For Each lProcedure As MetaDiscovery.Procedure In pProvider.Procedures
            lSB.AppendFormat(My.Resources.ClassGeneratorStrings.SPFunctionWrapper & vbCrLf & vbCrLf, _
                             lProcedure.SchemaName, _
                             lProcedure.DisplayName, _
                             Me.GetSPParameters(lProcedure), _
                             Me.GetCommandParameters(lProcedure), _
                             pProvider.GeneratedNamespace)
        Next

        Return lSB.ToString
    End Function

    Public Overrides Sub ProduceCode(ByRef Output As System.IO.StreamWriter)
        Output.Write(My.Resources.ClassGeneratorStrings.DataContextSPFunctionsWrapper, _
                        Me.CurrentProvider.GeneratedNamespace, _
                        Me.CurrentProvider.Name, _
                        Me.GetScope(Me.CurrentProvider), _
                        Me.GetSPs(Me.CurrentProvider))
    End Sub
End Class
