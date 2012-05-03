Imports System.Data.Common

Public Class ADONetServiceProvider
    Implements IDataServiceProvider

#Region "Fields"
    Private _Connection As DbConnection
    Private _Transaction As DbTransaction
    Private _ConnectionInfo As ConnectionInfo
    Private _IsTransactionActive As Boolean = False
    Private _DBFactory As System.Data.Common.DbProviderFactory
#End Region

#Region "Properties"
    Public ReadOnly Property OperativeMode() As OperativeModes Implements IDataServiceProvider.OperativeMode
        Get
            Return OperativeModes.Connected
        End Get
    End Property

    Public ReadOnly Property IsTransactionActive() As Boolean
        Get
            Return _IsTransactionActive
        End Get
    End Property

    Public Property ConnectionInfo() As ConnectionInfo Implements IDataServiceProvider.ConnectionInfo
        Get
            Return _ConnectionInfo
        End Get
        Set(ByVal value As ConnectionInfo)
            _ConnectionInfo = value
        End Set
    End Property

    Private ReadOnly Property DBFactory() As System.Data.Common.DbProviderFactory
        Get
            If (_DBFactory Is Nothing) Then
                If (Me.ConnectionInfo Is Nothing) Then
                    Throw New Exception(My.Resources.Exceptions.CONNECTION_INFO_NOT_SET)
                Else
                    _DBFactory = ADONetDbProviderFactory.GetADONetDBFactory(Me.ConnectionInfo.ProviderName)
                End If
            End If
            Return _DBFactory
        End Get
    End Property
#End Region

#Region "Helper methods"
    Private Function GetProviderCommand(ByVal pCommand As DataCommand) As System.Data.Common.DbCommand
        Dim lReturnValue As DbCommand = Me.DBFactory.CreateCommand

        lReturnValue.CommandText = pCommand.SQLCommand
        lReturnValue.CommandType = pCommand.CommandType

        For Each lParameter As DataCommandParameter In pCommand.Parameters
            lReturnValue.Parameters.Add(Me.ConvertParameter(lParameter))
        Next

        lReturnValue.CommandTimeout = Me.ConnectionInfo.ConnectionTimeOut

        Return lReturnValue
    End Function

    Private Function ConvertParameter(ByVal pParameter As DataCommandParameter) As System.Data.Common.DbParameter
        Dim lReturnValue As DbParameter = Me.DBFactory.CreateParameter

        lReturnValue.ParameterName = String.Format("{0}", pParameter.Name)
        lReturnValue.DbType = pParameter.Type

        lReturnValue.Direction = pParameter.Direction
        lReturnValue.Value = pParameter.Value

        Return lReturnValue
    End Function
#End Region

#Region "Connection handling"
    Public Function OpenConnection() As System.Data.Common.DbConnection Implements IDataServiceProvider.OpenConnection
        If (Me._Connection Is Nothing) Then
            _Connection = Me.DBFactory.CreateConnection()
        End If

        If (Me._Connection.State = ConnectionState.Closed) Then
            Me._Connection.ConnectionString = _ConnectionInfo.ConnectionString
            Me._Connection.Open()
        End If

        Return _Connection
    End Function

#End Region

#Region "Transaction handling"
    Public Sub BeginTransaction(Optional ByVal pIsolationLevel As System.Data.IsolationLevel = IsolationLevel.Serializable) Implements IDataServiceProvider.BeginTransaction
        If Not (_IsTransactionActive) Then
            Me.OpenConnection()
            _Transaction = _Connection.BeginTransaction(pIsolationLevel)
            _IsTransactionActive = True
        End If
    End Sub

    Public Sub CommitTransaction() Implements IDataServiceProvider.CommitTransaction
        If (_IsTransactionActive) Then
            If Not (_Transaction Is Nothing) Then
                _Transaction.Commit()
            End If

            Me.CloseConnection()
            _IsTransactionActive = False
        End If
    End Sub

    Public Sub RollbackTransaction() Implements IDataServiceProvider.RollbackTransaction
        If (_IsTransactionActive) Then
            If Not (_Transaction Is Nothing) Then
                _Transaction.Rollback()
            End If

            Me.CloseConnection()
            _IsTransactionActive = False
        End If
    End Sub
#End Region

    Private Sub RethrowException(ByVal pEx As Exception)
        If Not (pEx Is Nothing) Then
            Throw pEx
        End If
    End Sub

    Public Function ExecuteDataSet(ByVal pCommand As DataCommand) As System.Data.DataSet Implements IDataServiceProvider.ExecuteDataSet
        Dim lReturnValue As New DataSet
        Dim lException As Exception = Nothing
        Dim lCommand As DbCommand

        Try
            lCommand = Me.GetProviderCommand(pCommand)
            If (Me.IsTransactionActive) Then
                lCommand.Connection = _Transaction.Connection
                lCommand.Transaction = _Transaction
            Else
                lCommand.Connection = Me.OpenConnection()
            End If

            Dim lAdapter As DbDataAdapter = DBFactory.CreateDataAdapter()
            lAdapter.SelectCommand = lCommand
            lAdapter.Fill(lReturnValue)

        Catch ex As Exception
            lException = ex
        Finally
            If Not (Me.IsTransactionActive) Then
                Me.CloseConnection()
            End If
        End Try

        RethrowException(lException)

        Return lReturnValue
    End Function

    Public Function ExecuteNonQuery(ByVal pCommand As DataCommand) As Integer Implements IDataServiceProvider.ExecuteNonQuery
        Dim lReturnValue As Integer
        Dim lException As Exception = Nothing
        Dim lCommand As DbCommand

        Try
            lCommand = Me.GetProviderCommand(pCommand)
            If (Me.IsTransactionActive) Then
                lCommand.Connection = _Transaction.Connection
                lCommand.Transaction = _Transaction
            Else
                lCommand.Connection = Me.OpenConnection()
            End If

            lReturnValue = lCommand.ExecuteNonQuery()
        Catch ex As Exception

        Finally
            If Not (Me.IsTransactionActive) Then
                Me.CloseConnection()
            End If
        End Try

        RethrowException(lException)

        Return lReturnValue
    End Function

    Public Function ExecuteResultSet(ByVal pCommand As DataCommand, Optional ByVal pCommandBehavior As System.Data.CommandBehavior = System.Data.CommandBehavior.CloseConnection) As ResultSet Implements IDataServiceProvider.ExecuteResultSet
        Dim lReturnValue As ResultSet = Nothing
        Dim lReader As DbDataReader = Nothing
        Dim lException As Exception = Nothing
        Dim lCommand As DbCommand

        Try
            lCommand = Me.GetProviderCommand(pCommand)
            If (Me.IsTransactionActive) Then
                lCommand.Connection = _Transaction.Connection
                lCommand.Transaction = _Transaction
            Else
                lCommand.Connection = Me.OpenConnection()

            End If
            lReader = lCommand.ExecuteReader(pCommandBehavior)
        Catch ex As Exception
            lException = ex
        End Try

        If Not (lReader Is Nothing) Then
            lReturnValue = New ResultSet(lReader, pCommandBehavior, Me)
        End If

        RethrowException(lException)

        Return lReturnValue
    End Function

    Public Function ExecuteScalar(ByVal pCommand As DataCommand) As Object Implements IDataServiceProvider.ExecuteScalar
        Dim lReturnValue As Object = Nothing
        Dim lException As Exception = Nothing
        Dim lCommand As DbCommand

        Try
            lCommand = Me.GetProviderCommand(pCommand)
            If (Me.IsTransactionActive) Then
                lCommand.Connection = _Transaction.Connection
                lCommand.Transaction = _Transaction
            Else
                lCommand.Connection = Me.OpenConnection()
            End If

            lReturnValue = lCommand.ExecuteScalar()
        Catch ex As Exception
            lException = ex
        Finally
            If Not (Me.IsTransactionActive) Then
                Me.CloseConnection()
            End If
        End Try

        RethrowException(lException)

        Return lReturnValue
    End Function

#Region "Constructor"
    Public Sub New(pConnectionInfo As ConnectionInfo)
        _ConnectionInfo = pConnectionInfo
    End Sub

    Public Sub New()
        MyBase.New()
    End Sub
#End Region

    Public Sub CloseConnection() Implements IDataServiceProvider.CloseConnection
        If Not (_Connection Is Nothing) Then
            If Not (IsTransactionActive) Then
                If (_Connection.State <> ConnectionState.Closed) Then
                    _Connection.Close()
                End If
                _Connection.Dispose()
                _Connection = Nothing
            End If
        End If
    End Sub
End Class
