Namespace Entities
    <Serializable()> _
    Public Class View
        Inherits AbstractTable
        Implements IComparable(Of View)

        Public Function CompareTo(ByVal other As View) As Integer Implements System.IComparable(Of View).CompareTo
            If other Is Nothing Then
                Return 1
            End If
            Return String.Compare(Me.Name, other.Name)
        End Function
    End Class
End Namespace

