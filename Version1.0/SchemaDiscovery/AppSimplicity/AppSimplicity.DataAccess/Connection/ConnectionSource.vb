Public Class ConnectionSource
    Public Shared Function GetConnection(pConnectionName As String) As ConnectionInfo
        Dim lConfig As New ConfigurationSourceProvider()
        Return lConfig.GetConnectionInfo(pConnectionName)
    End Function

    Public Shared Function GetAllConnections() As List(Of ConnectionInfo)
        Dim lConfig As New ConfigurationSourceProvider()
        Return lConfig.GetAllConnections()
    End Function
End Class