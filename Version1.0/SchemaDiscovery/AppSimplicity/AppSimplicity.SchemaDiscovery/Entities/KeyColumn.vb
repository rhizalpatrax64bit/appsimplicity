Namespace Entities

    Public Enum SortDirection
        Ascending = 1
        Descending = 2
    End Enum

    Public Class KeyColumn

        Private _ColumnName As String
        Public Property ColumnName() As String
            Get
                Return _ColumnName
            End Get
            Set(ByVal value As String)
                _ColumnName = value
            End Set
        End Property

        Private _SortDirection As SortDirection
        Public Property SortDirection() As SortDirection
            Get
                Return _SortDirection
            End Get
            Set(ByVal value As SortDirection)
                _SortDirection = value
            End Set
        End Property

    End Class
End Namespace

