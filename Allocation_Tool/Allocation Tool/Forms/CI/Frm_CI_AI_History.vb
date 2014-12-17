Public Class Frm_CI_AI_History

    Friend id_resource As Integer
    Friend id_project As Integer

    Friend dbTables As String = ""

    Private Sub Frm_CI_AI_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Private Sub loadData()
        Dim dataTable As DataTable

        dataTable = Nothing
        DataGridViewHistory.DataSource = Nothing
        DataGridViewHistory.Columns.Clear()
        BindingSourceHistory.DataSource = Nothing

        dataTable = SQL.Return_DataTable("select " & _
                                                "actuals.ID, " & _
                                                "(select Primary_Process from CI_Primary_Process where CI_Primary_Process.ID = project.Primary_Process) as 'Primary Process', " & _
                                                "resources.Task_Name as 'Task Name', " & _
                                                "(select Task_Type from CI_Task_Type where CI_Task_Type.ID = resources.Task_Type) as 'Task Type', " & _
                                                "Resources.Owner_Name as 'Owner Name', " & _
                                                "entry_type.Entry_Type as 'Entry Type', " & _
                                                "actuals.Actual_Date as 'Actual Date', " & _
                                                "actuals.Value, " & _
                                                "actuals.Comment " & _
                                            "from " & _
                                                dbTables & "_Actuals_History as actuals, " & _
                                                dbTables & "_Project as project, " & _
                                                dbTables & "_Resources as resources, " & _
                                                "Project_Entry_Type as entry_type " & _
                                            "where " & _
                                                "actuals.Project_ID = project.ID and " & _
                                                "actuals.Resource_ID = resources.ID and " & _
                                                "entry_type.ID = resources.Entry_Type and " & _
                                                "actuals.Project_ID='" & id_project & "' and  " & _
                                                "actuals.Resource_ID='" & id_resource & "'")

        DataGridViewHistory.DataSource = dataTable
        BindingSourceHistory.DataSource = dataTable

        DataGridViewHistory.Columns(0).HeaderText = "ID"
        DataGridViewHistory.Columns(0).Visible = False
        DataGridViewHistory.Columns(5).HeaderText = "Entry Type"
        DataGridViewHistory.Columns(5).Name = "Entry_Type"
        DataGridViewHistory.Columns(6).HeaderText = "Actual Date"
        DataGridViewHistory.Columns(7).HeaderText = "Value"
        DataGridViewHistory.Columns(7).Name = "Value"
        DataGridViewHistory.Columns(8).DefaultCellStyle.Format = "N3"
        DataGridViewHistory.Columns(8).HeaderText = "Comment"

        Dim FTEcolumn As New DataGridViewTextBoxColumn()

        DataGridViewHistory.Columns.Insert(8, FTEcolumn)

        FTEcolumn.HeaderText = "FTE"
        FTEcolumn.Name = "FTEcolumn"

        calculate()
    End Sub

    Private Sub calculate()
        If DataGridViewHistory.Rows.Count > 0 Then
            For Each row As DataGridViewRow In DataGridViewHistory.Rows
                Dim value As Decimal = getMonthlyFTE(row.Cells("Entry_Type").Value, row.Cells("Value").Value)
                DataGridViewHistory.Item("FTEcolumn", row.Index).Value = value
            Next
        End If
    End Sub

    Private Sub ToolStripButtonFilter_Click(sender As Object, e As EventArgs) Handles ToolStripButtonFilter.Click
        Try
            Dim FV As String
            If Not DBNull.Value.Equals(DataGridViewHistory.CurrentCell.Value) Then
                If DataGridViewHistory.CurrentCell.ValueType.Equals(GetType(Date)) Then
                    FV = " >= '" & String.Format("{0:yyyy-MM-dd}", DataGridViewHistory.CurrentCell.Value) & " 00:00:00.000' AND " & DataGridViewHistory.CurrentCell.OwningColumn.Name & " <= '" & String.Format("{0:yyyy-MM-dd}", DataGridViewHistory.CurrentCell.Value) & " 23:59:00.000'"
                Else
                    FV = " = '" & DataGridViewHistory.CurrentCell.Value & "'"
                End If
            Else
                FV = " Is Null"
            End If
            Dim FE As String = DataGridViewHistory.CurrentCell.OwningColumn.Name & FV

            If BindingSourceHistory.Filter <> Nothing Then
                BindingSourceHistory.Filter = BindingSourceHistory.Filter & " AND " & FE
            Else
                BindingSourceHistory.Filter = FE
            End If
        Catch ex As Exception
        End Try
        calculate()
    End Sub

    Private Sub ToolStripButtonExclude_Click(sender As Object, e As EventArgs) Handles ToolStripButtonExclude.Click
        Try
            Dim FV As String
            If Not DBNull.Value.Equals(DataGridViewHistory.CurrentCell.Value) Then
                If DataGridViewHistory.CurrentCell.ValueType.Equals(GetType(Date)) Then
                    FV = " >= '" & String.Format("{0:yyyy-MM-dd}", DataGridViewHistory.CurrentCell.Value) & " 00:00:00.000' AND " & DataGridViewHistory.CurrentCell.OwningColumn.Name & " <= '" & String.Format("{0:yyyy-MM-dd}", DataGridViewHistory.CurrentCell.Value) & " 23:59:00.000'"
                Else
                    FV = " = '" & DataGridViewHistory.CurrentCell.Value & "'"
                End If
            Else
                FV = " Is Null"
            End If
            Dim FE As String = "Not (" & DataGridViewHistory.CurrentCell.OwningColumn.Name & FV & ")"
            If BindingSourceHistory.Filter <> Nothing Then
                BindingSourceHistory.Filter = BindingSourceHistory.Filter & " AND " & FE
            Else
                BindingSourceHistory.Filter = FE
            End If
        Catch ex As Exception
        End Try
        calculate()
    End Sub

    Private Sub ToolStripButtonClear_Click(sender As Object, e As EventArgs) Handles ToolStripButtonClear.Click
        BindingSourceHistory.Filter = ""
        calculate()
    End Sub

    Private Sub ToolStripButtonRefresh_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRefresh.Click
        loadData()
    End Sub

    Private Sub DataGridViewHistory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewHistory.CellContentClick
        calculate()
    End Sub

    Private Sub DataGridViewHistory_Sorted(sender As Object, e As EventArgs) Handles DataGridViewHistory.Sorted
        calculate()
    End Sub
End Class