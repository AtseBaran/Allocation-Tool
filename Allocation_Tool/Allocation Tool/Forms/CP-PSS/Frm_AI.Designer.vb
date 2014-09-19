<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_AI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_AI))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonAddFilter = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonRemoveFilter = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonClearAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridViewActuals = New System.Windows.Forms.DataGridView()
        Me.BindingSourceActuals = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStrip.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridViewActuals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceActuals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonRefresh, Me.ToolStripButton2, Me.ToolStripButtonAddFilter, Me.ToolStripButtonRemoveFilter, Me.ToolStripButtonClearAll, Me.ToolStripButton1, Me.ToolStripButtonSave})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1103, 31)
        Me.ToolStrip.TabIndex = 0
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'ToolStripButtonRefresh
        '
        Me.ToolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonRefresh.Image = Global.Allocation_Tool.My.Resources.Resources.refresh
        Me.ToolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonRefresh.Name = "ToolStripButtonRefresh"
        Me.ToolStripButtonRefresh.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonRefresh.Text = "Refresh"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripButtonAddFilter
        '
        Me.ToolStripButtonAddFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonAddFilter.Image = Global.Allocation_Tool.My.Resources.Resources.filter
        Me.ToolStripButtonAddFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAddFilter.Name = "ToolStripButtonAddFilter"
        Me.ToolStripButtonAddFilter.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonAddFilter.Text = "Add Filter"
        '
        'ToolStripButtonRemoveFilter
        '
        Me.ToolStripButtonRemoveFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonRemoveFilter.Image = Global.Allocation_Tool.My.Resources.Resources.block_blue
        Me.ToolStripButtonRemoveFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonRemoveFilter.Name = "ToolStripButtonRemoveFilter"
        Me.ToolStripButtonRemoveFilter.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonRemoveFilter.Text = "Remove Filter"
        Me.ToolStripButtonRemoveFilter.Visible = False
        '
        'ToolStripButtonClearAll
        '
        Me.ToolStripButtonClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonClearAll.Image = Global.Allocation_Tool.My.Resources.Resources.edit_clear
        Me.ToolStripButtonClearAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonClearAll.Name = "ToolStripButtonClearAll"
        Me.ToolStripButtonClearAll.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonClearAll.Text = "Clear All Filter"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(6, 31)
        Me.ToolStripButton1.Visible = False
        '
        'ToolStripButtonSave
        '
        Me.ToolStripButtonSave.Image = Global.Allocation_Tool.My.Resources.Resources.disk_save
        Me.ToolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSave.Name = "ToolStripButtonSave"
        Me.ToolStripButtonSave.Size = New System.Drawing.Size(59, 28)
        Me.ToolStripButtonSave.Text = "Save"
        Me.ToolStripButtonSave.Visible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.ToolStrip, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridViewActuals, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1103, 400)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'DataGridViewActuals
        '
        Me.DataGridViewActuals.AllowUserToAddRows = False
        Me.DataGridViewActuals.AllowUserToDeleteRows = False
        Me.DataGridViewActuals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewActuals.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewActuals.Location = New System.Drawing.Point(3, 38)
        Me.DataGridViewActuals.Name = "DataGridViewActuals"
        Me.DataGridViewActuals.ReadOnly = True
        Me.DataGridViewActuals.Size = New System.Drawing.Size(1097, 359)
        Me.DataGridViewActuals.TabIndex = 1
        '
        'Frm_CP_AI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1103, 400)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_CP_AI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Actuals Input"
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.DataGridViewActuals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceActuals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonAddFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonRemoveFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonClearAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewActuals As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingSourceActuals As System.Windows.Forms.BindingSource
End Class
