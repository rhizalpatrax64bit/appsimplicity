Imports SpitCodeEngine
Imports System.Windows.Forms

Public Class SchemaDesigner
    Private _Project As MetaDiscovery.Project

    Private Sub FillUI()
        Dim lProjectFolderNode As New TreeNode("Project")
        lProjectFolderNode.ImageIndex = 0
        lProjectFolderNode.SelectedImageIndex = 0
        lProjectFolderNode.Expand()
        Me.TreeView1.Nodes.Add(lProjectFolderNode)

        For Each lProvider As MetaDiscovery.Provider In _Project.Providers
            Dim lProviderNode As New System.Windows.Forms.TreeNode(lProvider.Name)
            lProviderNode.Tag = lProvider
            lProviderNode.ImageIndex = 1
            lProviderNode.SelectedImageIndex = 1
            lProjectFolderNode.Nodes.Add(lProviderNode)

            Dim lTablesFolderNode As New System.Windows.Forms.TreeNode("Tables")
            lTablesFolderNode.ImageIndex = 2
            lTablesFolderNode.SelectedImageIndex = 2
            lProviderNode.Nodes.Add(lTablesFolderNode)

            Dim lViewsFolderNode As New System.Windows.Forms.TreeNode("Views")
            lViewsFolderNode.ImageIndex = 2
            lViewsFolderNode.SelectedImageIndex = 2
            lProviderNode.Nodes.Add(lViewsFolderNode)

            Dim lProceduresFolderNode As New System.Windows.Forms.TreeNode("Stored Procedures")
            lProceduresFolderNode.ImageIndex = 2
            lProceduresFolderNode.SelectedImageIndex = 2
            lProviderNode.Nodes.Add(lProceduresFolderNode)

            'Tables ------------------------------------------------------------------------------------------
            For Each lTable As MetaDiscovery.Table In lProvider.Tables
                Dim lTableNode As New System.Windows.Forms.TreeNode(lTable.Name)
                lTableNode.Tag = lTable

                If (lTable.HasPrimaryKey = False) Or (lTable.HasManyPrimaryKeys) Then
                    lTableNode.ImageIndex = 10
                    lTableNode.SelectedImageIndex = 10

                    If (lTable.HasPrimaryKey = False) Then
                        lTableNode.ToolTipText = "This table has no primary key"
                    End If

                    If (lTable.HasManyPrimaryKeys = False) Then
                        lTableNode.ToolTipText = "This table has too many primary keys"
                    End If
                Else
                    lTableNode.ImageIndex = 4
                    lTableNode.SelectedImageIndex = 4
                End If

                lTablesFolderNode.Nodes.Add(lTableNode)

                Dim lColumnsNode As New System.Windows.Forms.TreeNode("Columns")
                lColumnsNode.ImageIndex = 2
                lColumnsNode.SelectedImageIndex = 2
                lTableNode.Nodes.Add(lColumnsNode)

                For Each lColumn As MetaDiscovery.Column In lTable.Columns
                    Dim lColumnNode As New System.Windows.Forms.TreeNode(lColumn.Name)

                    If (lColumn.IsPrimaryKey) Then
                        lColumnNode.ImageIndex = 7
                        lColumnNode.SelectedImageIndex = 7
                    Else
                        lColumnNode.ImageIndex = 5
                        lColumnNode.SelectedImageIndex = 5
                    End If

                    lColumnNode.Tag = lColumn

                    lColumnsNode.Nodes.Add(lColumnNode)
                Next

                If (lTable.BelongsToRelations.Count > 0) Then
                    Dim lForeignDependenciesFolder As New System.Windows.Forms.TreeNode("BelongsTo Dependencies")
                    lForeignDependenciesFolder.ImageIndex = 2
                    lForeignDependenciesFolder.SelectedImageIndex = 2
                    lTableNode.Nodes.Add(lForeignDependenciesFolder)

                    For Each lDependency As MetaDiscovery.MetaRelation In lTable.BelongsToRelations
                        Dim lDependencyNode As New System.Windows.Forms.TreeNode(lDependency.ForeignEntity.Name)
                        lDependencyNode.ImageIndex = 8
                        lDependencyNode.SelectedImageIndex = 8
                        lDependencyNode.Tag = lDependency

                        lForeignDependenciesFolder.Nodes.Add(lDependencyNode)
                    Next
                End If

                If (lTable.HasManyRelations.Count > 0) Then
                    Dim lHasManyDependencies As New System.Windows.Forms.TreeNode("HasMany Dependencies")
                    lHasManyDependencies.ImageIndex = 2
                    lHasManyDependencies.SelectedImageIndex = 2
                    lTableNode.Nodes.Add(lHasManyDependencies)

                    For Each lDependency As MetaDiscovery.MetaRelation In lTable.HasManyRelations
                        Dim lDependencyNode As New System.Windows.Forms.TreeNode(lDependency.ForeignEntity.Name)
                        lDependencyNode.ImageIndex = 8
                        lDependencyNode.SelectedImageIndex = 8
                        lDependencyNode.Tag = lDependency

                        lHasManyDependencies.Nodes.Add(lDependencyNode)
                    Next
                End If
            Next

            'Views ------------------------------------------------------------------------------------------
            For Each lView As MetaDiscovery.View In lProvider.Views
                Dim lViewNode As New System.Windows.Forms.TreeNode(lView.Name)
                lViewNode.Tag = lView
                lViewNode.ImageIndex = 4
                lViewNode.SelectedImageIndex = 4
                lViewsFolderNode.Nodes.Add(lViewNode)

                Dim lColumnsNode As New System.Windows.Forms.TreeNode("Columns")
                lColumnsNode.ImageIndex = 2
                lColumnsNode.SelectedImageIndex = 2
                lViewNode.Nodes.Add(lColumnsNode)

                For Each lColumn As MetaDiscovery.Column In lView.Columns
                    Dim lColumnNode As New System.Windows.Forms.TreeNode(lColumn.Name)

                    If (lColumn.IsPrimaryKey) Then
                        lColumnNode.ImageIndex = 7
                        lColumnNode.SelectedImageIndex = 7
                    Else
                        lColumnNode.ImageIndex = 5
                        lColumnNode.SelectedImageIndex = 5
                    End If

                    lColumnNode.Tag = lColumn

                    lColumnsNode.Nodes.Add(lColumnNode)
                Next
            Next

            'Procedures ----------------------------------------------------------------------------------
            For Each lSP As MetaDiscovery.Procedure In lProvider.Procedures

                Dim lSPNode As New System.Windows.Forms.TreeNode(lSP.SchemaName)
                lSPNode.ImageIndex = 6
                lSPNode.SelectedImageIndex = 6

                lSPNode.Tag = lSP

                lProceduresFolderNode.Nodes.Add(lSPNode)

                For Each lParameter As MetaDiscovery.Parameter In lSP.Parameters
                    Dim lParameterNode As New System.Windows.Forms.TreeNode(lParameter.Name)
                    lParameterNode.ImageIndex = 9
                    lParameterNode.SelectedImageIndex = 9
                    lParameterNode.Tag = lParameter

                    lSPNode.Nodes.Add(lParameterNode)
                Next
            Next
        Next

    End Sub

    Public Sub Initialize(ByVal pProject As MetaDiscovery.Project, ByVal pVersionString As String)
        Me.Text = String.Format("SpitCode {0} - Schema Designer", pVersionString)
        _Project = pProject
        Me.FillUI()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CloseMe()
    End Sub

    Private Sub CloseMe()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        If Not (e.Node.Tag Is Nothing) Then
            PropertyGrid1.SelectedObject = e.Node.Tag
        Else
            PropertyGrid1.SelectedObject = Nothing
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Me.CloseMe()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me._Project.SaveChanges()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me._Project.SaveChanges()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ShowAboutbox()
        Dim lUI As New SplashScreen(SplashScreen.DisplayMode.AboutBox)
        lUI.ShowDialog()
    End Sub
  
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Me.ShowAboutbox()
    End Sub
End Class