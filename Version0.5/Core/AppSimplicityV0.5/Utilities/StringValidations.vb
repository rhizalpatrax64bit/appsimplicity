Imports System.Text.RegularExpressions
Namespace Utilities
    Public Class StringValidations

        ''' <summary>
        ''' Determina si una dirección de correo posee la sintaxis correcta
        ''' </summary>
        ''' <param name="pMailAddress">La dirección que se desea validar</param>
        ''' <returns>Devuelve verdadero cuando la dirección de correo tiene la sintaxis correcta</returns>
        Public Shared Function IsValidEmail(ByVal pMailAddress As String) As Boolean
            Dim lReg As New Regex("^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
            Return (lReg.Match(pMailAddress).Success)
        End Function

    End Class
End Namespace
