Public Class FrmMain
    Dim showNotify As Boolean = True

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        If (DateTime.Now.Hour = 10) Then
            If showNotify Then
                NotifyIcon.ShowBalloonTip(15000, Application.ProductName, "Please input your actuals.", ToolTipIcon.Warning)
                'Send e-mails



                showNotify = False
            End If
        End If

        If (DateTime.Now.Hour = 11 Or DateTime.Now.Hour = 15) Then
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
