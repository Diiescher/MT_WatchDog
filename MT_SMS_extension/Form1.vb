﻿Option Explicit On
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop.Outlook
Imports Outlook = Microsoft.Office.Interop.Outlook


Imports System.Text.RegularExpressions



Public Class Form1
    Delegate Sub SetTextCallback([text] As String)

    Public WithEvents olApp As Outlook.Application = CreateObject("Outlook.Application")
    Private WithEvents olInspectors As Outlook.Inspectors = olApp.Inspectors
    Private WithEvents olExplorer As Outlook.Explorer = olApp.ActiveExplorer
    Private WithEvents myItem As Outlook.MailItem
    Private WithEvents oMaintFolder As Outlook.Folder
    Private WithEvents objNewMailItemsWatch As Outlook.Items

    Dim MA As New clsBerMA
    Dim WithEvents timer1 As New Timer
    Dim bHbSent As Boolean
    Dim failCount As Integer = 0
    Dim maxCountMsgGiven As Boolean = False

    Dim maxFailCount As Integer = 10
    Const HBinterval As Integer = 15
    Const HBTick As String = "PureHB"
    Const HBStop As String = "PureHB stop"
    Dim strLogText As String
    Dim strPort As String = "COM"

    Dim modem As clsSmsModem
    Dim dbData As clsWdDatabase = New clsWdDatabase

    'Dim strCopyFolder = "PureCopy"
    Dim strMailBox As String = "" 'MB.Maintenance_Networking@computacenter.com\Inbox"

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'objNewMailItemsWatch = getMailbox(strMailBox)
        'lblMailBox.Text = objNewMailItemsWatch.Parent.folderpath


        cbbOMailBox.Items.Add("MB.Maintenance_Networking")
        cbbOMailBox.Items.Add("MB.DE_Mainserv_PureStorage_AP")
        cbbOMailBox.SelectedIndex = 1

        cbbCopyMailsTo.Items.Add("Oliver.Schreckenbach@computacenter.com")
        cbbCopyMailsTo.Items.Add("Florian.Graefen@computacenter.com")
        cbbCopyMailsTo.SelectedIndex = 0

        tbMobNr.Text = "+491728303626"

        'If cbCopyTo.Checked Then MA.email = String.Format("{0}\{1}", {cbbCopyMailsTo.Text, strCopyFolder})
        timer1.Interval = 1000
        timer1.Start()
        'cbbOMailBox.Text = strMailBox

        AddLogText("Started")
        setlabels()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        timer1.Start()
    End Sub

    Private Sub objNewMailItemsWatch_ItemAdd(Item As Object) Handles objNewMailItemsWatch.ItemAdd
        'triggers on new Mail event
        Dim mail As Outlook.MailItem
        Dim out As String = ""
        Dim i As Integer

        'Debug.Print("neue Mail eingetroffen")
        If TypeOf Item Is Outlook.MailItem Then
            mail = Item 'for intellisense
            AddLogText("new Mail (Topic)" & vbCrLf & vbTab & Strings.Left(mail.ConversationTopic, 30))

            'normaleweise liegt das erste vorkommen von "Displatch" bei ca. 200 Zeichen (ohne fwd head)
            i = InStr(UCase(mail.Body), UCase("Dispatch Requirements"))
            If i > 0 AndAlso i < 600 Then
                out = "PureAlarm: triggered" '& Strings.Mid(mail.Body, i, 110)
            Else
                out = "PureAlarm: no trigger " '& Strings.Left(mail.ConversationTopic, 50)
            End If
            Dim rgx = New Regex("\[|\]|\(|\)|\|")
            out = rgx.Replace(out, ".")
            If Not watchdogOnDuty() Then
                AddLogText("...but ignored. Dog is sleeping")
                Exit Sub
            End If
            'send the actual SMS
            If cbSendMailSMS.Checked Then
                If modem.SendSMS(MA.number, out) Then
                    AddLogText(String.Format("OK: notfication SMS to {0}", {MA.number}))
                Else
                    AddLogText(String.Format("FAIL: notfication SMS to {0}", {MA.number}))
                End If
            Else
                AddLogText("Newmail detected but SMS disabled")
            End If
            If cbCopyTo.Checked Then
                sendMailCopy(mail)

            Else
                AddLogText("Mail not forwarded")
            End If

        End If
    End Sub
    Private Sub sendMailCopy(mail As Outlook.MailItem)
        Dim newmail As Outlook.MailItem
        newmail = mail.Forward
        newmail.Body = "Watchdog AutoForward" & vbCrLf & vbCrLf & newmail.Body
        'delete all receipients
        While newmail.Recipients.Count > 0
            newmail.Recipients.Remove(1)
        End While
        '  add receipient
        newmail.Recipients.Add(MA.email)
        'newmail.Display()
        newmail.Send()
        AddLogText(String.Format("Mailcopy sent"))
    End Sub
    Public Sub AddLogText(ByVal [text] As String, Optional i As Integer = 0)
        Dim tStamp As Date = Date.Now
        strLogText = String.Format("{0}{1:t}: {2}{3}", {strLogText, tStamp, [text], vbCrLf})
        UpdLog(strLogText)
    End Sub

    Private Sub UpdLog(ByVal [text] As String, Optional i As Integer = 0)
        Dim tStamp As DateTime = TimeOfDay

        ' needed to update textbox from listener

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true
        If Me.rtbOutput.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf UpdLog)
            Me.Invoke(d, New Object() {[text]})
        Else
            rtbOutput.Text = [text]
        End If
    End Sub


    Private Sub btSend_Click(sender As Object, e As EventArgs) Handles btSend.Click
        AddLogText(String.Format("Test-SMS an {0}{2}Text:{1}", {MA.number, rtbSmsText.Text, vbCrLf}))
        If modem.SendSMS(MA.number, rtbSmsText.Text) Then
            AddLogText("SMS Test OK")
        Else
            AddLogText("SMS Test Fail")
        End If

    End Sub

    Private Sub btChngNr_Click(sender As Object, e As EventArgs) Handles btChngNr.Click
        strMailBox = cbbOMailBox.Text

        MA = New clsBerMA
        MA.email = cbbCopyMailsTo.Text
        MA.number = tbMobNr.Text

        'mailBox Extenders
        If cbAtCC.Checked Then strMailBox &= "@Computacenter.com"
        If cbSlashInbox.Checked Then strMailBox &= "\Inbox"

        'get Mailbox to watch
        objNewMailItemsWatch = getMailbox(strMailBox)

        ' Comport
        If tbComPortNr.Text <> "" Then
            strPort = "COM" & tbComPortNr.Text
            lblComPortNr.ForeColor = Color.Black
            modem = New clsSmsModem(strPort)
            If modem.enabled Then
                lblComPortNr.ForeColor = Color.Black
            Else
                strPort &= " n/a !!"
                lblComPortNr.ForeColor = Color.Red
            End If
        End If
        setlabels()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer1.Tick
        ' Clock-Timer ticked

        Dim [min] As Integer

        'clock
        Dim tStamp As DateTime = TimeOfDay
        Dim dStamp As DateTime = Date.Now

        'zum testen :)
        'dstamp = Date.Parse("2.7.2018")

        'Uhr
        lblCurTime.Text = tStamp  '.ToString("HH:mm:ss tt")
        lblDateInfo.Text = String.Format("{0:D} {1}", {dStamp, IstFeiertag(dStamp)})

        If MA.number = "" Then Exit Sub
        If (tStamp.Second Mod 15) = 0 And dbData.KillTheDog Then End

        'Heartbeat every xx Minutes
        [min] = CType(tStamp.Minute, Integer) '0-59
        If [min] Mod HBinterval <> 0 Then bHbSent = False 'reset HB-sent-flag after time-window, so new HB can occur
        If watchdogOnDuty() Then
            If [min] Mod HBinterval = 0 And Not bHbSent And failCount < maxFailCount Then
                If cbSendHbSMS.Checked Then
                    Dim HbText As String = HBTick
                    'last message?
                    If Not watchdogOnDuty(Date.Now.AddMinutes(HBinterval)) Then HbText = HBStop
                    'actual Haertbeat-SMS
                    bHbSent = modem.SendSMS(MA.number, String.Format("{0} {1:t}", {HbText, tStamp})) ' " & tStamp.ToString("HH:mm:ss"))
                    If Not bHbSent Then
                        failCount += 1
                        AddLogText("HB-SMS failed " & failCount & " of " & maxFailCount & " times")
                    Else
                        'update lastHB-Label
                        lblLastHb.Text = tStamp.ToString("HH:mm:ss tt")
                        AddLogText("HB-SMS sent (" & failCount + 1 & ". try)")
                        failCount = 0
                        maxCountMsgGiven = False
                    End If
                    If failCount > maxFailCount - 1 And Not maxCountMsgGiven Then
                        maxCountMsgGiven = True
                        AddLogText(maxFailCount & " SMS-tries failed. Not trying again!!")
                    End If
                Else
                    AddLogText("HB-Interval reached but HB-SMS disabled!")
                    bHbSent = True
                End If
            End If
        End If
        setlabels()
    End Sub
    Public Overloads Function watchdogOnDuty() As Boolean
        Return watchdogOnDuty(Date.Now, cbOnlyOOH.Checked)
    End Function
    Public Overloads Function watchdogOnDuty(tstamp As DateTime) As Boolean
        Return watchdogOnDuty(tstamp, cbOnlyOOH.Checked)
    End Function
    Public Overloads Function watchdogOnDuty(tStamp As Date, onlyDuringOOH As Boolean) As Boolean
        ' true, wenn watchdog rund um die Uhr oder innerhalb der Office-Hours.
        ' OH: Mo-Fr, 6-24 Uhr, kein Feiertag
        Dim res As Boolean
        Dim weekend As Boolean

        With tStamp
            weekend = (.DayOfWeek = 6) Or (.DayOfWeek = 0) Or IstFeiertag(.Date) <> ""
            '       immer = ja                   nicht immer, aber zwischen 0 und 6 =  ja
            res = Not onlyDuringOOH OrElse (onlyDuringOOH And .Hour < 6)
            '         oder wochenende
            res = res Or weekend
            '         und eine Nummer muss bekannt sein
            res = res And MA.number <> ""
        End With
        Return res
    End Function


    Private Function getMailbox(str As String) As Outlook.Items
        Dim result As Outlook.Items = Nothing
        Try
            result = GetFolderPath(str).Items
        Catch ex As SystemException
            Debug.Print("not found: " & str)
            MsgBox("No Mailbox found!" & vbCrLf & "Tool not working!")
            MA.number = ""
            strMailBox = "not found!"
        End Try
        Return result
    End Function
    Private Sub setlabels()
        Dim active As String = ""
        lblMailBox.Text = strMailBox
        lblInterval.Text = HBinterval
        lblComPortNr.Text = strPort
        lblCurNr.Text = MA.number
        lblForward.Text = MA.email
        If Not watchdogOnDuty(Date.Now) Then
            active = "in"
        End If
        active &= "active"
        lblWDisactive.Text = String.Format("Watchdog is {0}", active)
    End Sub



    Private Sub btClearLog_Click(sender As Object, e As EventArgs) Handles btClearLog.Click
        strLogText = ""
        rtbOutput.Text = ""
    End Sub

    Private Sub cbCopyTo_CheckedChanged(sender As Object, e As EventArgs) Handles cbCopyTo.CheckedChanged
        cbbCopyMailsTo.Enabled = cbCopyTo.Checked
        lblForward.Enabled = cbCopyTo.Checked
        If cbCopyTo.Checked Then
            MA.email = cbbCopyMailsTo.Text
        Else
            MA.email = ""
        End If
        setlabels()
    End Sub

    Private Sub cbOnlyOOH_CheckedChanged(sender As Object, e As EventArgs) Handles cbOnlyOOH.CheckedChanged
        Dim vorheran As Boolean
        Dim jetztan As Boolean
        Dim tStamp As DateTime = Date.Now
        If cbOnlyOOH.Checked Then
            vorheran = watchdogOnDuty(tStamp, False)
            'wiederherstellen
            jetztan = watchdogOnDuty(tStamp, True)
            If vorheran And Not jetztan Then
                'MsgBox("STOP-SMS müsste gesendet werden")
                If modem.SendSMS(MA.number, String.Format("{0} {1:t}", {HBStop, tStamp})) Then
                    AddLogText("Stop-SMS sent")
                Else
                    AddLogText("! FAIL ! Stop-SMS should be sent but failed")
                End If

            End If

        End If
    End Sub
End Class