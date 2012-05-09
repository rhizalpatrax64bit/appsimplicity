Imports AppSimplicity.SchemaDiscovery

Namespace Query
    Public MustInherit Class QueryBuilder

        Private _Schema As Entities.Table
        Public ReadOnly Property Schema As Entities.Table
            Get
                Return _Schema
            End Get
        End Property

        Private _Limit As Integer
        Public ReadOnly Property Limit() As Integer
            Get
                Return _Limit
            End Get
        End Property

        Private _ParamCount As Integer = 0
        ''' <summary>
        ''' 
        ''' </summary>
        Private ReadOnly Property ParamCount() As Integer
            Get
                _ParamCount = _ParamCount + 1
                Return _ParamCount
            End Get
        End Property

        Public Sub New(ByVal schema As Entities.Table)
            _Schema = schema
        End Sub

    End Class
End Namespace

