<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Resources_History
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Resources_History))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonFilter = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonExclude = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonClear = New System.Windows.Forms.ToolStripButton()
        Me.DataGridViewHistory = New System.Windows.Forms.DataGridView()
        Me.BindingSourceHistory = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridViewHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonRefresh, Me.ToolStripSeparator1, Me.ToolStripButtonFilter, Me.ToolStripButtonExclude, Me.ToolStripButtonClear})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(797, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripButtonFilter
        '
        Me.ToolStripButtonFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonFilter.Image = Global.Allocation_Tool.My.Resources.Resources.filter
        Me.ToolStripButtonFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonFilter.Name = "ToolStripButtonFilter"
        Me.ToolStripButtonFilter.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonFilter.Text = "Filter"
        '
        'ToolStripButtonExclude
        '
        Me.ToolStripButtonExclude.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonExclude.Image = Global.Allocation_Tool.My.Resources.Resources.block_blue
        Me.ToolStripButtonExclude.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonExclude.Name = "ToolStripButtonExclude"
        Me.ToolStripButtonExclude.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonExclude.Text = "Exclude"
        Me.ToolStripButtonExclude.Visible = False
        '
        'ToolStripButtonClear
        '
        Me.ToolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonClear.Image = Global.Allocation_Tool.My.Resources.Resources.filter_remove
        Me.ToolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonClear.Name = "ToolStripButtonClear"
        Me.ToolStripButtonClear.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonClear.Text = "Clear"
        '
        'DataGridViewHistory
        '
        Me.DataGridViewHistory.AllowUserToAddRows = False
        Me.DataGridViewHistory.AllowUserToDeleteRows = False
        Me.DataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewHistory.Location = New System.Drawing.Point(0, 31)
        Me.DataGridViewHistory.Name = "DataGridViewHistory"
        Me.DataGridViewHistory.ReadOnly = True
        Me.DataGridViewHistory.Size = New System.Drawing.Size(797, 279)
        Me.DataGridViewHistory.TabIndex = 1
        '
        'Frm_Resources_History
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(797, 310)
        Me.Controls.Add(Me.DataGridViewHistory)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Resources_History"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Resources History"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridViewHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonExclude As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridViewHistory As System.Windows.Forms.DataGridView
    Friend WithEvents BindingSourceHistory As System.Windows.Forms.BindingSource
End Class
