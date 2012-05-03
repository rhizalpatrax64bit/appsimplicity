Public Interface IConnectionProvider

    Function GetConnectionInfo(ByVal pConnectionName As String) As ConnectionInfo

    Function GetAllConnections() As List(Of ConnectionInfo)

End Interface
