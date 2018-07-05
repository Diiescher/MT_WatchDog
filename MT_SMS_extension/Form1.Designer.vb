<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rtbOutput = New System.Windows.Forms.RichTextBox()
        Me.tbMobNr = New System.Windows.Forms.TextBox()
        Me.rtbSmsText = New System.Windows.Forms.RichTextBox()
        Me.btSend = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btChngNr = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCurNr = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblComPortNr = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblMailBox = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblInterval = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblLastHb = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCurTime = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbComPortNr = New System.Windows.Forms.TextBox()
        Me.cbbOMailBox = New System.Windows.Forms.ComboBox()
        Me.btClearLog = New System.Windows.Forms.Button()
        Me.cbAtCC = New System.Windows.Forms.CheckBox()
        Me.cbSlashInbox = New System.Windows.Forms.CheckBox()
        Me.cbCopyTo = New System.Windows.Forms.CheckBox()
        Me.cbbCopyMailsTo = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbOutput
        '
        Me.rtbOutput.Location = New System.Drawing.Point(33, 490)
        Me.rtbOutput.Name = "rtbOutput"
        Me.rtbOutput.Size = New System.Drawing.Size(361, 169)
        Me.rtbOutput.TabIndex = 0
        Me.rtbOutput.Text = ""
        '
        'tbMobNr
        '
        Me.tbMobNr.Location = New System.Drawing.Point(28, 33)
        Me.tbMobNr.Name = "tbMobNr"
        Me.tbMobNr.Size = New System.Drawing.Size(278, 20)
        Me.tbMobNr.TabIndex = 1
        Me.tbMobNr.Text = "+491729278903"
        '
        'rtbSmsText
        '
        Me.rtbSmsText.Location = New System.Drawing.Point(14, 226)
        Me.rtbSmsText.Name = "rtbSmsText"
        Me.rtbSmsText.Size = New System.Drawing.Size(333, 39)
        Me.rtbSmsText.TabIndex = 2
        Me.rtbSmsText.Text = "SMS text"
        '
        'btSend
        '
        Me.btSend.Location = New System.Drawing.Point(426, 416)
        Me.btSend.Name = "btSend"
        Me.btSend.Size = New System.Drawing.Size(88, 25)
        Me.btSend.TabIndex = 3
        Me.btSend.Text = "test SMS"
        Me.btSend.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "mobile number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 465)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Log"
        '
        'btChngNr
        '
        Me.btChngNr.Location = New System.Drawing.Point(405, 22)
        Me.btChngNr.Name = "btChngNr"
        Me.btChngNr.Size = New System.Drawing.Size(119, 31)
        Me.btChngNr.TabIndex = 7
        Me.btChngNr.Text = "manual Override"
        Me.btChngNr.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "mobile Nr: "
        '
        'lblCurNr
        '
        Me.lblCurNr.AutoSize = True
        Me.lblCurNr.Location = New System.Drawing.Point(104, 25)
        Me.lblCurNr.Name = "lblCurNr"
        Me.lblCurNr.Size = New System.Drawing.Size(14, 13)
        Me.lblCurNr.TabIndex = 9
        Me.lblCurNr.Text = "#"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblComPortNr)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.lblMailBox)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.lblCurTime)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblCurNr)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.rtbSmsText)
        Me.GroupBox1.Location = New System.Drawing.Point(33, 176)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(368, 271)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "actually using:"
        '
        'lblComPortNr
        '
        Me.lblComPortNr.AutoSize = True
        Me.lblComPortNr.Location = New System.Drawing.Point(257, 28)
        Me.lblComPortNr.Name = "lblComPortNr"
        Me.lblComPortNr.Size = New System.Drawing.Size(45, 13)
        Me.lblComPortNr.TabIndex = 18
        Me.lblComPortNr.Text = "Label11"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(220, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Com:"
        '
        'lblMailBox
        '
        Me.lblMailBox.AutoSize = True
        Me.lblMailBox.Location = New System.Drawing.Point(11, 88)
        Me.lblMailBox.Name = "lblMailBox"
        Me.lblMailBox.Size = New System.Drawing.Size(54, 13)
        Me.lblMailBox.TabIndex = 16
        Me.lblMailBox.Text = "lblMailBox"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Watched Mailbox:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblInterval)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lblLastHb)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 140)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(187, 65)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "HeartBeat"
        '
        'lblInterval
        '
        Me.lblInterval.AutoSize = True
        Me.lblInterval.Location = New System.Drawing.Point(93, 22)
        Me.lblInterval.Name = "lblInterval"
        Me.lblInterval.Size = New System.Drawing.Size(13, 13)
        Me.lblInterval.TabIndex = 15
        Me.lblInterval.Text = "--"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "interval (min)"
        '
        'lblLastHb
        '
        Me.lblLastHb.AutoSize = True
        Me.lblLastHb.Location = New System.Drawing.Point(93, 39)
        Me.lblLastHb.Name = "lblLastHb"
        Me.lblLastHb.Size = New System.Drawing.Size(37, 13)
        Me.lblLastHb.TabIndex = 13
        Me.lblLastHb.Text = "lastHb"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "last:"
        '
        'lblCurTime
        '
        Me.lblCurTime.AutoSize = True
        Me.lblCurTime.Location = New System.Drawing.Point(104, 43)
        Me.lblCurTime.Name = "lblCurTime"
        Me.lblCurTime.Size = New System.Drawing.Size(45, 13)
        Me.lblCurTime.TabIndex = 12
        Me.lblCurTime.Text = "curTime"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "current time: "
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(426, 185)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 29)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "pull Data"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(26, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Mailbox"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(330, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "COM-Port"
        '
        'tbComPortNr
        '
        Me.tbComPortNr.Location = New System.Drawing.Point(333, 33)
        Me.tbComPortNr.MaxLength = 2
        Me.tbComPortNr.Name = "tbComPortNr"
        Me.tbComPortNr.Size = New System.Drawing.Size(48, 20)
        Me.tbComPortNr.TabIndex = 15
        Me.tbComPortNr.Text = "4"
        '
        'cbbOMailBox
        '
        Me.cbbOMailBox.FormattingEnabled = True
        Me.cbbOMailBox.Location = New System.Drawing.Point(32, 80)
        Me.cbbOMailBox.Name = "cbbOMailBox"
        Me.cbbOMailBox.Size = New System.Drawing.Size(274, 21)
        Me.cbbOMailBox.TabIndex = 16
        '
        'btClearLog
        '
        Me.btClearLog.Location = New System.Drawing.Point(436, 628)
        Me.btClearLog.Name = "btClearLog"
        Me.btClearLog.Size = New System.Drawing.Size(63, 30)
        Me.btClearLog.TabIndex = 17
        Me.btClearLog.Text = "ClearLog"
        Me.btClearLog.UseVisualStyleBackColor = True
        '
        'cbAtCC
        '
        Me.cbAtCC.AutoSize = True
        Me.cbAtCC.Location = New System.Drawing.Point(321, 82)
        Me.cbAtCC.Name = "cbAtCC"
        Me.cbAtCC.Size = New System.Drawing.Size(88, 17)
        Me.cbAtCC.TabIndex = 18
        Me.cbAtCC.Text = "@Computa..."
        Me.cbAtCC.UseVisualStyleBackColor = True
        '
        'cbSlashInbox
        '
        Me.cbSlashInbox.AutoSize = True
        Me.cbSlashInbox.Location = New System.Drawing.Point(426, 81)
        Me.cbSlashInbox.Name = "cbSlashInbox"
        Me.cbSlashInbox.Size = New System.Drawing.Size(57, 17)
        Me.cbSlashInbox.TabIndex = 19
        Me.cbSlashInbox.Text = "\Inbox"
        Me.cbSlashInbox.UseVisualStyleBackColor = True
        '
        'cbCopyTo
        '
        Me.cbCopyTo.AutoSize = True
        Me.cbCopyTo.Checked = True
        Me.cbCopyTo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbCopyTo.Location = New System.Drawing.Point(26, 116)
        Me.cbCopyTo.Name = "cbCopyTo"
        Me.cbCopyTo.Size = New System.Drawing.Size(89, 17)
        Me.cbCopyTo.TabIndex = 20
        Me.cbCopyTo.Text = "Copy Mails to"
        Me.cbCopyTo.UseVisualStyleBackColor = True
        '
        'cbbCopyMailsTo
        '
        Me.cbbCopyMailsTo.FormattingEnabled = True
        Me.cbbCopyMailsTo.Location = New System.Drawing.Point(139, 115)
        Me.cbbCopyMailsTo.Name = "cbbCopyMailsTo"
        Me.cbbCopyMailsTo.Size = New System.Drawing.Size(240, 21)
        Me.cbbCopyMailsTo.TabIndex = 21
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 671)
        Me.Controls.Add(Me.cbbCopyMailsTo)
        Me.Controls.Add(Me.cbCopyTo)
        Me.Controls.Add(Me.cbSlashInbox)
        Me.Controls.Add(Me.cbAtCC)
        Me.Controls.Add(Me.btClearLog)
        Me.Controls.Add(Me.cbbOMailBox)
        Me.Controls.Add(Me.tbComPortNr)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btChngNr)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btSend)
        Me.Controls.Add(Me.tbMobNr)
        Me.Controls.Add(Me.rtbOutput)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rtbOutput As RichTextBox
    Friend WithEvents tbMobNr As TextBox
    Friend WithEvents rtbSmsText As RichTextBox
    Friend WithEvents btSend As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btChngNr As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents lblCurNr As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblLastHb As Label
    Friend WithEvents lblCurTime As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblInterval As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lblMailBox As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblComPortNr As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents tbComPortNr As TextBox
    Friend WithEvents cbbOMailBox As ComboBox
    Friend WithEvents btClearLog As Button
    Friend WithEvents cbAtCC As CheckBox
    Friend WithEvents cbSlashInbox As CheckBox
    Friend WithEvents cbCopyTo As CheckBox
    Friend WithEvents cbbCopyMailsTo As ComboBox
End Class
