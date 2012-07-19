Imports System.IO
Imports System.Configuration
Namespace Entities
    Partial Public Class Project

        Public Shared Sub PersistToFile(ByVal project As Project, ByVal pathToFile As String)
            Dim lSerializer As New Serialization.XMLSerializer(Of Project)
            System.IO.File.WriteAllText(pathToFile, lSerializer.SerializeToString(project))
        End Sub

        Public Shared Function LoadFromFile(ByVal pathToFile As String) As Project
            Dim lSerializer As New Serialization.XMLSerializer(Of Project)
            Return lSerializer.DeserializeFromString(System.IO.File.ReadAllText(pathToFile))
        End Function
    End Class
End Namespace
