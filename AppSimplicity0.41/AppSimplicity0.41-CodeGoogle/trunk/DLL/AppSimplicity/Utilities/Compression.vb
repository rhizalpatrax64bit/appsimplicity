Imports Ionic.Zip
Imports System.IO.Compression
Imports System.Text
Imports System.IO

Namespace Utilities
    Public Class Compression

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

        ''' <summary>
        ''' Compresses a file into a Zip file.
        ''' </summary>
        ''' <param name="pFileName">The full path to source file.</param>
        ''' <param name="pOutputPath">The full path to save zip file. If this parameter is not specified function will generate zip file in source file path.</param>
        ''' <param name="pOutputFileName">Use this parameter to rename output file name.  If this parameter is not specified output file name will be the same as source file name.</param>
        ''' <param name="pOverWriteFile">Wether or not overwrite zip file if already exists.</param>
        ''' <param name="pDeleteOriginalFileAfterCompression">If this parameter is set to true it will delete source file after compression.</param>
        ''' <returns>Returns the full path to output zip file.</returns>
        Public Shared Function ZipFile(ByVal pFileName As String, Optional ByVal pOutputPath As String = "", Optional ByVal pOutputFileName As String = "", Optional ByVal pOverWriteFile As Boolean = False, Optional ByVal pDeleteOriginalFileAfterCompression As Boolean = False) As String
            Dim lReturnValue As String = String.Empty
            If (System.IO.File.Exists(pFileName)) Then

                Dim lPath As String = System.IO.Path.GetDirectoryName(pFileName)

                Dim lFileName As String = System.IO.Path.GetFileNameWithoutExtension(pFileName)

                Dim lOutputFileName As String
                Dim lOutputFileNameWithOutExtension As String

                If (pOutputFileName <> "") Then
                    lOutputFileNameWithOutExtension = pOutputFileName
                Else
                    lOutputFileNameWithOutExtension = String.Format("{0}.zip", System.IO.Path.GetFileNameWithoutExtension(pFileName))
                End If

                If (pOutputPath <> "") Then
                    lOutputFileName = String.Format("{0}\{1}", pOutputPath, lOutputFileNameWithOutExtension)
                Else
                    lOutputFileName = String.Format("{0}\{1}", System.IO.Path.GetDirectoryName(pFileName), lOutputFileNameWithOutExtension)
                End If

                Dim lPerform As Boolean = False

                If (System.IO.File.Exists(lOutputFileName)) Then
                    If (pOverWriteFile) Then
                        lPerform = True
                    End If
                Else
                    lPerform = True
                End If

                If (lPerform) Then
                    Dim lZip As New Ionic.Zip.ZipFile
                    lZip.AddFile(pFileName)
                    lZip.Save(lOutputFileName)

                    lReturnValue = lOutputFileName
                End If

                If (pDeleteOriginalFileAfterCompression) Then
                    System.IO.File.Delete(pFileName)
                End If
            Else
                Throw New Exception(String.Format(My.Resources.ExceptionMessages.CompressFileNotFound, pFileName))
            End If

            Return lReturnValue
        End Function
    End Class
End Namespace
