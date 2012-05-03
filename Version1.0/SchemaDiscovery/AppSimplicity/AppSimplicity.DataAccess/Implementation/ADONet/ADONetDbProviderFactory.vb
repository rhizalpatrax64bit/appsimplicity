Imports System.Data.Common

Public Class ADONetDbProviderFactory
    ''' <summary>
    ''' Gets the instance of the ADO.Net data access provider with a given invariant name.
    ''' </summary>
    ''' <param name="pProviderInvariantName">The invariant name of the provider factory</param>
    ''' <returns></returns>
    ''' <remarks>If provider was not found it will throw an exception.</remarks>
    Public Shared Function GetADONetDBFactory(ByVal pProviderInvariantName As String) As System.Data.Common.DbProviderFactory
        Dim lReturnValue As System.Data.Common.DbProviderFactory

        lReturnValue = DbProviderFactories.GetFactory(pProviderInvariantName)

        If (lReturnValue Is Nothing) Then
            Throw New Exception(String.Format(My.Resources.Exceptions.DATA_PROVIDER_NOT_FOUND, pProviderInvariantName))
        End If

        Return lReturnValue
    End Function

End Class
