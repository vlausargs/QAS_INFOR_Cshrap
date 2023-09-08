Option Explicit On
Option Strict On

Imports System.Data.SqlClient

Imports Mongoose.IDO
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.DataAccess
Imports Mongoose.Core.Common
Imports CSI.Data.SQL.UDDT
Imports System
Imports System.Data
Imports Mongoose.IDO.Protocol
Imports CSI.DataCollection
Imports CSI.MG
Imports System.Runtime.InteropServices

<IDOExtensionClass("SLDcparms")> _
Public Class SLDcparms
    Inherits ExtensionClassBase

    Public ParmsTable As String = "dcparm"


    Public Function GetSystemParm(ByRef strParmValue As String, ByVal strParmName As String) As Integer

        Dim dr As IDataReader

        dr = Nothing

        Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
            Using cmd As IDbCommand = appDB.CreateCommand()
                cmd.CommandText = String.Format("SELECT [{0}] FROM [" & ParmsTable & "]", strParmName)
                cmd.CommandType = CommandType.Text

                Try
                    dr = cmd.ExecuteReader()
                Catch ex As Exception
                    Throw New MGException(ex.Message)
                End Try

                Using reader As New MGDataReader(dr)
                    If reader.Read() Then
                        strParmValue = TextUtil.FormatNormalizedString(reader.RawReader.GetValue(0))
                    Else
                        If dr IsNot Nothing AndAlso Not dr.IsClosed Then
                            dr.Close()
                        End If
                        MGException.Throw(Me.GetMessageProvider.GetMessage("E=NotOneExists", "@" & ParmsTable))
                    End If
                End Using
                If dr IsNot Nothing AndAlso Not dr.IsClosed Then
                    dr.Close()
                End If
            End Using
        End Using

        GetSystemParm = 0

    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcReValidateTransactionsSp(ByVal Receiving As String, ByVal Shipping As String, ByVal MiscIssue As String, ByVal Quantity As String, ByVal Job As String, ByVal Transfer As String, ByVal Time As String, ByVal Production As String, ByVal JIT As String, ByVal Work As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iDcReValidateTransactionsExt As IDcReValidateTransactions = New DcReValidateTransactionsFactory().Create(appDb)

            Dim oInfobar As InfobarType = Infobar

            Dim Severity As Integer = iDcReValidateTransactionsExt.DcReValidateTransactionsSp(Receiving, Shipping, MiscIssue, Quantity, Job, Transfer, Time, Production, JIT, Work, oInfobar)

            Infobar = oInfobar

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcBGTaskCheckSp(ByRef PostPoReceving As Integer?, ByRef PostCoShipping As Integer?, ByRef PostCycleCount As Integer?, ByRef PostMiscAjust As Integer?, ByRef PostMatlMove As Integer?, ByRef PostJobMaterial As Integer?, ByRef PostJobReceipt As Integer?, ByRef PostTransferShip As Integer?, ByRef PostTransferReceipt As Integer?, ByRef PostJob As Integer?, ByRef PostTimeAttendance As Integer?, ByRef PostProductionSchedule As Integer?, ByRef PostJIT As Integer?, ByRef PostWCMaterial As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcBGTaskCheckExt As IDcBGTaskCheck = New DcBGTaskCheckFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PostPoReceving As Integer?, PostCoShipping As Integer?, PostCycleCount As Integer?, PostMiscAjust As Integer?, PostMatlMove As Integer?, PostJobMaterial As Integer?, PostJobReceipt As Integer?, PostTransferShip As Integer?, PostTransferReceipt As Integer?, PostJob As Integer?, PostTimeAttendance As Integer?, PostProductionSchedule As Integer?, PostJIT As Integer?, PostWCMaterial As Integer?, Infobar As String) = iDcBGTaskCheckExt.DcBGTaskCheckSp(PostPoReceving, PostCoShipping, PostCycleCount, PostMiscAjust, PostMatlMove, PostJobMaterial, PostJobReceipt, PostTransferShip, PostTransferReceipt, PostJob, PostTimeAttendance, PostProductionSchedule, PostJIT, PostWCMaterial, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PostPoReceving = result.PostPoReceving
            PostCoShipping = result.PostCoShipping
            PostCycleCount = result.PostCycleCount
            PostMiscAjust = result.PostMiscAjust
            PostMatlMove = result.PostMatlMove
            PostJobMaterial = result.PostJobMaterial
            PostJobReceipt = result.PostJobReceipt
            PostTransferShip = result.PostTransferShip
            PostTransferReceipt = result.PostTransferReceipt
            PostJob = result.PostJob
            PostTimeAttendance = result.PostTimeAttendance
            PostProductionSchedule = result.PostProductionSchedule
            PostJIT = result.PostJIT
            PostWCMaterial = result.PostWCMaterial
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function




    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcCycleSetDefaultLocSP(ByVal Item As String, ByVal Whse As String, ByVal DCLot As String, ByRef TLoc As String, ByRef TLot As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcCycleSetDefaultLocExt As IDcCycleSetDefaultLoc = New DcCycleSetDefaultLocFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, TLoc As String, Tlot As String, Infobar As String) = iDcCycleSetDefaultLocExt.DcCycleSetDefaultLocSP(Item, Whse, DCLot, TLoc, TLot, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            TLoc = result.TLoc
            TLot = result.TLot
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcCycleValLocSP(ByVal DCItemItem As String, ByVal DCItemWhse As String, ByVal DCItemLoc As String, ByVal DCItemLot As String, ByRef ItemLocQuestionAsked As Integer?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcCycleValLocExt As IDcCycleValLoc = New DcCycleValLocFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ItemLocQuestionAsked As Integer?, PromptMsg As String, PromptButtons As String, Infobar As String) = iDcCycleValLocExt.DcCycleValLocSP(DCItemItem, DCItemWhse, DCItemLoc, DCItemLot, ItemLocQuestionAsked, PromptMsg, PromptButtons, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            ItemLocQuestionAsked = result.ItemLocQuestionAsked
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcCycleValLotSP(ByVal DCItemItem As String, ByVal DCItemWhse As String, ByVal DCItemLoc As String, ByVal DCItemLot As String,
<[Optional]> ByVal Title As String, ByRef AddLot As Byte?, ByRef PromptAddMsg As String, ByRef PromptAddButtons As String, ByRef PromptExpLotMsg As String, ByRef PromptExpLotButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcCycleValLotExt As IDcCycleValLot = New DcCycleValLotFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, AddLot As Byte?, PromptAddMsg As String, PromptAddButtons As String, PromptExpLotMsg As String, PromptExpLotButtons As String, Infobar As String) = iDcCycleValLotExt.DcCycleValLotSP(DCItemItem, DCItemWhse, DCItemLoc, DCItemLot, Title, AddLot, PromptAddMsg, PromptAddButtons, PromptExpLotMsg, PromptExpLotButtons, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            AddLot = result.AddLot
            PromptAddMsg = result.PromptAddMsg
            PromptAddButtons = result.PromptAddButtons
            PromptExpLotMsg = result.PromptExpLotMsg
            PromptExpLotButtons = result.PromptExpLotButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class
