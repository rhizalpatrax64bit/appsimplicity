Namespace Entities
    <Serializable()> _
    Public Class StoredProcedure
        Inherits AbstractDataObject

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

    End Class
End Namespace

