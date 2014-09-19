<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MaintenanceOneValue
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MaintenanceOneValue))
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.TextBoxValue = New System.Windows.Forms.TextBox()
        Me.LabelTexto = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDelete = New System.Windows.Forms.ToolStripButton()
        Me.TableLayoutPanel.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 1
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel.Controls.Add(Me.DataGridView, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.Panel, 0, 0)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 2
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel.Size = New System.Drawing.Size(539, 322)
        Me.TableLayoutPanel.TabIndex = 0
        '
        'DataGridView
        '
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView.Location = New System.Drawing.Point(3, 73)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView.Size = New System.Drawing.Size(533, 246)
        Me.DataGridView.TabIndex = 0
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.TextBoxValue)
        Me.Panel.Controls.Add(Me.LabelTexto)
        Me.Panel.Controls.Add(Me.ToolStrip)
        Me.Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel.Location = New System.Drawing.Point(3, 3)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(533, 64)
        Me.Panel.TabIndex = 1
        '
        'TextBoxValue
        '
        Me.TextBoxValue.Enabled = False
        Me.TextBoxValue.Location = New System.Drawing.Point(99, 38)
        Me.TextBoxValue.Name = "TextBoxValue"
        Me.TextBoxValue.Size = New System.Drawing.Size(425, 20)
        Me.TextBoxValue.TabIndex = 2
        '
        'LabelTexto
        '
        Me.LabelTexto.AutoSize = True
        Me.LabelTexto.Location = New System.Drawing.Point(9, 41)
        Me.LabelTexto.Name = "LabelTexto"
        Me.LabelTexto.Size = New System.Drawing.Size(50, 13)
        Me.LabelTexto.TabIndex = 1
        Me.LabelTexto.Text = "[lblTexto]"
        Me.LabelTexto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonNew, Me.ToolStripButtonEdit, Me.ToolStripButtonSave, Me.ToolStripButtonDelete})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(533, 31)
        Me.ToolStrip.TabIndex = 0
        Me.ToolStrip.Text = "ToolStrip1"
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
        'Frm_MaintenanceOneValue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(539, 322)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_MaintenanceOneValue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "[Title]"
        Me.TableLayoutPanel.ResumeLayout(False)
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Panel As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TextBoxValue As System.Windows.Forms.TextBox
    Friend WithEvents LabelTexto As System.Windows.Forms.Label
    Friend WithEvents ToolStripButtonDelete As System.Windows.Forms.ToolStripButton
End Class
