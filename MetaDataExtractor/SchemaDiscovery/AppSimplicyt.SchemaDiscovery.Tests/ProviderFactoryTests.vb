Imports NUnit.Framework

<TestFixture()> _
Public Class ProviderFactoryTests

    <Test()> _
    Public Sub TestProviderInstance()
        'Dim lCS As System.Configuration.ConnectionStringSettings = System.Configuration.ConfigurationManager.ConnectionStrings("SomeERP")
        'Assert.IsNotNull(AppSimplicity.SchemaDiscovery.Engine.MetaDataProviderFactory.GetInstance(lCS.ProviderName))

        Dim lProject As AppSimplicity.SchemaDiscovery.Entities.Project = AppSimplicity.SchemaDiscovery.Engine.MetaDataExtractor.LoadProjectFromDisk()
        Assert.IsNotNull(lProject)

    End Sub
End Class
