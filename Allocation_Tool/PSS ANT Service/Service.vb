Imports System.Runtime.InteropServices

Public Class Service
    Public Enum ServiceState
        SERVICE_STOPPED = 1
        SERVICE_START_PENDING = 2
        SERVICE_STOP_PENDING = 3
        SERVICE_RUNNING = 4
        SERVICE_CONTINUE_PENDING = 5
        SERVICE_PAUSE_PENDING = 6
        SERVICE_PAUSED = 7
    End Enum

    <StructLayout(LayoutKind.Sequential)>
    Public Structure ServiceStatus
        Public dwServiceType As Long
        Public dwCurrentState As ServiceState
        Public dwControlsAccepted As Long
        Public dwWin32ExitCode As Long
        Public dwServiceSpecificExitCode As Long
        Public dwCheckPoint As Long
        Public dwWaitHint As Long
    End Structure

    Dim timer As New System.Timers.Timer
    Dim eventID As Integer
    Dim serviceStatusReporter As ServiceStatus = New ServiceStatus()

    Declare Auto Function SetServiceStatus Lib "advapi32.dll" (ByVal handle As IntPtr, ByRef serviceStatus As ServiceStatus) As Boolean

    Public Sub New()
        MyBase.New()

        serviceStatusReporter.dwCurrentState = ServiceState.SERVICE_START_PENDING
        serviceStatusReporter.dwWaitHint = 100000
        SetServiceStatus(Me.ServiceHandle, serviceStatusReporter)

        InitializeComponent()
        Me.EventLog = New System.Diagnostics.EventLog
        If Not System.Diagnostics.EventLog.SourceExists("PSS ANT Service") Then
            System.Diagnostics.EventLog.CreateEventSource("PSS ANT Service", "Log")
        End If
        EventLog.Source = "PSS ANT Service"
        EventLog.Log = "Log"

        serviceStatusReporter.dwCurrentState = ServiceState.SERVICE_RUNNING
        SetServiceStatus(Me.ServiceHandle, serviceStatusReporter)
    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)
        timer.Interval = 60000
        AddHandler timer.Elapsed, AddressOf Me.OnTimer
        timer.Start()
        EventLog.WriteEntry("Service Start", EventLogEntryType.Information, eventID)
    End Sub

    Private Sub OnTimer(sender As Object, e As Timers.ElapsedEventArgs)
        EventLog.WriteEntry("Service verification...", EventLogEntryType.Information, eventID)
        eventID = eventID + 1
    End Sub

    Protected Overrides Sub OnStop()
        serviceStatusReporter.dwCurrentState = ServiceState.SERVICE_STOP_PENDING
        serviceStatusReporter.dwWaitHint = 100000
        SetServiceStatus(Me.ServiceHandle, serviceStatusReporter)

        timer.Stop()
        EventLog.WriteEntry("Service Stop", EventLogEntryType.Information, eventID)

        serviceStatusReporter.dwCurrentState = ServiceState.SERVICE_STOPPED
        SetServiceStatus(Me.ServiceHandle, serviceStatusReporter)
    End Sub

End Class
