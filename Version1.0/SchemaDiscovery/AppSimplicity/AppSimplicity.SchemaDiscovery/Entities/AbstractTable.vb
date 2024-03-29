﻿Namespace Entities
    <Serializable()> _
    Public Class AbstractTable
        Inherits AbstractDataObject

        Public Enum ClassScopes
            _Public
            _Friend
            _Protected
        End Enum

        Private _Columns As List(Of Column)
        <System.ComponentModel.Browsable(False)> _
        Public Property Columns() As List(Of Column)
            Get
                If (_Columns Is Nothing) Then
                    _Columns = New List(Of Column)
                End If
                Return _Columns
            End Get
            Set(ByVal value As List(Of Column))
                _Columns = value
            End Set
        End Property

        Private _ClassName As String
        <Category("Code generation"), DisplayName("Class name"), Description("Sets the name of the target entity class."), PersistAfterRefreshSchema(True)> _
        Public Property ClassName() As String
            Get
                If (_ClassName = String.Empty) Then
                    _ClassName = Me.Name
                End If
                Return _ClassName
            End Get
            Set(ByVal value As String)
                _ClassName = value
            End Set
        End Property

        Private _PluralClassName As String
        <Category("Code generation"), DisplayName("Plural class name"), Description("Indicates the name of the name of the plural class"), PersistAfterRefreshSchema(True)> _
        Public Property PluralClassName() As String
            Get
                If (_PluralClassName = String.Empty) Then
                    _PluralClassName = Me.Name
                End If
                Return _PluralClassName
            End Get
            Set(ByVal value As String)
                _PluralClassName = value
            End Set
        End Property

        Private _Scope As ClassScopes = ClassScopes._Public
        <Category("Code generation"), DisplayName("Target scope"), Description("Indicates the scope of the generated entity class"), PersistAfterRefreshSchema(True)> _
        Public Property Scope() As ClassScopes
            Get
                Return _Scope
            End Get
            Set(ByVal value As ClassScopes)
                _Scope = value
            End Set
        End Property

        ''' <summary>
        ''' Looks for the instance of a column by name
        ''' </summary>
        ''' <param name="pColumnName">The name of the column</param>
        ''' <returns>If column is not found returns Nothing</returns>
        Public Function GetColumnInstanceByName(ByVal pColumnName As String) As Column
            Dim lReturnValue As Column = Nothing

            For Each lColumn In Me.Columns
                If (Trim(pColumnName).ToLower = lColumn.ColumnName.ToLower) Then
                    lReturnValue = lColumn
                    Exit For
                End If
            Next

            Return lReturnValue
        End Function
    End Class

End Namespace
