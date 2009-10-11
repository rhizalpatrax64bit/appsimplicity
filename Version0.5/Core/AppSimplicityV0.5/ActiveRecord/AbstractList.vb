Imports System.Data.Common
Imports System.ComponentModel

Namespace ActiveRecord
    ''' <summary>
    ''' Class to implement an Abstract List of RecordBase Objects
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <remarks></remarks>
    <Serializable()> _
    Public MustInherit Class AbstractList(Of T As ActiveRecord)
        Inherits System.ComponentModel.BindingList(Of T)

        ''' <summary>
        ''' Indicates if collection has one item or more
        ''' </summary>        
        Public ReadOnly Property HasItems() As Boolean
            Get
                Dim lResult As Boolean = False
                If (Me.Count > 0) Then
                    lResult = True
                End If
                Return lResult
            End Get
        End Property

        Private _Schema As Schema
        ''' <summary>
        ''' Obtiene el esquema de la colección
        ''' </summary>        
        Public Property Schema() As Schema
            Get
                Return _Schema
            End Get
            Set(ByVal value As Schema)
                _Schema = value
            End Set
        End Property

        Public Sub New(ByVal pSchema As Schema)
            Me._Schema = pSchema
        End Sub

        Public MustOverride Sub FillCollection(ByVal pDS As DataSet, Optional ByVal pUseQualifiedNames As Boolean = False)

        Public MustOverride Sub FillCollection(ByVal pDR As System.Data.Common.DbDataReader, Optional ByVal pUseQualifiedNames As Boolean = False)

#Region "GetDataTable"
        Private Function IsRecordBase(ByVal pType As Type) As Boolean
            If Not (pType.BaseType Is Nothing) Then
                If (pType.BaseType.FullName = "AppSimplicity.ActiveRecord.RecordBase") Then
                    Return True
                End If
            End If

            Return False
        End Function

        Private Function IsBindableType(ByVal pType As Type) As Boolean
            Dim lValue As Boolean = False

            If (pType.IsPrimitive) Then
                Return True
            End If

            If (pType Is GetType(String)) Then
                Return True
            End If

            If (pType Is GetType(DateTime)) Then
                Return True
            End If

            If (pType Is GetType(Guid)) Then
                Return True
            End If

            Return False
        End Function

        ''' <summary>
        ''' Obtiene la instancia de una tabla con la información de los objetos contenidos en la colección
        ''' </summary>        
        Public Function GetDataTable() As DataTable
            Dim DT As New DataTable

            Dim PropList As New List(Of System.ComponentModel.PropertyDescriptor)

            'Verificar si la colección tiene registros
            If (Me.Count > 0) Then

                'Obtener las propiedades del primer objeto
                Dim lInstance As Object = Me(0)

                'Obtener únicamente las propiedades que son "Bindable(True)"
                Dim lProperties As System.ComponentModel.PropertyDescriptorCollection = TypeDescriptor.GetProperties(lInstance.GetType, New Attribute() {New System.ComponentModel.BindableAttribute(True)})

                'Obtener las propiedades, mapearlas a columnas en la tabla
                For Each lProp As System.ComponentModel.PropertyDescriptor In lProperties
                    Dim lIncludeColumn As Boolean = False
                    Dim lColumn As New DataColumn(lProp.Name)
                    If (IsRecordBase(lProp.PropertyType)) Then
                        lColumn.DataType = GetType(String)
                        lIncludeColumn = True
                    Else
                        If (IsBindableType(lProp.PropertyType)) Then
                            lColumn.DataType = lProp.PropertyType
                            lIncludeColumn = True
                        End If
                    End If

                    If (lIncludeColumn) Then
                        DT.Columns.Add(lColumn)

                        PropList.Add(lProp)
                    End If
                Next

                DT.AcceptChanges()

                Dim DR As DataRow
                'Obtener el contenido de la colección y asignarlo:
                For Each ItemInstance As ActiveRecord In Me
                    DR = DT.NewRow()
                    For Each lProp As System.ComponentModel.PropertyDescriptor In PropList
                        Dim lValue As Object = Nothing
                        lValue = ItemInstance.GetType.InvokeMember(lProp.Name, Reflection.BindingFlags.GetProperty, Nothing, ItemInstance, Nothing)

                        If (IsRecordBase(lProp.PropertyType)) Then
                            If (lValue Is Nothing) Then
                                lValue = System.DBNull.Value
                            Else
                                lValue = ItemInstance.ObjectDescription
                            End If
                        End If

                        DR.Item(lProp.Name) = lValue
                    Next

                    DT.Rows.Add(DR)
                Next

                DT.AcceptChanges()
            End If

            Return DT
        End Function

        ''' <summary>
        ''' Obtiene la instancia de una tabla con la información de los objetos contenidos en la colección
        ''' </summary>        
        Public Function GetDataTable(ByVal pSelectList As String()) As DataTable
            Dim DT As New DataTable

            Dim PropList As New List(Of System.ComponentModel.PropertyDescriptor)

            'Verificar si la colección tiene registros
            If (Me.Count > 0) Then

                'Obtener las propiedades del primer objeto
                Dim lInstance As Object = Me(0)

                'Obtener únicamente las propiedades que son "Bindable(True)"
                Dim lProperties As System.ComponentModel.PropertyDescriptorCollection = TypeDescriptor.GetProperties(lInstance.GetType, New Attribute() {New System.ComponentModel.BindableAttribute(True)})


                'Only those selected by selectlist:
                Dim lSelectList As New List(Of System.ComponentModel.PropertyDescriptor)
                For Each lProperty As String In pSelectList
                    For Each lProp As System.ComponentModel.PropertyDescriptor In lProperties
                        If (lProp.Name.ToLower = lProperty.ToLower) Then
                            lSelectList.Add(lProp)
                        End If
                    Next
                Next

                'Obtener las propiedades, mapearlas a columnas en la tabla
                For Each lProp As System.ComponentModel.PropertyDescriptor In lSelectList
                    Dim lIncludeColumn As Boolean = False
                    Dim lColumn As New DataColumn(lProp.Name)
                    If (IsRecordBase(lProp.PropertyType)) Then
                        lColumn.DataType = GetType(String)
                        lIncludeColumn = True
                    Else
                        If (IsBindableType(lProp.PropertyType)) Then
                            lColumn.DataType = lProp.PropertyType
                            lIncludeColumn = True
                        End If
                    End If

                    If (lIncludeColumn) Then
                        DT.Columns.Add(lColumn)

                        PropList.Add(lProp)
                    End If
                Next

                DT.AcceptChanges()

                Dim DR As DataRow
                'Obtener el contenido de la colección y asignarlo:
                For Each ItemInstance As ActiveRecord In Me
                    DR = DT.NewRow()
                    For Each lProp As System.ComponentModel.PropertyDescriptor In lSelectList
                        Dim lValue As Object = Nothing
                        lValue = ItemInstance.GetType.InvokeMember(lProp.Name, Reflection.BindingFlags.GetProperty, Nothing, ItemInstance, Nothing)

                        If (IsRecordBase(lProp.PropertyType)) Then
                            If (lValue Is Nothing) Then
                                lValue = System.DBNull.Value
                            Else
                                lValue = ItemInstance.ObjectDescription
                            End If
                        End If

                        DR.Item(lProp.Name) = lValue
                    Next

                    DT.Rows.Add(DR)
                Next

                DT.AcceptChanges()
            End If

            Return DT
        End Function
#End Region

    End Class
End Namespace
