Imports Microsoft.Win32
Imports System.IO
Imports System.Reflection
Imports AppSimplicity.SchemaDiscovery

Module Module1

    Private Function GetBuildVersion() As String
        Dim Assm As Assembly = Assembly.GetExecutingAssembly()
        Dim SpitCodeVersion As String = Assm.GetName().Version.ToString()
        Return SpitCodeVersion
    End Function

    Private Function CreateCodeGenerator() As AppSimplicity.CodeGeneration.Engine.CodeGenerator
        Dim lCodeGenerationConfigFile As String = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "AppSimplicity\AppSimplicity.CodeGeneration.xml")
        Dim lGenerator As New AppSimplicity.CodeGeneration.Engine.CodeGenerator(lCodeGenerationConfigFile)
        Return lGenerator
    End Function

    Private Sub Generate(templateSet As String)
        Dim lProject As Entities.Project = ProjectFactory.LoadProjectFromDisk()
        Dim lGenerator As AppSimplicity.CodeGeneration.Engine.CodeGenerator = CreateCodeGenerator()
        lGenerator.SpitCode(lProject, templateSet)
    End Sub

    Private Sub LaunchUI()
        Dim lProject As Entities.Project = ProjectFactory.LoadProjectFromDisk()

        Dim lUI As New AppSimplicity.SchemaDiscovery.UI.SchemaEditor
        lUI.Initialize(lProject, CreateCodeGenerator())
        lUI.ShowDialog()

        ProjectFactory.PersistProjectToDisk(lProject)
    End Sub

    Sub Main()
        Console.WriteLine(String.Format("SPITCODE {0} - AppSimplicity Schema Designer", GetBuildVersion))
        Console.WriteLine("By Javier Pitalua Cobos.")
        Console.WriteLine("Initializing...")
        Console.WriteLine(" ")
        Console.WriteLine(String.Format("Running on: {0}", Directory.GetCurrentDirectory()))

        Dim lParser As New CommandParser(Environment.CommandLine)

        Select Case lParser.ParseAction
            Case CommandParser.Actions.Generate
                Generate(lParser.GetCommandParameter("TemplateSet"))
            Case CommandParser.Actions.LaunchUI
                LaunchUI()
            Case CommandParser.Actions.UpdateSchema

            Case CommandParser.Actions.Undefined

        End Select
    End Sub

End Module
