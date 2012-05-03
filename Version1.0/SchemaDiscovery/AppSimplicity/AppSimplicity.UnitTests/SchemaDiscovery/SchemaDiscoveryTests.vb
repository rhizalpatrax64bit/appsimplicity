Imports NUnit.Framework
Imports AppSimplicity.SchemaDiscovery
Imports AppSimplicity.SchemaDiscovery.Entities

<TestFixture(), Category("MetaData extraction")> _
Public Class SchemaDiscoveryTests

    <Test()> _
    Public Sub LoadSchemaProjectTest()
        Dim lProject As Project = SchemaDiscovery.ProjectFactory.LoadProjectFromDisk()
        Assert.AreNotEqual(lProject, Nothing)
    End Sub

    <Test()> _
    Public Sub PersistProjectSettingsTest()
        Dim lPreviousProjectName As String
        Dim lProject As Project = SchemaDiscovery.ProjectFactory.LoadProjectFromDisk()
        lPreviousProjectName = lProject.ProjectName
        lProject.ProjectName = "This has been modified"
        SchemaDiscovery.ProjectFactory.PersistProjectToDisk(lProject)

        Dim lProjectReloaded As Project = SchemaDiscovery.ProjectFactory.LoadProjectFromDisk()
        Assert.AreEqual(lProjectReloaded.ProjectName, "This has been modified")

        lProjectReloaded.ProjectName = lPreviousProjectName
        SchemaDiscovery.ProjectFactory.PersistProjectToDisk(lProjectReloaded)
    End Sub

End Class
