Imports System.Data.Common

Public MustInherit Class EntityDataMapper(Of T)

    Private _DataSourceName As String
    Private _ConnectionInfo As AppSimplicity.DataAccess.ConnectionInfo
    Private ReadOnly Property ConnectionInfo As AppSimplicity.DataAccess.ConnectionInfo
        Get
            If (_ConnectionInfo Is Nothing) Then
                _ConnectionInfo = AppSimplicity.DataAccess.ConnectionSource.GetConnection(_DataSourceName)
            End If
            Return _ConnectionInfo
        End Get
    End Property
    MustOverride Function LoadInstance(ByVal dbRow As AppSimplicity.DataAccess.ResultSetRow) As T

    Public Function FetchFirst(ByVal command As AppSimplicity.DataAccess.DataCommand) As T
        Dim lService As New AppSimplicity.DataAccess.DataService(ConnectionInfo)
        Dim lReturnValue As T = Nothing

        For Each lRow As AppSimplicity.DataAccess.ResultSetRow In lService.RunCommand(command).ExecuteResultSet
            lReturnValue = LoadInstance(lRow)
            Exit For
        Next

        Return lReturnValue
    End Function

    Public Function FetchList(ByVal command As AppSimplicity.DataAccess.DataCommand) As List(Of T)
        Dim lReturnValue As New List(Of T)

        Dim lService As New AppSimplicity.DataAccess.DataService(ConnectionInfo)

        For Each lRow As AppSimplicity.DataAccess.ResultSetRow In lService.RunCommand(command).ExecuteResultSet
            Dim lItem As T = LoadInstance(lRow)
            lReturnValue.Add(lItem)
        Next

        Return lReturnValue
    End Function

    Public Sub New(ByVal dataSourceName As String)
        _DataSourceName = dataSourceName
    End Sub

End Class
