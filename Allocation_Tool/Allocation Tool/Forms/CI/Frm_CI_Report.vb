Imports OfficeOpenXml

Public Class Frm_CI_Report
    Friend dbTables As String

    Private dataTableActuals As DataTable
    Private dataTableProject As DataTable
    Dim dataTableF As DataTable = New DataTable()

    Dim where As String = ""

    Private Category As String = ""
    Private ProjectID As String = ""
    Private ProjectType As String = ""
    Private OwnerName As String = ""
    Private UserType As String = ""
    Private ServiceLine As String = ""
    Private VSChevron As String = ""
    Private PrimaryProcess As String = ""

    Private temp As String()

    Private Sub Frm_CI_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearFilters()
        refreshData()

        TabControl.TabPages(1).Hide()
    End Sub

    Private Function getDataCombo(table As String, field As String, Optional allField As String = "All") As DataTable
        Dim dataTable As DataTable
        dataTable = SQL.Return_DataTable("select * from " & table & " order by CAST(" & field & " as Varchar(1000))")
        Return dataTable
    End Function

    Private Function getDataCombo(table As String, field As String, fieldRequired As String, value As String) As DataTable
        Dim dataTable As DataTable
        dataTable = SQL.Return_DataTable("select * from " & table & " where " & fieldRequired & "='" & value & "' order by CAST(" & field & " as Varchar(1000))")
        Return dataTable
    End Function

    Private Sub CheckBoxRegionalAmerica_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRegionAmerica.CheckedChanged
        If (CheckBoxRegionAmerica.Checked And CheckBoxRegionAsia.Checked And CheckBoxRegionEMEA.Checked) Then
            CheckBoxRegionGlobal.CheckState = CheckState.Checked
        ElseIf (Not CheckBoxRegionAmerica.Checked And Not CheckBoxRegionAsia.Checked And Not CheckBoxRegionEMEA.Checked) Then
            CheckBoxRegionGlobal.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub CheckBoxRegionEMEA_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRegionEMEA.CheckedChanged
        If (CheckBoxRegionAmerica.Checked And CheckBoxRegionAsia.Checked And CheckBoxRegionEMEA.Checked) Then
            CheckBoxRegionGlobal.CheckState = CheckState.Checked
        ElseIf (Not CheckBoxRegionAmerica.Checked And Not CheckBoxRegionAsia.Checked And Not CheckBoxRegionEMEA.Checked) Then
            CheckBoxRegionGlobal.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub CheckBoxRegionAsia_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRegionAsia.CheckedChanged
        If (CheckBoxRegionAmerica.Checked And CheckBoxRegionAsia.Checked And CheckBoxRegionEMEA.Checked) Then
            CheckBoxRegionGlobal.CheckState = CheckState.Checked
        ElseIf (Not CheckBoxRegionAmerica.Checked And Not CheckBoxRegionAsia.Checked And Not CheckBoxRegionEMEA.Checked) Then
            CheckBoxRegionGlobal.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub CheckBoxRegionGlobal_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRegionGlobal.CheckedChanged
        If sender.checked Then
            CheckBoxRegionAmerica.Enabled = False
            CheckBoxRegionAsia.Enabled = False
            CheckBoxRegionEMEA.Enabled = False

            CheckBoxRegionAmerica.CheckState = CheckState.Checked
            CheckBoxRegionAsia.CheckState = CheckState.Checked
            CheckBoxRegionEMEA.CheckState = CheckState.Checked
        Else
            CheckBoxRegionAmerica.Enabled = True
            CheckBoxRegionAsia.Enabled = True
            CheckBoxRegionEMEA.Enabled = True

            CheckBoxRegionAmerica.CheckState = CheckState.Unchecked
            CheckBoxRegionAsia.CheckState = CheckState.Unchecked
            CheckBoxRegionEMEA.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub clearFilters()
        DTPStartDate.Value = Date.Now
        DTPEndDate.Value = Date.Now

        Category = ""
        ProjectID = ""
        ProjectType = ""
        OwnerName = ""
        UserType = ""
        ServiceLine = ""
        VSChevron = ""
        PrimaryProcess = ""

        ButtonProjectName.Text = "Select..."
        ButtonProjectType.Text = "Select..."
        ButtonProjectCategory.Text = "Select..."
        ButtonOwnerName.Text = "Select..."
        ButtonUserType.Text = "Select..."
        ButtonServiceLine.Text = "Select..."
        ButtonVSChevron.Text = "Select..."
        ButtonPrimaryProcess.Text = "Select..."

        where = ""
    End Sub

    Private Sub ToolStripButtonRefresh_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRefresh.Click
        refreshData()
    End Sub

    Private Sub ToolStripButtonClear_Click(sender As Object, e As EventArgs) Handles ToolStripButtonClear.Click
        clearFilters()
        refreshData()
    End Sub

    Private Function filters(t As String, Optional prefix As String = "") As String
        Dim temp() As String
        Dim query As String
        Dim first As Boolean
        Dim tableTemp As DataTable
        Dim dataTable As DataTable
        'Filters

        If t.Length > 0 And Not t.EndsWith(".") Then
            t = t & "."
        End If

        Dim where As String = ""

        'Project_ID
        If ProjectID.Length > 0 Then
            temp = Split(ProjectID, ",")
            where = where & t & "Project_ID in ( "
            first = True
            For Each item As String In temp
                If Not first Then
                    where = where & ","
                End If
                where = where & "'" & item & "'"
                first = False
            Next
            where = where & ") "
        End If

        If Not (t.Contains("Actuals")) Then
            'Project Type
            If ProjectType.Length > 0 Then
                temp = Split(ProjectType, ",")
                query = "select ID from " & dbTables & "_Project where Project_Type in ("
                first = True
                For Each item As String In temp
                    If Not first Then
                        query = query & ","
                    End If
                    query = query & "'" & item & "'"
                    first = False
                Next
                query = query & ")"
                tableTemp = SQL.Return_DataTable(query)
                If tableTemp.Rows.Count > 0 Then
                    first = True
                    If where.Length > 0 Then
                        where = where & " and "
                    End If
                    where = where & t & "Project_ID in ( "
                    For Each row As DataRow In tableTemp.Rows
                        If Not first Then
                            where = where & ","
                        End If
                        where = where & "'" & row.Item(0) & "'"
                        first = False
                    Next
                    where = where & ") "
                End If
            End If

            'Category
            If Category.Length > 0 Then
                temp = Split(Category, ",")
                first = True
                If where.Length > 0 Then
                    where = where & " and "
                End If
                where = where & t & "Category in ( "
                For Each item As String In temp
                    If Not first Then
                        where = where & ","
                    End If
                    where = where & "'" & item & "'"
                    first = False
                Next
                where = where & ") "
            End If

            'VS_Chevron
            If VSChevron.Length > 0 Then
                temp = Split(VSChevron, ",")
                first = True
                If where.Length > 0 Then
                    where = where & " and "
                End If
                where = where & t & "VS_Chevron in ( "
                For Each item As String In temp
                    If Not first Then
                        where = where & ","
                    End If
                    where = where & "'" & item & "'"
                    first = False
                Next
                where = where & ") "
            End If

            'Primary_Process
            If PrimaryProcess.Length > 0 Then
                temp = Split(PrimaryProcess, ",")
                first = True
                If where.Length > 0 Then
                    where = where & " and "
                End If
                where = where & t & "Primary_Process in ( "
                For Each item As String In temp
                    If Not first Then
                        where = where & ","
                    End If
                    where = where & "'" & item & "'"
                    first = False
                Next
                where = where & ") "
            End If
        End If

        'Owner Name
        If OwnerName.Length > 0 Then
            temp = Split(OwnerName, ",")
            query = "select ID from " & dbTables & "_Project where "
            first = True
            For Each item As String In temp
                If Not first Then
                    query = query & " or "
                End If
                query = query & "XGBS_PM like '%" & Mid(item, 10) & "%'"
                first = False
            Next
            tableTemp = SQL.Return_DataTable(query)
            If tableTemp.Rows.Count > 0 Then
                first = True
                If where.Length > 0 Then
                    where = where & " and "
                End If
                where = where & t & "Project_ID in ( "
                For Each row As DataRow In tableTemp.Rows
                    If Not first Then
                        where = where & ","
                    End If
                    where = where & "'" & row.Item(0) & "'"
                    first = False
                Next
                where = where & ") "
            End If

            If (DotNet.IsEmpty(t)) Then
                first = True
                query = ""
                where = where & " and Owner in ("
                For Each item As String In temp
                    If Not first Then
                        query = query & " , "
                    End If
                    Dim tnumber() As String = Split(item, "/")
                    query = query & " '" & Trim(tnumber(0)) & "' "
                    first = False
                Next
                where = where & query & " ) "
            End If
        End If

        'Service Line
        If ServiceLine.Length > 0 Then
            temp = Split(ServiceLine, ",")
            query = "select distinct Project_ID from " & dbTables & "_Resources where Service_Line in ("
            first = True
            For Each item As String In temp
                If Not first Then
                    query = query & ","
                End If
                query = query & "'" & item & "'"
                first = False
            Next
            query = query & ")"
            tableTemp = SQL.Return_DataTable(query)
            If tableTemp.Rows.Count > 0 Then
                first = True
                If where.Length > 0 Then
                    where = where & " and "
                End If
                where = where & t & "Project_ID in ( "
                For Each row As DataRow In tableTemp.Rows
                    If Not first Then
                        where = where & ","
                    End If
                    where = where & "'" & row.Item(0) & "'"
                    first = False
                Next
                where = where & ") "
            End If
        End If

        'User Type
        If UserType.Length > 0 Then
            temp = Split(UserType, ",")

            dataTable = UsersInfo.PeerList(AppName)
            If dataTable.Rows.Count > 0 Then
                Dim rowUser As DataRow = dataTable.NewRow
                rowUser.Item(0) = UsersInfo.TNumber
                rowUser.Item(1) = UsersInfo.Name
                dataTable.Rows.InsertAt(rowUser, 0)

                Dim role As String
                first = True
                Dim continueQuery As Boolean = False
                query = "select distinct Project_ID from " & dbTables & "_Resources where "
                For Each row As DataRow In dataTable.Rows
                    role = UsersInfo.GetRole(row.Item(0), AppName)
                    If Array.IndexOf(temp, role) <> -1 Then
                        If Not first Then
                            query = query & " or "
                        End If
                        query = query & "Owner = '" & row.Item(0) & "' "
                        first = False
                        continueQuery = True
                    End If
                Next

                If continueQuery Then
                    tableTemp = SQL.Return_DataTable(query)
                    If tableTemp.Rows.Count > 0 Then
                        first = True
                        If where.Length > 0 Then
                            where = where & " and "
                        End If
                        where = where & t & "Project_ID in ( "
                        For Each row As DataRow In tableTemp.Rows
                            If Not first Then
                                where = where & ","
                            End If
                            where = where & "'" & row.Item(0) & "'"
                            first = False
                        Next
                        where = where & ") "
                    End If
                End If
            End If
        End If

        'Region America
        If CheckBoxRegionAmerica.Checked Then
            query = "select distinct ID from " & dbTables & "_Project where Americas = 1"
            tableTemp = SQL.Return_DataTable(query)
            If tableTemp.Rows.Count > 0 Then
                first = True
                If where.Length > 0 Then
                    where = where & " and "
                End If
                where = where & t & "Project_ID in ( "
                For Each row As DataRow In tableTemp.Rows
                    If Not first Then
                        where = where & ","
                    End If
                    where = where & "'" & row.Item(0) & "'"
                    first = False
                Next
                where = where & ") "
            End If
        End If

        'Region Asia
        If CheckBoxRegionAsia.Checked Then
            query = "select distinct ID from " & dbTables & "_Project where Asia = 1"
            tableTemp = SQL.Return_DataTable(query)
            If tableTemp.Rows.Count > 0 Then
                first = True
                If where.Length > 0 Then
                    where = where & " and "
                End If
                where = where & t & "Project_ID in ( "
                For Each row As DataRow In tableTemp.Rows
                    If Not first Then
                        where = where & ","
                    End If
                    where = where & "'" & row.Item(0) & "'"
                    first = False
                Next
                where = where & ") "
            End If
        End If

        'Region EMEA
        If CheckBoxRegionEMEA.Checked Then
            query = "select distinct ID from " & dbTables & "_Project where EMEA = 1"
            tableTemp = SQL.Return_DataTable(query)
            If tableTemp.Rows.Count > 0 Then
                first = True
                If where.Length > 0 Then
                    where = where & " and "
                End If
                where = where & t & "Project_ID in ( "
                For Each row As DataRow In tableTemp.Rows
                    If Not first Then
                        where = where & ","
                    End If
                    where = where & "'" & row.Item(0) & "'"
                    first = False
                Next
                where = where & ") "
            End If
        End If

        'Region Global
        If CheckBoxRegionGlobal.Checked Then
            query = "select distinct ID from " & dbTables & "_Project where Global = 1"
            tableTemp = SQL.Return_DataTable(query)
            If tableTemp.Rows.Count > 0 Then
                first = True
                If where.Length > 0 Then
                    where = where & " and "
                End If
                where = where & t & "Project_ID in ( "
                For Each row As DataRow In tableTemp.Rows
                    If Not first Then
                        where = where & ","
                    End If
                    where = where & "'" & row.Item(0) & "'"
                    first = False
                Next
                where = where & ") "
            End If
        End If

        If where.Length > 0 Then
            where = " and (" & where & ") and " & dbTables & "_Project.ID = " & prefix & "Project_ID "
        End If

        Return where
    End Function

    Private Sub refreshData()
        If DTPStartDate.Value < DTPEndDate.Value Then
            Cursor = Cursors.WaitCursor
            drawGraph()
            Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub RawData()
        Dim dataTableR As DataTable = Nothing
        Dim dataTableA As DataTable = Nothing

        Dim sDate As Date = DTPStartDate.Value
        Dim eDate As Date = DTPEndDate.Value

        dataTableR = SQL.Return_DataTable(
            "select " & _
            "	" & dbTables & "_Resources.Project_ID, " & _
            "	" & dbTables & "_Resources.[Owner], " & _
            "	(select top 1 " & dbTables & "_Resources.Owner_Name from " & dbTables & "_Resources where " & dbTables & "_Resources.ID = " & dbTables & "_Resources.ID) as Owner_Name, " & _
            "	'' as User_Type, " & _
            "	(SELECT Americas FROM " & dbTables & "_Project where ID=" & dbTables & "_Resources.Project_ID) as Americas, " & _
            "	(SELECT EMEA FROM " & dbTables & "_Project where ID=" & dbTables & "_Resources.Project_ID) as EMEA, " & _
            "	(SELECT Asia FROM " & dbTables & "_Project where ID=" & dbTables & "_Resources.Project_ID) as Asia, " & _
            "	(SELECT Global FROM " & dbTables & "_Project where ID=" & dbTables & "_Resources.Project_ID) as Global, " & _
            "	(select Service_Line from Project_Service_Line where ID=" & dbTables & "_Resources.Service_Line) as Service_Line, " & _
            "	(select " & dbTables & "_Category.Category from " & dbTables & "_Category, " & dbTables & "_Project where " & dbTables & "_Category.ID=" & dbTables & "_Project.Category and " & dbTables & "_Project.ID=" & dbTables & "_Resources.Project_ID) as Category, " & _
            "	(select " & dbTables & "_VS_Chevron.VS_Chevron from " & dbTables & "_VS_Chevron, " & dbTables & "_Project where " & dbTables & "_VS_Chevron.ID=" & dbTables & "_Project.VS_Chevron and " & dbTables & "_Project.ID=" & dbTables & "_Resources.Project_ID) as VS_Chevron, " & _
            "	sum(" & dbTables & "_Resources.Value) as Monthly_FTE_REQ, " & _
            "	" & dbTables & "_Resources.ID as Resource_ID, " & _
            "	(select top 1 " & dbTables & "_Resources.Comment from " & dbTables & "_Resources where " & dbTables & "_Resources.ID = " & dbTables & "_Resources.ID order by " & dbTables & "_Resources.ID desc) as Resource_Description, " & _
            "	" & dbTables & "_Resources.Entry_Type, " & _
            "	(select Project_Entry_Type.Entry_Type from Project_Entry_Type where Project_Entry_Type.ID=" & dbTables & "_Resources.Entry_Type) as Entry_Type_Name " & _
            "from " & _
            "	" & dbTables & "_Resources, " & _
            "	" & dbTables & "_Project " & _
            "where " & _
            "	" & dbTables & "_Resources.Status != 0 and " & _
            "   ( " & _
            "       CI_Resources.[Start_Date] between '" & DateSerial(sDate.Year, sDate.Month, "1") & "' and '" & DateSerial(eDate.Year, eDate.Month + 1, "0") & "' and " & _
            "       CI_Resources.End_Date between '" & DateSerial(sDate.Year, sDate.Month, "1") & "' and '" & DateSerial(eDate.Year, eDate.Month + 1, "0") & "' " & _
            "   ) " & _
            filters("", "CI_Resources.") & _
            "group by " & _
            "	" & dbTables & "_Resources.Project_ID, " & _
            "	" & dbTables & "_Resources.ID, " & _
            "	" & dbTables & "_Resources.[Owner], " & _
            "	Service_Line, " & _
            "	" & dbTables & "_Resources.Entry_Type "
        )
        
        dataTableA = SQL.Return_DataTable(
            "select " & _
            "	" & dbTables & "_Actuals.Resource_ID as ResourceID, " & _
            "	sum(" & dbTables & "_Actuals.Value) as Actual_FTE, " & _
            "	CONVERT(DATE, " & dbTables & "_Actuals.Actual_Date) as [Date], " & _
            "	" & dbTables & "_Resources.Project_ID as Resources_Project_ID " & _
            "from " & _
            "	" & dbTables & "_Actuals, " & _
            "	" & dbTables & "_Resources " & _
            "where " & _
            "	" & dbTables & "_Actuals.Actual_Date between '" & DateSerial(sDate.Year, sDate.Month, "1") & "' and '" & DateSerial(eDate.Year, eDate.Month + 1, "0") & "' " & _
            "group by " & _
            "	" & dbTables & "_Actuals.Project_ID, " & _
            "	" & dbTables & "_Actuals.Resource_ID, " & _
            "	" & dbTables & "_Actuals.Actual_Date, " & _
            "	" & dbTables & "_Resources.Project_ID " & _
            "order by " & _
            "	" & dbTables & "_Resources.Project_ID "
        )

        dataTableF.Clear()
        dataTableF.Columns.Clear()

        For Each column As DataColumn In dataTableR.Columns
            dataTableF.Columns.Add(column.ColumnName)
        Next
        For Each column As DataColumn In dataTableA.Columns
            dataTableF.Columns.Add(column.ColumnName)
        Next

        Dim rowF As Integer = 0
        For Each rowR As DataRow In dataTableR.Rows
            For Each rowA As DataRow In dataTableA.Rows
                Dim columnF As Integer = 0
                Dim trow As DataRow = dataTableF.NewRow()
                dataTableF.Rows.Add(trow)
                For column As Integer = 0 To (dataTableR.Columns.Count - 1)
                    If IsDate(rowR.Item(column)) Then
                        dataTableF.Rows(rowF).Item(column) = FormatDateTime(rowR.Item(column), DateFormat.ShortDate)
                    Else
                        dataTableF.Rows(rowF).Item(column) = rowR.Item(column)
                    End If
                Next
                For column As Integer = 0 To (dataTableA.Columns.Count - 1)
                    If (rowR.Item("Resource_ID") = rowA.Item(0)) Then
                        If IsDate(rowA.Item(column)) Then
                            dataTableF.Rows(rowF).Item(column + dataTableR.Columns.Count) = FormatDateTime(rowA.Item(column), DateFormat.ShortDate)
                        ElseIf column = 1 Then
                            dataTableF.Rows(rowF).Item(column + dataTableR.Columns.Count) = getMonthlyFTE(rowR.Item("Entry_Type_Name"), rowA.Item(column))
                        Else
                            dataTableF.Rows(rowF).Item(column + dataTableR.Columns.Count) = rowA.Item(column)
                        End If
                    End If
                Next
                dataTableF.Rows(rowF).Item("Monthly_FTE_REQ") = getMonthlyFTE(rowR.Item("Entry_Type_Name"), rowR.Item("Monthly_FTE_REQ"))
                rowF = rowF + 1
            Next
        Next

        For i As Integer = 0 To (dataTableF.Rows.Count - 1)
            If Not DotNet.IsEmpty(dataTableF.Rows(i).Item("ResourceID")) Then
                dataTableF.Rows(i).Item("User_Type") = UsersInfo.GetRole(dataTableF.Rows(i).Item("Owner"), AppName)
            End If
        Next

        For Each column As System.Data.DataColumn In dataTableF.Columns
            dataTableF.Columns(column.ColumnName).ColumnName = Replace(column.ColumnName, "_", " ")
        Next

        BindingSource.DataSource = dataTableF
        DataGridView.DataSource = dataTableF

        DataGridView.Columns.Remove("Project ID")
        DataGridView.Columns.Remove("Owner")
        DataGridView.Columns.Remove("Resource ID")
        DataGridView.Columns.Remove("Entry Type")
        DataGridView.Columns.Remove("ResourceID")
        DataGridView.Columns.Remove("Resources Project ID")

        AxSpreadsheet.Worksheets(1).usedrange.clear()

        For cl As Integer = 0 To DataGridView.Columns.Count - 1
            AxSpreadsheet.Worksheets(1).Cells(1, cl + 1) = DataGridView.Columns(cl).HeaderText.ToString
        Next
        For ro As Integer = 1 To DataGridView.Rows.Count - 1
            For cl As Integer = 0 To DataGridView.Columns.Count - 1
                If DataGridView.Item(cl, ro).Value.ToString = "True" Then
                    AxSpreadsheet.Worksheets(1).Cells(ro + 1, cl + 1) = "Yes"
                ElseIf DataGridView.Item(cl, ro).Value.ToString = "False" Then
                    AxSpreadsheet.Worksheets(1).Cells(ro + 1, cl + 1) = "No"
                Else
                    AxSpreadsheet.Worksheets(1).Cells(ro + 1, cl + 1) = DataGridView.Item(cl, ro).Value.ToString
                End If
            Next
        Next
    End Sub

    'Excel 
    Public Function ExportDataTableToExcel(ByRef DT As DataTable, ByVal FilePath As String, ByVal Sheet As String, ByVal SheetLocation As String) As Boolean

        Try
            Dim WB_EEPLUS As New ExcelPackage(New IO.FileInfo(FilePath))
            WB_EEPLUS.Workbook.Worksheets.Add(Sheet)
            WB_EEPLUS.Workbook.Worksheets(Sheet).Cells(SheetLocation).LoadFromDataTable(DT, True, Table.TableStyles.Light1)

            'Set Column Format for DateTime (When Location = A1) 
            Dim ColumIndex As Integer = 0
            For Each C As DataColumn In DT.Columns
                Try
                    If C.DataType.FullName = "System.DateTime" Then
                        WB_EEPLUS.Workbook.Worksheets(Sheet).Column(ColumIndex + 1).Style.Numberformat.Format = "mm-dd-yy"
                    End If
                    ColumIndex += 1
                Catch ex As Exception
                End Try
            Next

            'Set Header Color 
            For I = 1 To DT.Columns.Count
                WB_EEPLUS.Workbook.Worksheets(Sheet).Cells(1, I).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
                WB_EEPLUS.Workbook.Worksheets(Sheet).Cells(1, I).Style.Fill.BackgroundColor.SetColor(Color.MidnightBlue)
                WB_EEPLUS.Workbook.Worksheets(Sheet).Cells(1, I).Style.Font.Color.SetColor(Color.White)
                WB_EEPLUS.Workbook.Worksheets(Sheet).Cells(1, I).AutoFitColumns()
            Next

            WB_EEPLUS.Save()
            ExportDataTableToExcel = True
        Catch ex As Exception
            ExportDataTableToExcel = False
        End Try
    End Function

    Private Sub drawGraph()
        Chart.Titles(0).Text = "Continuos Improvement Allocation Report"
        Chart.Series(0).Name = "Total Forecast"
        Chart.Series(1).Name = "Total Actuals"

        Dim dataTableForecast As DataTable
        Dim dataTableActuals As DataTable

        Dim sDate As Date = DTPStartDate.Value
        Dim eDate As Date = DTPEndDate.Value

        Dim curDate As Date = sDate
        Dim totalDays As Integer

        Chart.Series(0).Points.Clear()
        Chart.Series(1).Points.Clear()

        dataTableForecast = SQL.Return_DataTable(
            "select " & _
                "resources.Project_ID, " & _
                "resources.ID, " & _
                "(select Project_Entry_Type.Entry_Type from Project_Entry_Type where Project_Entry_Type.ID = resources.Entry_Type) as Entry_Type, " & _
                "resources.Value, " & _
                "resources.Recurrence " & _
            "from " & _
                dbTables & "_Resources as resources " & _
                ", " & dbTables & "_Project " & _
            "where " & _
                "resources.Status != 0 and " & _
                "resources.Start_Date between '" & DateSerial(sDate.Year, sDate.Month, "1") & "' and '" & DateSerial(eDate.Year, eDate.Month + 1, "0") & "' and " & _
                "resources.End_Date between '" & DateSerial(sDate.Year, sDate.Month, "1") & "' and '" & DateSerial(eDate.Year, eDate.Month + 1, "0") & "' " & _
                filters("", "resources.") & _
            "order by " & _
                "resources.Project_ID asc, " & _
                "resources.ID asc, " & _
                "resources.Entry_Type asc "
        )
        dataTableActuals = SQL.Return_DataTable(
            "select " & _
                dbTables & "_Actuals.Project_ID, " & _
                dbTables & "_Actuals.Resource_ID, " & _
                "(SELECT Project_Entry_Type.Entry_Type FROM Project_Entry_Type, " & dbTables & "_Resources WHERE Project_Entry_Type.ID = " & dbTables & "_Resources.Entry_Type and " & dbTables & "_Resources.ID = " & dbTables & "_Actuals.Resource_ID) as Entry_Type, " & _
                "sum(" & dbTables & "_Actuals.Value) as Value, " & _
                "CONVERT(DATE, " & dbTables & "_Actuals.Actual_Date) as [Date] " & _
            "from " & _
                dbTables & "_Actuals " & _
            "where " & _
                dbTables & "_Actuals.Actual_Date between '" & DateSerial(sDate.Year, sDate.Month, sDate.Day) & "' and '" & DateSerial(eDate.Year, eDate.Month, eDate.Day + 1) & "' " & _
                filters(dbTables & "_Actuals") & _
            "group by " & _
                dbTables & "_Actuals.Project_ID, " & _
                dbTables & "_Actuals.Resource_ID, " & _
                dbTables & "_Actuals.Actual_Date " & _
            "order by " & _
                "Project_ID asc, " & _
                "Resource_ID asc"
        )
        Try
            While curDate <= eDate
                If curDate.DayOfWeek <> DayOfWeek.Saturday And curDate.DayOfWeek <> DayOfWeek.Sunday Then
                    totalDays = totalDays + 1
                End If
                curDate = curDate.AddDays(1)
            End While

            If totalDays > 31 Then
                Dim dTemp As Date = DateSerial(sDate.Year, sDate.Month, "1")

                Dim TotalForecast As Decimal = 0
                While dTemp <= DateSerial(eDate.Year, eDate.Month + 1, "0")
                    TotalForecast = 0
                    For Each row As DataRow In dataTableForecast.Rows
                        If getDates(dTemp, row.Item("Recurrence")) Then
                            TotalForecast = TotalForecast + getMonthlyFTE(row.Item("Entry_Type").ToString, row.Item("Value"))
                        End If
                    Next
                    Chart.Series(0).Points.AddXY(FormatDateTime(dTemp, DateFormat.ShortDate), TotalForecast)
                    dTemp = DateSerial(dTemp.Year, dTemp.Month + 1, dTemp.Day)
                End While

                Dim TotalActuals As Decimal = 0
                dTemp = DateSerial(sDate.Year, sDate.Month, "1")
                While dTemp <= DateSerial(eDate.Year, eDate.Month + 1, "0")
                    TotalActuals = 0
                    For Each row As DataRow In dataTableActuals.Rows
                        Dim TDate2 As Date = row.Item("Date")
                        If dTemp = DateSerial(TDate2.Year, TDate2.Month, "1") Then
                            TotalActuals = TotalActuals + getMonthlyFTE(row.Item("Entry_Type").ToString, row.Item("Value"))
                        End If
                    Next
                    Chart.Series(1).Points.AddXY(FormatDateTime(dTemp, DateFormat.ShortDate), TotalActuals)
                    dTemp = DateSerial(dTemp.Year, dTemp.Month + 1, dTemp.Day)
                End While
            Else
                Dim TotalForecast As Decimal = 0

                If Not dataTableForecast Is Nothing Then
                    For Each row As DataRow In dataTableForecast.Rows
                        TotalForecast = TotalForecast + getMonthlyFTE(row.Item("Entry_Type").ToString, row.Item("Value"))
                    Next

                    curDate = DateSerial(sDate.Year, sDate.Month, sDate.Day)
                    Dim TotalActuals As Decimal
                    While curDate <= DateSerial(eDate.Year, eDate.Month, eDate.Day)
                        If curDate.DayOfWeek <> DayOfWeek.Saturday And curDate.DayOfWeek <> DayOfWeek.Sunday Then
                            TotalActuals = 0
                            For Each row As DataRow In dataTableActuals.Rows
                                Dim TDate2 As Date = row.Item("Date")
                                If curDate = DateSerial(TDate2.Year, TDate2.Month, TDate2.Day) Then
                                    TotalActuals = TotalActuals + getMonthlyFTE(row.Item("Entry_Type").ToString, row.Item("Value"))
                                End If
                            Next
                            Chart.Series(0).Points.AddXY(FormatDateTime(curDate, DateFormat.ShortDate), TotalForecast)
                            Chart.Series(1).Points.AddXY(FormatDateTime(curDate, DateFormat.ShortDate), TotalActuals)
                        End If
                        curDate = curDate.AddDays(1)
                    End While
                End If
            End If
            Chart.DataBind()
            RawData()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub ButtonProjectName_Click(sender As Object, e As EventArgs) Handles ButtonProjectName.Click
        Frm_Report_Popup.fields = "ID, Project_Name"
        Frm_Report_Popup.tables = dbTables & "_Project"
        Frm_Report_Popup.selected = ProjectID
        Frm_Report_Popup.ShowDialog(Me)

        ProjectID = Frm_Report_Popup.retorno

        Dim temp() As String = Split(Frm_Report_Popup.retorno, ",")
        If temp.Count > 0 And Frm_Report_Popup.retorno.Length > 0 Then
            sender.Text = temp.Count & " item(s) selected"
        Else
            sender.Text = "Select..."
        End If

        Frm_Report_Popup.Dispose()
    End Sub

    Private Sub ButtonOwnerName_Click(sender As Object, e As EventArgs) Handles ButtonOwnerName.Click
        Frm_Report_Popup.tables = "peerList"
        Frm_Report_Popup.returnField = 1
        Frm_Report_Popup.selected = OwnerName
        Frm_Report_Popup.ShowDialog(Me)

        OwnerName = Frm_Report_Popup.retorno

        Dim temp() As String = Split(Frm_Report_Popup.retorno, ",")
        If temp.Count > 0 And Frm_Report_Popup.retorno.Length > 0 Then
            sender.Text = temp.Count & " item(s) selected"
        Else
            sender.Text = "Select..."
        End If

        Frm_Report_Popup.Dispose()
    End Sub

    Private Sub ButtonServiceLine_Click(sender As Object, e As EventArgs) Handles ButtonServiceLine.Click
        Frm_Report_Popup.fields = "ID, Service_Line"
        Frm_Report_Popup.tables = "Project_Service_Line"
        Frm_Report_Popup.selected = ServiceLine
        Frm_Report_Popup.ShowDialog(Me)

        ServiceLine = Frm_Report_Popup.retorno

        Dim temp() As String = Split(Frm_Report_Popup.retorno, ",")
        If temp.Count > 0 And Frm_Report_Popup.retorno.Length > 0 Then
            sender.Text = temp.Count & " item(s) selected"
        Else
            sender.Text = "Select..."
        End If

        Frm_Report_Popup.Dispose()
    End Sub

    Private Sub ButtonProjectType_Click(sender As Object, e As EventArgs) Handles ButtonProjectType.Click
        Frm_Report_Popup.fields = "ID, Project_Type"
        Frm_Report_Popup.tables = dbTables & "_Project_Type"
        Frm_Report_Popup.selected = ProjectType
        Frm_Report_Popup.ShowDialog(Me)

        ProjectType = Frm_Report_Popup.retorno

        Dim temp() As String = Split(Frm_Report_Popup.retorno, ",")
        If temp.Count > 0 And Frm_Report_Popup.retorno.Length > 0 Then
            sender.Text = temp.Count & " item(s) selected"
        Else
            sender.Text = "Select..."
        End If

        Frm_Report_Popup.Dispose()
    End Sub

    Private Sub ButtonUserType_Click(sender As Object, e As EventArgs) Handles ButtonUserType.Click
        Frm_Report_Popup.fields = "ID, Role"
        Frm_Report_Popup.returnField = 1
        Frm_Report_Popup.tables = "Role"
        Frm_Report_Popup.selected = UserType
        Frm_Report_Popup.ShowDialog(Me)

        UserType = Frm_Report_Popup.retorno

        Dim temp() As String = Split(Frm_Report_Popup.retorno, ",")
        If temp.Count > 0 And Frm_Report_Popup.retorno.Length > 0 Then
            sender.Text = temp.Count & " item(s) selected"
        Else
            sender.Text = "Select..."
        End If

        Frm_Report_Popup.Dispose()
    End Sub

    Private Sub ButtonVSChevron_Click(sender As Object, e As EventArgs) Handles ButtonVSChevron.Click
        If Category.Length > 0 Then
            Frm_Report_Popup.fields = "ID, VS_Chevron"
            Frm_Report_Popup.tables = dbTables & "_VS_Chevron"
            Frm_Report_Popup.where = "where ID_Category IN (" & Category & ")"
            Frm_Report_Popup.selected = VSChevron
            Frm_Report_Popup.ShowDialog(Me)

            VSChevron = Frm_Report_Popup.retorno

            Dim temp() As String = Split(Frm_Report_Popup.retorno, ",")
            If temp.Count > 0 And Frm_Report_Popup.retorno.Length > 0 Then
                sender.Text = temp.Count & " item(s) selected"
            Else
                sender.Text = "Select..."
            End If

            Frm_Report_Popup.Dispose()
        Else
            MessageBox.Show("Please, select category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ButtonProjectCategory_Click(sender As Object, e As EventArgs) Handles ButtonProjectCategory.Click
        Frm_Report_Popup.fields = "ID, Category"
        Frm_Report_Popup.tables = dbTables & "_Category"
        Frm_Report_Popup.selected = Category
        Frm_Report_Popup.ShowDialog(Me)

        Category = Frm_Report_Popup.retorno

        Dim temp() As String = Split(Frm_Report_Popup.retorno, ",")
        If temp.Count > 0 And Frm_Report_Popup.retorno.Length > 0 Then
            sender.Text = temp.Count & " item(s) selected"
        Else
            sender.Text = "Select..."
        End If

        Frm_Report_Popup.Dispose()
    End Sub

    Private Sub ButtonPrimaryProcess_Click(sender As Object, e As EventArgs) Handles ButtonPrimaryProcess.Click
        If VSChevron.Length > 0 Then
            Frm_Report_Popup.fields = "ID, Primary_Process"
            Frm_Report_Popup.tables = dbTables & "_Primary_Process"
            Frm_Report_Popup.where = "where ID_VS_Chevron IN (" & VSChevron & ") "
            Frm_Report_Popup.selected = PrimaryProcess
            Frm_Report_Popup.ShowDialog(Me)

            PrimaryProcess = Frm_Report_Popup.retorno

            Dim temp() As String = Split(Frm_Report_Popup.retorno, ",")
            If temp.Count > 0 And Frm_Report_Popup.retorno.Length > 0 Then
                sender.Text = temp.Count & " item(s) selected"
            Else
                sender.Text = "Select..."
            End If

            Frm_Report_Popup.Dispose()
        Else
            MessageBox.Show("Please, select VS Chevron.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ToolStripButtonExcel_Click(sender As Object, e As EventArgs) Handles ToolStripButtonExcel.Click
        Dim fileName As String
        SaveFileDialog.Filter = "Excel File | *.xlsx"
        SaveFileDialog.ShowDialog(Me)
        fileName = SaveFileDialog.FileName

        Dim dataTemp As DataTable = dataTableF

        dataTemp.Columns.RemoveAt(0)
        dataTemp.Columns.RemoveAt(1)
        dataTemp.Columns.RemoveAt(7)
        dataTemp.Columns.RemoveAt(8)

        If ExportDataTableToExcel(dataTemp, fileName, "Report", "A1") Then
            MessageBox.Show("The export was successful.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("There has been an error, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ToolStripButtonGraphic_Click(sender As Object, e As EventArgs) Handles ToolStripButtonGraphic.Click
        Dim fileName As String
        SaveFileDialog.Filter = "Image | *.png"
        If SaveFileDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            fileName = SaveFileDialog.FileName
            Chart.SaveImage(fileName, System.Drawing.Imaging.ImageFormat.Png)
        End If
    End Sub
End Class