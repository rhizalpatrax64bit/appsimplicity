Imports System.Xml
Imports System.IO

Namespace VisualStudio
    Public Class Project

        Private _RootNamespace As String = "Undefined"
        Public Property RootNamespace() As String
            Get
                Return _RootNamespace
            End Get
            Set(ByVal value As String)
                _RootNamespace = value
            End Set
        End Property

        Private _AssemblyName As String = "Undefined"
        Public Property AssemblyName() As String
            Get
                Return _AssemblyName
            End Get
            Set(ByVal value As String)
                _AssemblyName = value
            End Set
        End Property

        ''' <summary>
        ''' Loads the content of a .csproj file and parses its content.
        ''' </summary>
        ''' <param name="inputProjectFile">The full file path to .csproj or .vbproj</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function LoadProject(inputProjectFile As String) As Project
            Dim lReturnValue As Project = New Project

            If (File.Exists(inputProjectFile)) Then
                Dim lReader As New System.Xml.XmlTextReader(inputProjectFile)

                While (lReader.Read())
                    Select Case lReader.NodeType
                        Case XmlNodeType.Element
                            Select Case lReader.Name
                                Case "RootNamespace"
                                    lReader.Read()
                                    lReturnValue.RootNamespace = lReader.Value
                                Case "AssemblyName"
                                    lReader.Read()
                                    lReturnValue.AssemblyName = lReader.Value
                            End Select
                    End Select
                End While
            End If

            Return lReturnValue
        End Function

        ''' <summary>
        ''' Looks for a .vbproj/.csproj file in the current directory
        ''' </summary>
        ''' <returns>returns the full path to project file.</returns>
        Public Shared Function FindProjectFile() As String
            Dim lReturnValue As String = ""
            Dim lFiles As String() = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.vbproj")

            If (lFiles.Length > 0) Then
                lReturnValue = lFiles(0)
            Else
                lFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.csproj")
                If (lFiles.Length > 0) Then
                    lReturnValue = lFiles(0)
                End If
            End If

            Return lReturnValue
        End Function

        ''' <summary>
        ''' Looks for a .csproj/.vbproj in the local directory
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GetCurrentProject() As Project
            Dim lProject As Project = Nothing
            Dim lFile As String = FindProjectFile()

            If (lFile <> String.Empty) Then
                lProject = LoadProject(lFile)
            End If

            Return lProject
        End Function
    End Class

End Namespace
