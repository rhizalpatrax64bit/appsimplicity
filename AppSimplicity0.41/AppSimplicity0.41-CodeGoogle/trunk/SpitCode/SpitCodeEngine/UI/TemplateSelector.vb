Public Class TemplateSelector

    Private _SelectedTemplates
    Public ReadOnly Property SelectedTemplates() As List(Of CodeGeneration.CodeTemplate)
        Get
            Return GetSelectedTemplates()
        End Get
    End Property

    Private Function GetSelectedTemplates() As List(Of CodeGeneration.CodeTemplate)
        Dim lList As New List(Of CodeGeneration.CodeTemplate)

        For Each lItem As ComponentFactory.Krypton.Toolkit.KryptonListItem In Me.TemplateList.CheckedItems
            lList.Add(lItem.Tag)
        Next

        Return lList
    End Function

    Public Sub Initialize(ByVal pTemplateList As List(Of CodeGeneration.CodeTemplate))
        For Each lTemplate As CodeGeneration.CodeTemplate In pTemplateList
            Dim lItem As New ComponentFactory.Krypton.Toolkit.KryptonListItem(lTemplate.Settings.Description)
            lItem.Tag = lTemplate

            Select Case lTemplate.Settings.TemplateType
                Case CodeGeneration.CodeTemplateType.ProjectTemplate
                    lItem.Image = Me.ImageList1.Images(0)
                Case CodeGeneration.CodeTemplateType.ProviderTemplate
                    lItem.Image = Me.ImageList1.Images(1)
                Case CodeGeneration.CodeTemplateType.DbEntityTemplate
                    lItem.Image = Me.ImageList1.Images(2)
                Case CodeGeneration.CodeTemplateType.TableTemplate
                    lItem.Image = Me.ImageList1.Images(2)
                Case CodeGeneration.CodeTemplateType.ViewTemplate
                    lItem.Image = Me.ImageList1.Images(2)
            End Select

            Me.TemplateList.SetItemChecked(Me.TemplateList.Items.Add(lItem), True)
        Next
    End Sub

    Private Sub KryptonButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton1.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub KryptonButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KryptonButton2.Click
        Me.Close()
    End Sub
End Class