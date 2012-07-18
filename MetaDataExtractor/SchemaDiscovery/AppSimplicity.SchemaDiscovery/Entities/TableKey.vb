Namespace Entities

    Public Enum KeyTypes
        PrimaryKey
        Index
    End Enum

    <Serializable()> _
    Public Class TableKey

        Private _Name As String
        <Category("Metadata"), DisplayName("Key name"), Description("The name of the key in the source database"), [ReadOnly](True)> _
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Private _Table As Table
        <Browsable(False)> _
        Public ReadOnly Property Table As Table
            Get
                Return _Table
            End Get
        End Property

        Public Sub SetTable(pTable As Table)
            _Table = pTable
        End Sub

        Private _Columns As List(Of KeyColumn)
        <Browsable(False)> _
        Public Property Columns() As List(Of KeyColumn)
            Get
                If (_Columns Is Nothing) Then
                    _Columns = New List(Of KeyColumn)
                End If
                Return _Columns
            End Get
            Set(ByVal value As List(Of KeyColumn))
                _Columns = value
            End Set
        End Property

        Private _KeyType As KeyTypes
        <Category("Metadata"), DisplayName("Key type"), Description("The type of the key in the source database."), [ReadOnly](True)> _
        Public Property KeyType() As KeyTypes
            Get
                Return _KeyType
            End Get
            Set(ByVal value As KeyTypes)
                _KeyType = value
            End Set
        End Property

        Private _ColumnDescriptions As String = String.Empty
        <Category("Metadata"), DisplayName("Columns"), Description("The names of the columns involved in this key.")> _
        Public ReadOnly Property ColumnDescriptions As String
            Get
                If (_ColumnDescriptions = String.Empty) Then
                    _ColumnDescriptions = Me.GetColumnDescriptions()
                End If
                Return _ColumnDescriptions
            End Get
        End Property

        Private Function GetColumnDescriptions() As String
            Dim lColumns As New List(Of String)

            For Each lCol As KeyColumn In Me.Columns
                lColumns.Add(String.Format("{0} ({1})", lCol.ColumnName, IIf(lCol.SortDirection = SortDirection.Ascending, "ASC", "DESC")))
            Next

            Return String.Join(", ", lColumns.ToArray())
        End Function

        Public Overrides Function ToString() As String
            Return Me.Name
        End Function
    End Class

End Namespace
