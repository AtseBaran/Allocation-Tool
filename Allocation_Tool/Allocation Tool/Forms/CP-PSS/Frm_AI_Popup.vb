Public Class Frm_AI_Popup

    Friend id_resource As Integer
    Friend id_project As Integer

    Friend dbTables As String = ""
    Friend windowTitle As String = ""

    Private Sub Frm_AI_Popup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = windowTitle
        loadData()
    End Sub

    Private Sub loadData()
        DTP_Actual_Date.Value = Date.Now
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

        If TabControl.SelectedIndex = 0 Then
            If CheckBoxVHTab1.CheckState = CheckState.Unchecked Then
                If ValueTab1.Value = 0 And Trim(TextBoxCommentTab1.Text) = "" Then
                    MessageBox.Show("Comment field is mandatory when Value is equal to zero, please fill it out.")
                    bandera = True
                End If
            End If
        ElseIf TabControl.SelectedIndex = 1 Then
            If ValueTab2.Value = 0 And Trim(TextBoxCommentTab2.Text) = "" And CheckBoxVHTab2.CheckState = CheckState.Unchecked Then
                MessageBox.Show("Comment field is mandatory when Value is equal to zero, please fill it out.")
                bandera = True
            ElseIf CheckBoxVHTab2.CheckState = CheckState.Checked Then
                Dim dTemp As Date = DTPVH.Value.Date.AddDays(VHDays.Value - 1)
                If Not (DTPVH.Value.Date >= DTP_Start_Date.Value.Date And DTPVH.Value.Date <= DTP_End_Date.Value.Date) Then
                    MessageBox.Show("The date of vacations / holiday is out of week, please check the date.")
                    bandera = True
                ElseIf VHDays.Value < 1 Or VHDays.Value > 5 Then
                    MessageBox.Show("The number of the days of vacations / holiday is too much longer than expected, please check the date.")
                    bandera = True
                ElseIf (dTemp > DTP_End_Date.Value.Date) Then
                    MessageBox.Show("The number of the days of vacations / holiday is too much longer than expected, please check the date.")
                    bandera = True
                End If
            End If
        End If

        If Not bandera Then
            If DotNet.IsConfirmed("Are you sure?") Then
                'Save

                If TabControl.SelectedIndex = 0 Then
                    If CheckBoxVHTab1.Checked Then
                        TextBoxCommentTab1.Text = "Vacations / Holydays"
                    End If
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
                ElseIf TabControl.SelectedIndex = 1 Then
                    Dim startDate As Date = DTP_Start_Date.Value
                    Dim endDate As Date = DTP_End_Date.Value
                    Dim curDate As Date = startDate
                    Dim vsDate As Date = DTPVH.Value.Date
                    Dim veDate As Date = DTPVH.Value.Date.AddDays(VHDays.Value - 1)

                    While (curDate <= endDate)
                        If curDate.Date >= vsDate And curDate.Date <= veDate Then
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
                                        "'" & curDate & "', " & _
                                        "'0', " & _
                                        "'Vacations / Holydays', " & _
                                        "'1' " & _
                                        ")")
                        Else
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
                                        "'" & curDate & "', " & _
                                        "'" & (ValueTab2.Value / (5 - VHDays.Value)) & "', " & _
                                        "'" & Trim(TextBoxCommentTab2.Text) & "', " & _
                                        "'0' " & _
                                        ")")
                        End If

                        curDate = curDate.AddDays(1)
                    End While

                End If

                loadData()
                Frm_AI.loadActuals()
                Me.Close()

            End If
        End If
    End Sub

    Private Sub ToolStripButtonCancel_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCancel.Click
        If DotNet.IsConfirmed("All data will be lost, are you sure?") Then
            loadData()
        End If
    End Sub

    Private Sub DTP_Start_Date_ValueChanged(sender As Object, e As EventArgs) Handles DTP_Start_Date.ValueChanged
        Dim today As Date = DTP_Start_Date.Value
        Dim dayDiff As Integer = today.DayOfWeek - DayOfWeek.Monday
        Dim monday As Date = today.AddDays(-dayDiff)
        DTP_Start_Date.Value = monday
        DTP_End_Date.Value = monday
    End Sub

    Private Sub DTP_End_Date_ValueChanged(sender As Object, e As EventArgs) Handles DTP_End_Date.ValueChanged
        Dim today As Date = DTP_End_Date.Value
        Dim dayDiff As Integer = DayOfWeek.Friday - today.DayOfWeek
        Dim friday As Date = today.AddDays(+dayDiff)
        DTP_End_Date.Value = friday
    End Sub

    Private Sub ToolStripButtonHistory_Click(sender As Object, e As EventArgs) Handles ToolStripButtonHistory.Click
        Dim form As New Frm_AI_History

        form.dbTables = dbTables
        form.id_project = id_project
        form.id_resource = id_resource
        form.ShowDialog(Me)
        form.Dispose()
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

    Private Sub CheckBoxVHTab1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxVHTab1.CheckedChanged
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
End Class