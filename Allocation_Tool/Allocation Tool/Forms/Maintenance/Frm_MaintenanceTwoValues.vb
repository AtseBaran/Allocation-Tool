Public Class Frm_MaintenanceTwoValues
    Private ID As Integer
    Private ID_Required As Integer
    Private TextValue As String

    Friend Tabla As String
    Friend TablaRequired As String
    Friend ValueRequired As String
    Friend IdRequired As String
    Friend CampoRequired As String
    Friend Campo As String
    Friend TitleWindow As String
    Friend lblCombo As String
    Friend lblTexto As String

    Private Sub Frm_MaintenanceTwoValues_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = TitleWindow
        LabelValue.Text = lblTexto
        LabelCombo.Text = lblCombo

        ComboBoxRequired.Enabled = False
        TextBoxValue.Enabled = False
        TextBoxValue.Text = ""
        ComboBoxRequired.DataSource = Nothing

        ToolStripButtonNew.Enabled = True
        ToolStripButtonEdit.Enabled = False
        ToolStripButtonSave.Enabled = False
        ToolStripButtonDelete.Enabled = False

        ID = 0

        LoadData()
    End Sub

    Private Sub LoadData()
        Dim combo As DataTable = SQL.Return_DataTable("select * from " & TablaRequired)
        ComboBoxRequired.DataSource = Nothing
        ComboBoxRequired.DisplayMember = ValueRequired
        ComboBoxRequired.ValueMember = IdRequired
        ComboBoxRequired.DataSource = combo
        ComboBoxRequired.SelectedIndex = -1

        Dim Table As DataTable = SQL.Return_DataTable("select * from " & Tabla)
        DataGridView.DataSource = Table
        DataGridView.Columns(0).Visible = False
        DataGridView.Columns(1).Visible = False
        DataGridView.Columns(1).HeaderText = lblCombo
        DataGridView.Columns(2).HeaderText = lblTexto
        DataGridView.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub ToolStripButtonNew_Click(sender As Object, e As EventArgs) Handles ToolStripButtonNew.Click
        TextBoxValue.Enabled = True
        ComboBoxRequired.Enabled = True

        ToolStripButtonNew.Enabled = False
        ToolStripButtonSave.Enabled = True
        ToolStripButtonDelete.Enabled = True
        ToolStripButtonEdit.Enabled = False

        ID = 0
    End Sub

    Private Sub ToolStripButtonEdit_Click(sender As Object, e As EventArgs) Handles ToolStripButtonEdit.Click
        TextBoxValue.Enabled = True
        ComboBoxRequired.Enabled = True

        ToolStripButtonNew.Enabled = False
        ToolStripButtonSave.Enabled = True
        ToolStripButtonDelete.Enabled = True
        ToolStripButtonEdit.Enabled = False

        TextBoxValue.Text = TextValue
        ComboBoxRequired.SelectedValue = ID_Required
    End Sub

    Private Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        TextBoxValue.Enabled = False
        ComboBoxRequired.Enabled = False

        ToolStripButtonNew.Enabled = True
        ToolStripButtonSave.Enabled = False
        ToolStripButtonDelete.Enabled = False

        If ID = 0 Then
            SQL.Execute("insert into " & Tabla & " (" & Campo & "," & CampoRequired & ") values('" & sqlString(Trim(TextBoxValue.Text)) & "', '" & ComboBoxRequired.SelectedValue & "')")
            LoadData()
        ElseIf ID <> 0 Then
            SQL.Execute("update " & Tabla & " set " & Campo & "='" & sqlString(Trim(TextBoxValue.Text)) & "', " & CampoRequired & "='" & ComboBoxRequired.SelectedValue & "' where id='" & ID & "'")
            LoadData()
        End If

        TextBoxValue.Text = ""
        ID = 0
    End Sub

    Private Sub ToolStripButtonDelete_Click(sender As Object, e As EventArgs) Handles ToolStripButtonDelete.Click
        If DotNet.IsConfirmed("Are you sure?") Then
            TextBoxValue.Enabled = False
            ComboBoxRequired.Enabled = False

            ToolStripButtonDelete.Enabled = False
            ToolStripButtonNew.Enabled = True
            ToolStripButtonSave.Enabled = False
            ToolStripButtonEdit.Enabled = False

            If ID <> 0 Then
                SQL.Execute("delete from " & Tabla & " where ID='" & ID & "'")
                LoadData()
            End If

            TextBoxValue.Text = ""
            ComboBoxRequired.SelectedIndex = -1

            ID = 0
        End If
    End Sub

    Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView.CellClick
        If (e.RowIndex >= 0) Then
            ToolStripButtonSave.Enabled = False
            ComboBoxRequired.SelectedIndex = -1
            TextBoxValue.Text = ""
            ComboBoxRequired.Enabled = False
            TextBoxValue.Enabled = False

            ToolStripButtonEdit.Enabled = True
            ToolStripButtonDelete.Enabled = True

            ID = DataGridView(0, e.RowIndex).Value
            ID_Required = DataGridView(1, e.RowIndex).Value
            TextValue = DataGridView(2, e.RowIndex).Value
        End If
    End Sub

End Class