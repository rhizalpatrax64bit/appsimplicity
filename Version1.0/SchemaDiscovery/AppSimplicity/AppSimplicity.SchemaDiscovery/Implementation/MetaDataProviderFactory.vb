Public Class MetaDataProviderFactory
    Inherits DependencyInjection.AbstractObjectFactory(Of IMetaDataProvider)

    Public Sub New()
        MyBase.New(String.Format("{0}\{1}", Common.Constants.SCHEMA_PATH, Common.Constants.METADATA_PROVIDERS_CONFIGURATION_FILE))
    End Sub

    Public Shared Function LoadProvider(ProviderInvariantName As String) As IMetaDataProvider
        Dim lFactory As New MetaDataProviderFactory()
        Return lFactory.LoadInstance(ProviderInvariantName)
    End Function
End Class
