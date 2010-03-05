Imports AppSimplicity
Namespace DataAccess.Providers
    Public Class RemoteWSProvider
        Implements DataAccess.Providers.IDataProvider

        Public ReadOnly Property CanHandleTransactions() As Boolean Implements IDataProvider.CanHandleTransactions
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property CanHandleConnectedReaders() As Boolean Implements IDataProvider.CanHandleConnectedReaders
            Get
                Return False
            End Get
        End Property

        Private _DataSource As DataAccess.DataSource
        Private ReadOnly Property DataSource() As DataAccess.DataSource
            Get
                Return _DataSource
            End Get
        End Property

        Private _RemoteDataService As RemoteDataService.DataService
        Protected ReadOnly Property RemoteDataService() As RemoteDataService.DataService
            Get
                If (_RemoteDataService Is Nothing) Then
                    _RemoteDataService = New RemoteDataService.DataService

                    _RemoteDataService.Url = Me.DataSource.ConnectionString
                End If
                Return _RemoteDataService
            End Get
        End Property

#Region "Transaction Handling"
        Public Sub BeginTransaction(ByVal pIsolationLevel As System.Data.IsolationLevel) Implements IDataProvider.BeginTransaction
            'Just do nothing
        End Sub

        Public Sub CommitTransaction() Implements IDataProvider.CommitTransaction
            'Just do nothing
        End Sub

        Public Sub RollBackTransaction() Implements IDataProvider.RollBackTransaction
            'Just do nothing
        End Sub
#End Region

        Private Function GetTransportCommand(ByVal pCommand As DataCommand) As RemoteDataService.DataCommand
            Dim lRemoteCommand As New RemoteDataService.DataCommand
            Dim lParameters As New List(Of RemoteDataService.DataCommandParameter)

            Select Case (pCommand.CommandType)
                Case CommandType.StoredProcedure
                    lRemoteCommand.CommandType = AppSimplicity.RemoteDataService.CommandType.StoredProcedure
                Case CommandType.Text
                    lRemoteCommand.CommandType = AppSimplicity.RemoteDataService.CommandType.Text
                Case CommandType.TableDirect
                    lRemoteCommand.CommandType = AppSimplicity.RemoteDataService.CommandType.TableDirect
            End Select

            lRemoteCommand.SQLCommand = pCommand.SQLCommand

            For Each lParameter As DataAccess.DataCommandParameter In pCommand.Parameters
                Dim lDataParameter As New RemoteDataService.DataCommandParameter

                lDataParameter.Name = lParameter.Name
                lDataParameter.Value = lParameter.Value

                lParameters.Add(lDataParameter)
            Next

            lRemoteCommand.Parameters = lParameters.ToArray

            Return lRemoteCommand
        End Function

        Public Function ExecuteDataReader(ByVal pCommand As DataCommand) As System.Data.Common.DbDataReader Implements IDataProvider.ExecuteDataReader
            Throw New NotImplementedException
        End Function

        Public Function ExecuteDataSet(ByVal pCommand As DataAccess.DataCommand) As System.Data.DataSet Implements IDataProvider.ExecuteDataSet
            Return Me.RemoteDataService.ExecuteDataSet(Me.DataSource.DataSourceName, Me.GetTransportCommand(pCommand))
        End Function

        Public Function ExecuteNonQuery(ByVal pCommand As DataCommand) As Integer Implements IDataProvider.ExecuteNonQuery
            Return Me.RemoteDataService.ExecuteNonQuery(Me.DataSource.DataSourceName, Me.GetTransportCommand(pCommand))
        End Function

        Public Function ExecuteScalar(ByVal pCommand As DataCommand) As Object Implements IDataProvider.ExecuteScalar
            Return Me.RemoteDataService.ExecuteScalar(Me.DataSource.DataSourceName, Me.GetTransportCommand(pCommand))
        End Function

        Public Sub New(ByVal pDataSource As DataSource)
            _DataSource = pDataSource
        End Sub

        
    End Class
End Namespace

