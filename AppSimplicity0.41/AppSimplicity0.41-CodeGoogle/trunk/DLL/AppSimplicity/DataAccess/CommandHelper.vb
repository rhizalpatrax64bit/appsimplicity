Namespace DataAccess

    ''' <summary>
    ''' An instance that inherits from this class may perform any of the various data access methods.
    ''' </summary>
    Public Class CommandHelper
        Private _DataService As DataService

        Private ReadOnly Property DataService() As DataService
            Get
                Return _DataService
            End Get
        End Property

        Private _Command As DataCommand
        
        Public Sub New(ByVal pDataService As DataService, ByVal pCommand As DataCommand)
            _DataService = pDataService
            _Command = pCommand
        End Sub

        Public Function ExecuteDataSet() As DataSet
            Return _DataService.ExecuteDataSet(_Command)
        End Function

        Public Function ExecuteDataReader() As Data.Common.DbDataReader
            Return _DataService.ExecuteDataReader(_Command)
        End Function

        Public Function ExecuteNonQuery() As Integer
            Return _DataService.ExecuteNonQuery(_Command)
        End Function

        Public Function ExecuteScalar() As Object
            Return _DataService.ExecuteScalar(_Command)
        End Function
        
    End Class
End Namespace

