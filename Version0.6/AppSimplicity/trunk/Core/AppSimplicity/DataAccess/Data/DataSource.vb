Imports System.Configuration

Namespace DataAccess
    Public Class DataSource

        Public Enum ProviderTypes
            ''' <summary>
            ''' SqlClient ADO.Net Provider
            ''' </summary>
            SQLServer = 1
            ''' <summary>           
            ''' Oracle data access provider (not implemented yet)
            ''' </summary>
            Oracle = 2
            ''' <summary>
            ''' MySQL connector data access provider
            ''' </summary>
            MySQL = 3
            ''' <summary>
            ''' SQLite data access provider
            ''' </summary>
            SQLite = 4
            ''' <summary>
            ''' OLEDB Microsoft Access data access provider
            ''' </summary>
            OleDB = 5
            ''' <summary>
            ''' Oracle 10g data access provider
            ''' </summary>
            Oracle10g = 6
            ''' <summary>
            ''' SQL Server CE data access provider
            ''' </summary>
            ''' <remarks></remarks>
            SQLServerCE = 7
        End Enum

        Private ProviderNames As String() = {"SQLServer", "SQLServerCE", "Oracle", "Oracle10g", "MySQL", "SQLite", "OleDB"}
        ''' <summary>
        ''' Returns a list of valid provider names
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property ValidProviderNames() As String
            Get
                Dim lNames As String = String.Empty

                For Each lName As String In Me.ProviderNames
                    lNames = lNames & String.Format(" '{0}'", lName)
                Next

                Return lNames
            End Get
        End Property

        Private _Name As String
        ''' <summary>
        ''' Sets or gets the DataSource name
        ''' </summary>
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Public Sub New(ByVal pProviderName As String)
            Me.ProviderName = pProviderName
        End Sub

        Private _ProviderName As String
        ''' <summary>
        ''' Sets or gets the data access provider name
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ProviderName() As String
            Get
                Return _ProviderName
            End Get
            Set(ByVal value As String)
                Dim lValidName As Boolean = False

                If (value = String.Empty) Then
                    'TODO: FIXTHIS
                    'Throw New Exception(My.Resources.LocalizableMessages.ProviderNameIsEmpty)
                End If

                For Each lName As String In ProviderNames
                    If (lName.ToLower = value.ToLower) Then
                        lValidName = True
                        _ProviderName = value
                        Exit For
                    End If
                Next

                If Not (lValidName) Then
                    'TODO: Fixthis:
                    'Throw New Exception(String.Format(My.Resources.LocalizableMessages.InvalidDataSourceName, value, Me.ValidProviderNames))
                End If
            End Set
        End Property

        Private _ConnectionString As String
        ''' <summary>
        ''' Obtiene o establece la cadena de conexion de la fuente de datos
        ''' </summary>
        Public Property ConnectionString() As String
            Get
                Return _ConnectionString
            End Get
            Set(ByVal value As String)
                _ConnectionString = value
            End Set
        End Property

        Private _TimeOut As Integer = 6000
        ''' <summary>
        ''' Obtiene o establece el tiempo de espera para la ejecución de comandos
        ''' </summary>
        ''' <remarks>If command execution time exceeds this value a connection timeout exception will be thrown</remarks>
        Public Property TimeOut() As Integer
            Get
                Return _TimeOut
            End Get
            Set(ByVal value As Integer)
                _TimeOut = value
            End Set
        End Property

        Private _IsEncrypted As Boolean = False
        ''' <summary>
        ''' Obtiene o establece si la cadena de conexión se encuentra encriptada
        ''' </summary>
        ''' <value></value>
        Public Property IsEncrypted() As Boolean
            Get
                Return _IsEncrypted
            End Get
            Set(ByVal value As Boolean)
                _IsEncrypted = value
            End Set
        End Property

        Private _Description As String
        ''' <summary>
        ''' Obtiene o establece una descripción breve del propósito de la fuente de datos
        ''' </summary>
        ''' <value></value>
        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property

        'TODO: Escribir y validar otros proveedores de datos:
        Private _ProviderType As ProviderTypes = ProviderTypes.SQLServer
        ''' <summary>
        ''' Obtiene el tipo de proveedor asociado al ambiente de conexión
        ''' </summary>
        ''' <remarks>Si el nombre del proveedor no es especificado el tipo del proveedor por defecto es SQLServer</remarks>
        Public ReadOnly Property ProviderType() As ProviderTypes
            Get
                Select Case (_ProviderName.ToLower)
                    Case "SQLServer".ToLower
                        _ProviderType = ProviderTypes.SQLServer
                    Case "SQLServerCE".ToLower
                        _ProviderType = ProviderTypes.SQLServerCE
                    Case "Oracle".ToLower
                        _ProviderType = ProviderTypes.Oracle
                    Case "Oracle10g".ToLower
                        _ProviderType = ProviderTypes.Oracle10g
                    Case "MySQL".ToLower
                        _ProviderType = ProviderTypes.MySQL
                    Case "SQLite".ToLower
                        _ProviderType = ProviderTypes.SQLite
                    Case "OleDB".ToLower
                        _ProviderType = ProviderTypes.OleDB
                    Case Else
                        _ProviderType = ProviderTypes.SQLServer
                End Select
                Return _ProviderType
            End Get
        End Property

        ''' <summary>
        ''' Obtiene la instancia de una fuente de datos a partir de la cadena de conexión declarada en el archivo .config
        ''' </summary>
        ''' <param name="pKey">Nombre de la clave de la fuente de datos</param>
        Public Shared Function GetDataSourceFromConfigFile(ByVal pKey As String) As DataSource
            Dim lValue As DataSource = Nothing
            Dim CS As ConnectionStringSettings

            CS = System.Configuration.ConfigurationManager.ConnectionStrings(pKey)

            If Not (CS Is Nothing) Then
                lValue = New DataSource(CS.ProviderName)
                lValue.Name = CS.Name
                lValue.ConnectionString = CS.ConnectionString
                lValue.TimeOut = 6000
            End If

            Return lValue
        End Function

    End Class
End Namespace
