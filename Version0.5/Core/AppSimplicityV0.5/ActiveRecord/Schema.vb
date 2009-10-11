﻿Namespace ActiveRecord
    ''' <summary>
    ''' An object derived from this class has a map of an existing physical table
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Schema
        Private _Dictionary As Dictionary(Of String, SchemaColumn)
        Private ReadOnly Property Dictionary() As Dictionary(Of String, SchemaColumn)
            Get
                If (_Dictionary Is Nothing) Then
                    _Dictionary = New Dictionary(Of String, SchemaColumn)
                End If
                Return _Dictionary
            End Get
        End Property

        Private _TableName As String
        ''' <summary>
        ''' Gets the name of the physical mapped table
        ''' </summary>
        Public ReadOnly Property TableName() As String
            Get
                Return _TableName
            End Get
        End Property

        Private _Dependencies As List(Of ForeignDependency)
        ''' <summary>
        ''' Obtiene las dependencias con otras tablas
        ''' </summary>        
        Public ReadOnly Property Dependencies() As List(Of ForeignDependency)
            Get
                If (_Dependencies Is Nothing) Then
                    _Dependencies = New List(Of ForeignDependency)
                End If
                Return _Dependencies
            End Get
        End Property

        Private WithEvents _DataService As DataAccess.DataService
        Public ReadOnly Property DataService() As DataAccess.DataService
            Get
                Return _DataService
            End Get
        End Property

        Public ReadOnly Property IdIsAutogenerated() As Boolean
            Get
                If (Me.PrimaryKey.AutoIncrement) Then Return True
                Return False
            End Get
        End Property

        ''' <summary>
        ''' Obtiene la instancia de la columna determinada por la clave
        ''' </summary>
        ''' <param name="pKey">La clave de la columna (el nombre de la columna en la tabla físicamente mapeada)</param>
        ''' <value></value>
        Default Public ReadOnly Property Item(ByVal pKey As String) As SchemaColumn
            Get
                Return Me.Dictionary(pKey)
            End Get
        End Property

        Private _AllColumns As List(Of String)
        ''' <summary>
        ''' Contiene la lista de las columnas declaradas dentro del esquema
        ''' </summary>
        Public ReadOnly Property AllColumns() As List(Of String)
            Get
                If (_AllColumns Is Nothing) Then
                    _AllColumns = New List(Of String)

                    For Each lKey As String In Me.Dictionary.Keys
                        _AllColumns.Add(lKey)
                    Next
                End If
                Return _AllColumns
            End Get
        End Property

        ''' <summary>
        ''' Agrega la definición de una columna
        ''' </summary>
        ''' <param name="pColumn">La instancia preconfigurada de la columna</param>
        Public Sub AddColumn(ByVal pColumn As SchemaColumn)

            If (pColumn.IsPrimaryKey) Then
                If Not (Me._PrimaryKey Is Nothing) Then
                    Throw New Exception(My.Resources.LocalizableMessages.MoreThanOnePrimaryKey)
                Else
                    Me._PrimaryKey = pColumn
                End If
            End If

            pColumn.Schema = Me
            Me.Dictionary.Add(pColumn.ColumnName, pColumn)
        End Sub

        Private _IsReadOnly As Boolean = False
        ''' <summary>
        ''' Determina si los objetos que utilicen este esquema podrán realizar operaciones de escritura hacia la tabla física.
        ''' </summary>
        ''' <remarks>Las vistas son tablas acceso de sólo lectura</remarks>
        Public Property IsReadOnly() As Boolean
            Get
                Return _IsReadOnly
            End Get
            Set(ByVal value As Boolean)
                _IsReadOnly = True
            End Set
        End Property

        Private _DescriptionColumns As List(Of String)
        ''' <summary>
        ''' Gets the list of column names that describe the object instance
        ''' </summary>        
        Public ReadOnly Property DescriptionColumns() As List(Of String)
            Get
                If _DescriptionColumns Is Nothing Then
                    _DescriptionColumns = New List(Of String)

                    For Each lkey As String In Me.AllColumns
                        If Me(lkey).IsDescription Then
                            _DescriptionColumns.Add(lkey)
                        End If
                    Next
                End If

                Return _DescriptionColumns
            End Get
        End Property

        Private _PrimaryKey As SchemaColumn
        Public ReadOnly Property PrimaryKey() As SchemaColumn
            Get
                If (_PrimaryKey Is Nothing) Then
                    Throw New Exception(String.Format(My.Resources.LocalizableMessages.NoPrimaryKey, Me.TableName))
                End If
                Return _PrimaryKey
            End Get
        End Property

        Private _PrimaryKeys As List(Of SchemaColumn)
        ''' <summary>
        ''' Obtiene la lista de la columna  (o columnas) que definen la llave primaria
        ''' </summary>
        ''' <returns>Devuelve la lista de las columnas que definen la llave primaria</returns>
        Public ReadOnly Property PrimaryKeys() As List(Of SchemaColumn)
            Get
                If (_PrimaryKeys Is Nothing) Then
                    _PrimaryKeys = Me.GetPrimaryKeys()
                End If
                Return _PrimaryKeys
            End Get
        End Property

        ''' <summary>
        ''' Obtiene la colección de las llaves primarias declaradas en el esquema
        ''' </summary>
        ''' <returns>Devuelve la instancia de la coleccion de las llaves primarias</returns>
        Private Function GetPrimaryKeys() As List(Of SchemaColumn)
            Dim lReturnValue As New List(Of SchemaColumn)

            For Each lKey As String In Me.Dictionary.Keys
                If (Me(lKey).IsPrimaryKey) Then
                    lReturnValue.Add(Me(lKey))
                End If
            Next

            If (lReturnValue.Count = 0) Then
                Throw New Exception(String.Format(My.Resources.LocalizableMessages.NoPrimaryKey, Me.TableName))
            End If

            Return lReturnValue
        End Function

        ''' <summary>
        ''' Averigua si un determinado nombre de columna está definido dentro del esquema
        ''' </summary>
        ''' <param name="pKey">Un nombre de columna</param>
        ''' <returns>Devuelve True cuando el nombre de la columna existe</returns>
        Public Function Contains(ByVal pKey As String) As Boolean
            Return Me.Dictionary.ContainsKey(pKey)
        End Function

        ''' <summary>
        ''' Valida si un nombre determinado de columna existe dentro del esquema
        ''' </summary>
        ''' <param name="pColumnName"></param>
        ''' <remarks></remarks>
        Public Sub ValidateColumnName(ByVal pColumnName As String)
            If Not Me.Contains(pColumnName) Then
                Throw New Exception(String.Format("La columna [{0}] no existe en el esquema de la tabla [{1}]", pColumnName, Me.TableName))
            End If
        End Sub

#Region "Data Access Methods"
        Public Function Create(ByVal pRecord As ActiveRecord) As Boolean
            Dim lEverythingOK As Boolean = True

            Try
                Dim lIdentity As Object

                lIdentity = Me.DataService.Helper._INSERT(pRecord).ExecuteScalar()

                pRecord.Identity.Value = lIdentity
            Catch ex As Exception
                lEverythingOK = False
            End Try

            Return lEverythingOK
        End Function

        Public Function Update(ByVal pRecord As ActiveRecord) As Integer
            Dim lResult As Integer

            Return lResult
        End Function

        Public Function Delete(ByVal pRecord As ActiveRecord) As Integer
            Dim lResult As Integer = 0

            lResult = Me.DataService.Helper._DELETE(pRecord).ExecuteScalar

            Return lResult
        End Function



        Public Function Read(ByVal pRecord As ActiveRecord) As Boolean
            Dim lResult As Boolean = True

            If (Me.DataService.Provider.DataAccessMode = DataAccess.Providers.Provider.DataAccesModes.ConnectedReaders) Then
                Dim DR As System.Data.Common.DbDataReader = Nothing

                Try
                    DR = Me.DataService.Helper._READ(pRecord).ExecuteDatareader

                    If Not (DR Is Nothing) Then
                        If (DR.HasRows) Then
                            DR.Read()
                            lResult = True
                            pRecord.Load(DR, DR.GetSchemaTable(), True, False)
                        End If
                    End If

                    DR.Close()
                Catch ex As Exception
                    If Not (DR Is Nothing) Then
                        If Not (DR.IsClosed) Then
                            DR.Close()
                        End If
                    End If

                    lResult = False
                End Try
            Else
                Dim DS As DataSet

                Try
                    DS = Me.DataService.Helper._READ(pRecord).ExecuteDataSet

                    If Not (DS Is Nothing) Then
                        If (DS.Tables.Count > 0) Then
                            If (DS.Tables(0).Rows.Count > 0) Then
                                pRecord.Load(DS.Tables(0).Rows(0), True, False)
                            End If
                        End If
                    End If

                Catch ex As Exception

                End Try
            End If


            Return lResult
        End Function
#End Region

#Region "CRUD Strings"
        Private _INSERT_Statement As String = String.Empty
        Public ReadOnly Property INSERT_Statement() As String
            Get
                If (Me._INSERT_Statement = String.Empty) Then
                    _INSERT_Statement = Me.DataService.Dialect.GetInsertStatement(Me)
                End If
                Return Me._INSERT_Statement
            End Get
        End Property

        Private _SELECT_BY_ID_Statement As String = String.Empty
        Public ReadOnly Property SELECT_BY_ID_Statement() As String
            Get
                If (Me._SELECT_BY_ID_Statement = String.Empty) Then
                    _SELECT_BY_ID_Statement = Me.DataService.Dialect.GetSelectByIdStatement(Me)
                End If
                Return Me._SELECT_BY_ID_Statement
            End Get
        End Property

        Private _UPDATE_Statement As String = String.Empty
        Public ReadOnly Property UPDATE_Statement() As String
            Get
                If (Me._UPDATE_Statement = String.Empty) Then
                    Me._UPDATE_Statement = Me.DataService.Dialect.GetUpdateStatement(Me)
                End If
                Return Me._UPDATE_Statement
            End Get
        End Property

        Private _DELETE_Statement As String = String.Empty
        Public ReadOnly Property DELETE_Statement() As String
            Get
                If (_DELETE_Statement = String.Empty) Then
                    _DELETE_Statement = Me.DataService.Dialect.GetDeletetStatement(Me)
                End If
                Return _DELETE_Statement
            End Get
        End Property
#End Region

#Region ".ctors"
        ''' <summary>
        ''' Initializes an Schema
        ''' </summary>
        ''' <param name="pTableName">The name of the table or view</param>
        ''' <param name="pIsReadOnly">Determina si las operaciones para este esquema será de sólo lectura</param>
        ''' <remarks>Las vistas deberán ser inicializadas como sólo lectura ('ReadOnly')</remarks>
        Public Sub New(ByVal pTableName As String, ByVal pDataService As DataAccess.DataService, ByVal pIsReadOnly As Boolean)
            _TableName = pTableName
            _IsReadOnly = pIsReadOnly
            _DataService = pDataService
        End Sub
#End Region

        Private Sub ClearStatements()
            Me._INSERT_Statement = String.Empty
            Me._UPDATE_Statement = String.Empty
            Me._DELETE_Statement = String.Empty
            Me._SELECT_BY_ID_Statement = String.Empty
        End Sub

        Private Sub _DataService_OnCommandTypeSelection() Handles _DataService.OnCommandTypeSelection
            Me.ClearStatements()
        End Sub
    End Class
End Namespace