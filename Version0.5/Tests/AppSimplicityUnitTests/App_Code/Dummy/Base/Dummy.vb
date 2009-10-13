Imports AppSimplicity

Namespace Dummy
    ''' <summary>
    ''' Clase que envuelve la instancia del servicio de datos del dominio Dummy
    ''' </summary>
    Partial Public Class DataService
        Private Shared WithEvents _Instance As DataAccess.DataService
        ''' <summary>
        ''' Encapsula un servicio de acceso a datos para la base de datos Dummy
        ''' </summary>
        Public Shared ReadOnly Property Instance() As DataAccess.DataService
            Get
                If (_Instance Is Nothing) Then
                    _Instance = New DataAccess.DataService("Dummy", False)
                End If
                Return _Instance
            End Get
        End Property
    End Class
End Namespace