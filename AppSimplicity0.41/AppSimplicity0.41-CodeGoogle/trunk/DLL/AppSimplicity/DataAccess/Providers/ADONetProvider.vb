Imports System.Data.Common

Namespace DataAccess.Providers
    Public MustInherit Class ADONetProvider
        Implements IDataProvider

        Public ReadOnly Property CanHandleConnectedReaders() As Boolean Implements IDataProvider.CanHandleConnectedReaders
            Get
                Return True
            End Get
        End Property

        Private _DataSource As DataSource
        Public ReadOnly Property DataSource() As DataSource
            Get
                Return _DataSource
            End Get
        End Property

        Private _DBFactory As DbProviderFactory
        Protected ReadOnly Property DBFactory() As DbProviderFactory
            Get
                If _DBFactory Is Nothing Then
                    _DBFactory = Me.GetFactory()
                End If
                Return _DBFactory
            End Get
        End Property

        Public Enum DataOperations
            ExecuteScalar
            ExecuteDataSet
            ExecuteNonQuery
            ExecuteDataReader
        End Enum

        Public Overridable ReadOnly Property CanHandleTransactions() As Boolean Implements IDataProvider.CanHandleTransactions
            Get
                Return True
            End Get
        End Property

        Public Overridable ReadOnly Property DataAccessMode() As DataAccesModes
            Get
                Return DataAccesModes.DisconnectedDataSets
            End Get
        End Property

        Private _Connection As System.Data.Common.DbConnection = Nothing
        Protected ReadOnly Property Connection() As System.Data.Common.DbConnection
            Get
                If _Connection Is Nothing Then
                    _Connection = Me.DBFactory.CreateConnection
                    _Connection.ConnectionString = Me.DataSource.ConnectionString
                End If
                Return _Connection
            End Get
        End Property

        Private _Transaction As DbTransaction = Nothing
        Public Property Transaction() As DbTransaction
            Get
                Return _Transaction
            End Get
            Set(ByVal value As DbTransaction)
                _Transaction = value
            End Set
        End Property

        Public ReadOnly Property IsTransactionActive() As Boolean
            Get
                Dim lResult As Boolean = False

                If Not (Me.Transaction Is Nothing) Then
                    If Not (Me.Transaction.Connection Is Nothing) Then
                        If (Me.Transaction.Connection.State = ConnectionState.Open) Then
                            lResult = True
                        End If
                    End If
                End If

                Return lResult
            End Get
        End Property

        Public Sub New(ByVal pDataSource As DataSource)
            Me._DataSource = pDataSource
        End Sub

        Public MustOverride Function GetFactory() As DbProviderFactory

#Region "Command functions"
        Public Function CreateCommand(ByVal pSQLStatement As String, Optional ByVal pType As System.Data.CommandType = CommandType.Text) As DataCommand
            Dim lCommand As New DataCommand
            lCommand.SQLCommand = pSQLStatement
            lCommand.CommandType = pType
            Return lCommand
        End Function

        Public Function CreateSPCommand(ByVal pSQLStatement As String) As DataCommand
            Dim lCommand As DataCommand = Me.CreateCommand(pSQLStatement, CommandType.StoredProcedure)
            Return lCommand
        End Function
#End Region

#Region "DB Agnostic Methods"
        Private Function CreateDBParameter(ByVal pParameter As DataCommandParameter) As DbParameter
            Dim lReturnValue As DbParameter
            lReturnValue = Me.DBFactory.CreateParameter

            lReturnValue.ParameterName = pParameter.Name
            lReturnValue.Value = pParameter.Value
            lReturnValue.Direction = ParameterDirection.Input

            'TODO: Determinar el tipo del valor del parametro:
            'lReturnValue.DbType = DbType.AnsiString

            Return lReturnValue
        End Function

        Private Function Execute(ByVal pCommand As DataCommand, ByVal pOperation As DataOperations) As Object
            Dim lEveryhingOK As Boolean = True
            Dim lResult As Object = Nothing
            Dim lUseTransaction As Boolean = False
            Dim lDataEx As Exception = Nothing
            Dim lCloseConnectionBeforeLeave As Boolean = True

            'Evaluar si existe una transaccion activa
            If (Me.CanHandleTransactions) Then
                If Me.IsTransactionActive Then
                    lUseTransaction = True
                End If
            End If

            Try
                Dim lCommand As DbCommand = Nothing

                'si existe una transaccion activa, se usará:
                If lUseTransaction Then
                    lCommand = Me.Transaction.Connection.CreateCommand()
                    lCommand.Transaction = Me.Transaction
                Else
                    OpenConnection()
                    lCommand = Me.Connection.CreateCommand()
                End If

                lCommand.CommandText = pCommand.SQLCommand
                lCommand.CommandType = pCommand.CommandType
                lCommand.CommandTimeout = Me.DataSource.ConnectionTimeOut

                For Each lParameter As DataCommandParameter In pCommand.Parameters
                    lCommand.Parameters.Add(Me.CreateDBParameter(lParameter))
                Next

                'Ejecutar la operación correspondiente:
                Select Case pOperation
                    Case DataOperations.ExecuteScalar
                        lResult = lCommand.ExecuteScalar()

                    Case DataOperations.ExecuteDataReader
                        'Si existe una transacción activa que no cierre la conexión:
                        If (Me.IsTransactionActive) Then
                            lResult = lCommand.ExecuteReader()
                        Else
                            lResult = lCommand.ExecuteReader(CommandBehavior.CloseConnection)
                        End If

                        If Not (lResult Is Nothing) Then
                            If (CType(lResult, System.Data.Common.DbDataReader).HasRows) Then
                                lCloseConnectionBeforeLeave = False
                            End If
                        End If

                    Case DataOperations.ExecuteNonQuery
                        lResult = lCommand.ExecuteNonQuery

                    Case DataOperations.ExecuteDataSet
                        Dim lDS As New DataSet
                        Dim lAdapter As DbDataAdapter
                        lAdapter = Me.DBFactory.CreateDataAdapter
                        lAdapter.SelectCommand = lCommand
                        lAdapter.Fill(lDS)

                        lResult = lDS
                End Select

            Catch ex As Exception
                lEveryhingOK = False
                lDataEx = ex
            Finally
                If (Not lUseTransaction) Then
                    If (lCloseConnectionBeforeLeave) Then
                        CloseConnection()
                    End If
                End If
            End Try

            If Not (lEveryhingOK) Then
                Throw (lDataEx)
            End If

            Return lResult
        End Function
#End Region

#Region "Public Data Access Methods"
        Public Overridable Function ExecuteScalar(ByVal pCommand As DataCommand) As Object Implements IDataProvider.ExecuteScalar
            Dim lResult As Object = Nothing

            lResult = Me.Execute(pCommand, DataOperations.ExecuteScalar)

            Return lResult
        End Function

        Public Overridable Function ExecuteDataset(ByVal pCommand As DataCommand) As DataSet Implements IDataProvider.ExecuteDataSet
            Dim lResult As DataSet = Nothing

            lResult = Me.Execute(pCommand, DataOperations.ExecuteDataSet)

            Return lResult
        End Function

        Public Overridable Function ExecuteNonQuery(ByVal pCommand As DataCommand) As Integer Implements IDataProvider.ExecuteNonQuery
            Dim lResult As Integer

            lResult = Me.Execute(pCommand, DataOperations.ExecuteNonQuery)

            Return lResult
        End Function

        Public Overridable Function ExecuteDataReader(ByVal pCommand As DataCommand) As DbDataReader Implements IDataProvider.ExecuteDataReader
            Dim lResult As DbDataReader = Nothing

            lResult = Me.Execute(pCommand, DataOperations.ExecuteDataReader)

            Return lResult
        End Function
#End Region

#Region "Transaction Handling"
        Private Sub OpenConnection()
            Connection.Open()
        End Sub

        Private Sub CloseConnection()
            If (Connection.State <> ConnectionState.Closed) Then
                Connection.Close()
            End If
        End Sub

        Public Sub BeginTransaction(ByVal pIsolationLevel As System.Data.IsolationLevel) Implements IDataProvider.BeginTransaction
            If (Me.CanHandleTransactions) Then
                If Not (Me.IsTransactionActive) Then
                    OpenConnection()
                    Me.Transaction = Connection.BeginTransaction(pIsolationLevel)
                End If
            End If
        End Sub

        Public Sub CommitTransaction() Implements IDataProvider.CommitTransaction
            If (Me.CanHandleTransactions) Then
                If (Me.IsTransactionActive) Then
                    Me.Transaction.Commit()
                    Me.CloseConnection()
                    Me.Transaction = Nothing
                End If
            End If
        End Sub

        Public Sub RollBackTransaction() Implements IDataProvider.RollBackTransaction
            If (Me.CanHandleTransactions) Then
                If (Me.IsTransactionActive) Then
                    Me.Transaction.Rollback()
                    Me.CloseConnection()
                    Me.Transaction = Nothing
                End If
            End If
        End Sub
#End Region
    End Class
End Namespace
