Imports System.Text
Imports System.IO

Namespace CodeGeneration

    ''' <summary>
    ''' Determina los tipos de plantillas que existen
    ''' </summary>
    Public Enum CodeTemplateType
        ''' <summary>
        ''' Establece que la plantilla generará archivos por cada tabla o vista del proveedor de datos
        ''' </summary>
        DbEntityTemplate
        ''' <summary>
        ''' Establece que la plantilla generará archivos por cada tabla del proveedor de datos
        ''' </summary>
        TableTemplate
        ''' <summary>
        ''' Establece que la plantilla generará archivos por cada vista del proveedor de datos
        ''' </summary>
        ViewTemplate
        ''' <summary>
        ''' Establece que la plantilla generará archivos por cada proveedor de datos existente en el proyecto
        ''' </summary>
        ProviderTemplate
        ''' <summary>
        ''' Establece que la plantilla generará un archivo por todo el proyecto
        ''' </summary>
        ''' <remarks></remarks>
        ProjectTemplate
    End Enum

    ''' <summary>
    ''' Determina el tipo de entidades posibles
    ''' </summary>
    Public Enum EntityTypes
        ''' <summary>
        ''' Establece que la entidad es de tipo Tabla
        ''' </summary>
        Table
        ''' <summary>
        ''' Establece que la entidad es de tipo Vista
        ''' </summary>
        View
    End Enum

#Region "Template Settings"
    Public Class TemplateSettings

        Private _Description As String = "Template Description Not Set"
        ''' <summary>
        ''' Establece una descripción del propósito de la plantilla
        ''' </summary>            
        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property

        Private _OverWriteFiles As Boolean = True
        ''' <summary>
        ''' Determina si se van a sobrescribir los archivos existente
        ''' con archivos nuevos generados.
        ''' </summary>            
        Public Property OverWriteFiles() As Boolean
            Get
                Return _OverWriteFiles
            End Get
            Set(ByVal value As Boolean)
                _OverWriteFiles = value
            End Set
        End Property

        Private _TemplateType As CodeTemplateType = CodeTemplateType.DbEntityTemplate
        ''' <summary>
        ''' Determina de qué tipo de plantilla se trata
        ''' </summary>            
        Public Property TemplateType() As CodeTemplateType
            Get
                Return _TemplateType
            End Get
            Set(ByVal value As CodeTemplateType)
                _TemplateType = value
            End Set
        End Property
    End Class
#End Region

    ''' <summary>
    ''' Encapsula el comportamiento de una plantilla de generación de código.
    ''' </summary>
    Public MustInherit Class CodeTemplate

#Region "Properties"
        Private _GenerateCodeFile As Boolean = True
        Public Property GenerateCodeFile() As Boolean
            Get
                Return _GenerateCodeFile
            End Get
            Set(ByVal value As Boolean)
                _GenerateCodeFile = value
            End Set
        End Property

        Private _EntityType As EntityTypes = EntityTypes.Table
        ''' <summary>
        ''' Determina el tipo de entidad que se utilizará para generar el código
        ''' </summary>        
        Public Property EntityType() As EntityTypes
            Get
                Return Me._EntityType
            End Get
            Set(ByVal value As EntityTypes)
                Me._EntityType = value
            End Set
        End Property

        Private _Settings As TemplateSettings
        Public ReadOnly Property Settings() As TemplateSettings
            Get
                If (_Settings Is Nothing) Then
                    _Settings = New TemplateSettings
                End If
                Return _Settings
            End Get
        End Property

        Private _CurrentProject As MetaDiscovery.Project
        ''' <summary>
        ''' Refiere al proyecto actual
        ''' </summary>        
        Protected ReadOnly Property CurrentProject() As MetaDiscovery.Project
            Get
                Return _CurrentProject
            End Get
        End Property

        Private _CurrentProvider As MetaDiscovery.Provider
        ''' <summary>
        ''' Refiere al proveedor actual
        ''' </summary>        
        Protected ReadOnly Property CurrentProvider() As MetaDiscovery.Provider
            Get
                Return _CurrentProvider
            End Get
        End Property

        Private _CurrentTable As MetaDiscovery.Table
        Public ReadOnly Property CurrentTable() As MetaDiscovery.Table
            Get
                Return _CurrentTable
            End Get
        End Property

        Private _CurrentView As MetaDiscovery.View
        Public ReadOnly Property CurrentView() As MetaDiscovery.View
            Get
                Return _CurrentView
            End Get
        End Property

        Private _FilesGeneratedCount As Integer = 0
        ''' <summary>
        ''' Obtiene el número de archivos que se han generado en la plantilla
        ''' </summary>        
        Public ReadOnly Property FilesGeneratedCount() As Integer
            Get
                Return _FilesGeneratedCount
            End Get
        End Property

        ''' <summary>
        ''' Determina el directorio actual donde se está ejecutando el generador de código
        ''' </summary>        
        Private ReadOnly Property RootDirectory() As String
            Get
                Return Directory.GetCurrentDirectory()
            End Get
        End Property

        Private ReadOnly Property OutputDirectory() As String
            Get
                Dim lDirectory As String = Me.OutputFileDirectory

                If (lDirectory.StartsWith("\")) Then
                    lDirectory = Right(lDirectory, lDirectory.Length - 1)
                End If

                If (lDirectory.EndsWith("\")) Then
                    lDirectory = Left(lDirectory, lDirectory.Length - 1)
                End If

                Return Path.Combine(Me.RootDirectory, lDirectory)
            End Get
        End Property
#End Region

#Region "Overridable interfaces"
        Public MustOverride Sub ProduceCode(ByRef Output As StreamWriter)
        Public MustOverride Sub Initialize(ByVal pSettings As TemplateSettings)
        Public MustOverride Function OutputFileName() As String
        Public MustOverride Function OutputFileDirectory() As String
#End Region

        ''' <summary>
        ''' Método que realiza la generación del código
        ''' </summary>
        ''' <param name="Project">El proyecto consiste en una colección de Proveedores</param>
        Public Sub SpitCode(ByVal Project As MetaDiscovery.Project)
            Me._CurrentProject = Project

            Console.WriteLine(" ")
            Console.WriteLine(Me.Settings.Description)
            Console.WriteLine("______________________________________________________________")
            Console.WriteLine("Generating code:")

            Select Case (Me.Settings.TemplateType)
                Case CodeTemplateType.ProjectTemplate
                    Me._CurrentProvider = Nothing
                    Me._CurrentTable = Nothing
                    WriteToFile()

                Case CodeTemplateType.ProviderTemplate
                    For Each Provider As MetaDiscovery.Provider In Me.CurrentProject.Providers
                        Me._CurrentProvider = Provider
                        Me._CurrentTable = Nothing
                        Me.WriteToFile()
                    Next

                Case CodeTemplateType.DbEntityTemplate, CodeTemplateType.TableTemplate, CodeTemplateType.ViewTemplate
                    For Each Provider As MetaDiscovery.Provider In Me.CurrentProject.Providers
                        Me._CurrentProvider = Provider

                        If (Me.Settings.TemplateType = CodeTemplateType.DbEntityTemplate) Or (Me.Settings.TemplateType = CodeTemplateType.TableTemplate) Then
                            For Each Table As MetaDiscovery.Table In Provider.Tables
                                Console.WriteLine(" ")
                                Console.WriteLine(String.Format("Reading schema from table [{0}]", Table.Name))
                                _CurrentTable = Table
                                _EntityType = EntityTypes.Table

                                If (Table.IncludeInGeneration) Then
                                    Dim lGenerate As Boolean = True
                                    If (Table.HasManyPrimaryKeys) Then
                                        lGenerate = False

                                        Console.WriteLine(String.Format("ERROR: Table [{0}] has too many primary keys.", Table.Name))
                                    End If

                                    If Not (Table.HasPrimaryKey) Then
                                        lGenerate = False

                                        Console.WriteLine(String.Format("ERROR: Table [{0}] has no primary key.", Table.Name))
                                    End If

                                    If (lGenerate) Then
                                        Me.WriteToFile()
                                    Else
                                        Console.WriteLine(String.Format("Table [{0}] was excluded from code generation.", Table.Name))
                                    End If
                                Else
                                    Console.WriteLine(String.Format("Table [{0}] was not included in generation.", Table.Name))
                                End If

                                _CurrentTable = Nothing
                            Next
                        End If

                        If (Me.Settings.TemplateType = CodeTemplateType.DbEntityTemplate) Or (Me.Settings.TemplateType = CodeTemplateType.ViewTemplate) Then
                            For Each View As MetaDiscovery.View In Provider.Views
                                Console.WriteLine(" ")
                                Console.WriteLine(String.Format("Reading schema from view [{0}]", View.Name))
                                _CurrentView = View
                                _EntityType = EntityTypes.View

                                If (View.IncludeInGeneration) Then
                                    Me.WriteToFile()
                                Else
                                    Console.WriteLine(String.Format("View [{0}] was not included in generation.", View.Name))
                                End If

                                _CurrentView = Nothing
                            Next
                        End If
                    Next
            End Select
        End Sub

        Public Overridable Function ValidateCodeFile() As Boolean
            Return _GenerateCodeFile
        End Function

        Private Sub ValidateFileDir()
            If Not (Directory.Exists(Me.OutputDirectory)) Then
                Directory.CreateDirectory(Me.OutputDirectory)
            End If
        End Sub

        Private Sub WriteToFile()
            Dim SW As StreamWriter = Nothing
            Try
                Dim lWriteFile As Boolean = True
                'Obtener el nombre de archivo:
                ValidateFileDir()

                Dim FullFileName As String = String.Format("{0}\{1}", Me.OutputDirectory, OutputFileName)

                If (Me.Settings.OverWriteFiles = False) Then
                    If (File.Exists(FullFileName)) Then
                        lWriteFile = False
                    End If
                End If

                If Not (ValidateCodeFile()) Then
                    lWriteFile = False
                End If

                If (lWriteFile) Then
                    Console.WriteLine("  Writing file: " & FullFileName)

                    'Crear el archivo:
                    SW = New StreamWriter(FullFileName, False, System.Text.Encoding.UTF8)

                    'Escribir el código generado
                    ProduceCode(SW)
                    Console.WriteLine("  File generated successfully.")
                    Console.WriteLine()
                    Me._FilesGeneratedCount = Me._FilesGeneratedCount + 1
                    SW.Close()
                Else
                    Console.WriteLine("  File skipped.")
                End If
            Catch ex As Exception
                Console.WriteLine("ERROR: " & ex.Message)
            End Try
        End Sub

        Public Sub New()
            Me.Initialize(Me.Settings)
        End Sub
    End Class
End Namespace
