Imports Ionic.Zip
Imports System.IO.Compression
Imports System.Text
Imports System.IO

Namespace Utilities
    Public Class Compressor

        Public Shared Function CompressString(ByVal pString As String) As String
            Dim lBuffer As Byte()

            lBuffer = Encoding.UTF8.GetBytes(pString)

            Dim lMemoryStream As New MemoryStream

            Using lZip As New GZipStream(lMemoryStream, CompressionMode.Compress, True)
                lZip.Write(lBuffer, 0, lBuffer.Length)
            End Using
        End Function

        Public Shared Function DeCompressString(ByVal pString As String) As String

        End Function

        Public Shared Sub ZipFile(ByVal pFileName As String, Optional ByVal pOutputFileName As String = "", Optional ByVal DeleteOriginalFileAfterCompression As Boolean = False)

        End Sub
    End Class
End Namespace
