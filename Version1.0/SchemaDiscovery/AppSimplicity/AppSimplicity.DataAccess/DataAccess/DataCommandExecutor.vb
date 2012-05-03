Public Class DataCommandExecutor

    Private _Provider As IDataServiceProvider
    Private _Command As DataCommand

    Public Sub New(ByVal pCommand As DataCommand, ByVal pProvider As IDataServiceProvider)
        _Command = pCommand
        _Provider = pProvider
    End Sub

#Region "Execute methods"
    Public Function ExecuteDataSet() As DataSet
        Return _Provider.ExecuteDataSet(_Command)
    End Function

    Public Function ExecuteNonQuery() As Integer
        Return _Provider.ExecuteNonQuery(_Command)
    End Function

    Public Function ExecuteScalar() As Object
        Return _Provider.ExecuteScalar(_Command)
    End Function

    Public Function ExecuteResultSet() As ResultSet
        Return _Provider.ExecuteResultSet(_Command)
    End Function
#End Region

End Class
