Public Class Frm_Reports_Popup
    Friend dbTables As String = ""

    Private _retorno As String = ""

    Public Property retorno As String
        Get
            Return _retorno
        End Get
        Set(value As String)
            _retorno = value
        End Set
    End Property

    Friend tables As String = ""
    Friend fields As String = ""
    Friend order As String = ""
    Friend where As String = ""

    Friend sqlQuery As String = ""

    Friend selected As String = ""
    Friend returnField As Integer = 0

    Private Sub Frm_Reports_Popup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim datatable As DataTable
        If tables = "peerList" Then
            datatable = UsersInfo.PeerList(AppName)

            Dim rowUser As DataRow = datatable.NewRow
            rowUser.Item(0) = UsersInfo.TNumber
            rowUser.Item(1) = UsersInfo.Name
            datatable.Rows.InsertAt(rowUser, 0)
            Dim r As Integer = 0
            For Each row As DataRow In datatable.Rows
                datatable.Rows(r).Item(1) = row.Item(0) & " / " & row.Item(1)
                r = r + 1
            Next
        Else
            Dim sqlQuery As String = "select " & _
                                        fields & " " & _
                                    "from " & _
                                        tables & " " & _
                                    where & " " & _
                                    order

            datatable = SQL.Return_DataTable(sqlQuery)
        End If
        CheckedListBox.DataSource = datatable
        CheckedListBox.DisplayMember = datatable.Columns(1).ColumnName.ToString
        CheckedListBox.ValueMember = datatable.Columns(0).ColumnName.ToString

        Dim indexes As String = ""
        For Each item As DataRowView In CheckedListBox.Items
            If InStr(selected, item.Row(0)) Then
                indexes = indexes & "1"
            Else
                indexes = indexes & "0"
            End If
        Next
        Dim i As Integer = 0
        For Each c As Char In indexes
            If c = "0" Then
                CheckedListBox.SetItemChecked(i, False)
            Else
                CheckedListBox.SetItemChecked(i, True)
            End If
            i = i + 1
        Next

        If returnField = 1 Then
            indexes = ""
            For Each item As DataRowView In CheckedListBox.Items
                If InStr(selected, item.Row(1)) Then
                    indexes = indexes & "1"
                Else
                    indexes = indexes & "0"
                End If
            Next
            i = 0
            For Each c As Char In indexes
                If c = "0" Then
                    CheckedListBox.SetItemChecked(i, False)
                Else
                    CheckedListBox.SetItemChecked(i, True)
                End If
                i = i + 1
            Next
        End If
    End Sub

    Private Sub AllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllToolStripMenuItem.Click
        For i As Integer = 0 To CheckedListBox.Items.Count - 1
            CheckedListBox.SetItemChecked(i, True)
        Next
    End Sub

    Private Sub NoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoneToolStripMenuItem.Click
        For i As Integer = 0 To CheckedListBox.Items.Count - 1
            CheckedListBox.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub ToolStripButtonFilter_Click(sender As Object, e As EventArgs) Handles ToolStripButtonFilter.Click
        Dim bandera As Boolean = True
        For Each item As DataRowView In CheckedListBox.CheckedItems
            If Not bandera Then
                Me.retorno = Me.retorno & ","
            End If
            Me.retorno = Me.retorno & item.Row(returnField).ToString
            bandera = False
        Next

        Me.Close()
    End Sub
End Class