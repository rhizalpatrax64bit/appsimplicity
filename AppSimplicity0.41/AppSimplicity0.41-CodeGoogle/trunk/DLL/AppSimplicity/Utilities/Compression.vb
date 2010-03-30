Imports Ionic.Zip
Imports System.IO.Compression
Imports System.Text
Imports System.IO

Namespace Utilities
    Public Class Compressor

        'TODO: Implement the following methods

        Public Shared Function CompressString(ByVal pString As String) As String
            Dim lBuffer As Byte()

            lBuffer = Encoding.UTF8.GetBytes(pString)

            Dim lMemoryStream As New MemoryStream

            Using lZip As New GZipStream(lMemoryStream, CompressionMode.Compress, True)
                lZip.Write(lBuffer, 0, lBuffer.Length)
            End Using
        End Function

        Public Shared Function DeCompressString(ByVal pString As String) As String
            'TODO: terminar esto:
        End Function

        Public Shared Sub ZipFile(ByVal pFileName As String, Optional ByVal pOutputFileName As String = "", Optional ByVal DeleteOriginalFileAfterCompression As Boolean = False)
            Dim lFileName As String = System.IO.Path.GetFileNameWithoutExtension(pFileName)


            'TODO: Terminar esto

        End Sub
    End Class
End Namespace
