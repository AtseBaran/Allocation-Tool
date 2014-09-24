Module Globales
    Public DotNet As New PSS_Framework.DotNet.Support_Functions
    Public UsersInfo As New PSS_Framework.Users.App_User()
    Public SQL As New PSS_Framework.MS_SQL_Server.SQL_Server(
        "131.190.74.97\SQLExpress",
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
End Module
