Imports MyMeta
Imports System.Configuration
Imports System.IO
Imports Microsoft.Win32

Namespace MetaDiscovery
    Public Enum NetLanguageType
        VBNET
        CSharp
    End Enum

    Public Class Project
        Private _LanguageType As NetLanguageType = NetLanguageType.VBNET

        Private _WorkingDirectory As String
        <Browsable(False)> _
        Public ReadOnly Property WorkingDirectory() As String
            Get
                Return _WorkingDirectory
            End Get
        End Property

        <Browsable(False)> _
        Public ReadOnly Property TemplateDirectory() As String
            Get
                Return String.Format("{0}\Templates", Me.WorkingDirectory)
            End Get
        End Property

        Public ReadOnly Property Name() As String
            Get
                Return GetProjectName()
            End Get
        End Property
        
        Private _Providers As List(Of Provider)
        <Browsable(False)> _
        Public ReadOnly Property Providers() As List(Of Provider)
            Get
                If _Providers Is Nothing Then
                    _Providers = New List(Of Provider)
                End If
                Return _Providers
            End Get
        End Property

        Private Function GetConfigInDir(ByVal pPath As String) As String
            Dim lResult As String = String.Empty

            If (File.Exists(Path.Combine(pPath, "Web.config"))) Then
                lResult = Path.Combine(pPath, "Web.config")
            End If

            If (File.Exists(Path.Combine(pPath, "App.config"))) Then
                lResult = Path.Combine(pPath, "App.config")
            End If

            Return lResult
        End Function

        Public Sub New(ByVal pWorkingDirectory As String, Optional ByVal pLanguageType As NetLanguageType = NetLanguageType.VBNET)
            If (pWorkingDirectory = String.Empty) Then
                Throw New Exception("The working directory must be specified.")
            End If

            Try
                Console.WriteLine()
                Console.WriteLine("Looking for configuration file...")
                Dim lConfigFile As String = GetConfigInDir(Directory.GetCurrentDirectory)

                If Not (lConfigFile = String.Empty) Then
                    Console.WriteLine(String.Format("Reading Connection Strings from {0}", lConfigFile))
                    Me._LanguageType = pLanguageType

                    'Cargar el archivo de configuracion, leer la seccion de subsonic:
                    Dim lFileMap As System.Configuration.ExeConfigurationFileMap = New System.Configuration.ExeConfigurationFileMap()
                    lFileMap.ExeConfigFilename = lConfigFile
                    Dim lConfigSettings As System.Configuration.Configuration = ConfigurationManager.OpenMappedExeConfiguration(lFileMap, ConfigurationUserLevel.None)

                    Console.WriteLine()
                    For Each lCS As ConnectionStringSettings In lConfigSettings.ConnectionStrings.ConnectionStrings
                        Try
                            Console.WriteLine(String.Format("Attempting to connect using [{0}]", lCS.Name))
                            Dim lProvider As New Provider(lCS, Me, pLanguageType)
                            Me.Providers.Add(lProvider)
                            Console.WriteLine(String.Format("Metadata extraction from [{0}] was successfull.", lProvider.DatabaseName))
                            Console.WriteLine()
                        Catch ex As Exception
                            Console.WriteLine(String.Format("An error ocurred while retrieving MetaData from connection string: [{0}]", lCS.Name))
                            Console.WriteLine("Details:")
                            Console.WriteLine(String.Format("    {0}", ex.Message))
                            Console.WriteLine()
                        End Try
                    Next
                Else
                    Console.WriteLine()
                    Console.WriteLine("Configuration file not found. Nothing to do this time.")
                End If
            Catch ex As Exception
                Console.WriteLine("An error ocurred:")
                Console.WriteLine("Details:")
                Console.WriteLine(String.Format("      {0}", ex.Message))
                Console.WriteLine()
            End Try
        End Sub

        Private Function GetProjectName()
            Dim lProjectName As String = "NetProjectNotFound"

            Dim lFiles As String() = Directory.GetFiles(System.IO.Directory.GetCurrentDirectory(), "*.vbproj")

            If (lFiles.Length > 0) Then
                lProjectName = Path.GetFileName(lFiles(0))
            End If

            Return lProjectName
        End Function

        Public Sub SaveChanges()
            For Each lProvider As MetaDiscovery.Provider In Me.Providers
                lProvider.SaveChanges()
            Next
        End Sub
    End Class

End Namespace


