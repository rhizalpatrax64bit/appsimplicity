Namespace Serialization
    Public Class XMLSerializer(Of T)

        ''' <summary>
        ''' Serializes an object to a string in xml format.
        ''' </summary>
        ''' <param name="pObject">The instance</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SerializeToString(ByVal pObject As T) As String
            Dim lSW As New System.IO.StringWriter()
            Dim lSerializer As New System.Xml.Serialization.XmlSerializer(pObject.GetType())
            lSerializer.Serialize(lSW, pObject)
            lSW.Flush()

            Return lSW.ToString()
        End Function

        Public Function DeserializeFromString(ByVal pXML As String) As T
            Dim lReturnValue As T = Nothing
            Dim lSR As New System.IO.StringReader(pXML)
            Dim lSerializer As New System.Xml.Serialization.XmlSerializer(GetType(T))

            lReturnValue = CType(lSerializer.Deserialize(lSR), T)

            Return lReturnValue
        End Function

    End Class
End Namespace
