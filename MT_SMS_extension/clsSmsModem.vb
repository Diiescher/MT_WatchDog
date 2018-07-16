Imports System.IO.Ports
Public Class clsSmsModem

    Private WithEvents sp As SerialPort

    Public Property ServiceCenter As String
    Public Property telNr As String
    Public Property Message As String


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
End Class
