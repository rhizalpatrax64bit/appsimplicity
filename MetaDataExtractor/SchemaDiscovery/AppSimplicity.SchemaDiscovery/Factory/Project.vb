Imports System.IO
Imports System.Configuration
Namespace Entities
    Partial Public Class Project

        Public Shared Sub PersistToFile(ByVal project As Project, ByVal pathToFile As String)
            Dim lSerializer As New Serialization.XMLSerializer(Of Project)
            System.IO.File.WriteAllText(pathToFile, lSerializer.SerializeToString(project))
        End Sub

        Public Shared Function LoadFromFile(ByVal pathToFile As String) As Project
            Dim lProject As Project = Nothing
            Dim lSerializer As New Serialization.XMLSerializer(Of Project)
            lProject = lSerializer.DeserializeFromString(System.IO.File.ReadAllText(pathToFile))

            If (lProject Is Nothing) Then
                lProject.UpdateLanguageMappings()
            End If

            Return lProject
        End Function

        Public Sub UpdateLanguageMappings()
            Dim languageMapper As New DBCLRMapper()
            Dim Languages As String() = {"C#", "VB.NET"}

            For Each lDS As Entities.DataSource In Me.DataSources
                For Each lTable As Entities.Table In lDS.Tables
                    For Each lColumn As Entities.Column In lTable.Columns
                        Dim CLRMappingInfo As CLRMappingInfo = languageMapper.GetTargetCLRType("SQL", Languages(Me.TargetLanguage), lColumn.SQLType)

                        If Not (CLRMappingInfo Is Nothing) Then
                            lColumn.CLRTargetType = CLRMappingInfo.CLRTargetType
                            lColumn.IsCLRNullable = CLRMappingInfo.IsCLRNullable
                        End If
                    Next
                Next

                For Each lView As Entities.View In lDS.Views
                    For Each lColumn As Entities.Column In lView.Columns
                        Dim CLRMappingInfo As CLRMappingInfo = languageMapper.GetTargetCLRType("SQL", Languages(Me.TargetLanguage), lColumn.SQLType)

                        If Not (CLRMappingInfo Is Nothing) Then
                            lColumn.CLRTargetType = CLRMappingInfo.CLRTargetType
                            lColumn.IsCLRNullable = CLRMappingInfo.IsCLRNullable
                        End If
                    Next
                Next

                For Each lSP As Entities.StoredProcedure In lDS.StoredProcedures
                    For Each lParameter As Entities.StoredProcedureParameter In lSP.Parameters
                        Dim CLRMappingInfo As CLRMappingInfo = languageMapper.GetTargetCLRType("SQL", Languages(Me.TargetLanguage), lParameter.SQLType)

                        If Not (CLRMappingInfo Is Nothing) Then
                            lParameter.CLRTargetType = CLRMappingInfo.CLRTargetType
                            lParameter.IsCLRNullable = CLRMappingInfo.IsCLRNullable
                        End If
                    Next
                Next
            Next
        End Sub
    End Class
End Namespace
