Imports System.Reflection
Imports System.IO
Imports System.Configuration
Imports SpitCodeEngine
Imports Microsoft.Win32

Module Program
    Public Enum RunningModes
        Install
        Generate
        Design
        Help
    End Enum

    Dim _Project As SpitCodeEngine.MetaDiscovery.Project

    Private Function ShowSchemaDesigner() As Boolean
        Dim lReturnValue As Boolean = False
        Dim lUI As New SchemaDesigner

        Console.WriteLine(" ")
        Console.WriteLine("Now launching SchemaDesigner... ")
        lUI.Initialize(_Project, GetBuildVersion)
        Console.WriteLine(" ")
        Console.WriteLine("SchemaDesigner Initialization successfull, proceeding to request user input...")
        Console.WriteLine(" ")

        If (lUI.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            lReturnValue = True
            Console.WriteLine("Starting code generation...")
        Else
            Console.WriteLine("No code generation this time.")
        End If

        Return lReturnValue
    End Function
   
    Private Function GetApplicationPath() As String
        Dim lResult As String = ""
        lResult = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
        Return System.IO.Path.GetDirectoryName(lResult)
    End Function

    Private Sub DoTheMagic()
        Dim lCodeGenerator As New SpitCodeEngine.CodeGeneration.CodeGenerator(_Project)
        lCodeGenerator.DoTheMagic()
    End Sub

    Private Function GetBuildVersion() As String
        Dim Assm As Assembly = Assembly.GetExecutingAssembly()
        Dim SpitCodeVersion As String = Assm.GetName().Version.ToString()
        Return SpitCodeVersion
    End Function

    Public Sub Generate()
        Console.WriteLine()
        Console.WriteLine()

        _Project = New SpitCodeEngine.MetaDiscovery.Project(GetNetLanguage)

        If _Project.Providers.Count = 0 Then
            Console.WriteLine("No providers found, this will end right now.")
        Else
            DoTheMagic()
        End If
    End Sub

    Public Function GetNetLanguage() As MetaDiscovery.NetLanguageType
        Dim lReturnValue As MetaDiscovery.NetLanguageType = MetaDiscovery.NetLanguageType.VBNET
        Dim lArguments As New Arguments(Environment.CommandLine)

        Select Case (lArguments.Item("language"))
            Case "VB"
                lReturnValue = MetaDiscovery.NetLanguageType.VBNET
            Case "C#"
                lReturnValue = MetaDiscovery.NetLanguageType.CSharp
        End Select

        Return lReturnValue
    End Function

    Public Sub Design()
        Console.WriteLine(" ")
        Console.WriteLine(" ")
        Console.WriteLine("Reading Configuration File...")
        Console.WriteLine(" ")

        _Project = New SpitCodeEngine.MetaDiscovery.Project

        If _Project.Providers.Count = 0 Then
            Console.WriteLine("No providers found, this will end right now.")
        Else
            If (ShowSchemaDesigner()) Then
                DoTheMagic()
            End If
        End If
    End Sub

    Public Function GetRunningMode() As RunningModes
        Dim lRunningMode As RunningModes = RunningModes.Design

        If (Environment.CommandLine.Contains("/?")) Then
            lRunningMode = RunningModes.Help
        Else
            Dim arguments As New Arguments(Environment.CommandLine)

            If Not (arguments.Item("action") Is Nothing) Then
                Select Case (arguments.Item("action").ToLower)
                    Case "install"
                        lRunningMode = RunningModes.Install
                    Case "design"
                        lRunningMode = RunningModes.Design
                    Case "generate"
                        lRunningMode = RunningModes.Generate
                End Select
            End If
        End If

        Return lRunningMode
    End Function

    Public Sub Install()
        Dim lSpitCodeRegistry As RegistryKey = Registry.CurrentUser.CreateSubKey("SpitCode2")
        lSpitCodeRegistry.SetValue("InstallDir", Directory.GetCurrentDirectory)
    End Sub

    Public Sub ShowSplashScreen()
        Dim lSplash As New SplashScreen(SplashScreen.DisplayMode.SplashScreen)

        lSplash.ShowDialog()
    End Sub

    Public Function VerifyInstallation() As Boolean
        Dim lReturnValue As Boolean = True
        Dim lSpitCodeRegistry As RegistryKey = Registry.CurrentUser.CreateSubKey("SpitCode2")

        If (lSpitCodeRegistry.GetValue("InstallDir") Is Nothing) Then
            lReturnValue = False
        End If


        If (lReturnValue = False) Then
            Console.WriteLine("SpitCode is not installed, run program like this:")
            Console.WriteLine()
            Console.WriteLine("SpitCode2.exe /action install")
            Console.WriteLine()
        End If

        Return lReturnValue
    End Function

    Sub Main()
        Console.WriteLine(String.Format("SPITCODE {0}", GetBuildVersion))
        Console.WriteLine("By Javier Pitalua Cobos.")
        Console.WriteLine("Initializing...")
        ShowSplashScreen()
        Console.WriteLine(" ")
        Console.WriteLine(String.Format("Running on: {0}", Directory.GetCurrentDirectory()))
        Select Case (GetRunningMode())
            Case RunningModes.Design
                If (VerifyInstallation()) Then
                    Console.WriteLine()
                    Design()
                    Console.WriteLine()
                End If
            Case RunningModes.Generate
                If (VerifyInstallation()) Then
                    Console.WriteLine()
                    Generate()
                    Console.WriteLine()
                End If
            Case RunningModes.Install
                Install()
                Console.WriteLine()
                Console.WriteLine("SpitCode was successfully installed.")
                Console.WriteLine()
            Case RunningModes.Help
                Console.Clear()
                Console.Write(My.Resources.HelpInfo)
        End Select

        Console.WriteLine(" ")
        Console.WriteLine("Press any key to exit...")
        Console.Read()
    End Sub

End Module
