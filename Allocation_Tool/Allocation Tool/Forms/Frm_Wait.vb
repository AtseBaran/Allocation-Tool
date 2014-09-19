Public Class Frm_Wait

    Private _cancel As Boolean = False

    Public Property cancel As Boolean
        Get
            Return _cancel
        End Get
        Set(value As Boolean)
            _cancel = value
        End Set
    End Property

    Friend sProgress As Integer
    Friend eProgress As Integer

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        closeMe()
    End Sub

    Private Sub Frm_Wait_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        closeMe()
        e.Cancel = True
    End Sub

    Private Sub closeMe()
        If DotNet.IsConfirmed("Are you sure?") Then
            cancel = True
        End If
    End Sub

    Private Sub Frm_Wait_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar.Minimum = sProgress
        ProgressBar.Maximum = eProgress
    End Sub

    Friend Sub performStep(stepProgress As Integer)
        ProgressBar.Value = stepProgress
    End Sub
End Class