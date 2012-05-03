Imports System.IO
Imports System.Configuration

Namespace Configuration
    ''' <summary>
    ''' This class holds some static helper methods to work with .net configuration files
    ''' </summary>
    Public Class ConnectionSettings

        Private _ConnectionSection As ConnectionStringsSection

        Public Function GetConnectionSettings(pConnectionStringName As String) As ConnectionStringSettings
            If (_ConnectionSection Is Nothing) Then
                Return ConfigurationManager.ConnectionStrings(pConnectionStringName)
            Else
                Return _ConnectionSection.ConnectionStrings(pConnectionStringName)
            End If
        End Function

        Public Function GetAllConnectionSettings() As List(Of ConnectionStringSettings)
            Dim lReturnValue As New List(Of ConnectionStringSettings)

            If (_ConnectionSection Is Nothing) Then
                For Each lCS As ConnectionStringSettings In ConfigurationManager.ConnectionStrings
                    lReturnValue.Add(lCS)
                Next
            Else
                For Each lCS As ConnectionStringSettings In _ConnectionSection.ConnectionStrings
                    lReturnValue.Add(lCS)
                Next
            End If

            Return lReturnValue
        End Function

        Public Sub New()
            If (System.Web.HttpContext.Current Is Nothing) Then
                'If we are not in a web context, then get settings from local configuration file:
                Dim lConfigFile As String = Me.GetLocalConfigurationFile()
                _ConnectionSection = Me.GetConnectionStringsSection(lConfigFile)
            End If
        End Sub

        ''' <summary>
        ''' Looks in the current directory and returns the full path of the configuration file if exists.
        ''' </summary>
        Public Function GetLocalConfigurationFile() As String
            Dim lReturnValue As String = String.Empty

            Dim lExeFile As String = Path.Combine(Directory.GetCurrentDirectory(), "app.config")
            Dim lConfigFileExists As Boolean = False

            If (File.Exists(lExeFile)) Then
                lConfigFileExists = True
            Else
                lExeFile = Path.Combine(Directory.GetCurrentDirectory(), "web.config")
                If (File.Exists(lExeFile)) Then
                    lConfigFileExists = True
                Else
                    Dim lFiles As String() = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.config")
                    If (lFiles.Length > 0) Then
                        lExeFile = lFiles(0)
                        If (File.Exists(lExeFile)) Then
                            lConfigFileExists = True
                        End If
                    End If
                End If
            End If

            If (lConfigFileExists) Then
                lReturnValue = lExeFile
            End If

            Return lReturnValue
        End Function

        ''' <summary>
        ''' Loads the connection string section from a given .config file.
        ''' </summary>
        ''' <param name="pExeFile">The full path to the .config file</param>
        ''' <returns>Returns the connection string section object</returns>
        Public Function GetConnectionStringsSection(ByVal pExeFile As String) As ConnectionStringsSection
            Dim lFileMap As System.Configuration.ExeConfigurationFileMap = New System.Configuration.ExeConfigurationFileMap()
            lFileMap.ExeConfigFilename = pExeFile
            Dim lConfigSettings As System.Configuration.Configuration = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(lFileMap, ConfigurationUserLevel.None)
            Return lConfigSettings.ConnectionStrings
        End Function

#Region "Shared methods"
        Public Shared Function GetConnection(pConnectionName As String) As ConnectionStringSettings
            Dim lCS As New ConnectionSettings
            Return lCS.GetConnectionSettings(pConnectionName)
        End Function

        Public Shared Function GetAllConnections() As List(Of ConnectionStringSettings)
            Dim lCS As New ConnectionSettings
            Return lCS.GetAllConnectionSettings()
        End Function

#End Region



    End Class

End Namespace
