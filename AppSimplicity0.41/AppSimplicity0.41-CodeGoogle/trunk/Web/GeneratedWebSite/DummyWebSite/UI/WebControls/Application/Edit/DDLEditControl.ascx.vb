
Partial Class UI_WebControls_Application_Edit_DDLEditControl
    Inherits UI.EditWebControl

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.ddlSelectedValue.Items.Add("opcion 1")
            Me.ddlSelectedValue.Items.Add("opcion 2")
            Me.ddlSelectedValue.Items.Add("opcion 3")
        End If
    End Sub

    Protected Sub Page_OnAfterInitialize() Handles Me.OnAfterInitialize
        Me.ddlSelectedValue.Width = Me.Width - 20
    End Sub

End Class
