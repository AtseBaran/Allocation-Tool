Imports OfficeOpenXml

Public Class Frm_Reports
    Friend dbTables As String = ""

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

    Private Sub Frm_Reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearFilters()
        refreshData()
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

    Private Sub refreshData()
        If DTPStartDate.Value < DTPEndDate.Value Then
            drawGraph()
        End If
    End Sub

    Private Sub ToolStripButtonRefresh_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRefresh.Click
        refreshData()
    End Sub

    Private Sub ToolStripButtonClear_Click(sender As Object, e As EventArgs) Handles ToolStripButtonClear.Click
        clearFilters()
        refreshData()
    End Sub

    Private Sub ToolStripButtonExcel_Click(sender As Object, e As EventArgs) Handles ToolStripButtonExcel.Click
        Dim fileName As String
        SaveFileDialog.Filter = "Excel File | *.xlsx"
        SaveFileDialog.ShowDialog(Me)
        fileName = SaveFileDialog.FileName

        Dim dataTemp As DataTable = dataTableF

        dataTemp.Columns.RemoveAt(0)
        dataTemp.Columns.RemoveAt(7)
        dataTemp.Columns.RemoveAt(9)
        dataTemp.Columns.RemoveAt(11)

        If ExportDataTableToExcel(dataTemp, fileName, "Report", "A1") Then
            MessageBox.Show("The export was successful.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("There has been an error, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
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

    Private Sub ToolStripButtonGraphic_Click(sender As Object, e As EventArgs) Handles ToolStripButtonGraphic.Click
        Dim fileName As String
        SaveFileDialog.Filter = "Image | *.png"
        If SaveFileDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            fileName = SaveFileDialog.FileName
            Chart.SaveImage(fileName, System.Drawing.Imaging.ImageFormat.Png)
        End If
    End Sub

    Private Sub ButtonProjectCategory_Click(sender As Object, e As EventArgs) Handles ButtonProjectCategory.Click
        Frm_Reports_Popup.fields = "ID, Category"
        Frm_Reports_Popup.tables = dbTables & "_Category"
        Frm_Reports_Popup.sqlQuery = ""
        Frm_Reports_Popup.selected = Category
        Frm_Reports_Popup.ShowDialog(Me)

        Category = Frm_Reports_Popup.retorno

        Dim temp() As String = Split(Frm_Reports_Popup.retorno, ",")
        If temp.Count > 0 And Frm_Reports_Popup.retorno.Length > 0 Then
            sender.Text = temp.Count & " item(s) selected"
        Else
            sender.Text = "Select..."
        End If

        Frm_Reports_Popup.Dispose()
    End Sub

    Private Sub ButtonProjectName_Click(sender As Object, e As EventArgs) Handles ButtonProjectName.Click
        Frm_Reports_Popup.fields = "ID, Project_Name"
        Frm_Reports_Popup.tables = dbTables & "_Project"
        Frm_Reports_Popup.selected = ProjectID
        Frm_Reports_Popup.ShowDialog(Me)

        ProjectID = Frm_Reports_Popup.retorno

        Dim temp() As String = Split(Frm_Reports_Popup.retorno, ",")
        If temp.Count > 0 And Frm_Reports_Popup.retorno.Length > 0 Then
            sender.Text = temp.Count & " item(s) selected"
        Else
            sender.Text = "Select..."
        End If

        Frm_Reports_Popup.Dispose()
    End Sub

    Private Sub ButtonProjectType_Click(sender As Object, e As EventArgs) Handles ButtonProjectType.Click
        Frm_Reports_Popup.fields = "ID, Project_Type"
        Frm_Reports_Popup.tables = dbTables & "_Project_Type"
        Frm_Reports_Popup.selected = ProjectType
        Frm_Reports_Popup.ShowDialog(Me)

        ProjectType = Frm_Reports_Popup.retorno

        Dim temp() As String = Split(Frm_Reports_Popup.retorno, ",")
        If temp.Count > 0 And Frm_Reports_Popup.retorno.Length > 0 Then
            sender.Text = temp.Count & " item(s) selected"
        Else
            sender.Text = "Select..."
        End If

        Frm_Reports_Popup.Dispose()
    End Sub

    Private Sub ButtonOwnerName_Click(sender As Object, e As EventArgs) Handles ButtonOwnerName.Click
        Frm_Reports_Popup.tables = "peerList"
        Frm_Reports_Popup.sqlQuery = "peerList"
        Frm_Reports_Popup.returnField = 1
        Frm_Reports_Popup.selected = OwnerName
        Frm_Reports_Popup.ShowDialog(Me)

        OwnerName = Frm_Reports_Popup.retorno

        Dim temp() As String = Split(Frm_Reports_Popup.retorno, ",")
        If temp.Count > 0 And Frm_Reports_Popup.retorno.Length > 0 Then
            sender.Text = temp.Count & " item(s) selected"
        Else
            sender.Text = "Select..."
        End If

        Frm_Reports_Popup.Dispose()
    End Sub

    Private Sub ButtonUserType_Click(sender As Object, e As EventArgs) Handles ButtonUserType.Click
        Frm_Reports_Popup.fields = "ID, Role"
        Frm_Reports_Popup.returnField = 1
        Frm_Reports_Popup.tables = "Role"
        Frm_Reports_Popup.selected = UserType
        Frm_Reports_Popup.ShowDialog(Me)

        UserType = Frm_Reports_Popup.retorno

        Dim temp() As String = Split(Frm_Reports_Popup.retorno, ",")
        If temp.Count > 0 And Frm_Reports_Popup.retorno.Length > 0 Then
            sender.Text = temp.Count & " item(s) selected"
        Else
            sender.Text = "Select..."
        End If

        Frm_Reports_Popup.Dispose()
    End Sub

    Private Sub ButtonServiceLine_Click(sender As Object, e As EventArgs) Handles ButtonServiceLine.Click
        Frm_Reports_Popup.fields = "ID, Service_Line"
        Frm_Reports_Popup.tables = "Project_Service_Line"
        Frm_Reports_Popup.selected = ServiceLine
        Frm_Reports_Popup.ShowDialog(Me)

        ServiceLine = Frm_Reports_Popup.retorno

        Dim temp() As String = Split(Frm_Reports_Popup.retorno, ",")
        If temp.Count > 0 And Frm_Reports_Popup.retorno.Length > 0 Then
            sender.Text = temp.Count & " item(s) selected"
        Else
            sender.Text = "Select..."
        End If

        Frm_Reports_Popup.Dispose()
    End Sub

    Private Sub ButtonVSChevron_Click(sender As Object, e As EventArgs) Handles ButtonVSChevron.Click
        If Category.Length > 0 Then
            Frm_Reports_Popup.fields = "ID, VS_Chevron"
            Frm_Reports_Popup.tables = dbTables & "_VS_Chevron"
            Frm_Reports_Popup.where = "where ID_Category IN (" & Category & ")"
            Frm_Reports_Popup.selected = VSChevron
            Frm_Reports_Popup.ShowDialog(Me)

            VSChevron = Frm_Reports_Popup.retorno

            Dim temp() As String = Split(Frm_Reports_Popup.retorno, ",")
            If temp.Count > 0 And Frm_Reports_Popup.retorno.Length > 0 Then
                sender.Text = temp.Count & " item(s) selected"
            Else
                sender.Text = "Select..."
            End If

            Frm_Reports_Popup.Dispose()
        Else
            MessageBox.Show("Please, select category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ButtonPrimaryProcess_Click(sender As Object, e As EventArgs) Handles ButtonPrimaryProcess.Click
        If VSChevron.Length > 0 Then
            Frm_Reports_Popup.fields = "ID, Primary_Process"
            Frm_Reports_Popup.tables = dbTables & "_Primary_Process"
            Frm_Reports_Popup.where = "where ID_VS_Chevron IN (" & VSChevron & ") "
            Frm_Reports_Popup.selected = PrimaryProcess
            Frm_Reports_Popup.ShowDialog(Me)

            PrimaryProcess = Frm_Reports_Popup.retorno

            Dim temp() As String = Split(Frm_Reports_Popup.retorno, ",")
            If temp.Count > 0 And Frm_Reports_Popup.retorno.Length > 0 Then
                sender.Text = temp.Count & " item(s) selected"
            Else
                sender.Text = "Select..."
            End If

            Frm_Reports_Popup.Dispose()
        Else
            MessageBox.Show("Please, select VS Chevron.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

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

    Private Sub DTPEndDate_ValueChanged(sender As Object, e As EventArgs) Handles DTPEndDate.ValueChanged
        If DTPEndDate.Value < DTPStartDate.Value Then
            'MessageBox.Show("The date range is not correct, please verify.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            'drawGraph()
        End If
    End Sub

    Private Sub DTPStartDate_ValueChanged(sender As Object, e As EventArgs) Handles DTPStartDate.ValueChanged
        If DTPEndDate.Value < DTPStartDate.Value Then
            'MessageBox.Show("The date range is not correct, please verify.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            'drawGraph()
        End If
    End Sub

    Private Sub drawGraph()
        Chart.Titles(0).Text = "Allocation Report"
        Chart.Series(0).Name = "Total Forecast"
        Chart.Series(1).Name = "Total Actuals"

        Dim dataTableForecast1 As DataTable = Nothing
        Dim dataTableForecast2 As DataTable = Nothing
        Dim dataTableForecast3 As DataTable = Nothing
        Dim dataTableForecast As New DataTable
        Dim dataTableActuals1 As DataTable = Nothing
        Dim dataTableActuals2 As DataTable = Nothing
        Dim dataTableActuals3 As DataTable = Nothing
        Dim dataTableActuals As New DataTable

        Dim sDate As Date = DTPStartDate.Value
        Dim eDate As Date = DTPEndDate.Value

        Dim curDate As Date = sDate
        Dim totalDays As Integer

        Chart.Series(0).Points.Clear()
        Chart.Series(1).Points.Clear()

        dataTableForecast.Columns.Add("Project_ID")
        dataTableForecast.Columns.Add("ID")
        dataTableForecast.Columns.Add("Entry_Type")
        dataTableForecast.Columns.Add("Value")
        dataTableForecast.Columns.Add("Date")
        dataTableForecast.Columns.Add("Recurrence")

        dbTables = "CP"
        dataTableForecast1 = SQL.Return_DataTable(
            "select " & _
                "resources.Project_ID, " & _
                "resources.ID, " & _
                "(select Project_Entry_Type.Entry_Type from Project_Entry_Type where Project_Entry_Type.ID = resources.Entry_Type) as Entry_Type, " & _
                "sum(resources.Value) as Value, " & _
                "resources.Month as [Date], " & _
                "'' as 'Recurrence'" & _
            "from " & _
                dbTables & "_Resources as resources " & _
            "where " & _
                "resources.Status != 0 and " & _
                "resources.Month between '" & DateSerial(sDate.Year, sDate.Month, "1") & "' and '" & DateSerial(eDate.Year, eDate.Month + 1, "0") & "' " & _
                filters("") & _
            "group by " & _
                "resources.Project_ID, " & _
                "resources.ID, " & _
                "Entry_Type, " & _
                "resources.Month " & _
            "order by " & _
                "[Date] asc, " & _
                "Project_ID asc, " & _
                "ID asc	"
        )
        dbTables = "PSS"
        dataTableForecast3 = SQL.Return_DataTable(
            "select " & _
                "resources.Project_ID, " & _
                "resources.ID, " & _
                "(select Project_Entry_Type.Entry_Type from Project_Entry_Type where Project_Entry_Type.ID = resources.Entry_Type) as Entry_Type, " & _
                "sum(resources.Value) as Value, " & _
                "resources.Month as [Date], " & _
                "'' as 'Recurrence'" & _
            "from " & _
                dbTables & "_Resources as resources " & _
            "where " & _
                "resources.Status != 0 and " & _
                "resources.Month between '" & DateSerial(sDate.Year, sDate.Month, "1") & "' and '" & DateSerial(eDate.Year, eDate.Month + 1, "0") & "' " & _
                filters("") & _
            "group by " & _
                "resources.Project_ID, " & _
                "resources.ID, " & _
                "Entry_Type, " & _
                "resources.Month " & _
            "order by " & _
                "[Date] asc, " & _
                "Project_ID asc, " & _
                "ID asc	"
        )
        dbTables = "CI"
        dataTableForecast2 = SQL.Return_DataTable(
            "select " & _
                "resources.Project_ID, " & _
                "resources.ID, " & _
                "(select Project_Entry_Type.Entry_Type from Project_Entry_Type where Project_Entry_Type.ID = resources.Entry_Type) as Entry_Type, " & _
                "resources.Value, " & _
                "'' as [Date]," & _
                "resources.Recurrence " & _
            "from " & _
                dbTables & "_Resources as resources " & _
            "where " & _
                "resources.Status != 0 and " & _
                "resources.Start_Date between '" & DateSerial(sDate.Year, sDate.Month, "1") & "' and '" & DateSerial(eDate.Year, eDate.Month + 1, "0") & "' and " & _
                "resources.End_Date between '" & DateSerial(sDate.Year, sDate.Month, "1") & "' and '" & DateSerial(eDate.Year, eDate.Month + 1, "0") & "' " & _
                filters("") & _
            "order by " & _
                "resources.Project_ID asc, " & _
                "resources.ID asc, " & _
                "resources.Entry_Type asc "
        )

        For Each row As DataRow In dataTableForecast1.Rows
            dataTableForecast.ImportRow(row)
        Next
        For Each row As DataRow In dataTableForecast3.Rows
            dataTableForecast.ImportRow(row)
        Next
        For Each row As DataRow In dataTableForecast2.Rows
            dataTableForecast.ImportRow(row)
        Next

        dataTableActuals.Columns.Add("Project_ID")
        dataTableActuals.Columns.Add("Resource_ID")
        dataTableActuals.Columns.Add("Entry_Type")
        dataTableActuals.Columns.Add("Value")
        dataTableActuals.Columns.Add("Date")

        dbTables = "CP"
        dataTableActuals1 = SQL.Return_DataTable(
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
                where & _
            "group by " & _
                dbTables & "_Actuals.Project_ID, " & _
                dbTables & "_Actuals.Resource_ID, " & _
                dbTables & "_Actuals.Actual_Date " & _
            "order by " & _
                "[Date] asc, " & _
                "Project_ID asc, " & _
                "Resource_ID asc"
        )
        dbTables = "PSS"
        dataTableActuals3 = SQL.Return_DataTable(
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
                where & _
            "group by " & _
                dbTables & "_Actuals.Project_ID, " & _
                dbTables & "_Actuals.Resource_ID, " & _
                dbTables & "_Actuals.Actual_Date " & _
            "order by " & _
                "[Date] asc, " & _
                "Project_ID asc, " & _
                "Resource_ID asc"
        )
        dbTables = "CI"
        dataTableActuals2 = SQL.Return_DataTable(
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
                where & _
            "group by " & _
                dbTables & "_Actuals.Project_ID, " & _
                dbTables & "_Actuals.Resource_ID, " & _
                dbTables & "_Actuals.Actual_Date " & _
            "order by " & _
                "Project_ID asc, " & _
                "Resource_ID asc"
        )
        For Each row As DataRow In dataTableActuals1.Rows
            dataTableActuals.ImportRow(row)
        Next
        For Each row As DataRow In dataTableActuals3.Rows
            dataTableActuals.ImportRow(row)
        Next
        For Each row As DataRow In dataTableActuals2.Rows
            dataTableActuals.ImportRow(row)
        Next

        While curDate <= eDate
            If curDate.DayOfWeek <> DayOfWeek.Saturday And curDate.DayOfWeek <> DayOfWeek.Sunday Then
                totalDays = totalDays + 1
            End If
            curDate = curDate.AddDays(1)
        End While

        If totalDays > 23 Then
            Dim dTemp As Date = DateSerial(sDate.Year, sDate.Month, "1")

            Dim TotalForecast As Decimal = 0
            While dTemp <= DateSerial(eDate.Year, eDate.Month + 1, "0")
                TotalForecast = 0
                For Each row As DataRow In dataTableForecast.Rows
                    If Not DotNet.IsEmpty(row.Item("Date")) Then
                        If dTemp = row.Item("Date") Then
                            TotalForecast = TotalForecast + getMonthlyFTE(row.Item("Entry_Type").ToString, row.Item("Value"))
                        End If
                    Else
                        ' Recurrence
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
                    If Not DotNet.IsEmpty(row.Item("Date")) Then
                        Dim TDate2 As Date = row.Item("Date")
                        If dTemp = DateSerial(TDate2.Year, TDate2.Month, "1") Then
                            TotalActuals = TotalActuals + getMonthlyFTE(row.Item("Entry_Type").ToString, row.Item("Value"))
                        End If
                    Else
                        ' Recurrence
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
                            If Not DotNet.IsEmpty(row.Item("Date")) Then
                                Dim TDate2 As Date = row.Item("Date")
                                If curDate = DateSerial(TDate2.Year, TDate2.Month, TDate2.Day) Then
                                    TotalActuals = TotalActuals + getMonthlyFTE(row.Item("Entry_Type").ToString, row.Item("Value"))
                                End If
                            Else
                                ' Recurrence
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
    End Sub

    Private Sub RawData()
        Dim dataTableR1 As DataTable = Nothing
        Dim dataTableR2 As DataTable = Nothing
        Dim dataTableR3 As DataTable = Nothing
        Dim dataTableR As New DataTable
        Dim dataTableA1 As DataTable = Nothing
        Dim dataTableA2 As DataTable = Nothing
        Dim dataTableA3 As DataTable = Nothing
        Dim dataTableA As New DataTable

        Dim sDate As Date = DTPStartDate.Value
        Dim eDate As Date = DTPEndDate.Value

        dbTables = "CP"
        dataTableR1 = SQL.Return_DataTable(
            "(select " & _
                dbTables & "_Resources.Project_ID, " & _
                "(select " & dbTables & "_Project.Project_Name from " & dbTables & "_Project where " & dbTables & "_Project.ID=" & dbTables & "_Resources.Project_ID) as Project_Name, " & _
                dbTables & "_Resources.Month as Month, " & _
                "sum(" & dbTables & "_Resources.Value) as Monthly_FTE_REQ, " & _
                "(select " & dbTables & "_Project.XGBS_PM from " & dbTables & "_Project where " & dbTables & "_Project.ID=" & dbTables & "_Resources.Project_ID) as XGBS_PM, " & _
                dbTables & "_Resources.[Owner], " & _
                "(select top 1 " & dbTables & "_Resources.Owner_Name from " & dbTables & "_Resources where " & dbTables & "_Resources.ID = " & dbTables & "_Resources.ID) as Owner_Name, " & _
                dbTables & "_Resources.ID as Resource_ID, " & _
                "(select top 1 " & dbTables & "_Resources.Comment from " & dbTables & "_Resources where " & dbTables & "_Resources.ID = " & dbTables & "_Resources.ID) as Resource_Description, " & _
                dbTables & "_Resources.Entry_Type, " & _
                "(select Project_Entry_Type.Entry_Type from Project_Entry_Type where Project_Entry_Type.ID=" & dbTables & "_Resources.Entry_Type) as Entry_Type_Name, " & _
                "'' as MonthlyFTE, " & _
                "'' as Value, " & _
                "'' as Recurrence " & _
            "from " & _
               dbTables & "_Resources, " & _
               dbTables & "_Project " & _
            "where " & _
                dbTables & "_Resources.Status != 0 and " & _
                dbTables & "_Resources.Month between '" & DateSerial(sDate.Year, sDate.Month, "1") & "' and '" & DateSerial(eDate.Year, eDate.Month + 1, "0") & "' " & _
                where & _
            "group by " & _
                dbTables & "_Resources.Project_ID, " & _
                dbTables & "_Resources.ID, " & _
                dbTables & "_Resources.[Owner], " & _
                dbTables & "_Resources.Entry_Type, " & _
                dbTables & "_Resources.Month) "
        )
        dbTables = "PSS"
        dataTableR2 = SQL.Return_DataTable(
            "(select " & _
                dbTables & "_Resources.Project_ID, " & _
                "(select " & dbTables & "_Project.Project_Name from " & dbTables & "_Project where " & dbTables & "_Project.ID=" & dbTables & "_Resources.Project_ID) as Project_Name, " & _
                dbTables & "_Resources.Month as Month, " & _
                "sum(" & dbTables & "_Resources.Value) as Monthly_FTE_REQ, " & _
                "(select " & dbTables & "_Project.XGBS_PM from " & dbTables & "_Project where " & dbTables & "_Project.ID=" & dbTables & "_Resources.Project_ID) as XGBS_PM, " & _
                dbTables & "_Resources.[Owner], " & _
                "(select top 1 " & dbTables & "_Resources.Owner_Name from " & dbTables & "_Resources where " & dbTables & "_Resources.ID = " & dbTables & "_Resources.ID) as Owner_Name, " & _
                dbTables & "_Resources.ID as Resource_ID, " & _
                "(select top 1 " & dbTables & "_Resources.Comment from " & dbTables & "_Resources where " & dbTables & "_Resources.ID = " & dbTables & "_Resources.ID) as Resource_Description, " & _
                dbTables & "_Resources.Entry_Type, " & _
                "(select Project_Entry_Type.Entry_Type from Project_Entry_Type where Project_Entry_Type.ID=" & dbTables & "_Resources.Entry_Type) as Entry_Type_Name, " & _
                "'' as MonthlyFTE, " & _
                "'' as Value, " & _
                "'' as Recurrence " & _
            "from " & _
               dbTables & "_Resources, " & _
               dbTables & "_Project " & _
            "where " & _
                dbTables & "_Resources.Status != 0 and " & _
                dbTables & "_Resources.Month between '" & DateSerial(sDate.Year, sDate.Month, "1") & "' and '" & DateSerial(eDate.Year, eDate.Month + 1, "0") & "' " & _
                where & _
            "group by " & _
                dbTables & "_Resources.Project_ID, " & _
                dbTables & "_Resources.ID, " & _
                dbTables & "_Resources.[Owner], " & _
                dbTables & "_Resources.Entry_Type, " & _
                dbTables & "_Resources.Month) "
        )
        dbTables = "CI"
        dataTableR3 = SQL.Return_DataTable(
            "select " & _
                "resources.Project_ID, " & _
                "'' as 'Project_Name', " & _
                "'' as 'Month', " & _
                "'' as 'Monthly_FTE_REQ', " & _
                "'' as 'XGBS_PM', " & _
                "resources.Owner, " & _
                "'' as 'Owner_Name', " & _
                "resources.ID as Resource_ID, " & _
                "'' as 'Resource_Description', " & _
                "(select Project_Entry_Type.Entry_Type from Project_Entry_Type where Project_Entry_Type.ID = resources.Entry_Type) as Entry_Type, " & _
                "'' as 'Entry_Name', " & _
                "'0' as MonthlyFTE, " & _
                "resources.Value, " & _
                "resources.Recurrence " & _
            "from " & _
                dbTables & "_Resources as resources " & _
            "where " & _
                "resources.Status != 0 and " & _
                "resources.Start_Date between '" & DateSerial(sDate.Year, sDate.Month, "1") & "' and '" & DateSerial(eDate.Year, eDate.Month + 1, "0") & "' and " & _
                "resources.End_Date between '" & DateSerial(sDate.Year, sDate.Month, "1") & "' and '" & DateSerial(eDate.Year, eDate.Month + 1, "0") & "' " & _
                where & _
            "order by " & _
                "resources.Project_ID asc, " & _
                "resources.ID asc, " & _
                "resources.Entry_Type asc "
        )

        For Each row As DataRow In dataTableR1.Rows
            dataTableR.ImportRow(row)
        Next
        For Each row As DataRow In dataTableR2.Rows
            dataTableR.ImportRow(row)
        Next
        For Each row As DataRow In dataTableR3.Rows
            dataTableR.ImportRow(row)
        Next

        dbTables = "CP"
        dataTableA1 = SQL.Return_DataTable(
            "(select " & _
                "'' as 'Actuals_Project_ID', " & _
                dbTables & "_Actuals.Resource_ID as ResourceID," & _
                "'' as 'Actuals_Entry_Type', " & _
                "'' as 'Actuals_Value', " & _
                "sum(" & dbTables & "_Actuals.Value) as Actual_FTE, " & _
                "CONVERT(DATE, " & dbTables & "_Actuals.Actual_Date) as [Date] " & _
            "from " & _
                dbTables & "_Actuals, " & _
                dbTables & "_Resources " & _
            "where " & _
                dbTables & "_Actuals.Actual_Date between '" & DateSerial(sDate.Year, sDate.Month, sDate.Day) & "' and '" & DateSerial(eDate.Year, eDate.Month, eDate.Day + 1) & "' " & _
                where & _
            "group by " & _
                dbTables & "_Actuals.Project_ID, " & _
                dbTables & "_Actuals.Resource_ID, " & _
                dbTables & "_Actuals.Actual_Date)"
        )
        dbTables = "PSS"
        dataTableA2 = SQL.Return_DataTable(
            "(select " & _
                "'' as 'Actuals_Project_ID', " & _
                dbTables & "_Actuals.Resource_ID as ResourceID," & _
                "'' as 'Actuals_Entry_Type', " & _
                "'' as 'Actuals_Value', " & _
                "sum(" & dbTables & "_Actuals.Value) as Actual_FTE, " & _
                "CONVERT(DATE, " & dbTables & "_Actuals.Actual_Date) as [Date] " & _
            "from " & _
                dbTables & "_Actuals, " & _
                dbTables & "_Resources " & _
            "where " & _
                dbTables & "_Actuals.Actual_Date between '" & DateSerial(sDate.Year, sDate.Month, sDate.Day) & "' and '" & DateSerial(eDate.Year, eDate.Month, eDate.Day + 1) & "' " & _
                where & _
            "group by " & _
                dbTables & "_Actuals.Project_ID, " & _
                dbTables & "_Actuals.Resource_ID, " & _
                dbTables & "_Actuals.Actual_Date)"
        )
        dbTables = "CI"
        dataTableA3 = SQL.Return_DataTable(
            "select " & _
                dbTables & "_Actuals.Project_ID as Actuals_Project_ID, " & _
                dbTables & "_Actuals.Resource_ID, " & _
                "(SELECT Project_Entry_Type.Entry_Type FROM Project_Entry_Type, " & dbTables & "_Resources WHERE Project_Entry_Type.ID = " & dbTables & "_Resources.Entry_Type and " & dbTables & "_Resources.ID = " & dbTables & "_Actuals.Resource_ID) as Actuals_Entry_Type, " & _
                "sum(" & dbTables & "_Actuals.Value) as Actuals_Value, " & _
                "'' as 'Actual_FTE', " & _
                "CONVERT(DATE, " & dbTables & "_Actuals.Actual_Date) as [Date] " & _
            "from " & _
                dbTables & "_Actuals " & _
            "where " & _
                dbTables & "_Actuals.Actual_Date between '" & DateSerial(sDate.Year, sDate.Month, sDate.Day) & "' and '" & DateSerial(eDate.Year, eDate.Month, eDate.Day + 1) & "' " & _
                where & _
            "group by " & _
                dbTables & "_Actuals.Project_ID, " & _
                dbTables & "_Actuals.Resource_ID, " & _
                dbTables & "_Actuals.Actual_Date " & _
            "order by " & _
                "Project_ID asc, " & _
                "Resource_ID asc"
        )

        For Each row As DataRow In dataTableA1.Rows
            dataTableA.ImportRow(row)
        Next
        For Each row As DataRow In dataTableA2.Rows
            dataTableA.ImportRow(row)
        Next
        For Each row As DataRow In dataTableA3.Rows
            dataTableA.ImportRow(row)
        Next

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
                'Add logic
                rowF = rowF + 1
            Next
        Next

        Dim columnUserType As New DataColumn
        columnUserType.ColumnName = "Role"
        dataTableF.Columns.Add(columnUserType)

        'For i As Integer = 0 To (dataTableF.Rows.Count - 1)
        '    If Not DotNet.IsEmpty(dataTableF.Rows(i).Item("ResourceID")) Then
        '        dataTableF.Rows(i).Item("Role") = UsersInfo.GetRole(dataTableF.Rows(i).Item("Owner"), AppName)
        '    End If
        'Next

        For Each column As System.Data.DataColumn In dataTableF.Columns
            dataTableF.Columns(column.ColumnName).ColumnName = Replace(column.ColumnName, "_", " ")
        Next

        BindingSource.DataSource = dataTableF
        DataGridView.DataSource = dataTableF

        'DataGridView.Columns(0).Visible = False
        'DataGridView.Columns(7).Visible = False
        'DataGridView.Columns(9).Visible = False
        'DataGridView.Columns(11).Visible = False

        For cl As Integer = 0 To DataGridView.Columns.Count - 1
            AxSpreadsheet.Worksheets(1).Cells(1, cl + 1) = DataGridView.Columns(cl).HeaderText.ToString
        Next
        For ro As Integer = 1 To DataGridView.Rows.Count - 1
            For cl As Integer = 0 To DataGridView.Columns.Count - 1
                AxSpreadsheet.Worksheets(1).Cells(ro + 1, cl + 1) = DataGridView.Item(cl, ro).Value.ToString
            Next
        Next
    End Sub

    Private Function filters(t As String) As String
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
            where = " and (" & where & ")"
        End If

        Return where
    End Function
End Class