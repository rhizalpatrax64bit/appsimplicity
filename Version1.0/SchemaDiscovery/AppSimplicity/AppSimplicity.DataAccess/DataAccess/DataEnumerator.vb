Public Class DataEnumerator
    Implements IEnumerator

#Region "Fields"
    Private _Reader As System.Data.Common.DbDataReader
    Private _Connection As System.Data.Common.DbConnection
#End Region

#Region "Properties"
    Public ReadOnly Property RecordsAffected() As Integer
        Get
            Return _Reader.RecordsAffected
        End Get
    End Property
#End Region

#Region "IEnumerator implementations"
    Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
            Return _Reader
        End Get
    End Property

    Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Return Me._Reader.Read()
    End Function

    Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        'This will not be implemented
    End Sub
#End Region

    Public Function GetValue(ByVal pKey As String) As Object
        Return Me._Reader.Item(pKey)
    End Function

    Public Sub Close()
        If Not (_Reader.IsClosed()) Then
            Me._Reader.Close()
        End If

        If (Me._Connection.State <> ConnectionState.Closed) Then
            Me._Connection.Close()
        End If
    End Sub

End Class
