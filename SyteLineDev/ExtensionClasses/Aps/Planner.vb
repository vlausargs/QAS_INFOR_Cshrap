Option Explicit On
Option Strict On

Imports ERDB.Server

Public Class PlannerInterface

    Public Shared Function iVBDate2OLDate(ByVal vdatDate As Date) As Integer

        Dim sOLDate As String
        Dim iYear As Integer
        Dim oERDB As New ERDB.Server

        iYear = Year(vdatDate)
        If iYear >= 2038 Or iYear < 1970 Then
            iVBDate2OLDate = 0
            Exit Function
        End If

        sOLDate = sVBDate2OLDateFormat(vdatDate)
        iVBDate2OLDate = oERDB.cata_timenum(sOLDate)

    End Function

    Public Shared Function datOLDateFormat2VBDate(ByVal vsOLDate As String) As Date

        Dim iYear As Integer
        Dim datDate As Date

        iYear = CInt(Mid$(vsOLDate, 1, 2))
        If iYear < 80 Then iYear = iYear + 2000

        datDate = DateSerial(iYear, CInt(Mid$(vsOLDate, 3, 2)), CInt(Mid$(vsOLDate, 5, 2)))
        datDate = datDate.AddHours(CInt(Mid$(vsOLDate, 8, 2)))
        datDate = datDate.AddMinutes(CInt(Mid$(vsOLDate, 10, 2)))
        datDate = datDate.AddSeconds(CInt(Mid$(vsOLDate, 12, 2)))

        datOLDateFormat2VBDate = datDate

    End Function

    Public Shared Function sVBDate2OLDateFormat(ByVal vdatDate As Date) As String
        sVBDate2OLDateFormat = Format$(vdatDate, "yyMMdd.HHmmss")
    End Function

    Public Shared Function datOLDate2VBDate(ByVal viDate As Integer) As Date

        Dim sbValue As String
        Dim oERDB As New ERDB.Server

        sbValue = ""
        oERDB.cata_numerictime(viDate, sbValue)
        datOLDate2VBDate = datOLDateFormat2VBDate(sbValue)

    End Function

End Class