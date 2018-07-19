Public Class clsBerMA
    Public Property name As String
    Public Property number As String
    Public Property email As String
    Public Sub New()
        name = String.Empty
        number = String.Empty
        email = String.Empty
    End Sub

    Public Function sameAs(M As clsBerMA) As Boolean
        Return (M.name = name) And (M.number = number) And (M.email = email)
    End Function
End Class
