Public Class EntityDataManager(Of T As IActiveRecord)

    Protected Function CreateCommand(ByVal SQLStatement As String, Optional ByVal CommandType As System.Data.CommandType = System.Data.CommandType.Text) As AppSimplicity.DataAccess.DataCommand
        Return New AppSimplicity.DataAccess.DataCommand(SQLStatement, CommandType)
    End Function

End Class
