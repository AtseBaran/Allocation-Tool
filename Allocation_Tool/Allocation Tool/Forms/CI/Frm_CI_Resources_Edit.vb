Public Class Frm_CI_Resources_Edit
    Friend id_resource As Integer
    Friend entry_type As String
    Friend old_value As Decimal

    Friend dbTables As String = ""

    Dim dataTable As DataRow

    Private Sub Frm_CI_Resources_Edit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBoxOldValue.Text = old_value

        dataTable = SQL.Return_DataRow("select " & _
                                            "ID, " & _
                                            "Start_Date, " & _
                                            "End_Date, " & _
                                            "Recurrence " & _
                                        "from " & _
                                            dbTables & "_Resources " & _
                                        "where " & _
                                            "ID=" & id_resource)

        DTP_Start.Value = dataTable.Item(1)
        DTP_End.Value = dataTable.Item(2)

        Dim recurrence() As String = Split(dataTable.Item(3), ",")

        If IsDate(recurrence(recurrence.Length - 1)) Then
            CheckBoxEndDate.CheckState = CheckState.Checked
        Else
            CheckBoxEndDate.CheckState = CheckState.Unchecked
        End If

        If recurrence(0) = "DAILY" Then
            TabControlRecipe.SelectTab(0)
            If recurrence(2) = "1" Then
                RadioButtonDailyEvery.Checked = True
                TextBoxDaily.Text = recurrence(3)
            ElseIf recurrence(2) = 2 Then
                RadioButtonDailyWeekday.Checked = True
            End If
        ElseIf recurrence(0) = "WEEKLY" Then
            TabControlRecipe.SelectTab(1)
            TextBoxWeeklyRecur.Text = recurrence(2)
            For Each wDay As String In recurrence
                If wDay = "SUNDAY" Then
                    CheckBoxWeeklySunday.CheckState = CheckState.Checked
                End If
                If wDay = "MONDAY" Then
                    CheckBoxWeeklyMonday.CheckState = CheckState.Checked
                End If
                If wDay = "TUESDAY" Then
                    CheckBoxWeeklyTuesday.CheckState = CheckState.Checked
                End If
                If wDay = "WEDNESDAY" Then
                    CheckBoxWeeklyWednesday.CheckState = CheckState.Checked
                End If
                If wDay = "THURSDAY" Then
                    CheckBoxWeeklyThursday.CheckState = CheckState.Checked
                End If
                If wDay = "FRIDAY" Then
                    CheckBoxWeeklyFriday.CheckState = CheckState.Checked
                End If
                If wDay = "SATURDAY" Then
                    CheckBoxWeeklySaturday.CheckState = CheckState.Checked
                End If
            Next
        ElseIf recurrence(0) = "MONTHLY" Then
            TabControlRecipe.SelectTab(2)
            If recurrence(2) = "1" Then
                RadioButtonMonthlyDay.Checked = True
                TextBoxMonthlyNumDay.Text = recurrence(3)
                TextBoxMonthlyNumMonths.Text = recurrence(4)
            ElseIf recurrence(2) = "2" Then
                RadioButtonMonthly.Checked = True
                ComboBoxMonthlyOrd.Text = recurrence(3)
                ComboBoxMonthlyOption.Text = recurrence(4)
                TextBoxMonthlyNum.Text = recurrence(5)
            End If
        ElseIf recurrence(0) = "YEARLY" Then
            TabControlRecipe.SelectTab(3)
            TextBoxYearlyYears.Text = recurrence(2)
            If recurrence(3) = "1" Then
                RadioButtonYearlyOn.Checked = True
                ComboBoxYearlyMonth.Text = recurrence(4)
                TextBoxYearlyDate.Text = recurrence(5)
            ElseIf recurrence(3) = "2" Then
                RadioButtonYearlyOnThe.Checked = True
                ComboBoxYearlyOrd.Text = recurrence(4)
                ComboBoxYearlyDay.Text = recurrence(5)
                ComboBoxYearlyMonths.Text = recurrence(6)
            End If
        End If
    End Sub

    Private Sub ToolStripButtonHistory_Click(sender As Object, e As EventArgs) Handles ToolStripButtonHistory.Click
        Dim form As New Frm_CI_Resources_History
        form.dbTables = dbTables
        form.id_resource = id_resource
        form.ShowDialog(Me)
        form.Dispose()
    End Sub

    Private Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        Dim bandera As Boolean = True

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

        If Trim(TextBoxComments.Text).Length = 0 Then
            bandera = False
            LabelComments.ForeColor = Color.Red
        Else
            LabelComments.ForeColor = Color.Black
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

        If Not bandera Then
            MessageBox.Show("Please add value and comment, they are mandatory fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If DotNet.IsConfirmed("Are you sure?") Then

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

                SQL.Execute("update " & dbTables & "_Resources set " & _
                            "Value='" & Trim(TextBoxMonthlyValue.Text) & "', " & _
                            "Comment='" & Trim(TextBoxComments.Text) & "', " & _
                            "Recurrence='" & recipe & "' " & _
                            " where " & _
                            "ID='" & id_resource & "'")

                SQL.Execute("insert into " & dbTables & "_Resources_Historical ( " & _
                                    "ID_Resource, " & _
                                    "New_Value, " & _
                                    "Old_Value, " & _
                                    "Date, " & _
                                    "Recurrence, " & _
                                    "Comment) values ( " & _
                                    "'" & id_resource & "', " & _
                                    "'" & Trim(TextBoxMonthlyValue.Text) & "', " & _
                                    "'" & Trim(TextBoxOldValue.Text) & "', " & _
                                    "GETDATE(), " & _
                                    "'" & recipe & "', " & _
                                    "'" & Trim(TextBoxComments.Text) & "')")
                Frm_CI_PF.loadProject()
                Me.Close()
            End If
        End If

    End Sub
End Class