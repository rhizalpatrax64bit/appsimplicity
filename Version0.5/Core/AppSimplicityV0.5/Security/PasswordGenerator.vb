Imports System.Security.Cryptography

Namespace Security
    Public Class PasswordGenerator
        Const VALIDCHARS = "ABCDEFGHIJKLMNPQRSTWXYZabcdefghijkmnopqrstwxyz023456789"

        Private Function GetRandomChar() As Char
            Dim lRandom As New Random(Me.GetRandomSeed)
            Dim lIndex As Integer = 0
            Dim lValidChars = VALIDCHARS

            lIndex = lRandom.Next(0, lValidChars.Length - 1)

            Return lValidChars(lIndex)
        End Function

        Private Function GetRandomSeed() As Integer
            Dim lRandomBytes As Byte() = New Byte(3) {}

            ' Generar 4 numeros aleatorios:
            Dim lRandomGenerator As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()
            lRandomGenerator.GetBytes(lRandomBytes)


            ' Convertir los 4 valores a un solo número entero de 32 bits 
            Dim lSeed As Integer = ((lRandomBytes(0) And &H7F) << 24 Or _
                                    lRandomBytes(1) << 16 Or _
                                    lRandomBytes(2) << 8 Or _
                                    lRandomBytes(3))

            Return lSeed
        End Function

        ''' <summary>
        ''' Genera una contraseña segura de forma aleatoria
        ''' </summary>
        ''' <param name="pPasswordLength">La longitud que maxima que tendrá la contraseña generada</param>
        ''' <returns>Devuelve una cadena con la contraseña generada</returns>
        Public Function Generate(Optional ByVal pPasswordLength As Integer = 16) As String
            Dim lGeneratedPassword As String = String.Empty

            Dim lPassword As Char()
            lPassword = New Char(pPasswordLength - 1) {}

            For N As Integer = 0 To lPassword.Length - 1
                lPassword(N) = GetRandomChar()
            Next

            Return New String(lPassword)
        End Function
    End Class
End Namespace
