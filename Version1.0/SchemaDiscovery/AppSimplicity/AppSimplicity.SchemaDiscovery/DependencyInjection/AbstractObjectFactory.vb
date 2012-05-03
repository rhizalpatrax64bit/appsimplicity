Imports System.IO
Imports System.Windows.Forms

Namespace DependencyInjection
    Public Class AbstractObjectFactory(Of T)
        Private _ProviderConfigurationFile As String

        Private _Definitions As List(Of ProviderDefinition)
        Public ReadOnly Property ProviderDefinitions() As List(Of ProviderDefinition)
            Get
                If (_Definitions Is Nothing) Then
                    _Definitions = LoadProviderDefinitions()
                End If
                Return _Definitions
            End Get
        End Property

        Private Function LoadProviderDefinitions() As List(Of ProviderDefinition)
            Dim lReturnValue As New List(Of ProviderDefinition)

            If (System.IO.File.Exists(_ProviderConfigurationFile)) Then
                Dim lDS As New Data.DataSet

                lDS.ReadXml(_ProviderConfigurationFile)

                For Each lDR As DataRow In lDS.Tables(0).Rows
                    Dim lDefinition As New ProviderDefinition
                    lDefinition.Name = lDR.Item("Name")
                    lDefinition.ProviderType = lDR.Item("ProviderType")
                    lReturnValue.Add(lDefinition)
                Next
            End If

            Return lReturnValue
        End Function

        Public Sub New(ByVal pConfigurationFile As String)
            _ProviderConfigurationFile = Path.Combine(Directory.GetCurrentDirectory, pConfigurationFile)

            If Not (System.IO.File.Exists(_ProviderConfigurationFile)) Then
                _ProviderConfigurationFile = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), pConfigurationFile)
                If Not (System.IO.File.Exists(_ProviderConfigurationFile)) Then
                    Throw New Exception(String.Format("Unable to load DI provider [{0}]", GetType(T).ToString()))
                End If
            End If
        End Sub

        Public Function LoadInstance(ByVal pProviderName As String) As T
            Dim lReturnValue As T = Nothing

            For Each lDefinition As ProviderDefinition In Me.ProviderDefinitions
                If (lDefinition.Name.ToLower() = pProviderName.ToLower()) Then
                    lReturnValue = Activator.CreateInstance(Type.GetType(lDefinition.ProviderType))
                    Exit For
                End If
            Next

            If (lReturnValue Is Nothing) Then
                Throw New Exception(String.Format("Unable to load provider [{0}]", pProviderName))
            End If

            Return lReturnValue
        End Function

    End Class
End Namespace

