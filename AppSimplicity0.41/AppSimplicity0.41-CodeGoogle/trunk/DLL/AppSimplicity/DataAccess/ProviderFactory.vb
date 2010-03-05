Namespace DataAccess.Providers
    Public Class ProviderFactory

        Public Shared Function GetDataProviderFactory(ByVal pDataSource As DataAccess.DataSource) As DataAccess.Providers.IDataProvider
            Dim lReturnValue As DataAccess.Providers.IDataProvider = Nothing

            If (pDataSource.ConnectsThroughWebService) Then
                lReturnValue = New RemoteWSProvider(pDataSource)
            Else

                'TODO: Implement oracle providers:
                Select Case (pDataSource.ProviderType)
                    Case ProviderTypes.SQLServer
                        lReturnValue = New SQLServerProvider(pDataSource)
                    Case ProviderTypes.Oracle
                        Throw New NotImplementedException
                    Case ProviderTypes.Oracle10g
                        Throw New NotImplementedException
                    Case ProviderTypes.SQLite
                        lReturnValue = New SQLiteV3Provider(pDataSource)
                    Case ProviderTypes.MySQL
                        lReturnValue = New MySQLProvider(pDataSource)
                End Select
            End If

            Return lReturnValue
        End Function

        Public Shared Function GetDialectProviderFactory(ByVal pDataSource As DataAccess.DataSource, ByVal pUseSPsforCRUD As Boolean) As DataAccess.Providers.IDialectProvider
            Dim lReturnValue As DataAccess.Providers.IDialectProvider = Nothing

            Select Case (pDataSource.ProviderType)
                Case ProviderTypes.SQLServer
                    lReturnValue = New Providers.SQLServerDialectProvider(pUseSPsforCRUD)
                Case ProviderTypes.MySQL
                    lReturnValue = New Providers.MySQLDialect(pUseSPsforCRUD)
                Case ProviderTypes.SQLite
                    lReturnValue = New Providers.SQLiteDialect(pUseSPsforCRUD)
                Case ProviderTypes.Oracle, ProviderTypes.Oracle10g
                    Throw New NotImplementedException
            End Select

            Return lReturnValue
        End Function
    End Class
End Namespace

