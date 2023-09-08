
Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports CSI.Data.SQL.UDDT
Imports System
Imports System.Data
Imports CSI.DataCollection
Imports CSI.MG
Imports System.Runtime.InteropServices

<IDOExtensionClass("SLDcitems")> _
Public Class SLDcitems
    Inherits ExtensionClassBase
 

    <IDOMethod(MethodFlags.RequiresTransaction, "Infobar")> _
    Public Function DcmatlPVb(ByVal PPostDate As Nullable(Of DateTime), ByRef Infobar As String) As Integer
        '-----------------------------------------------------------------------
        ' Note that the Dcitems IDO is used by two DC modules:
        ' 1. CycleCounting (Transtype = 1)
        ' 2. MiscIssue/ReceiptAndQtyAdjust (Transtype = 2, 3, or 8)
        ' This function applies only to MiscIssue/ReceiptAndQtyAdjust.
        '-----------------------------------------------------------------------

        Dim oCollection As LoadCollectionResponseData
        Dim Filter As String
        Dim TransNum As Integer
        Dim ResponseData As New InvokeResponseData
        Dim iCanOverride As Integer
        Try
            DcmatlPVb = 0

            If IDONull.IsNull(PPostDate) Then
                PPostDate = DateTime.Now
            End If

            Filter = "CHARINDEX(Stat, 'UP') > 0 AND CHARINDEX(TransType, '238') > 0 AND TransNum > 0 "
            Filter = Filter & " And TransDate <= dbo.DayEndOf(" & SqlLiteral.Format(PPostDate) & ")"

            oCollection = Me.LoadCollection("TransNum", Filter, String.Empty, 0)
            For index As Integer = 0 To oCollection.Items.Count - 1
                TransNum = oCollection(index, "TransNum").GetValue(Of Integer)(-1)
                Try
                    ResponseData = Me.Invoke("DcmatlPSp", TransNum, iCanOverride, Infobar)
                    iCanOverride = CInt(ResponseData.Parameters(1).Value)
                    Infobar = ResponseData.Parameters(2).Value
                Catch ex As Exception
                    Infobar = MGException.ExtractMessages(ex)
                    iCanOverride = 1
                End Try

                If ResponseData.IsReturnValueStdError Or iCanOverride = 1 Then
                    ResponseData = Me.Invoke("DcitemLogErrorSp", TransNum, iCanOverride, Infobar)
                    If ResponseData.IsReturnValueStdError Then
                        Infobar = "UNKNOWN ERROR CALLING DcitemLogErrorSp"
                        DcmatlPVb = 16
                        oCollection = Nothing
                        ResponseData = Nothing
                        Exit Function
                    End If
                End If
            Next
        Catch ex As Exception
            Infobar = Infobar & ":" & MGException.ExtractMessages(ex)
            DcmatlPVb = 16
        End Try
        oCollection = Nothing
        ResponseData = Nothing
    End Function
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DccycPVb(ByVal PPostDate As Nullable(Of DateTime), ByRef Infobar As String) As Integer
        '-----------------------------------------------------------------------
        ' Note that the Dcitems IDO is used by two DC modules:
        ' 1. CycleCounting (Transtype = 1)
        ' 2. MiscIssue/ReceiptAndQtyAdjust (Transtype = 2, 3, or 8)
        ' This function applies only to CycleCounting.
        '-----------------------------------------------------------------------

        Dim oCollection As LoadCollectionResponseData
        Dim Filter As String
        Dim TransNum As Integer
        Dim ResponseData As New InvokeResponseData
        Dim iErrorFlag As Integer

        Try
            DccycPVb = 0
            iErrorFlag = 0

            If IDONull.IsNull(PPostDate) Then
                PPostDate = DateTime.Now
            End If

            Filter = "CHARINDEX(Stat, 'UP') > 0 AND CHARINDEX(TransType, '1') > 0 AND TransNum > 0 "
            Filter = Filter & " And TransDate <= dbo.DayEndOf(" & SqlLiteral.Format(PPostDate) & ")"

            oCollection = Me.LoadCollection("TransNum", Filter, String.Empty, 0)
            For index As Integer = 0 To oCollection.Items.Count - 1
                TransNum = oCollection(index, "TransNum").GetValue(Of Integer)(0)
                Try
                    ResponseData = Me.Invoke("DccycPSp", TransNum, Infobar)
                    Infobar = ResponseData.Parameters(1).Value
                Catch ex As Exception
                    Infobar = MGException.ExtractMessages(ex)
                    iErrorFlag = 1
                End Try
                If ResponseData.IsReturnValueStdError Or iErrorFlag = 1 Then
                    ResponseData = Me.Invoke("DcitemLogErrorSp", TransNum, 0, Infobar)
                    If ResponseData.IsReturnValueStdError Then
                        Infobar = "UNKNOWN ERROR CALLING DcitemLogErrorSp"
                        DccycPVb = 16
                        oCollection = Nothing
                        ResponseData = Nothing
                        Exit Function
                    End If
                End If
            Next
        Catch ex As Exception
            Infobar = Infobar & ":" & MGException.ExtractMessages(ex)
            DccycPVb = 16
        End Try
        oCollection = Nothing
        ResponseData = Nothing
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DccycDSp(ByVal Status As String, ByVal FromTransNum As Decimal?, ByVal ToTransNum As Decimal?, ByVal FromTransDate As DateTime?, ByVal ToTransDate As DateTime?, ByRef Infobar As String,
<[Optional]> ByVal StartingTransDateOffset As Short?,
<[Optional]> ByVal EndingTransDateOffset As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDccycDExt As IDccycD = New DccycDFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDccycDExt.DccycDSp(Status, FromTransNum, ToTransNum, FromTransDate, ToTransDate, Infobar, StartingTransDateOffset, EndingTransDateOffset)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcCycleAddLocPostSP(ByVal DCItemItem As String, ByVal DCItemWhse As String, ByVal DCItemLoc As String, ByRef DCItemLot As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcCycleAddLocPostExt As IDcCycleAddLocPost = New DcCycleAddLocPostFactory().Create(appDb)
            Dim oDCItemLot As LotType = DCItemLot
            Dim oInfobar As InfobarType = Infobar
            Dim Severity As Integer = iDcCycleAddLocPostExt.DcCycleAddLocPostSP(DCItemItem, DCItemWhse, DCItemLoc, oDCItemLot, oInfobar)
            DCItemLot = oDCItemLot
            Infobar = oInfobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcCycleSetDefaultLocSP(ByVal Item As String, ByVal Whse As String, ByVal DCLot As String, ByRef TLoc As String, ByRef TLot As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcCycleSetDefaultLocExt As IDcCycleSetDefaultLoc = New DcCycleSetDefaultLocFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, TLoc As String, TLot As String, Infobar As String) = iDcCycleSetDefaultLocExt.DcCycleSetDefaultLocSP(Item, Whse, DCLot, TLoc, TLot, Infobar)
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
            Dim appDb As CSI.MG.IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
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


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcmatlDSp(ByVal Status As String, ByVal TransType As String, ByVal FromTransNum As Decimal?, ByVal ToTransNum As Decimal?, ByVal FromTransDate As DateTime?, ByVal ToTransDate As DateTime?, ByRef Infobar As String,
<[Optional]> ByVal StartingTransDateOffset As Short?,
<[Optional]> ByVal EndingTransDateOffset As Short?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iDcmatlDExt As IDcmatlD = New DcmatlDFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcmatlDExt.DcmatlDSp(Status, TransType, FromTransNum, ToTransNum, FromTransDate, ToTransDate, Infobar, StartingTransDateOffset, EndingTransDateOffset)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcSyncQtySp(ByVal DCitemTransType As String, ByVal DCitemRepQty As Decimal?, ByVal DCitemCountQty As Decimal?, ByRef TcQttQtyOnHand As Decimal?, ByVal DCitemItem As String, ByVal DCitemUM As String, ByVal DcitemTransNum As Integer?, ByRef AskQuestion As Byte?, ByRef UpdtCountQtyFlag As Byte?, ByRef UpdtCountQty As Decimal?, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iDcSyncQtyExt As IDcSyncQty = New DcSyncQtyFactory().Create(appDb)

            Dim Severity As Integer = iDcSyncQtyExt.DcSyncQtySp(DCitemTransType, DCitemRepQty, DCitemCountQty, TcQttQtyOnHand, DCitemItem, DCitemUM, DcitemTransNum, AskQuestion, UpdtCountQtyFlag, UpdtCountQty, PromptMsg, PromptButtons, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SetQtyForInvAdjSP(
<[Optional]> ByVal Item As String,
<[Optional]> ByVal Whse As String,
<[Optional]> ByVal Loc As String,
<[Optional]> ByVal TransType As String, ByRef QtyOnHand As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iSetQtyForInvAdjExt As ISetQtyForInvAdj = New SetQtyForInvAdjFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, QtyOnHand As Decimal?) = iSetQtyForInvAdjExt.SetQtyForInvAdjSP(Item, Whse, Loc, TransType, QtyOnHand)
            Dim Severity As Integer = result.ReturnCode.Value
            QtyOnHand = result.QtyOnHand
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetumcfSp(ByVal OtherUM As String, ByVal Item As String, ByVal VendNum As String, ByVal Area As String, ByRef ConvFactor As Decimal?, ByRef Infobar As String,
<[Optional]> ByVal Site As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetumcfExt As IGetumcf = New GetumcfFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, ConvFactor As Decimal?, Infobar As String) = iGetumcfExt.GetumcfSp(OtherUM, Item, VendNum, Area, ConvFactor, Infobar, Site)
            Dim Severity As Integer = result.ReturnCode.Value
            ConvFactor = result.ConvFactor
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcACyccntSp(ByVal TTermId As String, ByVal TEmpNum As String, ByVal TTransDate As DateTime?, ByVal TItem As String, ByVal TLocation As String, ByVal TLot As String, ByVal TCurWhse As String, ByVal TQty As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcACyccntExt As IDcACyccnt = New DcACyccntFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcACyccntExt.DcACyccntSp(TTermId, TEmpNum, TTransDate, TItem, TLocation, TLot, TCurWhse, TQty, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcAMiscirSp(ByVal TTermId As String, ByVal pTransType As String, ByVal pEmpNum As String, ByVal TTransDate As DateTime?, ByVal pItem As String, ByVal pCurWhse As String, ByVal pLocation As String, ByVal pLot As String, ByVal pQty As Decimal?, ByVal pUm As String, ByVal pReasonCode As String, ByVal pDocumentNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcAMiscirExt As IDcAMiscir = New DcAMiscirFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDcAMiscirExt.DcAMiscirSp(TTermId, pTransType, pEmpNum, TTransDate, pItem, pCurWhse, pLocation, pLot, pQty, pUm, pReasonCode, pDocumentNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DccycPSp(ByVal PTransNum As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDccycPExt As IDccycP = New DccycPFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iDccycPExt.DccycPSp(PTransNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcitemLogErrorSp(ByVal PTransNum As Integer?, ByVal PCanOverride As Byte?, ByVal ErrorMsg As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcitemLogErrorExt As IDcitemLogError = New DcitemLogErrorFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iDcitemLogErrorExt.DcitemLogErrorSp(PTransNum, PCanOverride, ErrorMsg)
            Dim Severity As Integer = result.Value
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcmatlPSp(ByVal PTransNum As Integer?, ByRef PCanOverride As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcmatlPExt As IDcmatlP = New DcmatlPFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PCanOverride As Integer?, Infobar As String) = iDcmatlPExt.DcmatlPSp(PTransNum, PCanOverride, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PCanOverride = result.PCanOverride
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcMiscValidateEmpNumSp(ByVal Connected As Byte?, ByVal EmpNum As String, ByRef EmpName As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcMiscValidateEmpNumExt As IDcMiscValidateEmpNum = New DcMiscValidateEmpNumFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, EmpName As String, Infobar As String) = iDcMiscValidateEmpNumExt.DcMiscValidateEmpNumSp(Connected, EmpNum, EmpName, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            EmpName = result.EmpName
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DcMiscValidateLotSp(ByVal Connected As Byte?, ByVal TransType As Integer?, ByVal ItemQty As Integer?, ByVal Item As String, ByVal Location As String, ByVal Lot As String, ByVal CurWhse As String, ByRef PromptMsg As String, ByRef PromptButtons As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDcMiscValidateLotExt As IDcMiscValidateLot = New DcMiscValidateLotFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, PromptMsg As String, PromptButtons As String, Infobar As String) = iDcMiscValidateLotExt.DcMiscValidateLotSp(Connected, TransType, ItemQty, Item, Location, Lot, CurWhse, PromptMsg, PromptButtons, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            PromptMsg = result.PromptMsg
            PromptButtons = result.PromptButtons
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetDcparmAutopostEscFlagSp(ByVal AutoPostFieldName As String, ByRef AutoPostFlag As Integer?, ByRef EscFlag As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iGetDcparmAutopostEscFlagExt As IGetDcparmAutopostEscFlag = New GetDcparmAutopostEscFlagFactory().Create(appDb, MGInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, AutoPostFlag As Integer?, EscFlag As String, Infobar As String) = iGetDcparmAutopostEscFlagExt.GetDcparmAutopostEscFlagSp(AutoPostFieldName, AutoPostFlag, EscFlag, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            AutoPostFlag = result.AutoPostFlag
            EscFlag = result.EscFlag
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetInvparmAutoGenSp(ByVal AutoGenFieldName As String, ByRef AutoGenFlag As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetInvparmAutoGenExt As IGetInvparmAutoGen = New GetInvparmAutoGenFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, AutoGenFlag As Integer?, Infobar As String) = iGetInvparmAutoGenExt.GetInvparmAutoGenSp(AutoGenFieldName, AutoGenFlag, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            AutoGenFlag = result.AutoGenFlag
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class
