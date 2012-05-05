Imports System.ComponentModel

Namespace Entities
    <Serializable()> _
    Public Class DataSource

#Region "Properties"
        Private _Project As Project
        <Browsable(False)> _
        Public ReadOnly Property Project As Project
            Get
                Return _Project
            End Get
        End Property

        Private _DataSourceName As String
        <Category("Metadata"), DisplayName("Datasource name"), Description("The name of the connection string"), [ReadOnly](True)> _
        Public Property DataSourceName() As String
            Get
                Return _DataSourceName
            End Get
            Set(ByVal value As String)
                _DataSourceName = value
            End Set
        End Property

        Private _ProviderName As String
        <Category("Metadata"), DisplayName("Provider name"), Description("The invariant name of the connection provider"), [ReadOnly](True)>
        Public Property ProviderName() As String
            Get
                Return _ProviderName
            End Get
            Set(ByVal value As String)
                _ProviderName = value
            End Set
        End Property

        Private _Tables As List(Of Table)
        <Browsable(False)> _
        Public Property Tables() As List(Of Table)
            Get
                If (_Tables Is Nothing) Then
                    _Tables = New List(Of Table)
                End If
                Return _Tables
            End Get
            Set(ByVal value As List(Of Table))
                _Tables = value
            End Set
        End Property

        Private _Views As List(Of View)
        <Browsable(False)> _
        Public Property Views() As List(Of View)
            Get
                If (_Views Is Nothing) Then
                    _Views = New List(Of View)
                End If
                Return _Views
            End Get
            Set(ByVal value As List(Of View))
                _Views = value
            End Set
        End Property

        Private _StoredProcedures As List(Of StoredProcedure)
        <Browsable(False)> _
        Public Property StoredProcedures() As List(Of StoredProcedure)
            Get
                If (_StoredProcedures Is Nothing) Then
                    _StoredProcedures = New List(Of StoredProcedure)
                End If
                Return _StoredProcedures
            End Get
            Set(ByVal value As List(Of StoredProcedure))
                _StoredProcedures = value
            End Set
        End Property

        Private _GeneratedNamespace As String
        <Category("Code generation"), DisplayName("Generated namespace"), Description("Sets the namespace for the generated entities"), PersistAfterRefreshSchema(True)> _
        Public Property GeneratedNamespace() As String
            Get
                Return _GeneratedNamespace
            End Get
            Set(ByVal value As String)
                _GeneratedNamespace = value
            End Set
        End Property

        Private _UseStoredProceduresForCRUD As Boolean
        <Category("Code generation"), DisplayName("User stored procedures for CRUD"), Description("Determines if CRUD operations should be performed using Stored Procedures"), PersistAfterRefreshSchema(True)> _
        Public Property UseStoredProceduresForCRUD() As Boolean
            Get
                Return _UseStoredProceduresForCRUD
            End Get
            Set(ByVal value As Boolean)
                _UseStoredProceduresForCRUD = value
            End Set
        End Property

#End Region

        Public Sub SetProject(project As Project)
            _Project = project
        End Sub


#Region "FindBy Methods"

        Public Function FindTableByName(ByVal pSchema As String, ByVal pTableName As String) As Entities.Table
            Dim lReturnValue As Entities.Table = Nothing

            Dim lFound As Boolean = False
            For Each lTable As Entities.Table In Me.Tables
                If (pTableName.ToLower() = lTable.Name.ToLower()) Then
                    If (pSchema = String.Empty) Then
                        lFound = True
                    Else
                        If (lTable.Schema.ToLower() = pSchema.ToLower()) Then
                            lFound = True
                        End If
                    End If

                    If (lFound) Then
                        lReturnValue = lTable
                        Exit For
                    End If
                End If
            Next

            Return lReturnValue
        End Function

        Public Function FindTableByName(ByVal pTableName As String)
            Return FindTableByName(String.Empty, pTableName)
        End Function
#End Region

#Region "FindView"
        Public Function FindViewByName(ByVal pSchema As String, ByVal pViewName As String) As Entities.View
            Dim lReturnValue As Entities.View = Nothing

            Dim lFound As Boolean = False
            For Each lView As Entities.View In Me.Views
                If (pViewName.ToLower() = lView.Name.ToLower()) Then
                    If (pSchema = String.Empty) Then
                        lFound = True
                    Else
                        If (lView.Schema.ToLower() = pSchema.ToLower()) Then
                            lFound = True
                        End If
                    End If

                    If (lFound) Then
                        lReturnValue = lView
                        Exit For
                    End If
                End If
            Next

            Return lReturnValue
        End Function

        Public Function FindViewByName(ByVal pViewName As String)
            Return FindViewByName(String.Empty, pViewName)
        End Function
#End Region

#Region "FindStoredProcedure"
        Public Function FindProcedureByName(ByVal pSchema As String, ByVal pSPName As String) As Entities.StoredProcedure
            Dim lReturnValue As Entities.StoredProcedure = Nothing

            Dim lFound As Boolean = False
            For Each lStoredProcedure As Entities.StoredProcedure In Me.StoredProcedures
                If (pSPName.ToLower() = lStoredProcedure.Name.ToLower()) Then
                    If (pSchema = String.Empty) Then
                        lFound = True
                    Else
                        If (lStoredProcedure.Schema.ToLower() = pSchema.ToLower()) Then
                            lFound = True
                        End If
                    End If

                    If (lFound) Then
                        lReturnValue = lStoredProcedure
                        Exit For
                    End If
                End If
            Next

            Return lReturnValue
        End Function

        Public Function FindProcedureByName(ByVal pSPName As String)
            Return FindProcedureByName(String.Empty, pSPName)
        End Function
#End Region

        Public Sub UpdateLanguageMappings()
            Dim lMappings As New LanguageMappingProvider(Me.ProviderName, Me.Project.TargetLanguage)

            For Each lTable As Table In Me.Tables
                For Each lColumn In lTable.Columns
                    Dim lTargetProperty As CLRTargetProperty = lMappings.GetCLRMapping(lColumn)
                    If Not (lTargetProperty Is Nothing) Then
                        lColumn.CLRTargetType = lTargetProperty.TargetType
                        lColumn.IsCLRNullable = lTargetProperty.IsCLRNullable
                    End If
                Next
            Next

            For Each lView As View In Me.Views
                For Each lColumn In lView.Columns
                    Dim lTargetProperty As CLRTargetProperty = lMappings.GetCLRMapping(lColumn)
                    If Not (lTargetProperty Is Nothing) Then
                        lColumn.CLRTargetType = lTargetProperty.TargetType
                        lColumn.IsCLRNullable = lTargetProperty.IsCLRNullable
                    End If
                Next
            Next

            For Each lSP As StoredProcedure In Me.StoredProcedures
                For Each lParamenter In lSP.Parameters
                    Dim lTargetProperty As CLRTargetProperty = lMappings.GetCLRMapping(lParamenter)
                    If Not (lTargetProperty Is Nothing) Then
                        lParamenter.CLRTargetType = lTargetProperty.TargetType
                    End If
                Next
            Next
        End Sub

    End Class
End Namespace

