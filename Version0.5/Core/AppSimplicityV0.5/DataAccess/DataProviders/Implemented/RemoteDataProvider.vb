Namespace DataAccess.Providers
    Public Class RemoteDataProvider
        Inherits Provider

        Private _URL As String
        Private ReadOnly Property URL() As String
            Get
                Return _URL
            End Get
        End Property

        Public Sub New(ByVal pDataSource As DataSource, ByVal pURL As String)
            MyBase.New(pDataSource)
        End Sub

        Public Overrides Function GetFactory() As System.Data.Common.DbProviderFactory
            Return SqlClient.SqlClientFactory.Instance
        End Function

        Public Overrides Function ExecuteDataset(ByVal pCommand As DataCommand) As System.Data.DataSet
            Return MyBase.ExecuteDataset(pCommand)
        End Function

        Public Overrides Function ExecuteNonQuery(ByVal pCommand As DataCommand) As Integer
            Return MyBase.ExecuteNonQuery(pCommand)
        End Function

        Public Overrides Function ExecuteScalar(ByVal pCommand As DataCommand) As Object
            Return MyBase.ExecuteScalar(pCommand)
        End Function

        Public Overrides Function ExecuteDataReader(ByVal pCommand As DataCommand) As System.Data.Common.DbDataReader
            Throw New NotImplementedException
        End Function
    End Class
End Namespace
