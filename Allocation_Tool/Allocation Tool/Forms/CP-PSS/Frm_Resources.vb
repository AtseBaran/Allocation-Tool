Public Class Frm_Resources
    Friend Id_Project As Integer = 0

    Friend dbTables As String = ""

    Dim userServiceLine(1, 1) As Boolean
    Dim setteo As Boolean = False

    Private Sub Frm_Resources_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridViewSelected.DataSource = Nothing
        If Id_Project = 0 Then
            MessageBox.Show("Please, select a project before add new resource.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        Else
            clearControls()
            loadData()
        End If
    End Sub

    Private Sub clearControls()
        setteo = False

        DataGridViewSelected.DataSource = Nothing
        ComboBoxEntryType.SelectedIndex = -1
        ComboBoxProjectPhase.SelectedIndex = -1
        ComboBoxResourceType.SelectedIndex = -1
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
        Dim dataResourceType As DataTable = SQL.Return_DataTable("select * from Project_Resource_Type")
        Dim dataProjectPhase As DataTable = SQL.Return_DataTable("select * from " & dbTables & "_Project_Phase")
        Dim dataEntryType As DataTable = SQL.Return_DataTable("select * from Project_Entry_Type")
        Dim dataServiceLine As DataTable = SQL.Return_DataTable("select * from Project_Service_Line")
        Dim dataOwner As DataTable = UsersInfo.PeerList(AppName)

        Dim rowRT As DataRow = dataResourceType.NewRow
        Dim rowPP As DataRow = dataProjectPhase.NewRow
        Dim rowET As DataRow = dataEntryType.NewRow
        Dim rowUser As DataRow = dataOwner.NewRow

        ComboBoxResourceType.DisplayMember = "Resource_Type"
        ComboBoxResourceType.ValueMember = "ID"
        rowRT.Item(0) = "0"
        rowRT.Item(1) = ""
        dataResourceType.Rows.InsertAt(rowRT, 0)
        ComboBoxResourceType.DataSource = dataResourceType

        ComboBoxProjectPhase.DisplayMember = "Project_Phase"
        ComboBoxProjectPhase.ValueMember = "ID"
        rowPP.Item(0) = "0"
        rowPP.Item(1) = ""
        dataProjectPhase.Rows.InsertAt(rowPP, 0)
        ComboBoxProjectPhase.DataSource = dataProjectPhase

        ComboBoxEntryType.DisplayMember = "Entry_Type"
        ComboBoxEntryType.ValueMember = "ID"
        rowET.Item(0) = "0"
        rowET.Item(1) = ""
        dataEntryType.Rows.InsertAt(rowET, 0)
        ComboBoxEntryType.DataSource = dataEntryType

        CheckedListBoxServiceLine.DataSource = dataServiceLine
        CheckedListBoxServiceLine.DisplayMember = dataServiceLine.Columns(1).ColumnName.ToString
        CheckedListBoxServiceLine.ValueMember = dataServiceLine.Columns(0).ColumnName.ToString

        'Change method, tnumber visible in list
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

    Private Sub DTP_Start_ValueChanged(sender As Object, e As EventArgs) Handles DTP_Start.ValueChanged
        CalculateMonths(DTP_Start.Value, DTP_End.Value, ListBoxMonths)
    End Sub

    Private Sub DTP_End_ValueChanged(sender As Object, e As EventArgs) Handles DTP_End.ValueChanged
        CalculateMonths(DTP_Start.Value, DTP_End.Value, ListBoxMonths)
    End Sub

    Private Sub CalculateMonths(date_start As Date, date_end As Date, list As ListBox)
        If (date_start.Date <= date_end.Date) Then
            list.Items.Clear()
            Dim m_end As Integer = (DateDiff(DateInterval.Month, date_start.Date, date_end.Date))
            For c_mes = 0 To m_end
                Dim tmes As Decimal = date_start.Month + c_mes
                Dim tyear As Integer = date_start.Year

                If (tmes) > 12 Then
                    tyear = tyear + Math.Floor((tmes - 0.1) / 12)
                    tmes = tmes - (12 * Math.Floor((tmes - 0.1) / 12))
                End If

                ListBoxMonths.Items.Add(meses(tmes - 1) & " " & tyear)
            Next
        Else
            MessageBox.Show("Date range is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        Dim bandera As Boolean = True

        If ComboBoxResourceType.Text = "" Then
            bandera = False
            LabelResourceType.ForeColor = Color.Red
        Else
            LabelResourceType.ForeColor = Color.Black
        End If
        If ComboBoxProjectPhase.Text = "" Then
            bandera = False
            LabelProjectPhase.ForeColor = Color.Red
        Else
            LabelProjectPhase.ForeColor = Color.Black
        End If
        If ComboBoxEntryType.Text = "" Then
            bandera = False
            LabelEntryType.ForeColor = Color.Red
        Else
            LabelEntryType.ForeColor = Color.Black
        End If
        If TextBoxMonthlyValue.Text.Length <= 0 Then
            bandera = False
            LabelMonthlyValue.ForeColor = Color.Red
        Else
            LabelMonthlyValue.ForeColor = Color.Black
        End If
        If CheckedListBoxOwner.CheckedItems.Count <= 0 Then
            bandera = False
            GroupBoxOwnerList.ForeColor = Color.Red
        Else
            GroupBoxOwnerList.ForeColor = Color.Black
        End If
        If CheckedListBoxServiceLine.CheckedItems.Count <= 0 Then
            bandera = False
            GroupBoxServiceLine.ForeColor = Color.Red
        Else
            GroupBoxServiceLine.ForeColor = Color.Black
        End If

        If bandera Then
            Dim continueInsert As Boolean = True
            If DataGridViewSelected.Rows.Count > 0 Then
                If DotNet.IsConfirmed("The information has not been saved, the resources allocated will be lost." & vbCrLf & "Continue?") Then
                    continueInsert = True
                Else
                    continueInsert = False
                End If
            End If
            If continueInsert Then
                Dim data As New DataTable
                data.Columns.Add("Project ID")
                data.Columns.Add("TNumber")
                data.Columns.Add("Name")
                data.Columns.Add("Service Line")
                data.Columns.Add("Project Phase")
                data.Columns.Add("PP")
                data.Columns.Add("Entry Type")
                data.Columns.Add("ET")
                data.Columns.Add("Value")
                data.Columns.Add("Resource Type")
                data.Columns.Add("ID")
                data.Columns.Add("Monthly FTE")
                data.Columns.Add("Month Number")
                data.Columns.Add("Month")
                data.Columns.Add("Year")
                Dim row As DataRow

                For Each month As String In ListBoxMonths.Items
                    For i As Integer = 0 To (CheckedListBoxOwner.Items.Count - 1)
                        If CheckedListBoxOwner.GetItemCheckState(i) Then
                            Dim owner As DataRowView = CheckedListBoxOwner.Items.Item(i)
                            CheckedListBoxOwner.SelectedIndex = i
                            CheckedListBoxServiceLine_MouseUp(sender, e)
                            For Each service As DataRowView In CheckedListBoxServiceLine.CheckedItems
                                row = data.NewRow
                                row("Project ID") = Id_Project
                                row("Resource Type") = ComboBoxResourceType.SelectedValue

                                row("ID") = service.Item(0).ToString()
                                row("Service Line") = service.Item(1).ToString()
                                row("TNumber") = owner.Item(0).ToString()
                                row("Name") = owner.Item(1).ToString()

                                row("Project Phase") = ComboBoxProjectPhase.SelectedValue
                                row("Entry Type") = ComboBoxEntryType.SelectedValue
                                row("Value") = TextBoxMonthlyValue.Text
                                row("Monthly FTE") = getMonthlyFTE(ComboBoxEntryType.Text, TextBoxMonthlyValue.Text)
                                Dim tmes() As String = month.Split(" ")
                                row("Month Number") = Array.IndexOf(meses, tmes(0)) + 1
                                row("Month") = tmes(0)
                                row("Year") = tmes(1)
                                data.Rows.Add(row)

                                row("PP") = SQL.Execute("select Project_Phase from " & dbTables & "_Project_Phase where id='" & row("Project Phase") & "'")
                                row("ET") = SQL.Execute("select Entry_Type from Project_Entry_Type where id='" & row("Entry Type") & "'")
                            Next
                        End If
                    Next
                Next
                DataGridViewSelected.DataSource = data
                DataGridViewSelected.Columns("PP").HeaderText = "Project Phase"
                DataGridViewSelected.Columns("ET").HeaderText = "Entry Type"
                DataGridViewSelected.Columns("Project ID").Visible = False
                DataGridViewSelected.Columns("Resource Type").Visible = False
                DataGridViewSelected.Columns("ID").Visible = False
                DataGridViewSelected.Columns("Project Phase").Visible = False
                DataGridViewSelected.Columns("Entry Type").Visible = False
                DataGridViewSelected.Columns("Month Number").Visible = False
            End If
        Else
            MessageBox.Show("All fields are mandatory, please fill out the ones highlighted in red.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
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

    Private Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        Dim count As Integer = DataGridViewSelected.Rows.Count
        If count > 0 Then
            If DotNet.IsConfirmed("Are you sure you want to include this resource(s)?") Then
                Dim retorno As Integer
                For Each dr As DataGridViewRow In DataGridViewSelected.Rows
                    retorno = SQL.Execute("insert into " & dbTables & "_Resources (" & _
                                "Project_ID," & _
                                "Resource_Type," & _
                                "Service_Line," & _
                                "Owner," & _
                                "Owner_Name," & _
                                "Project_Phase," & _
                                "Entry_Type," & _
                                "Value," & _
                                "Monthly_FTE," & _
                                "Month, " & _
                                "Status" & _
                                ") OUTPUT Inserted.ID values (" & _
                                "'" & dr.Cells("Project ID").Value.ToString & "'," & _
                                "'" & dr.Cells("Resource Type").Value.ToString & "'," & _
                                "'" & dr.Cells("ID").Value.ToString & "'," & _
                                "'" & dr.Cells("TNumber").Value.ToString & "'," & _
                                "'" & dr.Cells("Name").Value.ToString & "'," & _
                                "'" & dr.Cells("Project Phase").Value.ToString & "'," & _
                                "'" & dr.Cells("Entry Type").Value.ToString & "'," & _
                                "'" & dr.Cells("Value").Value.ToString & "'," & _
                                "'" & dr.Cells("Monthly FTE").Value.ToString & "'," & _
                                "'" & dr.Cells("Year").Value.ToString & "-" & dr.Cells("Month Number").Value.ToString & "-01" & "'," & _
                                "1" & _
                                ")")
                    SQL.Execute("insert into " & dbTables & "_Resources_Historical (" & _
                                    "ID_Resource, " & _
                                    "New_Value, " & _
                                    "Date) values (" & _
                                    "'" & retorno & "', " & _
                                    "'" & dr.Cells("Value").Value.ToString & "', " & _
                                    "GETDATE())")
                Next
                Frm_PF.loadResources(Id_Project)
                clearControls()

            End If
        End If
    End Sub

    Private Sub ToolStripButtonCancel_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCancel.Click
        clearControls()
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
End Class