Namespace Security
    Public Class ApplicationContext

        ''' <summary>
        ''' Gets the name of current user's identity
        ''' </summary>      
        Public Function GetIdentityName() As String
            Dim lReturnValue As String = "Anonymous"

            If (System.Web.HttpContext.Current Is Nothing) Then
                lReturnValue = System.Threading.Thread.CurrentPrincipal.Identity.Name
            Else
                lReturnValue = System.Web.HttpContext.Current.User.Identity.Name
            End If

            Return lReturnValue
        End Function

        Public Shared Function GetCurrentUserIdentity() As String
            Dim lSecurity As New ApplicationContext
            Return lSecurity.GetIdentityName()
        End Function

    End Class

End Namespace
