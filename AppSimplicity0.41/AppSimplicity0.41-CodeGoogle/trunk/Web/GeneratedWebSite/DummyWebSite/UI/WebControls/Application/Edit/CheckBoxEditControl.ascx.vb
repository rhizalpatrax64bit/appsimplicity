
Partial Class UI_WebControls_Application_Edit_CheckBoxEditControl
    Inherits UI.EditWebControl

    Public Property Value() As Boolean
        Get
            Return Me.chkInput.Checked
        End Get
        Set(ByVal value As Boolean)
            Me.chkInput.Checked = value
        End Set
    End Property

End Class
