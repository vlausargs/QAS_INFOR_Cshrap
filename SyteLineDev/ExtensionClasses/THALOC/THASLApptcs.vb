Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.Core.Common

<IDOExtensionClass("THASLApptcs")> _
Public Class THASLApptcs
    Inherits ExtensionClassBase

    'Sub New()
    '    Me.ParmsTable = "apparms"
    'End Sub

    <IDOMethod(MethodFlags.None, "Infobar")> _
    Public Function THAAp01RIDoPostVB( _
        ByVal PSessionID As String, _
        ByVal PUserID As Decimal, _
        ByVal PStartingVendNum As String, _
        ByVal PEndingVendNum As String, _
        ByVal PStartingVendName As String, _
        ByVal PEndingVendName As String, _
        ByVal PSortNameNum As String, _
        ByVal PPayType As String, _
        ByVal PRegNeeded As String, _
        ByRef Infobar As String, _
        ByVal PPayDateStarting As String, _
        ByVal PPayDateEnding As String) As Integer

        Dim invokeResponse As InvokeResponseData

        Dim str_filter As String
        If InStr("NameNumber", PSortNameNum) = 0 Then
            PSortNameNum = "Number"
        End If

        'Build the filter
        str_filter = "dbo.THAInValidApptcStagingRecords('" & PSessionID _
                                                    & "',RowPointer" _
                                                    & ",'" & Replace(PStartingVendNum, "'", "''") _
                                                    & "','" & Replace(PEndingVendNum, "'", "''") _
                                                    & "','" & Replace(PStartingVendName, "'", "''") _
                                                    & "','" & Replace(PEndingVendName, "'", "''") _
                                                    & "','" & PSortNameNum _
                                                    & "','" & PPayDateStarting _
                                                    & "','" & PPayDateEnding _
                                                    & "') = 1"

        If PSortNameNum = "Number" Then
            str_filter = str_filter & " ORDER BY BankCode, CheckNum"
        Else
            str_filter = str_filter & " ORDER BY VadName, BankCode, CheckNum"
        End If

        invokeResponse = Me.Invoke("LockAPDistJournalAndCheckPrinting", PUserID, Infobar)
        If invokeResponse.IsReturnValueStdError Then
            Infobar = invokeResponse.Parameters(1).Value
            UnlockAPDistJournalAndCheckPrinting(PUserID)
            Return 16
        End If

        Try 'make sure we unlock APDistJournalAndCheckPrinting if an exception is thrown 
            Dim loadResponse As LoadCollectionResponseData
            loadResponse = Me.LoadCollection("RowPointer", str_filter, "", 0)
            '/* Check for appmts within the range */
            If loadResponse.Items.Count = 0 And PRegNeeded <> "1" Then
                Infobar = Me.GetMessageProvider().GetMessage("W=NoneSelected", "@!" & PPayType)
                Throw New MGException(Infobar)
            End If

            Dim int_numBad As Integer = 0
            Dim int_numGood As Integer = 0

            For i As Integer = 0 To loadResponse.Items.Count - 1
                invokeResponse = Me.Invoke("THAApptcOneSp", PSessionID, loadResponse(i, "RowPointer").Value, PPayType, Infobar)
                If invokeResponse.IsReturnValueStdError Then
                    Infobar = invokeResponse.Parameters(3).Value
                    int_numBad = int_numBad + 1

                    invokeResponse = Me.Invoke("THAMessageToAppmtToPrintPostSp", PSessionID, loadResponse(i, "RowPointer").Value, Infobar, Infobar)
                    If invokeResponse.IsReturnValueStdError Then
                        Infobar = invokeResponse.Parameters(3).Value
                        Throw New MGException(Infobar)
                    End If

                    invokeResponse = Me.Invoke("THAApPmtpVoidOneSp", PSessionID, loadResponse(i, "RowPointer").Value, PPayType, Infobar)
                    If invokeResponse.ReturnValue <> "0" Then
                        Infobar = invokeResponse.Parameters(3).Value
                        Throw New MGException(Infobar)
                    End If
                Else
                    int_numGood = int_numGood + 1
                End If
            Next

            If int_numBad > 0 Then
                If int_numGood > 0 Then
                    Infobar = Me.GetMessageProvider().GetMessage("W=PartDist", "@aptrx")
                Else
                    Infobar = Me.GetMessageProvider().GetMessage("E=CmdFailed", "@%post")
                End If
                Infobar = Me.GetMessageProvider().AppendMessage(Infobar, "I=#Invalid", CStr(int_numBad), "@appmt")
            Else
                Infobar = Me.GetMessageProvider().GetMessage("I=CmdSucceeded", "@appmt")
            End If
            Infobar = Me.GetMessageProvider().AppendMessage(Infobar, "I=#Post", int_numGood, "@appmt")
        Catch ex As Exception
            Infobar = ex.Message
            UnlockAPDistJournalAndCheckPrinting(PUserID)
            Return 16
        End Try

        UnlockAPDistJournalAndCheckPrinting(PUserID)

        Return 0

    End Function

    Function UnlockAPDistJournalAndCheckPrinting(ByVal PUserID As Decimal) As Integer
        Dim invokeResponse As InvokeResponseData
        '/* UNLOCK JOURNAL and Check Printing */
        invokeResponse = Me.Context.Commands.Invoke("SL.SLParms", "JourlockSp", "AP Dist", PUserID, 0, "")
        invokeResponse = Me.Context.Commands.Invoke("SL.SLParms", "LasttranSp", 12, PUserID, 0, 0, "")
    End Function

    <IDOMethod(MethodFlags.RequiresTransaction, "Infobar")> _
    Public Function LockAPDistJournalAndCheckPrinting(ByVal PUserID As Decimal, ByRef Infobar As String) As Integer
        Dim invokeResponse As InvokeResponseData
        Dim int_success As Integer


        '/* LOCK JOURNAL and LASTTRAN */
        invokeResponse = Me.Context.Commands.Invoke("SL.SLParms", "JourlockSp", "AP Dist", PUserID, 1, Infobar)

        If invokeResponse.ReturnValue <> "0" Then
            Infobar = invokeResponse.Parameters(3).Value
            Return 16
        End If

        'Lock Check Printing
        invokeResponse = Me.Context.Commands.Invoke("SL.SLParms", "LasttranSp", 12, PUserID, 1, int_success, Infobar)
        If invokeResponse.ReturnValue <> "0" Or invokeResponse.Parameters(3).Value <> "1" Then
            Infobar = invokeResponse.Parameters(4).Value
            Return 16
        End If

        Return 0
    End Function
End Class