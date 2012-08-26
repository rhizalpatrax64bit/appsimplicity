Public Class DBCLRMapper

    Private _LanguageDictionary As DataSet
    Public ReadOnly Property LanguageDictionary As DataSet
        Get
            If (_LanguageDictionary Is Nothing) Then
                _LanguageDictionary = Me.LoadLanguageDictionary()
            End If
            Return _LanguageDictionary
        End Get
    End Property

    Private Function LoadLanguageDictionary() As System.Data.DataSet
        Dim lDS As New System.Data.DataSet

        Dim lSReader As New System.IO.StringReader(My.Resources.DB_CLRLanguageMappings.Languages)
        lDS.ReadXml(lSReader)

        Return lDS
    End Function

    Private Function GetLanguageId(ByVal SourceDB As String, ByVal TargetLanguage As String) As Integer
        Dim lReturnValue As Integer = -1

        Dim lRows As System.Data.DataRow() = Me.LanguageDictionary.Tables("Language").Select(String.Format("From='{0}' AND To='{1}'", SourceDB, TargetLanguage))
        If lRows.Length > 0 Then
            lReturnValue = lRows(0).Item("Language_Id")
        End If

        Return lReturnValue
    End Function

    Private Function GetCLRMapping(ByVal LanguageId As Integer, ByVal DBType As String) As CLRMappingInfo
        Dim lReturnValue As CLRMappingInfo = Nothing

        If (LanguageId <> -1) Then
            Dim lRows As System.Data.DataRow() = Me.LanguageDictionary.Tables("Type").Select(String.Format("From='{0}' AND Language_Id='{1}'", DBType.ToLower(), LanguageId))
            If lRows.Length > 0 Then
                lReturnValue = New CLRMappingInfo()
                lReturnValue.DBSourceType = DBType
                lReturnValue.CLRTargetType = lRows(0).Item("To")
                lReturnValue.IsCLRNullable = IIf(lRows(0).Item("IsCLRNullable").ToString.ToLower() = "true", True, False)
            End If
        End If

        Return lReturnValue
    End Function

    Public Function GetTargetCLRType(ByVal SourceDB As String, ByVal TargetLanguage As String, ByVal DBType As String) As CLRMappingInfo
        Return Me.GetCLRMapping(Me.GetLanguageId(SourceDB, TargetLanguage), DBType)
    End Function

End Class
