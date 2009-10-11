Imports System.Text

Namespace ActiveRecord
    Public Class ActiveRecord

        Private _Schema As Schema
        ''' <summary>
        ''' Gets the current mapped schema
        ''' </summary>
        ''' <value></value>        
        Public ReadOnly Property Schema() As Schema
            Get
                Return _Schema
            End Get
        End Property

        Private _DependencyCache As Dictionary(Of String, ActiveRecord)
        ''' <summary>
        ''' Stores objects in cache when an object is loaded with dependencies
        ''' </summary>        
        Public ReadOnly Property DependencyCache() As Dictionary(Of String, ActiveRecord)
            Get
                If (_DependencyCache Is Nothing) Then
                    _DependencyCache = New Dictionary(Of String, ActiveRecord)
                End If
                Return _DependencyCache
            End Get
        End Property

        Protected _IsLoadedFromDB As Boolean
        ''' <summary>
        ''' Indicates if instance has been loaded from the data source
        ''' </summary>
        Public ReadOnly Property IsLoadedFromDB()
            Get
                Return _IsLoadedFromDB
            End Get
        End Property

        Private _Values As Dictionary(Of String, DataValue)
        ''' <summary>
        ''' 
        ''' </summary>        
        Protected ReadOnly Property Values() As Dictionary(Of String, DataValue)
            Get
                If (_Values Is Nothing) Then
                    _Values = New Dictionary(Of String, DataValue)
                End If
                Return _Values
            End Get
        End Property

        Public ReadOnly Property Identity() As DataValue
            Get
                Return Me(Me.Schema.PrimaryKey.ColumnName)
            End Get
        End Property

        ''' <summary>
        ''' Obtiene la instancia del valor almacenado especificando la clave de la columna
        ''' </summary>
        ''' <param name="pKey">La clave de la columna</param>
        Default Public ReadOnly Property Item(ByVal pKey As String) As DataValue
            Get
                Return Me.Values(pKey)
            End Get
        End Property

        ''' <summary>
        ''' Initializes the values vector using schema information
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub InitializeValues()
            Me.Values.Clear()

            For Each lKey As String In Me.Schema.AllColumns
                Dim lDataValue As New DataValue(Me.Schema(lKey))

                lDataValue.Value = System.DBNull.Value
                Me.AddValue(lDataValue)
            Next

            Me._IsLoadedFromDB = False
        End Sub

        Private Sub AddValue(ByVal pValue As DataValue)
            Me.Values.Add(pValue.Column.ColumnName, pValue)
        End Sub

        ''' <summary>
        ''' Gets the record description
        ''' </summary>        
        Public Overridable ReadOnly Property ObjectDescription() As String
            Get
                Dim SB As New StringBuilder
                Dim lFirst As Boolean = True

                For Each lkey As String In Me.Schema.DescriptionColumns
                    If (lFirst) Then
                        SB.AppendFormat("{0}", Me(lkey).Value)
                        lFirst = False
                    Else
                        SB.AppendFormat(" - {0}", Me(lkey).Value)
                    End If
                Next

                Return SB.ToString
            End Get
        End Property

        Public Sub New(ByVal pSchema As Schema)
            Me._Schema = pSchema

            Me.InitializeValues()
        End Sub

        Public Overrides Function ToString() As String
            Try
                Return Me.ObjectDescription
            Catch ex As Exception
                Return My.Resources.LocalizableMessages.ToStringEx
            End Try
        End Function

#Region "Load record"
        ''' <summary>
        ''' Maps values to object from an existing recordset
        ''' </summary>
        ''' <param name="pDR">Datarow containing values</param>
        ''' <param name="pUseQualifiedNames">Sets if record must read values from qualified column names
        ''' (like [cutomers.id], [customers.name] and so on</param>
        Public Sub Load(ByVal pDR As DataRow, Optional ByVal pUseQualifiedNames As Boolean = False, Optional ByVal pFillDependencies As Boolean = True)
            For Each lColumn As String In Me._Schema.AllColumns
                If (pUseQualifiedNames) Then
                    Dim lQualifiedName = Me.Schema.DataService.Dialect.GetQualifiedColumnName(Me.Schema(lColumn))
                    If (pDR.Table.Columns.Contains(lQualifiedName)) Then
                        Me(lColumn).Value = pDR.Item(lQualifiedName)
                    End If
                Else
                    If (pDR.Table.Columns.Contains(lColumn)) Then
                        Me(lColumn).Value = pDR.Item(lColumn)
                    End If
                End If
            Next

            If (pUseQualifiedNames) Then
                If (pFillDependencies) Then
                    For Each lDependency As ForeignDependency In Me.Schema.Dependencies
                        Dim lInstance As New ActiveRecord(lDependency.BelongsToSchema)
                        lInstance.Load(pDR, pUseQualifiedNames, False)
                        Me.DependencyCache(lDependency.BelongsToSchema.TableName) = lInstance
                    Next
                End If
            End If
        End Sub

        Private Function FieldExists(ByVal pSchema As DataTable, ByVal pFieldName As String) As Boolean
            Dim lReturnValue As Boolean = False
            Dim lView As System.Data.DataView
            lView = pSchema.DefaultView
            lView.RowFilter = String.Format("ColumnName = '{0}'", pFieldName)

            If (lView.Count > 0) Then
                lReturnValue = True
            End If

            Return lReturnValue
        End Function

        ''' <summary>
        ''' Maps values to object from an existing recordset
        ''' </summary>
        ''' <param name="pReader">Previously connected datareader containing values</param>
        ''' <param name="pUseQualifiedNames">Sets if record must read values from qualified column names
        ''' (like [cutomers.id], [customers.name] and so on</param>
        Public Sub Load(ByVal pReader As System.Data.Common.DbDataReader, ByVal pSchemaTable As DataTable, Optional ByVal pUseQualifiedNames As Boolean = False, Optional ByVal pFillDependencies As Boolean = True)
            For Each lColumn As String In Me._Schema.AllColumns
                If (pUseQualifiedNames) Then
                    Dim lQualifiedName As String = Me.Schema.DataService.Dialect.GetQualifiedColumnName(Me.Schema(lColumn))

                    If (FieldExists(pSchemaTable, lQualifiedName)) Then
                        Me(lColumn).Value = pReader.Item(lQualifiedName)
                    End If
                Else

                    If (FieldExists(pSchemaTable, lColumn)) Then
                        Me(lColumn).Value = pReader.Item(lColumn)
                    End If
                End If
            Next

            If (pUseQualifiedNames) Then
                If (pFillDependencies) Then
                    For Each lDependency As ForeignDependency In Me.Schema.Dependencies
                        Dim lInstance As New ActiveRecord(lDependency.BelongsToSchema)
                        lInstance.Load(pReader, pSchemaTable, pUseQualifiedNames, False)
                        Me.DependencyCache(lDependency.BelongsToSchema.TableName) = lInstance
                    Next
                End If
            End If
        End Sub
#End Region

#Region "Data Access Methods"
        ''' <summary>
        ''' Saves data stored in current record. 
        ''' </summary>
        Public Sub Save()
            Dim lE As New ObjectBeforeOperationEventArgs

            RaiseEvent OnBeforeSave(lE)

            If (lE.PerformOperation) Then
                If (Me.IsLoadedFromDB) Then
                    Me.Update()
                Else
                    Me.Create()
                End If
            End If

            RaiseEvent OnAfterSave()
        End Sub

        ''' <summary>
        ''' Deletes data mapped on database
        ''' </summary>
        Public Function Delete() As Integer
            Dim lResult As Integer
            Dim lE As New ObjectBeforeOperationEventArgs

            RaiseEvent OnBeforeDelete(lE)

            If (lE.PerformOperation) Then
                lResult = Schema.Delete(Me)
                Me._IsLoadedFromDB = False
            End If

            RaiseEvent OnAfterDelete()

            Return lResult
        End Function

        ''' <summary>
        ''' Creates a new record on database from current object properties
        ''' </summary>
        ''' <returns>Returns false if creation did not perform</returns>
        Public Function Create() As Boolean
            Dim lResult As Boolean
            Dim lE As New ObjectBeforeOperationEventArgs()

            RaiseEvent OnBeforeCreate(lE)

            If (lE.PerformOperation) Then
                lResult = Schema.Create(Me)
            End If

            If lResult > 0 Then
                Me._IsLoadedFromDB = True
                RaiseEvent OnAfterCreate()
            End If

            Return lResult
        End Function

        ''' <summary>
        ''' Updates record on database from current object properties
        ''' </summary>
        ''' <returns>Returns the number of rows affected</returns>
        ''' <remarks>Id values must be assigned before calling this method, otherwise will throw a new exception</remarks>
        Public Function Update() As Integer
            Dim lResult As Integer
            Dim lE As New ObjectBeforeOperationEventArgs()

            RaiseEvent OnBeforeUpdate(lE)

            If (lE.PerformOperation) Then
                lResult = Schema.Update(Me)
                Me._IsLoadedFromDB = True
            End If

            RaiseEvent OnAfterUpdate()

            Return lResult
        End Function

        ''' <summary>
        ''' Loads object properties from database
        ''' </summary>
        ''' <returns>If load was successful returns a true value</returns>
        ''' <remarks>Id value must be filled in order to pick data from database</remarks>
        Public Function Load() As Boolean
            Dim lResult As Boolean = False

            If (Me.Schema.Read(Me)) Then
                Me._IsLoadedFromDB = True
                lResult = True
            End If

            Return lResult
        End Function
#End Region

#Region "Events"
        Public Event OnAfterLoad()
        Public Event OnBeforeCreate(ByVal e As ObjectBeforeOperationEventArgs)
        Public Event OnAfterCreate()
        Public Event OnBeforeUpdate(ByVal e As ObjectBeforeOperationEventArgs)
        Public Event OnAfterUpdate()
        Public Event OnBeforeDelete(ByVal e As ObjectBeforeOperationEventArgs)
        Public Event OnAfterDelete()
        Public Event OnBeforeSave(ByVal e As ObjectBeforeOperationEventArgs)
        Public Event OnAfterSave()
#End Region

    End Class

    Public Class ObjectBeforeOperationEventArgs
        Inherits System.EventArgs

        Private _PerformOperation As Boolean = True
        Public Property PerformOperation() As Boolean
            Get
                Return _PerformOperation
            End Get
            Set(ByVal value As Boolean)
                _PerformOperation = value
            End Set
        End Property
    End Class

End Namespace
