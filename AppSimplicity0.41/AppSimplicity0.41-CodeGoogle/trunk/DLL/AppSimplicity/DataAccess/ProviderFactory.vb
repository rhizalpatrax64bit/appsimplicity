Namespace DataAccess.Providers
    Public Class ProviderFactory

        Public Shared Function GetDataProviderFactory(ByVal pDataSource As DataSource) As IDataProvider
            Dim lReturnValue As IDataProvider = Nothing

            If (pDataSource.ConnectsThroughWebService) Then
                lReturnValue = New RemoteWSProvider(pDataSource)
            Else
                Select Case (pDataSource.ProviderType)
                    Case ProviderTypes.SQLServer, _
                            ProviderTypes.MySQL, _
                            ProviderTypes.ODBC, _
                            ProviderTypes.OleDB, _
                            ProviderTypes.Oracle, _
                            ProviderTypes.SQLite, _
                            ProviderTypes.SQLServerCE
                        lReturnValue = New EnterpriseLibraryProvider(pDataSource)
                End Select
            End If

            Return lReturnValue
        End Function

        Public Shared Function GetDialectProviderFactory(ByVal pDataSource As DataSource, ByVal pUseSPsforCRUD As Boolean) As IDialectProvider
            Dim lReturnValue As IDialectProvider = Nothing

            Select Case (pDataSource.ProviderType)
                Case ProviderTypes.SQLServer
                    lReturnValue = New Providers.SQLServerDialectProvider(pUseSPsforCRUD)
                Case ProviderTypes.MySQL
                    lReturnValue = New Providers.MySQLDialect(pUseSPsforCRUD)
                Case ProviderTypes.SQLite
                    lReturnValue = New Providers.SQLiteDialect(pUseSPsforCRUD)
                Case ProviderTypes.Oracle, ProviderTypes.Oracle
                    Throw New NotImplementedException
            End Select

            Return lReturnValue
        End Function
    End Class
End Namespace

