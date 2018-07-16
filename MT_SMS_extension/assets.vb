Option Explicit On

Module assets







    'feiertagsberechnung von BV-FUN

    Public Function IstFeiertag(Datum As Date) As String
        Dim Osterdatum As DateTime

        If Datum.Day = 1 And Datum.Month = 1 Then
            IstFeiertag = "Neujahr"
        ElseIf Datum.Day = 1 And Datum.Month = 5 Then
            IstFeiertag = "Maifeiertag"
        ElseIf Datum.Day = 3 And Datum.Month = 10 Then
            IstFeiertag = "Tag der Deutschen Einheit"
        ElseIf Datum.Day = 25 And Datum.Month = 12 Then
            IstFeiertag = "1. Weihnachtstag"
        ElseIf Datum.Day = 26 And Datum.Month = 12 Then
            IstFeiertag = "2. Weihnachtstag"
        Else
            Osterdatum = HolOsterdatum(Datum.Year)

            If (Osterdatum - Datum).Days = 2 Then
                IstFeiertag = "Karfreitag"
            ElseIf Datum = Osterdatum Then
                IstFeiertag = "Ostersonntag"
            ElseIf (Datum - Osterdatum).Days = 1 Then
                IstFeiertag = "Ostermontag"
            ElseIf (Datum - Osterdatum).Days = 39 Then
                IstFeiertag = "Christi Himmelfahrt"
            ElseIf (Datum - Osterdatum).Days = 49 Then
                IstFeiertag = "Pfingstsonntag"
            ElseIf (Datum - Osterdatum).Days = 50 Then
                IstFeiertag = "Pfingstmontag"
            End If
        End If
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
