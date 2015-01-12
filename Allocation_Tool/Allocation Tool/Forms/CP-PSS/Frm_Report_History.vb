Imports OfficeOpenXml

Public Class Frm_Report_History
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

    Private Sub ToolStripButtonRefresh_Click(sender As Object, e As EventArgs) Handles ToolStripButtonRefresh.Click
        refreshData()
    End Sub

    Private Sub ToolStripButtonClear_Click(sender As Object, e As EventArgs) Handles ToolStripButtonClear.Click
        clearFilters()
        refreshData()
    End Sub

    Private Sub ButtonProjectName_Click(sender As Object, e As EventArgs) Handles ButtonProjectName.Click
        Frm_Report_Popup.fields = "ID, Project_Name"
        Frm_Report_Popup.order = "order by CAST(Project_Name as varchar(max)) asc"
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
        'Frm_Report_Popup.order = "order by CAST(Service_Line as varchar(max)) asc"
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
        Frm_Report_Popup.order = "order by CAST(Project_Type as varchar(max)) asc"
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
        Frm_Report_Popup.order = "order by CAST(Role as varchar(max)) asc"
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
            Frm_Report_Popup.order = "order by CAST(VS_Chevron as varchar(max)) asc"
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

    Private Sub ButtonPrimaryProcess_Click(sender As Object, e As EventArgs) Handles ButtonPrimaryProcess.Click
        If VSChevron.Length > 0 Then
            Frm_Report_Popup.fields = "ID, Primary_Process"
            Frm_Report_Popup.order = "order by CAST(Primary_Process as varchar(max)) asc"
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

    Private Sub ButtonProjectCategory_Click(sender As Object, e As EventArgs) Handles ButtonProjectCategory.Click
        Frm_Report_Popup.fields = "ID, Category"
        Frm_Report_Popup.order = "order by CAST(Category as varchar(max)) asc"
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

    Private Sub CheckBoxRegionAmerica_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRegionAmerica.CheckedChanged
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
    End Sub

    Private Sub refreshData()
        If DTPStartDate.Value < DTPEndDate.Value Then
            RawData()
        End If
    End Sub

    Private Sub RawData()
        Dim dataTableR As DataTable
        
        Dim sDate As Date = DTPStartDate.Value
        Dim eDate As Date = DTPEndDate.Value

        Dim sqlTemp As String = "" & _
        "SELECT " & _
        "   P.Project_Name " & _
        "   ,RH.[Old_Value] " & _
        "   ,RH.[New_Value] " & _
        "   ,RH.[Date] " & _
        "   ,RH.[Comment] " & _
        "FROM " & _
        "	" & dbTables & "_Project as P, " & _
        "	" & dbTables & "_Resources as R, " & _
        "	" & dbTables & "_Resources_Historical as RH " & _
        "WHERE " & _
        "   (RH.Date between '" & DTPStartDate.Value.ToShortDateString & "' and '" & DTPEndDate.Value.ToShortDateString & "') and " & _
        "	P.ID = R.Project_ID and " & _
        "	R.ID = RH.ID_Resource " & _
            filters("")

        dataTableR = SQL.Return_DataTable(sqlTemp)

        AxSpreadsheet.Worksheets(1).usedrange.clear()

        For cl As Integer = 0 To dataTableR.Columns.Count - 1
            AxSpreadsheet.Worksheets(1).Cells(1, cl + 1) = dataTableR.Columns(cl).ColumnName.ToString
        Next
        For ro As Integer = 1 To dataTableR.Rows.Count - 1
            For cl As Integer = 0 To dataTableR.Columns.Count - 1
                If dataTableR.Rows(ro).Item(cl).ToString = "True" Then
                    AxSpreadsheet.Worksheets(1).Cells(ro + 1, cl + 1) = "Yes"
                ElseIf dataTableR.Rows(ro).Item(cl).ToString = "False" Then
                    AxSpreadsheet.Worksheets(1).Cells(ro + 1, cl + 1) = "No"
                Else
                    AxSpreadsheet.Worksheets(1).Cells(ro + 1, cl + 1) = dataTableR.Rows(ro).Item(cl).ToString
                End If
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

        'Category
        If Category.Length > 0 Then
            temp = Split(Category, ",")
            first = True
            where = where & t & "Category in ( "
            For Each item As String In temp
                If Not first Then
                    where = where & ","
                End If
                where = where & "'" & Mid(item, 3) & "'"
                first = False
            Next
            where = where & ") "
        End If

        'VS_Chevron
        If VSChevron.Length > 0 Then
            temp = Split(VSChevron, ",")
            first = True
            where = where & t & "VS_Chevron in ( "
            For Each item As String In temp
                If Not first Then
                    where = where & ","
                End If
                where = where & "'" & Mid(item, 3) & "'"
                first = False
            Next
            where = where & ") "
        End If

        'Primary_Process
        If Category.Length > 0 Then
            temp = Split(PrimaryProcess, ",")
            first = True
            where = where & t & "Primary_Process in ( "
            For Each item As String In temp
                If Not first Then
                    where = where & ","
                End If
                where = where & "'" & Mid(item, 3) & "'"
                first = False
            Next
            where = where & ") "
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
                If where.Length > 0 Then
                    where = where & " and "
                End If
                where = where & " Owner in ("
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

    Private Sub Frm_Report_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DTPStartDate_ValueChanged(sender As Object, e As EventArgs) Handles DTPStartDate.ValueChanged
        If DTPEndDate.Value < DTPStartDate.Value Then
            'MessageBox.Show("The date range is not correct, please verify.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            'drawGraph()
        End If
    End Sub

    Private Sub DTPEndDate_ValueChanged(sender As Object, e As EventArgs) Handles DTPEndDate.ValueChanged
        If DTPEndDate.Value < DTPStartDate.Value Then
            'MessageBox.Show("The date range is not correct, please verify.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            'drawGraph()
        End If
    End Sub
End Class