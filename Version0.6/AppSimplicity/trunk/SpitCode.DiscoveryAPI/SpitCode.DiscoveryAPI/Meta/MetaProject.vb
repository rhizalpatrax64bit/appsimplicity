Public Class MetaProject

    Private _Tables As List(Of MetaTable)
    Public ReadOnly Property Tables() As List(Of MetaTable)
        Get
            If _Tables Is Nothing Then

            End If
            Return _Tables
        End Get
    End Property


    Public Sub New(ByVal pDataSource As AppSimplicity.DataAccess.DataSource)

    End Sub

  

End Class
