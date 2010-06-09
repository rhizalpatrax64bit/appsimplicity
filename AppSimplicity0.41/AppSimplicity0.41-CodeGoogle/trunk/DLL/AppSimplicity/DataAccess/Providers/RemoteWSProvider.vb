﻿Imports AppSimplicity
Namespace DataAccess.Providers
    Public Class RemoteWSProvider
        Implements IDataProvider

        Private _DataSource As DataSource
        Private ReadOnly Property DataSource() As DataSource
            Get
                Return _DataSource
            End Get
        End Property

        Private _DataService As RemoteDataServices.DataService
        Protected ReadOnly Property DataService() As RemoteDataServices.DataService
            Get
                If (_DataService Is Nothing) Then
                    _DataService = New RemoteDataServices.DataService
                    _DataService.Url = Me.DataSource.ConnectionString
                End If
                Return _DataService
            End Get
        End Property

        Private Function GetTransportCommand(ByVal pCommand As DataCommand) As RemoteDataServices.DataCommand
            Dim lRemoteCommand As New RemoteDataServices.DataCommand
            Dim lParameters As New List(Of RemoteDataServices.DataCommandParameter)

            Select Case (pCommand.CommandType)
                Case CommandType.StoredProcedure
                    lRemoteCommand.CommandType = AppSimplicity.RemoteDataServices.CommandType.StoredProcedure
                Case CommandType.Text
                    lRemoteCommand.CommandType = AppSimplicity.RemoteDataServices.CommandType.Text
                Case CommandType.TableDirect
                    lRemoteCommand.CommandType = AppSimplicity.RemoteDataServices.CommandType.TableDirect
            End Select

            lRemoteCommand.SQLCommand = pCommand.SQLCommand

            For Each lParameter As DataCommandParameter In pCommand.Parameters
                Dim lDataParameter As New RemoteDataServices.DataCommandParameter

                lDataParameter.Name = lParameter.Name
                lDataParameter.Value = lParameter.Value
                lDataParameter.Type = lParameter.Type

                lParameters.Add(lDataParameter)
            Next

            lRemoteCommand.Parameters = lParameters.ToArray

            Return lRemoteCommand
        End Function

        Public Function ExecuteDataSet(ByVal pCommand As DataCommand) As System.Data.DataSet Implements IDataProvider.ExecuteDataSet
            Return Me.DataService.ExecuteDataSet(Me.DataSource.DataSourceName, Me.GetTransportCommand(pCommand))
        End Function

        Public Function ExecuteNonQuery(ByVal pCommand As DataCommand) As Integer Implements IDataProvider.ExecuteNonQuery
            Return Me.DataService.ExecuteNonQuery(Me.DataSource.DataSourceName, Me.GetTransportCommand(pCommand))
        End Function

        Public Function ExecuteScalar(ByVal pCommand As DataCommand) As Object Implements IDataProvider.ExecuteScalar
            Return Me.DataService.ExecuteScalar(Me.DataSource.DataSourceName, Me.GetTransportCommand(pCommand))
        End Function

        Public Sub New(ByVal pDataSource As DataSource)
            _DataSource = pDataSource
        End Sub
    End Class
End Namespace

