Imports System.Text
Imports System.IO
Imports Ionic.Zip


Namespace Utilities

    Public Class Compression
        ''' <summary>
        ''' Compress a file into a Zip file
        ''' </summary>
        ''' <param name="pSourceFilePath">The full path of the source file</param>
        ''' <param name="pZipFile">The full path of the zip file. If this is not specified a zip file will be generated using the source file name</param>
        ''' <param name="pDeleteSourceFile">Sets if the sourcefile must be deleted after compression</param>
        ''' <remarks></remarks>
        Public Shared Sub ZipFile(ByVal pSourceFilePath As String, Optional ByVal pZipFile As String = "", Optional ByVal pDeleteSourceFile As Boolean = False)
            Dim lZipFileName As String

            If (pZipFile = String.Empty) Then
                lZipFileName = String.Format("{0}\{1}.zip", _
                                    System.IO.Path.GetFullPath(pSourceFilePath), _
                                    System.IO.Path.GetFileNameWithoutExtension(pSourceFilePath))
            Else
                lZipFileName = pZipFile
            End If

            Using Zip As New ZipFile
                Zip.AddFile(pSourceFilePath)
                Zip.Save(lZipFileName)
            End Using

            If (pDeleteSourceFile) Then
                System.IO.File.Delete(pSourceFilePath)
            End If
        End Sub
    End Class

    Public Class Files
        ''' <summary>
        ''' Creates a file and write some text on it
        ''' </summary>
        ''' <param name="absolutePath">The full path of the text file</param>
        ''' <param name="fileText">The text to write to file</param>
        Public Shared Sub CreateToFile(ByVal absolutePath As String, ByVal fileText As String)
            Using sw As StreamWriter = File.CreateText(absolutePath)
                sw.Write(fileText)
            End Using
        End Sub

        ''' <summary>
        ''' Escribe una cadena a un archivo.
        ''' </summary>
        ''' <param name="absolutePath">La ruta completa del archivo a guardar</param>
        ''' <param name="fileText">La cadena que contiene el texto a guardar</param>
        Public Shared Sub WriteToFile(ByVal absolutePath As String, ByVal fileText As String)
            Using sw As StreamWriter = New StreamWriter(absolutePath, False)
                sw.Write(fileText)
            End Using
        End Sub

        ''' <summary>
        ''' Lee un archivo de texto y obtiene su contenido
        ''' </summary>
        ''' <param name="absolutePath">La ruta completa del archivo a guardar</param>
        ''' <returns>El contenido del archivo</returns>
        Public Shared Function GetFileText(ByVal absolutePath As String) As String
            Using sr As StreamReader = New StreamReader(absolutePath)
                Return sr.ReadToEnd
            End Using
        End Function
    End Class

    Public Class Misc
        ''' <summary>
        ''' Genera una contraseña segura de forma aleatoria
        ''' </summary>
        ''' <returns>Devuelve un string que contiene la contraseña segura</returns>
        Public Shared Function GenerateStrongPassword(Optional ByVal pPasswordLength As Integer = 16) As String
            Dim lPasswordGen As New Security.PasswordGenerator
            Return lPasswordGen.Generate(pPasswordLength)
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
