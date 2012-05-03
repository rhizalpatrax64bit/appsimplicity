Namespace IO
    Public Class File
        ''' <summary>
        ''' Writes a string to a given file.
        ''' </summary>
        ''' <param name="absolutePath">The full path to the file to be written.</param>
        ''' <param name="fileText">The content to be written to file.</param>
        Public Shared Sub WriteToFile(ByVal absolutePath As String, ByVal fileText As String, Optional createFile As Boolean = True)
            If (createFile) Then
                Using sw As System.IO.StreamWriter = System.IO.File.CreateText(absolutePath)
                    sw.Write(fileText)
                End Using
            Else
                Using sw As System.IO.StreamWriter = New System.IO.StreamWriter(absolutePath, False)
                    sw.Write(fileText)
                End Using
            End If
        End Sub

        ''' <summary>
        ''' Reads a text file and returns its contents
        ''' </summary>
        ''' <param name="absolutePath">The full path to the file to be read.</param>
        ''' <returns>The file content in a string.</returns>
        Public Shared Function GetFileText(ByVal absolutePath As String) As String
            Using sr As System.IO.StreamReader = New System.IO.StreamReader(absolutePath)
                Return sr.ReadToEnd
            End Using
        End Function
    End Class
End Namespace
