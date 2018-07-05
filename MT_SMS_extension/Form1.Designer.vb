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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblInterval = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblLastHb = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblCurTime = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblMailBox = New System.Windows.Forms.Label()
        Me.tbOMailBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbOutput
        '
        Me.rtbOutput.Location = New System.Drawing.Point(31, 392)
        Me.rtbOutput.Name = "rtbOutput"
        Me.rtbOutput.Size = New System.Drawing.Size(361, 199)
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
        Me.rtbSmsText.Location = New System.Drawing.Point(9, 199)
        Me.rtbSmsText.Name = "rtbSmsText"
        Me.rtbSmsText.Size = New System.Drawing.Size(333, 39)
        Me.rtbSmsText.TabIndex = 2
        Me.rtbSmsText.Text = "SMS text"
        '
        'btSend
        '
        Me.btSend.Location = New System.Drawing.Point(410, 337)
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
        Me.Label2.Location = New System.Drawing.Point(30, 376)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Log"
        '
        'btChngNr
        '
        Me.btChngNr.Location = New System.Drawing.Point(327, 48)
        Me.btChngNr.Name = "btChngNr"
        Me.btChngNr.Size = New System.Drawing.Size(88, 25)
        Me.btChngNr.TabIndex = 7
        Me.btChngNr.Text = "Override Settings"
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
        Me.GroupBox1.Controls.Add(Me.lblMailBox)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.lblCurTime)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblCurNr)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.rtbSmsText)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 118)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(368, 244)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "actually using:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblInterval)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lblLastHb)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 128)
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
        Me.Button1.Location = New System.Drawing.Point(410, 127)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 29)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "pull mobile Nr"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Mailbox:"
        '
        'lblMailBox
        '
        Me.lblMailBox.AutoSize = True
        Me.lblMailBox.Location = New System.Drawing.Point(11, 94)
        Me.lblMailBox.Name = "lblMailBox"
        Me.lblMailBox.Size = New System.Drawing.Size(54, 13)
        Me.lblMailBox.TabIndex = 16
        Me.lblMailBox.Text = "lblMailBox"
        '
        'tbOMailBox
        '
        Me.tbOMailBox.Location = New System.Drawing.Point(28, 76)
        Me.tbOMailBox.Name = "tbOMailBox"
        Me.tbOMailBox.Size = New System.Drawing.Size(274, 20)
        Me.tbOMailBox.TabIndex = 12
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 603)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbOMailBox)
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
    Friend WithEvents tbOMailBox As TextBox
    Friend WithEvents Label8 As Label
End Class
