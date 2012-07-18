Imports NUnit.Framework

<TestFixture()> _
Public Class ProviderFactoryTests

    <Test()> _
    Public Sub TestProviderInstance()
        Dim lCS As System.Configuration.ConnectionStringSettings = System.Configuration.ConfigurationManager.ConnectionStrings("SomeERP")
        Assert.IsNotNull(AppSimplicity.SchemaDiscovery.Engine.MetaDataProviderFactory.GetInstance(lCS.ProviderName))
    End Sub
End Class
