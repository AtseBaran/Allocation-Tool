<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CI_Resources
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CI_Resources))
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCancel = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanelPreview = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonRemove = New System.Windows.Forms.Button()
        Me.DataGridViewSelected = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBoxNewEntry = New System.Windows.Forms.GroupBox()
        Me.CheckBoxEndDate = New System.Windows.Forms.CheckBox()
        Me.TabControlRecipe = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxDaily = New System.Windows.Forms.TextBox()
        Me.RadioButtonDailyWeekday = New System.Windows.Forms.RadioButton()
        Me.RadioButtonDailyEvery = New System.Windows.Forms.RadioButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CheckBoxWeeklySaturday = New System.Windows.Forms.CheckBox()
        Me.CheckBoxWeeklyFriday = New System.Windows.Forms.CheckBox()
        Me.CheckBoxWeeklyThursday = New System.Windows.Forms.CheckBox()
        Me.CheckBoxWeeklyWednesday = New System.Windows.Forms.CheckBox()
        Me.CheckBoxWeeklyTuesday = New System.Windows.Forms.CheckBox()
        Me.CheckBoxWeeklyMonday = New System.Windows.Forms.CheckBox()
        Me.CheckBoxWeeklySunday = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxWeeklyRecur = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBoxMonthlyNum = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxMonthlyOption = New System.Windows.Forms.ComboBox()
        Me.ComboBoxMonthlyOrd = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxMonthlyNumMonths = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxMonthlyNumDay = New System.Windows.Forms.TextBox()
        Me.RadioButtonMonthly = New System.Windows.Forms.RadioButton()
        Me.RadioButtonMonthlyDay = New System.Windows.Forms.RadioButton()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.ComboBoxYearlyMonths = New System.Windows.Forms.ComboBox()
        Me.ComboBoxYearlyDay = New System.Windows.Forms.ComboBox()
        Me.ComboBoxYearlyOrd = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBoxYearlyDate = New System.Windows.Forms.TextBox()
        Me.ComboBoxYearlyMonth = New System.Windows.Forms.ComboBox()
        Me.RadioButtonYearlyOnThe = New System.Windows.Forms.RadioButton()
        Me.RadioButtonYearlyOn = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBoxYearlyYears = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBoxMonthlyValue = New System.Windows.Forms.TextBox()
        Me.DTP_End = New System.Windows.Forms.DateTimePicker()
        Me.DTP_Start = New System.Windows.Forms.DateTimePicker()
        Me.LabelStartDate = New System.Windows.Forms.Label()
        Me.LabelMonthlyValue = New System.Windows.Forms.Label()
        Me.ComboBoxEntryType = New System.Windows.Forms.ComboBox()
        Me.ComboBoxTaskName = New System.Windows.Forms.ComboBox()
        Me.ComboBoxTaskType = New System.Windows.Forms.ComboBox()
        Me.LabelEntryType = New System.Windows.Forms.Label()
        Me.LabelTaskName = New System.Windows.Forms.Label()
        Me.LabelTaskType = New System.Windows.Forms.Label()
        Me.GroupBoxAssign = New System.Windows.Forms.GroupBox()
        Me.ButtonAdd = New System.Windows.Forms.Button()
        Me.GroupBoxServiceLine = New System.Windows.Forms.GroupBox()
        Me.CheckedListBoxServiceLine = New System.Windows.Forms.CheckedListBox()
        Me.GroupBoxOwnerList = New System.Windows.Forms.GroupBox()
        Me.CheckedListBoxOwner = New System.Windows.Forms.CheckedListBox()
        Me.TableLayoutPanel.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanelPreview.SuspendLayout()
        CType(Me.DataGridViewSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBoxNewEntry.SuspendLayout()
        Me.TabControlRecipe.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBoxAssign.SuspendLayout()
        Me.GroupBoxServiceLine.SuspendLayout()
        Me.GroupBoxOwnerList.SuspendLayout()
        Me.SuspendLayout()
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
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(923, 440)
        Me.TableLayoutPanel.TabIndex = 21
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
        Me.ToolStrip.Text = "ToolStrip"
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanelPreview)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 248)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(10)
        Me.GroupBox1.Size = New System.Drawing.Size(917, 189)
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
        Me.TableLayoutPanelPreview.Size = New System.Drawing.Size(897, 156)
        Me.TableLayoutPanelPreview.TabIndex = 1
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
        Me.DataGridViewSelected.Size = New System.Drawing.Size(891, 115)
        Me.DataGridViewSelected.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.23337!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.76663!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBoxNewEntry, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBoxAssign, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 38)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(917, 204)
        Me.TableLayoutPanel2.TabIndex = 20
        '
        'GroupBoxNewEntry
        '
        Me.GroupBoxNewEntry.Controls.Add(Me.CheckBoxEndDate)
        Me.GroupBoxNewEntry.Controls.Add(Me.TabControlRecipe)
        Me.GroupBoxNewEntry.Controls.Add(Me.TextBoxMonthlyValue)
        Me.GroupBoxNewEntry.Controls.Add(Me.DTP_End)
        Me.GroupBoxNewEntry.Controls.Add(Me.DTP_Start)
        Me.GroupBoxNewEntry.Controls.Add(Me.LabelStartDate)
        Me.GroupBoxNewEntry.Controls.Add(Me.LabelMonthlyValue)
        Me.GroupBoxNewEntry.Controls.Add(Me.ComboBoxEntryType)
        Me.GroupBoxNewEntry.Controls.Add(Me.ComboBoxTaskName)
        Me.GroupBoxNewEntry.Controls.Add(Me.ComboBoxTaskType)
        Me.GroupBoxNewEntry.Controls.Add(Me.LabelEntryType)
        Me.GroupBoxNewEntry.Controls.Add(Me.LabelTaskName)
        Me.GroupBoxNewEntry.Controls.Add(Me.LabelTaskType)
        Me.GroupBoxNewEntry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxNewEntry.Location = New System.Drawing.Point(3, 3)
        Me.GroupBoxNewEntry.Name = "GroupBoxNewEntry"
        Me.GroupBoxNewEntry.Padding = New System.Windows.Forms.Padding(10)
        Me.GroupBoxNewEntry.Size = New System.Drawing.Size(528, 198)
        Me.GroupBoxNewEntry.TabIndex = 0
        Me.GroupBoxNewEntry.TabStop = False
        Me.GroupBoxNewEntry.Text = "New Entry"
        '
        'CheckBoxEndDate
        '
        Me.CheckBoxEndDate.AutoSize = True
        Me.CheckBoxEndDate.Checked = True
        Me.CheckBoxEndDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxEndDate.Location = New System.Drawing.Point(354, 19)
        Me.CheckBoxEndDate.Name = "CheckBoxEndDate"
        Me.CheckBoxEndDate.Size = New System.Drawing.Size(71, 17)
        Me.CheckBoxEndDate.TabIndex = 11
        Me.CheckBoxEndDate.Text = "End Date"
        Me.CheckBoxEndDate.UseVisualStyleBackColor = True
        '
        'TabControlRecipe
        '
        Me.TabControlRecipe.Controls.Add(Me.TabPage1)
        Me.TabControlRecipe.Controls.Add(Me.TabPage2)
        Me.TabControlRecipe.Controls.Add(Me.TabPage3)
        Me.TabControlRecipe.Controls.Add(Me.TabPage4)
        Me.TabControlRecipe.Location = New System.Drawing.Point(204, 43)
        Me.TabControlRecipe.Name = "TabControlRecipe"
        Me.TabControlRecipe.SelectedIndex = 0
        Me.TabControlRecipe.Size = New System.Drawing.Size(323, 147)
        Me.TabControlRecipe.TabIndex = 10
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Lavender
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.TextBoxDaily)
        Me.TabPage1.Controls.Add(Me.RadioButtonDailyWeekday)
        Me.TabPage1.Controls.Add(Me.RadioButtonDailyEvery)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(315, 121)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Daily"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(110, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "day(s)"
        '
        'TextBoxDaily
        '
        Me.TextBoxDaily.Location = New System.Drawing.Point(64, 14)
        Me.TextBoxDaily.Name = "TextBoxDaily"
        Me.TextBoxDaily.Size = New System.Drawing.Size(40, 20)
        Me.TextBoxDaily.TabIndex = 2
        Me.TextBoxDaily.Text = "1"
        Me.TextBoxDaily.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RadioButtonDailyWeekday
        '
        Me.RadioButtonDailyWeekday.AutoSize = True
        Me.RadioButtonDailyWeekday.Location = New System.Drawing.Point(6, 45)
        Me.RadioButtonDailyWeekday.Name = "RadioButtonDailyWeekday"
        Me.RadioButtonDailyWeekday.Size = New System.Drawing.Size(98, 17)
        Me.RadioButtonDailyWeekday.TabIndex = 1
        Me.RadioButtonDailyWeekday.Text = "Every weekday"
        Me.RadioButtonDailyWeekday.UseVisualStyleBackColor = True
        '
        'RadioButtonDailyEvery
        '
        Me.RadioButtonDailyEvery.AutoSize = True
        Me.RadioButtonDailyEvery.Checked = True
        Me.RadioButtonDailyEvery.Location = New System.Drawing.Point(6, 15)
        Me.RadioButtonDailyEvery.Name = "RadioButtonDailyEvery"
        Me.RadioButtonDailyEvery.Size = New System.Drawing.Size(52, 17)
        Me.RadioButtonDailyEvery.TabIndex = 0
        Me.RadioButtonDailyEvery.TabStop = True
        Me.RadioButtonDailyEvery.Text = "Every"
        Me.RadioButtonDailyEvery.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Lavender
        Me.TabPage2.Controls.Add(Me.CheckBoxWeeklySaturday)
        Me.TabPage2.Controls.Add(Me.CheckBoxWeeklyFriday)
        Me.TabPage2.Controls.Add(Me.CheckBoxWeeklyThursday)
        Me.TabPage2.Controls.Add(Me.CheckBoxWeeklyWednesday)
        Me.TabPage2.Controls.Add(Me.CheckBoxWeeklyTuesday)
        Me.TabPage2.Controls.Add(Me.CheckBoxWeeklyMonday)
        Me.TabPage2.Controls.Add(Me.CheckBoxWeeklySunday)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.TextBoxWeeklyRecur)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(315, 121)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Weekly"
        '
        'CheckBoxWeeklySaturday
        '
        Me.CheckBoxWeeklySaturday.AutoSize = True
        Me.CheckBoxWeeklySaturday.Location = New System.Drawing.Point(150, 70)
        Me.CheckBoxWeeklySaturday.Name = "CheckBoxWeeklySaturday"
        Me.CheckBoxWeeklySaturday.Size = New System.Drawing.Size(68, 17)
        Me.CheckBoxWeeklySaturday.TabIndex = 9
        Me.CheckBoxWeeklySaturday.Text = "Saturday"
        Me.CheckBoxWeeklySaturday.UseVisualStyleBackColor = True
        '
        'CheckBoxWeeklyFriday
        '
        Me.CheckBoxWeeklyFriday.AutoSize = True
        Me.CheckBoxWeeklyFriday.Location = New System.Drawing.Point(80, 70)
        Me.CheckBoxWeeklyFriday.Name = "CheckBoxWeeklyFriday"
        Me.CheckBoxWeeklyFriday.Size = New System.Drawing.Size(54, 17)
        Me.CheckBoxWeeklyFriday.TabIndex = 8
        Me.CheckBoxWeeklyFriday.Text = "Friday"
        Me.CheckBoxWeeklyFriday.UseVisualStyleBackColor = True
        '
        'CheckBoxWeeklyThursday
        '
        Me.CheckBoxWeeklyThursday.AutoSize = True
        Me.CheckBoxWeeklyThursday.Location = New System.Drawing.Point(9, 70)
        Me.CheckBoxWeeklyThursday.Name = "CheckBoxWeeklyThursday"
        Me.CheckBoxWeeklyThursday.Size = New System.Drawing.Size(70, 17)
        Me.CheckBoxWeeklyThursday.TabIndex = 7
        Me.CheckBoxWeeklyThursday.Text = "Thursday"
        Me.CheckBoxWeeklyThursday.UseVisualStyleBackColor = True
        '
        'CheckBoxWeeklyWednesday
        '
        Me.CheckBoxWeeklyWednesday.AutoSize = True
        Me.CheckBoxWeeklyWednesday.Location = New System.Drawing.Point(223, 43)
        Me.CheckBoxWeeklyWednesday.Name = "CheckBoxWeeklyWednesday"
        Me.CheckBoxWeeklyWednesday.Size = New System.Drawing.Size(83, 17)
        Me.CheckBoxWeeklyWednesday.TabIndex = 6
        Me.CheckBoxWeeklyWednesday.Text = "Wednesday"
        Me.CheckBoxWeeklyWednesday.UseVisualStyleBackColor = True
        '
        'CheckBoxWeeklyTuesday
        '
        Me.CheckBoxWeeklyTuesday.AutoSize = True
        Me.CheckBoxWeeklyTuesday.Location = New System.Drawing.Point(150, 43)
        Me.CheckBoxWeeklyTuesday.Name = "CheckBoxWeeklyTuesday"
        Me.CheckBoxWeeklyTuesday.Size = New System.Drawing.Size(67, 17)
        Me.CheckBoxWeeklyTuesday.TabIndex = 5
        Me.CheckBoxWeeklyTuesday.Text = "Tuesday"
        Me.CheckBoxWeeklyTuesday.UseVisualStyleBackColor = True
        '
        'CheckBoxWeeklyMonday
        '
        Me.CheckBoxWeeklyMonday.AutoSize = True
        Me.CheckBoxWeeklyMonday.Location = New System.Drawing.Point(80, 43)
        Me.CheckBoxWeeklyMonday.Name = "CheckBoxWeeklyMonday"
        Me.CheckBoxWeeklyMonday.Size = New System.Drawing.Size(64, 17)
        Me.CheckBoxWeeklyMonday.TabIndex = 4
        Me.CheckBoxWeeklyMonday.Text = "Monday"
        Me.CheckBoxWeeklyMonday.UseVisualStyleBackColor = True
        '
        'CheckBoxWeeklySunday
        '
        Me.CheckBoxWeeklySunday.AutoSize = True
        Me.CheckBoxWeeklySunday.Location = New System.Drawing.Point(9, 43)
        Me.CheckBoxWeeklySunday.Name = "CheckBoxWeeklySunday"
        Me.CheckBoxWeeklySunday.Size = New System.Drawing.Size(62, 17)
        Me.CheckBoxWeeklySunday.TabIndex = 3
        Me.CheckBoxWeeklySunday.Text = "Sunday"
        Me.CheckBoxWeeklySunday.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(127, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "week(s) on:"
        '
        'TextBoxWeeklyRecur
        '
        Me.TextBoxWeeklyRecur.Location = New System.Drawing.Point(77, 15)
        Me.TextBoxWeeklyRecur.Name = "TextBoxWeeklyRecur"
        Me.TextBoxWeeklyRecur.Size = New System.Drawing.Size(44, 20)
        Me.TextBoxWeeklyRecur.TabIndex = 1
        Me.TextBoxWeeklyRecur.Text = "1"
        Me.TextBoxWeeklyRecur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Recur every"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Lavender
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.TextBoxMonthlyNum)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.ComboBoxMonthlyOption)
        Me.TabPage3.Controls.Add(Me.ComboBoxMonthlyOrd)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.TextBoxMonthlyNumMonths)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.TextBoxMonthlyNumDay)
        Me.TabPage3.Controls.Add(Me.RadioButtonMonthly)
        Me.TabPage3.Controls.Add(Me.RadioButtonMonthlyDay)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(315, 121)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Monthly"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(257, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "month(s)"
        '
        'TextBoxMonthlyNum
        '
        Me.TextBoxMonthlyNum.Location = New System.Drawing.Point(223, 44)
        Me.TextBoxMonthlyNum.Name = "TextBoxMonthlyNum"
        Me.TextBoxMonthlyNum.Size = New System.Drawing.Size(28, 20)
        Me.TextBoxMonthlyNum.TabIndex = 9
        Me.TextBoxMonthlyNum.Text = "1"
        Me.TextBoxMonthlyNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(172, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "of every"
        '
        'ComboBoxMonthlyOption
        '
        Me.ComboBoxMonthlyOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxMonthlyOption.DropDownWidth = 150
        Me.ComboBoxMonthlyOption.FormattingEnabled = True
        Me.ComboBoxMonthlyOption.Items.AddRange(New Object() {"day", "weekday", "weekend day", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"})
        Me.ComboBoxMonthlyOption.Location = New System.Drawing.Point(112, 44)
        Me.ComboBoxMonthlyOption.Name = "ComboBoxMonthlyOption"
        Me.ComboBoxMonthlyOption.Size = New System.Drawing.Size(54, 21)
        Me.ComboBoxMonthlyOption.TabIndex = 7
        '
        'ComboBoxMonthlyOrd
        '
        Me.ComboBoxMonthlyOrd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxMonthlyOrd.DropDownWidth = 150
        Me.ComboBoxMonthlyOrd.FormattingEnabled = True
        Me.ComboBoxMonthlyOrd.Items.AddRange(New Object() {"first", "second", "third", "fourth", "last"})
        Me.ComboBoxMonthlyOrd.Location = New System.Drawing.Point(53, 44)
        Me.ComboBoxMonthlyOrd.Name = "ComboBoxMonthlyOrd"
        Me.ComboBoxMonthlyOrd.Size = New System.Drawing.Size(53, 21)
        Me.ComboBoxMonthlyOrd.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(196, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "month(s)"
        '
        'TextBoxMonthlyNumMonths
        '
        Me.TextBoxMonthlyNumMonths.Location = New System.Drawing.Point(150, 12)
        Me.TextBoxMonthlyNumMonths.Name = "TextBoxMonthlyNumMonths"
        Me.TextBoxMonthlyNumMonths.Size = New System.Drawing.Size(40, 20)
        Me.TextBoxMonthlyNumMonths.TabIndex = 4
        Me.TextBoxMonthlyNumMonths.Text = "1"
        Me.TextBoxMonthlyNumMonths.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(99, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "of every"
        '
        'TextBoxMonthlyNumDay
        '
        Me.TextBoxMonthlyNumDay.Location = New System.Drawing.Point(53, 12)
        Me.TextBoxMonthlyNumDay.Name = "TextBoxMonthlyNumDay"
        Me.TextBoxMonthlyNumDay.Size = New System.Drawing.Size(40, 20)
        Me.TextBoxMonthlyNumDay.TabIndex = 2
        Me.TextBoxMonthlyNumDay.Text = "1"
        Me.TextBoxMonthlyNumDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RadioButtonMonthly
        '
        Me.RadioButtonMonthly.AutoSize = True
        Me.RadioButtonMonthly.Location = New System.Drawing.Point(3, 45)
        Me.RadioButtonMonthly.Name = "RadioButtonMonthly"
        Me.RadioButtonMonthly.Size = New System.Drawing.Size(44, 17)
        Me.RadioButtonMonthly.TabIndex = 1
        Me.RadioButtonMonthly.Text = "The"
        Me.RadioButtonMonthly.UseVisualStyleBackColor = True
        '
        'RadioButtonMonthlyDay
        '
        Me.RadioButtonMonthlyDay.AutoSize = True
        Me.RadioButtonMonthlyDay.Checked = True
        Me.RadioButtonMonthlyDay.Location = New System.Drawing.Point(3, 13)
        Me.RadioButtonMonthlyDay.Name = "RadioButtonMonthlyDay"
        Me.RadioButtonMonthlyDay.Size = New System.Drawing.Size(44, 17)
        Me.RadioButtonMonthlyDay.TabIndex = 0
        Me.RadioButtonMonthlyDay.TabStop = True
        Me.RadioButtonMonthlyDay.Text = "Day"
        Me.RadioButtonMonthlyDay.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Lavender
        Me.TabPage4.Controls.Add(Me.ComboBoxYearlyMonths)
        Me.TabPage4.Controls.Add(Me.ComboBoxYearlyDay)
        Me.TabPage4.Controls.Add(Me.ComboBoxYearlyOrd)
        Me.TabPage4.Controls.Add(Me.Label10)
        Me.TabPage4.Controls.Add(Me.TextBoxYearlyDate)
        Me.TabPage4.Controls.Add(Me.ComboBoxYearlyMonth)
        Me.TabPage4.Controls.Add(Me.RadioButtonYearlyOnThe)
        Me.TabPage4.Controls.Add(Me.RadioButtonYearlyOn)
        Me.TabPage4.Controls.Add(Me.Label8)
        Me.TabPage4.Controls.Add(Me.TextBoxYearlyYears)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(315, 121)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Yearly"
        '
        'ComboBoxYearlyMonths
        '
        Me.ComboBoxYearlyMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxYearlyMonths.DropDownWidth = 150
        Me.ComboBoxYearlyMonths.FormattingEnabled = True
        Me.ComboBoxYearlyMonths.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.ComboBoxYearlyMonths.Location = New System.Drawing.Point(231, 68)
        Me.ComboBoxYearlyMonths.Name = "ComboBoxYearlyMonths"
        Me.ComboBoxYearlyMonths.Size = New System.Drawing.Size(79, 21)
        Me.ComboBoxYearlyMonths.TabIndex = 13
        '
        'ComboBoxYearlyDay
        '
        Me.ComboBoxYearlyDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxYearlyDay.DropDownWidth = 150
        Me.ComboBoxYearlyDay.FormattingEnabled = True
        Me.ComboBoxYearlyDay.Items.AddRange(New Object() {"day", "weekday", "weekend day", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"})
        Me.ComboBoxYearlyDay.Location = New System.Drawing.Point(143, 68)
        Me.ComboBoxYearlyDay.Name = "ComboBoxYearlyDay"
        Me.ComboBoxYearlyDay.Size = New System.Drawing.Size(62, 21)
        Me.ComboBoxYearlyDay.TabIndex = 12
        '
        'ComboBoxYearlyOrd
        '
        Me.ComboBoxYearlyOrd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxYearlyOrd.DropDownWidth = 150
        Me.ComboBoxYearlyOrd.FormattingEnabled = True
        Me.ComboBoxYearlyOrd.Items.AddRange(New Object() {"first", "second", "third", "fourth", "last"})
        Me.ComboBoxYearlyOrd.Location = New System.Drawing.Point(65, 68)
        Me.ComboBoxYearlyOrd.Name = "ComboBoxYearlyOrd"
        Me.ComboBoxYearlyOrd.Size = New System.Drawing.Size(72, 21)
        Me.ComboBoxYearlyOrd.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(211, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(16, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "of"
        '
        'TextBoxYearlyDate
        '
        Me.TextBoxYearlyDate.Location = New System.Drawing.Point(127, 41)
        Me.TextBoxYearlyDate.Name = "TextBoxYearlyDate"
        Me.TextBoxYearlyDate.Size = New System.Drawing.Size(44, 20)
        Me.TextBoxYearlyDate.TabIndex = 9
        Me.TextBoxYearlyDate.Text = "1"
        Me.TextBoxYearlyDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ComboBoxYearlyMonth
        '
        Me.ComboBoxYearlyMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxYearlyMonth.DropDownWidth = 150
        Me.ComboBoxYearlyMonth.FormattingEnabled = True
        Me.ComboBoxYearlyMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.ComboBoxYearlyMonth.Location = New System.Drawing.Point(51, 41)
        Me.ComboBoxYearlyMonth.Name = "ComboBoxYearlyMonth"
        Me.ComboBoxYearlyMonth.Size = New System.Drawing.Size(67, 21)
        Me.ComboBoxYearlyMonth.TabIndex = 8
        '
        'RadioButtonYearlyOnThe
        '
        Me.RadioButtonYearlyOnThe.AutoSize = True
        Me.RadioButtonYearlyOnThe.Location = New System.Drawing.Point(3, 70)
        Me.RadioButtonYearlyOnThe.Name = "RadioButtonYearlyOnThe"
        Me.RadioButtonYearlyOnThe.Size = New System.Drawing.Size(57, 17)
        Me.RadioButtonYearlyOnThe.TabIndex = 7
        Me.RadioButtonYearlyOnThe.Text = "On the"
        Me.RadioButtonYearlyOnThe.UseVisualStyleBackColor = True
        '
        'RadioButtonYearlyOn
        '
        Me.RadioButtonYearlyOn.AutoSize = True
        Me.RadioButtonYearlyOn.Checked = True
        Me.RadioButtonYearlyOn.Location = New System.Drawing.Point(3, 42)
        Me.RadioButtonYearlyOn.Name = "RadioButtonYearlyOn"
        Me.RadioButtonYearlyOn.Size = New System.Drawing.Size(39, 17)
        Me.RadioButtonYearlyOn.TabIndex = 6
        Me.RadioButtonYearlyOn.TabStop = True
        Me.RadioButtonYearlyOn.Text = "On"
        Me.RadioButtonYearlyOn.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(124, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "years:"
        '
        'TextBoxYearlyYears
        '
        Me.TextBoxYearlyYears.Location = New System.Drawing.Point(74, 15)
        Me.TextBoxYearlyYears.Name = "TextBoxYearlyYears"
        Me.TextBoxYearlyYears.Size = New System.Drawing.Size(44, 20)
        Me.TextBoxYearlyYears.TabIndex = 4
        Me.TextBoxYearlyYears.Text = "1"
        Me.TextBoxYearlyYears.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Recur every"
        '
        'TextBoxMonthlyValue
        '
        Me.TextBoxMonthlyValue.Location = New System.Drawing.Point(77, 101)
        Me.TextBoxMonthlyValue.Name = "TextBoxMonthlyValue"
        Me.TextBoxMonthlyValue.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxMonthlyValue.TabIndex = 4
        '
        'DTP_End
        '
        Me.DTP_End.CustomFormat = "MMMM yyyy"
        Me.DTP_End.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_End.Location = New System.Drawing.Point(422, 17)
        Me.DTP_End.Name = "DTP_End"
        Me.DTP_End.Size = New System.Drawing.Size(96, 20)
        Me.DTP_End.TabIndex = 6
        '
        'DTP_Start
        '
        Me.DTP_Start.CustomFormat = "MMMM yyyy"
        Me.DTP_Start.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Start.Location = New System.Drawing.Point(261, 17)
        Me.DTP_Start.Name = "DTP_Start"
        Me.DTP_Start.Size = New System.Drawing.Size(84, 20)
        Me.DTP_Start.TabIndex = 5
        '
        'LabelStartDate
        '
        Me.LabelStartDate.AutoSize = True
        Me.LabelStartDate.Location = New System.Drawing.Point(208, 20)
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
        Me.LabelMonthlyValue.Size = New System.Drawing.Size(34, 13)
        Me.LabelMonthlyValue.TabIndex = 6
        Me.LabelMonthlyValue.Text = "Value"
        '
        'ComboBoxEntryType
        '
        Me.ComboBoxEntryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEntryType.FormattingEnabled = True
        Me.ComboBoxEntryType.Location = New System.Drawing.Point(77, 74)
        Me.ComboBoxEntryType.Name = "ComboBoxEntryType"
        Me.ComboBoxEntryType.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxEntryType.TabIndex = 3
        '
        'ComboBoxTaskName
        '
        Me.ComboBoxTaskName.FormattingEnabled = True
        Me.ComboBoxTaskName.Location = New System.Drawing.Point(77, 47)
        Me.ComboBoxTaskName.Name = "ComboBoxTaskName"
        Me.ComboBoxTaskName.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxTaskName.TabIndex = 2
        '
        'ComboBoxTaskType
        '
        Me.ComboBoxTaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTaskType.FormattingEnabled = True
        Me.ComboBoxTaskType.Location = New System.Drawing.Point(77, 20)
        Me.ComboBoxTaskType.Name = "ComboBoxTaskType"
        Me.ComboBoxTaskType.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxTaskType.TabIndex = 1
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
        'LabelTaskName
        '
        Me.LabelTaskName.AutoSize = True
        Me.LabelTaskName.Location = New System.Drawing.Point(12, 50)
        Me.LabelTaskName.Name = "LabelTaskName"
        Me.LabelTaskName.Size = New System.Drawing.Size(62, 13)
        Me.LabelTaskName.TabIndex = 1
        Me.LabelTaskName.Text = "Task Name"
        '
        'LabelTaskType
        '
        Me.LabelTaskType.AutoSize = True
        Me.LabelTaskType.Location = New System.Drawing.Point(12, 23)
        Me.LabelTaskType.Name = "LabelTaskType"
        Me.LabelTaskType.Size = New System.Drawing.Size(58, 13)
        Me.LabelTaskType.TabIndex = 0
        Me.LabelTaskType.Text = "Task Type"
        '
        'GroupBoxAssign
        '
        Me.GroupBoxAssign.Controls.Add(Me.ButtonAdd)
        Me.GroupBoxAssign.Controls.Add(Me.GroupBoxServiceLine)
        Me.GroupBoxAssign.Controls.Add(Me.GroupBoxOwnerList)
        Me.GroupBoxAssign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxAssign.Location = New System.Drawing.Point(537, 3)
        Me.GroupBoxAssign.Name = "GroupBoxAssign"
        Me.GroupBoxAssign.Size = New System.Drawing.Size(377, 198)
        Me.GroupBoxAssign.TabIndex = 1
        Me.GroupBoxAssign.TabStop = False
        Me.GroupBoxAssign.Text = "Assign Entry"
        '
        'ButtonAdd
        '
        Me.ButtonAdd.Image = Global.Allocation_Tool.My.Resources.Resources.forward
        Me.ButtonAdd.Location = New System.Drawing.Point(308, 74)
        Me.ButtonAdd.Name = "ButtonAdd"
        Me.ButtonAdd.Size = New System.Drawing.Size(64, 63)
        Me.ButtonAdd.TabIndex = 10
        Me.ButtonAdd.Text = "Add Resource"
        Me.ButtonAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonAdd.UseVisualStyleBackColor = True
        '
        'GroupBoxServiceLine
        '
        Me.GroupBoxServiceLine.Controls.Add(Me.CheckedListBoxServiceLine)
        Me.GroupBoxServiceLine.Location = New System.Drawing.Point(157, 19)
        Me.GroupBoxServiceLine.Name = "GroupBoxServiceLine"
        Me.GroupBoxServiceLine.Size = New System.Drawing.Size(145, 165)
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
        Me.CheckedListBoxServiceLine.Size = New System.Drawing.Size(139, 146)
        Me.CheckedListBoxServiceLine.TabIndex = 9
        '
        'GroupBoxOwnerList
        '
        Me.GroupBoxOwnerList.Controls.Add(Me.CheckedListBoxOwner)
        Me.GroupBoxOwnerList.Location = New System.Drawing.Point(6, 19)
        Me.GroupBoxOwnerList.Name = "GroupBoxOwnerList"
        Me.GroupBoxOwnerList.Size = New System.Drawing.Size(145, 165)
        Me.GroupBoxOwnerList.TabIndex = 16
        Me.GroupBoxOwnerList.TabStop = False
        Me.GroupBoxOwnerList.Text = "Owner List"
        '
        'CheckedListBoxOwner
        '
        Me.CheckedListBoxOwner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxOwner.FormattingEnabled = True
        Me.CheckedListBoxOwner.Location = New System.Drawing.Point(3, 16)
        Me.CheckedListBoxOwner.Name = "CheckedListBoxOwner"
        Me.CheckedListBoxOwner.Size = New System.Drawing.Size(139, 146)
        Me.CheckedListBoxOwner.TabIndex = 8
        '
        'Frm_CI_Resources
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(923, 440)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_CI_Resources"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Resources"
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanelPreview.ResumeLayout(False)
        CType(Me.DataGridViewSelected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupBoxNewEntry.ResumeLayout(False)
        Me.GroupBoxNewEntry.PerformLayout()
        Me.TabControlRecipe.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBoxAssign.ResumeLayout(False)
        Me.GroupBoxServiceLine.ResumeLayout(False)
        Me.GroupBoxOwnerList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanelPreview As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonRemove As System.Windows.Forms.Button
    Friend WithEvents DataGridViewSelected As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBoxNewEntry As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxMonthlyValue As System.Windows.Forms.TextBox
    Friend WithEvents DTP_End As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_Start As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelStartDate As System.Windows.Forms.Label
    Friend WithEvents LabelMonthlyValue As System.Windows.Forms.Label
    Friend WithEvents ComboBoxEntryType As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxTaskName As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxTaskType As System.Windows.Forms.ComboBox
    Friend WithEvents LabelEntryType As System.Windows.Forms.Label
    Friend WithEvents LabelTaskName As System.Windows.Forms.Label
    Friend WithEvents LabelTaskType As System.Windows.Forms.Label
    Friend WithEvents GroupBoxAssign As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBoxServiceLine As System.Windows.Forms.GroupBox
    Friend WithEvents CheckedListBoxServiceLine As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBoxOwnerList As System.Windows.Forms.GroupBox
    Friend WithEvents CheckedListBoxOwner As System.Windows.Forms.CheckedListBox
    Friend WithEvents TabControlRecipe As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxDaily As System.Windows.Forms.TextBox
    Friend WithEvents RadioButtonDailyWeekday As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonDailyEvery As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBoxWeeklySaturday As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxWeeklyFriday As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxWeeklyThursday As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxWeeklyWednesday As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxWeeklyTuesday As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxWeeklyMonday As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxWeeklySunday As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxWeeklyRecur As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxMonthlyNum As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxMonthlyOption As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxMonthlyOrd As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxMonthlyNumMonths As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxMonthlyNumDay As System.Windows.Forms.TextBox
    Friend WithEvents RadioButtonMonthly As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonMonthlyDay As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBoxYearlyMonths As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxYearlyDay As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxYearlyOrd As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBoxYearlyDate As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxYearlyMonth As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButtonYearlyOnThe As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonYearlyOn As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxYearlyYears As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxEndDate As System.Windows.Forms.CheckBox
End Class
