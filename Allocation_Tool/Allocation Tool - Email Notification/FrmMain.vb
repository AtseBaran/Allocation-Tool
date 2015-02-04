Public Class FrmMain

    Dim showNotify As Boolean = True
    Dim email As New eMail()

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        If (DateTime.Now.Hour = 10 And Today.Day = 15) Then
            If showNotify Then
                'Remove this line
                Timer.Enabled = False
                'Remove this line

                NotifyIcon.ShowBalloonTip(15000, Application.ProductName, "Sending mails.", ToolTipIcon.Warning)
                'Send e-mails

                Dim dataTable As DataTable = SQL.Return_DataTable("" & _
                "select " & _
                "	distinct Project.ID, " & _
                "  'CP' as 'Table' " & _
                "from " & _
                "	CP_Project as Project, " & _
                "	CP_Resources as Resources " & _
                "where " & _
                "	Project.ID = Resources.Project_ID " & _
                "	and ( " & _
                "		SELECT " & _
                "			DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,( " & _
                "				select " & _
                "					max(month) " & _
                "				from " & _
                "					CP_Resources as Resources " & _
                "				where " & _
                "					Project.ID = Resources.Project_ID " & _
                "			))+1,0))) between GETDATE() and DATEADD(DAY, 15, GETDATE()) " & _
                "union " & _
                "select " & _
                "	distinct Project.ID, " & _
                "  'PSS' as 'Table' " & _
                "from " & _
                "	PSS_Project as Project, " & _
                "	PSS_Resources as Resources " & _
                "where " & _
                "	Project.ID = Resources.Project_ID " & _
                "	and ( " & _
                "		SELECT " & _
                "			DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,( " & _
                "				select " & _
                "					max(month) " & _
                "				from " & _
                "					PSS_Resources as Resources " & _
                "				where " & _
                "					Project.ID = Resources.Project_ID " & _
                "			))+1,0))) between GETDATE() and DATEADD(DAY, 15, GETDATE()) " & _
                "union " & _
                "select " & _
                "	distinct Project.ID, " & _
                "  'CI' as 'Table' " & _
                "from " & _
                "	CI_Project as Project, " & _
                "	CI_Resources as Resources " & _
                "where " & _
                "	Project.ID = Resources.Project_ID " & _
                "	and ( " & _
                "		SELECT " & _
                "			DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,( " & _
                "				select " & _
                "					max(Resources.End_Date) " & _
                "				from " & _
                "					CI_Resources as Resources " & _
                "				where " & _
                "					Project.ID = Resources.Project_ID " & _
                "			))+1,0))) between GETDATE() and DATEADD(DAY, 15, GETDATE())")

                Dim mail As String = Nothing
                Dim projectName As String = Nothing
                Dim dataTmp As New DataTable
                For Each row As DataRow In dataTable.Rows
                    dataTmp = Nothing
                    If row.Item(1).ToString() = "CI" Then
                        dataTmp = SQL.Get_Table("select distinct project.Created_By, resources.Task_Name from " & row.Item(1).ToString() & "_Resources as resources, " & row.Item(1).ToString() & "_Project as project where project.Project_ID = '" & row.Item(0).ToString() & "' and resources.Project_ID = project.ID")
                    Else
                        dataTmp = SQL.Get_Table("select project.Created_By, project.Project_Name from " & row.Item(1).ToString() & "_Project as project where project.ID = '" & row.Item(0).ToString() & "'")
                    End If

                    For Each rowtmp As DataRow In dataTmp.Rows
                        mail = UsersInfo.GetMail(rowtmp.Item(0).ToString(), AppName)
                        projectName = rowtmp.Item(1).ToString()
                    Next
                Next

                email.Recipients = mail
                email.Subject = "The project " & projectName & " is about to end."
                email.Body = "..."
                email.Send(True)

                showNotify = False
            End If
        End If

        If (DateTime.Now.Hour = 11) Then
            showNotify = True
        End If
    End Sub

    Private Sub NotifyIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon.MouseDoubleClick
        Me.Visible = Not Me.Visible
    End Sub

    Private Sub FrmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Visible = False
    End Sub

End Class
