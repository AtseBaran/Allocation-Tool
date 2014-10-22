Imports System.IO
Imports System.Data.SqlClient
Imports System.IO.Compression

Public Class Frm_CI_PF
    Friend Id_Project As Integer = 0

    Friend windowTitle As String = ""
    Friend dbTables As String = ""

    Dim ResourceBindingSource As New BindingSource

    Private Sub Frm_CI_PF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = windowTitle

        setLabels()
        clearControlsProjects()
        lockControlsProjects()

        ToolStripButtonNew.Enabled = True
        ToolStripButtonSave.Enabled = False
        ToolStripButtonCancel.Enabled = False
    End Sub

    Private Sub setLabels()
        ToolStripLabelUser.Text = "User: " & UsersInfo.TNumber
    End Sub

    Private Sub clearControlsProjects() 'Clear all data of controls
        TextBoxProjectName.Text = ""
        TextBoxPSSDeliveryPM.Text = ""
        TextBoxXGBSPM.Text = ""
        TextBoxHoursRequired.Text = ""
        TextBoxMaterialRequired.Text = ""
        TextBoxFTERequired.Text = ""
        TextBoxEndDate.Text = ""
        TextBoxStartDate.Text = ""
        ComboBoxProjectType.SelectedIndex = -1
        ComboBoxStatus.SelectedIndex = -1
        CheckBoxRegionAmerica.Checked = False
        CheckBoxRegionAsia.Checked = False
        CheckBoxRegionEMEA.Checked = False
        CheckBoxRegionGlobal.Checked = False
        DataGridViewResources.DataSource = Nothing

        ResourceBindingSource.DataSource = Nothing
    End Sub

    Private Sub lockControlsProjects() 'Lock all controls of projects
        GroupBoxProject.Enabled = False
    End Sub

    Private Sub unLockControlsProjects() 'Unlock all controls of projects
        GroupBoxProject.Enabled = True
        'Load ComboBox
        Dim Table_Category As DataTable = SQL.Return_DataTable("select * from " & dbTables & "_Category")
        ComboBoxCategory.DisplayMember = "Category"
        ComboBoxCategory.ValueMember = "ID"
        ComboBoxCategory.DataSource = Table_Category

        Dim Table_Status As DataTable = SQL.Return_DataTable("select * from Project_Status")
        ComboBoxStatus.DisplayMember = "Status"
        ComboBoxStatus.ValueMember = "ID"
        ComboBoxStatus.DataSource = Table_Status

        Dim Table_Type As DataTable = SQL.Return_DataTable("select * from " & dbTables & "_Project_Type")
        ComboBoxProjectType.DisplayMember = "Project_Type"
        ComboBoxProjectType.ValueMember = "ID"
        ComboBoxProjectType.DataSource = Table_Type

        'Select Value
        If ComboBoxCategory.Items.Count > 0 Then
            ComboBoxCategory.SelectedIndex = 0
        End If
    End Sub

    Private Sub ToolStripButtonNew_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNew.Click
        unLockControlsProjects() 'Unlock all controls

        ToolStripButtonSave.Enabled = True
        ToolStripButtonCancel.Enabled = True
        sender.Enabled = False

        clearControlsProjects()

        TextBoxProjectName.Focus()
    End Sub

    Private Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        If Id_Project = 0 Then

            Dim Bandera As Boolean = False

            If ComboBoxCategory.SelectedIndex = -1 Then
                LabelCategory.ForeColor = Color.Red
                Bandera = True
            Else
                LabelCategory.ForeColor = Color.Black
            End If
            If ComboBoxVSChevron.SelectedIndex = -1 Then
                LabelVSChevron.ForeColor = Color.Red
                Bandera = True
            Else
                LabelVSChevron.ForeColor = Color.Black
            End If
            If ComboBoxPrimaryProcessProject.SelectedIndex = -1 Then
                LabelPrimaryProcess.ForeColor = Color.Red
                Bandera = True
            Else
                LabelPrimaryProcess.ForeColor = Color.Black
            End If
            If ComboBoxStatus.SelectedIndex = -1 Then
                LabelStatus.ForeColor = Color.Red
                Bandera = True
            Else
                LabelStatus.ForeColor = Color.Black
            End If
            If (CheckBoxRegionAmerica.CheckState = CheckState.Unchecked And CheckBoxRegionAsia.CheckState = CheckState.Unchecked And CheckBoxRegionEMEA.CheckState = CheckState.Unchecked And CheckBoxRegionGlobal.CheckState = CheckState.Unchecked) Then
                GroupBoxRegion.ForeColor = Color.Red
                Bandera = True
            Else
                GroupBoxRegion.ForeColor = Color.Black
            End If

            If Bandera Then
                MessageBox.Show("All fields are mandatory, please fill out the ones highlighted in red.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If DotNet.IsConfirmed("Do you want to create the project?") Then
                    lockControlsProjects() 'Lock all contronls

                    ToolStripButtonNew.Enabled = True
                    ToolStripButtonSave.Enabled = False
                    ToolStripButtonCancel.Enabled = False

                    'Create Project
                    Dim retorno = SQL.Execute("insert into " & dbTables & "_Project (" & _
                                                    "Category," & _
                                                    "VS_Chevron," & _
                                                    "Primary_Process," & _
                                                    "Status," & _
                                                    "Americas," & _
                                                    "EMEA," & _
                                                    "Asia," & _
                                                    "Global," & _
                                                    "Created_Date," & _
                                                    "Created_By" & _
                                                ") OUTPUT Inserted.ID values (" & _
                                                    "'" & Trim(ComboBoxCategory.SelectedValue) & "'," & _
                                                    "'" & Trim(ComboBoxVSChevron.SelectedValue) & "'," & _
                                                    "'" & Trim(ComboBoxPrimaryProcessProject.SelectedValue) & "'," & _
                                                    "'" & Trim(ComboBoxStatus.SelectedValue) & "'," & _
                                                    "'" & CheckBoxRegionAmerica.CheckState & "'," & _
                                                    "'" & CheckBoxRegionEMEA.CheckState & "'," & _
                                                    "'" & CheckBoxRegionAsia.CheckState & "'," & _
                                                    "'" & CheckBoxRegionGlobal.CheckState & "'," & _
                                                    "GETDATE()," & _
                                                    "'" & UsersInfo.TNumber & "'" & _
                                                ")"
                                            )

                    'Insert resources...
                    If retorno <> 0 Then
                        Id_Project = retorno
                        loadProject()
                        TabControl.Enabled = True
                    Else
                        MessageBox.Show("An error has been occurred, please contact system administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        ElseIf Id_Project <> 0 Then
            Dim change As Boolean = False
            Dim dataTemp As DataTable
            dataTemp = SQL.Return_DataTable("select Status.Status from " & dbTables & "_Project as project, Project_Status as status where project.ID = '" & Id_Project & "' and status.ID = project.Status")

            For Each rowTemp As DataRow In dataTemp.Rows
                If (rowTemp.Item(0).ToString = "Closed") Then
                    change = False
                ElseIf (rowTemp.Item(0).ToString = "In Process") Then
                    If ComboBoxStatus.Text = "Paid" Then
                        change = False
                    Else
                        change = True
                    End If
                ElseIf (rowTemp.Item(0).ToString = "On Hold") Then
                    If ComboBoxStatus.Text = "Paid" Then
                        change = False
                    Else
                        change = True
                    End If
                ElseIf (rowTemp.Item(0).ToString = "Paid") Then
                    change = False
                ElseIf (rowTemp.Item(0).ToString = "Completed") Then
                    If ComboBoxStatus.Text = "Paid" Then
                        change = True
                    Else
                        change = False
                    End If
                End If
            Next

            If change Then
                SQL.Execute("update " & dbTables & "_Project set Status='" & ComboBoxStatus.SelectedValue & "', Updated_Date=GETDATE(), Updated_By = '" & UsersInfo.TNumber & "' where ID='" & Id_Project & "'")
                MessageBox.Show("Project saved!", "System", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ToolStripButtonSave.Enabled = False
                ToolStripButtonCancel.Enabled = False
                ToolStripButtonNew.Enabled = True

                TextBoxProjectName.Enabled = True
                TextBoxXGBSPM.Enabled = True
                TextBoxPSSDeliveryPM.Enabled = True
                ComboBoxProjectType.Enabled = True
                GroupBoxRegion.Enabled = True

                clearControlsProjects()
                lockControlsProjects()
            Else
                MessageBox.Show("The current project cannot be safe, the new Status is not correct.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Friend Sub loadProject()
        Dim row As DataRow
        Try
            unLockControlsProjects()
            row = SQL.Return_DataRow("select * from " & dbTables & "_Project where ID='" & Id_Project & "'")
            ComboBoxCategory.SelectedValue = row.Item("Category")
            ComboBoxVSChevron.SelectedValue = row.Item("VS_Chevron")
            ComboBoxPrimaryProcessProject.SelectedValue = row.Item("Primary_Process")
            ComboBoxStatus.SelectedValue = row.Item("Status")
            CheckBoxRegionAmerica.CheckState = row.Item("Americas") * -1
            CheckBoxRegionAsia.CheckState = row.Item("Asia") * -1
            CheckBoxRegionEMEA.CheckState = row.Item("EMEA") * -1
            CheckBoxRegionGlobal.CheckState = row.Item("Global") * -1

            ComboBoxCategory.Enabled = False
            ComboBoxVSChevron.Enabled = False
            ComboBoxPrimaryProcessProject.Enabled = False
            GroupBoxRegion.Enabled = False

            ComboBoxStatus.Enabled = True
            ToolStripButtonSave.Enabled = True
            ToolStripButtonCancel.Enabled = True
            ToolStripButtonNew.Enabled = False

            TabControl.Enabled = True

            loadResources(Id_Project)
            loadFiles()
        Catch ex As Exception
            clearControlsProjects()
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Friend Sub loadResources(Project_ID)
        Try
            DataGridViewResources.Columns.Remove("selectProject")
            DataGridViewResources.Columns.Remove("recurrenceText")
        Catch ex As Exception

        End Try

        ResourceBindingSource.DataSource = Nothing
        DataGridViewResources.DataSource = Nothing

        Dim dataTable As DataTable = SQL.Return_DataTable(
                                                            "select " & _
                                                                "project.Category, " & _
                                                                "(select Category from " & dbTables & "_Category where ID=project.Category) as Category_Name, " & _
                                                                "project.VS_Chevron, " & _
                                                                "(select VS_Chevron from " & dbTables & "_VS_Chevron where ID=project.VS_Chevron) as VS_Chevron_Name, " & _
                                                                "project.Primary_Process, " & _
                                                                "(select Primary_Process from " & dbTables & "_Primary_Process where ID=project.Primary_Process) as Primary_Process_Name, " & _
                                                                "project.Created_By, " & _
                                                                "project.Updated_By, " & _
                                                                "resources.ID, " & _
                                                                "resources.Project_ID, " & _
                                                                "resources.Task_Name, " & _
                                                                "resources.Task_Type, " & _
                                                                "(select Task_Type from " & dbTables & "_Task_Type where ID=resources.Task_Type) as Task_Type_Name, " & _
                                                                "resources.Owner_Name, " & _
                                                                "resources.Owner, " & _
                                                                "resources.Start_Date, " & _
                                                                "resources.End_Date, " & _
                                                                "resources.Entry_Type, " & _
                                                                "(select Entry_Type from Project_Entry_Type where ID=resources.Entry_Type) as Entry_Type_Name, " & _
                                                                "resources.Value, " & _
                                                                "resources.Service_Line, " & _
                                                                "(select Service_Line from Project_Service_Line where ID=resources.Service_Line) as Service_Line_Name, " & _
                                                                "Resources.Comment, " & _
                                                                "Resources.Recurrence " & _
                                                            "from  " & _
                                                                dbTables & "_Project as project, " & _
                                                                dbTables & "_Resources as resources " & _
                                                            "where  " & _
                                                                "project.ID = '" & Project_ID & "' and " & _
                                                                "project.ID = resources.Project_ID and " & _
                                                                "resources.Status <> 0"
                                                        )
        
        ResourceBindingSource.DataSource = dataTable
        DataGridViewResources.DataSource = ResourceBindingSource

        DataGridViewResources.Columns(0).Visible = False
        DataGridViewResources.Columns(2).Visible = False
        DataGridViewResources.Columns(4).Visible = False
        DataGridViewResources.Columns(6).Visible = False
        DataGridViewResources.Columns(7).Visible = False
        DataGridViewResources.Columns(8).Visible = False
        DataGridViewResources.Columns(9).Visible = False
        DataGridViewResources.Columns(11).Visible = False
        DataGridViewResources.Columns(15).Visible = False
        DataGridViewResources.Columns(16).Visible = False
        DataGridViewResources.Columns(17).Visible = False
        DataGridViewResources.Columns(19).Visible = False
        DataGridViewResources.Columns(20).Visible = False
        DataGridViewResources.Columns(22).Visible = False
        DataGridViewResources.Columns(23).Visible = False

        Dim TotalValue As New DataGridViewTextBoxColumn()
        DataGridViewResources.Columns.Insert(20, TotalValue)
        TotalValue.HeaderText = "Total Value"
        TotalValue.Name = "totalValue"
        Dim TotalFTE As New DataGridViewTextBoxColumn()
        DataGridViewResources.Columns.Insert(20, TotalFTE)
        TotalFTE.HeaderText = "Total FTE"
        TotalFTE.Name = "totalFTE"


        'Values
        For Each row As DataGridViewRow In DataGridViewResources.Rows
            Dim endDate As Date = DateSerial(Now.Year, (Now.Month + 1), 0)
            Dim curDate As Date = DateSerial(Now.Year, Now.Month, 1)

            Dim Value As Decimal = 0

            While curDate <= endDate
                If Not (curDate.DayOfWeek = DayOfWeek.Saturday) And Not (curDate.DayOfWeek = DayOfWeek.Sunday) Then
                    If getDates(curDate, row.Cells("Recurrence").Value) Then
                        Value = Value + row.Cells("Value").Value
                    End If
                End If
                curDate = curDate.AddDays(1)
            End While
            row.Cells("totalValue").Value = Value

            row.Cells("totalFTE").Value = getMonthlyFTE(row.Cells("Entry_Type_Name").Value, row.Cells("totalValue").Value)

            If Value = 0 Then
                row.Visible = False
            End If
        Next

        Dim recurrence As New DataGridViewTextBoxColumn()

        DataGridViewResources.Columns.Add(recurrence)

        recurrence.HeaderText = "Recurrence Text"
        recurrence.Name = "recurrenceText"

        For Each row As DataGridViewRow In DataGridViewResources.Rows
            row.Cells("recurrenceText").Value = translateRecipe(row.Cells("Recurrence").Value)
        Next

        Dim selectProject As New DataGridViewButtonColumn()

        DataGridViewResources.Columns.Add(selectProject)

        selectProject.HeaderText = "Actions"
        selectProject.Text = "Edit Forecast"
        selectProject.Name = "selectProject"
        selectProject.UseColumnTextForButtonValue = True

        DataGridViewResources.ReadOnly = True
        DataGridViewResources.Columns(1).ReadOnly = False

        For Each column As DataGridViewColumn In DataGridViewResources.Columns
            DataGridViewResources.Columns(column.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DataGridViewResources.Columns(column.Name).HeaderText = DataGridViewResources.Columns(column.Name).HeaderText.Replace("_", " ")
        Next

        getTotals()
    End Sub

    Private Sub getTotals()
        Dim MHours As Decimal = 0
        Dim MMaterials As Decimal = 0
        Dim MFTE As Decimal = 0
        Dim SDate As Date = Date.Now
        Dim EDate As Date = Date.Now
        If DataGridViewResources.Rows.Count > 0 Then
            For Each row As DataGridViewRow In DataGridViewResources.Rows
                If row.Cells("Entry_Type_Name").Value = "Hours" Then
                    MHours = MHours + row.Cells("totalValue").Value
                    MFTE = MFTE + getMonthlyFTE("Hours", row.Cells("totalValue").Value)
                End If
                If row.Cells("Entry_Type_Name").Value = "Materials" Then
                    MMaterials = MMaterials + row.Cells("totalValue").Value
                    MFTE = MFTE + getMonthlyFTE("Materials", row.Cells("totalValue").Value)
                End If

                If SDate > row.Cells("Start_Date").Value Then
                    SDate = row.Cells("Start_Date").Value
                End If
                If EDate < row.Cells("End_Date").Value Then
                    EDate = row.Cells("End_Date").Value
                End If
            Next
        End If
        TextBoxHoursRequired.Text = MHours
        TextBoxMaterialRequired.Text = MMaterials
        TextBoxFTERequired.Text = MFTE
        TextBoxStartDate.Text = SDate.Date
        TextBoxEndDate.Text = EDate.Date
    End Sub

    Private Sub loadFiles()
        Dim dataTable As DataTable = Nothing

        Try
            dataTable = SQL.Return_DataTable("select * from " & dbTables & "_Files where Project_ID='" & Id_Project & "'")

            DataGridViewFiles.DataSource = Nothing
            DataGridViewFiles.Columns.Clear()

            DataGridViewFiles.DataSource = dataTable

            DataGridViewFiles.Columns(0).Visible = False
            DataGridViewFiles.Columns(1).Visible = False
            DataGridViewFiles.Columns(2).Name = "File Name"
            DataGridViewFiles.Columns(3).Visible = False
            DataGridViewFiles.Columns(4).Name = "Owner"

            'Add column with button to download file
            Dim downloadFile As New DataGridViewButtonColumn()

            DataGridViewFiles.Columns.Add(downloadFile)

            downloadFile.HeaderText = "Actions"
            downloadFile.Text = "Download File"
            downloadFile.Name = "downloadFile"
            downloadFile.UseColumnTextForButtonValue = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButtonCancel_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCancel.Click
        If DotNet.IsConfirmed("Are you sure?") Then
            clearControlsProjects() 'Clear data of controls

            sender.Enabled = False
            ToolStripButtonSave.Enabled = False
            ToolStripButtonNew.Enabled = True

            TextBoxProjectName.Enabled = True
            TextBoxXGBSPM.Enabled = True
            TextBoxPSSDeliveryPM.Enabled = True
            ComboBoxProjectType.Enabled = True
            GroupBoxRegion.Enabled = True

            lockControlsProjects() 'Lock all controls
        End If
    End Sub

    Private Sub ToolStripButtonSearch_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSearch.Click
        Dim f As New Frm_CI_SearchProject
        f.dbTables = dbTables
        f.ShowDialog(Me)
        f.Dispose()
    End Sub

    Private Sub ComboBoxCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCategory.SelectedIndexChanged
        Dim Table As DataTable = SQL.Return_DataTable("select * from " & dbTables & "_VS_Chevron where ID_Category='" & sender.SelectedValue & "'")
        ComboBoxVSChevron.DisplayMember = "VS_Chevron"
        ComboBoxVSChevron.ValueMember = "ID"
        ComboBoxVSChevron.DataSource = Table
    End Sub

    Private Sub ComboBoxVSChevron_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxVSChevron.SelectedIndexChanged
        Dim Table As DataTable = SQL.Return_DataTable("select * from " & dbTables & "_Primary_Process where ID_VS_Chevron='" & sender.SelectedValue & "'")
        ComboBoxPrimaryProcessProject.DisplayMember = "Primary_Process"
        ComboBoxPrimaryProcessProject.ValueMember = "ID"
        ComboBoxPrimaryProcessProject.DataSource = Table
    End Sub

    Private Sub ToolStripButtonRefresh_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRefresh.Click
        loadResources(Id_Project)
    End Sub

    Private Sub ToolStripButtonFilter_Click(sender As Object, e As EventArgs) Handles ToolStripButtonFilter.Click
        Try
            Dim FV As String
            If Not DBNull.Value.Equals(DataGridViewResources.CurrentCell.Value) Then
                If DataGridViewResources.CurrentCell.ValueType.Equals(GetType(Date)) Then
                    FV = " >= '" & String.Format("{0:yyyy-MM-dd}", DataGridViewResources.CurrentCell.Value) & " 00:00:00.000' AND " & DataGridViewResources.CurrentCell.OwningColumn.Name & " <= '" & String.Format("{0:yyyy-MM-dd}", DataGridViewResources.CurrentCell.Value) & " 23:59:00.000'"
                Else
                    FV = " = '" & DataGridViewResources.CurrentCell.Value & "'"
                End If
            Else
                FV = " Is Null"
            End If
            Dim FE As String = DataGridViewResources.CurrentCell.OwningColumn.Name & FV

            If ResourceBindingSource.Filter <> Nothing Then
                ResourceBindingSource.Filter = ResourceBindingSource.Filter & " AND " & FE
            Else
                ResourceBindingSource.Filter = FE
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButtonClearFilter_Click(sender As Object, e As EventArgs) Handles ToolStripButtonClearFilter.Click
        Try
            Dim FV As String
            If Not DBNull.Value.Equals(DataGridViewResources.CurrentCell.Value) Then
                If DataGridViewResources.CurrentCell.ValueType.Equals(GetType(Date)) Then
                    FV = " >= '" & String.Format("{0:yyyy-MM-dd}", DataGridViewResources.CurrentCell.Value) & " 00:00:00.000' AND " & DataGridViewResources.CurrentCell.OwningColumn.Name & " <= '" & String.Format("{0:yyyy-MM-dd}", DataGridViewResources.CurrentCell.Value) & " 23:59:00.000'"
                Else
                    FV = " = '" & DataGridViewResources.CurrentCell.Value & "'"
                End If
            Else
                FV = " Is Null"
            End If
            Dim FE As String = "Not (" & DataGridViewResources.CurrentCell.OwningColumn.Name & FV & ")"
            If ResourceBindingSource.Filter <> Nothing Then
                ResourceBindingSource.Filter = ResourceBindingSource.Filter & " AND " & FE
            Else
                ResourceBindingSource.Filter = FE
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolStripButtonClearAll_Click(sender As Object, e As EventArgs) Handles ToolStripButtonClearAll.Click
        ResourceBindingSource.Filter = ""
    End Sub

    Private Sub MarkAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarkAllToolStripMenuItem.Click
        If DataGridViewResources.Rows.Count > 0 Then
            For Each dr As DataGridViewRow In DataGridViewResources.Rows
                dr.Cells(1).Value = 1
            Next
        End If
    End Sub

    Private Sub MarkNoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarkNoneToolStripMenuItem.Click
        If DataGridViewResources.Rows.Count > 0 Then
            For Each dr As DataGridViewRow In DataGridViewResources.Rows
                dr.Cells(1).Value = 0
            Next
        End If
    End Sub

    Private Sub ToolStripButtonAdd_Click(sender As Object, e As EventArgs) Handles ToolStripButtonAdd.Click
        Frm_CI_Resources.Id_Project = Id_Project
        Frm_CI_Resources.Id_Primary_Process = ComboBoxPrimaryProcessProject.SelectedValue
        Frm_CI_Resources.dbTables = dbTables
        Frm_CI_Resources.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButtonRemove_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRemove.Click
        If DotNet.IsConfirmed("Are you sure you want to delete this resource?") Then
            For Each dr As DataGridViewRow In DataGridViewResources.SelectedRows
                SQL.Execute("Delete from " & dbTables & "_Resources where id = '" & dr.Cells(0).Value & "'")
            Next
            loadResources(Id_Project)
        End If
    End Sub

    Private Sub ToolStripButtonRefreshFiles_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRefreshFiles.Click
        loadFiles()
    End Sub

    Private Sub DataGridViewResources_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewResources.CellClick
        Try
            If (e.RowIndex <> -1) Then
                If DataGridViewResources.Columns(e.ColumnIndex).HeaderText = "Actions" Then
                    If DataGridViewResources.Rows.Count > 0 Then
                        'Edit data
                        Frm_CI_Resources_Edit.dbTables = dbTables
                        Frm_CI_Resources_Edit.entry_type = DataGridViewResources.Item("Entry_Type", e.RowIndex).Value
                        Frm_CI_Resources_Edit.old_value = DataGridViewResources.Item("Value", e.RowIndex).Value
                        Frm_CI_Resources_Edit.id_resource = DataGridViewResources.Item("ID", e.RowIndex).Value
                        Frm_CI_Resources_Edit.ShowDialog(Me)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridViewFiles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewFiles.CellClick
        Try
            If (e.RowIndex <> -1) Then
                If DataGridViewFiles.Columns(e.ColumnIndex).HeaderText = "Actions" Then
                    If DataGridViewFiles.Rows.Count > 0 Then
                        Dim fileName As String = DataGridViewFiles.Item(3, e.RowIndex).Value
                        Dim fileData As Byte() = DataGridViewFiles.Item(4, e.RowIndex).Value

                        SaveFileDialog.FileName = fileName

                        SaveFileDialog.ShowDialog(Me)

                        Dim path As String = SaveFileDialog.FileName

                        File.WriteAllBytes(path, fileData)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckBoxRegionAmerica_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRegionAmerica.CheckedChanged
        If (CheckBoxRegionAmerica.Checked And CheckBoxRegionAsia.Checked And CheckBoxRegionEMEA.Checked) Then
            CheckBoxRegionGlobal.CheckState = CheckState.Checked
        ElseIf (Not CheckBoxRegionAmerica.Checked And Not CheckBoxRegionAsia.Checked And Not CheckBoxRegionEMEA.Checked) Then
            CheckBoxRegionGlobal.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub CheckBoxRegionEMEA_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRegionEMEA.CheckedChanged
        If (CheckBoxRegionAmerica.Checked And CheckBoxRegionAsia.Checked And CheckBoxRegionEMEA.Checked) Then
            CheckBoxRegionGlobal.CheckState = CheckState.Checked
        ElseIf (Not CheckBoxRegionAmerica.Checked And Not CheckBoxRegionAsia.Checked And Not CheckBoxRegionEMEA.Checked) Then
            CheckBoxRegionGlobal.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub CheckBoxRegionAsia_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRegionAsia.CheckedChanged
        If (CheckBoxRegionAmerica.Checked And CheckBoxRegionAsia.Checked And CheckBoxRegionEMEA.Checked) Then
            CheckBoxRegionGlobal.CheckState = CheckState.Checked
        ElseIf (Not CheckBoxRegionAmerica.Checked And Not CheckBoxRegionAsia.Checked And Not CheckBoxRegionEMEA.Checked) Then
            CheckBoxRegionGlobal.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub CheckBoxRegionGlobal_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRegionGlobal.CheckedChanged
        If sender.checked Then
            CheckBoxRegionAmerica.Enabled = False
            CheckBoxRegionAsia.Enabled = False
            CheckBoxRegionEMEA.Enabled = False

            CheckBoxRegionAmerica.CheckState = CheckState.Checked
            CheckBoxRegionAsia.CheckState = CheckState.Checked
            CheckBoxRegionEMEA.CheckState = CheckState.Checked
        Else
            CheckBoxRegionAmerica.Enabled = True
            CheckBoxRegionAsia.Enabled = True
            CheckBoxRegionEMEA.Enabled = True

            CheckBoxRegionAmerica.CheckState = CheckState.Unchecked
            CheckBoxRegionAsia.CheckState = CheckState.Unchecked
            CheckBoxRegionEMEA.CheckState = CheckState.Unchecked
        End If
    End Sub
End Class