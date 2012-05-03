Public Class DataService
    Implements IDisposable

    Private _DataServiceProvider As IDataServiceProvider
    Public ReadOnly Property ConnectionInfo() As ConnectionInfo
        Get
            Return Me._DataServiceProvider.ConnectionInfo
        End Get
    End Property

    ''' <summary>
    ''' Initializes the data service provider using a connection string from local app.config/web.config file.
    ''' </summary>
    ''' <param name="pDataServiceProvider">The instance of a custom data service provider.</param>
    Public Sub New(ByVal pDataServiceProvider As IDataServiceProvider)
        _DataServiceProvider = pDataServiceProvider
    End Sub

    ''' <summary>
    ''' Initializes the data service provider using a connection string from local app.config/web.config file.
    ''' </summary>
    ''' <param name="pDataSourceName">The name of the connection string.</param>
    Public Sub New(pDataSourceName As String)
        _DataServiceProvider = New ADONetServiceProvider(ConnectionSource.GetConnection(pDataSourceName))
    End Sub

    ''' <summary>
    ''' Initializes the data service provider using a previously loaded connectionInfo instance.
    ''' </summary>
    ''' <param name="connection">The previously loaded connectionInfo object</param>
    Public Sub New(connection As ConnectionInfo)
        _DataServiceProvider = New ADONetServiceProvider(connection)
    End Sub

#Region "RunCommand"
    Public Function RunCommand(ByVal pCommand As DataCommand) As DataCommandExecutor
        Return New DataCommandExecutor(pCommand, _DataServiceProvider)
    End Function

    Public Function RunCommand(ByVal pCommand As String) As DataCommandExecutor
        Dim lCommand As New DataCommand(pCommand, CommandType.Text)
        Return New DataCommandExecutor(lCommand, _DataServiceProvider)
    End Function

    Public Function RunCommand(ByVal pCommand As String, ByVal pType As System.Data.CommandType) As DataCommandExecutor
        Dim lCommand As New DataCommand(pCommand, pType)
        Return New DataCommandExecutor(lCommand, _DataServiceProvider)
    End Function

    Public Function RunCommand(ByVal pCommand As String, ByVal pType As System.Data.CommandType, ByVal pParameters As List(Of DataCommandParameter)) As DataCommandExecutor
        Dim lCommand As New DataCommand(pCommand, pType)
        lCommand.Parameters.AddRange(pParameters)
        Return New DataCommandExecutor(lCommand, _DataServiceProvider)
    End Function

#Region "CreateCommand"
    Public Function CreateCommand(ByVal pCommand As String) As DataCommand
        Return CreateCommand(pCommand, CommandType.Text)
    End Function

    Public Function CreateCommand(ByVal pCommand As String, ByVal pType As System.Data.CommandType) As DataCommand
        Dim lReturnValue As New DataCommand(pCommand, pType)

        lReturnValue.SetDataService(Me)

        Return lReturnValue
    End Function
#End Region

#Region "CreateStoredProcedure"
    Public Function CreateStoredProcedure(ByVal pCommand As String) As DataCommand
        Dim lCommand As New DataCommand

        lCommand.CommandType = CommandType.StoredProcedure
        lCommand.SetDataService(Me)

        Return lCommand
    End Function
#End Region

#End Region

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                If Not (Me._DataServiceProvider Is Nothing) Then
                    Me._DataServiceProvider.CloseConnection()
                End If
            End If
        End If
        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
