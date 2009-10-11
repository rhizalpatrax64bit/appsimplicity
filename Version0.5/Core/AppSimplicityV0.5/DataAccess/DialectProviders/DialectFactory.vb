Namespace DataAccess.Dialect
    Public Class DialectFactory

        Public Shared Function GetDialectInstance(ByVal pDataService As DataService) As DialectBase
            Dim lReturnValue As DialectBase = Nothing

            Select Case (pDataService.DataSource.ProviderType)
                Case DataSource.ProviderTypes.SQLServer, DataSource.ProviderTypes.SQLServerCE
                    lReturnValue = New SqlServerDialect()
                Case Else
                    'TODO: throw exception here
            End Select

            Return lReturnValue
        End Function
    End Class
End Namespace
