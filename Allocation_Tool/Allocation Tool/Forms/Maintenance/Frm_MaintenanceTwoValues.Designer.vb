<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MaintenanceTwoValues
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MaintenanceTwoValues))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDelete = New System.Windows.Forms.ToolStripButton()
        Me.LabelCombo = New System.Windows.Forms.Label()
        Me.LabelValue = New System.Windows.Forms.Label()
        Me.ComboBoxRequired = New System.Windows.Forms.ComboBox()
        Me.TextBoxValue = New System.Windows.Forms.TextBox()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel.SuspendLayout()
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonNew, Me.ToolStripButtonEdit, Me.ToolStripButtonSave, Me.ToolStripButtonDelete})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(506, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButtonNew
        '
        Me.ToolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonNew.Image = Global.Allocation_Tool.My.Resources.Resources.New_Document
        Me.ToolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonNew.Name = "ToolStripButtonNew"
        Me.ToolStripButtonNew.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonNew.Text = "New"
        '
        'ToolStripButtonEdit
        '
        Me.ToolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonEdit.Enabled = False
        Me.ToolStripButtonEdit.Image = Global.Allocation_Tool.My.Resources.Resources.Write_File
        Me.ToolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonEdit.Name = "ToolStripButtonEdit"
        Me.ToolStripButtonEdit.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonEdit.Text = "Edit"
        '
        'ToolStripButtonSave
        '
        Me.ToolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSave.Enabled = False
        Me.ToolStripButtonSave.Image = Global.Allocation_Tool.My.Resources.Resources.disk_save
        Me.ToolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSave.Name = "ToolStripButtonSave"
        Me.ToolStripButtonSave.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonSave.Text = "Save"
        '
        'ToolStripButtonDelete
        '
        Me.ToolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonDelete.Enabled = False
        Me.ToolStripButtonDelete.Image = Global.Allocation_Tool.My.Resources.Resources.Delete_Document
        Me.ToolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonDelete.Name = "ToolStripButtonDelete"
        Me.ToolStripButtonDelete.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonDelete.Text = "Delete"
        '
        'LabelCombo
        '
        Me.LabelCombo.AutoSize = True
        Me.LabelCombo.Location = New System.Drawing.Point(16, 13)
        Me.LabelCombo.Name = "LabelCombo"
        Me.LabelCombo.Size = New System.Drawing.Size(56, 13)
        Me.LabelCombo.TabIndex = 1
        Me.LabelCombo.Text = "[lblCombo]"
        '
        'LabelValue
        '
        Me.LabelValue.AutoSize = True
        Me.LabelValue.Location = New System.Drawing.Point(16, 46)
        Me.LabelValue.Name = "LabelValue"
        Me.LabelValue.Size = New System.Drawing.Size(50, 13)
        Me.LabelValue.TabIndex = 2
        Me.LabelValue.Text = "[lblValue]"
        '
        'ComboBoxRequired
        '
        Me.ComboBoxRequired.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxRequired.FormattingEnabled = True
        Me.ComboBoxRequired.Location = New System.Drawing.Point(118, 10)
        Me.ComboBoxRequired.Name = "ComboBoxRequired"
        Me.ComboBoxRequired.Size = New System.Drawing.Size(373, 21)
        Me.ComboBoxRequired.TabIndex = 3
        '
        'TextBoxValue
        '
        Me.TextBoxValue.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxValue.Location = New System.Drawing.Point(118, 43)
        Me.TextBoxValue.Name = "TextBoxValue"
        Me.TextBoxValue.Size = New System.Drawing.Size(373, 20)
        Me.TextBoxValue.TabIndex = 4
        '
        'DataGridView
        '
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView.Location = New System.Drawing.Point(3, 83)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView.Size = New System.Drawing.Size(500, 150)
        Me.DataGridView.TabIndex = 5
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 1
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel.Controls.Add(Me.DataGridView, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.Panel, 0, 0)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 31)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 2
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel.Size = New System.Drawing.Size(506, 229)
        Me.TableLayoutPanel.TabIndex = 6
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.LabelCombo)
        Me.Panel.Controls.Add(Me.TextBoxValue)
        Me.Panel.Controls.Add(Me.LabelValue)
        Me.Panel.Controls.Add(Me.ComboBoxRequired)
        Me.Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel.Location = New System.Drawing.Point(3, 3)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(500, 74)
        Me.Panel.TabIndex = 6
        '
        'Frm_MaintenanceTwoValues
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(506, 260)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_MaintenanceTwoValues"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "[Title]"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents LabelCombo As System.Windows.Forms.Label
    Friend WithEvents LabelValue As System.Windows.Forms.Label
    Friend WithEvents ComboBoxRequired As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxValue As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents ToolStripButtonNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonDelete As System.Windows.Forms.ToolStripButton
End Class
