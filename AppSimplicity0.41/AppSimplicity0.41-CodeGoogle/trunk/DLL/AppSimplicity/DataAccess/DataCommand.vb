Namespace DataAccess

    ''' <summary>
    ''' The objects that inherit from this class may perform command executions to the data provider
    ''' </summary>
    Public Class DataCommand

        Private _CommandType As System.Data.CommandType
        ''' <summary>
        ''' Determines whether the type of command is a stored procedure or a sql statement
        ''' </summary>        
        Public Property CommandType() As System.Data.CommandType
            Get
                Return _CommandType
            End Get
            Set(ByVal value As System.Data.CommandType)
                _CommandType = value
            End Set
        End Property

        Private _Parameters As System.Collections.Generic.List(Of DataCommandParameter)
        ''' <summary>
        ''' Keeps the list of parameters associated with data command
        ''' </summary>        
        Public Property Parameters() As List(Of DataCommandParameter)
            Get
                If (_Parameters Is Nothing) Then
                    _Parameters = New List(Of DataCommandParameter)
                End If
                Return _Parameters
            End Get
            Set(ByVal value As List(Of DataCommandParameter))
                _Parameters = value
            End Set
        End Property

        Private _SQLCommand As String
        ''' <summary>
        ''' Sets or gets the data command sql statement
        ''' </summary>        
        Public Property SQLCommand() As String
            Get
                Return _SQLCommand
            End Get
            Set(ByVal value As String)
                _SQLCommand = value
            End Set
        End Property

        ''' <summary>
        ''' Adds a parameter to the command parameters collection of data.
        ''' </summary>
        ''' <param name="pParameterName">Specifies the parameter name</param>
        ''' <param name="pParameterValue">Determines the value of parameter</param>
        ''' <remarks></remarks>
        Public Sub AddParameter(ByVal pParameterName As String, ByVal pParameterType As System.Data.DbType, ByVal pParameterValue As Object)
            Dim lParameter As New DataCommandParameter(pParameterName, pParameterType, pParameterValue)

            Me.Parameters.Add(lParameter)
        End Sub

        ''' <summary>
        ''' Adds a parameter to the command parameters collection of data.
        ''' </summary>
        ''' <param name="pParameter">Specifies the parameter</param>        
        Public Sub AddParameter(ByVal pParameter As DataCommandParameter)
            Me.Parameters.Add(pParameter)
        End Sub
    End Class

End Namespace
