
Partial Class UI_WebControls_Application_Common_InLineAlert
    Inherits System.Web.UI.UserControl

    Public Enum Type
        Information
        Warning
        Critical
    End Enum

    Public Sub DisplayAlert(ByVal pTitle As String, ByVal pType As Type, ByVal pMessage As String)
        Me.Visible = True
    End Sub

    Public Sub DisplayAlert(ByVal pMessage As String)
        Me.DisplayAlert("Information", Type.Information, pMessage)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Visible = False
    End Sub
End Class
