
Partial Class UI_WebControls_Custom_Sitios_EditSitio
    Inherits UI.EditItemWebControl


    Protected Sub LayoutSelector_OnLayoutSelection(ByVal pLayout As UI.EditItemWebControl.Layout) Handles LayoutSelector.OnLayoutSelection
        Me.SetLayoutMode(pLayout)
    End Sub

    Protected Sub btnSaveBottom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveBottom.Click

    End Sub

    Protected Sub btnSaveTop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveTop.Click
        Try
            Throw New Exception("algo pasó")
        Catch ex As Exception
            Me.InLineAlert1.DisplayAlert(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            Utilities.Web.AddWaitOverlay(Me.btnSaveTop)
        End If
    End Sub
End Class
