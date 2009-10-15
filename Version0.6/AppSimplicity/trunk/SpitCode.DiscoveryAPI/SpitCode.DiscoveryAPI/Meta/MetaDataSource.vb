Public Class MetaDataSource

    Private _Tables As List(Of MetaTable)
    Public ReadOnly Property Tables() As List(Of MetaTable)
        Get
            If _Tables Is Nothing Then

            End If
            Return _Tables
        End Get
    End Property

    ''' <summary>
    ''' Fetchs a project given the connection 
    ''' </summary>
    ''' <param name="pConnectionStringName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FetchDataSource(ByVal pConnectionStringName As String) As MetaDataSource
        Dim lDS As AppSimplicity.DataAccess.DataSource
        Dim lDataSource As MetaDataSource = Nothing
        lDS = AppSimplicity.DataAccess.DataSource.GetDataSourceFromConfigFile(pConnectionStringName)

        If Not (lDS Is Nothing) Then
            'lProject = New MetaProject(lDS)
        End If

        'Return lProject
    End Function

End Class
