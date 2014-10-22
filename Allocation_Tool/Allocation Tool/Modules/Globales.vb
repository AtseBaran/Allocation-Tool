Module Globales
    Public DotNet As New PSS_Framework.DotNet.Support_Functions
    Public UsersInfo As New PSS_Framework.Users.App_User()
    Public SQL As New PSS_Framework.MS_SQL_Server.SQL_Server(
        "131.190.68.219\SQLExpress",
        "developer",
        "hmetal",
        "AllocationTool")

    Public AppName As String = "Allocation"

    Public meses() As String = {
        "January",
        "February",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December"
    }

    Public Function getMonthlyFTE(type As String, value As Double, Optional days As Double = 0)
        Dim total As Decimal
        If type = "Hours" Then
            total = value / (7 * (22 - days))
        ElseIf type = "Materials" Then
            total = (value * 0.033) / (7 * (22 - days))
        End If
        Return Decimal.Round(total, 3)
    End Function

    Public Function sqlString(str As String)
        sqlString = Replace(str, "'", "''")
    End Function

    'Dates

    Function getDates(dateTemp As Date, recipe As String) As Boolean
        Dim words() As String = Split(recipe, ",")

        'Daily
        If words(0) = "DAILY" Then
            If words(2) = "1" Then
                Dim dateStart As Date = words(1)
                While (dateStart <= dateTemp)
                    If dateStart = dateTemp Then
                        Return True
                    End If
                    dateStart = dateStart.AddDays(Integer.Parse(words(3)))
                End While
            ElseIf words(2) = "2" Then
                Dim dateStart As Date = words(1)
                While dateStart <= dateTemp
                    If dateStart = dateTemp Then
                        Return True
                    End If
                    dateStart = dateStart.AddDays(1)
                End While
            End If
        End If

        'Weekly
        If words(0) = "WEEKLY" Then
            Dim dateStart As Date = words(1)
            Dim days() As String
            Dim numEnd As Integer
            If IsDate(words(words.Length - 1)) Then
                numEnd = 2
            Else
                numEnd = 1
            End If
            ReDim days((words.Length - numEnd) - 3)
            For i As Integer = 3 To (words.Length - numEnd)
                days(i - 3) = words(i)
            Next
            Dim week As Integer = 0
            While (dateStart <= dateTemp)
                If InArray(days, dateStart.DayOfWeek.ToString("G")) Then
                    If ((week Mod Integer.Parse(words(2))) = 0) Or (week = 0) Then
                        If dateStart = dateTemp Then
                            Return True
                        End If
                    End If
                End If
                dateStart = dateStart.AddDays(1)
                If dateStart.DayOfWeek = DayOfWeek.Sunday Then
                    week = week + 1
                End If
            End While
        End If

        'Monthly
        If words(0) = "MONTHLY" Then
            If words(2) = "1" Then
                Dim dateStart As Date = words(1)
                Dim day As Integer = Integer.Parse(words(3))
                Dim month As Integer = 0
                While dateStart <= dateTemp
                    If ((month Mod Integer.Parse(words(4))) = 0) Or (month = 0) Then
                        If dateStart.Day = day And dateStart = dateTemp Then
                            Return True
                        End If
                    End If
                    dateStart = dateStart.AddDays(1)
                    If dateStart.Day = 1 Then
                        dateStart.AddMonths(1)
                    End If
                End While
            ElseIf words(2) = "2" Then
                Dim dateStart As Date = words(1)
                Dim order() As String = {"FIRST", "SECOND", "THIRD", "FOURTH"}
                Dim pos As Integer = 0
                While dateStart <= dateTemp
                    If dateStart.DayOfWeek.ToString("G").ToUpper = words(4) Then
                        If order(pos) = words(3) And dateStart = dateTemp Then
                            Return True
                        End If
                        pos = pos + 1
                        If pos > 3 Then
                            Return False
                        End If
                    End If
                    dateStart = dateStart.AddDays(1)
                End While
            End If
        End If

        'Yearly
        If words(0) = "YEARLY" Then
            Dim dateStart As Date = words(1)
            Dim years As Integer = words(2)
            Dim year As Integer = 0
            If words(2) = 1 Then
                While dateStart <= dateTemp
                    If meses(dateStart.Month - 1).ToUpper = words(4) Then
                        If dateStart.Day = words(5) And dateStart = dateTemp Then
                            Return True
                        End If
                    End If
                    dateStart = dateStart.AddDays(1)
                End While
            ElseIf words(2) = 2 Then
                Dim order() As String = {"FIRST", "SECOND", "THIRD", "FOURTH"}
                Dim pos As Integer = 0
                If meses(dateStart.Month - 1).ToUpper = words(6) Then
                    While dateStart <= dateTemp
                        If dateStart.DayOfWeek.ToString("G").ToUpper = words(5) Then
                            If order(pos) = words(4) And dateStart = dateTemp Then
                                Return True
                            End If
                            pos = pos + 1
                            If pos > 3 Then
                                Return False
                            End If
                        End If
                        dateStart = dateStart.AddDays(1)
                    End While
                End If
            End If
        End If

        Return False
    End Function

    Private Function InArray(array() As String, search As String)
        For Each str As String In array
            If search.ToUpper = str Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function translateRecipe(recipe As String)
        Dim words() As String = Split(recipe, ",")
        Dim recipeText As String = ""

        If words(0) = "DAILY" Then
            If words(2) = "1" Then
                recipeText = "Occurs daily, every " & words(3) & " day(s) from " & words(1)
                If IsDate(words(words.Count - 1)) Then
                    recipeText = recipeText & " until " & words(words.Count - 1)
                End If
            ElseIf words(2) = "2" Then
                recipeText = "Occurs daily, every weekday from " & words(1)
                If IsDate(words(words.Count - 1)) Then
                    recipeText = recipeText & " until " & words(words.Count - 1)
                End If
            End If
        ElseIf words(0) = "WEEKLY" Then
            recipeText = "Occurs weekly, every " & words(2) & " week(s) on "
            Dim days As String = ""
            For c As Integer = 3 To (words.Count - 2)
                If days.Length > 0 Then
                    days = days & ", "
                End If
                days = days & words(c).ToLower
            Next
            recipeText = recipeText & " " & days & " from " & words(1)
            If IsDate(words(words.Count - 1)) Then
                recipeText = recipeText & " until " & words(words.Count - 1)
            End If
        ElseIf words(0) = "MONTHLY" Then
            If words(2) = "1" Then
                recipeText = "Occurs monthly, on " & words(3) & " of every " & words(4) & " month(s) from " & words(1)
                If IsDate(words(words.Count - 1)) Then
                    recipeText = recipeText & " until " & words(words.Count - 1)
                End If
            ElseIf words(2) = "2" Then
                recipeText = "Occurs monthly, the " & words(3).ToLower & " " & words(4).ToLower & " of every " & words(5) & " month(s) from " & words(1)
                If IsDate(words(words.Count - 1)) Then
                    recipeText = recipeText & " until " & words(words.Count - 1)
                End If
            End If
        ElseIf words(0) = "YEARLY" Then
            recipeText = "Occurs every " & words(2) & " year(s) "
            If words(2) = "1" Then
                recipeText = recipeText & "on " & words(4).ToLower & " " & words(5) & " from " & words(1)
                If IsDate(words(words.Count - 1)) Then
                    recipeText = recipeText & " until " & words(words.Count - 1)
                End If
            ElseIf words(2) = "2" Then
                recipeText = recipeText & "on the " & words(4).ToLower & " " & words(5).ToLower & " of " & words(6).ToLower & " from " & words(1)
                If IsDate(words(words.Count - 1)) Then
                    recipeText = recipeText & " until " & words(words.Count - 1)
                End If
            End If
        End If
        Return recipeText
    End Function
End Module
