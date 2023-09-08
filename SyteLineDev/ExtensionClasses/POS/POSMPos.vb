Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports Mongoose.Core.Configuration
Imports System.Data.SqlClient
Imports CSI.MG
Imports CSI.POS

<IDOExtensionClass("POSMPos")>
Public Class POSMPos
    Inherits CSIExtensionClassBase
    Implements IIDOExtensionClass

    <IDOMethod(MethodFlags.None, "sInfobar")>
    Public Function POSDrawerLogon(ByVal Drawer As String, ByVal UserName As String, ByVal Password As String, ByRef sInfobar As String) As Byte
        Dim iRtn As Integer = 5 'toolset critical error
        Dim Configuration As String
        Dim myClient As New Mongoose.IDO.Client
        Dim mySession As New Mongoose.IDO.Client(myClient.Server, myClient.Protocol)
        Dim Response As Mongoose.IDO.Protocol.OpenSessionResponseData = Nothing

        sInfobar = ""

        If String.IsNullOrEmpty(Drawer) Or String.IsNullOrEmpty(UserName) Then
            sInfobar = GetErrorMsg(sInfobar, "E=CmdFailed", "@pos_logon")
        End If

        Configuration = IDORuntime.ConfigurationName

        Try
            Response = mySession.OpenSession(UserName, Password, Configuration)

            If Response.LogonSucceeded Or
               Response.Result = OpenSessionResult.SessionLimit Or
               Response.Result = OpenSessionResult.ConcurrentSessionLimit Then

                iRtn = 0
            Else
                sInfobar = GetErrorMsg(sInfobar, "E=CmdFailed", "@pos_logon")
            End If

        Catch ex As Exception
            sInfobar = GetErrorMsg(sInfobar, "E=CmdFailed", "@pos_logon")
        End Try

        mySession.CloseSession()

        Response = Nothing
        mySession = Nothing
        Return iRtn
    End Function

    Private Function GetErrorMsg(ByVal sInfobar As String, ByVal sMsg As String _
  , Optional ByVal sParm1 As String = "" _
  , Optional ByVal sParm2 As String = "" _
  , Optional ByVal sParm3 As String = "" _
  , Optional ByVal sParm4 As String = "" _
  , Optional ByVal sParm5 As String = "" _
  , Optional ByVal sParm6 As String = "" _
  , Optional ByVal sParm7 As String = "") As String

        Dim oMessageProvider As Mongoose.IDO.IMessageProvider = Nothing

        Using appdb As AppDB = Me.CreateAppDB
            oMessageProvider = appdb.GetMessageProvider

            sInfobar = oMessageProvider.AppendMessage(
                       sInfobar _
                     , sMsg _
                     , sParm1, sParm2, sParm3, sParm4, sParm5, sParm6, sParm7)
        End Using

        Return sInfobar
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSPOSCoCustomerValid2Sp(ByVal OldCustNum As String, ByRef CustNum As String, ByRef CustSeq As Integer?, ByRef BillToAddress As String, ByRef ShipToAddress As String, ByRef Contact As String, ByRef Phone As String, ByRef BillToContact As String, ByRef BillToPhone As String, ByRef ShipToContact As String, ByRef ShipToPhone As String, ByRef ShipCode As String, ByRef TermsCode As String, ByRef PriceCode As String, ByVal TaxCode1Type As String, ByRef TaxCode1 As String, ByVal TaxCode2Type As String, ByRef TaxCode2 As String, ByRef OnCreditHold As Byte?, ByRef Slsman As String, ByRef EndUserType As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSPOSCoCustomerValid2Ext As ISSSPOSCoCustomerValid2 = New SSSPOSCoCustomerValid2Factory().Create(appDb)
            Dim Severity As Integer = iSSSPOSCoCustomerValid2Ext.SSSPOSCoCustomerValid2Sp(OldCustNum, CustNum, CustSeq, BillToAddress, ShipToAddress, Contact, Phone, BillToContact, BillToPhone, ShipToContact, ShipToPhone, ShipCode, TermsCode, PriceCode, TaxCode1Type, TaxCode1, TaxCode2Type, TaxCode2, OnCreditHold, Slsman, EndUserType, Infobar)
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSPOSGenerateOrderSp(ByVal OrderType As String, ByVal CashDrawer As String, ByVal CoNum As String, ByVal PartnerID As String, ByVal PartnerName As String, ByVal UserName As String, ByRef POSNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSPOSGenerateOrderExt As ISSSPOSGenerateOrder = New SSSPOSGenerateOrderFactory().Create(appDb)
            Dim Severity As Integer = iSSSPOSGenerateOrderExt.SSSPOSGenerateOrderSp(OrderType, CashDrawer, CoNum, PartnerID, PartnerName, UserName, POSNum, Infobar)
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSPOSGetAutoLogoffSp(ByRef AutoLogoff As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iSSSPOSGetAutoLogoffExt As ISSSPOSGetAutoLogoff = New SSSPOSGetAutoLogoffFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, AutoLogoff As String) = iSSSPOSGetAutoLogoffExt.SSSPOSGetAutoLogoffSp(AutoLogoff)
            Dim Severity As Integer = result.ReturnCode.Value
            AutoLogoff = result.AutoLogoff
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSPOSGetSROTypeSp(ByVal CashDrawer As String, ByRef IsValid As Byte?, ByRef Description As String, ByRef ProductCode As String, ByRef BillCode As String, ByRef BillType As String, ByRef Whse As String, ByRef Disc As Decimal?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSPOSGetSROTypeExt As ISSSPOSGetSROType = New SSSPOSGetSROTypeFactory().Create(appDb)
            Dim Severity As Integer = iSSSPOSGetSROTypeExt.SSSPOSGetSROTypeSp(CashDrawer, IsValid, Description, ProductCode, BillCode, BillType, Whse, Disc)
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSPOSGetWhseSp(ByVal Drawer As String, ByVal UserName As String, ByRef Whse As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSPOSGetWhseExt As ISSSPOSGetWhse = New SSSPOSGetWhseFactory().Create(appDb)
            Dim Severity As Integer = iSSSPOSGetWhseExt.SSSPOSGetWhseSp(Drawer, UserName, Whse)
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSPOSPosM_PSp(ByVal POSNum As String, ByVal UserID As Decimal?, ByVal ParmCurrCode As String, ByVal ParmSite As String, ByVal CurUserCode As String, ByVal SessionID As Guid?, ByRef TInvNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSPOSPosM_PExt As ISSSPOSPosM_P = New SSSPOSPosM_PFactory().Create(appDb)
            Dim Severity As Integer = iSSSPOSPosM_PExt.SSSPOSPosM_PSp(POSNum, UserID, ParmCurrCode, ParmSite, CurUserCode, SessionID, TInvNum, Infobar)
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function SSSPOSReverseLookUpCLSp(ByVal CustNum As String, ByVal CustSeq As Integer?, ByVal SerNum As String, ByVal POSNum As String, ByVal CashDrawer As String, ByVal PartnerID As String, ByVal UserName As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim bunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim iSSSPOSReverseLookUpCLExt As ISSSPOSReverseLookUpCL = New SSSPOSReverseLookUpCLFactory().Create(appDb, bunchedLoadCollection)
            Dim dt As DataTable = iSSSPOSReverseLookUpCLExt.SSSPOSReverseLookUpCLSp(CustNum, CustSeq, SerNum, POSNum, CashDrawer, PartnerID, UserName)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSPOSReverseSp(ByVal POSNum As String, ByRef NewPOSNum As String, ByVal Drawer As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iSSSPOSReverseExt As ISSSPOSReverse = New SSSPOSReverseFactory().Create(appDb)
            Dim Severity As Integer = iSSSPOSReverseExt.SSSPOSReverseSp(POSNum, NewPOSNum, Drawer, Infobar)
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function FormatAddressSp(ByVal CustNum As String, ByVal CustSeq As Integer?, ByRef BillToAddress As String, ByRef ShipToAddress As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As IMGInvoker = New MGInvoker(Me.Context)
            Dim iFormatAddressExt As IFormatAddress = New FormatAddressFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, BillToAddress As String, ShipToAddress As String, Infobar As String) = iFormatAddressExt.FormatAddressSp(CustNum, CustSeq, BillToAddress, ShipToAddress, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            BillToAddress = result.BillToAddress
            ShipToAddress = result.ShipToAddress
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function SSSPOSValidateCustomerDomesticSp(ByVal CustNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim iSSSPOSValidateCustomerDomesticExt As ISSSPOSValidateCustomerDomestic = New SSSPOSValidateCustomerDomesticFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iSSSPOSValidateCustomerDomesticExt.SSSPOSValidateCustomerDomesticSp(CustNum, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class
