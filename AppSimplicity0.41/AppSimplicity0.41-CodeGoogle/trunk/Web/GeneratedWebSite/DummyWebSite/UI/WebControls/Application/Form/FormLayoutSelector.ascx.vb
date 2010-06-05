
Partial Class UI_WebControls_Application_Form_FormLayoutSelector
    Inherits UI.CustomWebControl

    Public Event OnLayoutSelection(ByVal pLayout As UI.EditItemWebControl.Layout)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.ddlFormLayout.Items.Add(New ListItem("Lista", "1"))
            Me.ddlFormLayout.Items.Add(New ListItem("Flujo", "2"))
        End If
    End Sub

    Protected Sub ddlFormLayout_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFormLayout.SelectedIndexChanged
        RaiseEvent OnLayoutSelection(Me.ddlFormLayout.SelectedValue)
    End Sub
End Class
