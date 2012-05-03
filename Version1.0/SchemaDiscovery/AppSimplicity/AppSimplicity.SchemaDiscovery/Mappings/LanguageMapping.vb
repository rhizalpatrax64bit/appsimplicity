Public Class LanguageMappingProvider

    Private _ProviderInvariantName As String

    Public Function GetCLRMapping(ByVal inputType As String, ByVal targetLanguage As TargetLanguages) As String
        Dim lReturnValue As String = "Undefined"

        Dim lDS As New DataSet

        Dim lStringReader As System.IO.StringReader = Nothing
        Select Case targetLanguage
            Case TargetLanguages.VisualBasic
                Select Case (_ProviderInvariantName.ToLower)
                    Case "system.data.sqlclient"
                        lStringReader = New System.IO.StringReader(My.Resources.MappingDefinitions.SQLServer_VBNet)
                    Case "system.data.mysqlclient"
                        lStringReader = New System.IO.StringReader(My.Resources.MappingDefinitions.MySQL_VBNet)
                End Select
                lDS.ReadXml(lStringReader)
            Case TargetLanguages.CSharp
                'TODO: Implement this
        End Select

        Dim lRows As DataRow() = lDS.Tables(0).Select(String.Format("SQLType='{0}'", inputType))
        If (lRows.Length > 0) Then
            lReturnValue = lRows(0).Item("CLRTargetType").ToString()
        End If

        Return lReturnValue
    End Function

    Public Sub New(ByVal providerInvariantName As String)
        _ProviderInvariantName = providerInvariantName
    End Sub

End Class
