Imports System.Text

Namespace Utilities

    Public Class File
        ''' <summary>
        ''' Creates a file and write some text on it
        ''' </summary>
        ''' <param name="absolutePath">The full path of the text file</param>
        ''' <param name="fileText">The text to write to file</param>
        Public Shared Sub CreateToFile(ByVal absolutePath As String, ByVal fileText As String)
            Using sw As System.IO.StreamWriter = System.IO.File.CreateText(absolutePath)
                sw.Write(fileText)
            End Using
        End Sub

        ''' <summary>
        ''' Escribe una cadena a un archivo.
        ''' </summary>
        ''' <param name="absolutePath">La ruta completa del archivo a guardar</param>
        ''' <param name="fileText">La cadena que contiene el texto a guardar</param>
        Public Shared Sub WriteToFile(ByVal absolutePath As String, ByVal fileText As String)
            Using sw As System.IO.StreamWriter = New System.IO.StreamWriter(absolutePath, False)
                sw.Write(fileText)
            End Using
        End Sub

        ''' <summary>
        ''' Lee un archivo de texto y obtiene su contenido
        ''' </summary>
        ''' <param name="absolutePath">La ruta completa del archivo a guardar</param>
        ''' <returns>El contenido del archivo</returns>
        Public Shared Function GetFileText(ByVal absolutePath As String) As String
            Using sr As System.IO.StreamReader = New System.IO.StreamReader(absolutePath)
                Return sr.ReadToEnd
            End Using
        End Function
    End Class

    Public Class CodeService
        Public Shared Function Encode(ByVal pValue As String) As String
            Dim lEnc As New Security.Encryption.CryptoService(My.Resources.AssemblyStrongKey)
            Return lEnc.Encrypt(pValue)
        End Function

        Public Shared Function Decode(ByVal pValue As String) As String
            Dim lEnc As New Security.Encryption.CryptoService(My.Resources.AssemblyStrongKey)
            Return lEnc.Decrypt(pValue)
        End Function
    End Class
End Namespace

