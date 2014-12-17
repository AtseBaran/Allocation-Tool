Imports System.IO
Imports System.Data.SqlClient
Imports System.IO.Compression

Public Class Frm_Documents_Upload
    Dim docByte As Byte() = Nothing

    Dim dbTables As String = Nothing
    Dim Id_Project As Integer = Nothing
    Dim datos As DataTable = Nothing

    Private Sub Frm_Documents_Upload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datos = SQL.Return_DataTable(
            "select  " & _
            "	distinct convert(varchar(max),Project_Name) as Project_Name, " & _
            "	project.ID, " & _
            "	resources.Owner as owner, " & _
            "  'CP' as [table] " & _
            "from  " & _
            "	CP_Project as project, " & _
            "	CP_Resources as resources " & _
            "where  " & _
            "	resources.Project_ID = project.ID and " & _
            "	Owner " & UsersInfo.Workflow_Onwer_String(AppName) & _
            "union all " & _
            "select " & _
            "	distinct convert(varchar(max),Project_Name) as Project_Name, " & _
            "	project.ID, " & _
            "	resources.Owner as owner, " & _
            "  'PSS' as [table] " & _
            "from  " & _
            "	PSS_Project as project, " & _
            "	PSS_Resources as resources " & _
            "where  " & _
            "	resources.Project_ID = project.ID and " & _
            "	Owner " & UsersInfo.Workflow_Onwer_String(AppName) & _
            "union all " & _
            "select  " & _
            "	Distinct convert (varchar(max), Task_Name) as Project_Name, " & _
            "	convert(varchar(max),Project_ID), " & _
            "	Owner as owner, " & _
            "  'CI' as [table] " & _
            "from  " & _
            "	CI_Resources as resources " & _
            "where " & _
            "	Owner " & UsersInfo.Workflow_Onwer_String(AppName) & _
            "order by " & _
            "	Project_Name "
        )

        CmbProject.ValueMember = "ID"
        CmbProject.DisplayMember = "Project_Name"
        CmbProject.DataSource = datos

        CmbProject.SelectedValue = -1
        CmbProject.Text = ""
    End Sub

    Private Sub BtnUploadFile_Click(sender As Object, e As EventArgs) Handles BtnUploadFile.Click
        If IsNothing(CmbProject.SelectedValue) Then
            MessageBox.Show("Please select a project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Try
                If Not IsNothing(OpenFileDialog.SafeFileName) Then


                    For Each row As DataRow In datos.Rows
                        If (row.Item("ID") = CmbProject.SelectedValue) And row.Item("Project_Name") = CmbProject.Text Then
                            Id_Project = CmbProject.SelectedValue
                            dbTables = row.Item("table")
                        End If
                    Next

                    Dim SQLquery As String = "insert into " & dbTables & "_Files (Project_ID, FileName, [File], Owner) values ('" & Id_Project & "', '" & OpenFileDialog.SafeFileName & "', @fdoc, '" & UsersInfo.TNumber & "')"
                    Dim docfile As New SqlParameter
                    docfile.SqlDbType = SqlDbType.Binary
                    docfile.ParameterName = "fdoc"
                    docfile.Value = docByte

                    Dim myConn As New SqlConnection(SQL.Connection_String)
                    myConn.Open()
                    Dim sqlcmd As SqlCommand = New SqlCommand(SQLquery, myConn)
                    sqlcmd.Parameters.Add(docfile)
                    sqlcmd.ExecuteNonQuery()
                    myConn.Close()

                    Me.Close()
                Else
                    MessageBox.Show("Please select a file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("An error has been ocurred, please try again." & vbCrLf & vbCrLf & "Additional Information: " & vbCrLf & vbCrLf & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub BtnSelectFile_Click(sender As Object, e As EventArgs) Handles BtnSelectFile.Click
        Try
            Dim fs As FileStream

            OpenFileDialog.ShowDialog(Me)
            Dim sFile As String = OpenFileDialog.FileName

            fs = New FileStream(sFile, FileMode.Open, FileAccess.Read)
            docByte = New Byte(fs.Length - 1) {}
            fs.Read(docByte, 0, System.Convert.ToInt32(fs.Length))
            fs.Close()
        Catch ex As Exception
            MessageBox.Show("An error has been ocurred, please try again." & vbCrLf & vbCrLf & "Additional Information: " & vbCrLf & vbCrLf & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class