Imports System.Data.Common

Public Class ResultSetRow

    Private _Enumerator As ResultSetEnumerator
    Private _Reader As DbDataReader

    ''' <summary>
    ''' Gets the appropiated value from reader
    ''' </summary>
    ''' <param name="pKey">The key for the value to be returned</param>
    ''' <returns></returns>
    Public Function GetValue(ByVal pKey As String) As Object
        Dim lReturnValue As Object = Nothing

        Try
            lReturnValue = _Reader.Item(pKey)
        Catch ex As Exception
            _Enumerator.OnReadException(ex)
        End Try

        Return lReturnValue
    End Function

    ''' <summary>
    ''' Determines if a given data value is null
    ''' </summary>
    ''' <param name="pKey">The key of the data value</param>
    Public Function IsNull(ByVal pKey As String) As Boolean
        Dim lReturnValue As Boolean = False

        If (_Reader.Item(pKey) Is System.DBNull.Value) Then
            lReturnValue = True
        End If

        Return lReturnValue
    End Function

    Public Sub New(ByVal pReader As DbDataReader, ByVal pEnumerator As ResultSetEnumerator)
        _Reader = pReader
        _Enumerator = pEnumerator
    End Sub

End Class