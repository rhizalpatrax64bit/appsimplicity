Imports System.Data.Common

''' <summary>
''' The objective for this class is to implement an enumerator that wraps the call for a DbDataReader but internally handles exception and resource releasing issues.
''' </summary>
''' <remarks></remarks>
Public Class ResultSetEnumerator
    Implements IEnumerator

    Private _Behavior As System.Data.CommandBehavior
    Private _Reader As DbDataReader
    Private _ResultSetReader As ResultSetRow
    Private _Dataservice As IDataServiceProvider
    Private _ResultSet As ResultSet

    Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
            Return Me.Reader()
        End Get
    End Property

    Private ReadOnly Property Reader() As ResultSetRow
        Get
            Return _ResultSetReader
        End Get
    End Property

    Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Dim lReturnValue As Boolean = False

        lReturnValue = _Reader.Read()

        If (lReturnValue = False) Then
            'When reader has reached the end of the rows, then close it:
            Me.CloseReader()
        Else
            _ResultSet.IncreaseCounter()
        End If

        Return lReturnValue
    End Function

    Private Sub CloseReader()
        _Reader.Close()
        If (_Behavior = CommandBehavior.CloseConnection) Then
            _Dataservice.CloseConnection()
        End If
    End Sub

    Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        'Just do nothing.
    End Sub

    Public Sub New(ByVal pReader As DbDataReader, ByVal pBehavior As System.Data.CommandBehavior, ByVal pDataService As IDataServiceProvider, ByVal pResultSet As ResultSet)
        _Reader = pReader
        _Behavior = pBehavior
        _Dataservice = pDataService
        _ResultSet = pResultSet

        _ResultSetReader = New ResultSetRow(pReader, Me)
    End Sub

    Friend Sub OnReadException(ByVal pException As Exception)
        Me.CloseReader()
        Throw (pException)
    End Sub

End Class


