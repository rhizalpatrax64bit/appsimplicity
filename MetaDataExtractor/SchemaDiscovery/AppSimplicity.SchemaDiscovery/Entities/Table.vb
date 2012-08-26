Namespace Entities
    <Serializable()> _
    Public Class Table
        Inherits AbstractTable
        Implements IComparable(Of Table)

        Public Overrides Function ToString() As String
            Return String.Format("{0}.{1}", Me.Schema, Me.Name)
        End Function

        Private _IgnoreForDataScripting As Boolean = False
        <Category("Scripting options"), DisplayName("Include for data scripting"), Description("Determines if this table should be included for data scripting")> _
        Public Property IgnoreForDataScripting() As Boolean
            Get
                Return _IgnoreForDataScripting
            End Get
            Set(ByVal value As Boolean)
                _IgnoreForDataScripting = value
            End Set
        End Property

        Private _Keys As List(Of TableKey)
        <Browsable(False)> _
        Public Property Keys() As List(Of TableKey)
            Get
                If (_Keys Is Nothing) Then
                    _Keys = New List(Of TableKey)
                End If
                Return _Keys
            End Get
            Set(ByVal value As List(Of TableKey))
                _Keys = value
            End Set
        End Property

        Private _PrimaryKey As TableKey = Nothing
        <Category("Metadata"), DisplayName("Primary key"), Description("The name of the primary key"), [ReadOnly](True)> _
        Public ReadOnly Property PrimaryKey As TableKey
            Get
                If (_PrimaryKey Is Nothing) Then
                    _PrimaryKey = GetPrimaryKey()
                End If
                Return _PrimaryKey
            End Get
        End Property

        Private Function GetPrimaryKey() As TableKey
            Dim lReturnValue As TableKey = Nothing

            For Each lkey As TableKey In Me.Keys
                If (lkey.KeyType = KeyTypes.PrimaryKey) Then
                    lReturnValue = lkey
                    Exit For
                End If
            Next

            Return lReturnValue
        End Function

        Public Function CompareTo(ByVal other As Table) As Integer Implements System.IComparable(Of Table).CompareTo
            If other Is Nothing Then
                Return 1
            End If
            Return String.Compare(Me.Name, other.Name)
        End Function
    End Class
End Namespace

