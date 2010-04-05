Imports System.Text
Imports SpitCodeEngine

Public Class SchemaGenerator
    Inherits CodeGeneration.CodeTemplate

    Public Overrides Sub Initialize(ByVal pSettings As SpitCodeEngine.CodeGeneration.TemplateSettings)
        pSettings.Description = "v0.41 - Schema Generator"
        pSettings.TemplateType = CodeGeneration.CodeTemplateType.TableTemplate
        pSettings.OverWriteFiles = True
    End Sub

    Public Overrides Function OutputFileDirectory() As String
        Return String.Format("App_Code\{0}\Schemas", Me.CurrentProvider.GeneratedNamespace)
    End Function

    Public Overrides Function OutputFileName() As String
        If (Me.EntityType = CodeGeneration.EntityTypes.Table) Then
            Return String.Format("{0}.vb", Me.CurrentTable.PluralClassName)
        End If

        If (Me.EntityType = CodeGeneration.EntityTypes.View) Then
            Return String.Format("{0}.vb", Me.CurrentView.PluralClassName)
        End If

        Return "undefined.txt"
    End Function

    Private Function GetColumnsDefinitions(ByVal pEntity As SpitCodeEngine.MetaDiscovery.Table) As String
        Dim SB As New StringBuilder

        For Each Column As MetaDiscovery.Column In pEntity.Columns

            SB.AppendFormat(My.Resources.ClassGeneratorStrings.ColumnDefinition & vbCrLf & vbCrLf, _
                                Column.Name, _
                                Column.DbTargetType, _
                                Column.MaxLength, _
                                Column.AutoIncrement.ToString, _
                                Column.IsNullable.ToString, _
                                Column.IsPrimaryKey.ToString, _
                                Column.FieldLabel, _
                                Column.GridColumnCaption, _
                                "True")

        Next

        Return SB.ToString()
    End Function

    Public Function GetFieldEnum(ByVal pTable As MetaDiscovery.Table) As String
        Dim SB As New StringBuilder
        Dim lFirst As Boolean = True

        For Each lColumn As MetaDiscovery.Column In pTable.Columns
            If (lFirst) Then
                SB.AppendFormat("            ""{0}"" _" & vbCrLf, lColumn.Name)
                lFirst = False
            Else
                SB.AppendFormat("            , ""{0}"" _" & vbCrLf, lColumn.Name)
            End If
        Next

        Return SB.ToString
    End Function

    Public Function GetColumnEnum(ByVal pTable As MetaDiscovery.Table) As String
        Dim SB As New StringBuilder
        Dim lFirst As Boolean = True

        Dim N As Integer = 0
        For Each lColumn As MetaDiscovery.Column In pTable.Columns
            SB.AppendFormat("            {0} = {1}" & vbCrLf, lColumn.PropertyName, N)

            N = N + 1
        Next

        Return SB.ToString
    End Function

    Public Function GetHardCodeFieldEnumeration(ByVal pTable As MetaDiscovery.Table) As String
        Dim lValue As String = String.Format(My.Resources.ClassGeneratorStrings.FieldGenerator, GetFieldEnum(pTable), GetColumnEnum(pTable))
        Return lValue.Replace("-<", "{").Replace(">-", "}")
    End Function




    Private Function GetSelectColumnsClass(ByVal pTable As MetaDiscovery.Table) As String
        Dim lSB As New StringBuilder

        For Each lColumn As MetaDiscovery.Column In pTable.Columns
            lSB.AppendFormat("                    Query.ColumnsList.Add(Schema({0}.Fields({0}.Columns.{1})))" & vbCrLf, pTable.PluralClassName, lColumn.PropertyName)
        Next

        Return String.Format(My.Resources.ClassGeneratorStrings.SelectColumnsClassWrapper, pTable.PluralClassName, lSB.ToString())
    End Function

    Private Function GetJoinList(ByVal pTable As MetaDiscovery.Table) As String
        Dim lSB As New StringBuilder

        For Each lRelation As MetaDiscovery.MetaRelation In pTable.BelongsToRelations
            lSB.AppendFormat(My.Resources.ClassGeneratorStrings.JoinProperty & vbCrLf, _
                             lRelation.ForeignEntity.PluralClassName, _
                             lRelation.ExternalReferenceColumn.Name)
        Next

        Return String.Format(My.Resources.ClassGeneratorStrings.JoinList, lSB.ToString)
    End Function

    Public Function GetQueryBuilder(ByVal pTable As MetaDiscovery.Table) As String
        Return String.Format(My.Resources.ClassGeneratorStrings.QueryBuilderClassWrapper, _
                              pTable.PluralClassName, _
                              pTable.Provider.GeneratedNamespace, _
                              pTable.ClassName, _
                              Me.GetSelectColumnsClass(pTable), _
                              Me.GetJoinList(pTable), _
                              Me.GetScopeForFetchMethods(pTable))
    End Function

    Private Function GetFetchManyMethods(ByVal pTable As MetaDiscovery.Table) As String
        Dim lSB As New StringBuilder

        If Not (pTable.Name.ToLower.EndsWith("map")) Then
            For Each lRelation As MetaDiscovery.MetaRelation In pTable.HasManyRelations
                If (lRelation.ForeignEntity.Name.ToLower.EndsWith("map")) Then

                    Dim lParent As MetaDiscovery.Table = Nothing
                    Dim lChild As MetaDiscovery.Table = pTable
                    Dim lExternalColumn As MetaDiscovery.Column = Nothing

                    For Each lBelongsToRelation As MetaDiscovery.MetaRelation In lRelation.ForeignEntity.BelongsToRelations
                        If Not (lBelongsToRelation.ForeignEntity.Name = pTable.Name) Then
                            lParent = lBelongsToRelation.ForeignEntity
                            lExternalColumn = lBelongsToRelation.ExternalReferenceColumn
                            Exit For
                        End If
                    Next

                    lSB.AppendFormat(My.Resources.ClassGeneratorStrings.FetchHasManyByMethod, _
                                     lChild.PluralClassName, _
                                     pTable.Provider.GeneratedNamespace, _
                                     lChild.ClassName, _
                                     lParent.ClassName, _
                                     lParent.PluralClassName, _
                                     lRelation.ForeignEntity.ClassName, _
                                     lParent.PKColumn.PropertyName, _
                                     lExternalColumn.PropertyName, _
                                     Me.GetScopeForFetchMethods(pTable))


                End If
            Next
        End If

        Return lSB.ToString
    End Function

    Private Function GetScopeForFetchMethods(ByVal pTable As MetaDiscovery.Table) As String
        Select Case (pTable.ClassScope)
            Case MetaDiscovery.Table.ScopeTypes._Friend
                Return "Friend"
            Case MetaDiscovery.Table.ScopeTypes._Protected, MetaDiscovery.Table.ScopeTypes._Public
                Return "Public"
        End Select

        Return "Public"
    End Function

    Public Function GetFetchMethods(ByVal pTable As MetaDiscovery.Table) As String
        Return String.Format(My.Resources.ClassGeneratorStrings.FetchMethods, _
                             pTable.Provider.GeneratedNamespace, _
                             pTable.ClassName, _
                             pTable.PluralClassName, _
                             Me.GetFetchManyMethods(pTable), _
                             Me.GetScopeForFetchMethods(pTable))
    End Function

    Public Overrides Sub ProduceCode(ByRef Output As System.IO.StreamWriter)
        Output.Write(String.Format(My.Resources.ClassGeneratorStrings.SchemaWraper, _
                        Me.CurrentProvider.GeneratedNamespace, _
                        Me.CurrentTable.PluralClassName, _
                        Me.CurrentTable.Name, _
                        "False", _
                        GetColumnsDefinitions(Me.CurrentTable), _
                        Me.GetHardCodeFieldEnumeration(Me.CurrentTable), _
                        Me.GetQueryBuilder(Me.CurrentTable), _
                        Me.GetFetchMethods(Me.CurrentTable), _
                        Me.GetScopeForFetchMethods(Me.CurrentTable)))

    End Sub
End Class
