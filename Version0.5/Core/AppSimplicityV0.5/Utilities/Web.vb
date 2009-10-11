Namespace Utilities
    Public Class Web
        ''' <summary>
        ''' Sends a file to a page response.
        ''' </summary>
        ''' <param name="pResponse">The current page response object</param>
        ''' <param name="pFileAbsolutePath">The file to transmit</param>
        ''' <param name="pContentTypeString">The Mime type for file.  
        ''' This parameter is required only if file extension is NOT one of the following: doc, pdf, zip, xls, xml, txt, csv</param>
        ''' <param name="pDownloadFileName">This parameter is used to specify the filename in the download dialog.
        ''' If this parameter is omited then the original filename will be used.
        ''' </param>
        Public Shared Sub TransmitFile(ByVal pResponse As System.Web.HttpResponse, ByVal pFileAbsolutePath As String, Optional ByVal pContentTypeString As String = "", Optional ByVal pDownloadFileName As String = "")
            If Not (System.IO.File.Exists(pFileAbsolutePath)) Then
                Throw New Exception(String.Format("No se puede transmitir el archivo ""{0}"".  El archivo no existe.", pFileAbsolutePath))
            End If

            pResponse.Clear()

            Dim lMimeExtractor As New MimeExtractor(pFileAbsolutePath)
            Dim lFileName As String = String.Empty

            If (pDownloadFileName <> String.Empty) Then
                lFileName = pDownloadFileName
            Else
                lFileName = System.IO.Path.GetFileName(pFileAbsolutePath)
            End If

            If (pContentTypeString <> String.Empty) Then
                pResponse.ContentType = pContentTypeString
            Else
                pResponse.ContentType = MimeExtractor.GetMimeTypeString(pFileAbsolutePath)
            End If

            pResponse.AddHeader("content-disposition", String.Format("attachment; filename={0}", lFileName))
            pResponse.TransmitFile(pFileAbsolutePath)
            pResponse.End()
        End Sub

        Private Class MimeExtractor
            Private _FileAbsolutePath As String

            Public ReadOnly Property MimeType() As String
                Get
                    Return GetMimeType()
                End Get
            End Property

            Private ReadOnly Property Extension() As String
                Get
                    Return System.IO.Path.GetExtension(Me._FileAbsolutePath).ToLower
                End Get
            End Property

            Private Function GetMimeType() As String
                Dim lReturnValue As String = ""

                Select Case Extension
                    Case "pdf"
                        lReturnValue = "application/pdf"
                    Case "doc"
                        lReturnValue = "application/msword"
                    Case "xls"
                        lReturnValue = "application/msexcel"
                    Case "xml"
                        lReturnValue = "text/plain"
                    Case "zip"
                        lReturnValue = "application/zip"
                    Case "csv"
                        lReturnValue = "text/plain"
                    Case "txt"
                        lReturnValue = "text/plain"
                End Select

                Return lReturnValue
            End Function

            Public Sub New(ByVal pFileAbsolutePath As String)
                _FileAbsolutePath = pFileAbsolutePath
            End Sub

            Public Shared Function GetMimeTypeString(ByVal pFileAbsolutePath As String) As String
                Dim lMime As New MimeExtractor(pFileAbsolutePath)
                Return lMime.MimeType
            End Function
        End Class
    End Class
End Namespace

