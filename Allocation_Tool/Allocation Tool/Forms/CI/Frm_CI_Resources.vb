Public Class Frm_CI_Resources
    Friend dbTables As String = ""
    Friend Id_Project As Integer = 0
    Friend Id_Primary_Process As Integer = 0

    Dim dataTableTaskName As DataTable
    Dim dataTableTaskType As DataTable
    Dim dataTableEntryType As DataTable
    Dim dataServiceLine As DataTable
    Dim dataOwner As DataTable

    Dim userServiceLine(1, 1) As Boolean
    Dim setteo As Boolean = False

    Private Sub CheckBoxEndDate_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxEndDate.CheckedChanged
        If CheckBoxEndDate.CheckState = CheckState.Checked Then
            DTP_End.Enabled = True
        Else
            DTP_End.Enabled = False
        End If
    End Sub

    Private Sub Frm_CI_Resources_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearControls()
        loadData()
    End Sub

    Private Sub clearControls()
        setteo = False

        DataGridViewSelected.DataSource = Nothing
        ComboBoxTaskType.SelectedIndex = -1
        ComboBoxTaskName.SelectedIndex = -1
        ComboBoxEntryType.SelectedIndex = -1
        TextBoxMonthlyValue.Text = ""

        DTP_Start.Value = Now
        DTP_End.Value = Now
        For i As Integer = 0 To (CheckedListBoxOwner.Items.Count - 1)
            CheckedListBoxOwner.SetItemCheckState(i, CheckState.Unchecked)
        Next
        For i As Integer = 0 To (CheckedListBoxServiceLine.Items.Count - 1)
            CheckedListBoxServiceLine.SetItemCheckState(i, CheckState.Unchecked)
        Next

        loadData()
    End Sub

    Private Sub loadData()
        dataTableTaskName = SQL.Return_DataTable("select * from " & dbTables & "_Task_Name where ID_Primary_Process='" & Id_Primary_Process & "'")
        ComboBoxTaskName.DataSource = dataTableTaskName
        ComboBoxTaskName.DisplayMember = "Task_Name"
        ComboBoxTaskName.ValueMember = "ID"
        ComboBoxTaskName.SelectedIndex = -1

        dataTableTaskType = SQL.Return_DataTable("select * from " & dbTables & "_Task_Type")
        ComboBoxTaskType.DataSource = dataTableTaskType
        ComboBoxTaskType.DisplayMember = "Task_Type"
        ComboBoxTaskType.ValueMember = "ID"
        ComboBoxTaskType.SelectedIndex = -1

        dataTableEntryType = SQL.Return_DataTable("select * from Project_Entry_Type")
        ComboBoxEntryType.DataSource = dataTableEntryType
        ComboBoxEntryType.DisplayMember = "Entry_Type"
        ComboBoxEntryType.ValueMember = "ID"
        ComboBoxEntryType.SelectedIndex = -1

        dataServiceLine = SQL.Return_DataTable("select * from Project_Service_Line")
        CheckedListBoxServiceLine.DataSource = dataServiceLine
        CheckedListBoxServiceLine.DisplayMember = dataServiceLine.Columns(1).ColumnName.ToString
        CheckedListBoxServiceLine.ValueMember = dataServiceLine.Columns(0).ColumnName.ToString

        dataOwner = UsersInfo.PeerList(AppName)
        Dim rowUser As DataRow = dataOwner.NewRow
        rowUser.Item(0) = UsersInfo.TNumber
        rowUser.Item(1) = UsersInfo.Name
        dataOwner.Rows.InsertAt(rowUser, 0)
        Dim r As Integer = 0
        For Each row As DataRow In dataOwner.Rows
            dataOwner.Rows(r).Item(1) = row.Item(0) & " / " & row.Item(1)
            r = r + 1
        Next
        CheckedListBoxOwner.DataSource = dataOwner
        CheckedListBoxOwner.DisplayMember = dataOwner.Columns(1).ColumnName.ToString
        CheckedListBoxOwner.ValueMember = dataOwner.Columns(0).ColumnName.ToString

        DTP_Start.Value = Now
        DTP_End.Value = Now

        ReDim userServiceLine(CheckedListBoxOwner.Items.Count, CheckedListBoxServiceLine.Items.Count)
        setteo = True
    End Sub

    Private Sub TextBoxMonthlyValue_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxMonthlyValue.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub CheckedListBoxServiceLine_MouseUp(sender As Object, e As MouseEventArgs) Handles CheckedListBoxServiceLine.MouseUp
        If setteo Then
            For i As Integer = 0 To (CheckedListBoxServiceLine.Items.Count - 1)
                userServiceLine(CheckedListBoxOwner.SelectedIndex, i) = CheckedListBoxServiceLine.GetItemCheckState(i)
            Next
        End If
    End Sub

    Private Sub CheckedListBoxOwner_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBoxOwner.SelectedIndexChanged
        If setteo Then
            For i As Integer = 0 To (CheckedListBoxServiceLine.Items.Count - 1)
                CheckedListBoxServiceLine.SetItemChecked(i, userServiceLine(CheckedListBoxOwner.SelectedIndex, i))
            Next
        End If
    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        Dim bandera As Boolean = True

        If DotNet.IsEmpty(ComboBoxTaskType.Text) Then
            bandera = False
            LabelTaskType.ForeColor = Color.Red
        Else
            LabelTaskType.ForeColor = Color.Black
        End If

        If DotNet.IsEmpty(ComboBoxTaskName.Text) Then
            bandera = False
            LabelTaskName.ForeColor = Color.Red
        Else
            LabelTaskName.ForeColor = Color.Black
        End If

        If DotNet.IsEmpty(ComboBoxEntryType.Text) Then
            bandera = False
            LabelEntryType.ForeColor = Color.Red
        Else
            LabelEntryType.ForeColor = Color.Black
        End If

        If ComboBoxTaskType.Text <> "Ongoing" Then
            If DTP_Start.Value > DTP_End.Value Then
                bandera = False
                LabelStartDate.ForeColor = Color.Red
                CheckBoxEndDate.ForeColor = Color.Red
            Else
                LabelStartDate.ForeColor = Color.Black
                CheckBoxEndDate.ForeColor = Color.Black
            End If
        End If

        If (Trim(TextBoxMonthlyValue.Text.Length) = 0) Then
            bandera = False
            LabelMonthlyValue.ForeColor = Color.Red
        Else
            If (Convert.ToDecimal(TextBoxMonthlyValue.Text) <= 0) Then
                bandera = False
                LabelMonthlyValue.ForeColor = Color.Red
            Else
                LabelMonthlyValue.ForeColor = Color.Black
            End If
        End If

        If CheckedListBoxOwner.CheckedItems.Count <= 0 Then
            bandera = False
            GroupBoxOwnerList.ForeColor = Color.Red
        Else
            GroupBoxOwnerList.ForeColor = Color.Black
        End If

        Dim temp As Boolean = False
        For x As Integer = 0 To CheckedListBoxOwner.Items.Count
            For y As Integer = 0 To CheckedListBoxServiceLine.Items.Count
                If userServiceLine(x, y) Then
                    temp = True
                End If
            Next
        Next
        If Not temp Then
            bandera = False
            GroupBoxServiceLine.ForeColor = Color.Red
        Else
            GroupBoxServiceLine.ForeColor = Color.Black
        End If

        'Tabs
        'Daily
        If TabControlRecipe.SelectedIndex = 0 Then
            If RadioButtonDailyEvery.Checked Then
                If Convert.ToDecimal(TextBoxDaily.Text) <= 0 Then
                    bandera = False
                    TextBoxDaily.ForeColor = Color.Red
                Else
                    TextBoxDaily.ForeColor = Color.Black
                End If
            Else
                TextBoxDaily.ForeColor = Color.Black
            End If
        End If
        'Weekly
        If TabControlRecipe.SelectedIndex = 1 Then
            If Convert.ToDecimal(TextBoxWeeklyRecur.Text) <= 0 Then
                bandera = False
                TextBoxWeeklyRecur.ForeColor = Color.Red
            Else
                TextBoxWeeklyRecur.ForeColor = Color.Black
            End If
            If (Not CheckBoxWeeklySunday.Checked And Not CheckBoxWeeklyMonday.Checked And Not CheckBoxWeeklyThursday.Checked And Not CheckBoxWeeklyWednesday.Checked And Not CheckBoxWeeklyTuesday.Checked And Not CheckBoxWeeklyFriday.Checked And Not CheckBoxWeeklySaturday.Checked) Then
                bandera = False
                CheckBoxWeeklySunday.ForeColor = Color.Red
                CheckBoxWeeklyMonday.ForeColor = Color.Red
                CheckBoxWeeklyThursday.ForeColor = Color.Red
                CheckBoxWeeklyWednesday.ForeColor = Color.Red
                CheckBoxWeeklyTuesday.ForeColor = Color.Red
                CheckBoxWeeklyFriday.ForeColor = Color.Red
                CheckBoxWeeklySaturday.ForeColor = Color.Red
            Else
                CheckBoxWeeklySunday.ForeColor = Color.Black
                CheckBoxWeeklyMonday.ForeColor = Color.Black
                CheckBoxWeeklyThursday.ForeColor = Color.Black
                CheckBoxWeeklyWednesday.ForeColor = Color.Black
                CheckBoxWeeklyTuesday.ForeColor = Color.Black
                CheckBoxWeeklyFriday.ForeColor = Color.Black
                CheckBoxWeeklySaturday.ForeColor = Color.Black
            End If
        End If
        'Monthly
        If TabControlRecipe.SelectedIndex = 2 Then
            If RadioButtonMonthlyDay.Checked Then
                RadioButtonMonthly.ForeColor = Color.Black

                If (Convert.ToDecimal(TextBoxMonthlyNumDay.Text) <= 0) Or (Convert.ToDecimal(TextBoxMonthlyNumMonths.Text) <= 0) Then
                    bandera = False
                    RadioButtonMonthlyDay.ForeColor = Color.Red
                Else
                    RadioButtonMonthlyDay.ForeColor = Color.Black
                End If
            ElseIf RadioButtonMonthly.Checked Then
                RadioButtonMonthlyDay.ForeColor = Color.Black

                If DotNet.IsEmpty(ComboBoxMonthlyOrd.Text) Or DotNet.IsEmpty(ComboBoxMonthlyOption.Text) Or Convert.ToDecimal(TextBoxMonthlyNum.Text) <= 0 Then
                    bandera = False
                    RadioButtonMonthly.ForeColor = Color.Red
                Else
                    RadioButtonMonthly.ForeColor = Color.Black
                End If
            End If
        End If
        'Yearly
        If TabControlRecipe.SelectedIndex = 3 Then
            If Convert.ToDecimal(TextBoxYearlyYears.Text) <= 0 Then
                bandera = False
                TextBoxYearlyYears.ForeColor = Color.Red
            Else
                TextBoxYearlyYears.ForeColor = Color.Black
            End If

            If RadioButtonYearlyOn.Checked Then
                RadioButtonYearlyOnThe.ForeColor = Color.Black
                
                If DotNet.IsEmpty(ComboBoxYearlyMonth.Text) Or Convert.ToDecimal(TextBoxYearlyDate.Text) <= 0 Then
                    bandera = False
                    RadioButtonYearlyOn.ForeColor = Color.Red
                Else
                    RadioButtonYearlyOn.ForeColor = Color.Black
                End If
            ElseIf RadioButtonYearlyOnThe.Checked Then
                RadioButtonYearlyOn.ForeColor = Color.Black

                If DotNet.IsEmpty(ComboBoxYearlyOrd.Text) Or DotNet.IsEmpty(ComboBoxYearlyDay.Text) Or DotNet.IsEmpty(ComboBoxYearlyMonths.Text) Then
                    bandera = False
                    RadioButtonYearlyOnThe.ForeColor = Color.Red
                Else
                    RadioButtonYearlyOnThe.ForeColor = Color.Black
                End If
            End If
        End If

        If bandera Then
            If ComboBoxTaskType.Text <> "Ongoing" And CheckBoxEndDate.CheckState = CheckState.Unchecked Then
                MessageBox.Show("Should indicate an end date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                bandera = False
                CheckBoxEndDate.ForeColor = Color.Red
            Else
                CheckBoxEndDate.ForeColor = Color.Black

                Dim data As New DataTable
                data.Columns.Add("Project ID")
                data.Columns.Add("Id Task Type")
                data.Columns.Add("Task Type")
                data.Columns.Add("Task Name")
                data.Columns.Add("Owner Name")
                data.Columns.Add("Owner")
                data.Columns.Add("Start Date")
                data.Columns.Add("End Date")
                data.Columns.Add("Entry Type")
                data.Columns.Add("Id Entry Type")
                data.Columns.Add("Value")
                data.Columns.Add("Service Line")
                data.Columns.Add("Id Service Line")
                data.Columns.Add("Recurrence")
                data.Columns.Add("Recurrence Text")
                Dim row As DataRow
                For i As Integer = 0 To (CheckedListBoxOwner.Items.Count - 1)
                    If CheckedListBoxOwner.GetItemCheckState(i) Then
                        Dim owner As DataRowView = CheckedListBoxOwner.Items.Item(i)
                        CheckedListBoxOwner.SelectedIndex = i
                        CheckedListBoxServiceLine_MouseUp(sender, e)
                        For Each service As DataRowView In CheckedListBoxServiceLine.CheckedItems
                            row = data.NewRow
                            row("Project ID") = Id_Project
                            row("Task Name") = ComboBoxTaskName.Text
                            row("Id Task Type") = ComboBoxTaskType.SelectedValue
                            row("Task Type") = ComboBoxTaskType.Text

                            Dim str() As String = Split(owner.Item(1).ToString(), " / ")
                            row("Owner Name") = str(1)

                            row("Owner") = owner.Item(0).ToString
                            row("Start Date") = DTP_Start.Value.Date.ToString("MM/dd/yyyy")
                            row("End Date") = DTP_End.Value.Date.ToString("MM/dd/yyyy")
                            row("Entry Type") = ComboBoxEntryType.Text
                            row("Id Entry Type") = ComboBoxEntryType.SelectedValue
                            row("Value") = TextBoxMonthlyValue.Text
                            row("Service Line") = service.Item(1).ToString
                            row("Id Service Line") = service.Item(0).ToString

                            ' Recipe
                            Dim recipe As String = ""
                            'Daily
                            If TabControlRecipe.SelectedIndex = 0 Then
                                recipe = recipe & "DAILY"
                                recipe = recipe & "," & DTP_Start.Value.Date.ToString("MM/dd/yyyy")

                                If RadioButtonDailyEvery.Checked Then
                                    recipe = recipe & ",1," & Trim(TextBoxDaily.Text)
                                ElseIf RadioButtonDailyWeekday.Checked Then
                                    recipe = recipe & ",2,WEEKDAY"
                                End If

                                If CheckBoxEndDate.Checked Then
                                    recipe = recipe & "," & DTP_End.Value.Date.ToString("MM/dd/yyyy")
                                End If
                            End If
                            'Weekly
                            If TabControlRecipe.SelectedIndex = 1 Then
                                recipe = recipe & "WEEKLY"
                                recipe = recipe & "," & DTP_Start.Value.Date.ToString("MM/dd/yyyy")

                                recipe = recipe & "," & TextBoxWeeklyRecur.Text

                                If CheckBoxWeeklySunday.Checked Then
                                    recipe = recipe & ",SUNDAY"
                                End If
                                If CheckBoxWeeklyMonday.Checked Then
                                    recipe = recipe & ",MONDAY"
                                End If
                                If CheckBoxWeeklyTuesday.Checked Then
                                    recipe = recipe & ",TUESDAY"
                                End If
                                If CheckBoxWeeklyWednesday.Checked Then
                                    recipe = recipe & ",WEDNESDAY"
                                End If
                                If CheckBoxWeeklyThursday.Checked Then
                                    recipe = recipe & ",THURSDAY"
                                End If
                                If CheckBoxWeeklyFriday.Checked Then
                                    recipe = recipe & ",FRIDAY"
                                End If
                                If CheckBoxWeeklySaturday.Checked Then
                                    recipe = recipe & ",SATURDAY"
                                End If

                                If CheckBoxEndDate.Checked Then
                                    recipe = recipe & "," & DTP_End.Value.Date.ToString("MM/dd/yyyy")
                                End If
                            End If
                            'Monthly
                            If TabControlRecipe.SelectedIndex = 2 Then
                                recipe = recipe & "MONTHLY"
                                recipe = recipe & "," & DTP_Start.Value.Date.ToString("MM/dd/yyyy")

                                If RadioButtonMonthlyDay.Checked Then
                                    recipe = recipe & ",1," & TextBoxMonthlyNumDay.Text
                                    recipe = recipe & "," & TextBoxMonthlyNumMonths.Text
                                ElseIf RadioButtonMonthly.Checked Then
                                    recipe = recipe & ",2," & ComboBoxMonthlyOrd.Text.ToUpper
                                    recipe = recipe & "," & ComboBoxMonthlyOption.Text.ToUpper
                                    recipe = recipe & "," & TextBoxMonthlyNum.Text
                                End If

                                If CheckBoxEndDate.Checked Then
                                    recipe = recipe & "," & DTP_End.Value.Date.ToString("MM/dd/yyyy")
                                End If
                            End If
                            'Yearly
                            If TabControlRecipe.SelectedIndex = 3 Then
                                recipe = recipe & "YEARLY"
                                recipe = recipe & "," & DTP_Start.Value.Date.ToString("MM/dd/yyyy")

                                recipe = recipe & "," & TextBoxYearlyYears.Text

                                If RadioButtonYearlyOn.Checked Then
                                    recipe = recipe & ",1," & ComboBoxYearlyMonth.Text.ToUpper
                                    recipe = recipe & "," & TextBoxYearlyDate.Text
                                ElseIf RadioButtonYearlyOnThe.Checked Then
                                    recipe = recipe & ",2," & ComboBoxYearlyOrd.Text.ToUpper
                                    recipe = recipe & "," & ComboBoxYearlyDay.Text.ToUpper
                                    recipe = recipe & "," & ComboBoxYearlyMonths.Text.ToUpper
                                End If

                                If CheckBoxEndDate.Checked Then
                                    recipe = recipe & "," & DTP_End.Value.Date.ToString("MM/dd/yyyy")
                                End If
                            End If

                            row("Recurrence") = recipe

                            Dim words() As String = Split(recipe, ",")
                            Dim recipeText As String = ""

                            If words(0) = "DAILY" Then
                                If words(2) = "1" Then
                                    recipeText = "Occurs daily, every " & words(3) & " day(s) from " & words(1)
                                    If CheckBoxEndDate.Checked Then
                                        recipeText = recipeText & " until " & words(words.Count - 1)
                                    End If
                                ElseIf words(2) = "2" Then
                                    recipeText = "Occurs daily, every weekday from " & words(1)
                                    If CheckBoxEndDate.Checked Then
                                        recipeText = recipeText & " until " & words(words.Count - 1)
                                    End If
                                End If
                            ElseIf words(0) = "WEEKLY" Then
                                recipeText = "Occurs weekly, every " & words(2) & " week(s) on "
                                Dim days As String = ""
                                For c As Integer = 3 To (words.Count - 2)
                                    If days.Length > 0 Then
                                        days = days & ", "
                                    End If
                                    days = days & words(c).ToLower
                                Next
                                recipeText = recipeText & " " & days & " from " & words(1)
                                If CheckBoxEndDate.Checked Then
                                    recipeText = recipeText & " until " & words(words.Count - 1)
                                End If
                            ElseIf words(0) = "MONTHLY" Then
                                If words(2) = "1" Then
                                    recipeText = "Occurs monthly, on " & words(3) & " of every " & words(4) & " month(s) from " & words(1)
                                    If CheckBoxEndDate.Checked Then
                                        recipeText = recipeText & " until " & words(words.Count - 1)
                                    End If
                                ElseIf words(2) = "2" Then
                                    recipeText = "Occurs monthly, the " & words(3).ToLower & " " & words(4).ToLower & " of every " & words(5) & " month(s) from " & words(1)
                                    If CheckBoxEndDate.Checked Then
                                        recipeText = recipeText & " until " & words(words.Count - 1)
                                    End If
                                End If
                            ElseIf words(0) = "YEARLY" Then
                                recipeText = "Occurs every " & words(2) & " year(s) "
                                If words(2) = "1" Then
                                    recipeText = recipeText & "on " & words(4).ToLower & " " & words(5) & " from " & words(1)
                                    If CheckBoxEndDate.Checked Then
                                        recipeText = recipeText & " until " & words(words.Count - 1)
                                    End If
                                ElseIf words(2) = "2" Then
                                    recipeText = recipeText & "on the " & words(4).ToLower & " " & words(5).ToLower & " of " & words(6).ToLower & " from " & words(1)
                                    If CheckBoxEndDate.Checked Then
                                        recipeText = recipeText & " until " & words(words.Count - 1)
                                    End If
                                End If
                            End If

                            row("Recurrence Text") = recipeText

                            data.Rows.Add(row)
                        Next
                    End If
                Next

                DataGridViewSelected.DataSource = data
                DataGridViewSelected.Columns("Project ID").Visible = False
                DataGridViewSelected.Columns("Id Task Type").Visible = False
                DataGridViewSelected.Columns("Id Entry Type").Visible = False
                DataGridViewSelected.Columns("Id Service Line").Visible = False
                DataGridViewSelected.Columns("Recurrence").Visible = False

                DataGridViewSelected.Columns("Owner").HeaderText = "Owner TNumber"
                DataGridViewSelected.Columns("Recurrence Text").HeaderText = "Recurrence"

                For i As Integer = 0 To (DataGridViewSelected.Columns.Count - 1)
                    DataGridViewSelected.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                Next
            End If
        Else
            MessageBox.Show("All fields are mandatory, please fill out the ones highlighted in red.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ToolStripButtonCancel_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCancel.Click
        clearControls()
    End Sub

    Private Sub ButtonRemove_Click(sender As Object, e As EventArgs) Handles ButtonRemove.Click
        If DataGridViewSelected.SelectedRows.Count > 0 Then
            For Each dr As DataGridViewRow In DataGridViewSelected.SelectedRows
                If (DataGridViewSelected.Rows.Count > 0) Then
                    DataGridViewSelected.Rows.Remove(dr)
                End If
            Next
        End If
    End Sub

    Private Sub TextBoxDaily_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxDaily.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxWeeklyRecur_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxWeeklyRecur.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxMonthlyNumDay_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxMonthlyNumDay.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxMonthlyNumMonths_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxMonthlyNumMonths.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxMonthlyNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxMonthlyNum.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxYearlyYears_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxYearlyYears.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxYearlyDate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxYearlyDate.KeyPress
        If Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    Private Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        Dim count As Integer = DataGridViewSelected.Rows.Count
        If count > 0 Then
            If DotNet.IsConfirmed("Are you sure you want to include this resource(s)?") Then
                Dim retorno As Integer
                For Each dr As DataGridViewRow In DataGridViewSelected.Rows
                    retorno = SQL.Execute("insert into " & dbTables & "_Resources (" & _
                                                "Project_ID," & _
                                                "Task_Name," & _
                                                "Task_Type," & _
                                                "Owner_Name," & _
                                                "Owner," & _
                                                "Start_Date," & _
                                                "End_Date," & _
                                                "Entry_Type," & _
                                                "Value," & _
                                                "Service_Line, " & _
                                                "Recurrence, " & _
                                                "Status " & _
                                            ") OUTPUT Inserted.ID values (" & _
                                                "'" & dr.Cells("Project ID").Value.ToString & "'," & _
                                                "'" & dr.Cells("Task Name").Value.ToString & "'," & _
                                                "'" & dr.Cells("Id Task Type").Value.ToString & "'," & _
                                                "'" & dr.Cells("Owner Name").Value.ToString & "'," & _
                                                "'" & dr.Cells("Owner").Value.ToString & "'," & _
                                                "'" & dr.Cells("Start Date").Value.ToString & "'," & _
                                                "'" & dr.Cells("End Date").Value.ToString & "'," & _
                                                "'" & dr.Cells("Id Entry Type").Value.ToString & "'," & _
                                                "'" & dr.Cells("Value").Value.ToString & "'," & _
                                                "'" & dr.Cells("Id Service Line").Value.ToString & "'," & _
                                                "'" & dr.Cells("Recurrence").Value.ToString & "'," & _
                                                "1" & _
                                            ")")
                    SQL.Execute("insert into " & dbTables & "_Resources_Historical (" & _
                                    "ID_Resource, " & _
                                    "New_Value, " & _
                                    "Date, " & _
                                    "Recurrence) values (" & _
                                    "'" & retorno & "', " & _
                                    "'" & dr.Cells("Value").Value.ToString & "', " & _
                                    "GETDATE(), " & _
                                    "'" & dr.Cells("Recurrence").Value.ToString & "')")
                Next
                Frm_CI_PF.loadResources(Id_Project)
            End If
        End If
    End Sub
End Class