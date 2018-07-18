Imports System.IO.Ports
Public Class clsSmsModem

    'eine "Arbeiterklasse", die ein Modem darstellt


    Private WithEvents sp As SerialPort
    Private strBuffer As String = String.Empty
    Private Delegate Sub UpdateBufferDelegate(ByVal Text As String)
    Private working As Boolean
    Private MessageText As String

    'Public Property ServiceCenter As String = "+491722270333"
    Public Property telNr As String
    Public Property SmsText As String
    Public Property Port As String
    ReadOnly Property Message As String
        Get
            Return MessageText
        End Get
    End Property
    ReadOnly Property enabled As Boolean
        Get
            Return working
        End Get
    End Property
    Public Sub New(comPort As String)
        'erwartet den String "COMX" mit X als Portnummer als Parameter
        Dim result As Boolean
        Port = comPort
        Try
            sp = My.Computer.Ports.OpenSerialPort(Port)
            result = ComSendData("ATZ" & vbCr, "OK")
            ' set text-mode
            result = result And ComSendData("AT+CMGF=1" & vbCr, "OK")
            ' set SMS Center +491722270000, should be saved on SIM
            result = result And ComSendData("AT+CSCA=""+491722270333"",145" & vbCr, "OK")
            ' set data type
            result = result And ComSendData("AT+CSMP=17,167,0,0" & vbCr, "OK")
            sp.Close()
        Catch ex As System.Exception
            MessageText = "Modem init failed!"
            result = False
        End Try
        working = result
    End Sub
    Public Overloads Function sendSMS()
        SendSMS(telNr, SmsText)
    End Function

    Public Overloads Function SendSMS(ByVal [To] As String, ByVal Message As String) As Boolean
        Dim result As Boolean
        Try
            sp = My.Computer.Ports.OpenSerialPort(Port)
            result = ComSendData("ATZ" & vbCr, "OK")
            result = result And ComSendData("AT+CMGS=""" & [To] & """" & vbCr, ">")
            result = result And ComSendData(Message & vbCr, ">")
            result = result And ComSendData(Chr(26), "OK")
            sp.Close()
        Catch EX As System.Exception
            MessageText = "Send SMS Failed with Exception" & vbCrLf & EX.Message
            Return False
        End Try
        Return result
    End Function

    Public Function Porttest() As Boolean
        Try
            sp = My.Computer.Ports.OpenSerialPort(Port)
            sp.Close()
            MessageText = String.Format("Port {0} tested OK", {Port})
            Return True
        Catch ex As System.Exception
            MessageText = String.Format("Port {0} Failed{1}{2}", {Port, vbCrLf, ex.Message})
            working = False
            Return False
        End Try
    End Function

    ' Send data and wait for a specific response 
    Private Function ComSendData(ByVal Data As String, ByVal WaitFor As String) As Boolean
        Dim res As Boolean
        sp.Write(Data)
        res = WaitForData(WaitFor)
        Return res
    End Function

    Private Function WaitForData(ByVal Data As String, Optional ByVal Timeout As Integer = 10) As Boolean
        Dim StartTime As Date = Date.Now
        Do
            If InStr(strBuffer, Data) > 0 Then
                strBuffer = strBuffer.Substring((InStr(strBuffer, Data) - 1) + Data.Length)
                Return True
            End If
            If Date.Now.Subtract(StartTime).TotalSeconds >= Timeout Then
                Return False
            End If
        Loop
    End Function
    Private Sub sp_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs) Handles sp.DataReceived
        Dim dUpdateBuffer As New UpdateBufferDelegate(AddressOf UpdateBuffer)
        Dim strTmp As String = sp.ReadExisting
        dUpdateBuffer.Invoke(strTmp)
    End Sub
    Private Sub UpdateBuffer(ByVal Text As String)
        strBuffer &= Text
    End Sub
End Class
