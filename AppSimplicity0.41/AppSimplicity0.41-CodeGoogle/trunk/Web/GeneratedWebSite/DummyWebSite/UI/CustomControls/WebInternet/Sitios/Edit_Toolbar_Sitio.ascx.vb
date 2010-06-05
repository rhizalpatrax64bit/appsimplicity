
Partial Class UI_CustomControls_WebInternet_Sitios_Edit_Toolbar_Sitio
    Inherits UI.EditItemWebControl

    Public Event OnCancel()
    Public Event OnNew()
    Public Event OnSave()
    Public Event OnSaveNew()
    Public Event OnDelete()

    Public Sub Inititalize(ByVal pMode As UI.EditItemWebControl.EditModes)
        If (pMode = EditModes.CreateNew) Then
            Me.btnDelete.Enabled = False
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Utilities.Web.AddWaitOverlay(Me.btnCancel)
            Utilities.Web.AddWaitOverlay(Me.btnNew)
            Utilities.Web.AddWaitOverlay(Me.btnSave)
            Utilities.Web.AddWaitOverlay(Me.btnSaveNew)
            Utilities.Web.AddWaitOverlay(Me.btnSave)

            Utilities.Web.AddConfirmation(Me.btnDelete, "¿Desea eliminar el registro?", True)
        End If
    End Sub

End Class
