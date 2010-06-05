
Partial Class UI_WebControls_Application_Edit_NumericEditControl
    Inherits UI.EditWebControl

    Protected Sub Page_OnAfterInitialize() Handles Me.OnAfterInitialize
        Me.txtText.Width = Me.Width - 20
    End Sub

End Class
