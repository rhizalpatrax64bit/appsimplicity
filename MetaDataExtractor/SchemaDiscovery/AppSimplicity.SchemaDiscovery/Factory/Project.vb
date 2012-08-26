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
                lProject.UpdateRelationShips()
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

        ''' <summary>
        ''' Looks for hookups between entities to discover HasMany and BelongsTo relationships
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub UpdateRelationShips()
            For Each lDataSource As Entities.DataSource In Me.DataSources
                For Each lTable As Entities.AbstractTable In lDataSource.Tables
                    lTable.HasManyRelationships.Clear()
                    lTable.BelongsToRelationShips.Clear()
                    lTable.BelongsToAndHasManyRelationships.Clear()
                    Me.FixRelationships(lTable, lDataSource.Tables)
                Next
            Next
        End Sub

        Private Sub FixRelationships(pParentTable As Entities.AbstractTable, pNeighborhood As List(Of Entities.Table))
            'Fix 'BelongsTo' relationships:
            For Each lColumn As Entities.Column In pParentTable.Columns
                If (lColumn.ColumnName.ToLower().EndsWith("_id")) Then
                    Dim entityName As String = Left(lColumn.ColumnName, lColumn.ColumnName.Length - 3)

                    For Each lotherTable In pNeighborhood
                        Dim lEvaluate As Boolean = True

                        If (lotherTable.Name.ToLower().EndsWith("map")) Then
                            lEvaluate = False
                        ElseIf (lotherTable.ClassName = pParentTable.ClassName) Then
                            lEvaluate = False
                        End If

                        If (lEvaluate) Then
                            If entityName.ToLower() = lotherTable.ClassName.ToLower() Then
                                Dim lRelationShip As New Entities.RelationShip
                                lRelationShip.ForeignEntityName = entityName
                                lRelationShip.RelationshipColumn = lColumn.ColumnName
                                pParentTable.BelongsToRelationShips.Add(lRelationShip)
                            End If
                        End If
                    Next
                End If
            Next

            'Fix 'HasMany' relationships:
            For Each ltable As Entities.AbstractTable In pNeighborhood
                If (ltable.ClassName <> pParentTable.ClassName) Then
                    Dim lForeignColumnName = String.Format("{0}_Id", pParentTable.ClassName)

                    For Each lColumn As Entities.Column In ltable.Columns
                        If (lColumn.ColumnName.ToLower() = lForeignColumnName.ToLower()) Then
                            Dim lRelationShip As New Entities.RelationShip
                            lRelationShip.ForeignEntityName = ltable.ClassName
                            lRelationShip.RelationshipColumn = lColumn.ColumnName
                            pParentTable.HasManyRelationships.Add(lRelationShip)
                        End If
                    Next
                End If
            Next

        End Sub

    End Class
End Namespace
