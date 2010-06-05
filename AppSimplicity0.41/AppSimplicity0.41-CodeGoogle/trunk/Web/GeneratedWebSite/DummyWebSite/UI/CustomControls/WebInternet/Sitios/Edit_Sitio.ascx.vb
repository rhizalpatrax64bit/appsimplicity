Imports Entities

Partial Class UI_CustomControls_WebInternet_Sitios_Edit_Sitio
    Inherits UI.EditItemWebControl

    Protected Sub LayoutSelector_OnLayoutSelection(ByVal pLayout As UI.EditItemWebControl.Layout) Handles LayoutSelector.OnLayoutSelection
        Me.SetLayoutMode(pLayout)
    End Sub

    Public Sub Initialize(ByVal pItem As SM_WebFI.Serie)

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
