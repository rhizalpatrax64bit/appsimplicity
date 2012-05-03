Namespace Engine
    Public MustInherit Class CodeGenerationTemplate(Of T)

        MustOverride ReadOnly Property OverwriteIfExists() As Boolean

        MustOverride Function GetOutputFileName(ByVal pEntity As T)

        MustOverride Sub WriteCode(ByVal pEntity As T, ByVal pOutput As System.IO.StreamWriter)

        Public Sub RunTemplate(ByVal pEntity As T)
            Dim lOutput As System.IO.StreamWriter = Nothing
            Try
                Dim lFileName As String = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), Me.GetOutputFileName(pEntity))

                If Not (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(lFileName))) Then
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(lFileName))
                End If

                Dim lWriteFile As Boolean = True

                If Not (OverwriteIfExists) Then
                    If (System.IO.File.Exists(lFileName)) Then
                        lWriteFile = False
                    End If
                End If

                If (lWriteFile) Then
                    Console.WriteLine(Me.GetOutputFileName(pEntity))
                    lOutput = New System.IO.StreamWriter(lFileName)
                    WriteCode(pEntity, lOutput)
                End If

            Catch ex As Exception
                Console.WriteLine("Something went wrong trying to generate code output:")
                Console.WriteLine(ex.Message)
                Console.WriteLine("Stack trace:")
                Console.WriteLine(ex.StackTrace)
            Finally
                If Not (lOutput Is Nothing) Then
                    lOutput.Flush()
                    lOutput.Close()
                    lOutput.Dispose()
                End If
            End Try
        End Sub
    End Class
End Namespace
