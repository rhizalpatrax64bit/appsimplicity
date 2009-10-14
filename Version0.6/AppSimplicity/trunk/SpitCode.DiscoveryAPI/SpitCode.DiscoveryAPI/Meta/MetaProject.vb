﻿Public Class MetaProject

    Private _Tables As List(Of MetaTable)
    Public ReadOnly Property Tables() As List(Of MetaTable)
        Get
            If _Tables Is Nothing Then

            End If
            Return _Tables
        End Get
    End Property


    Public Sub New(ByVal pDataSource As AppSimplicity.DataAccess.DataSource)

    End Sub

    ''' <summary>
    ''' Fetchs a project given the connection 
    ''' </summary>
    ''' <param name="pConnectionStringName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FetchProject(ByVal pConnectionStringName As String) As MetaProject
        Dim lDS As AppSimplicity.DataAccess.DataSource
        Dim lProject As MetaProject = Nothing
        lDS = AppSimplicity.DataAccess.DataSource.GetDataSourceFromConfigFile(pConnectionStringName)

        If Not (lDS Is Nothing) Then
            lProject = New MetaProject(lDS)
        End If

        Return lProject
    End Function

End Class