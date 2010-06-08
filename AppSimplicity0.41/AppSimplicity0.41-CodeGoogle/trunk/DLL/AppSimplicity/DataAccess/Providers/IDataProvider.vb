Namespace DataAccess.Providers

    ''' <summary>
    ''' The purpose of this interface is to implement classes that may function as data providers.
    ''' </summary>
    Public Interface IDataProvider

#Region "Execute methods"
        ''' <summary>
        ''' Execute a command of data and returns a dataset
        ''' </summary>
        ''' <param name="pCommand">Represents the data request command</param>        
        Function ExecuteDataSet(ByVal pCommand As DataCommand) As System.Data.DataSet

        ''' <summary>
        ''' Execute a command of data and returns the result of a data command which results matrix is 1x1
        ''' </summary>
        ''' <param name="pCommand">Represents the data request command</param>        
        Function ExecuteScalar(ByVal pCommand As DataCommand) As Object

        ''' <summary>
        ''' Execute a command of data and returns the number of rows affected
        ''' </summary>
        ''' <param name="pCommand">Represents the data request command</param>        
        Function ExecuteNonQuery(ByVal pCommand As DataCommand) As Integer
#End Region

    End Interface
End Namespace


