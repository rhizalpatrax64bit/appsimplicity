Namespace SomeERP
    Public Class DataContext

        Private _Customers As CustomerDataManager
        Public ReadOnly Property Customers As CustomerDataManager
            Get
                If (_Customers Is Nothing) Then
                    _Customers = New CustomerDataManager
                End If
                Return _Customers
            End Get
        End Property

    End Class
End Namespace
