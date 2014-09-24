Public Class Frm_Main

    Private Sub Frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dateFuture As Date
        Dim tNumber As String, emailGBSPM As String, emailPSSPM As String
        If Today.Day >= 1 And Today.Day <= 5 Then
            dateFuture = DateSerial(Today.Year, Today.Month + 1, 0)
            Dim DataTable As DataTable = SQL.Return_DataTable(
                "select " & _
                    "project.ID, " & _
                    "project.Project_Name, " & _
                    "project.XGBS_PM, " & _
                    "project.PSS_Delivery_PM, " & _
                    "project.Created_By " & _
                "from " & _
                    "CP_Project as project, " & _
                    "CP_Resources as resources " & _
                "where " & _
                    "project.ID = resources.Project_ID and " & _
                    "resources.Month = '" & dateFuture & "'")
            If DataTable.Rows.Count > 0 Then
                For Each row As DataRow In DataTable.Rows
                    tNumber = UsersInfo.GetTNumber(row.Item(2).ToString, AppName)
                    emailGBSPM = UsersInfo.GetMail(tNumber, AppName)
                    tNumber = UsersInfo.GetTNumber(row.Item(3).ToString, AppName)
                    emailPSSPM = UsersInfo.GetMail(tNumber, AppName)
                    If Send_eMail(emailGBSPM, "Subject", "Body") Then
                        My.Settings.LastSend = DateSerial(Today.Year, Today.Month, Today.Day)
                        My.Settings.Save()
                    End If
                Next
            End If
        End If
        Me.Close()
    End Sub
End Class