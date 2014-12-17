Public Class Frm_CI_Resources_Edit_Person
    Friend dbTables As String = ""
    Friend TNumber As String = ""

    Dim dataTable As DataTable

    Private Sub Btn_Refresh_Click(sender As Object, e As EventArgs) Handles Btn_Refresh.Click
        loadData()
    End Sub

    Private Sub loadData()
        Me.Cursor = Cursors.WaitCursor
        If DTP_Start.Value.Date <= DTP_End.Value.Date Then
            dataTable = SQL.Return_DataTable(
                "select " & _
                    "project.Category, " & _
                    "(select Category from " & dbTables & "_Category where ID=project.Category) as Category_Name, " & _
                    "project.VS_Chevron, " & _
                    "(select VS_Chevron from " & dbTables & "_VS_Chevron where ID=project.VS_Chevron) as VS_Chevron_Name, " & _
                    "project.Primary_Process, " & _
                    "(select Primary_Process from " & dbTables & "_Primary_Process where ID=project.Primary_Process) as Primary_Process_Name, " & _
                    "project.Created_By, " & _
                    "project.Updated_By, " & _
                    "resources.ID, " & _
                    "resources.Project_ID, " & _
                    "resources.Task_Name, " & _
                    "resources.Task_Type, " & _
                    "(select Task_Type from " & dbTables & "_Task_Type where ID=resources.Task_Type) as Task_Type_Name, " & _
                    "resources.Owner_Name, " & _
                    "resources.Owner, " & _
                    "resources.Start_Date, " & _
                    "resources.End_Date, " & _
                    "resources.Entry_Type, " & _
                    "(select Entry_Type from Project_Entry_Type where ID=resources.Entry_Type) as Entry_Type_Name, " & _
                    "resources.Value, " & _
                    "resources.Service_Line, " & _
                    "(select Service_Line from Project_Service_Line where ID=resources.Service_Line) as Service_Line_Name, " & _
                    "Resources.Comment, " & _
                    "Resources.Recurrence " & _
                "from  " & _
                    dbTables & "_Project as project, " & _
                    dbTables & "_Resources as resources " & _
                "where  " & _
                    "project.ID = resources.Project_ID and " & _
                    "resources.Status = 1 and " & _
                    "resources.owner = '" & TNumber & "'"
            )

            loadGrid()
        Else
            MessageBox.Show("The Start Date and End Date are incorrect, please verify.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub loadGrid()
        Dim addBtn As Boolean = True
        Dim dateStart As Date = DTP_Start.Value.Date
        Dim dateEnd As Date = DTP_End.Value.Date
        Dim dateTemp As Date = dateStart

        DataGridView.DataSource = Nothing

        Try
            DataGridView.Columns.Clear()
        Catch ex As Exception
        End Try

        DataGridView.Columns.Add("OwnerName", "Owner Name")
        DataGridView.Columns.Add("TNumber", "TNumber")
        DataGridView.Columns.Add("Category", "Category")
        DataGridView.Columns("Category").Visible = False
        DataGridView.Columns.Add("CategoryName", "Category")
        DataGridView.Columns.Add("VSChevron", "VS Chevron")
        DataGridView.Columns("VSChevron").Visible = False
        DataGridView.Columns.Add("VSChevronName", "VS Chevron")
        DataGridView.Columns.Add("PrimaryProcess", "Primary Process")
        DataGridView.Columns("PrimaryProcess").Visible = False
        DataGridView.Columns.Add("PrimaryProcessName", "Primary Process")
        DataGridView.Columns.Add("TaskType", "Task Type")
        DataGridView.Columns("TaskType").Visible = False
        DataGridView.Columns.Add("TaskTypeName", "Task Type")
        DataGridView.Columns.Add("TaskName", "Task Name")
        DataGridView.Columns.Add("ServiceLine", "Service Line")
        DataGridView.Columns("ServiceLine").Visible = False
        DataGridView.Columns.Add("ServiceLineName", "Service Line")
        DataGridView.Columns.Add("EntryType", "Entry Type")
        DataGridView.Columns.Add("ResourceID", "Resource ID")
        DataGridView.Columns("ResourceID").Visible = False

        'Fill data on grid
        Dim rowIndex As Integer = 0
        For Each row As DataRow In dataTable.Rows
            DataGridView.Rows.Add()

            DataGridView.Rows(rowIndex).Cells(0).Value = row.Item(13) ' Owner Name
            DataGridView.Rows(rowIndex).Cells(1).Value = row.Item(14) ' TNumber
            DataGridView.Rows(rowIndex).Cells(2).Value = row.Item(0) ' Category
            DataGridView.Rows(rowIndex).Cells(3).Value = row.Item(1) ' Category Name
            DataGridView.Rows(rowIndex).Cells(4).Value = row.Item(2) ' VS Chevron
            DataGridView.Rows(rowIndex).Cells(5).Value = row.Item(3) ' VS Chevron Name
            DataGridView.Rows(rowIndex).Cells(6).Value = row.Item(4) ' Primary Process
            DataGridView.Rows(rowIndex).Cells(7).Value = row.Item(5) ' Primary Process Name
            DataGridView.Rows(rowIndex).Cells(8).Value = row.Item(11) ' Task Type
            DataGridView.Rows(rowIndex).Cells(9).Value = row.Item(12) ' Task Type Name
            DataGridView.Rows(rowIndex).Cells(10).Value = row.Item(10) ' Task Name
            DataGridView.Rows(rowIndex).Cells(11).Value = row.Item(20) ' Service Line
            DataGridView.Rows(rowIndex).Cells(12).Value = row.Item(21) ' Service Line Name
            DataGridView.Rows(rowIndex).Cells(13).Value = row.Item(18) ' Entry Type Name
            DataGridView.Rows(rowIndex).Cells(14).Value = row.Item(8) ' Resource ID

            rowIndex = rowIndex + 1
        Next

        ' Get the dates
        If DateDiff(DateInterval.Day, dateStart, dateEnd) <= 31 Then
            ' Values for day
            addBtn = True
            While dateTemp <= dateEnd
                If dateTemp.DayOfWeek <> DayOfWeek.Saturday And dateTemp.DayOfWeek <> DayOfWeek.Sunday Then
                    DataGridView.Columns.Add(dateTemp.ToString("MMddyyyy"), dateTemp.DayOfWeek.ToString("G") & " " & dateTemp.ToString("MM/dd/yyyy"))
                End If
                dateTemp = dateTemp.AddDays(1)
            End While
        Else
            ' Values for month
            addBtn = False
            dateTemp = DateSerial(dateTemp.Year, dateTemp.Month, "1")
            While dateTemp <= dateEnd
                DataGridView.Columns.Add(dateTemp.ToString("MMddyyyy"), Globales.meses(dateTemp.Month - 1).ToString)
                dateTemp = dateTemp.AddMonths(1)
            End While
        End If

        'Not Edit
        For Each row As DataGridViewRow In DataGridView.Rows
            For Each column As DataGridViewColumn In DataGridView.Columns
                row.Cells(column.Name).ReadOnly = True
                column.SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Next

        'Fill values of dates
        rowIndex = 0
        For Each row As DataRow In dataTable.Rows
            Dim words() As String = row.Item(23).ToString().Split(",")

            For column As Integer = 15 To (DataGridView.Columns.Count - 1)
                Dim dateRow As Date = DateSerial(
                    Integer.Parse(DataGridView.Columns(column).Name.Substring(4, 4)),
                    Integer.Parse(DataGridView.Columns(column).Name.Substring(0, 2)),
                    Integer.Parse(DataGridView.Columns(column).Name.Substring(2, 2))
                )

                Dim changeCell As Boolean = False

                If words(1) <= dateRow Then
                    If IsDate(words(words.Length - 1)) Then
                        If (words(words.Length - 1) < dateRow) Then
                            changeCell = True
                        End If
                    End If
                Else
                    changeCell = True
                End If

                'Values
                If changeCell Then
                    DataGridView.Rows(rowIndex).Cells(column).Value = ""
                    DataGridView.Rows(rowIndex).Cells(column).ReadOnly = True
                ElseIf getDates(dateRow, row.Item(23)) Then
                    DataGridView.Rows(rowIndex).Cells(column).Value = row.Item(19)

                    'Find info in CI_Resources_Specific
                    Dim tableSpecific As DataTable = SQL.Return_DataTable("select * from " & dbTables & "_Resources_Specific where Resource_ID='" & DataGridView.Rows(rowIndex).Cells(14).Value & "' and Date='" & DateSerial(
                        Integer.Parse(DataGridView.Columns(column).Name.Substring(4, 4)),
                        Integer.Parse(DataGridView.Columns(column).Name.Substring(0, 2)),
                        Integer.Parse(DataGridView.Columns(column).Name.Substring(2, 2))
                    ) & "'")
                    If tableSpecific.Rows.Count > 0 Then
                        DataGridView.Rows(rowIndex).Cells(column).Value = tableSpecific.Rows(0).Item("Value").ToString
                    End If
                    If addBtn Then
                        DataGridView.Rows(rowIndex).Cells(column).ReadOnly = False
                    Else
                        DataGridView.Rows(rowIndex).Cells(column).ReadOnly = True
                    End If
                Else
                    DataGridView.Rows(rowIndex).Cells(column).Value = ""
                    DataGridView.Rows(rowIndex).Cells(column).ReadOnly = True
                End If
            Next
            rowIndex = rowIndex + 1
        Next

        'Hide rows
        For Each row As DataGridViewRow In DataGridView.Rows
            Dim visible As Boolean = False
            For column As Integer = 15 To (DataGridView.Columns.Count - 1)
                If row.Cells(column).Value.ToString <> "" Then
                    visible = True
                End If
            Next
            row.Visible = visible
        Next

        'Add button
        If addBtn Then
            Dim btnColumn As DataGridViewButtonColumn = New DataGridViewButtonColumn()
            btnColumn.Name = "btnAction"
            btnColumn.HeaderText = "Action"
            btnColumn.Text = "Save Data"
            btnColumn.UseColumnTextForButtonValue = True
            DataGridView.Columns.Add(btnColumn)
        End If

        'Autosize columns
        For Each column As DataGridViewColumn In DataGridView.Columns
            DataGridView.Columns(column.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

        'Totals
        DataGridView.Rows.Add()
        For column As Integer = 15 To (DataGridView.Columns.Count - 1)
            Dim total As Double = 0
            For Each row As DataGridViewRow In DataGridView.Rows
                If row.Index < (DataGridView.Rows.Count - 1) Then
                    Try
                        total = total + row.Cells(column).Value
                    Catch ex As Exception
                    End Try
                Else
                    row.Cells(column).Value = total
                End If
            Next
        Next

        If addBtn Then
            Dim text As New DataGridViewTextBoxCell()
            text.Value = ""
            DataGridView(DataGridView.Columns.Count - 1, DataGridView.Rows.Count - 1) = text
        End If
        DataGridView.Rows(DataGridView.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightGreen

        'Not Edit
        For Each column As DataGridViewColumn In DataGridView.Columns
            DataGridView.Rows(DataGridView.Rows.Count - 1).Cells(column.Name).ReadOnly = True
        Next
    End Sub

    Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView.CellClick
        Try
            If (e.RowIndex <> -1) Then
                If DataGridView.Columns(e.ColumnIndex).HeaderText = "Action" Then
                    For Each row As DataGridViewRow In DataGridView.Rows
                        If row.Index < (DataGridView.Rows.Count - 1) Then
                            For column As Integer = 15 To (DataGridView.Columns.Count - 2)
                                Dim tableSpecific As DataTable = SQL.Return_DataTable("select * from " & dbTables & "_Resources_Specific where Resource_ID='" & row.Cells(14).Value & "' and Date='" & DateSerial(
                                        Integer.Parse(DataGridView.Columns(column).Name.Substring(4, 4)),
                                        Integer.Parse(DataGridView.Columns(column).Name.Substring(0, 2)),
                                        Integer.Parse(DataGridView.Columns(column).Name.Substring(2, 2))
                                    ) & "'")
                                If ((row.Cells(column).Value.ToString <> dataTable.Rows(row.Index).Item(19).ToString) And
                                    (row.Cells(column).Value.ToString <> "")) Or
                                    (tableSpecific.Rows.Count > 0) Then
                                    If tableSpecific.Rows.Count > 0 Then
                                        SQL.Execute("update " & dbTables & "_Resources_Specific set Value = '" & row.Cells(column).Value & "' where Resource_ID = '" & row.Cells(14).Value & "' and Date='" & DateSerial(
                                            Integer.Parse(DataGridView.Columns(column).Name.Substring(4, 4)),
                                            Integer.Parse(DataGridView.Columns(column).Name.Substring(0, 2)),
                                            Integer.Parse(DataGridView.Columns(column).Name.Substring(2, 2))
                                        ) & "'")
                                    Else
                                        SQL.Execute("insert into " & dbTables & "_Resources_Specific (Resource_ID, Date, Value) values ('" & row.Cells(14).Value & "', '" & DateSerial(
                                            Integer.Parse(DataGridView.Columns(column).Name.Substring(4, 4)),
                                            Integer.Parse(DataGridView.Columns(column).Name.Substring(0, 2)),
                                            Integer.Parse(DataGridView.Columns(column).Name.Substring(2, 2))
                                        ) & "', '" & row.Cells(column).Value & "')")
                                    End If
                                End If
                            Next
                        End If
                    Next
                    MessageBox.Show("The changes has been saved.")
                    loadData()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class