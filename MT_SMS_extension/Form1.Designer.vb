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
        Me.lblLog = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCurNr = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblWDisactive = New System.Windows.Forms.Label()
        Me.lblDateInfo = New System.Windows.Forms.Label()
        Me.cbOnlyOOH = New System.Windows.Forms.CheckBox()
        Me.cbSendHbSMS = New System.Windows.Forms.CheckBox()
        Me.lblForward = New System.Windows.Forms.Label()
        Me.cbSendMailSMS = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblComPortNr = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbCopyTo = New System.Windows.Forms.CheckBox()
        Me.lblMailBox = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblInterval = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblLastHb = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCurTime = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbComPortNr = New System.Windows.Forms.TextBox()
        Me.cbbOMailBox = New System.Windows.Forms.ComboBox()
        Me.btClearLog = New System.Windows.Forms.Button()
        Me.cbAtCC = New System.Windows.Forms.CheckBox()
        Me.cbbCopyMailsTo = New System.Windows.Forms.ComboBox()
        Me.rbUseManual = New System.Windows.Forms.RadioButton()
        Me.rbUseDB = New System.Windows.Forms.RadioButton()
        Me.btPullData = New System.Windows.Forms.Button()
        Me.btSetData = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbOutput
        '
        Me.rtbOutput.Location = New System.Drawing.Point(31, 479)
        Me.rtbOutput.Name = "rtbOutput"
        Me.rtbOutput.Size = New System.Drawing.Size(365, 169)
        Me.rtbOutput.TabIndex = 0
        Me.rtbOutput.Text = ""
        '
        'tbMobNr
        '
        Me.tbMobNr.Location = New System.Drawing.Point(169, 47)
        Me.tbMobNr.Name = "tbMobNr"
        Me.tbMobNr.Size = New System.Drawing.Size(124, 20)
        Me.tbMobNr.TabIndex = 1
        '
        'rtbSmsText
        '
        Me.rtbSmsText.Location = New System.Drawing.Point(31, 439)
        Me.rtbSmsText.Name = "rtbSmsText"
        Me.rtbSmsText.Size = New System.Drawing.Size(365, 23)
        Me.rtbSmsText.TabIndex = 2
        Me.rtbSmsText.Text = "SMS text"
        '
        'btSend
        '
        Me.btSend.Location = New System.Drawing.Point(405, 439)
        Me.btSend.Name = "btSend"
        Me.btSend.Size = New System.Drawing.Size(88, 25)
        Me.btSend.TabIndex = 3
        Me.btSend.Text = "test SMS"
        Me.btSend.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(169, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "mobile number"
        '
        'lblLog
        '
        Me.lblLog.AutoSize = True
        Me.lblLog.Location = New System.Drawing.Point(28, 465)
        Me.lblLog.Name = "lblLog"
        Me.lblLog.Size = New System.Drawing.Size(25, 13)
        Me.lblLog.TabIndex = 6
        Me.lblLog.Text = "Log"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(11, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "mobile Nr: "
        '
        'lblCurNr
        '
        Me.lblCurNr.AutoSize = True
        Me.lblCurNr.Location = New System.Drawing.Point(78, 64)
        Me.lblCurNr.Name = "lblCurNr"
        Me.lblCurNr.Size = New System.Drawing.Size(14, 13)
        Me.lblCurNr.TabIndex = 9
        Me.lblCurNr.Text = "#"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblWDisactive)
        Me.GroupBox1.Controls.Add(Me.lblDateInfo)
        Me.GroupBox1.Controls.Add(Me.cbOnlyOOH)
        Me.GroupBox1.Controls.Add(Me.cbSendHbSMS)
        Me.GroupBox1.Controls.Add(Me.lblForward)
        Me.GroupBox1.Controls.Add(Me.cbSendMailSMS)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lblComPortNr)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cbCopyTo)
        Me.GroupBox1.Controls.Add(Me.lblMailBox)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.lblCurTime)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblCurNr)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(31, 171)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(368, 253)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "actually using:"
        '
        'lblWDisactive
        '
        Me.lblWDisactive.AutoSize = True
        Me.lblWDisactive.Location = New System.Drawing.Point(12, 39)
        Me.lblWDisactive.Name = "lblWDisactive"
        Me.lblWDisactive.Size = New System.Drawing.Size(59, 13)
        Me.lblWDisactive.TabIndex = 27
        Me.lblWDisactive.Text = "WD Status"
        '
        'lblDateInfo
        '
        Me.lblDateInfo.AutoSize = True
        Me.lblDateInfo.Location = New System.Drawing.Point(141, 24)
        Me.lblDateInfo.Name = "lblDateInfo"
        Me.lblDateInfo.Size = New System.Drawing.Size(76, 13)
        Me.lblDateInfo.TabIndex = 26
        Me.lblDateInfo.Text = "DatumFeiertag"
        '
        'cbOnlyOOH
        '
        Me.cbOnlyOOH.AutoSize = True
        Me.cbOnlyOOH.Checked = True
        Me.cbOnlyOOH.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbOnlyOOH.Location = New System.Drawing.Point(14, 155)
        Me.cbOnlyOOH.Name = "cbOnlyOOH"
        Me.cbOnlyOOH.Size = New System.Drawing.Size(125, 17)
        Me.cbOnlyOOH.TabIndex = 25
        Me.cbOnlyOOH.Text = "Watchdog only OOH"
        Me.cbOnlyOOH.UseVisualStyleBackColor = True
        '
        'cbSendHbSMS
        '
        Me.cbSendHbSMS.AutoSize = True
        Me.cbSendHbSMS.Location = New System.Drawing.Point(15, 224)
        Me.cbSendHbSMS.Name = "cbSendHbSMS"
        Me.cbSendHbSMS.Size = New System.Drawing.Size(125, 17)
        Me.cbSendHbSMS.TabIndex = 24
        Me.cbSendHbSMS.Text = "send Heartbeat-SMS"
        Me.cbSendHbSMS.UseVisualStyleBackColor = True
        '
        'lblForward
        '
        Me.lblForward.AutoSize = True
        Me.lblForward.Location = New System.Drawing.Point(73, 131)
        Me.lblForward.Name = "lblForward"
        Me.lblForward.Size = New System.Drawing.Size(45, 13)
        Me.lblForward.TabIndex = 20
        Me.lblForward.Text = "Label12"
        '
        'cbSendMailSMS
        '
        Me.cbSendMailSMS.AutoSize = True
        Me.cbSendMailSMS.Location = New System.Drawing.Point(15, 201)
        Me.cbSendMailSMS.Name = "cbSendMailSMS"
        Me.cbSendMailSMS.Size = New System.Drawing.Size(134, 17)
        Me.cbSendMailSMS.TabIndex = 23
        Me.cbSendMailSMS.Text = "send SMS on new mail"
        Me.cbSendMailSMS.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label11.Location = New System.Drawing.Point(11, 131)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Forward to: "
        '
        'lblComPortNr
        '
        Me.lblComPortNr.AutoSize = True
        Me.lblComPortNr.Location = New System.Drawing.Point(271, 64)
        Me.lblComPortNr.Name = "lblComPortNr"
        Me.lblComPortNr.Size = New System.Drawing.Size(35, 13)
        Me.lblComPortNr.TabIndex = 18
        Me.lblComPortNr.Text = "Com#"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(220, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Modem:"
        '
        'cbCopyTo
        '
        Me.cbCopyTo.AutoSize = True
        Me.cbCopyTo.Location = New System.Drawing.Point(15, 178)
        Me.cbCopyTo.Name = "cbCopyTo"
        Me.cbCopyTo.Size = New System.Drawing.Size(96, 17)
        Me.cbCopyTo.TabIndex = 20
        Me.cbCopyTo.Text = "send mail copy"
        Me.cbCopyTo.UseVisualStyleBackColor = True
        '
        'lblMailBox
        '
        Me.lblMailBox.AutoSize = True
        Me.lblMailBox.Location = New System.Drawing.Point(11, 107)
        Me.lblMailBox.Name = "lblMailBox"
        Me.lblMailBox.Size = New System.Drawing.Size(54, 13)
        Me.lblMailBox.TabIndex = 16
        Me.lblMailBox.Text = "lblMailBox"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 90)
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
        Me.GroupBox2.Location = New System.Drawing.Point(181, 155)
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
        Me.lblCurTime.Location = New System.Drawing.Point(79, 24)
        Me.lblCurTime.Name = "lblCurTime"
        Me.lblCurTime.Size = New System.Drawing.Size(45, 13)
        Me.lblCurTime.TabIndex = 12
        Me.lblCurTime.Text = "curTime"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "current time: "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(28, 62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Mailboxfolder to watch"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(331, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "COM-Port"
        '
        'tbComPortNr
        '
        Me.tbComPortNr.Location = New System.Drawing.Point(334, 47)
        Me.tbComPortNr.MaxLength = 2
        Me.tbComPortNr.Name = "tbComPortNr"
        Me.tbComPortNr.Size = New System.Drawing.Size(48, 20)
        Me.tbComPortNr.TabIndex = 15
        Me.tbComPortNr.Text = "4"
        '
        'cbbOMailBox
        '
        Me.cbbOMailBox.FormattingEnabled = True
        Me.cbbOMailBox.Location = New System.Drawing.Point(31, 78)
        Me.cbbOMailBox.Name = "cbbOMailBox"
        Me.cbbOMailBox.Size = New System.Drawing.Size(262, 21)
        Me.cbbOMailBox.TabIndex = 16
        '
        'btClearLog
        '
        Me.btClearLog.Location = New System.Drawing.Point(405, 619)
        Me.btClearLog.Name = "btClearLog"
        Me.btClearLog.Size = New System.Drawing.Size(88, 30)
        Me.btClearLog.TabIndex = 17
        Me.btClearLog.Text = "ClearLog"
        Me.btClearLog.UseVisualStyleBackColor = True
        '
        'cbAtCC
        '
        Me.cbAtCC.AutoSize = True
        Me.cbAtCC.Location = New System.Drawing.Point(305, 80)
        Me.cbAtCC.Name = "cbAtCC"
        Me.cbAtCC.Size = New System.Drawing.Size(88, 17)
        Me.cbAtCC.TabIndex = 18
        Me.cbAtCC.Text = "@Computa..."
        Me.cbAtCC.UseVisualStyleBackColor = True
        '
        'cbbCopyMailsTo
        '
        Me.cbbCopyMailsTo.FormattingEnabled = True
        Me.cbbCopyMailsTo.Location = New System.Drawing.Point(113, 105)
        Me.cbbCopyMailsTo.Name = "cbbCopyMailsTo"
        Me.cbbCopyMailsTo.Size = New System.Drawing.Size(269, 21)
        Me.cbbCopyMailsTo.TabIndex = 21
        '
        'rbUseManual
        '
        Me.rbUseManual.AutoSize = True
        Me.rbUseManual.Location = New System.Drawing.Point(20, 17)
        Me.rbUseManual.Name = "rbUseManual"
        Me.rbUseManual.Size = New System.Drawing.Size(118, 17)
        Me.rbUseManual.TabIndex = 22
        Me.rbUseManual.TabStop = True
        Me.rbUseManual.Text = "Use Manual Setting"
        Me.rbUseManual.UseVisualStyleBackColor = True
        '
        'rbUseDB
        '
        Me.rbUseDB.AutoSize = True
        Me.rbUseDB.Location = New System.Drawing.Point(20, 148)
        Me.rbUseDB.Name = "rbUseDB"
        Me.rbUseDB.Size = New System.Drawing.Size(129, 17)
        Me.rbUseDB.TabIndex = 23
        Me.rbUseDB.TabStop = True
        Me.rbUseDB.Text = "Use Database Setting"
        Me.rbUseDB.UseVisualStyleBackColor = True
        '
        'btPullData
        '
        Me.btPullData.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btPullData.Location = New System.Drawing.Point(405, 185)
        Me.btPullData.Name = "btPullData"
        Me.btPullData.Size = New System.Drawing.Size(88, 23)
        Me.btPullData.TabIndex = 24
        Me.btPullData.Text = "Pull Data"
        Me.btPullData.UseVisualStyleBackColor = True
        '
        'btSetData
        '
        Me.btSetData.Location = New System.Drawing.Point(405, 25)
        Me.btSetData.Name = "btSetData"
        Me.btSetData.Size = New System.Drawing.Size(88, 25)
        Me.btSetData.TabIndex = 25
        Me.btSetData.Text = "Set Manual"
        Me.btSetData.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(30, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "copy-to E-Mail"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 660)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btSetData)
        Me.Controls.Add(Me.btPullData)
        Me.Controls.Add(Me.rbUseDB)
        Me.Controls.Add(Me.rbUseManual)
        Me.Controls.Add(Me.cbAtCC)
        Me.Controls.Add(Me.btClearLog)
        Me.Controls.Add(Me.cbbOMailBox)
        Me.Controls.Add(Me.cbbCopyMailsTo)
        Me.Controls.Add(Me.tbComPortNr)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rtbSmsText)
        Me.Controls.Add(Me.lblLog)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btSend)
        Me.Controls.Add(Me.tbMobNr)
        Me.Controls.Add(Me.rtbOutput)
        Me.Name = "Form1"
        Me.Text = "MB_Watchdog killsw"
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
    Friend WithEvents lblLog As Label
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
    Friend WithEvents cbCopyTo As CheckBox
    Friend WithEvents cbbCopyMailsTo As ComboBox
    Friend WithEvents lblForward As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cbSendMailSMS As CheckBox
    Friend WithEvents cbSendHbSMS As CheckBox
    Friend WithEvents cbOnlyOOH As CheckBox
    Friend WithEvents lblDateInfo As Label
    Friend WithEvents lblWDisactive As Label
    Friend WithEvents rbUseManual As RadioButton
    Friend WithEvents rbUseDB As RadioButton
    Friend WithEvents btPullData As Button
    Friend WithEvents btSetData As Button
    Friend WithEvents Label12 As Label
End Class
