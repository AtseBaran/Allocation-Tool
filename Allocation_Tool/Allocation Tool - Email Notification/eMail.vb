Imports Outlook = Microsoft.Office.Interop.Outlook

Public Class eMail

    Private Mail As Outlook.MailItem = Nothing
    Private MSubject As String = ""
    Private MBody As String = ""
    Private MRecipients As String = ""
    Private MCopyTo As String = ""
    Private MAttach() As String

    Sub New()

        InitMail()

    End Sub

    Sub New(ByVal Subject As Object, ByVal Body As Object, ByVal Recipients As Object, Optional ByVal CopyTo As Object = Nothing, Optional ByVal Attachments() As String = Nothing)

        InitMail()
        If Not DBNull.Value.Equals(Subject) Then MSubject = Subject
        If Not DBNull.Value.Equals(Body) Then MBody = Body
        If Not DBNull.Value.Equals(Recipients) Then MRecipients = Recipients
        If Not CopyTo Is Nothing AndAlso Not DBNull.Value.Equals(CopyTo) Then MCopyTo = CopyTo
        If Not Attachments Is Nothing Then
            For Each Attachment As String In Attachments
                Attach(Attachment)
            Next
        End If

    End Sub

    Public Property Subject() As String

        Get
            Subject = MSubject
        End Get
        Set(ByVal value As String)
            MSubject = value
        End Set

    End Property

    Public Property Body()

        Get
            Body = MBody
        End Get
        Set(ByVal value)
            MBody = value
        End Set

    End Property

    Public Property Recipients() As String

        Get
            Recipients = MRecipients
        End Get
        Set(ByVal value As String)
            MRecipients = value
        End Set

    End Property

    Public Property CopyTo() As String

        Get
            CopyTo = MCopyTo
        End Get
        Set(ByVal value As String)
            MCopyTo = value
        End Set

    End Property

    Public Sub Attach(ByVal Path As String)

        If Not My.Computer.FileSystem.FileExists(Path) Then
            MsgBox("Can Not Find File: " & Path, MsgBoxStyle.Critical, "Outlook: Invalid Attachment")
            Exit Sub
        End If

        If MAttach Is Nothing Then
            ReDim MAttach(0)
        Else
            ReDim Preserve MAttach(MAttach.Count)
        End If
        MAttach(MAttach.GetUpperBound(0)) = Path

    End Sub

    Public Function Send(Optional ByVal NotifyUnresolved As Boolean = True) As Boolean

        Send = False
        Dim U As String = Nothing
        If Not SetupMail(U) Then Exit Function
        Try
            If Not U Is Nothing Then
                If NotifyUnresolved Then MsgBox("There are some unresolved recipients: " & vbCr & vbCr & "Subject: " & MSubject & vbCr & vbCr & "Recipient(s): " & U & vbCr & vbCr & "This message will not be sent, it will be stored in the drafts folder instead.", MsgBoxStyle.Exclamation, "Outlook: Unresolved Recipients")
                Mail.Save()
            Else
                Mail.Send()
            End If
            Send = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Outlook Error")
        End Try

    End Function

    Public Function Save() As Boolean

        Save = False
        Dim U As String = Nothing
        If Not SetupMail(U) Then Exit Function
        Try
            If Not U Is Nothing Then
                MsgBox("There are some unresolved recipients: " & vbCr & vbCr & "Subject: " & MSubject & vbCr & vbCr & "Recipient(s): " & U, MsgBoxStyle.Exclamation, "Outlook: Unresolved Recipients")
            End If
            Mail.Save()
            Save = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Outlook Error")
        End Try

    End Function

    Private Sub InitMail()

        Try
            Dim Application = New Outlook.Application
            Dim NS As Outlook.NameSpace = Application.GetNamespace("MAPI")
            NS.Logon()
            Mail = Application.CreateItem(Outlook.OlItemType.olMailItem)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Outlook Error")
            Mail = Nothing
        End Try

    End Sub

    Private Function SetupMail(ByRef Unresolved As String) As Boolean

        SetupMail = False
        Try
            Dim I = Mail.GetInspector
            Mail.Subject = MSubject
            Mail.HTMLBody = MBody & Mail.HTMLBody
            Mail.CC = MCopyTo
            Mail.Recipients.Add(MRecipients)
            If Not Mail.Recipients.ResolveAll() Then
                For Each R As Outlook.Recipient In Mail.Recipients
                    If Not R.Resolved Then
                        Unresolved = Unresolved & R.Name & "; "
                    End If
                Next
            End If
            If Not MAttach Is Nothing Then
                For Each Atachment As String In MAttach
                    Mail.Attachments.Add(Atachment)
                Next
            End If
            SetupMail = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Outlook Error")
        End Try

    End Function

End Class

Public Class eMail_Services

    Private Application As Outlook.Application = Nothing
    Private MAPI As Outlook.NameSpace
    Private Unresolved As String = Nothing

    Public ReadOnly Property OnLine() As Boolean

        Get
            OnLine = Not Application Is Nothing
        End Get

    End Property

    Public ReadOnly Property Unresolved_Recipients() As String

        Get
            Unresolved_Recipients = Unresolved
        End Get

    End Property

    Public Sub New()

        Try
            Application = New Outlook.Application
            MAPI = Application.GetNamespace("MAPI")
            MAPI.Logon()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Outlook Error")
            Application = Nothing
        End Try

    End Sub

    Public Function Send_Mail(ByVal Subject As Object, ByVal Body As Object, ByVal Recipients As Object, Optional ByVal CopyTo As Object = Nothing, Optional ByVal Attachments() As String = Nothing, Optional ByVal CreateOnly As Boolean = False) As Boolean

        Send_Mail = False

        If Application Is Nothing Then Exit Function

        Try
            Dim Mail As Outlook.MailItem = Application.CreateItem(Outlook.OlItemType.olMailItem)
            Dim I = Mail.GetInspector
            Mail.Subject = Subject
            Mail.HTMLBody = Body & Mail.HTMLBody
            Mail.CC = CopyTo
            Mail.Recipients.Add(Recipients)
            If Not Mail.Recipients.ResolveAll() Then
                For Each R As Outlook.Recipient In Mail.Recipients
                    If Not R.Resolved Then
                        Unresolved = Unresolved & R.Name & "; "
                    End If
                Next
            End If
            If Not Attachments Is Nothing Then
                For Each Atachment As String In Attachments
                    Mail.Attachments.Add(Atachment)
                Next
            End If
            I.Display()
            If Not Unresolved Is Nothing Then
                'MsgBox("There are some unresolved recipients: " & vbCr & vbCr & "Subject: " & Subject & vbCr & vbCr & "Recipient(s): " & Unresolved & vbCr & vbCr & _
                '"This message will not be sent, it will be stored in the drafts folder instead.", MsgBoxStyle.Exclamation, "Outlook: Unresolved Recipients")
                Mail.Save()
            Else
                If Not CreateOnly Then
                    Mail.Send()
                Else
                    Mail.Save()
                End If
            End If
            Send_Mail = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Outlook Error")
        End Try

    End Function

    Public Sub SendDrafts()

        Dim drafts As Outlook.MAPIFolder
        Dim Item As Outlook.MailItem

        drafts = MAPI.GetDefaultFolder(16)
        For Each Item In drafts.Items
            Try
                Item.Send()
            Catch ex As Exception

            End Try
        Next

    End Sub

    Public Sub Replicate(Optional ByVal WaitToFinish As Boolean = False)

        MAPI.SendAndReceive(False)
        If WaitToFinish Then
            Do While MAPI.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderOutbox).Items.Count <> 0
            Loop
        End If

    End Sub

End Class