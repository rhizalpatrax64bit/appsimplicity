Namespace Entities
    <Serializable()> _
    Public Class StoredProcedure
        Inherits AbstractDataObject
        Implements IComparable(Of StoredProcedure)

        Private _Parameters As List(Of StoredProcedureParameter)
        <Browsable(False)> _
        Public Property Parameters() As List(Of StoredProcedureParameter)
            Get
                If (_Parameters Is Nothing) Then
                    _Parameters = New List(Of StoredProcedureParameter)
                End If
                Return _Parameters
            End Get
            Set(ByVal value As List(Of StoredProcedureParameter))
                _Parameters = value
            End Set
        End Property

        Public Function CompareTo(ByVal other As StoredProcedure) As Integer Implements System.IComparable(Of StoredProcedure).CompareTo
            If other Is Nothing Then
                Return 1
            End If
            Return String.Compare(Me.Name, other.Name)
        End Function
    End Class
End Namespace

