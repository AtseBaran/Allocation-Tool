Public Class Frm_MaintenanceOneValue
    Private ID As Integer
    Private TextValue As String

    Friend Tabla As String
    Friend Campo As String
    Friend Title As String
    Friend lblTexto As String

    Private Sub ToolStripButtonNew_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNew.Click
        TextBoxValue.Enabled = True

        ToolStripButtonNew.Enabled = False
        ToolStripButtonSave.Enabled = True
        ToolStripButtonDelete.Enabled = True
        ToolStripButtonEdit.Enabled = False

        ID = 0
    End Sub

    Private Sub ToolStripButtonEdit_Click(sender As Object, e As EventArgs) Handles ToolStripButtonEdit.Click
        TextBoxValue.Enabled = True

        ToolStripButtonNew.Enabled = False
        ToolStripButtonSave.Enabled = True
        ToolStripButtonDelete.Enabled = True
        ToolStripButtonEdit.Enabled = False

        TextBoxValue.Text = TextValue
    End Sub

    Private Sub ToolStripButtonDelete_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDelete.Click
        If DotNet.IsConfirmed("Are you sure?") Then
            TextBoxValue.Enabled = False

            ToolStripButtonDelete.Enabled = False
            ToolStripButtonNew.Enabled = True
            ToolStripButtonSave.Enabled = False
            ToolStripButtonEdit.Enabled = False

            If ID <> 0 Then
                SQL.Execute("delete from " & Tabla & " where ID='" & ID & "'")
                LoadData()
            End If

            TextBoxValue.Text = ""

            ID = 0
        End If
    End Sub

    Private Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        TextBoxValue.Enabled = False

        ToolStripButtonNew.Enabled = True
        ToolStripButtonSave.Enabled = False
        ToolStripButtonDelete.Enabled = False

        If ID = 0 Then
            SQL.Execute("insert into " & Tabla & " (" & Campo & ") values('" & sqlString(Trim(TextBoxValue.Text)) & "')")
            LoadData()
        ElseIf ID <> 0 Then
            SQL.Execute("update " & Tabla & " set " & Campo & "='" & sqlString(Trim(TextBoxValue.Text)) & "' where id='" & ID & "'")
            LoadData()
        End If

        TextBoxValue.Text = ""
        ID = 0
    End Sub

    Private Sub Frm_ProjectStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Title
        LabelTexto.Text = lblTexto

        TextBoxValue.Enabled = False
        TextBoxValue.Text = ""

        ToolStripButtonNew.Enabled = True
        ToolStripButtonEdit.Enabled = False
        ToolStripButtonSave.Enabled = False
        ToolStripButtonDelete.Enabled = False

        ID = 0

        LoadData()
    End Sub

    Private Sub LoadData()
        Dim Table As DataTable = SQL.Return_DataTable("select * from " & Tabla)
        DataGridView.DataSource = Table
        DataGridView.Columns(0).Visible = False
        DataGridView.Columns(1).HeaderText = lblTexto
        DataGridView.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView.CellClick
        If (e.RowIndex >= 0) Then
            ToolStripButtonSave.Enabled = False
            TextBoxValue.Text = ""
            TextBoxValue.Enabled = False

            ToolStripButtonEdit.Enabled = True
            ToolStripButtonDelete.Enabled = True

            ID = DataGridView(0, e.RowIndex).Value
            TextValue = DataGridView(1, e.RowIndex).Value
        End If
    End Sub
End Class