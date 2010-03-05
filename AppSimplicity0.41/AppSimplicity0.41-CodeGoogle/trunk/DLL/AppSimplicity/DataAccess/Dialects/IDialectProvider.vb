Namespace DataAccess.Providers

    Public Interface IDialectProvider

        Function Get_INSERT_Statement(ByVal pSchema As ActiveRecord.Schema) As String

        Function Get_UPDATE_Statement(ByVal pSchema As ActiveRecord.Schema) As String

        Function Get_DELETE_Statement(ByVal pSchema As ActiveRecord.Schema) As String

        Function Get_SELECTBYID_Statement(ByVal pSchema As ActiveRecord.Schema) As String

        Function Get_ParameterName(ByVal pColumn As ActiveRecord.SchemaColumn) As String

        Function Get_ParameterName(ByVal pParameterName As String) As String

        Function Get_QueryBuilderStatement(ByVal pQuery As ActiveRecord.Query.QueryBuilder) As String

    End Interface

End Namespace



