Imports Microsoft.VisualBasic

Namespace UI
    Public Class EditItemWebControl
        Inherits UI.CustomWebControl

        Private _FormContainer As System.Web.UI.HtmlControls.HtmlControl

        Public Enum Layout
            List = 1
            Flow = 2
        End Enum

        Public Property WebFormLayout() As Layout
            Get
                If (Me.ViewState("WebFormLayout") Is Nothing) Then
                    Me.ViewState("WebFormLayout") = Layout.List
                End If
                Return Me.ViewState("WebFormLayout")
            End Get
            Set(ByVal value As Layout)
                Me.ViewState("WebFormLayout") = value
            End Set
        End Property

        Public Enum EditModes
            CreateNew
            EditItem
        End Enum

        Public Property EditMode() As EditModes
            Get
                If (Me.ViewState("EditModes") Is Nothing) Then
                    Me.ViewState("EditModes") = EditModes.EditItem
                End If
                Return Me.ViewState("EditModes")
            End Get
            Set(ByVal value As EditModes)
                Me.ViewState("EditModes") = value
            End Set
        End Property

        Public Sub SetLayoutMode(ByVal pLayout As Layout)
            If (Me._FormContainer IsNot Nothing) Then

                Me._FormContainer.Attributes.Clear()
                Select Case pLayout
                    Case Layout.Flow
                        Me._FormContainer.Attributes.Add("class", "form-layout-flow")
                    Case Layout.List
                        Me._FormContainer.Attributes.Add("class", "form-layout-list")
                End Select
            End If
        End Sub

        Private Sub Initialize()
            Me.SetLayoutMode(Me.WebFormLayout)
        End Sub

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            _FormContainer = Me.FindControl("FormLayout")
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not (IsPostBack) Then
                Me.Initialize()
            End If
        End Sub
    End Class
End Namespace

