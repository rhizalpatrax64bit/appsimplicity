Public Class NameFixer

    Private lInvalidNames As String() = { _
           "alias", "addHandler", "ansi", "as", "assembly", "auto", "binary", "byref", "byval", "case", "catch", "class", _
           "custom", "date", "datetime", "default", "directcast", "each", "else", "elseif", "end", "error", "false", _
           "finally", "for", "friend", "global", "handles", "implements", "in", "is", "lib", "loop", "me", "module", _
           "mustinherit", "mustoverride", "mybase", "myclass", "narrowing", "new", "next", "nothing", "notinheritable", _
           "notoverridable", "of", "off", "on", "option", "optional", "overloads", "overridable", "overrides", "paramarray", _
           "partial", "preserve", "private", "property", "protected", "public", "raiseevent", "readonly", "resume", "shadows", _
           "shared", "static", "step", "structure", "text", "then", "to", "true", "trycast", "unicode", "until", "when", _
           "while", "widening", "withevents", "writeonly", _
           "compare", "explicit", "isfalse", "istrue", "mid", "strict", "module", "count" _
       }

    Public Function GetValidName(ByVal pName As String) As String
        Dim lReturnValue As String = String.Empty

        For Each lName As String In lInvalidNames
            If (pName.ToLower = lName.ToLower) Then
                pName = String.Format("{0}_", pName)
                Exit For
            End If
        Next

        lReturnValue = pName

        Return lReturnValue
    End Function

    Public Function FixClassName(ByVal pName As String) As String
        Dim lClassName As String = pName

        lClassName = lClassName.Replace(" ", "")

        If (lClassName.Contains("_")) Then
            If (lClassName.StartsWith("_")) Or (lClassName.EndsWith("_")) Then
                lClassName = lClassName.Replace("_", "")
            Else
                Dim lPrefix As Boolean = True
                Dim lNameChops As String() = lClassName.Split("_")
                lClassName = String.Empty
                For Each lChop As String In lNameChops

                    If (lPrefix) Then
                        lPrefix = False
                    Else
                        lClassName = lClassName & lChop
                    End If
                Next
            End If
        End If

        If (lClassName.ToLower.EndsWith("s")) Then
            lClassName = Left(lClassName, lClassName.Length - 1)
        End If

        lClassName = String.Format("{0}{1}", Left(lClassName, 1).ToUpper, Right(lClassName, lClassName.Length - 1))

        lClassName = GetValidName(lClassName)

        Return lClassName
    End Function

    Public Function FixPluralClassName(ByVal pName As String) As String
        Dim lClassName As String = pName

        lClassName = lClassName.Replace(" ", "")

        If (lClassName.Contains("_")) Then
            If (lClassName.StartsWith("_")) Or (lClassName.EndsWith("_")) Then
                lClassName = lClassName.Replace("_", "")
            Else
                Dim lPrefix As Boolean = True
                Dim lNameChops As String() = lClassName.Split("_")
                lClassName = String.Empty
                For Each lChop As String In lNameChops

                    If (lPrefix) Then
                        lPrefix = False
                    Else
                        lClassName = lClassName & lChop
                    End If
                Next
            End If
        End If

        lClassName = String.Format("{0}{1}", Left(lClassName, 1).ToUpper, Right(lClassName, lClassName.Length - 1))

        lClassName = GetValidName(lClassName)

        Return lClassName
    End Function

    Public Shared Function GetSingularClassName(ByVal pTableName As String)
        Dim lFixer As New NameFixer
        Return lFixer.FixClassName(pTableName)
    End Function

    Public Shared Function GetPluralClassName(ByVal pTableName As String)
        Dim lFixer As New NameFixer
        Return lFixer.FixPluralClassName(pTableName)
    End Function
End Class
