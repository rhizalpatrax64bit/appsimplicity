Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.CompilerServices

Namespace Utilities
    Public Class Serialization

        ''' <summary>
        ''' Serializes an object in binary form and converts it to a string
        ''' </summary>
        ''' <param name="pObject">The instance of the object being serialized</param>
        ''' <returns>Returns the serialized instance of the object</returns>
        Public Shared Function SerializeToString(ByVal pObject As Object) As String
            Dim SS As New System.IO.MemoryStream
            Dim BF As New BinaryFormatter()
            Dim lResult As String = ""

            'Serializar el contenido de los datos a guardar
            BF.Serialize(SS, pObject)
            lResult = Convert.ToBase64String(SS.ToArray())

            Return lResult
        End Function

        ''' <summary>
        ''' Deserializes an object from a string 
        ''' </summary>
        ''' <param name="pData">The instance of the object previously serialized in a string</param>
        ''' <returns>The deserialized object instance.</returns>
        Public Shared Function DeserializeFromString(ByVal pData As String) As Object
            Dim SS As System.IO.MemoryStream
            Dim BF As New BinaryFormatter()
            Dim lResult As Object = Nothing

            Dim lBytes As Byte()
            lBytes = Convert.FromBase64String(pData)

            SS = New System.IO.MemoryStream(lBytes)

            lResult = RuntimeHelpers.GetObjectValue(BF.Deserialize(SS))
            Return lResult
        End Function
    End Class
End Namespace

