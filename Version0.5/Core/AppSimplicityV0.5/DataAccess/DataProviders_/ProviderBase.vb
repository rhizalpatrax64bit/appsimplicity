Imports System.Data.Common

Namespace DataAccess.Providers
    Public MustInherit Class ProviderBase
        Public Enum DataAccesModes
            ConnectedReaders
            DisconnectedDataSets
        End Enum

        Protected _DataAccessMode As DataAccesModes = DataAccesModes.ConnectedReaders
        ''' <summary>
        ''' Obtiene el modo de acceso del proveedor de acceso a datos
        ''' </summary>
        Public ReadOnly Property DataAccessMode() As DataAccesModes
            Get
                Return _DataAccessMode
            End Get
        End Property

        Private _CanHandleTransactions As Boolean

        Protected _Factory As DataService
        Public ReadOnly Property Factory() As DataService
            Get
                If _Factory Is Nothing Then
                    _Factory = New DataService(Me.GetDBFactory())
                End If
                Return _Factory
            End Get
        End Property

        Public ReadOnly Property IsTransactionActive() As Boolean
            Get
                Dim lResult As Boolean = False

                If Not (Me.Transaction Is Nothing) Then
                    If (Me.Transaction.Connection.State = ConnectionState.Open) Then
                        lResult = True
                    End If
                End If

                Return lResult
            End Get
        End Property

        Private _Connection As DbConnection

        Private _Transaction As DbTransaction
        Public Property Transaction() As DbTransaction
            Get
                Return _Transaction
            End Get
            Set(ByVal value As DbTransaction)
                _Transaction = value
            End Set
        End Property

        Protected _DBFactory As System.Data.Common.DbProviderFactory
        Public ReadOnly Property DBFactory() As System.Data.Common.DbProviderFactory
            Get
                Return _DBFactory
            End Get
        End Property

        Private _DataSource As DataSource
        ''' <summary>
        ''' Obtiene la instancia de la fuente de datos asociada al proveedor
        ''' </summary>        
        Public ReadOnly Property DataSource() As DataSource
            Get
                Return _DataSource
            End Get
        End Property

#Region "Manejo de Transacciones"
        Public Sub BeginTransaction(Optional ByVal pIsolationLevel As System.Data.IsolationLevel = IsolationLevel.ReadUncommitted)
            If (Me._CanHandleTransactions) Then
                _Connection = Me.DBFactory.CreateConnection()
                _Connection.ConnectionString = Me.DataSource.ConnectionString
                _Connection.Open()

                Me.Transaction = _Connection.BeginTransaction(pIsolationLevel)
            End If
        End Sub

        Public Sub CommitTransaction()
            If (Me._CanHandleTransactions) Then
                Me.Transaction.Commit()
                Me._Connection.Close()
                Me._Connection.Dispose()

                Me.Transaction = Nothing
            End If
        End Sub

        Public Sub RollBackTransaction()
            If (Me._CanHandleTransactions) Then
                Me.Transaction.Rollback()
                Me._Connection.Close()
                Me._Connection.Dispose()

                Me.Transaction = Nothing
            End If
        End Sub
#End Region

#Region "Métodos de Acceso a Datos"
        Public Overridable Function ExecuteScalar(ByVal pCommandText As String, ByVal pCommandType As System.Data.CommandType, ByVal pParameters As List(Of DbParameter)) As Object
            Dim lResult As Object = Nothing
            Dim lUseTransaction As Boolean = False

            If (Me._CanHandleTransactions) Then
                If Me.IsTransactionActive Then
                    lUseTransaction = True
                End If
            End If

            If (lUseTransaction) Then
                lResult = Me.Factory.ExecuteScalar(Me.Transaction, pCommandText, pCommandType, pParameters)
            Else
                lResult = Me.Factory.ExecuteScalar(Me.DataSource, pCommandText, pCommandType, pParameters)
            End If

            Return lResult
        End Function

        Public Overridable Function ExecuteDataset(ByVal pCommandText As String, ByVal pCommandType As System.Data.CommandType, ByVal pParameters As List(Of DbParameter)) As DataSet
            Dim lResult As DataSet = Nothing
            Dim lUseTransaction As Boolean = False

            If (Me._CanHandleTransactions) Then
                If Me.IsTransactionActive Then
                    lUseTransaction = True
                End If
            End If

            If (lUseTransaction) Then
                lResult = Me.Factory.ExecuteDataset(Me.Transaction, pCommandText, pCommandType, pParameters)
            Else
                lResult = Me.Factory.ExecuteDataset(Me.DataSource, pCommandText, pCommandType, pParameters)
            End If

            Return lResult
        End Function

        Public Overridable Function ExecuteNonQuery(ByVal pCommandText As String, ByVal pCommandType As System.Data.CommandType, ByVal pParameters As List(Of DbParameter)) As Integer
            Dim lResult As Integer
            Dim lUseTransaction As Boolean = False

            If (Me._CanHandleTransactions) Then
                If Me.IsTransactionActive Then
                    lUseTransaction = True
                End If
            End If

            If (lUseTransaction) Then
                lResult = Me.Factory.ExecuteNonQuery(Me.Transaction, pCommandText, pCommandType, pParameters)
            Else
                lResult = Me.Factory.ExecuteNonQuery(Me.DataSource, pCommandText, pCommandType, pParameters)
            End If

            Return lResult
        End Function

        Public Overridable Function ExecuteDataReader(ByVal pCommandText As String, ByVal pCommandType As System.Data.CommandType, ByVal pParameters As List(Of DbParameter)) As DbDataReader
            If (Me.DataAccessMode = DataAccesModes.DisconnectedDataSets) Then
                Throw New Exception(String.Format("El proveedor para la fuente de datos [{0}] solo puede funcionar con accesos desconectados.", Me._DataSource.Name))
            End If

            Dim lResult As DbDataReader = Nothing
            Dim lUseTransaction As Boolean = False

            If (Me._CanHandleTransactions) Then
                If Me.IsTransactionActive Then
                    lUseTransaction = True
                End If
            End If

            If (lUseTransaction) Then
                lResult = Me.Factory.ExecuteDataReader(Me.Transaction, pCommandText, pCommandType, pParameters, CommandBehavior.Default)
            Else
                lResult = Me.Factory.ExecuteDataReader(Me.DataSource, pCommandText, pCommandType, pParameters, CommandBehavior.CloseConnection)
            End If

            Return lResult
        End Function

        Public MustOverride Function GetDBFactory() As System.Data.Common.DbProviderFactory
#End Region

        Public Function GetParameter(ByVal pParameterName As String, ByVal pValue As Object) As System.Data.Common.DbParameter
            Dim lDBParameter As System.Data.Common.DbParameter = Me.DBFactory.CreateParameter()

            lDBParameter.ParameterName = pParameterName
            lDBParameter.Value = pValue

            Return lDBParameter
        End Function

#Region ".ctors"
        Public Sub New(ByVal pDataSource As DataSource, Optional ByVal pCanHandleTransactions As Boolean = True, Optional ByVal pDataAccessMode As DataAccesModes = DataAccesModes.ConnectedReaders)
            _DataSource = pDataSource
            _DBFactory = GetDBFactory()
            _CanHandleTransactions = pCanHandleTransactions
            _DataAccessMode = pDataAccessMode
        End Sub
#End Region


    End Class

End Namespace
