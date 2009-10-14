Namespace DataAccess.Providers
    Public Class ProviderFactory

        ''' <summary>
        ''' Given a DataSource gets the 
        ''' </summary>
        ''' <param name="pDataSource"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetInstance(ByVal pDataSource As DataSource) As Provider
            Dim lReturnValue As Provider = Nothing

            Select Case (pDataSource.ProviderType)
                Case DataSource.ProviderTypes.SQLServer
                    lReturnValue = New SQLServerProvider(pDataSource)
                Case DataSource.ProviderTypes.MySQL
                    lReturnValue = New MySQLProvider(pDataSource)
                Case DataSource.ProviderTypes.Oracle
                    lReturnValue = New OracleProvider(pDataSource)
                Case DataSource.ProviderTypes.SQLite
                    lReturnValue = New SQLiteProvider(pDataSource)
                Case DataSource.ProviderTypes.OleDB
                    lReturnValue = New OleDBProvider(pDataSource)
            End Select

            Return lReturnValue
        End Function
    End Class
End Namespace
