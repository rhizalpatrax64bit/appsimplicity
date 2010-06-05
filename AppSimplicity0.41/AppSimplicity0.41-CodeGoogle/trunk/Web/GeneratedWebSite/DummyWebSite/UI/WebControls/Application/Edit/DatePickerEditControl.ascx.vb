
Partial Class UI_WebControls_Application_Edit_DatePickerEditControl
    Inherits UI.EditWebControl

    Public Property Value() As DateTime
        Get
            Return Me.ParseDate()
        End Get
        Set(ByVal value As DateTime)
            SetTextValue(value)
        End Set
    End Property

    Private Function ParseDate() As DateTime
        'TODO: make this work:
    End Function

    Private Sub SetTextValue(ByVal pDate As DateTime)
        'TODO: make this work:
    End Sub

    Protected Sub Page_OnAfterInitialize() Handles Me.OnAfterInitialize
        Me.txtDatePicker.Width = Me.Width - 80
    End Sub

End Class
