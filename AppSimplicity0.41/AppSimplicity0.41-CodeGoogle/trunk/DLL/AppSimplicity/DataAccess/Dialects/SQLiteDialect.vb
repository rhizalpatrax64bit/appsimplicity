Namespace DataAccess.Providers
    Public Class SQLiteDialect
        Inherits SQL92DialectProvider

        Public Overrides Function GetLastInsertedIdStatement() As String
            Return "; SELECT LAST_INSERT_ROWID() as newID;"
        End Function

        Public Overrides Function GetQualifiedColumnName(ByVal pColumn As ActiveRecord.SchemaColumn) As String
            Return String.Format("{0}", Me.GetBracketedColumnName(pColumn))
        End Function

        Public Sub New(ByVal pUseSPsForCRUD As Boolean)
            MyBase.New(pUseSPsForCRUD)
        End Sub
    End Class
End Namespace

