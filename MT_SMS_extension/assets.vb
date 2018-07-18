Option Explicit On
Imports Outlook = Microsoft.Office.Interop.Outlook

Module assets
    Public WithEvents olApp As Outlook.Application = CreateObject("Outlook.Application")

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

    'feiertagsberechnung nach BV-FUN

    Public Function IstFeiertag(Datum As Date) As String
        Dim Osterdatum As DateTime

        If Datum.Day = 1 And Datum.Month = 1 Then
            Return "Neujahr"
        ElseIf Datum.Day = 1 And Datum.Month = 5 Then
            Return "Maifeiertag"
        ElseIf Datum.Day = 3 And Datum.Month = 10 Then
            Return "Tag der Deutschen Einheit"
        ElseIf Datum.Day = 25 And Datum.Month = 12 Then
            Return "1. Weihnachtstag"
        ElseIf Datum.Day = 26 And Datum.Month = 12 Then
            Return "2. Weihnachtstag"
        Else
            Osterdatum = HolOsterdatum(Datum.Year)

            If (Osterdatum - Datum).Days = 2 Then
                Return "Karfreitag"
            ElseIf Datum = Osterdatum Then
                Return "Ostersonntag"
            ElseIf (Datum - Osterdatum).Days = 1 Then
                Return "Ostermontag"
            ElseIf (Datum - Osterdatum).Days = 39 Then
                Return "Christi Himmelfahrt"
            ElseIf (Datum - Osterdatum).Days = 49 Then
                Return "Pfingstsonntag"
            ElseIf (Datum - Osterdatum).Days = 50 Then
                Return "Pfingstmontag"
            End If
        End If
        Return String.Empty
    End Function

    Private Function HolOsterdatum(Jahr As Integer) As Date
        Dim a As Integer, b As Integer, c As Integer
        Dim d As Integer, e As Integer
        Dim Tag As Integer, Monat As Integer

        a = Jahr Mod 19
        b = Jahr Mod 4
        c = Jahr Mod 7
        d = (19 * a + 24) Mod 30
        e = (2 * b + 4 * c + 6 * d + 5) Mod 7

        Tag = 22 + d + e
        Monat = 3

        If Tag > 31 Then
            Tag = d + e - 9
            Monat = 4
        ElseIf Tag = 26 And Monat = 4 Then
            Tag = 19
        ElseIf Tag = 25 And Monat = 4 And d = 28 And e = 6 And a > 10 Then
            Tag = 18
        End If

        HolOsterdatum = DateSerial(Jahr, Monat, Tag)
    End Function

End Module
