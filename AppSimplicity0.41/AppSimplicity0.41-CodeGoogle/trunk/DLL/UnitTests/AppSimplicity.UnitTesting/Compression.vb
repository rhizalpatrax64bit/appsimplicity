Imports NUnit.Framework

<TestFixture()> _
Public Class Compression

    <Test()> _
    Public Sub ZipToFile()
        Dim lTestResult As Boolean = False
        Dim lFileName As String = String.Format("{0}\42b93dcd-1589-4e55-8a93-367bf0de048a.xls", System.IO.Directory.GetCurrentDirectory())

        Console.WriteLine(String.Format("Buscando el archivo en :{0}", lFileName))

        If (System.IO.File.Exists(lFileName)) Then
            Dim lOutputFileName As String = AppSimplicity.Utilities.Compression.ZipFile(lFileName, , "CompressedFile.zip", , True)

            If (System.IO.File.Exists(lOutputFileName)) Then
                lTestResult = True
            End If
        End If

        Assert.IsTrue(lTestResult)
    End Sub

End Class
