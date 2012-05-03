Imports System.Data.Common

Public Class ResultSet
    Implements IEnumerable

    Private _Reader As DbDataReader
    Private _Behavior As System.Data.CommandBehavior
    Private _DataService As IDataServiceProvider

    Private _RowsReaded As Integer
    ''' <summary>
    ''' Gets the number of readed records
    ''' </summary>    
    Public ReadOnly Property RowsReaded() As Integer
        Get
            Return _RowsReaded
        End Get
    End Property

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return New ResultSetEnumerator(_Reader, _Behavior, _DataService, Me)
    End Function

    Friend Sub IncreaseCounter()
        _RowsReaded = _RowsReaded + 1
    End Sub

    Public Sub New(ByVal pReader As DbDataReader, ByVal pBehavior As System.Data.CommandBehavior, ByVal pDataService As IDataServiceProvider)
        _RowsReaded = 0
        _Behavior = pBehavior
        _Reader = pReader
        _DataService = pDataService
    End Sub
End Class
