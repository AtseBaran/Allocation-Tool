Imports System.Net.Mail
Imports System.Text.RegularExpressions

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

    Public Function Validate_Email_List(ByVal sMail As String) As Boolean
        Dim emailExpression As New Regex("\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*")
        Return emailExpression.IsMatch(sMail)
    End Function

    Public Function GetHTMLcode(ByVal path As String) As String
        Dim HTMLcode As String = ""
        If System.IO.File.Exists(path) = True Then
            Dim objReader As New System.IO.StreamReader(path)
            HTMLcode = objReader.ReadToEnd
            objReader.Close()
        Else
            MsgBox("File: " & path & " Does Not Exist")
        End If
        Return HTMLcode
    End Function

    Public Function Send_eMail(
                                  ByVal Recipient As String,
                                  ByVal Subject As String,
                                  ByVal Body As String,
                                  Optional CopyTo As String = "",
                                  Optional Attachments() As String = Nothing,
                                  Optional OnBehalfOf As String = "",
                                  Optional Draft As Boolean = False
                            ) As Boolean
        Dim MyolApp
        Dim myNameSpace
        Dim objMail
        Dim A As String
        Try
            MyolApp = CreateObject("Outlook.Application")
            myNameSpace = MyolApp.GetNamespace("MAPI")
            objMail = MyolApp.CreateItem(0)

            With objMail
                MyolApp = .GetInspector()
                .Subject = Subject
                .HTMLBody = Body & .HTMLBody
                .To = Recipient
                .CC = CopyTo
                .SentOnBehalfOfName = OnBehalfOf

                If Not Attachments Is Nothing Then
                    For Each A In Attachments
                        If A <> "" Then
                            .Attachments.Add(CStr(A))
                        End If
                    Next
                End If
            End With

            If Not Draft Then
                objMail.Send()
            Else
                objMail.Save()
            End If

            Send_eMail = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Outlook Error")
            Send_eMail = False
        End Try
    End Function
End Module
