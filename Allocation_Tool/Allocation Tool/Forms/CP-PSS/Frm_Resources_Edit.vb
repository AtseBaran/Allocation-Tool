Public Class Frm_Resources_Edit
    Friend id_resource As Integer
    Friend entry_type As String
    Friend old_value As Decimal

    Friend dbTables As String = ""

    Private Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles ToolStripButtonSave.Click
        Dim bandera As Boolean = False

        If TextBoxNewValue.Value < 0 Then
            bandera = True
            LabelNewValue.ForeColor = Color.Red

        Else
            LabelNewValue.ForeColor = Color.Black
        End If
        If Trim(TextBoxComments.Text).Length = 0 Then
            bandera = True
            LabelComments.ForeColor = Color.Red
        Else
            LabelComments.ForeColor = Color.Black
        End If

        If bandera Then
            MessageBox.Show("Please add value and comment, they are mandatory fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If DotNet.IsConfirmed("Are you sure?") Then
                SQL.Execute("update " & dbTables & "_Resources set " & _
                            "Value='" & Trim(TextBoxNewValue.Value) & "', " & _
                            "Monthly_FTE='" & getMonthlyFTE(entry_type, TextBoxNewValue.Value) & "', " & _
                            "Comment='" & Trim(TextBoxComments.Text) & "'" & _
                            " where " & _
                            "ID='" & id_resource & "'")

                SQL.Execute("insert into " & dbTables & "_Resources_Historical (" & _
                                    "ID_Resource, " & _
                                    "New_Value, " & _
                                    "Old_Value, " & _
                                    "Date, " & _
                                    "Comment) values (" & _
                                    "'" & id_resource & "', " & _
                                    "'" & Trim(TextBoxNewValue.Value) & "', " & _
                                    "'" & Trim(TextBoxOldValue.Text) & "', " & _
                                    "GETDATE(), " & _
                                    "'" & Trim(TextBoxComments.Text) & "')")
                Frm_PF.loadProject()
                clearData()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Frm_Resources_Edit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearData()
        TextBoxOldValue.Text = old_value
    End Sub

    Private Sub ToolStripButtonCancel_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCancel.Click
        clearData()
    End Sub

    Private Sub clearData()
        TextBoxNewValue.Value = 0
        TextBoxComments.Text = ""
    End Sub

    Private Sub ToolStripButtonHistory_Click(sender As Object, e As EventArgs) Handles ToolStripButtonHistory.Click
        Dim form As New Frm_Resources_History
        form.dbTables = dbTables
        form.id_resource = id_resource
        form.ShowDialog(Me)
        form.Dispose()
    End Sub
End Class