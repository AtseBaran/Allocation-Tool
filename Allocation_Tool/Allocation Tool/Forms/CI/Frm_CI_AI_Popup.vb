Public Class Frm_CI_AI_Popup
    Friend tab As Integer
    Friend dateInput As Date

    Friend id_resource As Integer
    Friend id_project As Integer 'Get from resources

    Friend dbTables As String = ""
    Friend windowTitle As String = ""

    Private Sub Frm_CI_AI_Popup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = windowTitle

        Dim datarow As DataRow = SQL.Return_DataRow("select Project_ID from CI_Resources where ID='" & id_resource & "'")
        id_project = datarow.Item("Project_ID")

        Me.ValueTab1.Value = 0

        If tab = 0 Then
            Me.TabControl.TabPages.RemoveAt(1)
        Else
            Me.TabControl.TabPages.RemoveAt(0)
        End If

        loadData()
        DTP_Start_Date_ValueChanged(sender, e)
    End Sub

    Private Sub loadData()
        DTP_Actual_Date.Value = DateSerial(dateInput.Year, dateInput.Month, dateInput.Day)
        DTP_Start_Date.Value = Date.Now
        DTP_End_Date.Value = Date.Now
        DTPVH.Value = Date.Now

        ValueTab1.Value = 0
        ValueTab2.Value = 0

        TextBoxCommentTab1.Text = ""
        TextBoxCommentTab2.Text = ""

        CheckBoxVHTab1.CheckState = CheckState.Unchecked
        CheckBoxVHTab2.CheckState = CheckState.Unchecked

        CheckBoxVHTab2.Enabled = True
    End Sub

    Private Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        Dim bandera As Boolean = False

        If tab = 0 Then
            If CheckBoxVHTab1.CheckState = CheckState.Unchecked Then
                If ValueTab1.Value = 0 And Trim(TextBoxCommentTab1.Text) = "" Then
                    MessageBox.Show("Comment field is mandatory when Value is equal to zero, please fill it out.")
                    bandera = True
                End If
            End If
        ElseIf tab = 1 Then
            If ValueTab2.Value = 0 And Trim(TextBoxCommentTab2.Text) = "" And CheckBoxVHTab2.CheckState = CheckState.Unchecked Then
                MessageBox.Show("Comment field is mandatory when Value is equal to zero, please fill it out.")
                bandera = True
            ElseIf CheckBoxVHTab2.CheckState = CheckState.Checked Then
                Dim dTemp As Date = DTPVH.Value.Date.AddDays(VHDays.Value - 1)
                If Not (DTPVH.Value.Date >= DTP_Start_Date.Value.Date And DTPVH.Value.Date <= DTP_End_Date.Value.Date) Then
                    MessageBox.Show("The date of vacations / holiday is out of week, please check the date.")
                    bandera = True
                ElseIf VHDays.Value < 1 Or VHDays.Value > 5 Then
                    MessageBox.Show("Number of vacation/holiday days are higher than the working days in the time frame selected, please check.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    bandera = True
                ElseIf (dTemp > DTP_End_Date.Value.Date) Then
                    MessageBox.Show("Number of vacation/holiday days are higher than the working days in the time frame selected, please check.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    bandera = True
                End If
            End If
        End If

        If Not bandera Then
            If DotNet.IsConfirmed("Are you sure?") Then
                'Save

                If tab = 0 Then
                    If CheckBoxVHTab1.Checked Then
                        TextBoxCommentTab1.Text = "Vacations - Holydays"
                    End If
                    'Verify Update or Insert
                    Dim dataTableTemp As DataTable = SQL.Return_DataTable("select " & _
                                                                                "ID " & _
                                                                          "from " & _
                                                                                dbTables & "_Actuals " & _
                                                                          "where " & _
                                                                                "Resource_ID='" & id_resource & "' and " & _
                                                                                "Actual_Date='" & DateSerial(DTP_Actual_Date.Value.Year, DTP_Actual_Date.Value.Month, DTP_Actual_Date.Value.Day) & "' and " & _
                                                                                "Project_ID='" & id_project & "'")
                    If dataTableTemp Is Nothing Or dataTableTemp.Rows.Count = 0 Then
                        SQL.Execute("insert into " & dbTables & "_Actuals ( " & _
                                    "Project_ID, " & _
                                    "Resource_ID, " & _
                                    "Actual_Date, " & _
                                    "Value, " & _
                                    "Comment, " & _
                                    "Vacation_Holiday " & _
                                    ") values ( " & _
                                    "'" & id_project & "', " & _
                                    "'" & id_resource & "', " & _
                                    "'" & DTP_Actual_Date.Value & "', " & _
                                    "'" & ValueTab1.Value & "', " & _
                                    "'" & Trim(TextBoxCommentTab1.Text) & "', " & _
                                    "'" & Trim(CheckBoxVHTab1.CheckState) & "' " & _
                                    ")")
                    Else
                        SQL.Execute("update " & _
                                        dbTables & "_Actuals " & _
                                    "set " & _
                                        "Value= Value + " & ValueTab1.Value & ", " & _
                                        "Comment='" & Trim(TextBoxCommentTab1.Text) & "', " & _
                                        "Vacation_Holiday='" & Trim(CheckBoxVHTab1.CheckState) & "' " & _
                                    "where " & _
                                        "Project_ID='" & id_project & "' and " & _
                                        "Resource_ID='" & id_resource & "' and " & _
                                        "Actual_Date='" & DateSerial(DTP_Actual_Date.Value.Year, DTP_Actual_Date.Value.Month, DTP_Actual_Date.Value.Day) & "'")
                    End If
                    'Insert History
                    SQL.Execute("insert into " & dbTables & "_Actuals_History ( " & _
                                    "Project_ID, " & _
                                    "Resource_ID, " & _
                                    "Actual_Date, " & _
                                    "Value, " & _
                                    "Comment, " & _
                                    "Vacation_Holiday " & _
                                    ") values ( " & _
                                    "'" & id_project & "', " & _
                                    "'" & id_resource & "', " & _
                                    "'" & DTP_Actual_Date.Value & "', " & _
                                    "'" & ValueTab1.Value & "', " & _
                                    "'" & Trim(TextBoxCommentTab1.Text) & "', " & _
                                    "'" & Trim(CheckBoxVHTab1.CheckState) & "' " & _
                                    ")")
                ElseIf tab = 1 Then 'Validate data for each day
                    Dim startDate As Date = DTP_Start_Date.Value
                    Dim endDate As Date = DTP_End_Date.Value
                    Dim curDate As Date = startDate
                    Dim vsDate As Date = DTPVH.Value.Date
                    Dim veDate As Date = DTPVH.Value.Date.AddDays(VHDays.Value - 1)

                    Dim recipe As String
                    Dim dataTable As DataTable = SQL.Return_DataTable("select recurrence from " & dbTables & "_Resources where ID='" & id_resource & "'")
                    recipe = dataTable.Rows(0).Item(0).ToString

                    While (curDate <= endDate)
                        If curDate.Date >= vsDate And curDate.Date <= veDate Then

                            If getDates(DateSerial(curDate.Year, curDate.Month, curDate.Day), recipe) Then
                                'Verify Update or Insert
                                Dim dataTableTemp As DataTable = SQL.Return_DataTable("select " & _
                                                                                "ID " & _
                                                                          "from " & _
                                                                                dbTables & "_Actuals " & _
                                                                          "where " & _
                                                                                "Resource_ID='" & id_resource & "' and " & _
                                                                                "Actual_Date='" & DateSerial(curDate.Year, curDate.Month, curDate.Day) & "' and " & _
                                                                                "Project_ID='" & id_project & "'")
                                If dataTableTemp Is Nothing Or dataTableTemp.Rows.Count = 0 Then
                                    SQL.Execute("insert into " & dbTables & "_Actuals ( " & _
                                                "Project_ID, " & _
                                                "Resource_ID, " & _
                                                "Actual_Date, " & _
                                                "Value, " & _
                                                "Comment, " & _
                                                "Vacation_Holiday " & _
                                                ") values ( " & _
                                                "'" & id_project & "', " & _
                                                "'" & id_resource & "', " & _
                                                "'" & DateSerial(curDate.Year, curDate.Month, curDate.Day) & "', " & _
                                                "'0', " & _
                                                "'Vacations - Holydays', " & _
                                                "'1' " & _
                                                ")")
                                Else
                                    SQL.Execute("update " & _
                                        dbTables & "_Actuals " & _
                                    "set " & _
                                        "Value='0', " & _
                                        "Comment='Vacations - Holidays', " & _
                                        "Vacation_Holiday='1' " & _
                                    "where " & _
                                        "Project_ID='" & id_project & "' and " & _
                                        "Resource_ID='" & id_resource & "' and " & _
                                        "Actual_Date='" & DateSerial(curDate.Year, curDate.Month, curDate.Day) & "'")
                                End If
                                'Insert History
                                SQL.Execute("insert into " & dbTables & "_Actuals_History ( " & _
                                                "Project_ID, " & _
                                                "Resource_ID, " & _
                                                "Actual_Date, " & _
                                                "Value, " & _
                                                "Comment, " & _
                                                "Vacation_Holiday " & _
                                                ") values ( " & _
                                                "'" & id_project & "', " & _
                                                "'" & id_resource & "', " & _
                                                "'" & curDate & "', " & _
                                                "'0', " & _
                                                "'Vacations - Holydays', " & _
                                                "'1' " & _
                                                ")")
                            End If
                        Else
                            If getDates(DateSerial(curDate.Year, curDate.Month, curDate.Day), recipe) Then
                                'Verify Update or Insert
                                Dim dataTableTemp As DataTable = SQL.Return_DataTable("select " & _
                                                                                "ID " & _
                                                                          "from " & _
                                                                                dbTables & "_Actuals " & _
                                                                          "where " & _
                                                                                "Resource_ID='" & id_resource & "' and " & _
                                                                                "Actual_Date='" & DateSerial(curDate.Year, curDate.Month, curDate.Day) & "' and " & _
                                                                                "Project_ID='" & id_project & "'")
                                If dataTableTemp Is Nothing Or dataTableTemp.Rows.Count = 0 Then
                                    SQL.Execute("insert into " & dbTables & "_Actuals ( " & _
                                                "Project_ID, " & _
                                                "Resource_ID, " & _
                                                "Actual_Date, " & _
                                                "Value, " & _
                                                "Comment, " & _
                                                "Vacation_Holiday " & _
                                                ") values ( " & _
                                                "'" & id_project & "', " & _
                                                "'" & id_resource & "', " & _
                                                "'" & DateSerial(curDate.Year, curDate.Month, curDate.Day) & "', " & _
                                                "'" & ValueTab2.Value & "', " & _
                                                "'" & Trim(TextBoxCommentTab2.Text) & "', " & _
                                                "'0' " & _
                                                ")")
                                Else
                                    SQL.Execute("update " & _
                                        dbTables & "_Actuals " & _
                                    "set " & _
                                        "Value= Value + " & ValueTab2.Value & ", " & _
                                        "Comment='" & Trim(TextBoxCommentTab1.Text) & "', " & _
                                        "Vacation_Holiday='" & Trim(CheckBoxVHTab1.CheckState) & "' " & _
                                    "where " & _
                                        "Project_ID='" & id_project & "' and " & _
                                        "Resource_ID='" & id_resource & "' and " & _
                                        "Actual_Date='" & DateSerial(curDate.Year, curDate.Month, curDate.Day) & "'")
                                End If
                                'Insert History
                                SQL.Execute("insert into " & dbTables & "_Actuals_History ( " & _
                                                "Project_ID, " & _
                                                "Resource_ID, " & _
                                                "Actual_Date, " & _
                                                "Value, " & _
                                                "Comment, " & _
                                                "Vacation_Holiday " & _
                                                ") values ( " & _
                                                "'" & id_project & "', " & _
                                                "'" & id_resource & "', " & _
                                                "'" & DateSerial(curDate.Year, curDate.Month, curDate.Day) & "', " & _
                                                "'" & ValueTab2.Value & "', " & _
                                                "'" & Trim(TextBoxCommentTab2.Text) & "', " & _
                                                "'0' " & _
                                                ")")
                            End If
                        End If
                        curDate = curDate.AddDays(1)
                    End While

                End If

                loadData()
                Frm_CI_AI.loadActuals()
                Me.Close()

            End If
        End If
    End Sub

    Private Sub ToolStripButtonCancel_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCancel.Click
        If DotNet.IsConfirmed("All data will be lost, are you sure?") Then
            loadData()
        End If
    End Sub

    Private Sub CheckBoxVHTab1_CheckedChanged(sender As Object, e As EventArgs)
        If CheckBoxVHTab1.CheckState = CheckState.Checked Then
            ValueTab1.Enabled = False
            ValueTab1.Value = 0
            TextBoxCommentTab1.Enabled = False
            TextBoxCommentTab1.Text = ""
        Else
            ValueTab1.Enabled = True
            ValueTab1.Value = 0
            TextBoxCommentTab1.Enabled = True
            TextBoxCommentTab1.Text = ""
        End If
    End Sub

    Private Sub CheckBoxVHTab2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxVHTab2.CheckedChanged
        If CheckBoxVHTab2.CheckState = CheckState.Checked Then
            DTPVH.Enabled = True
            DTPVH.Value = Date.Now
            VHDays.Enabled = True
            VHDays.Value = 1
        Else
            DTPVH.Enabled = False
            DTPVH.Value = Date.Now
            VHDays.Enabled = False
            VHDays.Value = 1
        End If
        sender.Enabled = True
    End Sub

    Private Sub ToolStripButtonHistory_Click(sender As Object, e As EventArgs) Handles ToolStripButtonHistory.Click
        Dim form As New Frm_CI_AI_History

        form.dbTables = dbTables
        form.id_project = id_project
        form.id_resource = id_resource
        form.ShowDialog(Me)
        form.Dispose()
    End Sub

    Private Sub DTP_Start_Date_ValueChanged(sender As Object, e As EventArgs) Handles DTP_Start_Date.ValueChanged
        If DTP_Start_Date.Value < Frm_CI_AI.DTP_Start.Value Or DTP_Start_Date.Value > Frm_CI_AI.DTP_End.Value Then
            Dim today As Date = dateInput
            Dim dayDiff As Integer = today.DayOfWeek - DayOfWeek.Monday
            Dim monday As Date = today.AddDays(-dayDiff)
            DTP_Start_Date.Value = monday
            DTP_End_Date.Value = monday
        Else
            Dim today As Date = DTP_Start_Date.Value
            Dim dayDiff As Integer = today.DayOfWeek - DayOfWeek.Monday
            Dim monday As Date = today.AddDays(-dayDiff)
            DTP_Start_Date.Value = monday
            DTP_End_Date.Value = monday
        End If
    End Sub

    Private Sub DTP_End_Date_ValueChanged(sender As Object, e As EventArgs) Handles DTP_End_Date.ValueChanged
        If DTP_Start_Date.Value < Frm_CI_AI.DTP_Start.Value Or DTP_Start_Date.Value > Frm_CI_AI.DTP_End.Value Then
            Dim today As Date = Now()
            Dim dayDiff As Integer = DayOfWeek.Friday - today.DayOfWeek
            Dim friday As Date = today.AddDays(+dayDiff)
            DTP_End_Date.Value = friday
        Else
            Dim today As Date = DTP_End_Date.Value
            Dim dayDiff As Integer = DayOfWeek.Friday - today.DayOfWeek
            Dim friday As Date = today.AddDays(+dayDiff)
            DTP_End_Date.Value = friday
        End If
    End Sub
End Class