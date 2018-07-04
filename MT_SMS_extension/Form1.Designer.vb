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
        Me.cbActive = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btChngNr = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCurNr = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblLastHb = New System.Windows.Forms.Label()
        Me.lblCurTime = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblInterval = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbOutput
        '
        Me.rtbOutput.Location = New System.Drawing.Point(31, 346)
        Me.rtbOutput.Name = "rtbOutput"
        Me.rtbOutput.Size = New System.Drawing.Size(331, 199)
        Me.rtbOutput.TabIndex = 0
        Me.rtbOutput.Text = ""
        '
        'tbMobNr
        '
        Me.tbMobNr.Location = New System.Drawing.Point(31, 65)
        Me.tbMobNr.Name = "tbMobNr"
        Me.tbMobNr.Size = New System.Drawing.Size(278, 20)
        Me.tbMobNr.TabIndex = 1
        Me.tbMobNr.Text = "+491729278903"
        '
        'rtbSmsText
        '
        Me.rtbSmsText.Location = New System.Drawing.Point(14, 174)
        Me.rtbSmsText.Name = "rtbSmsText"
        Me.rtbSmsText.Size = New System.Drawing.Size(277, 48)
        Me.rtbSmsText.TabIndex = 2
        Me.rtbSmsText.Text = "SMS text"
        '
        'btSend
        '
        Me.btSend.Location = New System.Drawing.Point(341, 302)
        Me.btSend.Name = "btSend"
        Me.btSend.Size = New System.Drawing.Size(68, 25)
        Me.btSend.TabIndex = 3
        Me.btSend.Text = "test SMS"
        Me.btSend.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "new mobile number"
        '
        'cbActive
        '
        Me.cbActive.AutoSize = True
        Me.cbActive.Location = New System.Drawing.Point(189, 21)
        Me.cbActive.Name = "cbActive"
        Me.cbActive.Size = New System.Drawing.Size(94, 17)
        Me.cbActive.TabIndex = 5
        Me.cbActive.Text = "Service active"
        Me.cbActive.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 330)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Log"
        '
        'btChngNr
        '
        Me.btChngNr.Location = New System.Drawing.Point(341, 60)
        Me.btChngNr.Name = "btChngNr"
        Me.btChngNr.Size = New System.Drawing.Size(68, 25)
        Me.btChngNr.TabIndex = 7
        Me.btChngNr.Text = "Change Nr"
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
        Me.lblCurNr.Location = New System.Drawing.Point(122, 25)
        Me.lblCurNr.Name = "lblCurNr"
        Me.lblCurNr.Size = New System.Drawing.Size(14, 13)
        Me.lblCurNr.TabIndex = 9
        Me.lblCurNr.Text = "#"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.lblCurTime)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblCurNr)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.rtbSmsText)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(313, 235)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
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
        'lblCurTime
        '
        Me.lblCurTime.AutoSize = True
        Me.lblCurTime.Location = New System.Drawing.Point(97, 48)
        Me.lblCurTime.Name = "lblCurTime"
        Me.lblCurTime.Size = New System.Drawing.Size(45, 13)
        Me.lblCurTime.TabIndex = 12
        Me.lblCurTime.Text = "curTime"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "current time: "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblInterval)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lblLastHb)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 92)
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 576)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btChngNr)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbActive)
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
    Friend WithEvents cbActive As CheckBox
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
End Class
