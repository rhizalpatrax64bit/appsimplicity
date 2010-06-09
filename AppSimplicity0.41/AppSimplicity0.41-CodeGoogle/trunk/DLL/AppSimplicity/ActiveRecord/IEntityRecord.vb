Namespace ActiveRecord
    Public Interface IEntityRecord

        ReadOnly Property IsLoadedFromDB() As Boolean

        Event OnBeforeLoad()

        Event OnAfterLoad()

        Sub Load(ByVal pRow As System.Data.DataRow, Optional ByVal pUseQualifiedNames As Boolean = False)

        Sub Reset()

    End Interface
End Namespace
