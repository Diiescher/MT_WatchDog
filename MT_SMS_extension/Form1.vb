Option Explicit On
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop.Outlook
Imports Outlook = Microsoft.Office.Interop.Outlook

Imports System.IO.Ports
Imports System.Text.RegularExpressions



Public Class Form1
    Delegate Sub SetTextCallback([text] As String)

    Public WithEvents olApp As Outlook.Application = CreateObject("Outlook.Application")
    Private WithEvents olInspectors As Outlook.Inspectors = olApp.Inspectors
    Private WithEvents olExplorer As Outlook.Explorer = olApp.ActiveExplorer
    Private WithEvents myItem As Outlook.MailItem
    Private WithEvents oMaintFolder As Outlook.Folder
    Private WithEvents objNewMailItemsWatch As Outlook.Items


    Private WithEvents sp As SerialPort
    Private strBuffer As String = String.Empty
    Private Delegate Sub UpdateBufferDelegate(ByVal Text As String)

    Dim MA As New clsBerMA
    Dim WithEvents timer1 As New Timer
    Dim bSent As Boolean
    Dim failCount As Integer = 0
    Dim maxCountMsgGiven As Boolean = False

    Dim maxFailCount As Integer = 10
    Dim interval As Integer = 10
    Dim strLogText As String
    Dim strPort As String


    Dim strCopyFolder = "PureCopy"
    Dim strMailBox As String = "MB.Maintenance_Networking@computacenter.com\Inbox"

    Public Sub New()


        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objNewMailItemsWatch = getMailbox(strMailBox)
        'lblMailBox.Text = objNewMailItemsWatch.Parent.folderpath


        cbbOMailBox.Items.Add("MB.Maintenance_Networking")
        cbbOMailBox.Items.Add("MB.DE_Mainserv_PureStorage_AP")
        cbbOMailBox.SelectedIndex = 0

        cbbCopyMailsTo.Items.Add("Oliver.Schreckenbach@computacenter.com")
        cbbCopyMailsTo.Items.Add("Florian.Graefen@computacenter.com")
        cbbCopyMailsTo.SelectedIndex = 0


        MA = New clsBerMA
        timer1.Interval = 1000
        timer1.Start()
        'cbbOMailBox.Text = strMailBox
        strPort = "COM4"
        setlabels()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        timer1.Start()
    End Sub

    Private Sub objNewMailItemsWatch_ItemAdd(Item As Object) Handles objNewMailItemsWatch.ItemAdd
        'triggers new Mail event
        Dim mail As Outlook.MailItem
        Dim out As String = "trigger not found"
        Dim i As Integer
        Debug.Print("neue Mail eingetroffen")
        If TypeOf Item Is Outlook.MailItem Then
            mail = Item
            AddLogText("new Mail (Topic)" & vbCrLf & vbTab & Strings.Left(mail.ConversationTopic, 30))
            i = InStr(UCase(mail.Body), UCase("Dispatch Requirements"))
            If i > 0 Then
                out = "PureAlarm:" & Strings.Mid(mail.Body, i, 110)
                'Regex.Replace(out,"]")
            End If
            Dim rgx = New Regex("\[|\]|\(|\)|\|")
            out = rgx.Replace(out, ".")
            'send the actual SMS
            SendTextMessage(MA.number, out)
        End If
    End Sub

    Private Sub AddLogText(ByVal [text] As String, Optional i As Integer = 0)
        Dim tStamp As DateTime = TimeOfDay
        strLogText = strLogText & vbCrLf & tStamp.ToString("HH:mm:ss tt") & ": " & [text]
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
        'Return the oFolder
        Return oFolder
        Exit Function

GetFolderPath_Error:
        GetFolderPath = Nothing
        Exit Function
    End Function

    ' Send data and wait for a specific response 
    Private Function SendData(ByVal Data As String, ByVal WaitFor As String) As Boolean
        Debug.Print("Sending:" & Data)
        sp.Write(Data)
        Return WaitForData(WaitFor)
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
        SendTextMessage(MA.number, rtbSmsText.Text)
        AddLogText("testSMS" & vbCrLf & vbTab & MA.number & vbCrLf & vbTab & rtbSmsText.Text)
    End Sub

    Private Sub btChngNr_Click(sender As Object, e As EventArgs) Handles btChngNr.Click
        lblCurNr.Text = tbMobNr.Text
        MA.number = tbMobNr.Text
        strMailBox = cbbOMailBox.Text
        If cbAtCC.Checked Then strMailBox &= "@Computacenter.com"
        If cbSlashInbox.Checked Then strMailBox &= "\Inbox"

        objNewMailItemsWatch = getMailbox(strMailBox)

        If Not objNewMailItemsWatch Is Nothing Then lblMailBox.Text = objNewMailItemsWatch.Parent.folderpath
        If tbComPortNr.Text <> "" Then
            strPort = "COM" & tbComPortNr.Text
        End If
        setlabels()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer1.Tick
        Dim i As Integer

        'clock
        Dim tStamp As DateTime = TimeOfDay
        lblCurTime.Text = tStamp '.ToString("HH:mm:ss tt")
        If MA.number = "" Then Exit Sub
        'Heartbeat every xx Minutes

        i = CType(tStamp.Minute, Integer)
        If i Mod interval <> 0 Then bSent = False
        If i Mod interval = 0 And Not bSent And failCount < maxFailCount Then
            bSent = SendTextMessage(MA.number, "Heartbeat : " & tStamp.ToString("HH:mm:ss"))
            If Not bSent Then
                failCount += 1
                AddLogText("HB-SMS failed " & failCount & " of " & maxFailCount & " times")
            Else
                'update lastHB-Label
                lblLastHb.Text = tStamp.ToString("HH:mm:ss tt")
                'set log-Box
                AddLogText("HB-SMS sent (" & failCount + 1 & ". try)")
                failCount = 0
            End If
        End If
        If failCount > maxFailCount - 1 And Not maxCountMsgGiven Then
            maxCountMsgGiven = True
            AddLogText(maxFailCount & " SMS-tries failed. Not trying again")
        End If
    End Sub
    Public Function SendTextMessage(ByVal [To] As String, ByVal Message As String) As Boolean
        Dim result As Boolean

        Debug.Print("trying to send SMS: " & [To] & " to " & vbCrLf & Message)
        'Return True
        'Exit Function

        Try
            sp = My.Computer.Ports.OpenSerialPort(strPort)
            result = SendData("ATZ" & vbCr, "OK")
            result = result And SendData("AT+CMGF=1" & vbCr, "OK")
            result = result And SendData("AT+CSCA=""+491722270000"",129" & vbCr, "OK")
            result = result And SendData("AT+CSMP=17,167,0,0" & vbCr, "OK")
            result = result And SendData("AT+CMGS=""" & [To] & """" & vbCr, ">")
            result = result And SendData(Message & vbCr, ">")
            result = result And SendData(Chr(26), "OK")
            sp.Close()
        Catch EX As System.Exception
            result = False
            AddLogText("Send SMS Fail: " & vbCrLf & [To] & " : " & vbCrLf & "Message: " & Message)
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
        lblInterval.Text = interval
        lblCurNr.Text = MA.number
        lblMailBox.Text = strMailBox
        lblComPortNr.Text = strPort
    End Sub

    Private Function WaitForData(ByVal Data As String, Optional ByVal Timeout As Integer = 10) As Boolean
        Dim StartTime As Date = Date.Now
        Do
            If InStr(strBuffer, Data) > 0 Then
                strBuffer = strBuffer.Substring((InStr(strBuffer, Data) - 1) + Data.Length)
                Debug.Print("OK")
                Return True
            End If
            If Date.Now.Subtract(StartTime).TotalSeconds >= Timeout Then
                Debug.Print("FAIL")
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
    End Sub
End Class