<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SchemaEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SchemaEditor))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SchemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateSchemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutThisToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.trSchemaTree = New System.Windows.Forms.TreeView()
        Me.IconList = New System.Windows.Forms.ImageList(Me.components)
        Me.prgDataObjectEditor = New System.Windows.Forms.PropertyGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtConsoleOutput = New System.Windows.Forms.TextBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.bgWorker = New System.ComponentModel.BackgroundWorker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.pbProgressIndicator = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblStatusIndicator = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ctxProjectMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UpdateLanguageMappingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshRelationshipsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ctxProjectMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SchemaToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(921, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SchemaToolStripMenuItem
        '
        Me.SchemaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveSettingsToolStripMenuItem, Me.UpdateSchemaToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.SchemaToolStripMenuItem.Name = "SchemaToolStripMenuItem"
        Me.SchemaToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.SchemaToolStripMenuItem.Text = "Schema"
        '
        'SaveSettingsToolStripMenuItem
        '
        Me.SaveSettingsToolStripMenuItem.Name = "SaveSettingsToolStripMenuItem"
        Me.SaveSettingsToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.SaveSettingsToolStripMenuItem.Text = "Save settings"
        '
        'UpdateSchemaToolStripMenuItem
        '
        Me.UpdateSchemaToolStripMenuItem.Name = "UpdateSchemaToolStripMenuItem"
        Me.UpdateSchemaToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.UpdateSchemaToolStripMenuItem.Text = "Update schema"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(150, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutThisToolToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutThisToolToolStripMenuItem
        '
        Me.AboutThisToolToolStripMenuItem.Name = "AboutThisToolToolStripMenuItem"
        Me.AboutThisToolToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AboutThisToolToolStripMenuItem.Text = "About this tool"
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.SplitContainer1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(921, 507)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(921, 532)
        Me.ToolStripContainer1.TabIndex = 1
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(921, 507)
        Me.SplitContainer1.SplitterDistance = 297
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.trSchemaTree)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.prgDataObjectEditor)
        Me.SplitContainer2.Size = New System.Drawing.Size(921, 297)
        Me.SplitContainer2.SplitterDistance = 378
        Me.SplitContainer2.TabIndex = 0
        '
        'trSchemaTree
        '
        Me.trSchemaTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trSchemaTree.ImageIndex = 0
        Me.trSchemaTree.ImageList = Me.IconList
        Me.trSchemaTree.LabelEdit = True
        Me.trSchemaTree.Location = New System.Drawing.Point(0, 0)
        Me.trSchemaTree.Name = "trSchemaTree"
        Me.trSchemaTree.SelectedImageIndex = 0
        Me.trSchemaTree.Size = New System.Drawing.Size(378, 297)
        Me.trSchemaTree.TabIndex = 0
        '
        'IconList
        '
        Me.IconList.ImageStream = CType(resources.GetObject("IconList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.IconList.TransparentColor = System.Drawing.Color.Transparent
        Me.IconList.Images.SetKeyName(0, "application.png")
        Me.IconList.Images.SetKeyName(1, "database.png")
        Me.IconList.Images.SetKeyName(2, "folder.png")
        Me.IconList.Images.SetKeyName(3, "script_gear.png")
        Me.IconList.Images.SetKeyName(4, "table.png")
        Me.IconList.Images.SetKeyName(5, "table_error.png")
        Me.IconList.Images.SetKeyName(6, "textfield_rename.png")
        Me.IconList.Images.SetKeyName(7, "table_key.png")
        Me.IconList.Images.SetKeyName(8, "script_code.png")
        '
        'prgDataObjectEditor
        '
        Me.prgDataObjectEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prgDataObjectEditor.Location = New System.Drawing.Point(0, 0)
        Me.prgDataObjectEditor.Name = "prgDataObjectEditor"
        Me.prgDataObjectEditor.Size = New System.Drawing.Size(539, 297)
        Me.prgDataObjectEditor.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtConsoleOutput)
        Me.GroupBox1.Controls.Add(Me.ToolStrip2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(921, 206)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Output"
        '
        'txtConsoleOutput
        '
        Me.txtConsoleOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtConsoleOutput.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsoleOutput.Location = New System.Drawing.Point(3, 41)
        Me.txtConsoleOutput.Multiline = True
        Me.txtConsoleOutput.Name = "txtConsoleOutput"
        Me.txtConsoleOutput.ReadOnly = True
        Me.txtConsoleOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConsoleOutput.Size = New System.Drawing.Size(915, 162)
        Me.txtConsoleOutput.TabIndex = 1
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton4})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 16)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(915, 25)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(92, 22)
        Me.ToolStripButton4.Text = "Clear output"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(256, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(133, 22)
        Me.ToolStripButton1.Text = "Save project settings"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(111, 22)
        Me.ToolStripButton2.Text = "Update schemas"
        '
        'bgWorker
        '
        Me.bgWorker.WorkerReportsProgress = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pbProgressIndicator, Me.lblStatusIndicator})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 556)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(921, 23)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'pbProgressIndicator
        '
        Me.pbProgressIndicator.Name = "pbProgressIndicator"
        Me.pbProgressIndicator.Size = New System.Drawing.Size(100, 17)
        '
        'lblStatusIndicator
        '
        Me.lblStatusIndicator.Name = "lblStatusIndicator"
        Me.lblStatusIndicator.Size = New System.Drawing.Size(38, 18)
        Me.lblStatusIndicator.Text = "Ready"
        '
        'ctxProjectMenu
        '
        Me.ctxProjectMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateLanguageMappingsToolStripMenuItem, Me.RefreshRelationshipsToolStripMenuItem})
        Me.ctxProjectMenu.Name = "ctxProjectMenu"
        Me.ctxProjectMenu.Size = New System.Drawing.Size(219, 70)
        '
        'UpdateLanguageMappingsToolStripMenuItem
        '
        Me.UpdateLanguageMappingsToolStripMenuItem.Name = "UpdateLanguageMappingsToolStripMenuItem"
        Me.UpdateLanguageMappingsToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.UpdateLanguageMappingsToolStripMenuItem.Text = "Update language mappings"
        '
        'RefreshRelationshipsToolStripMenuItem
        '
        Me.RefreshRelationshipsToolStripMenuItem.Name = "RefreshRelationshipsToolStripMenuItem"
        Me.RefreshRelationshipsToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.RefreshRelationshipsToolStripMenuItem.Text = "Refresh relationships"
        '
        'SchemaEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 579)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "SchemaEditor"
        Me.Text = "AppSimplicity - Schema Editor"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ctxProjectMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SchemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateSchemaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutThisToolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents trSchemaTree As System.Windows.Forms.TreeView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents prgDataObjectEditor As System.Windows.Forms.PropertyGrid
    Friend WithEvents IconList As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents bgWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtConsoleOutput As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents pbProgressIndicator As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblStatusIndicator As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ctxProjectMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents UpdateLanguageMappingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshRelationshipsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
