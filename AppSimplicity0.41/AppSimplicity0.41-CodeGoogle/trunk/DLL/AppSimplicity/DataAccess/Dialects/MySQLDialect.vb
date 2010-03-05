Namespace DataAccess.Providers
    Public Class MySQLDialect
        Inherits SQL92DialectProvider


#Region "Column Formatters"
        Public Overrides Function GetBracketedColumnName(ByVal pColumn As ActiveRecord.SchemaColumn) As String
            Return String.Format("`{0}`", pColumn.ColumnName)
        End Function

        Public Overrides Function GetColumnJoinAlias(ByVal pColumn As ActiveRecord.SchemaColumn) As String
            Return String.Format("`{0}.{1}`", pColumn.Schema.TableName, pColumn.ColumnName)
        End Function

        Public Overrides Function GetQualifiedTableName(ByVal pSchema As ActiveRecord.Schema) As String
            Return String.Format("`{0}`", pSchema.TableName)
        End Function

        Public Overrides Function GetLastInsertedIdStatement() As String
            Return "; SELECT LAST_INSERT_ID() as newID;"
        End Function

        Public Sub New(ByVal pUseSPsForCRUD As Boolean)
            MyBase.New(pUseSPsForCRUD)
        End Sub
#End Region

    End Class
End Namespace

