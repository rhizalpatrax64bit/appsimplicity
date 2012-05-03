Imports System.Collections.Specialized
Imports System.Text.RegularExpressions

Namespace IO

    Public Class CommandArguments
        Private ReadOnly Parameters As StringDictionary = New StringDictionary

        Public Sub New(ByVal CommandLine As String)
            Dim Pattern As String = "/(?<arg>((?!/).)*?)(\s*""(?<value>[^""]*)""|\s+(?<value>(?!/).*?)([\s]|$)|(?<value>\s+))"
            Dim RegEx As New Regex(Pattern, RegexOptions.Compiled Or RegexOptions.IgnoreCase)
            Dim Matches As MatchCollection = RegEx.Matches(CommandLine)

            For Each Match As Match In Matches
                Dim arg As String = Match.Groups("arg").Value
                Dim value As String = Match.Groups("value").Value

                Parameters.Add(arg, value)
            Next
        End Sub

        Public ReadOnly Property Item(ByVal Param As String) As String
            Get
                Return Parameters(Param)
            End Get
        End Property
    End Class

End Namespace
