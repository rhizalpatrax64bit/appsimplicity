Imports System.Configuration

Public Class MetaDataProviderFactory
    Private _Providers As Dictionary(Of String, String)

    Private Sub InitializeProviders()
        _Providers = New Dictionary(Of String, String)
        Dim lConfiguration As MetaDataProviderSection = ConfigurationManager.GetSection("AppSimplicity.SchemaDiscovery")

        If Not (lConfiguration Is Nothing) Then
            For Each Element As MetaDataProviderElement In lConfiguration.Providers
                _Providers(Element.InvariantName) = Element.ProviderType
            Next
        End If
    End Sub

    Public Sub New()
        Me.InitializeProviders()
    End Sub

    ''' <summary>
    ''' Loads the instance of the metadata provider from a given connection string provider invariant name.
    ''' </summary>
    ''' <param name="providerInvariantName">The name of the provider</param>    
    Public Function LoadImplementation(providerInvariantName As String) As SchemaDiscovery.IMetaDataProvider
        Dim lReturnValue As SchemaDiscovery.IMetaDataProvider = Nothing

        If (_Providers.ContainsKey(providerInvariantName)) Then
            lReturnValue = Activator.CreateInstance(Type.GetType(_Providers(providerInvariantName)))
        End If

        Return lReturnValue
    End Function

    ''' <summary>
    ''' Given a connection string, returns the implementation for IMetadataProvider
    ''' </summary>
    ''' <param name="invariantName">The instance of the connection string</param>
    ''' <returns>Returns an instance of the mapped provider.</returns>
    Public Shared Function GetInstance(invariantName As String) As SchemaDiscovery.IMetaDataProvider
        Dim lFactory As New MetaDataProviderFactory()
        Return lFactory.LoadImplementation(invariantName)
    End Function
End Class
