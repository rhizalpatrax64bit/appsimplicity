Namespace DataAccess.Providers

    Public Enum DataAccesModes
        ConnectedReaders
        DisconnectedDataSets
    End Enum

    ''' <summary>
    ''' The purpose of this interface is to implement classes that may function as data providers.
    ''' </summary>
    Public Interface IDataProvider

        ''' <summary>
        ''' Determines whether the instance is a transactional data provider
        ''' </summary>        
        ReadOnly Property CanHandleTransactions() As Boolean

        ''' <summary>
        ''' Determines whether the data provider can return connected data readers
        ''' </summary>        
        ReadOnly Property CanHandleConnectedReaders() As Boolean


#Region "TransactionHandling"
        ''' <summary>
        ''' Starts a transaction in the context of the data provider
        ''' </summary>
        ''' <param name="pIsolationLevel">Determines the level of isolation in transaction.</param>
        Sub BeginTransaction(ByVal pIsolationLevel As System.Data.IsolationLevel)

        ''' <summary>
        ''' Run the changes made under the context of the transaction
        ''' </summary>
        Sub CommitTransaction()

        ''' <summary>
        ''' Undo the changes made under the context of the transaction
        ''' </summary>
        Sub RollBackTransaction()
#End Region

#Region "Execute methods"
        ''' <summary>
        ''' Execute a command of data and returns a dataset
        ''' </summary>
        ''' <param name="pCommand">Represents the data request command</param>        
        Function ExecuteDataSet(ByVal pCommand As DataCommand) As System.Data.DataSet

        ''' <summary>
        ''' Execute a command of data and returns an instance of a connected data reader
        ''' </summary>
        ''' <param name="pCommand">Represents the data request command</param>        
        Function ExecuteDataReader(ByVal pCommand As DataCommand) As System.Data.Common.DbDataReader

        ''' <summary>
        ''' Execute a command of data and returns the result of a data command which results matrix is 1x1
        ''' </summary>
        ''' <param name="pCommand">Represents the data request command</param>        
        Function ExecuteScalar(ByVal pCommand As DataCommand) As Object

        ''' <summary>
        ''' Execute a command of data and returns the number of rows affected
        ''' </summary>
        ''' <param name="pCommand">Represents the data request command</param>        
        Function ExecuteNonQuery(ByVal pCommand As DataCommand) As Integer
#End Region

    End Interface
End Namespace


