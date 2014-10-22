Public Class Frm_SearchProject
    Friend dbTables As String = ""

    Private Sub Frm_SearchProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Tabla As DataTable

        'Load projects
        DataGridViewProjects.DataSource = Nothing
        DataGridViewProjects.Columns.Clear()
        Tabla = SQL.Return_DataTable("SELECT ID, Project_Name, Created_Date, Created_By, Updated_date, Updated_By FROM " & dbTables & "_Project WHERE Created_By='" & UsersInfo.TNumber & "' order by Created_By desc")

        Dim selectProject As New DataGridViewButtonColumn()

        DataGridViewProjects.DataSource = Tabla

        DataGridViewProjects.Columns(0).Visible = False
        DataGridViewProjects.Columns(1).HeaderText = "Project Name"
        DataGridViewProjects.Columns(2).HeaderText = "Created Date"
        DataGridViewProjects.Columns(3).HeaderText = "Created By"
        DataGridViewProjects.Columns(4).HeaderText = "Updated Date"
        DataGridViewProjects.Columns(5).HeaderText = "Updated By"

        DataGridViewProjects.Columns.Add(selectProject)

        selectProject.HeaderText = "Actions"
        selectProject.Text = "View Project"
        selectProject.Name = "selectProject"
        selectProject.UseColumnTextForButtonValue = True
    End Sub

    Private Sub DataGridViewProjects_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewProjects.CellClick
        Try
            If (e.RowIndex <> -1) Then
                If DataGridViewProjects.Columns(e.ColumnIndex).HeaderText = "Actions" Then
                    Frm_PF.Id_Project = DataGridViewProjects.Rows(e.RowIndex).Cells("ID").Value
                    Frm_PF.loadProject()
                    Me.Close()
                    DataGridViewProjects.Columns.Remove("selectProject")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class