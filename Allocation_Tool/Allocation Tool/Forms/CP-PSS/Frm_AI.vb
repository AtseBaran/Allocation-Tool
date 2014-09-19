Public Class Frm_AI

    Friend dbTables As String = ""
    Friend windowTitle As String = ""

    Private Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click

    End Sub

    Private Sub Frm_CP_AI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = windowTitle
        loadActuals()
    End Sub

    Private Sub ToolStripButtonAddFilter_Click(sender As Object, e As EventArgs) Handles ToolStripButtonAddFilter.Click
        Try
            Dim FV As String
            If Not DBNull.Value.Equals(DataGridViewActuals.CurrentCell.Value) Then
                If DataGridViewActuals.CurrentCell.ValueType.Equals(GetType(Date)) Then
                    FV = " >= '" & String.Format("{0:yyyy-MM-dd}", DataGridViewActuals.CurrentCell.Value) & " 00:00:00.000' AND " & DataGridViewActuals.CurrentCell.OwningColumn.Name & " <= '" & String.Format("{0:yyyy-MM-dd}", DataGridViewActuals.CurrentCell.Value) & " 23:59:00.000'"
                Else
                    FV = " = '" & DataGridViewActuals.CurrentCell.Value & "'"
                End If
            Else
                FV = " Is Null"
            End If
            Dim FE As String = DataGridViewActuals.CurrentCell.OwningColumn.Name & FV

            If BindingSourceActuals.Filter <> Nothing Then
                BindingSourceActuals.Filter = BindingSourceActuals.Filter & " AND " & FE
            Else
                BindingSourceActuals.Filter = FE
            End If
        Catch ex As Exception

        End Try
        calculate()
    End Sub

    Private Sub ToolStripButtonRemoveFilter_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRemoveFilter.Click
        Try
            Dim FV As String
            If Not DBNull.Value.Equals(DataGridViewActuals.CurrentCell.Value) Then
                If DataGridViewActuals.CurrentCell.ValueType.Equals(GetType(Date)) Then
                    FV = " >= '" & String.Format("{0:yyyy-MM-dd}", DataGridViewActuals.CurrentCell.Value) & " 00:00:00.000' AND " & DataGridViewActuals.CurrentCell.OwningColumn.Name & " <= '" & String.Format("{0:yyyy-MM-dd}", DataGridViewActuals.CurrentCell.Value) & " 23:59:00.000'"
                Else
                    FV = " = '" & DataGridViewActuals.CurrentCell.Value & "'"
                End If
            Else
                FV = " Is Null"
            End If
            Dim FE As String = "Not (" & DataGridViewActuals.CurrentCell.OwningColumn.Name & FV & ")"
            If BindingSourceActuals.Filter <> Nothing Then
                BindingSourceActuals.Filter = BindingSourceActuals.Filter & " AND " & FE
            Else
                BindingSourceActuals.Filter = FE
            End If
        Catch ex As Exception
        End Try
        calculate()
    End Sub

    Private Sub ToolStripButtonClearAll_Click(sender As Object, e As EventArgs) Handles ToolStripButtonClearAll.Click
        BindingSourceActuals.Filter = ""
        calculate()
    End Sub

    Private Sub ToolStripButtonRefresh_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRefresh.Click
        loadActuals()
    End Sub

    Friend Sub loadActuals()
        Dim dataTable As New DataTable

        Try
            DataGridViewActuals.Columns.Remove("editActuals")
            DataGridViewActuals.Columns.Remove("ATV")
            DataGridViewActuals.Columns.Remove("AMFTE")
        Catch ex As Exception
        End Try

        DataGridViewActuals.DataSource = Nothing
        BindingSourceActuals.DataSource = Nothing

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
                                    dbTables & "_Resources as resources, " & _
                                    dbTables & "_Project as project, " & _
                                    dbTables & "_Project_Phase as phase, " & _
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
                                    "resources.[Month] asc") '"Owner = 'CS1214' or " & _ ' 7 = In Process

        BindingSourceActuals.DataSource = dataTable
        DataGridViewActuals.DataSource = dataTable

        DataGridViewActuals.Columns(0).Visible = False
        DataGridViewActuals.Columns(1).Visible = False
        DataGridViewActuals.Columns(2).HeaderText = "Project Name"
        DataGridViewActuals.Columns(3).HeaderText = "Owner Name"
        DataGridViewActuals.Columns(4).HeaderText = "Project Phase"
        DataGridViewActuals.Columns(5).HeaderText = "Entry Type"
        DataGridViewActuals.Columns(5).Name = "Entry_Type"
        DataGridViewActuals.Columns(6).HeaderText = "Month"
        DataGridViewActuals.Columns(6).DefaultCellStyle.Format = "MMMM yyyy"
        DataGridViewActuals.Columns(7).HeaderText = "Monthly Value"
        DataGridViewActuals.Columns(8).HeaderText = "Monthly FTE"
        DataGridViewActuals.Columns.Add("ATV", "Actuals Total Value")
        DataGridViewActuals.Columns.Add("AMFTE", "Actuals Monthly FTE")

        Dim selectActuals As New DataGridViewButtonColumn()

        DataGridViewActuals.Columns.Add(selectActuals)

        selectActuals.HeaderText = "Actions"
        selectActuals.Text = "Edit Actuals"
        selectActuals.Name = "editActuals"
        selectActuals.UseColumnTextForButtonValue = True

        calculate()
    End Sub

    Private Sub DataGridViewActuals_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewActuals.CellClick
        If DataGridViewActuals.Columns(e.ColumnIndex).HeaderText = "Actions" Then
            If DataGridViewActuals.Rows.Count > 0 Then
                'Edit data
                Frm_AI_Popup.dbTables = dbTables
                Frm_AI_Popup.windowTitle = "Actuals Input"
                Frm_AI_Popup.id_project = DataGridViewActuals.Item(1, e.RowIndex).Value
                Frm_AI_Popup.id_resource = DataGridViewActuals.Item(0, e.RowIndex).Value
                Frm_AI_Popup.ShowDialog(Me)
            End If
        End If
        calculate()
    End Sub

    Private Sub DataGridViewActuals_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewActuals.CellContentClick
        calculate()
    End Sub

    Private Sub calculate()
        If DataGridViewActuals.Rows.Count > 0 Then
            Dim value As Integer, days As Integer
            For Each row As DataGridViewRow In DataGridViewActuals.Rows
                Try
                    'Error on sum, check query
                    value = SQL.Execute("select sum(value) as value from " & dbTables & "_Actuals where Project_ID='" & row.Cells(1).Value & "' and Resource_ID='" & row.Cells(0).Value & "'")
                    days = SQL.Execute("select count(*) as days from " & dbTables & "_Actuals where Project_ID='" & row.Cells(1).Value & "' and Resource_ID='" & row.Cells(0).Value & "' and Vacation_Holiday = 'True'")
                Catch ex As Exception
                    value = 0
                End Try

                DataGridViewActuals.Item("ATV", row.Index).Value = value
                If (row.Cells(7).Value / 3) > value Then
                    DataGridViewActuals.Item("ATV", row.Index).Style.BackColor = Color.RosyBrown
                ElseIf ((row.Cells(7).Value / 3) * 2) > value Then
                    DataGridViewActuals.Item("ATV", row.Index).Style.BackColor = Color.LightYellow
                Else
                    DataGridViewActuals.Item("ATV", row.Index).Style.BackColor = Color.LightGreen
                End If
                DataGridViewActuals.Item("AMFTE", row.Index).Value = getMonthlyFTE(DataGridViewActuals.Item("Entry_Type", row.Index).Value, value, days)
            Next
        End If
    End Sub

    Private Sub DataGridViewActuals_ColumnSortModeChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridViewActuals.ColumnSortModeChanged
        calculate()
    End Sub

    Private Sub DataGridViewActuals_Sorted(sender As Object, e As EventArgs) Handles DataGridViewActuals.Sorted
        calculate()
    End Sub
End Class