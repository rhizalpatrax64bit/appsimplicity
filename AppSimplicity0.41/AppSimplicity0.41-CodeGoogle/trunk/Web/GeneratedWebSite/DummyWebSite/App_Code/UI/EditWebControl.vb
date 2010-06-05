Imports Microsoft.VisualBasic

Namespace UI
    Public Class EditWebControl
        Inherits CustomWebControl

        Private _Container As System.Web.UI.HtmlControls.HtmlGenericControl
        Private _LabelControl As System.Web.UI.WebControls.Label
        Private _HintControl As System.Web.UI.HtmlControls.HtmlTableRow
        Private _HintText As System.Web.UI.WebControls.Label

        Public Event OnAfterInitialize()

        Public Property Width() As Integer
            Get
                If (Me.ViewState("Width") Is Nothing) Then
                    Me.ViewState("Width") = 200
                End If
                Return Me.ViewState("Width")
            End Get
            Set(ByVal value As Integer)
                Me.ViewState("Width") = value
            End Set
        End Property

        Public Property Label() As String
            Get
                If (Me.ViewState("ControlLabel") Is Nothing) Then
                    Me.ViewState("ControlLabel") = String.Format("{0}", Me.ClientID)
                End If
                Return Me.ViewState("ControlLabel")
            End Get
            Set(ByVal value As String)
                Me.ViewState("ControlLabel") = value
            End Set
        End Property

        Public Property Hint() As String
            Get
                If (Me.ViewState("Hint") Is Nothing) Then
                    Me.ViewState("Hint") = Me.Label
                End If
                Return Me.ViewState("Hint")
            End Get
            Set(ByVal value As String)
                Me.ViewState("Hint") = value
            End Set
        End Property

        Public Property DisplayHint() As Boolean
            Get
                If (Me.ViewState("DisplayHint") Is Nothing) Then
                    Me.ViewState("DisplayHint") = True
                End If
                Return Me.ViewState("DisplayHint")
            End Get
            Set(ByVal value As Boolean)
                Me.ViewState("DisplayHint") = value
            End Set
        End Property

        Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
            _Container = Me.FindControl("Container")
            _LabelControl = Me.FindControl("lblControlLabel")
            _HintControl = Me.FindControl("ControlHint")
            _HintText = Me.FindControl("lblHint")
        End Sub

        Public Sub Initialize()
            Me._Container.Attributes.Add("style", String.Format("width:{0}px;", Me.Width))

            Me._LabelControl.Text = String.Format("{0}:", Me.Label)

            If (Me.DisplayHint) Then
                Me._HintControl.Visible = True
                Me._HintText.Text = Me.Hint
            Else
                Me._HintControl.Visible = False
            End If
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not (IsPostBack) Then
                Me.Initialize()

                RaiseEvent OnAfterInitialize()
            End If
        End Sub
    End Class
End Namespace

