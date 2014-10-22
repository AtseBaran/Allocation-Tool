Public Class Frm_CI_Vacations_Holidays
    Friend VHDates() As Date

    Friend dbTables As String = ""

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Dim exists As Boolean = False
        For Each boldedDate As Date In MonthCalendar.BoldedDates
            If boldedDate = MonthCalendar.SelectionRange.Start.Date Then
                exists = True
            End If
        Next
        If Not exists Then
            MonthCalendar.AddBoldedDate(MonthCalendar.SelectionRange.Start.Date)
        End If
        ListBox.Items.Clear()
        For Each boldedDate As Date In MonthCalendar.BoldedDates
            ListBox.Items.Add(boldedDate)
        Next
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles BtnRemove.Click
        If ListBox.SelectedItems.Count > 0 Then
            MonthCalendar.RemoveBoldedDate(ListBox.SelectedItems(0))
        End If
        ListBox.Items.Clear()
        For Each boldedDate As Date In MonthCalendar.BoldedDates
            ListBox.Items.Add(boldedDate)
        Next
    End Sub

    Private Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        If DotNet.IsConfirmed("Are you sure?") Then
            'Set vacations / holidays
            ReDim VHDates(ListBox.Items.Count - 1)
            For i As Integer = 0 To (ListBox.Items.Count - 1)
                VHDates(i) = ListBox.Items(i)
            Next
            Frm_CI_AI.VHDates = VHDates
            Me.Close()
            ToolStripButtonCancel_Click(sender, e)
            Frm_CI_AI.saveVHDates()
        End If
    End Sub

    Private Sub ToolStripButtonCancel_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCancel.Click
        MonthCalendar.RemoveAllBoldedDates()
        ListBox.Items.Clear()
    End Sub

    Private Sub Frm_CI_Vacations_Holidays_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not VHDates Is Nothing Then
            For i As Integer = 0 To (VHDates.Count - 1)
                ListBox.Items.Add(VHDates(i))
                MonthCalendar.AddBoldedDate(VHDates(i))
            Next
        End If
    End Sub
End Class