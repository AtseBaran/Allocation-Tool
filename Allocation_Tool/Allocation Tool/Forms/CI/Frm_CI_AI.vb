Public Class Frm_CI_AI
    Friend VHDates() As Date
    Friend dbTables As String
    Friend windowTitle As String

    Dim dataTable As DataTable

    Private Sub Frm_CI_AI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTP_Start.Value = Now()
        DTP_End.Value = Now()
    End Sub

    Private Sub ToolStripButtonRefresh_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRefresh.Click
        loadData()
    End Sub

    Friend Sub loadActuals()
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
                    "(resources.owner  " & UsersInfo.Workflow_Onwer_String(AppName) & ") "
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
        If DateDiff(DateInterval.Day, dateStart, dateEnd) < 31 Then
            ' Values for day
            addBtn = True
            While dateTemp <= dateEnd
                If dateTemp.DayOfWeek <> DayOfWeek.Saturday And dateTemp.DayOfWeek <> DayOfWeek.Sunday Then
                    Dim columnDate As New DataGridViewButtonColumn()

                    DataGridView.Columns.Add(columnDate)

                    columnDate.HeaderText = dateTemp.DayOfWeek.ToString("G") & " " & dateTemp.ToString("MM/dd/yyyy")
                    columnDate.Name = dateTemp.ToString("MMddyyyy")
                    columnDate.UseColumnTextForButtonValue = False
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
                Dim Actuals As Integer = 0
                Dim ActualsValue As String = "0"
                If changeCell Then
                    DataGridView.Rows(rowIndex).Cells(column).Value = ""
                Else 'If getDates(dateRow, row.Item(23)) Then
                    Dim dateSQL As Date = DateSerial(
                        Integer.Parse(DataGridView.Columns(column).Name.Substring(4, 4)),
                        Integer.Parse(DataGridView.Columns(column).Name.Substring(0, 2)),
                        Integer.Parse(DataGridView.Columns(column).Name.Substring(2, 2))
                    )
                    Dim dataActuals As DataTable = SQL.Return_DataTable(
                                                                        "select " & _
                                                                            "Value, " & _
                                                                            "Vacation_Holiday, " & _
                                                                            "Comment " & _
                                                                        "from " & _
                                                                            dbTables & "_Actuals " & _
                                                                        "where " & _
                                                                            "Resource_ID='" & row.Item(8) & "' and " & _
                                                                            "Project_ID='" & row.Item(9) & "' and " & _
                                                                            "Actual_Date='" & dateSQL & "'"
                                                                        )
                    If dataActuals.Rows.Count > 0 Then
                        If dataActuals.Rows(0).Item("Vacation_Holiday") = "1" Then
                            ActualsValue = dataActuals.Rows(0).Item("Comment").ToString
                        ElseIf dataActuals.Rows(0).Item("Value").ToString <> "" Then
                            ActualsValue = dataActuals.Rows(0).Item("Value").ToString
                        Else
                            ActualsValue = "0"
                        End If
                    End If

                    If Not addBtn Then
                        dataActuals = Nothing
                        dataActuals = SQL.Return_DataTable(
                                                            "select " & _
                                                                "Sum(Value) as Value " & _
                                                            "from " & _
                                                                dbTables & "_Actuals " & _
                                                            "where " & _
                                                                "Resource_ID='" & row.Item(8) & "' and " & _
                                                                "Project_ID='" & row.Item(9) & "' and " & _
                                                                "Actual_Date between '" & DateSerial(dateSQL.Year, dateSQL.Month, "1") & "' and '" & DateSerial(dateSQL.Year, dateSQL.Month + 1, "0") & "' " & _
                                                            "group by " & _
                                                                "Resource_ID, " & _
                                                                "Project_ID"
                                                            )
                        If dataActuals.Rows.Count > 0 Then
                            ActualsValue = dataActuals.Rows(0).Item("Value").ToString
                        Else
                            ActualsValue = 0
                        End If
                    End If

                    '**************************************************************************************
                    Dim tableSpecific As DataTable
                    If addBtn Then
                        tableSpecific = SQL.Return_DataTable("select * from " & dbTables & "_Resources_Specific where Resource_ID='" & DataGridView.Rows(rowIndex).Cells(14).Value & "' and Date='" & DateSerial(
                            Integer.Parse(DataGridView.Columns(column).Name.Substring(4, 4)),
                            Integer.Parse(DataGridView.Columns(column).Name.Substring(0, 2)),
                            Integer.Parse(DataGridView.Columns(column).Name.Substring(2, 2))
                        ) & "'")
                        If tableSpecific.Rows.Count > 0 Then
                            Actuals = Integer.Parse(tableSpecific.Rows(0).Item("Value").ToString)
                        Else
                            Actuals = row.Item(19)
                        End If
                    Else
                        Dim endMonth As Boolean = False
                        Dim dateMonth As Date = DateSerial(
                            Integer.Parse(DataGridView.Columns(column).Name.Substring(4, 4)),
                            Integer.Parse(DataGridView.Columns(column).Name.Substring(0, 2)),
                            Integer.Parse(DataGridView.Columns(column).Name.Substring(2, 2))
                        )
                        While Not endMonth
                            Console.WriteLine(dateMonth.Date.ToString)
                            If Not (dateMonth.DayOfWeek = DayOfWeek.Saturday) And Not (dateMonth.DayOfWeek = DayOfWeek.Sunday) Then
                                If getDates(dateMonth, row.Item(23)) Then
                                    tableSpecific = SQL.Return_DataTable("select * from " & dbTables & "_Resources_Specific where Resource_ID='" & DataGridView.Rows(rowIndex).Cells(14).Value & "' and Date='" & DateSerial(
                                        dateMonth.Year,
                                        dateMonth.Month,
                                        dateMonth.Day
                                    ) & "'")
                                    If tableSpecific.Rows.Count > 0 Then
                                        Actuals = Actuals + Integer.Parse(tableSpecific.Rows(0).Item("Value").ToString)
                                    Else
                                        Actuals = Actuals + row.Item(19)
                                    End If
                                End If
                            End If

                            dateMonth = dateMonth.AddDays(1)
                            If (dateMonth.Month > Integer.Parse(DataGridView.Columns(column).Name.Substring(0, 2))) Or (dateMonth.Year > Integer.Parse(DataGridView.Columns(column).Name.Substring(4, 4))) Then
                                endMonth = True
                            End If
                        End While
                    End If
                    '**************************************************************************************
                    If Actuals > 0 Then
                        DataGridView.Rows(rowIndex).Cells(column).Value = Actuals & " / " & ActualsValue
                    End If
                    '**************************************************************************************
                End If
            Next
            rowIndex = rowIndex + 1
        Next

        'Hide rows
        For Each row As DataGridViewRow In DataGridView.Rows
            Dim visible As Boolean = False
            For column As Integer = 15 To (DataGridView.Columns.Count - 1)
                Try
                    If row.Cells(column).Value.ToString <> "" Then
                        visible = True
                    End If
                Catch ex As Exception
                    visible = True
                End Try
            Next
            row.Visible = visible
        Next

        'Add button
        If addBtn Then
            Dim btnColumn As DataGridViewButtonColumn = New DataGridViewButtonColumn()
            btnColumn.Name = "btnAction"
            btnColumn.HeaderText = "Actions"
            btnColumn.Text = "Edit Actuals"
            btnColumn.UseColumnTextForButtonValue = True
            DataGridView.Columns.Add(btnColumn)
        End If

        'Autosize columns
        For Each column As DataGridViewColumn In DataGridView.Columns
            DataGridView.Columns(column.Name).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub

    Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView.CellClick
        Dim f As New Frm_CI_AI_Popup
        Dim tmp() As String = DataGridView.Columns(e.ColumnIndex).HeaderText.Split(" ")

        If (e.RowIndex <> -1) Then
            If DataGridView.Columns(e.ColumnIndex).HeaderText = "Actions" Then
                If DataGridView.Rows.Count > 0 Then
                    'Edit data
                    f.tab = 1
                    f.dateInput = Now()
                    f.dbTables = dbTables
                    f.windowTitle = "Actuals Input"
                    f.id_resource = DataGridView.Item(14, e.RowIndex).Value
                    f.ShowDialog(Me)
                End If
            Else 'Daily
                If TypeOf DataGridView.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                    If Not DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "" Then
                        f.tab = 0
                        f.dateInput = tmp(1)
                        f.dbTables = dbTables
                        f.windowTitle = "Actuals Input"
                        f.id_resource = DataGridView.Item(14, e.RowIndex).Value
                        f.ShowDialog(Me)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButtonVacationsHolidays.Click
        'Vacations...
        If DataGridView.Rows.Count > 0 Then
            Frm_CI_Vacations_Holidays.VHDates = VHDates
            Frm_CI_Vacations_Holidays.Show(Me)
        End If
    End Sub

    Friend Sub saveVHDates()
        Dim dateTemp As Date
        Console.WriteLine(VHDates.Count)
        For Each row As DataGridViewRow In DataGridView.Rows
            For column As Integer = 15 To (DataGridView.Columns.Count - 2)
                Dim isDate As Boolean = True
                Try
                    dateTemp = DateSerial(
                                    Integer.Parse(DataGridView.Columns(column).Name.Substring(4, 4)),
                                    Integer.Parse(DataGridView.Columns(column).Name.Substring(0, 2)),
                                    Integer.Parse(DataGridView.Columns(column).Name.Substring(2, 2))
                                )
                Catch ex As Exception
                    isDate = False
                End Try
                If isDate Then
                    Dim vh As Boolean = False
                    For Each item As Date In VHDates
                        If dateTemp = item Then
                            vh = True
                        End If
                    Next
                    If vh Then
                        Console.WriteLine("Yes " & dateTemp)
                        Dim id_resource As Integer = row.Cells(14).Value
                        Dim datarow As DataRow = SQL.Return_DataRow("select Project_ID from CI_Resources where ID='" & id_resource & "'")
                        Dim id_project As Integer = datarow.Item("Project_ID")
                        Dim dataTableTemp As DataTable = SQL.Return_DataTable("select " & _
                                                                                "ID " & _
                                                                          "from " & _
                                                                                dbTables & "_Actuals " & _
                                                                          "where " & _
                                                                                "Resource_ID='" & id_resource & "' and " & _
                                                                                "Actual_Date='" & dateTemp & "' and " & _
                                                                                "Project_ID='" & id_project & "'")
                        If dataTableTemp Is Nothing Or dataTableTemp.Rows.Count = 0 Then
                            SQL.Execute("insert into " & dbTables & "_Actuals ( " & _
                                                    "Project_ID, " & _
                                                    "Resource_ID, " & _
                                                    "Actual_Date, " & _
                                                    "Value, " & _
                                                    "Comment, " & _
                                                    "Vacation_Holiday " & _
                                                    ") values ( " & _
                                                    "'" & id_project & "', " & _
                                                    "'" & id_resource & "', " & _
                                                    "'" & dateTemp & "', " & _
                                                    "'0', " & _
                                                    "'Vacations - Holydays', " & _
                                                    "'1' " & _
                                                    ")")
                        Else
                            SQL.Execute("update " & _
                                dbTables & "_Actuals " & _
                            "set " & _
                                "Value='0', " & _
                                "Comment='Vacations - Holidays', " & _
                                "Vacation_Holiday='1' " & _
                            "where " & _
                                "Project_ID='" & id_project & "' and " & _
                                "Resource_ID='" & id_resource & "' and " & _
                                "Actual_Date='" & dateTemp & "'")
                        End If
                    Else
                        Console.WriteLine("Not " & dateTemp)
                    End If
                End If
            Next
        Next
        loadData()
    End Sub
End Class