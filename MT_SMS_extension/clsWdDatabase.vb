Option Explicit On

Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class clsWdDatabase
    ' "Arbeiterklasse" die die Datenbank darstellt

    Private Const sDBName As String = "mailtool"
    Private Const sServer As String = "dezntchrmuell02"

    Private rsConn As MySqlConnection = myMySQLConnection()
    Private sqlOnlineState As Boolean = True
    Private msg As String

    Public ReadOnly Property Message
        Get
            Return msg
        End Get
    End Property

    Public ReadOnly Property email
        Get
            Dim rs As MySqlDataReader
            Dim sQuery As String = String.Empty
            sQuery = "SELECT berEmail FROM " & sDBName & ".commondata Limit 1;"
            rs = dbQuery(sQuery)
            rs.Read()
            Return rs.GetString("berEmail")
        End Get
    End Property
    Public ReadOnly Property mobile
        Get
            Dim rs As MySqlDataReader
            Dim sQuery As String = String.Empty
            sQuery = "SELECT berMobile FROM " & sDBName & ".commondata Limit 1;"
            rs = dbQuery(sQuery)
            rs.Read()
            Return rs.GetString("berMobile")
        End Get
    End Property

    Private Function myMySQLConnection() As MySqlConnection
        'Connects to server and provides the mySQLConnection
        Dim newConn As New MySqlConnection

        Try
            With newConn
                'to connect to non-SSL Server
                .ConnectionString = String.Format("server={0}; user id={1}; password={2}; database={3}; pooling=false; SSLMode=none",
                                                    sServer, "mailtool", "mailtool", sDBName)
                .Open()
            End With
            sqlOnlineState = True
            Return newConn
        Catch ex As Exception
            msg = String.Format("myMySQLConnection failed:{0}{1}", vbCrLf, ex.Message)
            sqlOnlineState = False
            newConn = Nothing
            Return Nothing
        End Try
    End Function
    Public Function sqlOnline() As Boolean
        Dim res As Boolean = False
        If Not (rsConn Is Nothing) Then
            res = True
        Else
            Try
                rsConn = myMySQLConnection()
                If Not (rsConn Is Nothing) Then
                    res = True
                    msg = "SQL-Conn reestablished"
                Else
                    msg = "Could not reestablish SQL-conn"
                End If
            Catch ex As Exception
                msg = "Exception in reestablishment of SQL-Conn"
            End Try
        End If
        sqlOnlineState = res
        Return res
    End Function
    Public Function dbQuery(sQuery As String) As MySqlDataReader
        'generic DB query

        If sqlOnline Then
            Try
                Dim cmd As New MySqlCommand(sQuery, rsConn)
                dbQuery = cmd.ExecuteReader()
            Catch ex As Exception
                Debug.Print("Fehler in dbQuery: " & ex.Message)
                Debug.Print("Query used: " & sQuery)
                msg = ex.Message
                If Not (rsConn Is Nothing) Then rsConn.Close()
                sqlOnlineState = False
            End Try
        End If
    End Function

    Public Function KillTheDog() As Boolean
        Dim rs As MySqlDataReader
        Dim sQuery As String = String.Empty
        Dim res As Boolean = False
        Try
            sQuery = "SELECT killWatchdog FROM " & sDBName & ".commondata Limit 1;"
            rs = dbQuery(sQuery)
            rs.Read()
            res = (rs.GetBoolean("killWatchdog") <> 0)
            rs.Dispose()
            'If res Then
            '    sQuery = "update " & sDBName & ".commondata set killwatchdog='0' limit 1;"
            '    rs = dbQuery(sQuery)
            '    rs.Dispose()
            'End If

        Catch ex As Exception
            Debug.Print(String.Format("Exception in KillTheDog:{0}String:{1}{0}EX:{2}", vbCrLf, sQuery, ex.Message))
        End Try
        Return res
    End Function
    Public Function getBereitschaftsMA() As clsBerMA
        Dim berMA As New clsBerMA
        Dim rs As MySqlDataReader
        Dim sQuery As String = String.Empty
        sQuery = "SELECT * FROM " & sDBName & ".commondata Limit 1;"
        rs = dbQuery(sQuery)
        rs.Read()
        berMA.email = rs.GetString("berEmail")
        berMA.number = rs.GetString("berMobile")
        rs.Dispose()
        Return berMA
    End Function
End Class
