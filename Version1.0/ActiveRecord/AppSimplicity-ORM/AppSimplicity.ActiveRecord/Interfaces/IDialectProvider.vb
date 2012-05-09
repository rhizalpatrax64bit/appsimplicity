Imports AppSimplicity.SchemaDiscovery

Public Interface IDialectProvider

    Function Get_INSERT_Statement(ByVal pSchema As Entities.Table) As String

    Function Get_UPDATE_Statement(ByVal pSchema As Entities.Table) As String

    Function Get_DELETE_Statement(ByVal pSchema As Entities.Table) As String

    Function Get_SELECTBYID_Statement(ByVal pSchema As Entities.Table) As String

    Function Get_ParameterName(ByVal pColumn As Entities.Column) As String

    Function Get_ParameterName(ByVal pParameterName As String) As String

    Function Get_QueryBuilderStatement(ByVal pQuery As Query.QueryBuilder) As String

End Interface
