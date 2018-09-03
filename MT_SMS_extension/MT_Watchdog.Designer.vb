<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MT_Watchdog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
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
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.cbAtCC = New System.Windows.Forms.CheckBox()
        Me.cbbCopyMailsTo = New System.Windows.Forms.ComboBox()
        Me.rbUseManual = New System.Windows.Forms.RadioButton()
        Me.rbUseDB = New System.Windows.Forms.RadioButton()
        Me.btPullData = New System.Windows.Forms.Button()
        Me.btSetManually = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblRAM = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbOutput
        '
        Me.rtbOutput.Location = New System.Drawing.Point(31, 466)
        Me.rtbOutput.Name = "rtbOutput"
        Me.rtbOutput.Size = New System.Drawing.Size(462, 169)
        Me.rtbOutput.TabIndex = 0
        Me.rtbOutput.Text = ""
        '
        'tbMobNr
        '
        Me.tbMobNr.Location = New System.Drawing.Point(121, 41)
        Me.tbMobNr.Name = "tbMobNr"
        Me.tbMobNr.Size = New System.Drawing.Size(152, 20)
        Me.tbMobNr.TabIndex = 1
        '
        'rtbSmsText
        '
        Me.rtbSmsText.Location = New System.Drawing.Point(31, 426)
        Me.rtbSmsText.Name = "rtbSmsText"
        Me.rtbSmsText.Size = New System.Drawing.Size(365, 23)
        Me.rtbSmsText.TabIndex = 2
        Me.rtbSmsText.Text = "SMS text"
        '
        'btSend
        '
        Me.btSend.Location = New System.Drawing.Point(405, 426)
        Me.btSend.Name = "btSend"
        Me.btSend.Size = New System.Drawing.Size(88, 25)
        Me.btSend.TabIndex = 3
        Me.btSend.Text = "test SMS"
        Me.btSend.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "mobile number"
        '
        'lblLog
        '
        Me.lblLog.AutoSize = True
        Me.lblLog.Location = New System.Drawing.Point(28, 452)
        Me.lblLog.Name = "lblLog"
        Me.lblLog.Size = New System.Drawing.Size(25, 13)
        Me.lblLog.TabIndex = 6
        Me.lblLog.Text = "Log"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(12, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "mobile Nr: "
        '
        'lblCurNr
        '
        Me.lblCurNr.AutoSize = True
        Me.lblCurNr.Location = New System.Drawing.Point(79, 94)
        Me.lblCurNr.Name = "lblCurNr"
        Me.lblCurNr.Size = New System.Drawing.Size(14, 13)
        Me.lblCurNr.TabIndex = 9
        Me.lblCurNr.Text = "#"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblRAM)
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
        Me.GroupBox1.Size = New System.Drawing.Size(462, 240)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "actually using:"
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
        Me.cbOnlyOOH.Location = New System.Drawing.Point(15, 146)
        Me.cbOnlyOOH.Name = "cbOnlyOOH"
        Me.cbOnlyOOH.Size = New System.Drawing.Size(125, 17)
        Me.cbOnlyOOH.TabIndex = 25
        Me.cbOnlyOOH.Text = "Watchdog only OOH"
        Me.cbOnlyOOH.UseVisualStyleBackColor = True
        '
        'cbSendHbSMS
        '
        Me.cbSendHbSMS.AutoSize = True
        Me.cbSendHbSMS.Location = New System.Drawing.Point(15, 209)
        Me.cbSendHbSMS.Name = "cbSendHbSMS"
        Me.cbSendHbSMS.Size = New System.Drawing.Size(125, 17)
        Me.cbSendHbSMS.TabIndex = 24
        Me.cbSendHbSMS.Text = "send Heartbeat-SMS"
        Me.cbSendHbSMS.UseVisualStyleBackColor = True
        '
        'lblForward
        '
        Me.lblForward.AutoSize = True
        Me.lblForward.Location = New System.Drawing.Point(79, 115)
        Me.lblForward.Name = "lblForward"
        Me.lblForward.Size = New System.Drawing.Size(31, 13)
        Me.lblForward.TabIndex = 20
        Me.lblForward.Text = "email"
        '
        'cbSendMailSMS
        '
        Me.cbSendMailSMS.AutoSize = True
        Me.cbSendMailSMS.Location = New System.Drawing.Point(15, 188)
        Me.cbSendMailSMS.Name = "cbSendMailSMS"
        Me.cbSendMailSMS.Size = New System.Drawing.Size(134, 17)
        Me.cbSendMailSMS.TabIndex = 23
        Me.cbSendMailSMS.Text = "send SMS on new mail"
        Me.cbSendMailSMS.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(12, 115)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Forward to: "
        '
        'lblComPortNr
        '
        Me.lblComPortNr.AutoSize = True
        Me.lblComPortNr.Location = New System.Drawing.Point(79, 52)
        Me.lblComPortNr.Name = "lblComPortNr"
        Me.lblComPortNr.Size = New System.Drawing.Size(35, 13)
        Me.lblComPortNr.TabIndex = 18
        Me.lblComPortNr.Text = "Com#"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(12, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Com-Port:"
        '
        'cbCopyTo
        '
        Me.cbCopyTo.AutoSize = True
        Me.cbCopyTo.Location = New System.Drawing.Point(15, 167)
        Me.cbCopyTo.Name = "cbCopyTo"
        Me.cbCopyTo.Size = New System.Drawing.Size(96, 17)
        Me.cbCopyTo.TabIndex = 20
        Me.cbCopyTo.Text = "send mail copy"
        Me.cbCopyTo.UseVisualStyleBackColor = True
        '
        'lblMailBox
        '
        Me.lblMailBox.AutoSize = True
        Me.lblMailBox.Location = New System.Drawing.Point(79, 73)
        Me.lblMailBox.Name = "lblMailBox"
        Me.lblMailBox.Size = New System.Drawing.Size(54, 13)
        Me.lblMailBox.TabIndex = 16
        Me.lblMailBox.Text = "lblMailBox"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(12, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Mailbox:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.lblInterval)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lblLastHb)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(181, 144)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(254, 65)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "HeartBeat"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(161, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 23)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Send HB"
        Me.Button1.UseVisualStyleBackColor = True
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
        Me.Label7.Location = New System.Drawing.Point(7, 21)
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
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(38, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Mailbox"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(314, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "COM-Port"
        '
        'tbComPortNr
        '
        Me.tbComPortNr.Location = New System.Drawing.Point(373, 41)
        Me.tbComPortNr.MaxLength = 2
        Me.tbComPortNr.Name = "tbComPortNr"
        Me.tbComPortNr.Size = New System.Drawing.Size(26, 20)
        Me.tbComPortNr.TabIndex = 15
        Me.tbComPortNr.Text = "4"
        '
        'cbbOMailBox
        '
        Me.cbbOMailBox.FormattingEnabled = True
        Me.cbbOMailBox.Location = New System.Drawing.Point(121, 68)
        Me.cbbOMailBox.Name = "cbbOMailBox"
        Me.cbbOMailBox.Size = New System.Drawing.Size(278, 21)
        Me.cbbOMailBox.TabIndex = 16
        '
        'cbAtCC
        '
        Me.cbAtCC.AutoSize = True
        Me.cbAtCC.Location = New System.Drawing.Point(405, 70)
        Me.cbAtCC.Name = "cbAtCC"
        Me.cbAtCC.Size = New System.Drawing.Size(88, 17)
        Me.cbAtCC.TabIndex = 18
        Me.cbAtCC.Text = "@Computa..."
        Me.cbAtCC.UseVisualStyleBackColor = True
        '
        'cbbCopyMailsTo
        '
        Me.cbbCopyMailsTo.FormattingEnabled = True
        Me.cbbCopyMailsTo.Location = New System.Drawing.Point(121, 95)
        Me.cbbCopyMailsTo.Name = "cbbCopyMailsTo"
        Me.cbbCopyMailsTo.Size = New System.Drawing.Size(278, 21)
        Me.cbbCopyMailsTo.TabIndex = 21
        '
        'rbUseManual
        '
        Me.rbUseManual.AutoCheck = False
        Me.rbUseManual.AutoSize = True
        Me.rbUseManual.Location = New System.Drawing.Point(20, 14)
        Me.rbUseManual.Name = "rbUseManual"
        Me.rbUseManual.Size = New System.Drawing.Size(118, 17)
        Me.rbUseManual.TabIndex = 22
        Me.rbUseManual.TabStop = True
        Me.rbUseManual.Text = "Use Manual Setting"
        Me.rbUseManual.UseVisualStyleBackColor = True
        '
        'rbUseDB
        '
        Me.rbUseDB.AutoCheck = False
        Me.rbUseDB.AutoSize = True
        Me.rbUseDB.Location = New System.Drawing.Point(20, 128)
        Me.rbUseDB.Name = "rbUseDB"
        Me.rbUseDB.Size = New System.Drawing.Size(132, 17)
        Me.rbUseDB.TabIndex = 23
        Me.rbUseDB.TabStop = True
        Me.rbUseDB.Text = "Use Database Setting "
        Me.rbUseDB.UseVisualStyleBackColor = True
        '
        'btPullData
        '
        Me.btPullData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btPullData.Location = New System.Drawing.Point(405, 128)
        Me.btPullData.Name = "btPullData"
        Me.btPullData.Size = New System.Drawing.Size(88, 23)
        Me.btPullData.TabIndex = 24
        Me.btPullData.Text = "Pull Data"
        Me.btPullData.UseVisualStyleBackColor = True
        '
        'btSetManually
        '
        Me.btSetManually.ForeColor = System.Drawing.Color.Maroon
        Me.btSetManually.Location = New System.Drawing.Point(405, 10)
        Me.btSetManually.Name = "btSetManually"
        Me.btSetManually.Size = New System.Drawing.Size(88, 25)
        Me.btSetManually.TabIndex = 25
        Me.btSetManually.Text = "Set manually"
        Me.btSetManually.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(38, 98)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "copy-to E-Mail"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "( for  email + mobile ONLY!)"
        '
        'lblRAM
        '
        Me.lblRAM.AutoSize = True
        Me.lblRAM.Location = New System.Drawing.Point(311, 209)
        Me.lblRAM.Name = "lblRAM"
        Me.lblRAM.Size = New System.Drawing.Size(61, 13)
        Me.lblRAM.TabIndex = 27
        Me.lblRAM.Text = "RAM count"
        '
        'MT_Watchdog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 645)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btSetManually)
        Me.Controls.Add(Me.btPullData)
        Me.Controls.Add(Me.rbUseDB)
        Me.Controls.Add(Me.rbUseManual)
        Me.Controls.Add(Me.cbAtCC)
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
        Me.Name = "MT_Watchdog"
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
    Friend WithEvents cbAtCC As CheckBox
    Friend WithEvents cbCopyTo As CheckBox
    Friend WithEvents cbbCopyMailsTo As ComboBox
    Friend WithEvents lblForward As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cbSendMailSMS As CheckBox
    Friend WithEvents cbSendHbSMS As CheckBox
    Friend WithEvents cbOnlyOOH As CheckBox
    Friend WithEvents lblDateInfo As Label
    Friend WithEvents rbUseManual As RadioButton
    Friend WithEvents rbUseDB As RadioButton
    Friend WithEvents btPullData As Button
    Friend WithEvents btSetManually As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lblRAM As Label
End Class
