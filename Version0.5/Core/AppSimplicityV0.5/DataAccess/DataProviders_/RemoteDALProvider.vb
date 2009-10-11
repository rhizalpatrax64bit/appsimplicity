Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.CompilerServices
Imports System.Data.Common

Namespace DataAccess.Providers
    Public Class RemoteDALProvider
        Inherits ProviderBase

        Private _RemoteAcess As RemoteDataServices.DataService

        Public Overrides Function GetDBFactory() As System.Data.Common.DbProviderFactory
            Return SqlClient.SqlClientFactory.Instance
        End Function

        Private Function RipURL(ByVal pConnectionString As String) As String
            Dim lData As String() = pConnectionString.Split("|")
            Return lData(0).ToLower
        End Function

        Private Function RipCredentials(ByVal pConnectionString As String) As System.Net.NetworkCredential
            Dim lReturnValue As System.Net.NetworkCredential = Nothing

            Dim lData As String() = pConnectionString.Split("|")

            If lData.Length = 2 Then
                Dim lCredentials As String = lData(1)

                Dim lValues As String() = lCredentials.Split(";")

                Dim lUserFinded As Boolean = False
                Dim lPasswordFinded As Boolean = False
                Dim lUserName As String = String.Empty
                Dim lPassword As String = String.Empty

                Try
                    For Each lPair As String In lValues
                        If (lPair.ToLower.Contains("user")) Then
                            lUserName = lPair.ToLower.Split("=")(1)
                            lUserFinded = True
                        End If

                        If (lPair.ToLower.Contains("password")) Then
                            lPassword = lPair.ToLower.Split("=")(1)
                            lPasswordFinded = True
                        End If
                    Next
                Catch ex As Exception

                End Try

                If (lUserFinded And lPasswordFinded) Then
                    lReturnValue = New System.Net.NetworkCredential(lUserName, lPassword)
                End If
            End If

            Return lReturnValue
        End Function

        Public Sub New(ByVal pDataSource As DataSource)
            MyBase.New(pDataSource, False, DataAccesModes.DisconnectedDataSets)

            _RemoteAcess = New RemoteDataServices.DataService
            _RemoteAcess.Url = Me.RipURL(Me.DataSource.ConnectionString)

            Dim lCredentials As System.Net.NetworkCredential = Me.RipCredentials(Me.DataSource.ConnectionString)

            If Not (lCredentials Is Nothing) Then
                _RemoteAcess.Credentials = lCredentials
            End If
        End Sub

#Region "Métodos de Acceso a Datos"
        Public Overrides Function ExecuteDataReader(ByVal pCommandText As String, ByVal pCommandType As System.Data.CommandType, ByVal pParameters As System.Collections.Generic.List(Of System.Data.Common.DbParameter)) As System.Data.Common.DbDataReader
            Throw New NotImplementedException
        End Function

        Public Overrides Function ExecuteDataset(ByVal pCommandText As String, ByVal pCommandType As System.Data.CommandType, ByVal pParameters As System.Collections.Generic.List(Of System.Data.Common.DbParameter)) As System.Data.DataSet
            Return _RemoteAcess.ExecuteDataSet(Me.DataSource.Name, pCommandText, pCommandType, PackParametersAsDataSet(pParameters))
        End Function

        Public Overrides Function ExecuteNonQuery(ByVal pCommandText As String, ByVal pCommandType As System.Data.CommandType, ByVal pParameters As System.Collections.Generic.List(Of System.Data.Common.DbParameter)) As Integer
            Return _RemoteAcess.ExecuteNonQuery(Me.DataSource.Name, pCommandText, pCommandType, PackParametersAsDataSet(pParameters))
        End Function

        Public Overrides Function ExecuteScalar(ByVal pCommandText As String, ByVal pCommandType As System.Data.CommandType, ByVal pParameters As System.Collections.Generic.List(Of System.Data.Common.DbParameter)) As Object
            Return _RemoteAcess.ExecuteNonQuery(Me.DataSource.Name, pCommandText, pCommandType, PackParametersAsDataSet(pParameters))
        End Function
#End Region

#Region "Parameter Serialization Transport"
        Public Shared Function PackParametersAsDataSet(ByVal pParameters As List(Of System.Data.Common.DbParameter)) As DataSet
            Dim DS As New DataExchange

            Dim DR As DataRow = Nothing

            For Each Parameter As DbParameter In pParameters
                DR = DS.Parameters.NewRow

                DR.Item("key") = Parameter.ParameterName
                DR.Item("value") = Serialization.SerializeToString(Parameter.Value)

                DS.Parameters.Rows.Add(DR)
            Next
            DS.AcceptChanges()
            Return DS
        End Function

        Public Shared Function UnPackParametersCollection(ByVal pParameters As DataSet, ByVal pDBFactory As DbProviderFactory) As List(Of System.Data.Common.DbParameter)
            Dim lResult As New List(Of System.Data.Common.DbParameter)
            Dim lParameter As DbParameter
            Dim lValue As Object

            For Each DR As DataRow In pParameters.Tables(0).Rows
                lValue = Serialization.DeserializeFromString(DR.Item("value"))

                lParameter = pDBFactory.CreateParameter
                lParameter.ParameterName = CType(DR.Item("key"), String)
                lParameter.Value = lValue

                lResult.Add(lParameter)
            Next

            Return lResult
        End Function
#End Region
    End Class

End Namespace
