Imports Excel = Microsoft.Office.Interop.Excel

Public Class Frm_Main
    Private controlUser As PSS_Framework.User_Management_Control
    Private comandos As String

    Private Sub Frm_Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If DotNet.IsConfirmed("Are you sure?") = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim argsCadena As String = Command()
        Dim argsArray As Array = Split(argsCadena, " ")
        If (Array.IndexOf(argsArray, "-m")) >= 0 Then
            Me.WindowState = FormWindowState.Minimized
        End If

        SetLabels()
        EnableControls(False)
        If UsersInfo.IsRegistered(AppName) Then 'Validation of user, is registered
            My.Computer.Registry.CurrentUser.OpenSubKey(
                    "SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
                    True
                ).SetValue(
                    Application.ProductName,
                    Application.ExecutablePath & " -m"
                )
            refreshPermissions()
            EnableControls(True)
        Else 'Exit of application if user no have permissions
            My.Computer.Registry.CurrentUser.OpenSubKey(
                    "SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
                    True
                ).DeleteValue(
                    Application.ProductName
                )
            MsgBox("User " & UsersInfo.TNumber & " is not registered!" & vbCr & "Please contact your system administrator.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            Application.Exit()
        End If
    End Sub

    Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsersToolStripMenuItem.Click
        If UsersInfo.IsManager(AppName) Then
            controlUser = New PSS_Framework.User_Management_Control(AppName, UsersInfo)

            controlUser.Add_Credential("Corporative Projects Forecast", "CP_PF")
            controlUser.Add_Credential("Corporative Projects Actuals Input", "CP_AI")
            controlUser.Add_Credential("Corporative Projects Reports", "CP_R")
            controlUser.Add_Credential("PSS Projects Forecast", "PSS_PF")
            controlUser.Add_Credential("PSS Projects Actuals Input", "PSS_AI")
            controlUser.Add_Credential("PSS Projects Reports", "PSS_R")
            controlUser.Add_Credential("Continuos Improvement Allocation Project", "CI_AP")
            controlUser.Add_Credential("Continuos Improvement Actuals Input", "CI_AI")
            controlUser.Add_Credential("Continuos Improvement Reports", "CI_R")

            controlUser.Add_Credential("Documents", "DOC")
            controlUser.Add_Credential("Reports", "REPORTS")

            controlUser.Add_Credential("Maintenance Corporate Projects", "MCP")
            controlUser.Add_Credential("Maintenance PSS Projects", "MPP")
            controlUser.Add_Credential("Maintenance Continuous Improvement", "MCI")
            controlUser.Add_Credential("Project Status", "ProSta")
            controlUser.Add_Credential("Project Resource Type", "PRT")
            controlUser.Add_Credential("Project Service Line", "PSL")
            controlUser.Add_Credential("Project Entry Type", "PET")
            controlUser.Add_Credential("Project Roles", "ROL")

            Dim tablaRoles As DataTable = SQL.Return_DataTable("select * from Role")
            controlUser.Add_Roles(tablaRoles, "Role")

            controlUser.Dock = DockStyle.Fill
            Frm_UserManage.Panel.Controls.Add(controlUser)

            AddHandler Frm_UserManage.Closed, AddressOf refreshPermissions

            Frm_UserManage.ShowDialog(Me)

            controlUser.Dispose()
        End If
    End Sub

    Private Sub refreshPermissions()
        UsersInfo.Credentials_Check(MenuStrip, AppName)
    End Sub

    Private Sub SetLabels() 'Set data for labels and set look and feel of labels
        NotifyIcon.ShowBalloonTip(
            2000,
            Application.ProductName,
            "Welcome " & UsersInfo.Name & " (" & UsersInfo.TNumber & ")",
            ToolTipIcon.Info
        )

        'Look and feel
        Lbl_Welcome.Parent = PanelLabels
        Lbl_TNumber.Parent = PanelLabels
        Lbl_Txt_TNumber.Parent = PanelLabels
        Lbl_Txt_UserName.Parent = PanelLabels
        PanelLabels.BackColor = Color.Transparent
        Lbl_Welcome.BackColor = Color.Transparent
        Lbl_TNumber.BackColor = Color.Transparent
        Lbl_Txt_TNumber.BackColor = Color.Transparent
        Lbl_Txt_UserName.BackColor = Color.Transparent

        'Visual data of user and product version
        Lbl_Version.Text = "Tool Version: " & Application.ProductVersion
        Lbl_Txt_TNumber.Text = UsersInfo.TNumber
        Lbl_Txt_UserName.Text = UsersInfo.Name

        'Load number of pending task CP
        LinkLabelCPAI.Text = "Actuals Input (" & numberTask("CP") & ")"

        'Load number of pending task CP
        LinkLabelPSSAI.Text = "Actuals Input (" & numberTask("PSS") & ")"
    End Sub

    Private Function numberTask(table As String) As Integer
        Dim dataTable As DataTable
        dataTable = SQL.Return_DataTable("select " & _
                "resources.id, " & _
                "project.id, " & _
                "project.Project_Name, " & _
                "resources.Owner_Name, " & _
                "phase.Project_Phase, " & _
                "entry_type.Entry_Type, " & _
                "resources.[Month], " & _
                "resources.Value, " & _
                "resources.Monthly_FTE " & _
            "from " & _
                table & "_Resources as resources, " & _
                table & "_Project as project, " & _
                table & "_Project_Phase as phase, " & _
                "Project_Entry_Type as entry_type " & _
            "where " & _
                "resources.Project_ID = project.ID and " & _
                "resources.Project_Phase = phase.ID and " & _
                "resources.Entry_Type = entry_type.ID and " & _
                "resources.Status <> 0 and " & _
                "project.Status = 7 and " & _
                "resources.Month between '" & DateSerial(Date.Now.Year, Date.Now.Month, "1") & "' and '" & DateSerial(Date.Now.Year, Date.Now.Month + 1, "0") & "' and " & _
                "( " & _
                    "Owner " & UsersInfo.Workflow_Onwer_String(AppName) & _
                ") " & _
            "order by " & _
                "resources.[Month] asc") '"Owner = 'CS1214' or " & _

        Return dataTable.Rows.Count
    End Function

    Private Sub EnableControls(enable As Boolean)
        MenuStrip.Enabled = enable
    End Sub

    Private Sub ProjectForecastToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CPProjectForecastToolStripMenuItem.Click
        If UsersInfo.Cleared(sender.Tag, AppName, True) Then
            Frm_PF.dbTables = "CP"
            Frm_PF.windowTitle = "Corporate Project Forecast"
            Frm_PF.ShowDialog(Me)
            Frm_PF.Dispose()
        End If
    End Sub

    Private Sub ProjectStatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjectStatusToolStripMenuItem.Click
        If UsersInfo.Cleared(sender.tag, AppName, True) Then
            Frm_MaintenanceOneValue.Title = "Project Status"
            Frm_MaintenanceOneValue.lblTexto = "Status"
            Frm_MaintenanceOneValue.Tabla = "Project_Status"
            Frm_MaintenanceOneValue.Campo = "Status"

            Frm_MaintenanceOneValue.ShowDialog(Me)
        End If
    End Sub

    Private Sub ResourceTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResourceTypeToolStripMenuItem.Click
        If UsersInfo.Cleared(sender.tag, AppName, True) Then
            Frm_MaintenanceOneValue.Title = "Project Resource Type"
            Frm_MaintenanceOneValue.lblTexto = "Resource Type"
            Frm_MaintenanceOneValue.Tabla = "Project_Resource_Type"
            Frm_MaintenanceOneValue.Campo = "Resource_Type"

            Frm_MaintenanceOneValue.ShowDialog(Me)
        End If
    End Sub

    Private Sub ProjectServiceLineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjectServiceLineToolStripMenuItem.Click
        If UsersInfo.Cleared(sender.tag, AppName, True) Then
            Frm_MaintenanceOneValue.Title = "Project Service Line"
            Frm_MaintenanceOneValue.lblTexto = "Service Line"
            Frm_MaintenanceOneValue.Tabla = "Project_Service_Line"
            Frm_MaintenanceOneValue.Campo = "Service_Line"

            Frm_MaintenanceOneValue.ShowDialog(Me)
        End If
    End Sub

    Private Sub ProjectEntryTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjectEntryTypeToolStripMenuItem.Click
        If UsersInfo.Cleared(sender.tag, AppName, True) Then
            Frm_MaintenanceOneValue.Title = "Project Entry Type"
            Frm_MaintenanceOneValue.lblTexto = "Entry Type"
            Frm_MaintenanceOneValue.Tabla = "Project_Entry_Type"
            Frm_MaintenanceOneValue.Campo = "Entry_Type"

            Frm_MaintenanceOneValue.ShowDialog(Me)
        End If
    End Sub

    Private Sub CPProjectTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CPProjectTypeToolStripMenuItem.Click
        Frm_MaintenanceOneValue.Title = "Corporate Project - Project Type"
        Frm_MaintenanceOneValue.lblTexto = "Project Type"
        Frm_MaintenanceOneValue.Tabla = "CP_Project_Type"
        Frm_MaintenanceOneValue.Campo = "Project_Type"

        Frm_MaintenanceOneValue.ShowDialog(Me)
    End Sub

    Private Sub CPCategoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CPCategoryToolStripMenuItem.Click
        Frm_MaintenanceOneValue.Title = "Corporate Project - Category"
        Frm_MaintenanceOneValue.lblTexto = "Category"
        Frm_MaintenanceOneValue.Tabla = "CP_Category"
        Frm_MaintenanceOneValue.Campo = "Category"

        Frm_MaintenanceOneValue.ShowDialog(Me)
    End Sub

    Private Sub CPProjectPhaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CPProjectPhaseToolStripMenuItem.Click
        Frm_MaintenanceOneValue.Title = "Corporate Project - Project Phase"
        Frm_MaintenanceOneValue.lblTexto = "Project Phase"
        Frm_MaintenanceOneValue.Tabla = "CP_Project_Phase"
        Frm_MaintenanceOneValue.Campo = "Project_Phase"

        Frm_MaintenanceOneValue.ShowDialog(Me)
    End Sub

    Private Sub PSSCategoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PSSCategoryToolStripMenuItem.Click
        Frm_MaintenanceOneValue.Title = "PSS Project - Category"
        Frm_MaintenanceOneValue.lblTexto = "Category"
        Frm_MaintenanceOneValue.Tabla = "PSS_Category"
        Frm_MaintenanceOneValue.Campo = "Category"

        Frm_MaintenanceOneValue.ShowDialog(Me)
    End Sub

    Private Sub PSSProjectPhaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PSSProjectPhaseToolStripMenuItem.Click
        Frm_MaintenanceOneValue.Title = "PSS Project - Project Phase"
        Frm_MaintenanceOneValue.lblTexto = "Project Phase"
        Frm_MaintenanceOneValue.Tabla = "PSS_Project_Phase"
        Frm_MaintenanceOneValue.Campo = "Project_Phase"

        Frm_MaintenanceOneValue.ShowDialog(Me)
    End Sub

    Private Sub CITaskTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CITaskTypeToolStripMenuItem.Click
        Frm_MaintenanceOneValue.Title = "Continuous Improvement - Task Type"
        Frm_MaintenanceOneValue.lblTexto = "Task Type"
        Frm_MaintenanceOneValue.Tabla = "CI_Task_Type"
        Frm_MaintenanceOneValue.Campo = "Task_Type"

        Frm_MaintenanceOneValue.ShowDialog(Me)
    End Sub

    Private Sub CICatgoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CICatgoryToolStripMenuItem.Click
        Frm_MaintenanceOneValue.Title = "Continuous Improvement - Category"
        Frm_MaintenanceOneValue.lblTexto = "Category"
        Frm_MaintenanceOneValue.Tabla = "CI_Category"
        Frm_MaintenanceOneValue.Campo = "Category"

        Frm_MaintenanceOneValue.ShowDialog(Me)
    End Sub

    Private Sub CPVSChevromToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CPVSChevromToolStripMenuItem.Click
        Frm_MaintenanceTwoValues.TitleWindow = "Corporate Project - VS Chevron"
        Frm_MaintenanceTwoValues.lblCombo = "Category"
        Frm_MaintenanceTwoValues.lblTexto = "VS Chevron"

        Frm_MaintenanceTwoValues.Tabla = "CP_VS_Chevron"
        Frm_MaintenanceTwoValues.TablaRequired = "CP_Category"
        Frm_MaintenanceTwoValues.ValueRequired = "Category"
        Frm_MaintenanceTwoValues.IdRequired = "ID"

        Frm_MaintenanceTwoValues.Campo = "VS_Chevron"
        Frm_MaintenanceTwoValues.CampoRequired = "ID_Category"

        Frm_MaintenanceTwoValues.ShowDialog(Me)
    End Sub

    Private Sub PSSVSChevromToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PSSVSChevromToolStripMenuItem.Click
        Frm_MaintenanceTwoValues.TitleWindow = "PSS - VS Chevron"
        Frm_MaintenanceTwoValues.lblCombo = "Category"
        Frm_MaintenanceTwoValues.lblTexto = "VS Chevron"

        Frm_MaintenanceTwoValues.Tabla = "PSS_VS_Chevron"
        Frm_MaintenanceTwoValues.TablaRequired = "PSS_Category"
        Frm_MaintenanceTwoValues.ValueRequired = "Category"
        Frm_MaintenanceTwoValues.IdRequired = "ID"

        Frm_MaintenanceTwoValues.Campo = "VS_Chevron"
        Frm_MaintenanceTwoValues.CampoRequired = "ID_Category"

        Frm_MaintenanceTwoValues.ShowDialog(Me)
    End Sub

    Private Sub CIVSChevromToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CIVSChevromToolStripMenuItem.Click
        Frm_MaintenanceTwoValues.TitleWindow = "Continuous Improvement - VS Chevron"
        Frm_MaintenanceTwoValues.lblCombo = "Category"
        Frm_MaintenanceTwoValues.lblTexto = "VS Chevron"

        Frm_MaintenanceTwoValues.Tabla = "CI_VS_Chevron"
        Frm_MaintenanceTwoValues.TablaRequired = "CI_Category"
        Frm_MaintenanceTwoValues.ValueRequired = "Category"
        Frm_MaintenanceTwoValues.IdRequired = "ID"

        Frm_MaintenanceTwoValues.Campo = "VS_Chevron"
        Frm_MaintenanceTwoValues.CampoRequired = "ID_Category"

        Frm_MaintenanceTwoValues.ShowDialog(Me)
    End Sub

    Private Sub CIPrimaryProcessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CIPrimaryProcessToolStripMenuItem.Click
        Frm_MaintenanceTwoValues.TitleWindow = "Continuous Improvement - Primary Process"
        Frm_MaintenanceTwoValues.lblCombo = "VS Chevron"
        Frm_MaintenanceTwoValues.lblTexto = "Primary Process"

        Frm_MaintenanceTwoValues.Tabla = "CI_Primary_Process"
        Frm_MaintenanceTwoValues.TablaRequired = "CI_VS_Chevron"
        Frm_MaintenanceTwoValues.ValueRequired = "VS_Chevron"
        Frm_MaintenanceTwoValues.IdRequired = "ID"

        Frm_MaintenanceTwoValues.Campo = "Primary_Process"
        Frm_MaintenanceTwoValues.CampoRequired = "ID_VS_Chevron"

        Frm_MaintenanceTwoValues.ShowDialog(Me)
    End Sub

    Private Sub CPPrimaryProcessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CPPrimaryProcessToolStripMenuItem.Click
        Frm_MaintenanceTwoValues.TitleWindow = "Corporate Projects - Primary Process"
        Frm_MaintenanceTwoValues.lblCombo = "VS Chevron"
        Frm_MaintenanceTwoValues.lblTexto = "Primary Process"

        Frm_MaintenanceTwoValues.Tabla = "CP_Primary_Process"
        Frm_MaintenanceTwoValues.TablaRequired = "CP_VS_Chevron"
        Frm_MaintenanceTwoValues.ValueRequired = "VS_Chevron"
        Frm_MaintenanceTwoValues.IdRequired = "ID"

        Frm_MaintenanceTwoValues.Campo = "Primary_Process"
        Frm_MaintenanceTwoValues.CampoRequired = "ID_VS_Chevron"

        Frm_MaintenanceTwoValues.ShowDialog(Me)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCPPF.LinkClicked
        ProjectForecastToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub LinkLabel15_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelMaintenanceUsers.LinkClicked
        UsersToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub RolesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RolesToolStripMenuItem.Click
        Frm_MaintenanceOneValue.Title = "User Type"
        Frm_MaintenanceOneValue.lblTexto = "Role"
        Frm_MaintenanceOneValue.Tabla = "Role"
        Frm_MaintenanceOneValue.Campo = "Role"

        Frm_MaintenanceOneValue.ShowDialog(Me)
    End Sub

    Private Sub CPActualsInputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CPActualsInputToolStripMenuItem.Click
        If UsersInfo.Cleared(sender.Tag, AppName, True) Then
            Frm_AI.dbTables = "CP"
            Frm_AI.windowTitle = "Corporate Projects - Actuals Input"
            Frm_AI.ShowDialog(Me)
            Frm_AI.Dispose()
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCPAI.LinkClicked
        CPActualsInputToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub CPReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CPReportToolStripMenuItem.Click
        If UsersInfo.Cleared(sender.Tag, AppName, True) Then
            Dim f As New Frm_Report
            f.dbTables = "CP"
            f.ShowDialog(Me)
            f.Dispose()
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCPReports.LinkClicked
        CPReportToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub LinkLabelPSSPF_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelPSSPF.LinkClicked
        PSSProjectForecastToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub PSSProjectForecastToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PSSProjectForecastToolStripMenuItem.Click
        If UsersInfo.Cleared(sender.Tag, AppName, True) Then
            Frm_PF.dbTables = "PSS"
            Frm_PF.windowTitle = "PSS Project Forecast"
            Frm_PF.ShowDialog(Me)
            Frm_PF.Dispose()
        End If
    End Sub

    Private Sub PSSActualsInputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PSSActualsInputToolStripMenuItem.Click
        If UsersInfo.Cleared(sender.Tag, AppName, True) Then
            Frm_AI.dbTables = "PSS"
            Frm_AI.windowTitle = "PSS Projects - Actuals Input"
            Frm_AI.ShowDialog(Me)
            Frm_AI.Dispose()
        End If
    End Sub

    Private Sub LinkLabelPSSAI_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelPSSAI.LinkClicked
        PSSActualsInputToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub PSSReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PSSReportsToolStripMenuItem.Click
        If UsersInfo.Cleared(sender.Tag, AppName, True) Then
            Dim f As New Frm_Report
            f.dbTables = "PSS"
            f.ShowDialog(Me)
            f.Dispose()
        End If
    End Sub

    Private Sub LinkLabelPSSReports_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelPSSReports.LinkClicked
        PSSReportsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub PSSProjectTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PSSProjectTypeToolStripMenuItem.Click
        Frm_MaintenanceOneValue.Title = "PSS Projects - Project Type"
        Frm_MaintenanceOneValue.lblTexto = "Project Type"
        Frm_MaintenanceOneValue.Tabla = "PSS_Project_Type"
        Frm_MaintenanceOneValue.Campo = "Project_Type"

        Frm_MaintenanceOneValue.ShowDialog(Me)
    End Sub

    Private Sub PSSPrimaryProcessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PSSPrimaryProcessToolStripMenuItem.Click
        Frm_MaintenanceTwoValues.TitleWindow = "PSS Projects - Primary Process"
        Frm_MaintenanceTwoValues.lblCombo = "VS Chevron"
        Frm_MaintenanceTwoValues.lblTexto = "Primary Process"

        Frm_MaintenanceTwoValues.Tabla = "PSS_Primary_Process"
        Frm_MaintenanceTwoValues.TablaRequired = "PSS_VS_Chevron"
        Frm_MaintenanceTwoValues.ValueRequired = "VS_Chevron"
        Frm_MaintenanceTwoValues.IdRequired = "ID"

        Frm_MaintenanceTwoValues.Campo = "Primary_Process"
        Frm_MaintenanceTwoValues.CampoRequired = "ID_VS_Chevron"

        Frm_MaintenanceTwoValues.ShowDialog(Me)
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        If ((Today.DayOfWeek = DayOfWeek.Friday) And (DateTime.Now.Hour = 10)) Then
            NotifyIcon.ShowBalloonTip(5000, Application.ProductName, "Please input your actuals.", ToolTipIcon.Warning)
            Timer.Enabled = False
        End If
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub LinkLabelCIAP_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCIAP.LinkClicked
        CIAllocationProjectToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub CIAllocationProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CIAllocationProjectToolStripMenuItem.Click
        If UsersInfo.Cleared(sender.Tag, AppName, True) Then
            Frm_CI_PF.dbTables = "CI"
            Frm_CI_PF.windowTitle = "Continuos Improvement Allocation Project"
            Frm_CI_PF.ShowDialog(Me)
            Frm_CI_PF.Dispose()
        End If
    End Sub

    Private Sub TaskNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TaskNameToolStripMenuItem.Click
        Frm_MaintenanceTwoValues.TitleWindow = "Continuous Improvement - Task Name"
        Frm_MaintenanceTwoValues.lblCombo = "Primary Process"
        Frm_MaintenanceTwoValues.lblTexto = "Task Name"

        Frm_MaintenanceTwoValues.Tabla = "CI_Task_Name"
        Frm_MaintenanceTwoValues.TablaRequired = "CI_Primary_Process"
        Frm_MaintenanceTwoValues.ValueRequired = "Primary_Process"
        Frm_MaintenanceTwoValues.IdRequired = "ID"

        Frm_MaintenanceTwoValues.Campo = "Task_Name"
        Frm_MaintenanceTwoValues.CampoRequired = "ID_Primary_Process"

        Frm_MaintenanceTwoValues.ShowDialog(Me)
    End Sub

    Private Sub CIActualsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CIActualsToolStripMenuItem.Click
        If UsersInfo.Cleared(sender.Tag, AppName, True) Then
            Frm_CI_AI.dbTables = "CI"
            Frm_CI_AI.windowTitle = "CI Projects - Actuals Input"
            Frm_CI_AI.ShowDialog(Me)
            Frm_CI_AI.Dispose()
        End If
    End Sub

    Private Sub CIReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CIReportToolStripMenuItem.Click
        If UsersInfo.Cleared(sender.Tag, AppName, True) Then
            Dim f As New Frm_CI_Report
            f.dbTables = "CI"
            f.ShowDialog(Me)
            f.Dispose()
        End If
    End Sub

    Private Sub LinkLabelCIAI_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCIAI.LinkClicked
        CIActualsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub LinkLabelCIReports_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCIReports.LinkClicked
        CIReportToolStripMenuItem_Click(sender, e)
    End Sub
End Class