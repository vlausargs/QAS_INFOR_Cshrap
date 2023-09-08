Public Class SLCmdLineParser
    Public Commands As Collection

    Public Sub New()
        Commands = New Collection()
    End Sub

    Public Sub Dispose()
        Commands = Nothing
    End Sub

    Public Sub ParseCommandLine(ByVal Cmd As String)
        Do
            Commands.Add(GetWord(Cmd))
        Loop While Len(Cmd) <> 0
    End Sub

    Private Function GetWord(ByRef Expresion As String) As String
        Dim chr As String
        Dim i As Integer
        Dim quoteFound As Boolean
        Dim rtn As String

        Expresion = Trim(Expresion)
        quoteFound = False
        rtn = ""

        For i = 1 To Len(Expresion)
            chr = Mid(Expresion, i, 1)

            If chr <> """" Then
                rtn = rtn & chr
            End If

            If chr = " " And Not quoteFound _
          Or Len(Expresion) < i + 1 Then
                Exit For
            ElseIf quoteFound Then
                If chr = """" Then
                    Exit For
                End If
            ElseIf chr = """" Then
                quoteFound = True
            End If
        Next i

        rtn = Trim(rtn)

        If (Len(Expresion) - i) > 0 Then
            Expresion = Right(Expresion, Len(Expresion) - i)
        Else
            Expresion = ""
        End If

        Return rtn
    End Function
End Class
