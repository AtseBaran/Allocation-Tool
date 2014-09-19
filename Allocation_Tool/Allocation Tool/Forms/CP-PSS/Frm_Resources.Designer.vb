<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Resources
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Resources))
        Me.GroupBoxNewEntry = New System.Windows.Forms.GroupBox()
        Me.TextBoxMonthlyValue = New System.Windows.Forms.TextBox()
        Me.ListBoxMonths = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DTP_End = New System.Windows.Forms.DateTimePicker()
        Me.DTP_Start = New System.Windows.Forms.DateTimePicker()
        Me.LabelEndDate = New System.Windows.Forms.Label()
        Me.LabelStartDate = New System.Windows.Forms.Label()
        Me.LabelMonthlyValue = New System.Windows.Forms.Label()
        Me.ComboBoxEntryType = New System.Windows.Forms.ComboBox()
        Me.ComboBoxProjectPhase = New System.Windows.Forms.ComboBox()
        Me.ComboBoxResourceType = New System.Windows.Forms.ComboBox()
        Me.LabelEntryType = New System.Windows.Forms.Label()
        Me.LabelProjectPhase = New System.Windows.Forms.Label()
        Me.LabelResourceType = New System.Windows.Forms.Label()
        Me.CheckedListBoxOwner = New System.Windows.Forms.CheckedListBox()
        Me.GroupBoxAssign = New System.Windows.Forms.GroupBox()
        Me.ButtonAdd = New System.Windows.Forms.Button()
        Me.GroupBoxServiceLine = New System.Windows.Forms.GroupBox()
        Me.CheckedListBoxServiceLine = New System.Windows.Forms.CheckedListBox()
        Me.GroupBoxOwnerList = New System.Windows.Forms.GroupBox()
        Me.ButtonRemove = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanelPreview = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridViewSelected = New System.Windows.Forms.DataGridView()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCancel = New System.Windows.Forms.ToolStripButton()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBoxNewEntry.SuspendLayout()
        Me.GroupBoxAssign.SuspendLayout()
        Me.GroupBoxServiceLine.SuspendLayout()
        Me.GroupBoxOwnerList.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanelPreview.SuspendLayout()
        CType(Me.DataGridViewSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.TableLayoutPanel.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxNewEntry
        '
        Me.GroupBoxNewEntry.Controls.Add(Me.TextBoxMonthlyValue)
        Me.GroupBoxNewEntry.Controls.Add(Me.ListBoxMonths)
        Me.GroupBoxNewEntry.Controls.Add(Me.Label7)
        Me.GroupBoxNewEntry.Controls.Add(Me.DTP_End)
        Me.GroupBoxNewEntry.Controls.Add(Me.DTP_Start)
        Me.GroupBoxNewEntry.Controls.Add(Me.LabelEndDate)
        Me.GroupBoxNewEntry.Controls.Add(Me.LabelStartDate)
        Me.GroupBoxNewEntry.Controls.Add(Me.LabelMonthlyValue)
        Me.GroupBoxNewEntry.Controls.Add(Me.ComboBoxEntryType)
        Me.GroupBoxNewEntry.Controls.Add(Me.ComboBoxProjectPhase)
        Me.GroupBoxNewEntry.Controls.Add(Me.ComboBoxResourceType)
        Me.GroupBoxNewEntry.Controls.Add(Me.LabelEntryType)
        Me.GroupBoxNewEntry.Controls.Add(Me.LabelProjectPhase)
        Me.GroupBoxNewEntry.Controls.Add(Me.LabelResourceType)
        Me.GroupBoxNewEntry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxNewEntry.Location = New System.Drawing.Point(3, 3)
        Me.GroupBoxNewEntry.Name = "GroupBoxNewEntry"
        Me.GroupBoxNewEntry.Padding = New System.Windows.Forms.Padding(10)
        Me.GroupBoxNewEntry.Size = New System.Drawing.Size(452, 190)
        Me.GroupBoxNewEntry.TabIndex = 0
        Me.GroupBoxNewEntry.TabStop = False
        Me.GroupBoxNewEntry.Text = "New Entry"
        '
        'TextBoxMonthlyValue
        '
        Me.TextBoxMonthlyValue.Location = New System.Drawing.Point(100, 101)
        Me.TextBoxMonthlyValue.Name = "TextBoxMonthlyValue"
        Me.TextBoxMonthlyValue.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxMonthlyValue.TabIndex = 4
        '
        'ListBoxMonths
        '
        Me.ListBoxMonths.FormattingEnabled = True
        Me.ListBoxMonths.Location = New System.Drawing.Point(315, 71)
        Me.ListBoxMonths.Name = "ListBoxMonths"
        Me.ListBoxMonths.Size = New System.Drawing.Size(121, 108)
        Me.ListBoxMonths.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(228, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Months"
        '
        'DTP_End
        '
        Me.DTP_End.CustomFormat = "MMMM yyyy"
        Me.DTP_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_End.Location = New System.Drawing.Point(315, 43)
        Me.DTP_End.Name = "DTP_End"
        Me.DTP_End.Size = New System.Drawing.Size(121, 20)
        Me.DTP_End.TabIndex = 6
        '
        'DTP_Start
        '
        Me.DTP_Start.CustomFormat = "MMMM yyyy"
        Me.DTP_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_Start.Location = New System.Drawing.Point(315, 17)
        Me.DTP_Start.Name = "DTP_Start"
        Me.DTP_Start.Size = New System.Drawing.Size(121, 20)
        Me.DTP_Start.TabIndex = 5
        '
        'LabelEndDate
        '
        Me.LabelEndDate.AutoSize = True
        Me.LabelEndDate.Location = New System.Drawing.Point(227, 49)
        Me.LabelEndDate.Name = "LabelEndDate"
        Me.LabelEndDate.Size = New System.Drawing.Size(52, 13)
        Me.LabelEndDate.TabIndex = 9
        Me.LabelEndDate.Text = "End Date"
        '
        'LabelStartDate
        '
        Me.LabelStartDate.AutoSize = True
        Me.LabelStartDate.Location = New System.Drawing.Point(227, 23)
        Me.LabelStartDate.Name = "LabelStartDate"
        Me.LabelStartDate.Size = New System.Drawing.Size(55, 13)
        Me.LabelStartDate.TabIndex = 8
        Me.LabelStartDate.Text = "Start Date"
        '
        'LabelMonthlyValue
        '
        Me.LabelMonthlyValue.AutoSize = True
        Me.LabelMonthlyValue.Location = New System.Drawing.Point(12, 104)
        Me.LabelMonthlyValue.Name = "LabelMonthlyValue"
        Me.LabelMonthlyValue.Size = New System.Drawing.Size(74, 13)
        Me.LabelMonthlyValue.TabIndex = 6
        Me.LabelMonthlyValue.Text = "Monthly Value"
        '
        'ComboBoxEntryType
        '
        Me.ComboBoxEntryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEntryType.FormattingEnabled = True
        Me.ComboBoxEntryType.Location = New System.Drawing.Point(100, 74)
        Me.ComboBoxEntryType.Name = "ComboBoxEntryType"
        Me.ComboBoxEntryType.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxEntryType.TabIndex = 3
        '
        'ComboBoxProjectPhase
        '
        Me.ComboBoxProjectPhase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxProjectPhase.FormattingEnabled = True
        Me.ComboBoxProjectPhase.Location = New System.Drawing.Point(100, 47)
        Me.ComboBoxProjectPhase.Name = "ComboBoxProjectPhase"
        Me.ComboBoxProjectPhase.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxProjectPhase.TabIndex = 2
        '
        'ComboBoxResourceType
        '
        Me.ComboBoxResourceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxResourceType.FormattingEnabled = True
        Me.ComboBoxResourceType.Location = New System.Drawing.Point(100, 20)
        Me.ComboBoxResourceType.Name = "ComboBoxResourceType"
        Me.ComboBoxResourceType.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxResourceType.TabIndex = 1
        '
        'LabelEntryType
        '
        Me.LabelEntryType.AutoSize = True
        Me.LabelEntryType.Location = New System.Drawing.Point(13, 77)
        Me.LabelEntryType.Name = "LabelEntryType"
        Me.LabelEntryType.Size = New System.Drawing.Size(58, 13)
        Me.LabelEntryType.TabIndex = 2
        Me.LabelEntryType.Text = "Entry Type"
        '
        'LabelProjectPhase
        '
        Me.LabelProjectPhase.AutoSize = True
        Me.LabelProjectPhase.Location = New System.Drawing.Point(12, 50)
        Me.LabelProjectPhase.Name = "LabelProjectPhase"
        Me.LabelProjectPhase.Size = New System.Drawing.Size(73, 13)
        Me.LabelProjectPhase.TabIndex = 1
        Me.LabelProjectPhase.Text = "Project Phase"
        '
        'LabelResourceType
        '
        Me.LabelResourceType.AutoSize = True
        Me.LabelResourceType.Location = New System.Drawing.Point(12, 23)
        Me.LabelResourceType.Name = "LabelResourceType"
        Me.LabelResourceType.Size = New System.Drawing.Size(80, 13)
        Me.LabelResourceType.TabIndex = 0
        Me.LabelResourceType.Text = "Resource Type"
        '
        'CheckedListBoxOwner
        '
        Me.CheckedListBoxOwner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxOwner.FormattingEnabled = True
        Me.CheckedListBoxOwner.Location = New System.Drawing.Point(3, 16)
        Me.CheckedListBoxOwner.Name = "CheckedListBoxOwner"
        Me.CheckedListBoxOwner.Size = New System.Drawing.Size(169, 146)
        Me.CheckedListBoxOwner.TabIndex = 8
        '
        'GroupBoxAssign
        '
        Me.GroupBoxAssign.Controls.Add(Me.ButtonAdd)
        Me.GroupBoxAssign.Controls.Add(Me.GroupBoxServiceLine)
        Me.GroupBoxAssign.Controls.Add(Me.GroupBoxOwnerList)
        Me.GroupBoxAssign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxAssign.Location = New System.Drawing.Point(461, 3)
        Me.GroupBoxAssign.Name = "GroupBoxAssign"
        Me.GroupBoxAssign.Size = New System.Drawing.Size(453, 190)
        Me.GroupBoxAssign.TabIndex = 1
        Me.GroupBoxAssign.TabStop = False
        Me.GroupBoxAssign.Text = "Assign Entry"
        '
        'ButtonAdd
        '
        Me.ButtonAdd.Image = Global.Allocation_Tool.My.Resources.Resources.forward
        Me.ButtonAdd.Location = New System.Drawing.Point(369, 71)
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.Size = New System.Drawing.Size(78, 63)
        Me.ButtonAdd.TabIndex = 10
        Me.ButtonAdd.Text = "Add Resource"
        Me.ButtonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonAdd.UseVisualStyleBackColor = True
        '
        'GroupBoxServiceLine
        '
        Me.GroupBoxServiceLine.Controls.Add(Me.CheckedListBoxServiceLine)
        Me.GroupBoxServiceLine.Location = New System.Drawing.Point(187, 19)
        Me.GroupBoxServiceLine.Name = "GroupBoxServiceLine"
        Me.GroupBoxServiceLine.Size = New System.Drawing.Size(175, 165)
        Me.GroupBoxServiceLine.TabIndex = 17
        Me.GroupBoxServiceLine.TabStop = False
        Me.GroupBoxServiceLine.Text = "Service Line"
        '
        'CheckedListBoxServiceLine
        '
        Me.CheckedListBoxServiceLine.CheckOnClick = True
        Me.CheckedListBoxServiceLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxServiceLine.FormattingEnabled = True
        Me.CheckedListBoxServiceLine.Location = New System.Drawing.Point(3, 16)
        Me.CheckedListBoxServiceLine.Name = "CheckedListBoxServiceLine"
        Me.CheckedListBoxServiceLine.Size = New System.Drawing.Size(169, 146)
        Me.CheckedListBoxServiceLine.TabIndex = 9
        '
        'GroupBoxOwnerList
        '
        Me.GroupBoxOwnerList.Controls.Add(Me.CheckedListBoxOwner)
        Me.GroupBoxOwnerList.Location = New System.Drawing.Point(6, 19)
        Me.GroupBoxOwnerList.Name = "GroupBoxOwnerList"
        Me.GroupBoxOwnerList.Size = New System.Drawing.Size(175, 165)
        Me.GroupBoxOwnerList.TabIndex = 16
        Me.GroupBoxOwnerList.TabStop = False
        Me.GroupBoxOwnerList.Text = "Owner List"
        '
        'ButtonRemove
        '
        Me.ButtonRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonRemove.Location = New System.Drawing.Point(3, 3)
        Me.ButtonRemove.Name = "ButtonRemove"
        Me.ButtonRemove.Size = New System.Drawing.Size(115, 29)
        Me.ButtonRemove.TabIndex = 11
        Me.ButtonRemove.Text = "Remove Resource"
        Me.ButtonRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonRemove.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanelPreview)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 240)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(10)
        Me.GroupBox1.Size = New System.Drawing.Size(917, 197)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Preview List"
        '
        'TableLayoutPanelPreview
        '
        Me.TableLayoutPanelPreview.ColumnCount = 1
        Me.TableLayoutPanelPreview.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelPreview.Controls.Add(Me.ButtonRemove, 0, 0)
        Me.TableLayoutPanelPreview.Controls.Add(Me.DataGridViewSelected, 0, 1)
        Me.TableLayoutPanelPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelPreview.Location = New System.Drawing.Point(10, 23)
        Me.TableLayoutPanelPreview.Name = "TableLayoutPanelPreview"
        Me.TableLayoutPanelPreview.RowCount = 2
        Me.TableLayoutPanelPreview.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanelPreview.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelPreview.Size = New System.Drawing.Size(897, 164)
        Me.TableLayoutPanelPreview.TabIndex = 1
        '
        'DataGridViewSelected
        '
        Me.DataGridViewSelected.AllowUserToAddRows = False
        Me.DataGridViewSelected.AllowUserToDeleteRows = False
        Me.DataGridViewSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewSelected.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewSelected.Location = New System.Drawing.Point(3, 38)
        Me.DataGridViewSelected.Name = "DataGridViewSelected"
        Me.DataGridViewSelected.ReadOnly = True
        Me.DataGridViewSelected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewSelected.Size = New System.Drawing.Size(891, 123)
        Me.DataGridViewSelected.TabIndex = 0
        '
        'ToolStrip
        '
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonSave, Me.ToolStripButtonCancel})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(923, 35)
        Me.ToolStrip.TabIndex = 2
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'ToolStripButtonSave
        '
        Me.ToolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSave.Image = Global.Allocation_Tool.My.Resources.Resources.disk_save
        Me.ToolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSave.Name = "ToolStripButtonSave"
        Me.ToolStripButtonSave.Size = New System.Drawing.Size(28, 32)
        Me.ToolStripButtonSave.Text = "Save"
        '
        'ToolStripButtonCancel
        '
        Me.ToolStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonCancel.Image = Global.Allocation_Tool.My.Resources.Resources.Delete
        Me.ToolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCancel.Name = "ToolStripButtonCancel"
        Me.ToolStripButtonCancel.Size = New System.Drawing.Size(28, 32)
        Me.ToolStripButtonCancel.Text = "Clear"
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 1
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.Controls.Add(Me.ToolStrip, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.GroupBox1, 0, 2)
        Me.TableLayoutPanel.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 3
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(923, 440)
        Me.TableLayoutPanel.TabIndex = 20
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBoxNewEntry, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBoxAssign, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 38)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(917, 196)
        Me.TableLayoutPanel2.TabIndex = 20
        '
        'Frm_Resources
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(923, 440)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Resources"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Resources"
        Me.GroupBoxNewEntry.ResumeLayout(False)
        Me.GroupBoxNewEntry.PerformLayout()
        Me.GroupBoxAssign.ResumeLayout(False)
        Me.GroupBoxServiceLine.ResumeLayout(False)
        Me.GroupBoxOwnerList.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanelPreview.ResumeLayout(False)
        CType(Me.DataGridViewSelected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxNewEntry As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DTP_End As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_Start As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelEndDate As System.Windows.Forms.Label
    Friend WithEvents LabelStartDate As System.Windows.Forms.Label
    Friend WithEvents LabelMonthlyValue As System.Windows.Forms.Label
    Friend WithEvents ComboBoxEntryType As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxProjectPhase As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxResourceType As System.Windows.Forms.ComboBox
    Friend WithEvents LabelEntryType As System.Windows.Forms.Label
    Friend WithEvents LabelProjectPhase As System.Windows.Forms.Label
    Friend WithEvents LabelResourceType As System.Windows.Forms.Label
    Friend WithEvents GroupBoxAssign As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents CheckedListBoxOwner As System.Windows.Forms.CheckedListBox
    Friend WithEvents ListBoxMonths As System.Windows.Forms.ListBox
    Friend WithEvents ButtonAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBoxServiceLine As System.Windows.Forms.GroupBox
    Friend WithEvents CheckedListBoxServiceLine As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBoxOwnerList As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonRemove As System.Windows.Forms.Button
    Friend WithEvents DataGridViewSelected As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBoxMonthlyValue As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanelPreview As System.Windows.Forms.TableLayoutPanel
End Class
