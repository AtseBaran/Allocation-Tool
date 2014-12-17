<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CI_AI_Popup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CI_AI_Popup))
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CheckBoxVHTab1 = New System.Windows.Forms.CheckBox()
        Me.TextBoxCommentTab1 = New System.Windows.Forms.TextBox()
        Me.ValueTab1 = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DTP_Actual_Date = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBoxVH = New System.Windows.Forms.GroupBox()
        Me.CheckBoxVHTab2 = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DTPVH = New System.Windows.Forms.DateTimePicker()
        Me.VHDays = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxCommentTab2 = New System.Windows.Forms.TextBox()
        Me.DTP_End_Date = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ValueTab2 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTP_Start_Date = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonHistory = New System.Windows.Forms.ToolStripButton()
        Me.TableLayoutPanel.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.ValueTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBoxVH.SuspendLayout()
        CType(Me.VHDays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValueTab2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 1
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.Controls.Add(Me.TabControl, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.ToolStrip, 0, 0)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 2
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(305, 278)
        Me.TableLayoutPanel.TabIndex = 1
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(3, 38)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(299, 237)
        Me.TabControl.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Lavender
        Me.TabPage1.Controls.Add(Me.CheckBoxVHTab1)
        Me.TabPage1.Controls.Add(Me.TextBoxCommentTab1)
        Me.TabPage1.Controls.Add(Me.ValueTab1)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.DTP_Actual_Date)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(291, 211)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Daily"
        '
        'CheckBoxVHTab1
        '
        Me.CheckBoxVHTab1.AutoSize = True
        Me.CheckBoxVHTab1.Location = New System.Drawing.Point(449, 9)
        Me.CheckBoxVHTab1.Name = "CheckBoxVHTab1"
        Me.CheckBoxVHTab1.Size = New System.Drawing.Size(119, 17)
        Me.CheckBoxVHTab1.TabIndex = 49
        Me.CheckBoxVHTab1.Text = "Vacations / Holiday"
        Me.CheckBoxVHTab1.UseVisualStyleBackColor = True
        Me.CheckBoxVHTab1.Visible = False
        '
        'TextBoxCommentTab1
        '
        Me.TextBoxCommentTab1.Location = New System.Drawing.Point(76, 58)
        Me.TextBoxCommentTab1.Multiline = True
        Me.TextBoxCommentTab1.Name = "TextBoxCommentTab1"
        Me.TextBoxCommentTab1.Size = New System.Drawing.Size(200, 108)
        Me.TextBoxCommentTab1.TabIndex = 48
        '
        'ValueTab1
        '
        Me.ValueTab1.Location = New System.Drawing.Point(76, 32)
        Me.ValueTab1.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.ValueTab1.Name = "ValueTab1"
        Me.ValueTab1.Size = New System.Drawing.Size(200, 20)
        Me.ValueTab1.TabIndex = 47
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Comment"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Value"
        '
        'DTP_Actual_Date
        '
        Me.DTP_Actual_Date.Enabled = False
        Me.DTP_Actual_Date.Location = New System.Drawing.Point(76, 6)
        Me.DTP_Actual_Date.Name = "DTP_Actual_Date"
        Me.DTP_Actual_Date.Size = New System.Drawing.Size(200, 20)
        Me.DTP_Actual_Date.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Actual Date"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Lavender
        Me.TabPage2.Controls.Add(Me.GroupBoxVH)
        Me.TabPage2.Controls.Add(Me.TextBoxCommentTab2)
        Me.TabPage2.Controls.Add(Me.DTP_End_Date)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.ValueTab2)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.DTP_Start_Date)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(291, 211)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Weekly"
        '
        'GroupBoxVH
        '
        Me.GroupBoxVH.Controls.Add(Me.CheckBoxVHTab2)
        Me.GroupBoxVH.Controls.Add(Me.Label9)
        Me.GroupBoxVH.Controls.Add(Me.DTPVH)
        Me.GroupBoxVH.Controls.Add(Me.VHDays)
        Me.GroupBoxVH.Controls.Add(Me.Label8)
        Me.GroupBoxVH.Location = New System.Drawing.Point(302, 58)
        Me.GroupBoxVH.Name = "GroupBoxVH"
        Me.GroupBoxVH.Size = New System.Drawing.Size(266, 108)
        Me.GroupBoxVH.TabIndex = 57
        Me.GroupBoxVH.TabStop = False
        Me.GroupBoxVH.Text = "Vacations / Holidays"
        Me.GroupBoxVH.Visible = False
        '
        'CheckBoxVHTab2
        '
        Me.CheckBoxVHTab2.AutoSize = True
        Me.CheckBoxVHTab2.Location = New System.Drawing.Point(6, -1)
        Me.CheckBoxVHTab2.Name = "CheckBoxVHTab2"
        Me.CheckBoxVHTab2.Size = New System.Drawing.Size(124, 17)
        Me.CheckBoxVHTab2.TabIndex = 58
        Me.CheckBoxVHTab2.Text = "Vacations / Holidays"
        Me.CheckBoxVHTab2.UseVisualStyleBackColor = True
        Me.CheckBoxVHTab2.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Start Date"
        '
        'DTPVH
        '
        Me.DTPVH.Enabled = False
        Me.DTPVH.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPVH.Location = New System.Drawing.Point(115, 70)
        Me.DTPVH.Name = "DTPVH"
        Me.DTPVH.Size = New System.Drawing.Size(145, 20)
        Me.DTPVH.TabIndex = 2
        '
        'VHDays
        '
        Me.VHDays.Enabled = False
        Me.VHDays.Location = New System.Drawing.Point(115, 31)
        Me.VHDays.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.VHDays.Name = "VHDays"
        Me.VHDays.Size = New System.Drawing.Size(145, 20)
        Me.VHDays.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Number of the days"
        '
        'TextBoxCommentTab2
        '
        Me.TextBoxCommentTab2.Location = New System.Drawing.Point(76, 84)
        Me.TextBoxCommentTab2.Multiline = True
        Me.TextBoxCommentTab2.Name = "TextBoxCommentTab2"
        Me.TextBoxCommentTab2.Size = New System.Drawing.Size(200, 108)
        Me.TextBoxCommentTab2.TabIndex = 56
        '
        'DTP_End_Date
        '
        Me.DTP_End_Date.Enabled = False
        Me.DTP_End_Date.Location = New System.Drawing.Point(76, 32)
        Me.DTP_End_Date.Name = "DTP_End_Date"
        Me.DTP_End_Date.Size = New System.Drawing.Size(200, 20)
        Me.DTP_End_Date.TabIndex = 55
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "End Date"
        '
        'ValueTab2
        '
        Me.ValueTab2.Location = New System.Drawing.Point(76, 58)
        Me.ValueTab2.Name = "ValueTab2"
        Me.ValueTab2.Size = New System.Drawing.Size(200, 20)
        Me.ValueTab2.TabIndex = 53
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Comment"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Value"
        '
        'DTP_Start_Date
        '
        Me.DTP_Start_Date.Location = New System.Drawing.Point(76, 6)
        Me.DTP_Start_Date.Name = "DTP_Start_Date"
        Me.DTP_Start_Date.Size = New System.Drawing.Size(200, 20)
        Me.DTP_Start_Date.TabIndex = 49
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Start Date"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonSave, Me.ToolStripButtonCancel, Me.ToolStripButtonHistory})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(305, 31)
        Me.ToolStrip.TabIndex = 0
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'ToolStripButtonSave
        '
        Me.ToolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSave.Image = Global.Allocation_Tool.My.Resources.Resources.disk_save
        Me.ToolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSave.Name = "ToolStripButtonSave"
        Me.ToolStripButtonSave.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonSave.Text = "Save"
        '
        'ToolStripButtonCancel
        '
        Me.ToolStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonCancel.Image = Global.Allocation_Tool.My.Resources.Resources.edit_clear
        Me.ToolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCancel.Name = "ToolStripButtonCancel"
        Me.ToolStripButtonCancel.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonCancel.Text = "Clear"
        '
        'ToolStripButtonHistory
        '
        Me.ToolStripButtonHistory.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButtonHistory.Image = CType(resources.GetObject("ToolStripButtonHistory.Image"), System.Drawing.Image)
        Me.ToolStripButtonHistory.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonHistory.Name = "ToolStripButtonHistory"
        Me.ToolStripButtonHistory.Size = New System.Drawing.Size(89, 28)
        Me.ToolStripButtonHistory.Text = "Actuals history"
        '
        'Frm_CI_AI_Popup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(305, 278)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_CI_AI_Popup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actuals Input"
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.ValueTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBoxVH.ResumeLayout(False)
        Me.GroupBoxVH.PerformLayout()
        CType(Me.VHDays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValueTab2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonHistory As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents CheckBoxVHTab1 As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxCommentTab1 As System.Windows.Forms.TextBox
    Friend WithEvents ValueTab1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DTP_Actual_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxVH As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxVHTab2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DTPVH As System.Windows.Forms.DateTimePicker
    Friend WithEvents VHDays As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxCommentTab2 As System.Windows.Forms.TextBox
    Friend WithEvents DTP_End_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ValueTab2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTP_Start_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
