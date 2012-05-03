Imports AppSimplicity
Imports AppSimplicity.SchemaDiscovery
Imports System.Windows.Forms

Public Class SchemaEditor

    Private WithEvents _Project As Entities.Project
    Private _Factory As AppSimplicity.SchemaDiscovery.ProjectFactory
    Private _CodeGenerator As AppSimplicity.CodeGeneration.Engine.CodeGenerator

    Private ReadOnly Property Factory() As AppSimplicity.SchemaDiscovery.ProjectFactory
        Get
            If (_Factory Is Nothing) Then
                _Factory = New AppSimplicity.SchemaDiscovery.ProjectFactory()
            End If
            Return _Factory
        End Get
    End Property

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Public Sub Initialize(ByVal project As Entities.Project, codeGenerator As AppSimplicity.CodeGeneration.Engine.CodeGenerator)
        _Project = project
        _CodeGenerator = codeGenerator
        Me.InitializeTree(_Project)


        Dim lConsoleTextWriter As New ConsoleToTextboxWriter(Me.txtConsoleOutput)
        Console.SetOut(lConsoleTextWriter)
    End Sub

    Public Sub InitializeTree(ByVal pProject As Entities.Project)
        Me.trSchemaTree.Nodes.Clear()

        Dim lProjectNode As New TreeNode(pProject.ProjectName)
        Dim lDataSourcesNode As New TreeNode("Datasources")
        lProjectNode.Nodes.Add(lDataSourcesNode)
        lProjectNode.Tag = pProject
        lProjectNode.ImageIndex = IconSet.Application
        lProjectNode.SelectedImageIndex = IconSet.Application

        lDataSourcesNode.ImageIndex = IconSet.Folder
        lDataSourcesNode.SelectedImageIndex = IconSet.Folder
        Me.FillDataSourcesNode(lDataSourcesNode)

        Me.trSchemaTree.Nodes.Add(lProjectNode)
    End Sub

    Private Sub FillDataSourcesNode(ByVal pParentNode As TreeNode)
        For Each lDS As Entities.DataSource In _Project.DataSources
            Dim lNode As New TreeNode(lDS.DataSourceName, IconSet.Database, IconSet.Database)

            lNode.Tag = lDS
            lNode.ImageIndex = IconSet.Database
            lNode.SelectedImageIndex = IconSet.Database
            pParentNode.Nodes.Add(lNode)

            Dim lTablesNode As New TreeNode("Tables", IconSet.Folder, IconSet.Folder)
            For Each lTable As Entities.Table In lDS.Tables
                Dim lTableNode As New TreeNode(lTable.QualifiedName)
                If (lTable.PrimaryKey Is Nothing) Then
                    lTableNode.ImageIndex = IconSet.TableError
                    lTableNode.SelectedImageIndex = IconSet.TableError
                Else
                    lTableNode.ImageIndex = IconSet.Table
                    lTableNode.SelectedImageIndex = IconSet.Table
                End If

                lTableNode.Tag = lTable

                Dim lColumnsFolderNode As New TreeNode("Columns", IconSet.Folder, IconSet.Folder)
                For Each lColumn As Entities.Column In lTable.Columns
                    Dim lColumnNode As New TreeNode(lColumn.ColumnName)
                    lColumnNode.SelectedImageIndex = IconSet.Column
                    lColumnNode.ImageIndex = IconSet.Column
                    lColumnNode.Tag = lColumn
                    lColumnsFolderNode.Nodes.Add(lColumnNode)
                Next
                lTableNode.Nodes.Add(lColumnsFolderNode)
                lTablesNode.Nodes.Add(lTableNode)

                If (lTable.Keys.Count > 0) Then
                    Dim lKeysNode As New TreeNode("Keys", IconSet.Folder, IconSet.Folder)

                    For Each lkey As Entities.TableKey In lTable.Keys
                        Dim lKeyNode As New TreeNode(lkey.Name, IconSet.Table, IconSet.Table)
                        lKeyNode.Tag = lkey
                        lKeyNode.ImageIndex = IconSet.TableKey
                        lKeyNode.SelectedImageIndex = IconSet.TableKey
                        lKeysNode.Nodes.Add(lKeyNode)
                    Next

                    lTableNode.Nodes.Add(lKeysNode)
                End If
            Next

            Dim lViewsNode As New TreeNode("Views", IconSet.Folder, IconSet.Folder)
            For Each lView As Entities.View In lDS.Views
                Dim lViewNode As New TreeNode(lView.QualifiedName)
                lViewNode.Tag = lView

                Dim lColumnsFolderNode As New TreeNode("Columns", IconSet.Folder, IconSet.Folder)
                For Each lColumn As Entities.Column In lView.Columns
                    Dim lColumnNode As New TreeNode(lColumn.ColumnName)
                    lColumnNode.SelectedImageIndex = IconSet.Column
                    lColumnNode.ImageIndex = IconSet.Column
                    lColumnNode.Tag = lColumn
                    lColumnsFolderNode.Nodes.Add(lColumnNode)
                Next
                lViewNode.Nodes.Add(lColumnsFolderNode)

                lViewsNode.Nodes.Add(lViewNode)
            Next

            Dim lSPs As New TreeNode("Stored procedures", IconSet.Folder, IconSet.Folder)
            For Each lSP As Entities.StoredProcedure In lDS.StoredProcedures
                Dim lSPNode As New TreeNode(lSP.QualifiedName)
                lSPNode.ImageIndex = IconSet.StoredProcedure
                lSPNode.SelectedImageIndex = IconSet.StoredProcedure
                lSPNode.Tag = lSP

                Dim lParametersNode As New TreeNode("Parameters", IconSet.Folder, IconSet.Folder)
                For Each lParameter As Entities.StoredProcedureParameter In lSP.Parameters
                    Dim lPNode As New TreeNode(lParameter.ParameterName)
                    lPNode.Tag = lParameter
                    lPNode.ImageIndex = IconSet.StoredProcedureParameter
                    lPNode.SelectedImageIndex = IconSet.StoredProcedureParameter
                    lParametersNode.Nodes.Add(lPNode)
                Next
                lSPNode.Nodes.Add(lParametersNode)
                lSPs.Nodes.Add(lSPNode)
            Next

            lNode.Nodes.Add(lTablesNode)
            lNode.Nodes.Add(lViewsNode)
            lNode.Nodes.Add(lSPs)
        Next
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.PersistProject()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.UpdateSchema()
    End Sub

    Private Sub PersistProject()
        Me.EnableControls(False)
        Me.Factory.SaveProjectToFile(_Project)
        Me.EnableControls(True)
    End Sub

    Private Sub UpdateSchema()
        Me.EnableControls(False)
        Me.lblStatusIndicator.Text = "Running metadata extraction..."
        Me.txtConsoleOutput.Clear()
        Me.Factory.AttachBackgroundProcess(Me.bgWorker)
        Me.bgWorker.RunWorkerAsync()
    End Sub

    Private Sub EnableControls(enable As Boolean)
        For Each lcontrol As Control In Me.Controls
            lcontrol.Enabled = enable
        Next
    End Sub

    Private Sub SaveSettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveSettingsToolStripMenuItem.Click
        Me.PersistProject()
    End Sub

    Private Sub UpdateSchemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateSchemaToolStripMenuItem.Click
        Me.UpdateSchema()
    End Sub

    Private Sub trSchemaTree_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trSchemaTree.AfterSelect
        Me.prgDataObjectEditor.SelectedObject = e.Node.Tag
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.txtConsoleOutput.Clear()
    End Sub

    Private Sub bgWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker.DoWork
        Me.Factory.UpdateProject(_Project)
    End Sub

    Private Sub bgWorker_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgWorker.ProgressChanged
        Me.pbProgressIndicator.Value = e.ProgressPercentage

        If Not (e.UserState Is Nothing) Then
            Me.lblStatusIndicator.Text = CType(e.UserState, System.String)
            Console.WriteLine(CType(e.UserState, System.String))
        End If
    End Sub

    Private Sub bgWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted
        Me.lblStatusIndicator.Text = "Ready"
        Me.pbProgressIndicator.Value = 0
        Me.Factory.DetachBackgroundProcess()
        Me.PersistProject()
        Me.InitializeTree(_Project)
        Me.EnableControls(True)
    End Sub

    Private Sub ToolStripButton4_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        Me.txtConsoleOutput.Clear()
    End Sub

   
End Class