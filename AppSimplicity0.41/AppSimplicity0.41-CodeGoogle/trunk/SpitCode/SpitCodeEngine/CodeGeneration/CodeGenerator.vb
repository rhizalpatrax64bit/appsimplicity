Imports System.IO
Imports System.Reflection

Namespace CodeGeneration
    Public Class CodeGenerator
        Private _TemplateFiles As List(Of String)

        Private _Project As MetaDiscovery.Project

        Private _Templates As New List(Of SpitCodeEngine.CodeGeneration.CodeTemplate)
        Public ReadOnly Property Templates() As List(Of SpitCodeEngine.CodeGeneration.CodeTemplate)
            Get
                Return _Templates
            End Get
        End Property

        Public Sub DoTheMagic()
            Dim lReturnValue As Boolean = False
            Dim lUI As New TemplateSelector

            Console.WriteLine(" ")
            Console.WriteLine("Requesting user input...")
            lUI.Initialize(Me.Templates)

            If (lUI.ShowDialog = Windows.Forms.DialogResult.OK) Then
                Console.WriteLine("Proceeding to generate code...")
                Me.GenerateCode(lUI.SelectedTemplates)
            Else
                Console.WriteLine("Operation aborted by user.")
            End If
           
        End Sub

        Public Sub New(ByVal pProject As MetaDiscovery.Project)
            _Project = pProject
            Console.WriteLine(" ")
            Dim lAssemblyList As String()
            Console.WriteLine("Reading Templates...")
            lAssemblyList = Directory.GetFiles(pProject.TemplateDirectory, "*.dll")

            Console.WriteLine(String.Format("{0} Asseblies found.", lAssemblyList.Length))
            For Each lDll As String In lAssemblyList
                ReadAssembly(lDll)
            Next
        End Sub

        Private Sub GenerateCode(ByVal pSelectedTemplates As List(Of SpitCodeEngine.CodeGeneration.CodeTemplate))
            Dim lFilesGenerated As Integer = 0

            For Each lTemplate As SpitCodeEngine.CodeGeneration.CodeTemplate In pSelectedTemplates
                lTemplate.SpitCode(_Project)
                lFilesGenerated = lFilesGenerated + lTemplate.FilesGeneratedCount
            Next

            Console.WriteLine(String.Format("{0} Files Generated.", lFilesGenerated))
        End Sub
 
        Public Sub ReadAssembly(ByVal pAssemblyFileName As String)
            Dim assem As [Assembly] = Nothing
            Dim AssemblyFile As String = pAssemblyFileName
            Dim LoadSuccessFull As Boolean = False

            Try
                Console.WriteLine(String.Format("Loading Assembly : {0}", AssemblyFile))
                assem = [Assembly].LoadFile(AssemblyFile)

                LoadSuccessFull = True

            Catch ex As Exception
                Console.WriteLine("Couldn't load assembly, please verify assembly filename.")
                Console.WriteLine(String.Format("ERROR: {0}", ex.Message))
            End Try

            If (LoadSuccessFull) Then
                Try
                    ExtractFromAssembly(assem)
                Catch ex As Exception
                    Console.WriteLine("An error ocurred while generating code.")
                    Console.WriteLine(String.Format("ERROR:{0}", ex.Message))
                End Try
            End If
        End Sub

        Public Sub ExtractFromAssembly(ByVal assem As [Assembly])
            Dim lTypes As Type()
            Dim lFilesGenerated As Integer = 0
            Dim lTemplatesCount As Integer = 0

            lTypes = assem.GetTypes()
            Console.WriteLine("Reading assembly templates...")
            For Each lType As Type In lTypes
                If (lType.BaseType.FullName.Contains("SpitCodeEngine.CodeGeneration.CodeTemplate")) Then
                    lTemplatesCount = lTemplatesCount + 1

                    Console.WriteLine(String.Format("Code template found: [{0}],", lType.FullName))
                    Console.WriteLine(" ")

                    Try
                        Dim obj As Object
                        obj = assem.CreateInstance(lType.FullName)
                        Console.WriteLine(" ")

                        Me.Templates.Add(CType(obj, CodeGeneration.CodeTemplate))
                    Catch ex As Exception
                        Console.WriteLine("  An error ocurred:")
                        Console.WriteLine("  " & ex.Message)
                    End Try
                End If
            Next

            If (lTemplatesCount = 0) Then
                Console.WriteLine(" ")
                Console.WriteLine("No code templates were found.")
                Console.WriteLine(" ")
            Else
                Console.WriteLine(" ")
                Console.WriteLine(String.Format("{0} code templates were found.", lTemplatesCount))
                Console.WriteLine(" ")
            End If
        End Sub

    End Class

End Namespace
