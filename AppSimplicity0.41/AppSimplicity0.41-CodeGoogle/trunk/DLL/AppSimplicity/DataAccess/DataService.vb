Namespace DataAccess
    Public Class DataService

        Public Event OnSetDataSource(ByRef pDataSource As DataSource)

        Private _DataServiceName As String
        Public ReadOnly Property DataServiceName() As String
            Get
                Return _DataServiceName
            End Get
        End Property

        Private _UseSPsForCRUD As Boolean
        Public ReadOnly Property UseSPsForCRUD() As Boolean
            Get
                Return _UseSPsForCRUD
            End Get
        End Property

        Private ReadOnly Property ActiveRecordCommandType() As System.Data.CommandType
            Get
                If (Me.UseSPsForCRUD) Then
                    Return CommandType.StoredProcedure
                End If
                Return CommandType.Text
            End Get
        End Property

        Private _DataProvider As Providers.IDataProvider
        Public ReadOnly Property DataProvider() As Providers.IDataProvider
            Get
                If (_DataProvider Is Nothing) Then
                    _DataProvider = DataAccess.Providers.ProviderFactory.GetDataProviderFactory(DataSource)
                End If
                Return _DataProvider
            End Get
        End Property

        Private _Dialect As Providers.IDialectProvider
        Public ReadOnly Property Dialect() As Providers.IDialectProvider
            Get
                If (_Dialect Is Nothing) Then
                    _Dialect = Providers.ProviderFactory.GetDialectProviderFactory(DataSource, Me.UseSPsForCRUD)
                End If
                Return _Dialect
            End Get
        End Property

        Private _DataSource As DataSource
        Public ReadOnly Property DataSource() As DataSource
            Get
                If (_DataSource Is Nothing) Then
                    RaiseEvent OnSetDataSource(_DataSource)

                    If (_DataSource Is Nothing) Then
                        _DataSource = DataSource.GetDataSourceFromConfigFile(Me.DataServiceName)
                    End If
                End If

                Return _DataSource
            End Get
        End Property

        Public Sub BeginTransaction(Optional ByVal pIsolationLevel As System.Data.IsolationLevel = IsolationLevel.ReadUncommitted)
            DataProvider.BeginTransaction(pIsolationLevel)
        End Sub

        Public Sub RollBackTransaction()
            DataProvider.RollBackTransaction()
        End Sub

        Public Sub CommitTransaction()
            DataProvider.CommitTransaction()
        End Sub

        Public Function CreateCommand(ByVal pSQLCommand As String, ByVal pType As System.Data.CommandType) As DataCommand
            Dim lCommand As New DataCommand()

            lCommand.SQLCommand = pSQLCommand
            lCommand.CommandType = pType

            Return lCommand
        End Function

        Public Sub CloseConnection()
            Me.DataProvider.
        End Sub

        ''' <summary>
        ''' Initializes the data service. You must enter data source name and whether the data service will use stored procedures for data access operations.
        ''' </summary>
        ''' <param name="pDataServiceName">Indicates the name of the data service. For practical purposes, the name must match the connection string in the .config file. </param>
        ''' <param name="pUseSPsForCRUD">
        ''' This parameter indicates if operations objects that implement IActiveRecord would use stored procedures for data access operations.
        ''' </param>
        Public Sub New(ByVal pDataServiceName As String, Optional ByVal pUseSPsForCRUD As Boolean = False)
            _DataServiceName = pDataServiceName
            _UseSPsForCRUD = pUseSPsForCRUD
        End Sub

        ''' <summary>
        ''' Sets the origin of the data source
        ''' </summary>
        ''' <param name="pDataSource">Indicates where the data should be taken to stablish a connection</param>
        Public Sub SetDataSource(ByVal pDataSource As DataAccess.DataSource)
            _DataSource = pDataSource
        End Sub

#Region "Execute Methods"
        Public Function ExecuteDataSet(ByVal pCommand As DataAccess.DataCommand) As DataSet
            Return DataProvider.ExecuteDataSet(pCommand)
        End Function

        Public Function ExecuteNonQuery(ByVal pCommand As DataAccess.DataCommand) As Integer
            Return DataProvider.ExecuteNonQuery(pCommand)
        End Function

        Public Function ExecuteScalar(ByVal pCommand As DataAccess.DataCommand) As Object
            Return DataProvider.ExecuteScalar(pCommand)
        End Function

        Public Function ExecuteDataReader(ByVal pCommand As DataAccess.DataCommand) As System.Data.Common.DbDataReader
            Return DataProvider.ExecuteDataReader(pCommand)
        End Function
#End Region

#Region "Active Record"
        Public Sub Insert(ByVal pRecord As ActiveRecord.IActiveRecord)
            Dim lCommand As DataCommand

            lCommand = Me.CreateCommand(Me.Dialect.Get_INSERT_Statement(pRecord.GetSchema), Me.ActiveRecordCommandType)
            lCommand.Parameters = pRecord.Get_INSERT_Parameters

            If (pRecord.GetSchema.IdIsAutoGenerated) Then
                Dim lId As Object = Me.ExecuteScalar(lCommand)

                If Not (lCommand Is Nothing) Then
                    pRecord.SetId(lId)
                End If
            Else
                Me.ExecuteNonQuery(lCommand)
            End If

        End Sub

        Public Function Update(ByVal pRecord As ActiveRecord.IActiveRecord) As Boolean
            Dim lReturnValue As Boolean = False
            Dim lCommand As DataCommand
            Dim lRowsAffected As Integer

            lCommand = Me.CreateCommand(Me.Dialect.Get_UPDATE_Statement(pRecord.GetSchema), Me.ActiveRecordCommandType)
            lCommand.Parameters = pRecord.Get_UPDATE_Parameters

            lRowsAffected = Me.ExecuteNonQuery(lCommand)

            If (lRowsAffected > 0) Then
                lReturnValue = True
            End If

            Return lReturnValue
        End Function

        Public Function Delete(ByVal pRecord As ActiveRecord.IActiveRecord) As Boolean
            Dim lReturnValue As Boolean = False
            Dim lCommand As DataCommand

            lCommand = Me.CreateCommand(Me.Dialect.Get_DELETE_Statement(pRecord.GetSchema), Me.ActiveRecordCommandType)
            lCommand.Parameters = pRecord.Get_DELETE_Parameters

            Dim lRowsAffected As Integer = Me.ExecuteNonQuery(lCommand)

            If (lRowsAffected > 0) Then
                lReturnValue = True
            End If

            Return lReturnValue
        End Function
#End Region

    End Class
End Namespace
