Namespace Providers.SqlServer
    Public Class SQL92Provider
        Implements IDialectProvider

        Public Function Get_DELETE_Statement(ByVal pSchema As SchemaDiscovery.Entities.Table) As String Implements IDialectProvider.Get_DELETE_Statement

        End Function

        Public Function Get_INSERT_Statement(ByVal pSchema As SchemaDiscovery.Entities.Table) As String Implements IDialectProvider.Get_INSERT_Statement

        End Function

        Public Function Get_ParameterName(ByVal pColumn As SchemaDiscovery.Entities.Column) As String Implements IDialectProvider.Get_ParameterName

        End Function

        Public Function Get_ParameterName(ByVal pParameterName As String) As String Implements IDialectProvider.Get_ParameterName

        End Function

        Public Function Get_QueryBuilderStatement(ByVal pQuery As Query.QueryBuilder) As String Implements IDialectProvider.Get_QueryBuilderStatement

        End Function

        Public Function Get_SELECTBYID_Statement(ByVal pSchema As SchemaDiscovery.Entities.Table) As String Implements IDialectProvider.Get_SELECTBYID_Statement

        End Function

        Public Function Get_UPDATE_Statement(ByVal pSchema As SchemaDiscovery.Entities.Table) As String Implements IDialectProvider.Get_UPDATE_Statement

        End Function
    End Class
End Namespace

