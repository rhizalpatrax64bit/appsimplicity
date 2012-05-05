Public Class LanguageMappingProvider

    Private _MappingDefinition As DataSet

    Public Function GetCLRMapping(ByVal mappingColumn As Entities.Column) As CLRTargetProperty
        Dim lReturnValue As CLRTargetProperty = Nothing

        If Not (_MappingDefinition Is Nothing) Then
            Dim lRows As DataRow() = _MappingDefinition.Tables(0).Select(String.Format("SQLType='{0}'", mappingColumn.SQLType))
            If (lRows.Length > 0) Then
                lReturnValue = New CLRTargetProperty
                lReturnValue.TargetType = lRows(0).Item("CLRTargetType").ToString()

                If (mappingColumn.IsNullable) Then
                    If (lRows(0).Item("IsCLRNullable").ToString().ToLower() = "true") Then
                        lReturnValue.IsCLRNullable = True
                    End If
                End If
            End If
        End If

        Return lReturnValue
    End Function

    Public Function GetCLRMapping(ByVal mappingParameter As Entities.StoredProcedureParameter) As CLRTargetProperty
        Dim lReturnValue As CLRTargetProperty = Nothing

        If Not (_MappingDefinition Is Nothing) Then
            Dim lRows As DataRow() = _MappingDefinition.Tables(0).Select(String.Format("SQLType='{0}'", mappingParameter.SQLType))
            If (lRows.Length > 0) Then
                lReturnValue = New CLRTargetProperty
                lReturnValue.TargetType = lRows(0).Item("CLRTargetType").ToString()
            End If
        End If

        Return lReturnValue
    End Function


    Private Sub LoadMappings(ByVal providerInvarianName As String, ByVal targetLanguage As TargetLanguages)
        Dim lStringReader As System.IO.StringReader = Nothing
        Select Case targetLanguage
            Case TargetLanguages.VisualBasic
                Select Case (providerInvarianName.ToLower)
                    Case "system.data.sqlclient"
                        lStringReader = New System.IO.StringReader(My.Resources.MappingDefinitions.SQLServer_VBNet)
                    Case "system.data.mysqlclient"
                        lStringReader = New System.IO.StringReader(My.Resources.MappingDefinitions.MySQL_VBNet)
                End Select
            Case TargetLanguages.CSharp
                'TODO: Implement this
        End Select

        If Not (lStringReader Is Nothing) Then
            _MappingDefinition = New Data.DataSet()
            _MappingDefinition.ReadXml(lStringReader)
        End If
    End Sub

    Public Sub New(ByVal providerInvariantName As String, ByVal targetLanguage As TargetLanguages)
        LoadMappings(providerInvariantName, targetLanguage)
    End Sub

End Class
