Option Explicit On
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



    Private strBuffer As String = String.Empty
    Private Delegate Sub UpdateBufferDelegate(ByVal Text As String)

    Dim MA As New clsBerMA
    Dim WithEvents timer1 As New Timer
    Dim bHbSent As Boolean
    Dim failCount As Integer = 0
    Dim maxCountMsgGiven As Boolean = False

    Dim maxFailCount As Integer = 10
    Const interval As Integer = 15
    Dim strLogText As String
    Dim strPort As String = "COM"


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

        tbMobNr.Text = "01728303626"


        MA = New clsBerMA
        'If cbCopyTo.Checked Then MA.email = String.Format("{0}\{1}", {cbbCopyMailsTo.Text, strCopyFolder})
        timer1.Interval = 1000
        timer1.Start()
        'cbbOMailBox.Text = strMailBox

        lblSendTo.Text = ""
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

            'send the actual SMS
            If cbSendMailSMS.Checked Then
                If SendTextMessage(MA.number, out) Then
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
    Private Sub AddLogText(ByVal [text] As String, Optional i As Integer = 0)
        Dim tStamp As Date = Date.Now
        strLogText = String.Format("{0}{1}{2:t}: {3}", {strLogText, vbCrLf, tStamp, [text]})
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

    Function GetFolderPath(ByVal FolderPath As String) As Outlook.Folder
        ' from https://www.slipstick.com/developer/working-vba-nondefault-outlook-folders/
        Dim oFolder As Outlook.Folder

        Dim i As Integer

        On Error GoTo GetFolderPath_Error
        If Strings.Left(FolderPath, 2) = "\\" Then
            FolderPath = Strings.Right(FolderPath, Len(FolderPath) - 2)
        End If
        'Convert folderpath to array
        Dim FoldersArray = Split(FolderPath, "\")
        oFolder = olApp.Session.Folders.Item(FoldersArray(0))
        If Not oFolder Is Nothing Then
            For i = 1 To UBound(FoldersArray, 1)
                Dim SubFolders As Outlook.Folders
                SubFolders = oFolder.Folders
                oFolder = SubFolders.Item(FoldersArray(i))
                If oFolder Is Nothing Then
                    GetFolderPath = Nothing
                End If
            Next
        End If
        Return oFolder
        Exit Function

GetFolderPath_Error:
        GetFolderPath = Nothing
        Exit Function
    End Function

    ' Send data and wait for a specific response 
    Private Function ComSendData(ByVal Data As String, ByVal WaitFor As String) As Boolean
        Dim res As Boolean
        'Debug.Print("Sending:" & Data)
        rtbComLog.Text &= "Sending: " & Data & vbCrLf
        rtbComLog.Text &= "Waiting for: " & WaitFor & "......"
        sp.Write(Data)
        res = WaitForData(WaitFor)
        If res Then
            rtbComLog.Text &= "OK" & vbCrLf
        Else
            rtbComLog.Text &= "FAIL!" & vbCrLf
        End If
        Return res
    End Function

    Private Sub UpdateBuffer(ByVal Text As String)
        strBuffer &= Text
    End Sub

    Private Sub sp_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs) Handles sp.DataReceived
        Dim dUpdateBuffer As New UpdateBufferDelegate(AddressOf UpdateBuffer)
        Dim strTmp As String = sp.ReadExisting
        dUpdateBuffer.Invoke(strTmp)
    End Sub

    Private Sub btSend_Click(sender As Object, e As EventArgs) Handles btSend.Click
        AddLogText(String.Format("Test-SMS an {0}{2}Text:{1}", {MA.number, rtbSmsText.Text, vbCrLf}))
        If SendTextMessage(MA.number, rtbSmsText.Text) Then
            AddLogText("SMS Test OK")
        Else
            AddLogText("SMS Test Fail")
        End If

    End Sub

    Private Sub btChngNr_Click(sender As Object, e As EventArgs) Handles btChngNr.Click

        strMailBox = cbbOMailBox.Text

        'Forwarder
        If cbCopyTo.Checked Then MA.email = cbbCopyMailsTo.Text
        MA.number = tbMobNr.Text

        'mail Extenders
        If cbAtCC.Checked Then strMailBox &= "@Computacenter.com"
        If cbSlashInbox.Checked Then strMailBox &= "\Inbox"

        'get Mailbox to watch
        objNewMailItemsWatch = getMailbox(strMailBox)

        ' Comport
        If tbComPortNr.Text <> "" Then
            strPort = "COM" & tbComPortNr.Text
            lblComPortNr.ForeColor = Color.Black
            Try
                sp = My.Computer.Ports.OpenSerialPort(strPort)
                sp.Close()
            Catch ex As System.Exception
                strPort &= " n/a !!"
                lblComPortNr.ForeColor = Color.Red
            End Try
        End If
        setlabels()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer1.Tick
        ' Heartbeart-Timer ticked

        Dim i As Integer

        'clock
        Dim tStamp As DateTime = TimeOfDay
        Dim dStamp As DateTime = Date.Now

        'zum testen :)
        'dstamp = Date.Parse("2.7.2018")

        'Uhr
        lblCurTime.Text = tStamp  '.ToString("HH:mm:ss tt")
        lblDateInfo.Text = String.Format("{0:D} {1}", {dStamp, IstFeiertag(dStamp)})
        If MA.number = "" Then Exit Sub

        'Heartbeat every xx Minutes
        i = CType(tStamp.Minute, Integer) '0-59
        'reset sent-flag after time-window
        If i Mod interval <> 0 Then bHbSent = False
        If watchdog_active() Then
            If i Mod interval = 0 And Not bHbSent And failCount < maxFailCount Then
                If cbSendHbSMS.Checked Then
                    'actual Haertbeat-SMS
                    bHbSent = SendTextMessage(MA.number, "PureHB : " & tStamp.ToString("HH:mm:ss"))
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
    Public Function watchdog_active() As Boolean
        Dim res As Boolean
        Dim weekend As Boolean
        Dim tStamp As Date = Date.Now

        With tStamp
            weekend = (.DayOfWeek = 6) Or (.DayOfWeek = 0) Or IstFeiertag(.Date) <> ""
            res = Not cbOnlyOOH.Checked
            res = res OrElse ((cbOnlyOOH.Checked) And .Hour < 6)
            res = res Or weekend
            res = res And MA.number <> ""
        End With
        Return res
    End Function
    Public Function SendTextMessage(ByVal [To] As String, ByVal Message As String) As Boolean
        Dim result As Boolean

        'Debug.Print("trying to send SMS: " & [To] & " to " & vbCrLf & Message)
        'Return True
        'Exit Function
        Try
            Try
                lblComPortNr.ForeColor = Color.Black
                sp = My.Computer.Ports.OpenSerialPort(strPort)
            Catch ex As System.Exception
                strPort &= " n/a !!"
                lblComPortNr.ForeColor = Color.Red
                Return False
            End Try
            result = ComSendData("ATZ" & vbCr, "OK")
            ' set text-mode
            'result = result And ComSendData("AT+CMGF=1" & vbCr, "OK")
            ' set SMS Center +491722270000, should be saved on SIM
            'result = result And ComSendData("AT+CSCA=""+491722270333"",145" & vbCr, "OK")
            ' set data type
            'result = result And ComSendData("AT+CSMP=17,167,0,0" & vbCr, "OK")
            result = result And ComSendData("AT+CMGS=""" & [To] & """" & vbCr, ">")
            result = result And ComSendData(Message & vbCr, ">")
            result = result And ComSendData(Chr(26), "OK")
            sp.Close()
        Catch EX As System.Exception
            result = False
            AddLogText("Send SMS failed with exception: " & vbCrLf & [To] & " : " & vbCrLf & "Message: " & Message)
            AddLogText("COM: " & strPort)
            AddLogText(EX.Message)
        End Try
        Return result
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
        lblInterval.Text = interval
        lblComPortNr.Text = strPort
        lblCurNr.Text = MA.number
        lblForward.Text = MA.email
        If Not watchdog_active() Then
            active = "in"
        End If
        active &= "active"
        lblWDisactive.Text = String.Format("Watchdog is {0}", active)
    End Sub

    Private Function WaitForData(ByVal Data As String, Optional ByVal Timeout As Integer = 10) As Boolean
        Dim StartTime As Date = Date.Now
        Do
            If InStr(strBuffer, Data) > 0 Then
                strBuffer = strBuffer.Substring((InStr(strBuffer, Data) - 1) + Data.Length)
                'Debug.Print("OK")
                Return True
            End If
            If Date.Now.Subtract(StartTime).TotalSeconds >= Timeout Then
                'Debug.Print("FAIL")
                Return False
            End If
        Loop
    End Function

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


End Class