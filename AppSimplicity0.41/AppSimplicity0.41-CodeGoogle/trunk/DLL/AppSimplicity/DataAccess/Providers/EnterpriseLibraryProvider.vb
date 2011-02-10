'Imports Microsoft.Practices.EnterpriseLibrary.Common
'Imports Microsoft.Practices.EnterpriseLibrary.Data

Namespace DataAccess.Providers

    Public Class EnterpriseLibraryProvider
        Implements IDataProvider

        Private _DataSource As DataSource
        
        'Private Function GetCommand(ByVal pCommand As DataCommand, ByVal pDataBase As Database) As System.Data.Common.DbCommand
        '    Dim lReturnValue As System.Data.Common.DbCommand = Nothing

        '    Select Case pCommand.CommandType
        '        Case CommandType.StoredProcedure
        '            lReturnValue = pDataBase.GetStoredProcCommand(pCommand.SQLCommand)
        '        Case CommandType.Text
        '            lReturnValue = pDataBase.GetSqlStringCommand(pCommand.SQLCommand)
        '    End Select

        '    For Each lParameter As DataAccess.DataCommandParameter In pCommand.Parameters
        '        pDataBase.AddInParameter(lReturnValue, lParameter.Name, lParameter.Type, lParameter.Value)
        '    Next

        '    Return lReturnValue
        'End Function


        Private Function GetParameters(ByVal pCommand As DataCommand) As List(Of System.Data.SqlClient.SqlParameter)
            Dim lList As New List(Of System.Data.SqlClient.SqlParameter)

            For Each lParameter As AppSimplicity.DataAccess.DataCommandParameter In pCommand.Parameters
                Dim lSQLParameter As New System.Data.SqlClient.SqlParameter

                lSQLParameter.ParameterName = lParameter.Name
                lSQLParameter.Direction = ParameterDirection.Input
                lSQLParameter.DbType = lParameter.Type

                Select Case lParameter.Type
                    Case DbType.Date, DbType.DateTime, DbType.DateTime2

                        If (lParameter.Value = Date.MinValue) Then
                            lSQLParameter.Value = System.DBNull.Value
                        End If

                        If (lParameter.Value Is System.DBNull.Value) Then
                            lSQLParameter.Value = lParameter.Value
                        Else
                            If (lParameter.Value = Date.MinValue) Then
                                lSQLParameter.Value = System.DBNull.Value
                            Else
                                lSQLParameter.Value = lParameter.Value
                            End If
                        End If
                    Case Else
                        lSQLParameter.Value = lParameter.Value
                End Select

                lList.Add(lSQLParameter)
            Next

            Return lList
        End Function
#Region "Execute Methods"
        'Public Function ExecuteDataSet(ByVal pCommand As DataCommand) As System.Data.DataSet Implements IDataProvider.ExecuteDataSet
        '    Dim lDB As Database = DatabaseFactory.CreateDatabase(_DataSource.DataSourceName)

        '    Dim lCommand As System.Data.Common.DbCommand = Me.GetCommand(pCommand, lDB)

        '    Return lDB.ExecuteDataSet(lCommand)
        'End Function

        'Public Function ExecuteNonQuery(ByVal pCommand As DataCommand) As Integer Implements IDataProvider.ExecuteNonQuery
        '    Dim lDB As Database = DatabaseFactory.CreateDatabase(_DataSource.DataSourceName)

        '    Dim lCommand As System.Data.Common.DbCommand = Me.GetCommand(pCommand, lDB)

        '    Return lDB.ExecuteNonQuery(lCommand)
        'End Function

        'Public Function ExecuteScalar(ByVal pCommand As DataCommand) As Object Implements IDataProvider.ExecuteScalar
        '    Dim lDB As Database = DatabaseFactory.CreateDatabase(_DataSource.DataSourceName)

        '    Dim lCommand As System.Data.Common.DbCommand = Me.GetCommand(pCommand, lDB)

        '    Return lDB.ExecuteScalar(lCommand)
        'End Function

        Public Function ExecuteDataSet(ByVal pCommand As DataCommand) As System.Data.DataSet Implements IDataProvider.ExecuteDataSet

            If (pCommand.Parameters.Count > 0) Then
                Dim lParameters As List(Of System.Data.SqlClient.SqlParameter) = Me.GetParameters(pCommand)
                Return SqlHelper.ExecuteDataset(_DataSource.ConnectionString, pCommand.CommandType, pCommand.SQLCommand, lParameters.ToArray())
            Else
                Return SqlHelper.ExecuteDataset(_DataSource.ConnectionString, pCommand.CommandType, pCommand.SQLCommand)
            End If

        End Function

        Public Function ExecuteNonQuery(ByVal pCommand As DataCommand) As Integer Implements IDataProvider.ExecuteNonQuery
            If (pCommand.Parameters.Count > 0) Then
                Dim lParameters As List(Of System.Data.SqlClient.SqlParameter) = Me.GetParameters(pCommand)
                Return SqlHelper.ExecuteNonQuery(_DataSource.ConnectionString, pCommand.CommandType, pCommand.SQLCommand, lParameters.ToArray())
            Else
                Return SqlHelper.ExecuteNonQuery(_DataSource.ConnectionString, pCommand.CommandType, pCommand.SQLCommand)
            End If
        End Function

        Public Function ExecuteScalar(ByVal pCommand As DataCommand) As Object Implements IDataProvider.ExecuteScalar
            If (pCommand.Parameters.Count > 0) Then
                Dim lParameters As List(Of System.Data.SqlClient.SqlParameter) = Me.GetParameters(pCommand)
                Return SqlHelper.ExecuteScalar(_DataSource.ConnectionString, pCommand.CommandType, pCommand.SQLCommand, lParameters.ToArray())
            Else
                Return SqlHelper.ExecuteScalar(_DataSource.ConnectionString, pCommand.CommandType, pCommand.SQLCommand)
            End If
        End Function
#End Region

        Public Sub New(ByVal pDataSource As DataSource)
            _DataSource = pDataSource
        End Sub
    End Class
End Namespace


