<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CI_AI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CI_AI))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonAddFilter = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonRemoveFilter = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonClearAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonVacationsHolidays = New System.Windows.Forms.ToolStripButton()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTP_Start = New System.Windows.Forms.DateTimePicker()
        Me.DTP_End = New System.Windows.Forms.DateTimePicker()
        Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.ToolStrip, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1103, 400)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonRefresh, Me.ToolStripButton2, Me.ToolStripButtonAddFilter, Me.ToolStripButtonRemoveFilter, Me.ToolStripButtonClearAll, Me.ToolStripButton1, Me.ToolStripButtonSave, Me.ToolStripButtonVacationsHolidays})
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
        Me.ToolStripButton2.Visible = False
        '
        'ToolStripButtonAddFilter
        '
        Me.ToolStripButtonAddFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonAddFilter.Image = Global.Allocation_Tool.My.Resources.Resources.filter
        Me.ToolStripButtonAddFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAddFilter.Name = "ToolStripButtonAddFilter"
        Me.ToolStripButtonAddFilter.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonAddFilter.Text = "Add Filter"
        Me.ToolStripButtonAddFilter.Visible = False
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
        Me.ToolStripButtonClearAll.Visible = False
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
        'ToolStripButtonVacationsHolidays
        '
        Me.ToolStripButtonVacationsHolidays.Image = Global.Allocation_Tool.My.Resources.Resources.calendar
        Me.ToolStripButtonVacationsHolidays.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonVacationsHolidays.Name = "ToolStripButtonVacationsHolidays"
        Me.ToolStripButtonVacationsHolidays.Size = New System.Drawing.Size(143, 28)
        Me.ToolStripButtonVacationsHolidays.Text = "Vacations / Holidays"
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
        Me.DataGridView.Size = New System.Drawing.Size(1097, 324)
        Me.DataGridView.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DTP_Start, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.DTP_End, 3, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 38)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1097, 29)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(268, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Start Date"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(551, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(268, 29)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "End Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DTP_Start
        '
        Me.DTP_Start.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DTP_Start.Location = New System.Drawing.Point(277, 3)
        Me.DTP_Start.Name = "DTP_Start"
        Me.DTP_Start.Size = New System.Drawing.Size(268, 20)
        Me.DTP_Start.TabIndex = 2
        '
        'DTP_End
        '
        Me.DTP_End.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DTP_End.Location = New System.Drawing.Point(825, 3)
        Me.DTP_End.Name = "DTP_End"
        Me.DTP_End.Size = New System.Drawing.Size(269, 20)
        Me.DTP_End.TabIndex = 3
        '
        'Frm_CI_AI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(1103, 400)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_CI_AI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actuals Input"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonAddFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonRemoveFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonClearAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTP_Start As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_End As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStripButtonVacationsHolidays As System.Windows.Forms.ToolStripButton
End Class
