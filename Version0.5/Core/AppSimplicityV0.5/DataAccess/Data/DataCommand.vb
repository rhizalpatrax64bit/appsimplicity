Imports System.Data.Common

Namespace DataAccess
    Public Class DataCommand
#Region "Properties"
        Private _Parameters As List(Of DataParameter)

        Public Property Parameters() As List(Of DataParameter)
            Get
                If (_Parameters Is Nothing) Then
                    _Parameters = New List(Of DataParameter)
                End If
                Return _Parameters
            End Get
            Set(ByVal value As List(Of DataParameter))
                _Parameters = value
            End Set
        End Property

        Private _Provider As DataAccess.Providers.Provider
        Private ReadOnly Property Provider() As DataAccess.Providers.Provider
            Get
                Return _Provider
            End Get
        End Property

        Private _SQLStatement As String
        Public Property SQLStatement() As String
            Get
                Return _SQLStatement
            End Get
            Set(ByVal value As String)
                _SQLStatement = value
            End Set
        End Property

        Private _SQLStatementType As System.Data.CommandType
        Public Property SQLStatementType() As System.Data.CommandType
            Get
                Return _SQLStatementType
            End Get
            Set(ByVal value As System.Data.CommandType)
                _SQLStatementType = value
            End Set
        End Property
#End Region

#Region ".ctors"
        Public Sub New(ByVal pProvider As DataAccess.Providers.Provider, ByVal pSQLStatement As String, ByVal pType As System.Data.CommandType, Optional ByVal pParameters As List(Of DataParameter) = Nothing)
            Me._Provider = pProvider
            Me._SQLStatement = pSQLStatement
            Me._SQLStatementType = pType
            Me._Parameters = pParameters
        End Sub

        Public Sub New(ByVal pProvider As DataAccess.Providers.Provider)
            Me._Provider = pProvider
        End Sub
#End Region

        ''' <summary>
        ''' Ejecuta una operación SQL, el resultado es un resultset de 1x1 
        ''' </summary>
        ''' <returns>Devuelve en un objeto el resultado de la operación</returns>
        Public Function ExecuteScalar() As Object
            Return Me.Provider.ExecuteScalar(Me)
        End Function

        ''' <summary>
        ''' Ejecuta una operación SQL, devolviendo el resultado en un objeto DataSet
        ''' </summary>
        ''' <returns>Devuelve en un objeto Dataset el resultado de la operación</returns>
        Public Function ExecuteDataSet() As DataSet
            Return Me.Provider.ExecuteDataset(Me)
        End Function

        ''' <summary>
        ''' Ejecuta una operación SQL, devuelve el número de filas afectadas
        ''' </summary>
        ''' <returns>Devuelve el número de filas afectadas</returns>
        Public Function ExecuteNonQuery() As Integer
            Return Me.Provider.ExecuteNonQuery(Me)
        End Function

        ''' <summary>
        ''' Ejecuta una operación SQL, devuelve el número el objeto de lectura secuencial del resultado de datos
        ''' </summary>
        Public Function ExecuteDatareader() As DbDataReader
            Return Me.Provider.ExecuteDataReader(Me)
        End Function

        ''' <summary>
        ''' Agrega un parametro con su respectivo valor a la lista de parametros del comando
        ''' </summary>
        ''' <param name="pParameterName">Nombre del parametro</param>
        ''' <param name="pValue">Valor del parametro</param>
        Public Sub AddParameter(ByVal pParameterName As String, ByVal pValue As Object)
            Me.Parameters.Add(New DataParameter(pParameterName, pValue))
        End Sub
    End Class
End Namespace
