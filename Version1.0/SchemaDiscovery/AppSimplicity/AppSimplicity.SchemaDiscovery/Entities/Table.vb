﻿Namespace Entities
    <Serializable()> _
    Public Class Table
        Inherits AbstractTable

        Private _IncludeForDataScripting As Boolean
        <Category("Scripting options"), DisplayName("Include for data scripting"), Description("Determines if this table should be included for data scripting")> _
        Public Property IncludeForDataScripting() As Boolean
            Get
                Return _IncludeForDataScripting
            End Get
            Set(ByVal value As Boolean)
                _IncludeForDataScripting = value
            End Set
        End Property

        Private _Keys As List(Of TableKey)
        <Browsable(False)> _
        Public Property Keys() As List(Of TableKey)
            Get
                If (_Keys Is Nothing) Then
                    _Keys = New List(Of TableKey)
                End If
                Return _Keys
            End Get
            Set(ByVal value As List(Of TableKey))
                _Keys = value
            End Set
        End Property

        Private _PrimaryKey As TableKey = Nothing
        <Category("Metadata"), DisplayName("Primary key"), Description("The name of the primary key"), [ReadOnly](True)> _
        Public ReadOnly Property PrimaryKey As TableKey
            Get
                If (_PrimaryKey Is Nothing) Then
                    _PrimaryKey = GetPrimaryKey()
                End If
                Return _PrimaryKey
            End Get
        End Property

        Private Function GetPrimaryKey() As TableKey
            Dim lReturnValue As TableKey = Nothing

            For Each lkey As TableKey In Me.Keys
                If (lkey.KeyType = KeyTypes.PrimaryKey) Then
                    lReturnValue = lkey
                    Exit For
                End If
            Next

            Return lReturnValue
        End Function

    End Class
End Namespace
