Public MustInherit Class BaseProvider

    Private _LanguageMapper As DBCLRMapper
    Protected ReadOnly Property LanguageMapper As DBCLRMapper
        Get
            If _LanguageMapper Is Nothing Then
                _LanguageMapper = New DBCLRMapper()
            End If
            Return _LanguageMapper
        End Get
    End Property

    Protected Function GetTargetCLRType(ByVal SourceDB As String, ByVal TargetLanguage As String, ByVal DBType As String) As CLRMappingInfo
        Return LanguageMapper.GetTargetCLRType(SourceDB, TargetLanguage, DBType)
    End Function

End Class
