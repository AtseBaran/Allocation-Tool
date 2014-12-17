Imports System.IO
Imports System.Data.SqlClient
Imports System.IO.Compression

Public Class Frm_Documents

    Private dbTables As String = ""

    Private Sub loadFiles()
        Dim dataTable As DataTable = Nothing
        Dim dataTableFiles As New DataTable

        DataGridViewFiles.DataSource = Nothing
        DataGridViewFiles.Columns.Clear()

        Try
            dataTable = SQL.Return_DataTable("select " & _
                                                "Files.ID, " & _
                                                "'CP' as [Table] " & _
                                            "from  " & _
                                                "CP_Files as Files, " & _
                                                "CP_Resources as Resources " & _
                                            "Where " & _
                                                "Files.Project_ID = Resources.Project_ID and " & _
                                                "Resources.Owner " & UsersInfo.Workflow_Onwer_String(AppName) & _
                                            "union " & _
                                            "select  " & _
                                                "Files.ID, " & _
                                                "'PSS' as [Table] " & _
                                            "from  " & _
                                                "PSS_Files as Files, " & _
                                                "PSS_Resources as Resources " & _
                                            "Where " & _
                                                "Files.Project_ID = Resources.Project_ID and " & _
                                                "Resources.Owner " & UsersInfo.Workflow_Onwer_String(AppName) & _
                                            "union	 " & _
                                            "select  " & _
                                                "Files.ID, " & _
                                                "'CI' as [Table] " & _
                                            "from  " & _
                                                "CI_Files as Files, " & _
                                                "CI_Resources as Resources " & _
                                            "Where " & _
                                                "Files.Project_ID = Resources.Project_ID and " & _
                                                "Resources.Owner " & UsersInfo.Workflow_Onwer_String(AppName))

            dataTableFiles.TableName = "Files"
            dataTableFiles.Columns.Add("Table")
            dataTableFiles.Columns.Add("ID")
            dataTableFiles.Columns.Add("Project_Name")
            dataTableFiles.Columns.Add("FileName")
            dataTableFiles.Columns.Add("Owner")

            For Each row As DataRow In dataTable.Rows
                Dim rowTemp As DataRow = Nothing
                If row.Item(1) = "CI" Then
                    rowTemp = SQL.Return_DataRow("select 'CI' as [Table], Files.ID, (Select DISTINCT Task_Name from CI_Resources where CI_Resources.Project_ID = Files.Project_ID) as Project_Name, Files.[FileName], [Owner] from " & row.Item(1) & "_Files as Files where Files.ID='" & row.Item(0) & "'")
                Else
                    rowTemp = SQL.Return_DataRow("select '" & row.Item(1) & "' as [Table], Files.ID, Projects.Project_Name, Files.[FileName], [Owner] from " & row.Item(1) & "_Files as Files, " & row.Item(1) & "_Project as Projects where Files.ID='" & row.Item(0) & "'")
                End If
                dataTableFiles.ImportRow(rowTemp)
            Next

            DataGridViewFiles.DataSource = dataTableFiles
            
            'Add column with button to download file
            Dim downloadFile As New DataGridViewButtonColumn()
            DataGridViewFiles.Columns.Add(downloadFile)
            downloadFile.HeaderText = "Actions"
            downloadFile.Text = "Download File"
            downloadFile.Name = "downloadFile"
            downloadFile.UseColumnTextForButtonValue = True

            DataGridViewFiles.Columns("Table").Visible = False
            DataGridViewFiles.Columns("ID").Visible = False
            DataGridViewFiles.Columns("Project_Name").HeaderText = "Project Name / Task Name"
            DataGridViewFiles.Columns("Owner").HeaderText = "Create by"

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Frm_Documents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadFiles()
    End Sub

    Private Sub ToolStripButtonRefreshFiles_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRefreshFiles.Click
        loadFiles()
    End Sub

    Private Sub DataGridViewFiles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewFiles.CellClick
        Try
            If (e.RowIndex <> -1) Then
                If DataGridViewFiles.Columns(e.ColumnIndex).HeaderText = "Actions" Then
                    If DataGridViewFiles.Rows.Count > 0 Then
                        Dim dataRowFile As DataRow = SQL.Return_DataRow("select [FileName], [File] from " & DataGridViewFiles.Item("Table", e.RowIndex).Value & "_Files Where ID='" & DataGridViewFiles.Item("ID", e.RowIndex).Value & "'")

                        Dim fileName As String = dataRowFile.Item("FileName")
                        Dim fileData As Byte() = dataRowFile.Item("File")

                        SaveFileDialog.FileName = fileName

                        SaveFileDialog.ShowDialog(Me)

                        Dim path As String = SaveFileDialog.FileName

                        File.WriteAllBytes(path, fileData)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolStripButtonAddFiles_Click(sender As Object, e As EventArgs) Handles ToolStripButtonAddFiles.Click
        Frm_Documents_Upload.ShowDialog(Me)
        loadFiles()
    End Sub

    Private Sub ToolStripButtonRemoveFiles_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRemoveFiles.Click
        If DotNet.IsConfirmed("Are you sure?") Then
            For Each dr As DataGridViewRow In DataGridViewFiles.SelectedRows
                If dr.Cells("Owner").Value.ToString = UsersInfo.TNumber Then
                    dbTables = dr.Cells("Table").Value.ToString
                    SQL.Execute("Delete From " & dbTables & "_Files where id = '" & dr.Cells("ID").Value & "'")
                Else
                    MessageBox.Show("You not have permissions for delete this file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Next
            loadFiles()
        End If
    End Sub
End Class