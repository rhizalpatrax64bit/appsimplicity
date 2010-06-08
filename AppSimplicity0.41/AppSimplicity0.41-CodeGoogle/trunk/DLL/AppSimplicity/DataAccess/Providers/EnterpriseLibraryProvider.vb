Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data

Namespace DataAccess.Providers

    Public Class EnterpriseLibraryProvider
        Implements IDataProvider

        Private _DataSource As DataSource
        
        Private Function GetCommand(ByVal pCommand As DataCommand, ByVal pDataBase As Database) As System.Data.Common.DbCommand
            Dim lReturnValue As System.Data.Common.DbCommand = Nothing

            Select Case pCommand.CommandType
                Case CommandType.StoredProcedure
                    lReturnValue = pDataBase.GetStoredProcCommand(pCommand.SQLCommand)
                Case CommandType.Text
                    lReturnValue = pDataBase.GetSqlStringCommand(pCommand.SQLCommand)
            End Select

            For Each lParameter As DataAccess.DataCommandParameter In pCommand.Parameters
                pDataBase.AddInParameter(lReturnValue, lParameter.Name, lParameter.Type, lParameter.Value)
            Next

            Return lReturnValue
        End Function

#Region "Execute Methods"
        Public Function ExecuteDataSet(ByVal pCommand As DataCommand) As System.Data.DataSet Implements IDataProvider.ExecuteDataSet
            Dim lDB As Database = DatabaseFactory.CreateDatabase(_DataSource.DataSourceName)

            Dim lCommand As System.Data.Common.DbCommand = Me.GetCommand(pCommand, lDB)

            Return lDB.ExecuteDataSet(lCommand)
        End Function

        Public Function ExecuteNonQuery(ByVal pCommand As DataCommand) As Integer Implements IDataProvider.ExecuteNonQuery
            Dim lDB As Database = DatabaseFactory.CreateDatabase(_DataSource.DataSourceName)

            Dim lCommand As System.Data.Common.DbCommand = Me.GetCommand(pCommand, lDB)

            Return lDB.ExecuteNonQuery(lCommand)
        End Function

        Public Function ExecuteScalar(ByVal pCommand As DataCommand) As Object Implements IDataProvider.ExecuteScalar
            Dim lDB As Database = DatabaseFactory.CreateDatabase(_DataSource.DataSourceName)

            Dim lCommand As System.Data.Common.DbCommand = Me.GetCommand(pCommand, lDB)

            Return lDB.ExecuteScalar(lCommand)
        End Function
#End Region

        Public Sub New(ByVal pDataSource As DataSource)
            _DataSource = pDataSource
        End Sub
    End Class
End Namespace


