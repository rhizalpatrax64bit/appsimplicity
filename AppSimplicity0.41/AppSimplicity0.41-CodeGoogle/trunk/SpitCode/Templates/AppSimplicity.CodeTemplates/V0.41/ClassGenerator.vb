Imports System.Text
Imports SpitCodeEngine

Public Class ClassGenerator
    Inherits CodeGeneration.CodeTemplate

    Public Overrides Sub Initialize(ByVal pSettings As SpitCodeEngine.CodeGeneration.TemplateSettings)
        pSettings.Description = "v0.41 - Class Generator"
        pSettings.TemplateType = CodeGeneration.CodeTemplateType.TableTemplate
        pSettings.OverWriteFiles = True
    End Sub

    Public Overrides Function OutputFileDirectory() As String
        Return String.Format("App_Code\{0}\Classes", Me.CurrentProvider.GeneratedNamespace)
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

    Private Function GetFields(ByVal pTable As SpitCodeEngine.MetaDiscovery.Table) As String
        Dim lSB As New StringBuilder

        lSB.Append(vbCrLf)

        For Each lColumn As SpitCodeEngine.MetaDiscovery.Column In pTable.Columns
            lSB.AppendFormat("        Private _{0} As ActiveRecord.DataValue" & vbCrLf, lColumn.PropertyName)
        Next

        Return lSB.ToString
    End Function

    Private Function GetProperties(ByVal pTable As SpitCodeEngine.MetaDiscovery.Table) As String
        Dim lSB As New StringBuilder

        lSB.Append(vbCrLf)

        For Each lColumn As SpitCodeEngine.MetaDiscovery.Column In pTable.Columns
            lSB.AppendFormat(My.Resources.ClassGeneratorStrings.PropertyWrapper & vbCrLf & vbCrLf, _
                             lColumn.PropertyName, _
                             lColumn.NETVariableType, _
                             lColumn.CodeDocumentation, _
                             IIf(lColumn.IncludeInSerialization, "", vbCrLf & "        <System.Xml.Serialization.XmlIgnore()> _"))
        Next

        Return lSB.ToString
    End Function

    Private Function GetDataValueInstances(ByVal pTable As SpitCodeEngine.MetaDiscovery.Table) As String
        Dim lSB As New StringBuilder

        For Each lColumn As SpitCodeEngine.MetaDiscovery.Column In pTable.Columns
            lSB.AppendFormat("            _{0} = New ActiveRecord.DataValue(lSchema(""{1}""))" & vbCrLf, lColumn.PropertyName, lColumn.Name)
        Next

        Return lSB.ToString
    End Function

    Private Function GetEntityMethods(ByVal pTable As MetaDiscovery.Table) As String
        Dim lRowsQ As New StringBuilder
        Dim lRows As New StringBuilder
        Dim lReadersQ As New StringBuilder
        Dim lReaders As New StringBuilder

        Dim lToNullValues As New StringBuilder


        For Each lColumn As MetaDiscovery.Column In pTable.Columns
            lReadersQ.AppendFormat("                _{0}.Value = pReader.Item(""{1}.{2}"")" & vbCrLf, _
                                  lColumn.PropertyName, _
                                  lColumn.Table.Name, _
                                  lColumn.Name)

            lReaders.AppendFormat("                _{0}.Value = pReader.Item(""{1}"")" & vbCrLf, _
                      lColumn.PropertyName, _
                      lColumn.Name)

            lRowsQ.AppendFormat("                _{0}.Value = pRow.Item(""{1}.{2}"")" & vbCrLf, _
                                  lColumn.PropertyName, _
                                  lColumn.Table.Name, _
                                  lColumn.Name)

            lRows.AppendFormat("                _{0}.Value = pRow.Item(""{1}"")" & vbCrLf, _
                      lColumn.PropertyName, _
                      lColumn.Name)

            lToNullValues.AppendFormat("            _{0}.Value = System.DBNull.Value" & vbCrLf, lColumn.PropertyName)

        Next

        Return String.Format(My.Resources.ClassGeneratorStrings.EntityMethods, _
                             lReadersQ.ToString, _
                             lReaders.ToString, _
                             lRowsQ.ToString, _
                             lRows, lToNullValues)

    End Function

    Private Function GetActiveRecordMethods(ByVal pTable As MetaDiscovery.Table) As String
        Dim lInsertParameters As New StringBuilder
        Dim lDeleteParameters As New StringBuilder
        Dim lUpdateParameters As New StringBuilder

        For Each lColumn As MetaDiscovery.Column In pTable.Columns

            If ((lColumn.Name.ToLower = "modifiedby") Or (lColumn.Name.ToLower = "modificadopor")) Then
                lUpdateParameters.AppendFormat("            lParameters.Add(_{0}.GetCommandParameter(ActiveRecord.DataValue.AuditType.Identity))" & vbCrLf, lColumn.PropertyName)
            Else
                If ((lColumn.Name.ToLower = "modifiedon") Or (lColumn.Name.ToLower = "fechamodificacion")) Then
                    lUpdateParameters.AppendFormat("            lParameters.Add(_{0}.GetCommandParameter(ActiveRecord.DataValue.AuditType.DateInfo))" & vbCrLf, lColumn.PropertyName)
                Else
                    lUpdateParameters.AppendFormat("            lParameters.Add(_{0}.GetCommandParameter())" & vbCrLf, lColumn.PropertyName)
                End If
            End If


            If (lColumn.IsPrimaryKey) Then
                lDeleteParameters.AppendFormat("            lParameters.Add(_{0}.GetCommandParameter())" & vbCrLf, lColumn.PropertyName)
            End If


            If pTable.PKColumn.AutoIncrement Then
                If Not (lColumn.IsPrimaryKey) Then
                    If ((lColumn.Name.ToLower = "createdby") Or (lColumn.Name.ToLower = "creadopor")) Then
                        lInsertParameters.AppendFormat("            lParameters.Add(_{0}.GetCommandParameter(ActiveRecord.DataValue.AuditType.Identity))" & vbCrLf, lColumn.PropertyName)
                    Else
                        If ((lColumn.Name.ToLower = "createdon") Or (lColumn.Name.ToLower = "fechacreacion")) Then
                            lInsertParameters.AppendFormat("            lParameters.Add(_{0}.GetCommandParameter(ActiveRecord.DataValue.AuditType.DateInfo))" & vbCrLf, lColumn.PropertyName)
                        Else
                            lInsertParameters.AppendFormat("            lParameters.Add(_{0}.GetCommandParameter())" & vbCrLf, lColumn.PropertyName)
                        End If
                    End If
                End If
            Else

                If ((lColumn.Name.ToLower = "createdby") Or (lColumn.Name.ToLower = "creadopor")) Then
                    lInsertParameters.AppendFormat("            lParameters.Add(_{0}.GetCommandParameter(ActiveRecord.DataValue.AuditType.Identity))" & vbCrLf, lColumn.PropertyName)
                Else
                    If ((lColumn.Name.ToLower = "createdon") Or (lColumn.Name.ToLower = "fechacreacion")) Then
                        lInsertParameters.AppendFormat("            lParameters.Add(_{0}.GetCommandParameter(ActiveRecord.DataValue.AuditType.DateInfo))" & vbCrLf, lColumn.PropertyName)
                    Else
                        lInsertParameters.AppendFormat("            lParameters.Add(_{0}.GetCommandParameter())" & vbCrLf, lColumn.PropertyName)
                    End If
                End If

            End If
            

        Next

        Return String.Format(My.Resources.ClassGeneratorStrings.ActiveRecordMethods, _
                                pTable.Provider.GeneratedNamespace, _
                                pTable.PluralClassName, _
                                lDeleteParameters.ToString, _
                                lInsertParameters.ToString, _
                                lUpdateParameters.ToString, _
                                pTable.PKColumn.PropertyName)
    End Function

    Private Function GetBelongsToProperties(ByVal pTable As MetaDiscovery.Table) As String
        Dim lSB As New StringBuilder

        For Each lRelation As MetaDiscovery.MetaRelation In pTable.BelongsToRelations
            lSB.AppendFormat(My.Resources.ClassGeneratorStrings.BelongsToProperty & vbCrLf & vbCrLf, _
                             lRelation.ForeignEntity.ClassName, _
                             pTable.Provider.GeneratedNamespace, _
                             lRelation.ForeignEntity.PluralClassName, _
                             lRelation.ExternalReferenceColumn.PropertyName, _
                             lRelation.ForeignEntity.PKColumn.PropertyName)
        Next

        Return lSB.ToString
    End Function

    Private Function GetHasManyProperties(ByVal pTable As MetaDiscovery.Table) As String
        Dim lSB As New StringBuilder

        For Each lRelation As MetaDiscovery.MetaRelation In pTable.HasManyRelations

            If Not (lRelation.ForeignEntity.Name.ToLower.EndsWith("map")) Then

                lSB.AppendFormat(My.Resources.ClassGeneratorStrings.HasManyProperty & vbCrLf & vbCrLf, _
                             lRelation.ForeignEntity.ClassName, _
                             lRelation.ForeignEntity.PluralClassName, _
                             pTable.Provider.GeneratedNamespace, _
                             lRelation.ForeignColumn.PropertyName, _
                             lRelation.ForeignEntity.PKColumn.PropertyName)

            Else

                Dim lHasManyClass As MetaDiscovery.Table = Nothing
                Dim lParentClass As MetaDiscovery.Table = pTable

                For Each lHasManyRelation As MetaDiscovery.MetaRelation In lRelation.ForeignEntity.BelongsToRelations
                    If Not (lHasManyRelation.ForeignEntity.Name = pTable.Name) Then
                        lHasManyClass = lHasManyRelation.ForeignEntity
                        Exit For
                    End If
                Next

                lSB.AppendFormat(My.Resources.ClassGeneratorStrings.HasAndBelongsToManyProperty & vbCrLf & vbCrLf, _
                                lHasManyClass.PluralClassName, _
                                lParentClass.Provider.GeneratedNamespace, _
                                lHasManyClass.ClassName, lParentClass.ClassName)

            End If


        Next

        Return lSB.ToString
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

    Private Function GetSerializationProperties(ByVal pTable As MetaDiscovery.Table) As String
        Dim lSB As New StringBuilder

        For Each lColumn As MetaDiscovery.Column In pTable.Columns
            If (lColumn.IncludeInSerialization) Then
                lSB.AppendFormat("            info.AddValue(""{0}"", {0})" & vbCrLf, lColumn.PropertyName)
            End If
        Next

        Return lSB.ToString
    End Function

    Private Function GetSerializationConstructor(ByVal pTable As MetaDiscovery.Table) As String
        Dim lSB As New StringBuilder

        For Each lColumn As MetaDiscovery.Column In pTable.Columns
            If (lColumn.IncludeInSerialization) Then
                lSB.AppendFormat("            Me.{0} = info.GetValue(""{0}"", GetType({1}))" & vbCrLf, lColumn.PropertyName, lColumn.NETVariableType)
            End If
        Next

        Return lSB.ToString
    End Function

    Public Overrides Sub ProduceCode(ByRef Output As System.IO.StreamWriter)

        Output.Write(String.Format(My.Resources.ClassGeneratorStrings.ClassWrapper, _
                      Me.CurrentProvider.GeneratedNamespace, _
                      Me.CurrentTable.ClassName, _
                      Me.GetFields(Me.CurrentTable), _
                      Me.GetProperties(Me.CurrentTable), _
                      Me.GetDataValueInstances(Me.CurrentTable), _
                      Me.CurrentTable.PluralClassName, _
                      Me.GetEntityMethods(Me.CurrentTable), _
                      Me.GetActiveRecordMethods(Me.CurrentTable), _
                      Me.GetBelongsToProperties(Me.CurrentTable), _
                      Me.GetHasManyProperties(Me.CurrentTable), _
                      Me.GetScope(Me.CurrentTable), _
                      Me.CurrentTable.CodeDocumentation, _
                      Me.GetSerializationProperties(Me.CurrentTable), _
                      Me.GetSerializationConstructor(Me.CurrentTable)))


    End Sub
End Class
