﻿Option Explicit On
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop.Outlook
Imports Outlook = Microsoft.Office.Interop.Outlook


Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.Logging


Public Class MT_Watchdog
    Delegate Sub SetTextCallback([text] As String)

    Const WDVersion As String = "V0.2a Alpha"

    Const LLNewMailFound As Integer = 1
    Const LLTestSMS As Integer = 2
    Const LLGenHB As Integer = 3
    Const LLCheckDB As Integer = 4
    Const LLSettings As Integer = 5

    Dim strPort As String = "COM"
    Dim MA As New clsBerMA 'contains SMS-number and email
    Private WithEvents objNewItemsWatch As Outlook.Items

    Dim MaList As New Collection 'of MA :)
    Dim WithEvents timer1 As New Timer
    Dim bHbSent As Boolean
    Dim failCount As Integer = 0
    Dim maxCountMsgGiven As Boolean = False

    Dim maxFailCount As Integer = 10
    Const HBinterval As Integer = 15
    Const dbPull As Integer = 20
    Const HBTick As String = "PureHB"
    Const HBStop As String = "PureHB stop"
    Dim strLogText As String
    Public ReadOnly Property DefaultFileLogWriter As New FileLogTraceListener

    Dim modem As clsSmsModem
    Dim dbData As clsWdDatabase = New clsWdDatabase



    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        cbbOMailBox.Items.Add("MB.Maintenance_Networking")
        cbbOMailBox.Items.Add("MB.DE_Mainserv_PureStorage_AP")

        cbbCopyMailsTo.Items.Add("Oliver.Schreckenbach@computacenter.com")
        cbbCopyMailsTo.Items.Add("Florian.Graefen@computacenter.com")

        tbMobNr.Text = ""
        modem = New clsSmsModem()

        MaList = CollectUsers() 'for later use

        timer1.Interval = 1000
        timer1.Start()

        Me.Text = String.Format("MT Watchdog {0} running on account {1}", WDVersion, Environment.UserName)
        rbUseDB.Text = String.Format("Use Database Setting | Pulled every {0} seconds", dbPull)

        AddLogText("Started")
        'DefaultFileLogWriter.Append = True
        'DefaultFileLogWriter.BaseFileName
        'Debug.Print(DefaultFileLogWriter.FullLogFileName)

        My.Application.Log.DefaultFileLogWriter.AutoFlush = True
        AddFileLog("App Started ", 8, 1)

        Setlabels()
    End Sub
    Private Function CollectUsers() As Collection
        Dim M As New clsBerMA
        M.name = ""
        M.number = ""
        M.email = ""
    End Function

    Private Sub objNewMailItemsWatch_ItemAdd(Item As Object) Handles objNewItemsWatch.ItemAdd
        'triggers on new item event
        Dim mail As Outlook.MailItem
        Dim out As String = ""
        Dim i As Integer

        'Debug.Print("neue Mail eingetroffen")
        If TypeOf Item Is Outlook.MailItem Then
            mail = Item 'for intellisense
            AddLogText("New Mail detected")
            AddFileLog("New Mail detected | " & Strings.Left(mail.ConversationTopic, 30), 8, LLNewMailFound)

            'normaleweise liegt das erste vorkommen von "Displatch" bei ca. 200 Zeichen (ohne fwd head)
            i = InStr(UCase(mail.Body), UCase("Dispatch Requirements"))
            If i > 0 AndAlso i < 600 Then
                out = "PureAlarm: trigger found" '& Strings.Mid(mail.Body, i, 110)
            Else
                out = "PureAlarm: no trigger found" '& Strings.Left(mail.ConversationTopic, 50)
            End If
            Dim rgx = New Regex("\[|\]|\(|\)|\|")
            out = rgx.Replace(out, ".")

            If Not WatchdogOnDuty() Then
                AddLogText("...but ignored. Dog is sleeping")
                AddFileLog("... but ignored. Dog is sleeping!", 8, LLNewMailFound)
                Exit Sub
            End If

            If cbSendMailSMS.Checked Then
                'send the actual SMS
                If modem.SendSMS(MA.number, out) Then
                    AddLogText(String.Format("OK: notfication SMS to {0}", MA.number))
                    AddFileLog(String.Format("OK: notfication SMS to {0}", MA.number), 8, LLNewMailFound)
                Else
                    AddLogText(String.Format("FAILED: notfication SMS to {0}", MA.number))
                    AddFileLog(String.Format("Failed: notfication SMS to {0}", MA.number), 2, LLNewMailFound)
                End If
            Else
                AddLogText("Newmail detected but SMS disabled")
                AddFileLog("Newmail detected but SMS disabled", 4, LLNewMailFound)
            End If
            If cbCopyTo.Checked Then
                SendMailCopy(mail)
            Else
                AddLogText("Mail not forwarded")
                AddFileLog("Mail not forwarded", 4, LLNewMailFound)
            End If

        End If
    End Sub

    Private Sub SendMailCopy(mail As Outlook.MailItem)
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
        AddFileLog("Mailcopy sent to " & MA.email, 8, 1)
    End Sub

    Public Sub AddFileLog(str As String, sev As Integer, id As Integer)
        Dim mes As String
        mes = String.Format("{0} > {1}", Date.Now, str)
        My.Application.Log.WriteEntry(mes, sev, id)
        'My.Application.Log.
    End Sub

    Public Sub AddLogText(ByVal [text] As String, Optional i As Integer = 0)
        Dim maxLogLength As Integer = 50000
        Dim tStamp As Date = Date.Now
        strLogText = String.Format("{0}{1:dd}.{1:MM}.{1:yy} / {1:T} -- {2}{3}", strLogText, tStamp, [text], vbCrLf)
        If strLogText.Length > maxLogLength Then
            'truncate logtxt line by line (search for 2nd vbcrlf and omit all lines before)
            strLogText = String.Format("[...]{0}{1}", vbCrLf, Strings.Right(strLogText, maxLogLength))
            lblLog.Text = "LOG ... truncated"
        End If
        UpdLog(strLogText)
    End Sub

    Private Sub UpdLog(ByVal [text] As String)
        ' needed to update textbox from listener-thread

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true
        If Me.rtbOutput.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf UpdLog)
            Me.Invoke(d, New Object() {[text]})
        Else
            With rtbOutput
                .Text = [text]
                .SelectionStart = .Text.Length
                .ScrollToCaret()
            End With
        End If
    End Sub

    Private Sub btSend_Click(sender As Object, e As EventArgs) Handles btSend.Click
        AddLogText(String.Format("Trying Test-SMS an {0}{2}{3}Text:{1}", MA.number, rtbSmsText.Text, vbCrLf, vbTab))
        If modem.SendSMS(MA.number, rtbSmsText.Text) Then
            AddLogText("SMS Test OK")
            AddFileLog(String.Format("SMS Test OK|{0}|{1}", MA.number, rtbSmsText), 8, LLTestSMS)
        Else
            AddLogText(String.Format("SMS Test Fail:{0}", modem.Message))
            AddFileLog(String.Format("SMS Test Failed!|{0}|{1}|{2}", MA.number, rtbSmsText, modem.Message), 2, LLTestSMS)
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer1.Tick
        ' Clock-Timer ticked every second
        Dim [min] As Integer
        Dim dStamp As DateTime = Date.Now  'e.g. 27.08.2018 23:43:23
        'Dim tStamp As DateTime = TimeOfDay 'e.g. 23:43:2

        'zum testen :)
        ' dStamp = Date.Parse("25.12.2018")

        'Uhr
        lblCurTime.Text = String.Format("{0:T}", dStamp) 'tStamp  '.ToString("HH:mm:ss tt")
        lblDateInfo.Text = String.Format("{0:D} {1}", dStamp, IstFeiertag(dStamp))
        ' datenbank
        If rbUseDB.Checked AndAlso (dStamp.Second Mod dbPull) = 0 Then CheckDBSettings()

        'If MA.number = "" Then
        '    GroupBox1.Text = "no telephone data, no DOG at all"
        '    Exit Sub
        'End If

        'Heartbeat every "HBinterval" Minutes
        [min] = CType(dStamp.Minute, Integer) '0-59
        If ([min] Mod HBinterval) <> 0 Then bHbSent = False 'reset HB-sent-flag after time-window, so new HB can occur
        If WatchdogOnDuty() Then
            If [min] Mod HBinterval = 0 And Not bHbSent And failCount < maxFailCount Then
                If cbSendHbSMS.Checked Then
                    GenerateHB(dStamp)
                Else
                    AddLogText("HB-Interval reached but HB-SMS disabled!")
                    AddFileLog("HB-Interval reached but HB-SMS disabled by Checkbox!", 4, 1)
                    bHbSent = True
                End If
            End If
        End If
        Setlabels()
    End Sub

    Private Sub GenerateHB(dStamp As DateTime)
        'setting up HBText :
        'normal-Tick to reset the alarm timer
        Dim HbText As String = HBTick
        If Not WatchdogOnDuty(Date.Now.AddMinutes(HBinterval)) Then
            'if last message then notify mobile to stop the alarm-timer
            HbText = HBStop
        End If
        If Not TestMailBox() Then
            ' mailbox not reachable -> timer on mobile will NOT reset and alarm will go off
            ' (or start if this is the first SMS)
            HbText = "Fail Alert: Dog lost trail of Mailbox!"
        End If
        ' adding date info
        HbText = String.Format("{0} {1:dd}.{1:MM}. {1:T}", HbText, dStamp)

        'finally sending Heartbeat-SMS
        'AddLogText(String.Format("Trying SMS to {0}{2}{3}Text:<<{1}>>", MA.number, HbText, vbCrLf, vbTab))
        AddFileLog(String.Format("Trying HB-SMS|{0}|{1}", MA.number, HbText), 8, LLGenHB)
        bHbSent = modem.SendSMS(MA.number, HbText) ' " & tStamp.ToString("HH:mm:ss"))

        If Not bHbSent Then
            failCount += 1
            AddLogText(String.Format("HB-SMS failed {0} of {1} times", failCount, maxFailCount))
            AddFileLog(String.Format("HB-SMS failed {0} of {1} times| Modem:{2}", failCount, maxFailCount, modem.Message), 2, LLGenHB)
        Else
            'update lastHB-Label
            lblLastHb.Text = dStamp.ToString("HH:mm:ss tt")
            AddLogText(String.Format("HB-SMS sent ({0}. try)", failCount + 1))
            AddFileLog(String.Format("HB-SMS sent ({0}. try)", failCount + 1), 8, LLGenHB)
            failCount = 0
            maxCountMsgGiven = False
        End If
        If failCount > maxFailCount - 1 And Not maxCountMsgGiven Then
            maxCountMsgGiven = True
            AddLogText(maxFailCount & " SMS-tries failed. Not trying again!!")
            AddFileLog(String.Format("{0} SMS-tries failed. Not trying again!!", maxFailCount), 8, LLGenHB)
        End If
    End Sub
    Private Sub CheckDBSettings()
        'checks DB data

        Dim boo As Boolean

        Dim Mnew As New clsBerMA
        Mnew = dbData.getBereitschaftsMA
        If Not Mnew.sameAs(MA) Then
            AddFileLog(String.Format("User change detected! {0}->{1}", MA.name, Mnew.name), 8, LLCheckDB)
            Dim mes As String = String.Format("MA Data Changed{2}{3}New Number: {0}{2}{3}New Mail: {1}",
                                               Mnew.number, Mnew.email, vbCrLf, vbTab)
            'message new number about change
            If Not modem.SendSMS(Mnew.number, mes) Then
                AddLogText("User changed, but no SMS sent to new user!")
                AddFileLog(String.Format("User changed, but no SMS sent to new user: {0}", modem.Message), 2, LLCheckDB)
            Else
                AddLogText(String.Format("SMS sent to new MA ({0})", Mnew.number))
                AddFileLog(String.Format("SMS sent to new MA ({0})", Mnew.number), 8, LLCheckDB)
            End If
            'message old number about change
            If MA.number = vbNullString Then
                AddLogText("no previous MA Number")
            Else
                If Not modem.SendSMS(MA.number, String.Format("{0}{1}{2}", HBStop, vbCrLf, mes)) Then
                    AddLogText("User changed, but no SMS sent to old user!")
                    AddFileLog(String.Format("User Changed, but no SMS sent to old user: {0}", modem.Message), 2, LLCheckDB)
                Else
                    AddLogText(String.Format("SMS sent to old MA ({0})", Mnew.number))
                    AddFileLog(String.Format("SMS sent to old MA ({0})", MA.number), 8, LLCheckDB)
                End If
            End If
            AddLogText(mes)
            AddFileLog(mes, 8, LLCheckDB)
            MA = Mnew
        End If
        If dbData.KillTheDog Then
            'say goodby to current mobile number
            modem.SendSMS(MA.number, String.Format("Dog of {0} ends now", Environment.UserName))
            AddLogText("dog is poisend from DB....")
            AddFileLog(String.Format("dog is poisend from DB. Exiting!", MA.number), 1, LLCheckDB)
            Dim forceExitTimer = New Threading.Timer(Sub() End, Nothing, 3500, 1000)
            Close()
        End If
    End Sub

    Public Overloads Function WatchdogOnDuty() As Boolean
        'true when currently on duty
        Return WatchdogOnDuty(Date.Now, cbOnlyOOH.Checked)
    End Function
    Public Overloads Function WatchdogOnDuty(tstamp As DateTime) As Boolean
        'true when on duty at given time
        Return WatchdogOnDuty(tstamp, cbOnlyOOH.Checked)
    End Function
    Public Overloads Function WatchdogOnDuty(tStamp As Date, onlyDuringOOH As Boolean) As Boolean
        ' true, wenn watchdog rund um die Uhr oder außerhalb der Office-Hours.
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
    Private Function GetItembox(str As String) As Outlook.Items
        Dim result As Outlook.Items = Nothing
        Try 'fails deliberatly if MB not set properly
            'str = pullMBfromWatchFolder()
            result = GetFolderPath(str).Items
        Catch ex As SystemException
            'Debug.Print("not found: " & Str())
            'MsgBox("No Mailbox found!" & vbCrLf & "Tool not working!")
            MA.number = ""
            AddLogText(String.Format("MB not found: {0}", str, vbCrLf))
            'strMailBox = String.Empty
            Return Nothing
        End Try
        Return result
    End Function
    Private Function TestMailBox() As Boolean
        Dim result As Outlook.Items = Nothing
        Dim str As String
        Try 'fails deliberatly if MB not set properly
            str = pullMBfromWatchFolder()
            result = GetFolderPath(str).Items
        Catch ex As SystemException
            AddLogText(String.Format("MB not found: {0}", str, vbCrLf))
            Return False
        End Try
        Return True
    End Function

    Private Sub Setlabels()
        Dim active As String = ""
        Dim strMailBox As String

        Dim x As Process = Process.GetCurrentProcess()

        'memory
        Dim inf As String
        inf = "Mem Usage: " & x.WorkingSet / 1024 & " K" & vbCrLf _
    & "Paged Memory: " & x.PagedMemorySize / 1024 & " K"
        lblRAM.Text = inf

        'data
        strMailBox = pullMBfromWatchFolder()
        If strMailBox = "NONE" Then
            lblMailBox.ForeColor = Color.Red
        Else
            lblMailBox.ForeColor = Color.Black
        End If
        lblMailBox.Text = strMailBox
        lblInterval.Text = HBinterval
        lblComPortNr.Text = strPort
        lblCurNr.Text = MA.number
        lblForward.Text = MA.email
        If Not WatchdogOnDuty() Then
            active = "in"
        End If
        active &= "active"
        GroupBox1.Text = String.Format("Watchdog is {0}", active)
    End Sub

    Private Function pullMBfromWatchFolder() As String
        Dim strMailbox As String
        Try
            strMailbox = objNewItemsWatch.Parent.Folderpath
            strMailbox = Strings.Right(strMailbox, strMailbox.Length - 2)
        Catch
            strMailbox = "NONE"
        End Try
        Return strMailbox
    End Function

    Private Sub rtbOutput_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rtbOutput.MouseUp
        'context Menu for LogText
        If e.Button <> System.Windows.Forms.MouseButtons.Right Then Return
        Dim cms = New ContextMenuStrip
        Dim item1 = cms.Items.Add("Clear Log")
        item1.Tag = 1
        AddHandler item1.Click, AddressOf MenuChoice
        'Dim item2 = cms.Items.Add("bar")
        'item2.Tag = 2
        'AddHandler item2.Click, AddressOf menuChoice
        '-- etc
        '..
        cms.Show(rtbOutput, e.Location)
    End Sub

    Private Sub MenuChoice(ByVal sender As Object, ByVal e As EventArgs)
        'handles the menuchoices from LogText
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        If selection = 1 Then
            strLogText = ""
            rtbOutput.Text = ""
        End If
    End Sub
    Private Sub cbCopyTo_CheckedChanged(sender As Object, e As EventArgs) Handles cbCopyTo.CheckedChanged
        cbbCopyMailsTo.Enabled = cbCopyTo.Checked
        lblForward.Enabled = cbCopyTo.Checked
        Setlabels()
    End Sub

    Private Sub cbOnlyOOH_CheckedChanged(sender As Object, e As EventArgs) Handles cbOnlyOOH.CheckedChanged
        Dim vorheran As Boolean
        Dim jetztan As Boolean
        Dim tStamp As DateTime = Date.Now
        If cbOnlyOOH.Checked Then
            vorheran = WatchdogOnDuty(tStamp, False)
            'wiederherstellen
            jetztan = WatchdogOnDuty(tStamp, True)
            If vorheran And Not jetztan Then
                'MsgBox("STOP-SMS müsste gesendet werden")
                If modem.SendSMS(MA.number, String.Format("{0} {1:t}", HBStop, tStamp)) Then
                    AddLogText("Stop-SMS sent")
                Else
                    AddLogText("! FAIL ! Stop-SMS should be sent but failed")
                End If
            End If

        End If
    End Sub

    Private Sub btSetData_Click(sender As Object, e As EventArgs) Handles btSetManually.Click
        Dim strMailBox As String

        strMailBox = cbbOMailBox.Text

        MA = New clsBerMA With {
            .email = cbbCopyMailsTo.Text,
            .number = tbMobNr.Text
        }

        'mailBox Extenders
        If cbAtCC.Checked Then strMailBox &= "@Computacenter.com"
        strMailBox &= "\Inbox"

        'get Mailbox to watch
        objNewItemsWatch = GetItembox(strMailBox)

        ' Comport
        If tbComPortNr.Text <> "" Then
            strPort = "COM" & tbComPortNr.Text
            CheckComPort()
        End If

        rbUseDB.Checked = False
        rbUseDB.BackColor = Me.BackColor
        rbUseManual.Checked = True
        rbUseManual.BackColor = Color.Yellow
        AddFileLog(String.Format("Data set manually |port:{0}|mail:{1}|nr:{2}|fld:{3}", strPort, MA.email, MA.number, pullMBfromWatchFolder()), 8, LLSettings)
        Setlabels()
    End Sub

    Private Sub btPullData_Click(sender As Object, e As EventArgs) Handles btPullData.Click
        MA = dbData.getBereitschaftsMA()
        cbCopyTo.Checked = (MA.email <> String.Empty)
        cbOnlyOOH.Checked = True
        cbSendHbSMS.Checked = (MA.number <> String.Empty)
        cbSendMailSMS.Checked = True
        rbUseManual.Checked = False
        rbUseDB.Checked = True
        rbUseManual.BackColor = Me.BackColor
        rbUseDB.BackColor = Color.Yellow
        CheckComPort()
        AddFileLog(String.Format("DB-Data pulled manually |mail:{0}|nr:{1}", MA.email, MA.number), 8, LLSettings)
        Setlabels()
    End Sub
    Private Sub CheckComPort()
        With lblComPortNr
            .ForeColor = Color.Black
            modem = New clsSmsModem(strPort)
            If modem.Enabled Then
                .ForeColor = Color.Black
            Else
                strPort = String.Format("{0} n/a !!", strPort)
                .ForeColor = Color.Red
            End If
        End With

    End Sub

    Private Sub rbUseManual_Click(sender As Object, e As EventArgs) Handles rbUseManual.Click
        If Not rbUseManual.Checked Then btSetData_Click(sender, e)
    End Sub

    Private Sub rbUseDB_Click(sender As Object, e As EventArgs) Handles rbUseDB.Click
        If Not rbUseDB.Checked Then btPullData_Click(sender, e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GenerateHB(Date.Now)
    End Sub

End Class