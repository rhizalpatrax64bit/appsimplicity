Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Namespace Utilities.Security.Encryption
    ''' <summary>
    ''' Class to encrypt/decrypt using TripleDES algorythm
    ''' </summary>
    Public Class CryptoService

        Private _CryptoKey As String
        Private _InitializationVector() As Byte = {&H25, &H29, &H93, &H27, &H52, &HFD, &HAE, &HBC}
        Private _CryptoService As TripleDESCryptoServiceProvider

        Const MIN_KEY_LENGTH = 16

        Private Function GetEncryptor() As System.Security.Cryptography.ICryptoTransform
            Return _CryptoService.CreateEncryptor(System.Text.Encoding.UTF8.GetBytes(Left(_CryptoKey, MIN_KEY_LENGTH)), Me._InitializationVector)
        End Function

        Private Function GetDecryptor() As System.Security.Cryptography.ICryptoTransform
            Return _CryptoService.CreateDecryptor(System.Text.Encoding.UTF8.GetBytes(Left(_CryptoKey, MIN_KEY_LENGTH)), Me._InitializationVector)
        End Function

        ''' <summary>
        ''' Encrypts a string
        ''' </summary>
        ''' <param name="pValue">Value to encrypt</param>
        ''' <returns>It returns the value encrypted</returns>
        Public Function Encrypt(ByVal pValue As String) As String
            Try
                Dim lInput As Byte() = Encoding.UTF8.GetBytes(pValue)

                Dim lFinalStream As New MemoryStream
                Dim lCryptoStream As New CryptoStream(lFinalStream, Me.GetEncryptor(), CryptoStreamMode.Write)

                lCryptoStream.Write(lInput, 0, lInput.Length)
                lCryptoStream.FlushFinalBlock()

                Return Convert.ToBase64String(lFinalStream.ToArray)
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        ''' <summary>
        ''' Decrypt a previously encrypted value
        ''' </summary>
        ''' <param name="pValue">Previously encrypted value</param>
        ''' <returns>Devuelve el valor de la cadena despues de aplicar el algoritmo de desencriptacion</returns>
        Public Function Decrypt(ByVal pValue As String) As String
            Try
                Dim lInput As Byte() = Convert.FromBase64String(pValue)

                Dim lFinalStream As New MemoryStream
                Dim lCryptoStream As New CryptoStream(lFinalStream, Me.GetDecryptor(), CryptoStreamMode.Write)

                lCryptoStream.Write(lInput, 0, lInput.Length)
                lCryptoStream.FlushFinalBlock()

                Dim lUTF8 As System.Text.Encoding = System.Text.Encoding.UTF8

                Return lUTF8.GetString(lFinalStream.ToArray())
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        ''' <summary>
        ''' Crea la instancia de un servicio de encriptación 
        ''' </summary>
        ''' <param name="pEncryptionKey">Establece la clave de encriptacion</param>
        ''' <remarks>La clave de encriptación debe tener al menos 16 caracteres</remarks>
        Public Sub New(ByVal pEncryptionKey As String)
            If (pEncryptionKey.Length < MIN_KEY_LENGTH) Then
                Throw New Exception(String.Format("La clave de encryptación requiere tener al menos {0} caracteres.", MIN_KEY_LENGTH))
            End If
            _CryptoKey = pEncryptionKey
            _CryptoService = New TripleDESCryptoServiceProvider
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
            _CryptoService = Nothing
        End Sub
    End Class

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

        Public Shared Function GeneratePassword() As String
            Dim lPasswordGen As New PasswordGenerator

            Return lPasswordGen.Generate()
        End Function
    End Class

End Namespace


