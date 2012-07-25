Imports System.Configuration
Imports System.IO
Imports Microsoft.Win32
Imports AppSimplicity.SchemaDiscovery.ComponentModel

Namespace Entities
    Public Enum TargetLanguages
        CSharp = 0
        VisualBasic = 1
    End Enum

    <Serializable()> _
    Public Class Project

        Private _ProjectName As String
        <Category("Code generation"), DisplayName("Project name"), Description("The name of the CLR target project"), PersistAfterRefreshSchema(True)> _
        Public Property ProjectName() As String
            Get
                If (_ProjectName = String.Empty) Then
                    _ProjectName = "NewProject"
                End If
                Return _ProjectName
            End Get
            Set(ByVal value As String)
                _ProjectName = value
            End Set
        End Property

        Private _DataSources As List(Of DataSource)
        <Browsable(False)> _
        Public Property DataSources() As List(Of DataSource)
            Get
                If (_DataSources Is Nothing) Then
                    _DataSources = New List(Of DataSource)
                End If
                Return _DataSources
            End Get
            Set(ByVal value As List(Of DataSource))
                _DataSources = value
            End Set
        End Property

        Private _TargetLanguage As TargetLanguages = TargetLanguages.VisualBasic
        <Category("Code generation"), DisplayName("Code generation CLR target language"), Description("Sets the CLR language for code generation."), PersistAfterRefreshSchema(True)> _
        Public Property TargetLanguage() As TargetLanguages
            Get
                Return _TargetLanguage
            End Get
            Set(ByVal value As TargetLanguages)
                _TargetLanguage = value
            End Set
        End Property

        Private _AssemblyName As String
        <Category("Code generation"), DisplayName("Assembly name"), Description("The name of the target assembly for code generation"), [ReadOnly](True)> _
        Public Property AssemblyName() As String
            Get
                Return _AssemblyName
            End Get
            Set(ByVal value As String)
                _AssemblyName = value
            End Set
        End Property

        Private _RootNamespace As String
        <Category("Code generation"), DisplayName("Assembly root namespace"), Description("The name of the default namespace in the assembly."), [ReadOnly](True)> _
        Public Property RootNamespace() As String
            Get
                Return _RootNamespace
            End Get
            Set(ByVal value As String)
                _RootNamespace = value
            End Set
        End Property

    End Class
End Namespace
