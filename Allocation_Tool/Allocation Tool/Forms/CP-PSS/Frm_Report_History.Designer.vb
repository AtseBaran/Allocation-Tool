<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Report_History
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Report_History))
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.AxSpreadsheet = New AxMicrosoft.Office.Interop.Owc11.AxSpreadsheet()
        Me.TableLayoutPanelFilters = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanelFilter = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DTPStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DTPEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ButtonProjectCategory = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ButtonProjectName = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.ButtonOwnerName = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ButtonServiceLine = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.ButtonProjectType = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.ButtonUserType = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.ButtonVSChevron = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.CheckBoxRegionAmerica = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRegionEMEA = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.CheckBoxRegionAsia = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRegionGlobal = New System.Windows.Forms.CheckBox()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.ButtonPrimaryProcess = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonRefresh = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonClear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonGraphic = New System.Windows.Forms.ToolStripButton()
        Me.TableLayoutPanel.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.AxSpreadsheet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanelFilters.SuspendLayout()
        Me.TableLayoutPanelFilter.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 1
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.Controls.Add(Me.Panel4, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.TableLayoutPanelFilters, 0, 0)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 2
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 184.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(796, 425)
        Me.TableLayoutPanel.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.TabControl)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 187)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(790, 235)
        Me.Panel4.TabIndex = 1
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(790, 235)
        Me.TabControl.TabIndex = 2
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.AxSpreadsheet)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(782, 209)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Raw Data"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'AxSpreadsheet
        '
        Me.AxSpreadsheet.DataSource = Nothing
        Me.AxSpreadsheet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxSpreadsheet.Enabled = True
        Me.AxSpreadsheet.Location = New System.Drawing.Point(3, 3)
        Me.AxSpreadsheet.Name = "AxSpreadsheet"
        Me.AxSpreadsheet.OcxState = CType(resources.GetObject("AxSpreadsheet.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxSpreadsheet.Size = New System.Drawing.Size(776, 203)
        Me.AxSpreadsheet.TabIndex = 4
        '
        'TableLayoutPanelFilters
        '
        Me.TableLayoutPanelFilters.ColumnCount = 1
        Me.TableLayoutPanelFilters.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelFilters.Controls.Add(Me.TableLayoutPanelFilter, 0, 1)
        Me.TableLayoutPanelFilters.Controls.Add(Me.ToolStrip, 0, 0)
        Me.TableLayoutPanelFilters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelFilters.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanelFilters.Name = "TableLayoutPanelFilters"
        Me.TableLayoutPanelFilters.RowCount = 2
        Me.TableLayoutPanelFilters.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanelFilters.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelFilters.Size = New System.Drawing.Size(790, 178)
        Me.TableLayoutPanelFilters.TabIndex = 2
        '
        'TableLayoutPanelFilter
        '
        Me.TableLayoutPanelFilter.ColumnCount = 3
        Me.TableLayoutPanelFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.TableLayoutPanelFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanelFilter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.TableLayoutPanelFilter.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanelFilter.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanelFilter.Controls.Add(Me.Panel3, 2, 0)
        Me.TableLayoutPanelFilter.Controls.Add(Me.Panel5, 0, 1)
        Me.TableLayoutPanelFilter.Controls.Add(Me.Panel6, 0, 2)
        Me.TableLayoutPanelFilter.Controls.Add(Me.Panel7, 0, 3)
        Me.TableLayoutPanelFilter.Controls.Add(Me.Panel8, 1, 1)
        Me.TableLayoutPanelFilter.Controls.Add(Me.Panel9, 1, 2)
        Me.TableLayoutPanelFilter.Controls.Add(Me.Panel10, 1, 3)
        Me.TableLayoutPanelFilter.Controls.Add(Me.Panel11, 2, 1)
        Me.TableLayoutPanelFilter.Controls.Add(Me.Panel12, 2, 2)
        Me.TableLayoutPanelFilter.Controls.Add(Me.Panel13, 2, 3)
        Me.TableLayoutPanelFilter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelFilter.Location = New System.Drawing.Point(3, 35)
        Me.TableLayoutPanelFilter.Name = "TableLayoutPanelFilter"
        Me.TableLayoutPanelFilter.RowCount = 4
        Me.TableLayoutPanelFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanelFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanelFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanelFilter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanelFilter.Size = New System.Drawing.Size(784, 140)
        Me.TableLayoutPanelFilter.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DTPStartDate)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(255, 29)
        Me.Panel1.TabIndex = 0
        '
        'DTPStartDate
        '
        Me.DTPStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPStartDate.Location = New System.Drawing.Point(91, 6)
        Me.DTPStartDate.Name = "DTPStartDate"
        Me.DTPStartDate.Size = New System.Drawing.Size(158, 20)
        Me.DTPStartDate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Start Date"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DTPEndDate)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(264, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(255, 29)
        Me.Panel2.TabIndex = 1
        '
        'DTPEndDate
        '
        Me.DTPEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPEndDate.Location = New System.Drawing.Point(92, 6)
        Me.DTPEndDate.Name = "DTPEndDate"
        Me.DTPEndDate.Size = New System.Drawing.Size(156, 20)
        Me.DTPEndDate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "End Date"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ButtonProjectCategory)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(525, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(256, 29)
        Me.Panel3.TabIndex = 2
        Me.Panel3.Visible = False
        '
        'ButtonProjectCategory
        '
        Me.ButtonProjectCategory.Location = New System.Drawing.Point(98, 3)
        Me.ButtonProjectCategory.Name = "ButtonProjectCategory"
        Me.ButtonProjectCategory.Size = New System.Drawing.Size(158, 23)
        Me.ButtonProjectCategory.TabIndex = 5
        Me.ButtonProjectCategory.Text = "Select..."
        Me.ButtonProjectCategory.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Project Category"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.ButtonProjectName)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 38)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(255, 29)
        Me.Panel5.TabIndex = 3
        '
        'ButtonProjectName
        '
        Me.ButtonProjectName.Location = New System.Drawing.Point(91, 3)
        Me.ButtonProjectName.Name = "ButtonProjectName"
        Me.ButtonProjectName.Size = New System.Drawing.Size(158, 23)
        Me.ButtonProjectName.TabIndex = 1
        Me.ButtonProjectName.Text = "Select..."
        Me.ButtonProjectName.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Project Name"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.ButtonOwnerName)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 73)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(255, 29)
        Me.Panel6.TabIndex = 4
        Me.Panel6.Visible = False
        '
        'ButtonOwnerName
        '
        Me.ButtonOwnerName.Location = New System.Drawing.Point(91, 3)
        Me.ButtonOwnerName.Name = "ButtonOwnerName"
        Me.ButtonOwnerName.Size = New System.Drawing.Size(158, 23)
        Me.ButtonOwnerName.TabIndex = 3
        Me.ButtonOwnerName.Text = "Select..."
        Me.ButtonOwnerName.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Owner Name"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.ButtonServiceLine)
        Me.Panel7.Controls.Add(Me.Label7)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 108)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(255, 29)
        Me.Panel7.TabIndex = 5
        Me.Panel7.Visible = False
        '
        'ButtonServiceLine
        '
        Me.ButtonServiceLine.Location = New System.Drawing.Point(91, 3)
        Me.ButtonServiceLine.Name = "ButtonServiceLine"
        Me.ButtonServiceLine.Size = New System.Drawing.Size(158, 23)
        Me.ButtonServiceLine.TabIndex = 3
        Me.ButtonServiceLine.Text = "Select..."
        Me.ButtonServiceLine.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Service Line"
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.ButtonProjectType)
        Me.Panel8.Controls.Add(Me.Label4)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(264, 38)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(255, 29)
        Me.Panel8.TabIndex = 6
        Me.Panel8.Visible = False
        '
        'ButtonProjectType
        '
        Me.ButtonProjectType.Location = New System.Drawing.Point(90, 2)
        Me.ButtonProjectType.Name = "ButtonProjectType"
        Me.ButtonProjectType.Size = New System.Drawing.Size(158, 23)
        Me.ButtonProjectType.TabIndex = 3
        Me.ButtonProjectType.Text = "Select..."
        Me.ButtonProjectType.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Project Type"
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.ButtonUserType)
        Me.Panel9.Controls.Add(Me.Label6)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(264, 73)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(255, 29)
        Me.Panel9.TabIndex = 7
        Me.Panel9.Visible = False
        '
        'ButtonUserType
        '
        Me.ButtonUserType.Location = New System.Drawing.Point(90, 3)
        Me.ButtonUserType.Name = "ButtonUserType"
        Me.ButtonUserType.Size = New System.Drawing.Size(158, 23)
        Me.ButtonUserType.TabIndex = 3
        Me.ButtonUserType.Text = "Select..."
        Me.ButtonUserType.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "User Type"
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.ButtonVSChevron)
        Me.Panel10.Controls.Add(Me.Label9)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(264, 108)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(255, 29)
        Me.Panel10.TabIndex = 8
        Me.Panel10.Visible = False
        '
        'ButtonVSChevron
        '
        Me.ButtonVSChevron.Location = New System.Drawing.Point(90, 3)
        Me.ButtonVSChevron.Name = "ButtonVSChevron"
        Me.ButtonVSChevron.Size = New System.Drawing.Size(158, 23)
        Me.ButtonVSChevron.TabIndex = 3
        Me.ButtonVSChevron.Text = "Select..."
        Me.ButtonVSChevron.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "VS Chevron"
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.CheckBoxRegionAmerica)
        Me.Panel11.Controls.Add(Me.CheckBoxRegionEMEA)
        Me.Panel11.Controls.Add(Me.Label8)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(525, 38)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(256, 29)
        Me.Panel11.TabIndex = 9
        Me.Panel11.Visible = False
        '
        'CheckBoxRegionAmerica
        '
        Me.CheckBoxRegionAmerica.AutoSize = True
        Me.CheckBoxRegionAmerica.Location = New System.Drawing.Point(79, 6)
        Me.CheckBoxRegionAmerica.Name = "CheckBoxRegionAmerica"
        Me.CheckBoxRegionAmerica.Size = New System.Drawing.Size(64, 17)
        Me.CheckBoxRegionAmerica.TabIndex = 6
        Me.CheckBoxRegionAmerica.Text = "America"
        Me.CheckBoxRegionAmerica.UseVisualStyleBackColor = True
        '
        'CheckBoxRegionEMEA
        '
        Me.CheckBoxRegionEMEA.AutoSize = True
        Me.CheckBoxRegionEMEA.Location = New System.Drawing.Point(166, 6)
        Me.CheckBoxRegionEMEA.Name = "CheckBoxRegionEMEA"
        Me.CheckBoxRegionEMEA.Size = New System.Drawing.Size(56, 17)
        Me.CheckBoxRegionEMEA.TabIndex = 5
        Me.CheckBoxRegionEMEA.Text = "EMEA"
        Me.CheckBoxRegionEMEA.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Region"
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.CheckBoxRegionAsia)
        Me.Panel12.Controls.Add(Me.CheckBoxRegionGlobal)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(525, 73)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(256, 29)
        Me.Panel12.TabIndex = 10
        Me.Panel12.Visible = False
        '
        'CheckBoxRegionAsia
        '
        Me.CheckBoxRegionAsia.AutoSize = True
        Me.CheckBoxRegionAsia.Location = New System.Drawing.Point(79, 6)
        Me.CheckBoxRegionAsia.Name = "CheckBoxRegionAsia"
        Me.CheckBoxRegionAsia.Size = New System.Drawing.Size(46, 17)
        Me.CheckBoxRegionAsia.TabIndex = 4
        Me.CheckBoxRegionAsia.Text = "Asia"
        Me.CheckBoxRegionAsia.UseVisualStyleBackColor = True
        '
        'CheckBoxRegionGlobal
        '
        Me.CheckBoxRegionGlobal.AutoSize = True
        Me.CheckBoxRegionGlobal.Location = New System.Drawing.Point(166, 6)
        Me.CheckBoxRegionGlobal.Name = "CheckBoxRegionGlobal"
        Me.CheckBoxRegionGlobal.Size = New System.Drawing.Size(56, 17)
        Me.CheckBoxRegionGlobal.TabIndex = 3
        Me.CheckBoxRegionGlobal.Text = "Global"
        Me.CheckBoxRegionGlobal.UseVisualStyleBackColor = True
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.ButtonPrimaryProcess)
        Me.Panel13.Controls.Add(Me.Label10)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel13.Location = New System.Drawing.Point(525, 108)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(256, 29)
        Me.Panel13.TabIndex = 11
        Me.Panel13.Visible = False
        '
        'ButtonPrimaryProcess
        '
        Me.ButtonPrimaryProcess.Location = New System.Drawing.Point(98, 3)
        Me.ButtonPrimaryProcess.Name = "ButtonPrimaryProcess"
        Me.ButtonPrimaryProcess.Size = New System.Drawing.Size(158, 23)
        Me.ButtonPrimaryProcess.TabIndex = 3
        Me.ButtonPrimaryProcess.Text = "Select..."
        Me.ButtonPrimaryProcess.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Primary Process"
        '
        'ToolStrip
        '
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonRefresh, Me.ToolStripButtonClear, Me.ToolStripSeparator1, Me.ToolStripButtonExcel, Me.ToolStripButtonGraphic})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(790, 31)
        Me.ToolStrip.TabIndex = 1
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
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
        'ToolStripButtonClear
        '
        Me.ToolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonClear.Image = Global.Allocation_Tool.My.Resources.Resources.edit_clear
        Me.ToolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonClear.Name = "ToolStripButtonClear"
        Me.ToolStripButtonClear.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonClear.Text = "Clear Filters"
        '
        'ToolStripButtonExcel
        '
        Me.ToolStripButtonExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonExcel.Image = CType(resources.GetObject("ToolStripButtonExcel.Image"), System.Drawing.Image)
        Me.ToolStripButtonExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonExcel.Name = "ToolStripButtonExcel"
        Me.ToolStripButtonExcel.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonExcel.Text = "Export to Excel"
        Me.ToolStripButtonExcel.Visible = False
        '
        'ToolStripButtonGraphic
        '
        Me.ToolStripButtonGraphic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonGraphic.Image = Global.Allocation_Tool.My.Resources.Resources.pie_chart
        Me.ToolStripButtonGraphic.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonGraphic.Name = "ToolStripButtonGraphic"
        Me.ToolStripButtonGraphic.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButtonGraphic.Text = "Export to Image"
        Me.ToolStripButtonGraphic.Visible = False
        '
        'Frm_Report_History
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 425)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Report_History"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Report - Forecast Change History"
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.TabControl.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.AxSpreadsheet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanelFilters.ResumeLayout(False)
        Me.TableLayoutPanelFilters.PerformLayout()
        Me.TableLayoutPanelFilter.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents AxSpreadsheet As AxMicrosoft.Office.Interop.Owc11.AxSpreadsheet
    Friend WithEvents TableLayoutPanelFilters As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanelFilter As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DTPStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DTPEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ButtonProjectCategory As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents ButtonProjectName As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents ButtonOwnerName As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents ButtonServiceLine As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents ButtonProjectType As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents ButtonUserType As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents ButtonVSChevron As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents CheckBoxRegionAmerica As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRegionEMEA As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents CheckBoxRegionAsia As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRegionGlobal As System.Windows.Forms.CheckBox
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents ButtonPrimaryProcess As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonGraphic As System.Windows.Forms.ToolStripButton
End Class
