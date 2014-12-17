<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_CI_Resources_Edit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_CI_Resources_Edit))
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
        Me.DTP_End = New System.Windows.Forms.DateTimePicker()
        Me.DTP_Start = New System.Windows.Forms.DateTimePicker()
        Me.LabelStartDate = New System.Windows.Forms.Label()
        Me.GroupBoxRecurrence = New System.Windows.Forms.GroupBox()
        Me.GroupBoxData = New System.Windows.Forms.GroupBox()
        Me.TextBoxComments = New System.Windows.Forms.TextBox()
        Me.TextBoxMonthlyValue = New System.Windows.Forms.TextBox()
        Me.LabelComments = New System.Windows.Forms.Label()
        Me.LabelMonthlyValue = New System.Windows.Forms.Label()
        Me.TextBoxOldValue = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonHistory = New System.Windows.Forms.ToolStripButton()
        Me.TabControlRecipe.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBoxRecurrence.SuspendLayout()
        Me.GroupBoxData.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckBoxEndDate
        '
        Me.CheckBoxEndDate.AutoSize = True
        Me.CheckBoxEndDate.Checked = True
        Me.CheckBoxEndDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxEndDate.Location = New System.Drawing.Point(156, 17)
        Me.CheckBoxEndDate.Name = "CheckBoxEndDate"
        Me.CheckBoxEndDate.Size = New System.Drawing.Size(71, 17)
        Me.CheckBoxEndDate.TabIndex = 16
        Me.CheckBoxEndDate.Text = "End Date"
        Me.CheckBoxEndDate.UseVisualStyleBackColor = True
        '
        'TabControlRecipe
        '
        Me.TabControlRecipe.Controls.Add(Me.TabPage1)
        Me.TabControlRecipe.Controls.Add(Me.TabPage2)
        Me.TabControlRecipe.Controls.Add(Me.TabPage3)
        Me.TabControlRecipe.Controls.Add(Me.TabPage4)
        Me.TabControlRecipe.Location = New System.Drawing.Point(6, 41)
        Me.TabControlRecipe.Name = "TabControlRecipe"
        Me.TabControlRecipe.SelectedIndex = 0
        Me.TabControlRecipe.Size = New System.Drawing.Size(323, 147)
        Me.TabControlRecipe.TabIndex = 15
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
        Me.ComboBoxMonthlyOption.Items.AddRange(New Object() {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"})
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
        Me.ComboBoxMonthlyOrd.Items.AddRange(New Object() {"first", "second", "third", "fourth"})
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
        Me.ComboBoxYearlyDay.Items.AddRange(New Object() {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"})
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
        Me.ComboBoxYearlyOrd.Items.AddRange(New Object() {"first", "second", "third", "fourth"})
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
        'DTP_End
        '
        Me.DTP_End.CustomFormat = "MMMM yyyy"
        Me.DTP_End.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_End.Location = New System.Drawing.Point(224, 15)
        Me.DTP_End.Name = "DTP_End"
        Me.DTP_End.Size = New System.Drawing.Size(96, 20)
        Me.DTP_End.TabIndex = 13
        '
        'DTP_Start
        '
        Me.DTP_Start.CustomFormat = "MMMM yyyy"
        Me.DTP_Start.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Start.Location = New System.Drawing.Point(63, 15)
        Me.DTP_Start.Name = "DTP_Start"
        Me.DTP_Start.Size = New System.Drawing.Size(84, 20)
        Me.DTP_Start.TabIndex = 12
        '
        'LabelStartDate
        '
        Me.LabelStartDate.AutoSize = True
        Me.LabelStartDate.Location = New System.Drawing.Point(10, 18)
        Me.LabelStartDate.Name = "LabelStartDate"
        Me.LabelStartDate.Size = New System.Drawing.Size(55, 13)
        Me.LabelStartDate.TabIndex = 14
        Me.LabelStartDate.Text = "Start Date"
        '
        'GroupBoxRecurrence
        '
        Me.GroupBoxRecurrence.Controls.Add(Me.LabelStartDate)
        Me.GroupBoxRecurrence.Controls.Add(Me.CheckBoxEndDate)
        Me.GroupBoxRecurrence.Controls.Add(Me.DTP_Start)
        Me.GroupBoxRecurrence.Controls.Add(Me.TabControlRecipe)
        Me.GroupBoxRecurrence.Controls.Add(Me.DTP_End)
        Me.GroupBoxRecurrence.Location = New System.Drawing.Point(12, 34)
        Me.GroupBoxRecurrence.Name = "GroupBoxRecurrence"
        Me.GroupBoxRecurrence.Size = New System.Drawing.Size(336, 194)
        Me.GroupBoxRecurrence.TabIndex = 17
        Me.GroupBoxRecurrence.TabStop = False
        Me.GroupBoxRecurrence.Text = "Recurrence"
        '
        'GroupBoxData
        '
        Me.GroupBoxData.Controls.Add(Me.TextBoxComments)
        Me.GroupBoxData.Controls.Add(Me.TextBoxMonthlyValue)
        Me.GroupBoxData.Controls.Add(Me.LabelComments)
        Me.GroupBoxData.Controls.Add(Me.LabelMonthlyValue)
        Me.GroupBoxData.Controls.Add(Me.TextBoxOldValue)
        Me.GroupBoxData.Controls.Add(Me.Label11)
        Me.GroupBoxData.Location = New System.Drawing.Point(354, 34)
        Me.GroupBoxData.Name = "GroupBoxData"
        Me.GroupBoxData.Size = New System.Drawing.Size(303, 194)
        Me.GroupBoxData.TabIndex = 18
        Me.GroupBoxData.TabStop = False
        Me.GroupBoxData.Text = "Entry"
        '
        'TextBoxComments
        '
        Me.TextBoxComments.Location = New System.Drawing.Point(64, 77)
        Me.TextBoxComments.Multiline = True
        Me.TextBoxComments.Name = "TextBoxComments"
        Me.TextBoxComments.Size = New System.Drawing.Size(233, 107)
        Me.TextBoxComments.TabIndex = 23
        '
        'TextBoxMonthlyValue
        '
        Me.TextBoxMonthlyValue.Location = New System.Drawing.Point(64, 15)
        Me.TextBoxMonthlyValue.Name = "TextBoxMonthlyValue"
        Me.TextBoxMonthlyValue.Size = New System.Drawing.Size(233, 20)
        Me.TextBoxMonthlyValue.TabIndex = 7
        '
        'LabelComments
        '
        Me.LabelComments.AutoSize = True
        Me.LabelComments.Location = New System.Drawing.Point(8, 80)
        Me.LabelComments.Name = "LabelComments"
        Me.LabelComments.Size = New System.Drawing.Size(51, 13)
        Me.LabelComments.TabIndex = 22
        Me.LabelComments.Text = "Comment"
        '
        'LabelMonthlyValue
        '
        Me.LabelMonthlyValue.AutoSize = True
        Me.LabelMonthlyValue.Location = New System.Drawing.Point(6, 18)
        Me.LabelMonthlyValue.Name = "LabelMonthlyValue"
        Me.LabelMonthlyValue.Size = New System.Drawing.Size(34, 13)
        Me.LabelMonthlyValue.TabIndex = 8
        Me.LabelMonthlyValue.Text = "Value"
        '
        'TextBoxOldValue
        '
        Me.TextBoxOldValue.Enabled = False
        Me.TextBoxOldValue.Location = New System.Drawing.Point(64, 47)
        Me.TextBoxOldValue.Name = "TextBoxOldValue"
        Me.TextBoxOldValue.Size = New System.Drawing.Size(233, 20)
        Me.TextBoxOldValue.TabIndex = 21
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Old Value"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonSave, Me.ToolStripButtonCancel, Me.ToolStripButtonHistory})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(669, 31)
        Me.ToolStrip1.TabIndex = 19
        Me.ToolStrip1.Text = "ToolStrip1"
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
        Me.ToolStripButtonHistory.Size = New System.Drawing.Size(105, 28)
        Me.ToolStripButtonHistory.Text = "Resources History"
        '
        'Frm_CI_Resources_Edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(669, 243)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBoxData)
        Me.Controls.Add(Me.GroupBoxRecurrence)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Frm_CI_Resources_Edit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Resources"
        Me.TabControlRecipe.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBoxRecurrence.ResumeLayout(False)
        Me.GroupBoxRecurrence.PerformLayout()
        Me.GroupBoxData.ResumeLayout(False)
        Me.GroupBoxData.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBoxEndDate As System.Windows.Forms.CheckBox
    Friend WithEvents TabControlRecipe As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxDaily As System.Windows.Forms.TextBox
    Friend WithEvents RadioButtonDailyWeekday As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonDailyEvery As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
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
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
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
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
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
    Friend WithEvents DTP_End As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_Start As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelStartDate As System.Windows.Forms.Label
    Friend WithEvents GroupBoxRecurrence As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxData As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxMonthlyValue As System.Windows.Forms.TextBox
    Friend WithEvents LabelMonthlyValue As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonHistory As System.Windows.Forms.ToolStripButton
    Friend WithEvents TextBoxComments As System.Windows.Forms.TextBox
    Friend WithEvents LabelComments As System.Windows.Forms.Label
    Friend WithEvents TextBoxOldValue As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
