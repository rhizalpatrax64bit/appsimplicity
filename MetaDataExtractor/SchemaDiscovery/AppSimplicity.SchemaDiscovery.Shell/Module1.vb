Imports System.Reflection
Imports AppSimplicity.SchemaDiscovery
Imports System.IO

Module Module1

    Private Function GetBuildVersion() As String
        Dim Assm As Assembly = Assembly.GetExecutingAssembly()
        Dim SpitCodeVersion As String = Assm.GetName().Version.ToString()
        Return SpitCodeVersion
    End Function

    Private Sub LaunchUI()
        Dim lProject As Entities.Project = AppSimplicity.SchemaDiscovery.Engine.MetaDataExtractor.LoadProjectFromDisk()

        Dim lUI As New AppSimplicity.SchemaDiscovery.UI.SchemaEditor
        lUI.Initialize(lProject)
        lUI.ShowDialog()

        AppSimplicity.SchemaDiscovery.Engine.MetaDataExtractor.PersistProjectToDisk(lProject)
    End Sub

    Private Sub UpdateSchema()
        Dim lExtractor As New AppSimplicity.SchemaDiscovery.Engine.MetaDataExtractor()

        Dim lProject As Entities.Project = AppSimplicity.SchemaDiscovery.Engine.MetaDataExtractor.LoadProjectFromDisk()

        If (lProject Is Nothing) Then
            lProject = lExtractor.LoadProject()
        Else
            lExtractor.UpdateProject(lProject)
        End If

        If Not (lProject Is Nothing) Then
            AppSimplicity.SchemaDiscovery.Engine.MetaDataExtractor.PersistProjectToDisk(lProject)
        End If
    End Sub

    Sub Main()
        Console.WriteLine(String.Format("SPITCODE {0} - AppSimplicity Schema Designer", GetBuildVersion))
        Console.WriteLine("By Javier Pitalua Cobos.")
        Console.WriteLine("Initializing...")
        Console.WriteLine(" ")
        Console.WriteLine(String.Format("Running on: {0}", Directory.GetCurrentDirectory()))

        Dim lParser As New CommandParser(Environment.CommandLine)

        Select Case lParser.ParseAction
            Case CommandParser.Actions.LaunchUI
                LaunchUI()
            Case CommandParser.Actions.UpdateSchema
                UpdateSchema()
            Case CommandParser.Actions.Undefined
                LaunchUI()
        End Select
    End Sub

End Module
