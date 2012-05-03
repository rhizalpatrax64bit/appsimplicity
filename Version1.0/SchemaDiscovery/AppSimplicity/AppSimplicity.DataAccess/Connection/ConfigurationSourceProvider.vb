Imports AppSimplicity.DataAccess
Imports System.Configuration
Imports System.IO

Public Class ConfigurationSourceProvider
    Implements IConnectionProvider

    Private Function GetConnectionInfoFromSettings(ByVal pCS As ConnectionStringSettings) As ConnectionInfo
        Dim lReturnValue As ConnectionInfo = Nothing

        If Not (pCS Is Nothing) Then
            lReturnValue = New ConnectionInfo
            lReturnValue.DataSourceName = pCS.Name
            lReturnValue.ConnectionString = pCS.ConnectionString
            lReturnValue.ProviderName = pCS.ProviderName
            lReturnValue.ConnectionTimeOut = 6000
        End If

        Return lReturnValue
    End Function

    Public Function GetConnectionInfo(ByVal pConnectionName As String) As ConnectionInfo Implements IConnectionProvider.GetConnectionInfo
        Dim lReturnValue As ConnectionInfo = Nothing
        lReturnValue = Me.GetConnectionInfoFromSettings(AppSimplicity.Configuration.ConnectionSettings.GetConnection(pConnectionName))
        Return lReturnValue
    End Function

    Public Function GetAllConnections() As System.Collections.Generic.List(Of ConnectionInfo) Implements IConnectionProvider.GetAllConnections
        Dim lReturnValue As New List(Of ConnectionInfo)

        For Each lCS As ConnectionStringSettings In AppSimplicity.Configuration.ConnectionSettings.GetAllConnections()
            lReturnValue.Add(Me.GetConnectionInfoFromSettings(lCS))
        Next

        Return lReturnValue
    End Function

End Class
