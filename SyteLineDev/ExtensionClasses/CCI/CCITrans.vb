Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports Mongoose.Core.Configuration
Imports System.Data.SqlClient
Imports Mongoose.Scripting
Imports CSI.Data.SQL.UDDT
Imports System
Imports System.Data
Imports CSI.MG
Imports System.Runtime.InteropServices


Imports System.Web.HttpUtility

'Imports System.Data.SqlTypes
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports CSI.Finance.CreditCard
Imports CSI.Data.CreditCard
Imports CSI.ExternalContracts.Portals

<IDOExtensionClass("CCITrans")>
Public Class CCITrans
    Inherits CSIExtensionClassBase
    Implements IIDOExtensionClass
    Implements ICCITrans

    <IDOMethod(MethodFlags.None)>
    Public Function CCIWebPaySiteVerifySp(ByVal GatewayEncryptionKey As String, ByVal GatewayAPIKey As String _
                                         , ByVal Email As String, ByVal TotalAmt As Decimal? _
                                         , ByVal Type As String, ByVal CustNum As String _
                                          , ByRef VerifyingPost As String, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim CCIUtil = New CreditCardUtilFactory().Create(appDb)
            Return CCIUtil.WebPaySiteVerify(GatewayEncryptionKey, GatewayAPIKey, Email, TotalAmt, Type, CustNum, VerifyingPost, Infobar)
        End Using

    End Function



    <IDOMethod(MethodFlags.None)>
    Public Function CCIWebSessionCenPOSSp(ByVal GatewayVendId As String, ByVal GatewayEncryptionKey As String _
                                          , ByRef SessionData As String, ByRef SessionDataPost As String _
                                          , ByRef sInfobar As String, ByRef iSuccess As Byte) As Integer Implements ICCITrans.CCIWebSessionCenPOSSp
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim CCIUtil = New CreditCardUtilFactory().Create(appDb)
            Return CCIUtil.CCIWebSession(GatewayVendId, GatewayEncryptionKey, SessionData, SessionDataPost, sInfobar, iSuccess)
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CCIGetLevel3StringWrapSp(ByVal CardSystem As String, ByVal InvNum As String, ByVal TotalAmt As Decimal?, ByVal CustRef As String, ByRef Level3Data As String, ByRef Infobar As String) As Integer
        Dim iCCIGetLevel3StringWrapExt = New CCIGetLevel3StringWrapFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, Level3Data As String, Infobar As String) = iCCIGetLevel3StringWrapExt.CCIGetLevel3StringWrapSp(CardSystem, InvNum, TotalAmt, CustRef, Level3Data, Infobar)
        Level3Data = result.Level3Data
        Infobar = result.Infobar
        Return result.ReturnCode.Value
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSCCIShipAuthUtilSp(ByVal StartOrderNum As String, ByVal EndOrderNum As String, ByVal StartShipDate As DateTime?, ByVal EndShipDate As DateTime?, ByVal StartShipDateOffset As Short?, ByVal EndShipDateOffset As Short?, ByVal StartShipVia As String, ByVal EndShipVia As String, ByVal GenerateReport As String, ByRef Infobar As String,
<[Optional]> ByVal TaskId As Decimal?,
<[Optional]> ByVal pSite As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSCCIShipAuthUtilExt = New SSSCCIShipAuthUtilFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iSSSCCIShipAuthUtilExt.SSSCCIShipAuthUtilSp(StartOrderNum, EndOrderNum, StartShipDate, EndShipDate, StartShipDateOffset, EndShipDateOffset, StartShipVia, EndShipVia, GenerateReport, Infobar, TaskId, pSite)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Portal_CCICalcBal_1_ForOrderCurrSp(ByVal CustNum As String, ByVal CardSystemId As String, ByVal RefType As String, ByVal RefNum As String, ByVal OrderAmt As Decimal?, ByVal OrderExchRate As Decimal?, ByRef Balance As Decimal?, ByRef PayExchRate As Decimal?, ByRef BankAmt As Decimal?, ByRef BankExchRate As Decimal?, ByRef Infobar As String) As Integer Implements ICCITrans.Portal_CCICalcBal_1_ForOrderCurrSp
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortal_CCICalcBal_1_ForOrderCurrExt As IPortal_CCICalcBal_1_ForOrderCurr = New Portal_CCICalcBal_1_ForOrderCurrFactory().Create(appDb)

            Dim Severity As Integer = iPortal_CCICalcBal_1_ForOrderCurrExt.Portal_CCICalcBal_1_ForOrderCurrSp(CustNum, CardSystemId, RefType, RefNum, OrderAmt, OrderExchRate, Balance, PayExchRate, BankAmt, BankExchRate, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Portal_CCIDefaultCardSystemID_1_ForOrderCurrSp(ByVal CustNum As String, ByVal RefType As String, ByVal RefNum As String, ByRef CardSystemId As String) As Integer Implements ICCITrans.Portal_CCIDefaultCardSystemID_1_ForOrderCurrSp
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortal_CCIDefaultCardSystemID_1_ForOrderCurrExt As IPortal_CCIDefaultCardSystemID_1_ForOrderCurr = New Portal_CCIDefaultCardSystemID_1_ForOrderCurrFactory().Create(appDb)

            Dim Severity As Integer = iPortal_CCIDefaultCardSystemID_1_ForOrderCurrExt.Portal_CCIDefaultCardSystemID_1_ForOrderCurrSp(CustNum, RefType, RefNum, CardSystemId)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Portal_CCILogCardSp(ByVal CardNum As String, ByVal CardSystem As String, ByVal CustNum As String, ByVal CustSeq As Integer?, ByVal expDate As String, ByVal NameOnCard As String, ByVal GatewayTransNum As Decimal?, ByVal CardType As String,
<[Optional]> ByVal Username As String, ByVal CardSystemId As String) As Integer Implements ICCITrans.Portal_CCILogCardSp
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iPortal_CCILogCardExt = New Portal_CCILogCardFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As Integer? = iPortal_CCILogCardExt.Portal_CCILogCardSp(CardNum, CardSystem, CustNum, CustSeq, expDate, NameOnCard, GatewayTransNum, CardType, Username, CardSystemId)
            Return result.Value
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Portal_SSSCCIARPayFromTransSp(ByVal CCIRowPointer As Guid?, ByRef Infobar As String) As Integer Implements ICCITrans.Portal_SSSCCIARPayFromTransSp
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortal_SSSCCIARPayFromTransExt As IPortal_SSSCCIARPayFromTrans = New Portal_SSSCCIARPayFromTransFactory().Create(Me, True)

            Dim Severity = iPortal_SSSCCIARPayFromTransExt.Portal_SSSCCIARPayFromTransSp(CCIRowPointer, Infobar)

            Return Severity.ReturnCode

        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Portal_SSSCCICoBalSp(ByVal CoNum As String, ByRef Balance As Decimal?, ByRef TaxAmt As Decimal?, ByRef ExchRate As Decimal?, ByRef ForAmt As Decimal?, ByRef CustSeq As Integer?, ByRef Infobar As String,
<[Optional]> ByVal AuthType As String,
<[Optional]> ByVal ShipMethod As String) As Integer Implements ICCITrans.Portal_SSSCCICoBalSp
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iPortal_SSSCCICoBalExt = New Portal_SSSCCICoBalFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Balance As Decimal?, TaxAmt As Decimal?, ExchRate As Decimal?, ForAmt As Decimal?, CustSeq As Integer?, Infobar As String) = iPortal_SSSCCICoBalExt.Portal_SSSCCICoBalSp(CoNum, Balance, TaxAmt, ExchRate, ForAmt, CustSeq, Infobar, AuthType, ShipMethod)
            Dim Severity As Integer = result.ReturnCode.Value
            Balance = result.Balance
            TaxAmt = result.TaxAmt
            ExchRate = result.ExchRate
            ForAmt = result.ForAmt
            CustSeq = result.CustSeq
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Portal_SSSCCIProcessCardWrapSp(ByVal TransType As String, ByVal cardNum As String, ByVal expDate As String, ByVal NameOnCard As String, ByVal StreetAddress As String, ByVal City As String, ByVal State As String, ByVal Zip As String, ByVal CVNum As String, ByVal CustNum As String, ByVal CustSeq As Integer?, ByVal RefType As String, ByVal OrdInvNum As String, ByVal ForAmt As Decimal?, ByVal ExchRate As Decimal?, ByVal TotalAmt As Decimal?, ByVal TaxAmt As Decimal?, ByRef cardType As String, ByRef authCode As String, ByRef GatewayTransNum As Decimal?, ByRef Infobar As String, ByRef iSuccess As Byte?, ByVal AutoPostOpenPayment As Byte?, ByVal StoreCard As Byte?, ByVal CustRef As String,
<[Optional]> ByVal Username As String, ByVal CardSystemId As String, ByVal DomAmt As Decimal?, ByVal PayExchRate As Decimal?,
<[Optional]> ByVal Signature As Byte()) As Integer Implements ICCITrans.Portal_SSSCCIProcessCardWrapSp
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iPortal_SSSCCIProcessCardWrapExt = New Portal_SSSCCIProcessCardWrapFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, cardType As String, authCode As String, GatewayTransNum As Decimal?, Infobar As String, iSuccess As Byte?) = iPortal_SSSCCIProcessCardWrapExt.Portal_SSSCCIProcessCardWrapSp(TransType, cardNum, expDate, NameOnCard, StreetAddress, City, State, Zip, CVNum, CustNum, CustSeq, RefType, OrdInvNum, ForAmt, ExchRate, TotalAmt, TaxAmt, cardType, authCode, GatewayTransNum, Infobar, iSuccess, AutoPostOpenPayment, StoreCard, CustRef, Username, CardSystemId, DomAmt, PayExchRate, Signature)
            Dim Severity As Integer = result.ReturnCode.Value
            cardType = result.cardType
            authCode = result.authCode
            GatewayTransNum = result.GatewayTransNum
            Infobar = result.Infobar
            iSuccess = result.iSuccess
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSCCIArInvBalSp(ByVal InvNum As String, ByVal CustNum As String, ByRef TransType As String, ByRef Balance As Decimal?, ByRef TaxAmt As Decimal?, ByRef ExchRate As Decimal?, ByRef ForAmt As Decimal?, ByRef CustSeq As Integer?, ByRef Infobar As String) As Integer Implements ICCITrans.SSSCCIArInvBalSp
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iSSSCCIArInvBalExt As ISSSCCIArInvBal = New SSSCCIArInvBalFactory().Create(appDb)

            Dim Severity As Integer = iSSSCCIArInvBalExt.SSSCCIArInvBalSp(InvNum, CustNum, TransType, Balance, TaxAmt, ExchRate, ForAmt, CustSeq, Infobar)

            Return Severity
        End Using
    End Function
    Public Function SSSCCICoBalSp(ByVal CoNum As String, ByRef Balance As Decimal?, ByRef TaxAmt As Decimal?, ByRef ExchRate As Decimal?, ByRef ForAmt As Decimal?, ByRef CustSeq As Integer?, ByRef Infobar As String,
<[Optional]> ByVal AuthType As String,
<[Optional]> ByVal ShipMethod As String) As Integer Implements ICCITrans.SSSCCICoBalSp
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSCCICoBalExt = New SSSCCICoBalFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Balance As Decimal?, TaxAmt As Decimal?, ExchRate As Decimal?, ForAmt As Decimal?, CustSeq As Integer?, Infobar As String) = iSSSCCICoBalExt.SSSCCICoBalSp(CoNum, Balance, TaxAmt, ExchRate, ForAmt, CustSeq, Infobar, AuthType, ShipMethod)
            Dim Severity As Integer = result.ReturnCode.Value
            Balance = result.Balance
            TaxAmt = result.TaxAmt
            ExchRate = result.ExchRate
            ForAmt = result.ForAmt
            CustSeq = result.CustSeq
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSCCIPayOpenNextSp(ByRef NextOpenNum As Integer?) As Integer Implements ICCITrans.SSSCCIPayOpenNextSp
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iSSSCCIPayOpenNextExt As ISSSCCIPayOpenNext = New SSSCCIPayOpenNextFactory().Create(appDb)

            Dim Severity As Integer = iSSSCCIPayOpenNextExt.SSSCCIPayOpenNextSp(NextOpenNum)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CCICalcBalSp(ByVal CustNum As String, ByVal CardSystemId As String, ByVal RefType As String, ByVal RefNum As String, ByVal OrderAmt As Decimal?, ByVal OrderExchRate As Decimal?, ByRef Balance As Decimal?, ByRef PayExchRate As Decimal?, ByRef BankAmt As Decimal?, ByRef BankExchRate As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCCICalcBalExt As ICCICalcBal = New CCICalcBalFactory().Create(appDb)

            Dim Severity As Integer = iCCICalcBalExt.CCICalcBalSp(CustNum, CardSystemId, RefType, RefNum, OrderAmt, OrderExchRate, Balance, PayExchRate, BankAmt, BankExchRate, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CCICentralOrderEntryReplicateSp(ByVal CCIRowPointer As Guid?, ByVal CoNum As String, ByVal ToSite As String, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCCICentralOrderEntryReplicateExt = New CCICentralOrderEntryReplicateFactory().Create(appDb)

            Dim Severity As Integer = iCCICentralOrderEntryReplicateExt.CCICentralOrderEntryReplicateSp(CCIRowPointer, CoNum, ToSite, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CCIDefaultCardSystemIDSp(ByVal CustNum As String, ByVal RefType As String, ByVal RefNum As String, ByRef CardSystemId As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCCIDefaultCardSystemIDExt = New CCIDefaultCardSystemIDFactory().Create(appDb)

            Dim Severity As Integer = iCCIDefaultCardSystemIDExt.CCIDefaultCardSystemIDSp(CustNum, RefType, RefNum, CardSystemId)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CCIGetTransInfoSp(ByVal CardSystemId As String, ByVal CardSystem As String, ByVal CustNum As String, ByVal CustSeq As Integer?, ByVal RefType As String, ByVal TransType As String, ByVal OrdInvNum As String, ByRef GatewayStoredToken As String, ByRef GatewayTransNum As Decimal?, ByRef CardLast4Digits As String, ByRef Infobar As String) As Integer
        Dim iCCIGetTransInfoExt = New CCIGetTransInfoFactory().Create(Me, True)
        Dim result As (ReturnCode As Integer?, GatewayStoredToken As String, GatewayTransNum As Decimal?, CardLast4Digits As String, Infobar As String) = iCCIGetTransInfoExt.CCIGetTransInfoSp(CardSystemId, CardSystem, CustNum, CustSeq, RefType, TransType, OrdInvNum, GatewayStoredToken, GatewayTransNum, CardLast4Digits, Infobar)
        Dim Severity As Integer = result.ReturnCode.Value
        GatewayStoredToken = result.GatewayStoredToken
        GatewayTransNum = result.GatewayTransNum
        CardLast4Digits = result.CardLast4Digits
        Infobar = result.Infobar
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CCITotalAmtChangedSp(ByVal CustNum As String, ByVal CardSystemId As String, ByVal TotalAmt As Decimal?, ByRef DomAmt As Decimal?, ByRef ForAmt As Decimal?, ByRef ExchRate As Decimal?, ByRef PayExchRate As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCCITotalAmtChangedExt = New CCITotalAmtChangedFactory().Create(appDb)

            Dim Severity As Integer = iCCITotalAmtChangedExt.CCITotalAmtChangedSp(CustNum, CardSystemId, TotalAmt, DomAmt, ForAmt, ExchRate, PayExchRate, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Portal_CCICalcBalSp(ByVal CustNum As String, ByVal CardSystemId As String, ByVal ForAmt As Decimal?, ByRef Balance As Decimal?, ByRef PayExchRate As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortal_CCICalcBalExt = New Portal_CCICalcBalFactory().Create(appDb)

            Dim Severity As Integer = iPortal_CCICalcBalExt.Portal_CCICalcBalSp(CustNum, CardSystemId, ForAmt, Balance, PayExchRate, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Portal_CCIDefaultCardSystemIDSp(ByVal CustNum As String, ByRef CardSystemId As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortal_CCIDefaultCardSystemIDExt = New Portal_CCIDefaultCardSystemIDFactory().Create(appDb)

            Dim Severity As Integer = iPortal_CCIDefaultCardSystemIDExt.Portal_CCIDefaultCardSystemIDSp(CustNum, CardSystemId)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Portal_CCIGetTransInfoSp(ByVal CardSystemId As String, ByVal CardSystem As String, ByVal CustNum As String, ByVal CustSeq As Integer?, ByVal RefType As String, ByVal TransType As String, ByVal OrdInvNum As String, ByRef GatewayStoredToken As String, ByRef GatewayTransNum As Decimal?, ByRef CardLast4Digits As String, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortal_CCIGetTransInfoExt = New Portal_CCIGetTransInfoFactory().Create(appDb)

            Dim Severity As Integer = iPortal_CCIGetTransInfoExt.Portal_CCIGetTransInfoSp(CardSystemId, CardSystem, CustNum, CustSeq, RefType, TransType, OrdInvNum, GatewayStoredToken, GatewayTransNum, CardLast4Digits, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Portal_CCILogTransSp(ByVal CustNum As String, ByVal GatewayTransNum As Decimal?, ByVal authCode As String, ByVal TransType As String, ByVal TotalAmt As Decimal?, ByVal iSuccess As Byte?, ByVal RefType As String, ByVal OrdInvNum As String, ByVal CardType As String, ByVal strResponseMsg As String, ByVal CardSystem As String, ByVal ForAmt As Decimal?, ByVal ExchRate As Decimal?, ByVal AutoPostOpenPmt As Byte?, ByVal GatewayLongTransNum As Decimal?, ByVal GatewayStoredToken As String, ByVal CustRef As String, ByVal BackEndUserName As String, ByVal AuthBatchID As Guid?, ByVal ExpDate As String, ByVal Last4 As String, ByRef Infobar As String, ByVal CardSystemId As String, ByVal DomAmt As Decimal?, ByVal PayExchRate As Decimal?) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iPortal_CCILogTransExt As IPortal_CCILogTrans = New Portal_CCILogTransFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPortal_CCILogTransExt.Portal_CCILogTransSp(CustNum, GatewayTransNum, authCode, TransType, TotalAmt, iSuccess, RefType, OrdInvNum, CardType, strResponseMsg, CardSystem, ForAmt, ExchRate, AutoPostOpenPmt, GatewayLongTransNum, GatewayStoredToken, CustRef, BackEndUserName, AuthBatchID, ExpDate, Last4, Infobar, CardSystemId, DomAmt, PayExchRate)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function Portal_CCITotalAmtChangedSp(ByVal CustNum As String, ByVal CardSystemId As String, ByVal TotalAmt As Decimal?, ByRef DomAmt As Decimal?, ByRef ForAmt As Decimal?, ByRef ExchRate As Decimal?, ByRef PayExchRate As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortal_CCITotalAmtChangedExt = New Portal_CCITotalAmtChangedFactory().Create(appDb)

            Dim Severity As Integer = iPortal_CCITotalAmtChangedExt.Portal_CCITotalAmtChangedSp(CustNum, CardSystemId, TotalAmt, DomAmt, ForAmt, ExchRate, PayExchRate, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSCCIProcessCardWrapSp(ByVal TransType As String, ByVal cardNum As String, ByVal expDate As String, ByVal NameOnCard As String, ByVal StreetAddress As String, ByVal City As String, ByVal State As String, ByVal Zip As String, ByVal CVNum As String, ByVal CustNum As String, ByVal CustSeq As Integer?, ByVal RefType As String, ByVal OrdInvNum As String, ByVal ForAmt As Decimal?, ByVal ExchRate As Decimal?, ByVal TotalAmt As Decimal?, ByVal TaxAmt As Decimal?, ByRef cardType As String, ByRef authCode As String, ByRef GatewayTransNum As Decimal?, ByRef Infobar As String, ByRef iSuccess As Byte?, ByVal AutoPostOpenPayment As Byte?, ByVal StoreCard As Byte?, ByVal CustRef As String,
<[Optional]> ByVal Username As String, ByVal CardSystemId As String, ByVal DomAmt As Decimal?, ByVal PayExchRate As Decimal?,
<[Optional]> ByVal Signature As Byte()) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSCCIProcessCardWrapExt = New SSSCCIProcessCardWrapFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, cardType As String, authCode As String, GatewayTransNum As Decimal?, Infobar As String, iSuccess As Byte?) = iSSSCCIProcessCardWrapExt.SSSCCIProcessCardWrapSp(TransType, cardNum, expDate, NameOnCard, StreetAddress, City, State, Zip, CVNum, CustNum, CustSeq, RefType, OrdInvNum, ForAmt, ExchRate, TotalAmt, TaxAmt, cardType, authCode, GatewayTransNum, Infobar, iSuccess, AutoPostOpenPayment, StoreCard, CustRef, Username, CardSystemId, DomAmt, PayExchRate, Signature)
            Dim Severity As Integer = result.ReturnCode.Value
            cardType = result.cardType
            authCode = result.authCode
            GatewayTransNum = result.GatewayTransNum
            Infobar = result.Infobar
            iSuccess = result.iSuccess
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CCIGetLastTransInfoSp(ByVal CardSystemId As String, ByVal CardSystem As String, ByVal RefType As String, ByVal TransType As String, ByVal OrdInvNum As String, ByRef GatewayTransNum As Decimal?, ByRef Success As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iCCIGetLastTransInfoExt = New CCIGetLastTransInfoFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, GatewayTransNum As Decimal?, Success As Integer?, Infobar As String) = iCCIGetLastTransInfoExt.CCIGetLastTransInfoSp(CardSystemId, CardSystem, RefType, TransType, OrdInvNum, GatewayTransNum, Success, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            GatewayTransNum = result.GatewayTransNum
            Success = result.Success
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSCCICheckOrderAuthorizedSp(ByVal RefType As String, ByVal RefNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSCCICheckOrderAuthorizedExt = New SSSCCICheckOrderAuthorizedFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iSSSCCICheckOrderAuthorizedExt.SSSCCICheckOrderAuthorizedSp(RefType, RefNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSCCIPayInvoicesSp(ByVal BegInvNum As String, ByVal EndInvNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iSSSCCIPayInvoicesExt = New SSSCCIPayInvoicesFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iSSSCCIPayInvoicesExt.SSSCCIPayInvoicesSp(BegInvNum, EndInvNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSCCISROBalSp(ByVal SroNum As String, ByRef Balance As Decimal?, ByRef TaxAmt As Decimal?, ByRef ExchRate As Decimal?, ByRef ForAmt As Decimal?, ByRef CustSeq As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB = Me.CreateAppDB()
            Dim appDb = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iSSSCCISROBalExt As ISSSCCISROBal = New SSSCCISROBalFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result = iSSSCCISROBalExt.SSSCCISROBalSp(SroNum, Balance, TaxAmt, ExchRate, ForAmt, CustSeq, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Balance = result.Balance
            TaxAmt = result.TaxAmt
            ExchRate = result.ExchRate
            ForAmt = result.ForAmt
            CustSeq = result.CustSeq
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

End Class
