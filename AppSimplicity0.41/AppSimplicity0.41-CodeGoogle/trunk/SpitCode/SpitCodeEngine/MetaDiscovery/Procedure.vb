Namespace MetaDiscovery
    Public Class Procedure
        Private _Provider As MetaDiscovery.Provider

        Private _MetaProcedure As MyMeta.Procedure

        <Browsable(False)> _
        Public ReadOnly Property Provider() As MetaDiscovery.Provider
            Get
                Return _Provider
            End Get
        End Property

        <System.ComponentModel.DisplayName("Display Name"), Category("Metadata"), Description("The formatted display name")> _
        Public ReadOnly Property DisplayName() As String
            Get
                Return GetFunctionName()
            End Get
        End Property

        <System.ComponentModel.DisplayName("Schema Name"), Category("Metadata"), Description("The name of the schema this stored procedure belongs to")> _
        Public ReadOnly Property SchemaName() As String
            Get
                Return _MetaProcedure.Name
            End Get
        End Property

        <System.ComponentModel.DisplayName("Code Documentation"), Category("Code Documentation"), Description("A brief description of what the procedure does")> _
        Public Property Summary() As String
            Get
                Dim lKey As String = "Summary"

                Me.ValidatePropertyInstance(lKey, Me._MetaProcedure.Name.ToUpper)

                Return _MetaProcedure.Properties(lKey).Value
            End Get
            Set(ByVal value As String)
                Dim lKey As String = "Summary"
                Me.ValidatePropertyInstance(lKey, Me._MetaProcedure.Name.ToUpper)

                _MetaProcedure.Properties(lKey).Value = value
                Me.SaveData()
            End Set
        End Property

        <System.ComponentModel.DisplayName("Stored Procedure Code"), Category("Code Documentation"), Description("The body of the stored procedure")> _
        Public ReadOnly Property Code() As String
            Get
                Return Me._MetaProcedure.ProcedureText
            End Get
        End Property

        Protected Sub ValidatePropertyInstance(ByVal pKey As String, ByVal pDefaultValue As String)
            If _MetaProcedure.Properties(pKey) Is Nothing Then
                _MetaProcedure.Properties.AddKeyValue(pKey, pDefaultValue)
                Me.SaveData()
            End If
        End Sub

        Friend Sub SaveData()
            _MetaProcedure.Database.Root.SaveUserMetaData()
        End Sub

        Private _Parameters As New List(Of MetaDiscovery.Parameter)
        <Browsable(False)> _
        Public ReadOnly Property Parameters() As List(Of MetaDiscovery.Parameter)
            Get
                Return _Parameters
            End Get
        End Property

        Private Function GetFunctionName() As String
            Dim lReturnValue As String = Me.SchemaName.ToLower

            lReturnValue = lReturnValue.Replace(" ", "_")

            Return lReturnValue
        End Function

        Private Sub FillParameters()
            For Each lParameter As MyMeta.Parameter In _MetaProcedure.Parameters
                If Not (lParameter.ParameterType = 4) Then
                    Dim lParameterItem As New MetaDiscovery.Parameter(lParameter, Me)
                    Me.Parameters.Add(lParameterItem)
                End If
            Next
        End Sub

        Public Sub New(ByVal pProcedure As MyMeta.IProcedure, ByVal pProvider As MetaDiscovery.Provider)
            _Provider = pProvider
            _MetaProcedure = pProcedure

            Me.FillParameters()
        End Sub
    End Class
End Namespace

