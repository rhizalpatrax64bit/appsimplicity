Public Class MetaDataSource


    ''' <summary>
    ''' Fetchs a project given the connection 
    ''' </summary>
    ''' <param name="pConnectionStringName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FetchDataSource(ByVal pConnectionStringName As String) As MetaProject
        Dim lDS As AppSimplicity.DataAccess.DataSource
        Dim lProject As MetaProject = Nothing
        lDS = AppSimplicity.DataAccess.DataSource.GetDataSourceFromConfigFile(pConnectionStringName)

        If Not (lDS Is Nothing) Then
            lProject = New MetaProject(lDS)
        End If

        Return lProject
    End Function

End Class
