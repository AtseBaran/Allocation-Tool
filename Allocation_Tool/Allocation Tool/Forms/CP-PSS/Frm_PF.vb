Imports System.IO
Imports System.Data.SqlClient
Imports System.IO.Compression

Public Class Frm_PF
    Friend Id_Project As Integer = 0

    Friend windowTitle As String = ""
    Friend dbTables As String = ""

    Dim ResourceBindingSource As New BindingSource

    Private Sub Frm_CP_PF_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If GroupBoxProject.Enabled Then
            If Not DotNet.IsConfirmed("The window is closing, are you sure to continue?" & vbCrLf & "All information that has not been saved will be lost.") Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Frm_CP_PF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            If DotNet.IsEmpty(TextBoxProjectName.Text) Then
                LabelProjectName.ForeColor = Color.Red
                Bandera = True
            Else
                LabelProjectName.ForeColor = Color.Black
            End If
            If DotNet.IsEmpty(TextBoxXGBSPM.Text) Then
                LabelXGBSPM.ForeColor = Color.Red
                Bandera = True
            Else
                LabelXGBSPM.ForeColor = Color.Black
            End If
            If DotNet.IsEmpty(TextBoxPSSDeliveryPM.Text) Then
                LabelPSSDeliveryPM.ForeColor = Color.Red
                Bandera = True
            Else
                LabelPSSDeliveryPM.ForeColor = Color.Black
            End If
            If ComboBoxProjectType.SelectedIndex = -1 Then
                LabelProjectType.ForeColor = Color.Red
                Bandera = True
            Else
                LabelProjectType.ForeColor = Color.Black
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
                                "Project_Name," & _
                                "XGBS_PM," & _
                                "PSS_Delivery_PM," & _
                                "Category," & _
                                "VS_Chevron," & _
                                "Primary_Process," & _
                                "Status," & _
                                "Project_Type," & _
                                "Americas," & _
                                "EMEA," & _
                                "Asia," & _
                                "Global," & _
                                "Created_Date," & _
                                "Created_By" & _
                                ") OUTPUT Inserted.ID values (" & _
                                "'" & sqlString(Trim(TextBoxProjectName.Text)) & "'," & _
                                "'" & sqlString(Trim(TextBoxXGBSPM.Text)) & "'," & _
                                "'" & sqlString(Trim(TextBoxPSSDeliveryPM.Text)) & "'," & _
                                "'" & Trim(ComboBoxCategory.SelectedValue) & "'," & _
                                "'" & Trim(ComboBoxVSChevron.SelectedValue) & "'," & _
                                "'" & Trim(ComboBoxPrimaryProcessProject.SelectedValue) & "'," & _
                                "'" & Trim(ComboBoxStatus.SelectedValue) & "'," & _
                                "'" & Trim(ComboBoxProjectType.SelectedValue) & "'," & _
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

    Private Sub ToolStripButtonDelete_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCancel.Click
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
        Frm_SearchProject.dbTables = dbTables
        Frm_SearchProject.ShowDialog(Me)
    End Sub

    Friend Sub loadProject()
        Dim row As DataRow
        Try
            unLockControlsProjects()
            row = SQL.Return_DataRow("select * from " & dbTables & "_Project where ID='" & Id_Project & "'")
            TextBoxProjectName.Text = row.Item("Project_Name").ToString
            TextBoxXGBSPM.Text = row.Item("XGBS_PM").ToString
            TextBoxPSSDeliveryPM.Text = row.Item("PSS_Delivery_PM").ToString
            ComboBoxProjectType.SelectedValue = row.Item("Project_Type")
            ComboBoxStatus.SelectedValue = row.Item("Status")
            CheckBoxRegionAmerica.CheckState = row.Item("Americas") * -1
            CheckBoxRegionAsia.CheckState = row.Item("Asia") * -1
            CheckBoxRegionEMEA.CheckState = row.Item("EMEA") * -1
            CheckBoxRegionGlobal.CheckState = row.Item("Global") * -1

            TextBoxProjectName.Enabled = False
            TextBoxXGBSPM.Enabled = False
            TextBoxPSSDeliveryPM.Enabled = False
            ComboBoxProjectType.Enabled = False
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

    Private Sub ToolStripButtonAdd_Click(sender As Object, e As EventArgs) Handles ToolStripButtonAdd.Click
        Frm_Resources.Id_Project = Id_Project
        Frm_Resources.dbTables = dbTables
        Frm_Resources.ShowDialog(Me)
    End Sub

    Friend Sub loadResources(Project_ID)
        Try
            DataGridViewResources.Columns.Remove("selectProject")
        Catch ex As Exception

        End Try

        Dim dataTable = SQL.Return_DataTable("select resources.ID, " & _
                                                "resources.[Check], " & _
                                                "resource_type.Resource_Type, " & _
                                                "service_line.Service_Line, " & _
                                                "phase.Project_Phase, " & _
                                                "Resources.[Owner], " & _
                                                "resources.Owner_Name, " & _
                                                "entry_type.Entry_Type, " & _
                                                "resources.Value, " & _
                                                "resources.Monthly_FTE, " & _
                                                "resources.[Month], " & _
                                                "resources.Status " & _
                                            "from " & dbTables & "_Resources as resources, " & _
                                                "Project_Resource_Type as resource_type, " & _
                                                "Project_Service_Line as service_line, " & _
                                                "" & dbTables & "_Project_Phase as phase, " & _
                                                "Project_Entry_Type as entry_type " & _
                                            "where Project_ID = " & Id_Project & " And " & _
                                                "resources.Resource_Type = resource_type.ID And " & _
                                                "resources.Service_Line = service_line.ID And " & _
                                                "resources.Project_Phase = phase.ID And " & _
                                                "resources.Entry_Type = entry_type.ID and " & _
                                                "resources.Status <> 0")

        ResourceBindingSource.DataSource = dataTable
        DataGridViewResources.DataSource = ResourceBindingSource

        DataGridViewResources.Columns(0).Visible = False
        DataGridViewResources.Columns(1).HeaderText = "Check"
        DataGridViewResources.Columns(1).Visible = False
        DataGridViewResources.Columns(2).HeaderText = "Resource Type"
        DataGridViewResources.Columns(3).HeaderText = "Service Line"
        DataGridViewResources.Columns(4).HeaderText = "Project Phase"
        DataGridViewResources.Columns(5).HeaderText = "TNumber"
        DataGridViewResources.Columns(6).HeaderText = "Name"
        DataGridViewResources.Columns(7).HeaderText = "Entry Type"
        DataGridViewResources.Columns(8).HeaderText = "Monthly Value"
        DataGridViewResources.Columns(9).HeaderText = "Monthly FTE"
        DataGridViewResources.Columns(10).HeaderText = "Month"
        DataGridViewResources.Columns(10).DefaultCellStyle.Format = "MMMM yyyy"
        DataGridViewResources.Columns(11).Visible = False

        Dim selectProject As New DataGridViewButtonColumn()

        DataGridViewResources.Columns.Add(selectProject)

        selectProject.HeaderText = "Actions"
        selectProject.Text = "Edit Forecast"
        selectProject.Name = "selectProject"
        selectProject.UseColumnTextForButtonValue = True

        DataGridViewResources.ReadOnly = True
        DataGridViewResources.Columns(1).ReadOnly = False

        For Each row As DataGridViewRow In DataGridViewResources.Rows
            Dim dateTemp As Date = row.Cells(10).Value
            Dim diff As Integer
            diff = DateDiff(DateInterval.Day, Date.Now, DateSerial(dateTemp.Year, dateTemp.Month + 1, "0"))
            If diff < 7 Then
                DataGridViewResources.Item(10, row.Index).Style.BackColor = Color.RosyBrown
            ElseIf diff < 15 Then
                DataGridViewResources.Item(10, row.Index).Style.BackColor = Color.LightYellow
            Else
                DataGridViewResources.Item(10, row.Index).Style.BackColor = Color.LightGreen
            End If
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
                If row.Cells(7).Value = "Hours" Then
                    MHours = MHours + row.Cells(8).Value
                    MFTE = MFTE + getMonthlyFTE("Hours", row.Cells(8).Value)
                End If
                If row.Cells(7).Value = "Materials" Then
                    MMaterials = MMaterials + row.Cells(8).Value
                    MFTE = MFTE + getMonthlyFTE("Materials", row.Cells(8).Value)
                End If

                If SDate > row.Cells(10).Value Then
                    SDate = row.Cells(10).Value
                End If
                If EDate < row.Cells(10).Value Then
                    EDate = row.Cells(10).Value
                End If
            Next
        End If
        TextBoxHoursRequired.Text = MHours
        TextBoxMaterialRequired.Text = MMaterials
        TextBoxFTERequired.Text = MFTE
        TextBoxStartDate.Text = meses(SDate.Month - 1) & " " & SDate.Year
        TextBoxEndDate.Text = meses(EDate.Month - 1) & " " & EDate.Year
    End Sub

    Private Sub ToolStripButtonRemove_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRemove.Click
        If DotNet.IsConfirmed("Are you sure you want to delete this resource?") Then
            For Each dr As DataGridViewRow In DataGridViewResources.SelectedRows
                If dr.Cells("Month").Value > DateSerial(Date.Now.Year, Date.Now.Month + 1, "0") Then
                    SQL.Execute("Update " & dbTables & "_Resources set status=0 where id = '" & dr.Cells(0).Value & "'")
                Else
                    MessageBox.Show("The specified resource can not be deleted, please check the date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Next
            loadResources(Id_Project)
        End If
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

    Private Sub ToolStripButtonRefresh_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRefresh.Click
        loadResources(Id_Project)
    End Sub

    Private Sub DataGridViewResources_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewResources.CellClick
        Try
            If (e.RowIndex <> -1) Then
                If DataGridViewResources.Columns(e.ColumnIndex).HeaderText = "Actions" Then
                    Dim dateValue As Date = DataGridViewResources.Item(10, e.RowIndex).Value
                    If DateSerial(dateValue.Year, dateValue.Month, "5") >= DateSerial(Today.Year, Today.Month, Today.Day) Then
                        If DataGridViewResources.Rows.Count > 0 Then
                            'Edit data
                            Frm_Resources_Edit.dbTables = dbTables
                            Frm_Resources_Edit.entry_type = DataGridViewResources.Item(7, e.RowIndex).Value
                            Frm_Resources_Edit.old_value = DataGridViewResources.Item(8, e.RowIndex).Value
                            Frm_Resources_Edit.id_resource = DataGridViewResources.Item(0, e.RowIndex).Value
                            Frm_Resources_Edit.ShowDialog(Me)
                        End If
                    Else
                        MessageBox.Show("Please check, this resource can not be modified.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
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

    Private Sub ToolStripButtonAddFiles_Click(sender As Object, e As EventArgs) Handles ToolStripButtonAddFiles.Click
        Try
            Dim fs As FileStream

            OpenFileDialog.ShowDialog(Me)
            Dim sFile As String = OpenFileDialog.FileName

            fs = New FileStream(sFile, FileMode.Open, FileAccess.Read)
            Dim docByte As Byte() = New Byte(fs.Length - 1) {}
            fs.Read(docByte, 0, System.Convert.ToInt32(fs.Length))
            fs.Close()

            Dim SQLquery As String = "insert into " & dbTables & "_Files (Project_ID, FileName, [File], Owner) values ('" & Id_Project & "', '" & OpenFileDialog.SafeFileName & "', @fdoc, '" & UsersInfo.TNumber & "')"
            Dim docfile As New SqlParameter
            docfile.SqlDbType = SqlDbType.Binary
            docfile.ParameterName = "fdoc"
            docfile.Value = docByte

            Dim myConn As New SqlConnection(SQL.Connection_String)
            myConn.Open()
            Dim sqlcmd As SqlCommand = New SqlCommand(SQLquery, myConn)
            sqlcmd.Parameters.Add(docfile)
            sqlcmd.ExecuteNonQuery()
            myConn.Close()
        Catch ex As Exception

        End Try
        loadFiles()
    End Sub

    Private Sub ToolStripButtonRefreshFiles_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRefreshFiles.Click
        loadFiles()
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

    Private Sub ToolStripButtonRemoveFiles_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRemoveFiles.Click
        If DotNet.IsConfirmed("Are you sure?") Then
            For Each dr As DataGridViewRow In DataGridViewFiles.SelectedRows
                SQL.Execute("Delete From " & dbTables & "_Files where id = '" & dr.Cells("ID").Value & "'")
            Next
            loadFiles()
        End If
    End Sub

End Class