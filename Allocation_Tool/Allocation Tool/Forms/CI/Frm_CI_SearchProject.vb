Public Class Frm_CI_SearchProject

    Friend dbTables As String = ""
    Dim dataTablePrimaryProcess As DataTable
    Dim dataTableTaskName As DataTable
    Dim dataOwner As DataTable

    Dim dataSearch As DataTable

    Dim showColumns As Boolean = True

    Private Sub Frm_CI_SearchProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadData()
    End Sub

    Private Sub loadData()
        dataTablePrimaryProcess = SQL.Return_DataTable("select * from " & dbTables & "_Primary_Process")
        ComboBoxPrimaryProcess.DataSource = dataTablePrimaryProcess
        ComboBoxPrimaryProcess.DisplayMember = "Primary_Process"
        ComboBoxPrimaryProcess.ValueMember = "ID"
        ComboBoxPrimaryProcess.SelectedIndex = -1

        dataTableTaskName = SQL.Return_DataTable("select * from " & dbTables & "_Task_Name")
        ComboBoxTaskName.DataSource = dataTableTaskName
        ComboBoxTaskName.DisplayMember = "Task_Name"
        ComboBoxTaskName.ValueMember = "ID"
        ComboBoxTaskName.SelectedIndex = -1

        dataOwner = UsersInfo.PeerList(AppName)
        Dim rowUser As DataRow = dataOwner.NewRow
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
    End Sub

    Private Sub ButtonSearch_Click(sender As Object, e As EventArgs) Handles ButtonSearch.Click
        Dim where As String = ""

        If Not DotNet.IsEmpty(ComboBoxPrimaryProcess.SelectedValue) Then
            If where.Length > 0 Then
                where = where & "and "
            End If
            where = where & "project.Primary_Process = '" & ComboBoxPrimaryProcess.SelectedValue & "' "
        End If

        If Not DotNet.IsEmpty(ComboBoxTaskName.Text) Then
            If where.Length > 0 Then
                where = where & "and "
            End If
            where = where & "resources.Task_Name = '" & sqlString(Trim(ComboBoxTaskName.Text)) & "' "
        End If

        If CheckedListBoxOwner.CheckedItems.Count > 0 Then
            Dim temp As String = "("
            Dim countOwners As Integer = 0
            For Each owner As DataRowView In CheckedListBoxOwner.CheckedItems
                If countOwners > 0 Then
                    temp = temp & ","
                End If
                temp = temp & "'" & owner.Item(0) & "'"
                countOwners = countOwners + 1
            Next
            temp = temp & ") "

            If where.Length > 0 Then
                where = where & "and "
            End If
            where = where & "resources.Owner In " & temp
        End If

        Dim sqlstr As String = "select " & _
                "(select Primary_Process from " & dbTables & "_Primary_Process where " & dbTables & "_Primary_Process.ID = project.Primary_Process) as Primary_Process, " & _
                "project.ID as ID, " & _
                "Resources.Task_Name, " & _
                "Resources.Owner, " & _
                "Resources.Owner_Name, " & _
                "Resources.Start_Date, " & _
                "Resources.End_Date, " & _
                "Resources.Value, " & _
                "Resources.ID as Resources_ID " & _
            "from " & _
                dbTables & "_Project as project " & _
            "left join  " & _
                dbTables & "_Resources as resources " & _
            "on " & _
                "Resources.Project_ID = project.ID "

        If where.Length > 0 Then
            sqlstr = sqlstr & "where " & where
        End If

        dataSearch = SQL.Return_DataTable(sqlstr)

        If dataSearch.Rows.Count > -1 Then
            For Each column As System.Data.DataColumn In dataSearch.Columns
                dataSearch.Columns(column.ColumnName).ColumnName = Replace(column.ColumnName, "_", " ")
            Next

            DataGridView.DataSource = dataSearch

            If showColumns Then
                DataGridView.Columns(1).Visible = False
                DataGridView.Columns(8).Visible = False
                showColumns = False
            End If

            Dim selectProject As New DataGridViewButtonColumn()
            Dim selectUser As New DataGridViewButtonColumn()

            Try
                DataGridView.Columns.Remove("selectProject")
                DataGridView.Columns.Remove("selectUser")
            Catch ex As Exception
            End Try

            DataGridView.Columns.Add(selectProject)
            DataGridView.Columns.Add(selectUser)

            selectProject.HeaderText = "Project"
            selectProject.Text = "View Project"
            selectProject.Name = "selectProject"
            selectProject.UseColumnTextForButtonValue = True

            selectUser.HeaderText = "User"
            selectUser.Text = "View User"
            selectUser.Name = "selectUser"
            selectUser.UseColumnTextForButtonValue = True
        End If
    End Sub

    Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView.CellClick
        Try
            If (e.RowIndex <> -1) Then
                If DataGridView.Columns(e.ColumnIndex).HeaderText = "Project" Then
                    Frm_CI_PF.Id_Project = DataGridView.Rows(e.RowIndex).Cells("ID").Value
                    Frm_CI_PF.loadProject()
                    Me.Close()
                    DataGridView.Columns.Remove("selectProject")
                    DataGridView.Columns.Remove("selectUser")
                ElseIf DataGridView.Columns(e.ColumnIndex).HeaderText = "User" Then
                    If Not DotNet.IsEmpty(DataGridView.Rows(e.RowIndex).Cells("Resources ID").Value) Then
                        Dim f As New Frm_CI_Resources_Edit_Person
                        f.TNumber = DataGridView.Rows(e.RowIndex).Cells("Owner").Value
                        f.dbTables = dbTables
                        f.Show(Me)
                    Else
                        MessageBox.Show("The project not have resources assigned.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class