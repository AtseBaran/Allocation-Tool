Public Class Frm_CI_Resources_History
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
                                                "Recurrence " & _
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
        DataGridViewHistory.Columns(5).HeaderText = "Recurrence"
        DataGridViewHistory.Columns(5).Visible = False

        Dim recurrence As New DataGridViewTextBoxColumn()

        DataGridViewHistory.Columns.Add(recurrence)

        recurrence.HeaderText = "Recurrence Text"
        recurrence.Name = "recurrenceText"

        For Each row As DataGridViewRow In DataGridViewHistory.Rows
            Dim recipe As String = row.Cells(5).Value
            Dim words() As String = Split(recipe, ",")
            Dim recipeText As String = ""

            If words(0) = "DAILY" Then
                If words(2) = "1" Then
                    recipeText = "Occurs daily, every " & words(3) & " day(s) from " & words(1) & " until " & words(4)
                ElseIf words(2) = "2" Then
                    recipeText = "Occurs daily, every weekday from " & words(1) & " until " & words(4)
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
                recipeText = recipeText & " " & days & " from " & words(1) & " until " & words(words.Count - 1)
            ElseIf words(0) = "MONTHLY" Then
                If words(2) = "1" Then
                    recipeText = "Occurs monthly, on " & words(3) & " of every " & words(4) & " month(s) from " & words(1) & " until " & words(words.Count - 1)
                ElseIf words(2) = "2" Then
                    recipeText = "Occurs monthly, the " & words(3).ToLower & " " & words(4).ToLower & " of every " & words(5) & " month(s) from " & words(1) & " until " & words(words.Count - 1)
                End If
            ElseIf words(0) = "YEARLY" Then
                recipeText = "Occurs every " & words(2) & " year(s) "
                If words(2) = "1" Then
                    recipeText = recipeText & "on " & words(4).ToLower & " " & words(5) & " from " & words(1) & " until " & words(words.Count - 1)
                ElseIf words(2) = "2" Then
                    recipeText = recipeText & "on the " & words(4).ToLower & " " & words(5).ToLower & " of " & words(6).ToLower & " from " & words(1) & " until " & words(words.Count - 1)
                End If
            End If
            row.Cells("recurrenceText").Value = recipeText
        Next

    End Sub
End Class