Public Class Frm_AI_History

    Friend id_resource As Integer
    Friend id_project As Integer

    Friend dbTables As String = ""

    Private Sub Frm_AI_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                                                "project.Project_Name, " & _
                                                "Resources.Service_Line, " & _
                                                "(select Service_Line from Project_Service_Line where ID=resources.Service_Line) as Service_Line_Name, " & _
                                                "resources.Owner, " & _
                                                "resources.Owner_Name, " & _
                                                "actuals.Actual_Date, " & _
                                                "phase.Project_Phase, " & _
                                                "entry_type.Entry_Type, " & _
                                                "actuals.Value, " & _
                                                "actuals.Comment " & _
                                            "from " & _
                                                dbTables & "_Actuals as actuals, " & _
                                                dbTables & "_Project as project, " & _
                                                dbTables & "_Resources as resources, " & _
                                                dbTables & "_Project_Phase as phase, " & _
                                                "Project_Entry_Type as entry_type " & _
                                            "where " & _
                                                "actuals.Project_ID = project.ID and " & _
                                                "actuals.Resource_ID = resources.ID and " & _
                                                "phase.ID = resources.Project_Phase and " & _
                                                "entry_type.ID = resources.Entry_Type and " & _
                                                "actuals.Project_ID='" & id_project & "' and  " & _
                                                "actuals.Resource_ID='" & id_resource & "'")

        DataGridViewHistory.DataSource = dataTable
        BindingSourceHistory.DataSource = dataTable

        DataGridViewHistory.Columns(0).HeaderText = "ID"
        DataGridViewHistory.Columns(0).Visible = False
        DataGridViewHistory.Columns(1).HeaderText = "Project Name"

        DataGridViewHistory.Columns(2).Visible = False
        DataGridViewHistory.Columns(3).HeaderText = "Service Line"
        DataGridViewHistory.Columns(4).HeaderText = "TNumber"
        DataGridViewHistory.Columns(5).HeaderText = "Owner"

        DataGridViewHistory.Columns(6).HeaderText = "Actual Date"
        DataGridViewHistory.Columns(7).HeaderText = "Project Phase"
        DataGridViewHistory.Columns(8).HeaderText = "Entry Type"
        DataGridViewHistory.Columns(8).Name = "Entry_Type"
        DataGridViewHistory.Columns(9).HeaderText = "Value"
        DataGridViewHistory.Columns(9).Name = "Value"
        DataGridViewHistory.Columns(9).DefaultCellStyle.Format = "N3"
        DataGridViewHistory.Columns(10).HeaderText = "Comment"

        Dim FTEcolumn As New DataGridViewTextBoxColumn()

        DataGridViewHistory.Columns.Insert(11, FTEcolumn)

        FTEcolumn.HeaderText = "Monthly FTE"
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