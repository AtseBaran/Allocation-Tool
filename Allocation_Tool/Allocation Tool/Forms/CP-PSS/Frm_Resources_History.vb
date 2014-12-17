Public Class Frm_Resources_History
    Friend id_resource As Integer

    Friend dbTables As String = ""

    Private Sub ToolStripButtonRefresh_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRefresh.Click
        loadData()
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
    End Sub

    Private Sub ToolStripButtonClear_Click(sender As Object, e As EventArgs) Handles ToolStripButtonClear.Click
        BindingSourceHistory.Filter = ""
    End Sub

    Private Sub Frm_Resources_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Private Sub loadData()
        Dim dataTable As DataTable

        dataTable = Nothing
        DataGridViewHistory.DataSource = Nothing
        DataGridViewHistory.Columns.Clear()
        BindingSourceHistory.DataSource = Nothing

        dataTable = SQL.Return_DataTable("select " & _
                                                "ID, " & _
                                                "ID_Resource, " & _
                                                "Old_Value, " & _
                                                "New_Value, " & _
                                                "CONVERT(DATE, Date), " & _
                                                "Comment " & _
                                            "from " & _
                                                "" & dbTables & "_Resources_Historical " & _
                                            "where " & _
                                                "ID_Resource='" & id_resource & "'")

        DataGridViewHistory.DataSource = dataTable
        BindingSourceHistory.DataSource = dataTable

        DataGridViewHistory.Columns(0).Visible = False
        DataGridViewHistory.Columns(1).Visible = False
        DataGridViewHistory.Columns(2).HeaderText = "Old Value"
        DataGridViewHistory.Columns(3).HeaderText = "New Value"
        DataGridViewHistory.Columns(4).HeaderText = "Date"
        DataGridViewHistory.Columns(5).HeaderText = "Comment"
    End Sub
End Class