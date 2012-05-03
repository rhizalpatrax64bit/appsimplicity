Imports System.Data

Public Enum OperativeModes
    ''' <summary>
    ''' Specifies if provider can persist data accross tiers.
    ''' </summary>
    Connected
    ''' <summary>
    ''' Provider can not persist data across tiers (can not handle transactions and connected datareaders. Connected operations are not allowed).
    ''' </summary>
    Disconnected
End Enum
Public Interface IDataServiceProvider

    Property ConnectionInfo() As ConnectionInfo

    ReadOnly Property OperativeMode() As OperativeModes

#Region "Transaction handling"
    Sub BeginTransaction(optional ByVal pIsolationLevel As IsolationLevel =IsolationLevel.Serializable)

    Sub CommitTransaction()

    Sub RollbackTransaction()

    Function OpenConnection() As System.Data.Common.DbConnection

    Sub CloseConnection()
#End Region

#Region "Execute methods"
    Function ExecuteDataSet(ByVal pCommand As DataCommand) As DataSet

    Function ExecuteResultSet(ByVal pCommand As DataCommand, Optional ByVal pCommandBehavior As CommandBehavior = CommandBehavior.CloseConnection) As ResultSet

    Function ExecuteNonQuery(ByVal pCommand As DataCommand) As Integer

    Function ExecuteScalar(ByVal pCommand As DataCommand) As Object
#End Region

End Interface
