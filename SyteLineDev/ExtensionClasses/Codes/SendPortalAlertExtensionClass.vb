Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports CSI.MG
Imports CSI.Codes
Imports System.Runtime.InteropServices
Imports CSI.Data.RecordSets
Imports Microsoft.Extensions.DependencyInjection

Public Class SendPortalAlertExtensionClass
    'Inherits IDOExtensionClass 'appeared unused
    Inherits CSIExtensionClassBase

    Enum VbFunc
        _CBOOL
        _CBYTE
        _CDATE
        _CDBL
        _CDEC
        _CINT
        _CLNG
        _CSTR
    End Enum

    Public Function SendPortalAlert(ByVal toUserId As String,
                                    ByVal url As String,
                                    ByVal eventName As String,
                                    ByVal lcid As Integer,
                                    ByVal infoBar As String,
                                    Optional ByVal alertVarName1 As String = Nothing,
                                    Optional ByVal alertVarValue1 As Object = Nothing,
                                    Optional ByVal alertVarName2 As String = Nothing,
                                    Optional ByVal alertVarValue2 As Object = Nothing,
                                    Optional ByVal alertVarName3 As String = Nothing,
                                    Optional ByVal alertVarValue3 As Object = Nothing,
                                    Optional ByVal alertVarName4 As String = Nothing,
                                    Optional ByVal alertVarValue4 As Object = Nothing,
                                    Optional ByVal alertVarName5 As String = Nothing,
                                    Optional ByVal alertVarValue5 As Object = Nothing,
                                    Optional ByVal alertVarName6 As String = Nothing,
                                    Optional ByVal alertVarValue6 As Object = Nothing,
                                    Optional ByVal alertVarName7 As String = Nothing,
                                    Optional ByVal alertVarValue7 As Object = Nothing,
                                    Optional ByVal alertVarName8 As String = Nothing,
                                    Optional ByVal alertVarValue8 As Object = Nothing,
                                    Optional ByVal alertVarName9 As String = Nothing,
                                    Optional ByVal alertVarValue9 As Object = Nothing,
                                    Optional ByVal alertVarName10 As String = Nothing,
                                    Optional ByVal alertVarValue10 As Object = Nothing,
                                    Optional ByVal alertVarName11 As String = Nothing,
                                    Optional ByVal alertVarValue11 As Object = Nothing,
                                    Optional ByVal alertVarName12 As String = Nothing,
                                    Optional ByVal alertVarValue12 As Object = Nothing,
                                    Optional ByVal alertVarName13 As String = Nothing,
                                    Optional ByVal alertVarValue13 As Object = Nothing,
                                    Optional ByVal alertVarName14 As String = Nothing,
                                    Optional ByVal alertVarValue14 As Object = Nothing,
                                    Optional ByVal alertVarName15 As String = Nothing,
                                    Optional ByVal alertVarValue15 As Object = Nothing,
                                    Optional ByVal alertVarName16 As String = Nothing,
                                    Optional ByVal alertVarValue16 As Object = Nothing,
                                    Optional ByVal alertVarName17 As String = Nothing,
                                    Optional ByVal alertVarValue17 As Object = Nothing,
                                    Optional ByVal alertVarName18 As String = Nothing,
                                    Optional ByVal alertVarValue18 As Object = Nothing,
                                    Optional ByVal alertVarName19 As String = Nothing,
                                    Optional ByVal alertVarValue19 As Object = Nothing,
                                    Optional ByVal alertVarName20 As String = Nothing,
                                    Optional ByVal alertVarValue20 As Object = Nothing) As Integer


        If (url.EndsWith("/")) Then
            url = url + "ipf/svc/au_wcf"
        Else
            url = url + "/ipf/svc/au_wcf"
        End If

        Dim client As IPFAlertService.AlertServiceClient = New IPFAlertService.AlertServiceClient(url)

        Dim payload As IPFAlertService.IPFEvent = New IPFAlertService.IPFEvent With {
            .Variables = New Dictionary(Of String, Object)
        }
        InitializePayload(payload, alertVarName1, alertVarValue1, alertVarName2, alertVarValue2, alertVarName3, alertVarValue3, alertVarName4, alertVarValue4, alertVarName5, alertVarValue5, alertVarName6, alertVarValue6, alertVarName7, alertVarValue7, alertVarName8, alertVarValue8, alertVarName9, alertVarValue9, alertVarName10, alertVarValue10, alertVarName11, alertVarValue11, alertVarName12, alertVarValue12, alertVarName13, alertVarValue13, alertVarName14, alertVarValue14, alertVarName15, alertVarValue15, alertVarName16, alertVarValue16, alertVarName17, alertVarValue17, alertVarName18, alertVarValue18, alertVarName19, alertVarValue19, alertVarName20, alertVarValue20)
        payload.Name = eventName

        If (lcid = 0) Then
            client.AlertUser(toUserId, payload)
        Else
            client.AlertUser(toUserId, payload, lcid)
        End If

        Return 0
    End Function

    Public Sub InitializePayload(ByRef payload As IPFAlertService.IPFEvent,
                                 ByVal alertVarName1 As String,
                                 ByVal alertVarValue1 As Object,
                                 ByVal alertVarName2 As String,
                                 ByVal alertVarValue2 As Object,
                                 ByVal alertVarName3 As String,
                                 ByVal alertVarValue3 As Object,
                                 ByVal alertVarName4 As String,
                                 ByVal alertVarValue4 As Object,
                                 ByVal alertVarName5 As String,
                                 ByVal alertVarValue5 As Object,
                                 ByVal alertVarName6 As String,
                                 ByVal alertVarValue6 As Object,
                                 ByVal alertVarName7 As String,
                                 ByVal alertVarValue7 As Object,
                                 ByVal alertVarName8 As String,
                                 ByVal alertVarValue8 As Object,
                                 ByVal alertVarName9 As String,
                                 ByVal alertVarValue9 As Object,
                                 ByVal alertVarName10 As String,
                                 ByVal alertVarValue10 As Object,
                                 ByVal alertVarName11 As String,
                                 ByVal alertVarValue11 As Object,
                                 ByVal alertVarName12 As String,
                                 ByVal alertVarValue12 As Object,
                                 ByVal alertVarName13 As String,
                                 ByVal alertVarValue13 As Object,
                                 ByVal alertVarName14 As String,
                                 ByVal alertVarValue14 As Object,
                                 ByVal alertVarName15 As String,
                                 ByVal alertVarValue15 As Object,
                                 ByVal alertVarName16 As String,
                                 ByVal alertVarValue16 As Object,
                                 ByVal alertVarName17 As String,
                                 ByVal alertVarValue17 As Object,
                                 ByVal alertVarName18 As String,
                                 ByVal alertVarValue18 As Object,
                                 ByVal alertVarName19 As String,
                                 ByVal alertVarValue19 As Object,
                                 ByVal alertVarName20 As String,
                                 ByVal alertVarValue20 As Object)


        If (String.IsNullOrEmpty(alertVarName1) = False) Then
            payload.Variables.Add(alertVarName1, ConvertStringToTypedValue(alertVarValue1))
        End If
        If (String.IsNullOrEmpty(alertVarName2) = False) Then
            payload.Variables.Add(alertVarName2, ConvertStringToTypedValue(alertVarValue2))
        End If
        If (String.IsNullOrEmpty(alertVarName3) = False) Then
            payload.Variables.Add(alertVarName3, ConvertStringToTypedValue(alertVarValue3))
        End If
        If (String.IsNullOrEmpty(alertVarName4) = False) Then
            payload.Variables.Add(alertVarName4, ConvertStringToTypedValue(alertVarValue4))
        End If
        If (String.IsNullOrEmpty(alertVarName5) = False) Then
            payload.Variables.Add(alertVarName5, ConvertStringToTypedValue(alertVarValue5))
        End If
        If (String.IsNullOrEmpty(alertVarName6) = False) Then
            payload.Variables.Add(alertVarName6, ConvertStringToTypedValue(alertVarValue6))
        End If
        If (String.IsNullOrEmpty(alertVarName7) = False) Then
            payload.Variables.Add(alertVarName7, ConvertStringToTypedValue(alertVarValue7))
        End If
        If (String.IsNullOrEmpty(alertVarName8) = False) Then
            payload.Variables.Add(alertVarName8, ConvertStringToTypedValue(alertVarValue8))
        End If
        If (String.IsNullOrEmpty(alertVarName9) = False) Then
            payload.Variables.Add(alertVarName9, ConvertStringToTypedValue(alertVarValue9))
        End If
        If (String.IsNullOrEmpty(alertVarName10) = False) Then
            payload.Variables.Add(alertVarName10, ConvertStringToTypedValue(alertVarValue10))
        End If
        If (String.IsNullOrEmpty(alertVarName11) = False) Then
            payload.Variables.Add(alertVarName11, ConvertStringToTypedValue(alertVarValue11))
        End If
        If (String.IsNullOrEmpty(alertVarName12) = False) Then
            payload.Variables.Add(alertVarName12, ConvertStringToTypedValue(alertVarValue12))
        End If
        If (String.IsNullOrEmpty(alertVarName13) = False) Then
            payload.Variables.Add(alertVarName13, ConvertStringToTypedValue(alertVarValue13))
        End If
        If (String.IsNullOrEmpty(alertVarName14) = False) Then
            payload.Variables.Add(alertVarName14, ConvertStringToTypedValue(alertVarValue14))
        End If
        If (String.IsNullOrEmpty(alertVarName15) = False) Then
            payload.Variables.Add(alertVarName15, ConvertStringToTypedValue(alertVarValue15))
        End If
        If (String.IsNullOrEmpty(alertVarName16) = False) Then
            payload.Variables.Add(alertVarName16, ConvertStringToTypedValue(alertVarValue16))
        End If
        If (String.IsNullOrEmpty(alertVarName17) = False) Then
            payload.Variables.Add(alertVarName17, ConvertStringToTypedValue(alertVarValue17))
        End If
        If (String.IsNullOrEmpty(alertVarName18) = False) Then
            payload.Variables.Add(alertVarName18, ConvertStringToTypedValue(alertVarValue18))
        End If
        If (String.IsNullOrEmpty(alertVarName19) = False) Then
            payload.Variables.Add(alertVarName19, ConvertStringToTypedValue(alertVarValue19))
        End If
        If (String.IsNullOrEmpty(alertVarName20) = False) Then
            payload.Variables.Add(alertVarName20, ConvertStringToTypedValue(alertVarValue20))
        End If

    End Sub

    Private Function ConvertStringToTypedValue(ByVal arg1 As String) As Object

        Dim InStrFunc As VbFunc
        Dim InStrArg As String = Nothing

        '' If string doesn't contain a VbFunc
        '' then return the original value
        ''
        If (Not HasFunction(arg1, InStrFunc, InStrArg)) Then
            Return arg1
        End If


        Try
            Select Case InStrFunc

                Case VbFunc._CDATE

                    Dim dateValue As DateTime
                    Dim culture As CultureInfo = CultureInfo.CurrentCulture
                    Dim datetimestyles As DateTimeStyles = DateTimeStyles.None
                    DateTime.TryParse(InStrArg, culture, datetimestyles, dateValue)
                    Return dateValue

                Case VbFunc._CBOOL

                    Return Convert.ToBoolean(InStrArg)

                Case VbFunc._CDEC

                    Dim rtnVal As Decimal = 0
                    Decimal.TryParse(InStrArg, rtnVal)
                    Return rtnVal

                Case VbFunc._CDBL

                    Dim rtnVal As Double = 0
                    Double.TryParse(InStrArg, rtnVal)
                    Return rtnVal

                Case VbFunc._CINT

                    Dim rtnVal As Integer = 0
                    Integer.TryParse(InStrArg, rtnVal)
                    Return rtnVal

                Case VbFunc._CBYTE

                    Dim rtnVal As Byte = 0
                    Byte.TryParse(InStrArg, rtnVal)
                    Return rtnVal

                Case VbFunc._CLNG

                    Dim rtnVal As Byte = 0
                    Long.TryParse(InStrArg, rtnVal)
                    Return rtnVal

                Case VbFunc._CSTR

                    Return InStrArg

                Case Else
                    '' return original value
            End Select

        Catch ex As Exception
            '' return original value
        End Try

        '' Return original value in all other situations
        Return arg1
    End Function
    Private Function HasFunction(ByVal arg1 As String, ByRef InstrFunc As VbFunc, ByRef InstrArg As String) As Boolean

        If (String.IsNullOrEmpty(arg1)) Then
            Return False
        End If

        Dim HasFunctionRegex As String = "^\s*(\w+)\s*\((.*)\)"
        Dim ExtractFuncRegex As String = "\b[^()]+\((.*)\)$"
        '' Dim ExtractArgsRegex As String = "([^,]+\(.+?\))|([^,]+)"

        Dim funcname As String = Regex.Match(arg1, HasFunctionRegex).Groups(1).Value

        If (String.IsNullOrEmpty(funcname)) Then
            Return False
        End If

        If ([Enum].IsDefined(GetType(VbFunc), String.Format("_{0}", funcname.ToUpper))) Then
            InstrFunc = DirectCast([Enum].Parse(GetType(VbFunc), String.Format("_{0}", funcname.ToUpper)), VbFunc)

            InstrArg = Regex.Match(arg1, ExtractFuncRegex).Groups(1).Value

            '' Get comma seperated args
            'Dim matches = Regex.Matches(innerArgs, ExtractArgsRegex)
            'If (matches.Count > 0) Then
            '    InstrArg = matches.Item(0).Value
            'End If

        Else
            Return False
        End If


        Return True
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function AddToPortalOrderSp(ByVal CoCustNum As String, ByVal CoOrderDate As DateTime?, ByVal CoWhse As String, ByVal CoConsignment As Byte?, ByVal ColItem As String, ByVal ColUM As String, ByVal ColQtyOrdered As Decimal?,
<[Optional]> ByVal CoShipFromSite As String,
<[Optional]> ByVal ItemPriceConv As Decimal?,
<[Optional]> ByVal PortalUsername As String,
<[Optional]> ByVal ColProjectedDate As DateTime?,
<[Optional]> ByVal ColDueDate As DateTime?,
<[Optional]> ByVal ColPromiseDate As DateTime?, ByRef CoCustSeq As Integer?,
<[Optional]> ByRef CoType As String,
<[Optional]> ByRef CoRowPointer As Guid?, ByRef CoNum As String, ByRef PaymentMethod As String,
<[Optional]> ByRef CurrCode As String,
<[Optional]> ByRef ShippingMethod As String,
<[Optional]> ByRef CoLine As Short?,
<[Optional]> ByRef CoLineRowPointer As Guid?, ByRef ItemNotPriced As Byte?,
<[Optional]> ByRef ItmAutoJob As String,
<[Optional]> ByRef CfgModel As String,
<[Optional]> ByRef CustName As String,
<[Optional], DefaultParameterValue(CByte(0))> ByRef B2B As Byte?,
<[Optional]> ByRef CatalogRowPointer As Guid?,
<[Optional]> ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iAddToPortalOrderExt As IAddToPortalOrder = New AddToPortalOrderFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CoCustSeq As Integer?, CoType As String, CoRowPointer As Guid?, CoNum As String, PaymentMethod As String, CurrCode As String, ShippingMethod As String, CoLine As Integer?, CoLineRowPointer As Guid?, ItemNotPriced As Integer?, ItmAutoJob As String, CfgModel As String, CustName As String, B2B As Integer?, CatalogRowPointer As Guid?, Infobar As String) = iAddToPortalOrderExt.AddToPortalOrderSp(CoCustNum, CoOrderDate, CoWhse, CoConsignment, ColItem, ColUM, ColQtyOrdered, CoShipFromSite, ItemPriceConv, PortalUsername, ColProjectedDate, ColDueDate, ColPromiseDate, CoCustSeq, CoType, CoRowPointer, CoNum, PaymentMethod, CurrCode, ShippingMethod, CoLine, CoLineRowPointer, ItemNotPriced, ItmAutoJob, CfgModel, CustName, B2B, CatalogRowPointer, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            CoCustSeq = result.CoCustSeq
            CoType = result.CoType
            CoRowPointer = result.CoRowPointer
            CoNum = result.CoNum
            PaymentMethod = result.PaymentMethod
            CurrCode = result.CurrCode
            ShippingMethod = result.ShippingMethod
            CoLine = result.CoLine
            CoLineRowPointer = result.CoLineRowPointer
            ItemNotPriced = result.ItemNotPriced
            ItmAutoJob = result.ItmAutoJob
            CfgModel = result.CfgModel
            CustName = result.CustName
            B2B = result.B2B
            CatalogRowPointer = result.CatalogRowPointer
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function ClearTrackRowsSp(ByVal SessionID As Guid?, ByVal TrackedOperType As String, <[Optional]> ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iClearTrackRowsExt As IClearTrackRows = New ClearTrackRowsFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iClearTrackRowsExt.ClearTrackRowsSp(SessionID, TrackedOperType, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CreatePortalUserEmailAddressSp(ByVal Username As String, ByVal Email As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCreatePortalUserEmailAddressExt As ICreatePortalUserEmailAddress = New CreatePortalUserEmailAddressFactory().Create(appDb)

            Dim Severity As Integer = iCreatePortalUserEmailAddressExt.CreatePortalUserEmailAddressSp(Username, Email, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustomerPortalCreateCustomer_1_CanCreateUsersSp(ByVal Username As String, ByVal Name As String, ByVal Email As String, ByVal Password As String, ByVal RetypePassword As String, ByVal ResellerSlsman As String, ByVal OrderCurrency As String, ByVal CompanyName As String, ByVal LocaleId As Integer?, ByRef CustNum As String, ByVal PrimarySite As String, ByRef Infobar As String, ByVal CanCreateUsers As Byte?, ByVal PreCanCreateUsers As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCustomerPortalCreateCustomer_1_CanCreateUsersExt As ICustomerPortalCreateCustomer_1_CanCreateUsers = New CustomerPortalCreateCustomer_1_CanCreateUsersFactory().Create(appDb)

            Dim Severity As Integer = iCustomerPortalCreateCustomer_1_CanCreateUsersExt.CustomerPortalCreateCustomer_1_CanCreateUsersSp(Username, Name, Email, Password, RetypePassword, ResellerSlsman, OrderCurrency, CompanyName, LocaleId, CustNum, PrimarySite, Infobar, CanCreateUsers, PreCanCreateUsers)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustomerPortalCreateCustomerShipToSp(ByVal CustNum As String, ByRef CustSeq As String, ByVal Name As String, ByVal Addr1 As String, ByVal Addr2 As String, ByVal Addr3 As String, ByVal Addr4 As String, ByVal City As String, ByVal County As String, ByVal State As String, ByVal PostalCode As String, ByVal Country As String, ByVal ResellerSlsman As String, ByVal ShipToContactName As String, ByVal ShipToContactPhone As String, ByVal ShipToContactFax As String, ByVal ShipToContactEmail As String, ByVal PrimarySiteFlag As Byte?, ByVal BillToFlag As Byte?, ByVal AddressChanged As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCustomerPortalCreateCustomerShipToExt As ICustomerPortalCreateCustomerShipTo = New CustomerPortalCreateCustomerShipToFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CustSeq As String, Infobar As String) = iCustomerPortalCreateCustomerShipToExt.CustomerPortalCreateCustomerShipToSp(CustNum, CustSeq, Name, Addr1, Addr2, Addr3, Addr4, City, County, State, PostalCode, Country, ResellerSlsman, ShipToContactName, ShipToContactPhone, ShipToContactFax, ShipToContactEmail, PrimarySiteFlag, BillToFlag, AddressChanged, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            CustSeq = result.CustSeq
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustSpecificUnitPriceExistsSp(ByVal CurrCode As String, ByVal CustNum As String, ByVal Item As String, ByRef CustSpecificUnitPriceExists As Integer?, ByRef Infobar As String) As Integer
        Dim iCustSpecificUnitPriceExistsExt As ICustSpecificUnitPriceExists = Me.GetService(Of ICustSpecificUnitPriceExists)()
        Dim result As (ReturnCode As Integer?, CustSpecificUnitPriceExists As Integer?, Infobar As String) = iCustSpecificUnitPriceExistsExt.CustSpecificUnitPriceExistsSp(CurrCode, CustNum, Item, CustSpecificUnitPriceExists, Infobar)
        CustSpecificUnitPriceExists = result.CustSpecificUnitPriceExists
        Infobar = result.Infobar
        Dim Severity As Integer = result.ReturnCode.Value
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCustPortalCoRowPointerSp(ByVal CustNum As String, ByVal EstCoNum As String, ByRef CoNum As String, ByRef CoRowPointer As Guid?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetCustPortalCoRowPointerExt As IGetCustPortalCoRowPointer = New GetCustPortalCoRowPointerFactory().Create(appDb)

            Dim Severity As Integer = iGetCustPortalCoRowPointerExt.GetCustPortalCoRowPointerSp(CustNum, EstCoNum, CoNum, CoRowPointer, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCustPortalOrderInfoSp(ByVal CustNum As String, ByVal ResellerPortalFlag As Byte?, ByVal ResellerCustNum As String, ByRef CoRowPointer As Guid?, ByRef CustSeq As Integer?, ByRef CustName As String, ByRef B2B As Byte?, ByRef CoType As String, ByRef CurrCode As String, ByRef CoNum As String, ByRef PaymentMethod As String, ByRef ShippingMethod As String, ByRef CustomerCatalogRowPointer As Guid?, ByRef SubTotal As Decimal?, ByRef SalesTax As Decimal?, ByRef ShippingCost As Decimal?, ByRef ItemCnt As Integer?, ByRef CommissionAmountTotal As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetCustPortalOrderInfoExt As IGetCustPortalOrderInfo = New GetCustPortalOrderInfoFactory().Create(appDb)

            Dim Severity As Integer = iGetCustPortalOrderInfoExt.GetCustPortalOrderInfoSp(CustNum, ResellerPortalFlag, ResellerCustNum, CoRowPointer, CustSeq, CustName, B2B, CoType, CurrCode, CoNum, PaymentMethod, ShippingMethod, CustomerCatalogRowPointer, SubTotal, SalesTax, ShippingCost, ItemCnt, CommissionAmountTotal, Infobar)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCustPortalUserInfoSp(ByRef CoRowPointer As Guid?, ByRef GlobalCustNum As String, ByRef GlobalCustSeq As Integer?, ByRef GlobalCustName As String, ByRef GlobalB2B As Byte?, ByRef GlobalCoType As String, ByRef GlobalUserId As String, ByRef GlobalUserDesc As String, ByRef GlobalCurrCode As String, ByRef GlobalResellerCustNum As String, ByRef GlobalResellerSlsman As String, ByRef GlobalPrimarySite As String, ByRef GlobalCoNum As String, ByRef GlobalPaymentMethod As String, ByRef GlobalShippingMethod As String, ByRef GlobalAPSMode As String, ByRef GlobalSupportPhone As String, ByRef GlobalHasCCI As Byte?, ByRef GlobalHasFSP As Byte?, ByRef GlobalUserEmailAddress As String, ByRef GlobalCreateUserPrivilege As Byte?, ByRef GlobalIsAdmin As Byte?, ByRef GlobalEnableCategoryBrowsing As Byte?, ByRef GlobalResellerCurrCode As String, ByRef GlobalGroupName As String, ByRef GlobalSuperUserFlag As Byte?, ByRef GlobalB2BCOCustNum As String, ByRef GlobalIsPreLogin As Byte?, ByRef GlobalPricingPreCalculationRule As String, ByRef GlobalPricingDisplayRule As String, ByRef GlobalDisplayPriceOnRequest As Byte?, ByRef GlobalCustomerCatalogRowPointer As Guid?, ByRef GlobalResellerCatalogRowPointer As Guid?, ByRef GlobalPreLoginCatalogRowPointer As Guid?, ByVal MergeCart As Byte?, ByVal ToOrderType As String, ByVal PreLoginCoNum As String, ByVal PostLoginCoNum As String,
<[Optional], DefaultParameterValue("N")> ByRef ConfiguratorUserInterface As String, <[Optional], DefaultParameterValue("")> ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iGetCustPortalUserInfoExt As IGetCustPortalUserInfo = New GetCustPortalUserInfoFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, CoRowPointer As Guid?, GlobalCustNum As String, GlobalCustSeq As Integer?, GlobalCustName As String, GlobalB2B As Byte?, GlobalCoType As String, GlobalUserId As String, GlobalUserDesc As String, GlobalCurrCode As String, GlobalResellerCustNum As String, GlobalResellerSlsman As String, GlobalPrimarySite As String, GlobalCoNum As String, GlobalPaymentMethod As String, GlobalShippingMethod As String, GlobalAPSMode As String, GlobalSupportPhone As String, GlobalHasCCI As Byte?, GlobalHasFSP As Byte?, GlobalUserEmailAddress As String, GlobalCreateUserPrivilege As Byte?, GlobalIsAdmin As Byte?, GlobalEnableCategoryBrowsing As Byte?, GlobalResellerCurrCode As String, GlobalGroupName As String, GlobalSuperUserFlag As Byte?, GlobalB2BCOCustNum As String, GlobalIsPreLogin As Byte?, GlobalPricingPreCalculationRule As String, GlobalPricingDisplayRule As String, GlobalDisplayPriceOnRequest As Byte?, GlobalCustomerCatalogRowPointer As Guid?, GlobalResellerCatalogRowPointer As Guid?, GlobalPreLoginCatalogRowPointer As Guid?, ConfiguratorUserInterface As String, Infobar As String) = iGetCustPortalUserInfoExt.GetCustPortalUserInfoSp(CoRowPointer, GlobalCustNum, GlobalCustSeq, GlobalCustName, GlobalB2B, GlobalCoType, GlobalUserId, GlobalUserDesc, GlobalCurrCode, GlobalResellerCustNum, GlobalResellerSlsman, GlobalPrimarySite, GlobalCoNum, GlobalPaymentMethod, GlobalShippingMethod, GlobalAPSMode, GlobalSupportPhone, GlobalHasCCI, GlobalHasFSP, GlobalUserEmailAddress, GlobalCreateUserPrivilege, GlobalIsAdmin, GlobalEnableCategoryBrowsing, GlobalResellerCurrCode, GlobalGroupName, GlobalSuperUserFlag, GlobalB2BCOCustNum, GlobalIsPreLogin, GlobalPricingPreCalculationRule, GlobalPricingDisplayRule, GlobalDisplayPriceOnRequest, GlobalCustomerCatalogRowPointer, GlobalResellerCatalogRowPointer, GlobalPreLoginCatalogRowPointer, MergeCart, ToOrderType, PreLoginCoNum, PostLoginCoNum, ConfiguratorUserInterface, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            CoRowPointer = result.CoRowPointer
            GlobalCustNum = result.GlobalCustNum
            GlobalCustSeq = result.GlobalCustSeq
            GlobalCustName = result.GlobalCustName
            GlobalB2B = result.GlobalB2B
            GlobalCoType = result.GlobalCoType
            GlobalUserId = result.GlobalUserId
            GlobalUserDesc = result.GlobalUserDesc
            GlobalCurrCode = result.GlobalCurrCode
            GlobalResellerCustNum = result.GlobalResellerCustNum
            GlobalResellerSlsman = result.GlobalResellerSlsman
            GlobalPrimarySite = result.GlobalPrimarySite
            GlobalCoNum = result.GlobalCoNum
            GlobalPaymentMethod = result.GlobalPaymentMethod
            GlobalShippingMethod = result.GlobalShippingMethod
            GlobalAPSMode = result.GlobalAPSMode
            GlobalSupportPhone = result.GlobalSupportPhone
            GlobalHasCCI = result.GlobalHasCCI
            GlobalHasFSP = result.GlobalHasFSP
            GlobalUserEmailAddress = result.GlobalUserEmailAddress
            GlobalCreateUserPrivilege = result.GlobalCreateUserPrivilege
            GlobalIsAdmin = result.GlobalIsAdmin
            GlobalEnableCategoryBrowsing = result.GlobalEnableCategoryBrowsing
            GlobalResellerCurrCode = result.GlobalResellerCurrCode
            GlobalGroupName = result.GlobalGroupName
            GlobalSuperUserFlag = result.GlobalSuperUserFlag
            GlobalB2BCOCustNum = result.GlobalB2BCOCustNum
            GlobalIsPreLogin = result.GlobalIsPreLogin
            GlobalPricingPreCalculationRule = result.GlobalPricingPreCalculationRule
            GlobalPricingDisplayRule = result.GlobalPricingDisplayRule
            GlobalDisplayPriceOnRequest = result.GlobalDisplayPriceOnRequest
            GlobalCustomerCatalogRowPointer = result.GlobalCustomerCatalogRowPointer
            GlobalResellerCatalogRowPointer = result.GlobalResellerCatalogRowPointer
            GlobalPreLoginCatalogRowPointer = result.GlobalPreLoginCatalogRowPointer
            ConfiguratorUserInterface = result.ConfiguratorUserInterface
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetPortalOrderItemPriceSp(ByVal CurrCode As String, ByVal Item As String, ByVal OrderQtyConv As Decimal?, ByVal GenericIfNoCustSpecific As Byte?, ByVal PricingPrecalRule As String, ByVal ShipFromSite As String, ByVal CustNum As String, ByVal CustItem As String, ByRef CustItemUM As String, ByRef CustPriceConv As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetPortalOrderItemPriceExt As IGetPortalOrderItemPrice = New GetPortalOrderItemPriceFactory().Create(appDb)

            Dim Severity As Integer = iGetPortalOrderItemPriceExt.GetPortalOrderItemPriceSp(CurrCode, Item, OrderQtyConv, GenericIfNoCustSpecific, PricingPrecalRule, ShipFromSite, CustNum, CustItem, CustItemUM, CustPriceConv, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetResellerCreatedCustomerCOSp(ByVal CustNum As String, ByVal Username As String, ByRef CustSeq As Integer?, ByRef CoRowPointer As Guid?, ByRef CoNum As String, ByRef B2B As Byte?, ByRef CurrCode As String, ByRef CoType As String, ByRef PaymentMethod As String, ByRef ShippingMethod As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetResellerCreatedCustomerCOExt As IGetResellerCreatedCustomerCO = New GetResellerCreatedCustomerCOFactory().Create(appDb)

            Dim Severity As Integer = iGetResellerCreatedCustomerCOExt.GetResellerCreatedCustomerCOSp(CustNum, Username, CustSeq, CoRowPointer, CoNum, B2B, CurrCode, CoType, PaymentMethod, ShippingMethod, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function HasPreAndPostLoginCartSp(ByVal CoRowPointer As Guid?, ByRef GlobalCustNum As String, ByRef GlobalUserId As String, ByRef GlobalIsPreLogin As Byte?, ByRef ToOrderType As String, ByRef MergeCart As Byte?, ByRef HasConfig As Byte?, ByRef PreLoginCoNum As String, ByRef PostLoginCoNum As String, ByRef GlobalPrimarySite As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iHasPreAndPostLoginCartExt As IHasPreAndPostLoginCart = New HasPreAndPostLoginCartFactory().Create(appDb)

            Dim Severity As Integer = iHasPreAndPostLoginCartExt.HasPreAndPostLoginCartSp(CoRowPointer, GlobalCustNum, GlobalUserId, GlobalIsPreLogin, ToOrderType, MergeCart, HasConfig, PreLoginCoNum, PostLoginCoNum, GlobalPrimarySite, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalAccountCorrectionSp(ByVal Username As String, ByVal CustVendNum As String, ByVal Portal As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortalAccountCorrectionExt As IPortalAccountCorrection = New PortalAccountCorrectionFactory().Create(appDb)

            Dim Severity As Integer = iPortalAccountCorrectionExt.PortalAccountCorrectionSp(Username, CustVendNum, Portal, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalAccountManagement_1_CanCreateUsersSp(ByVal Username As String, ByVal CustVendNum As String, ByVal Name As String, ByVal Email As String, ByVal Password As String, ByVal DecryptedPassword As String, ByVal AccountType As String, ByVal VendNum As String, ByVal NotifyUser As Byte?, ByVal Primary As String, ByVal CreateUser As Byte?, ByVal PortalURL As String, ByVal LocaleId As Integer?, ByRef Infobar As String, ByVal CanCreateUsers As Byte?, ByVal PreCanCreateUsers As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortalAccountManagement_1_CanCreateUsersExt As IPortalAccountManagement_1_CanCreateUsers = New PortalAccountManagement_1_CanCreateUsersFactory().Create(appDb)

            Dim Severity As Integer = iPortalAccountManagement_1_CanCreateUsersExt.PortalAccountManagement_1_CanCreateUsersSp(Username, CustVendNum, Name, Email, Password, DecryptedPassword, AccountType, VendNum, NotifyUser, Primary, CreateUser, PortalURL, LocaleId, Infobar, CanCreateUsers, PreCanCreateUsers)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalEstimateToHistorySp(ByVal CoNum As String, ByVal pCpFOrdType As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortalEstimateToHistoryExt As IPortalEstimateToHistory = New PortalEstimateToHistoryFactory().Create(appDb)

            Dim Severity As Integer = iPortalEstimateToHistoryExt.PortalEstimateToHistorySp(CoNum, pCpFOrdType, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalOrderStatusChangeSp(ByVal CoNum As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortalOrderStatusChangeExt As IPortalOrderStatusChange = New PortalOrderStatusChangeFactory().Create(appDb)

            Dim Severity As Integer = iPortalOrderStatusChangeExt.PortalOrderStatusChangeSp(CoNum, Infobar)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalUpdateOrderLineQuantitiesSp(ByVal CoNum As String,
<[Optional]> ByVal CoLineList As String, ByVal QtyOrderedConvList As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim iPortalUpdateOrderLineQuantitiesExt As IPortalUpdateOrderLineQuantities = New PortalUpdateOrderLineQuantitiesFactory().Create(appDb)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPortalUpdateOrderLineQuantitiesExt.PortalUpdateOrderLineQuantitiesSp(CoNum, CoLineList, QtyOrderedConvList, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PurgeTmpPortalAccountStatusSp(ByVal Portal As String, ByVal Username As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPurgeTmpPortalAccountStatusExt As IPurgeTmpPortalAccountStatus = New PurgeTmpPortalAccountStatusFactory().Create(appDb)

            Dim Severity As Integer = iPurgeTmpPortalAccountStatusExt.PurgeTmpPortalAccountStatusSp(Portal, Username, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdatePortalOrderLineSp(ByVal CoNum As String, ByVal CoLine As Short?, ByVal UM As String, ByVal PriceConv As Decimal?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iUpdatePortalOrderLineExt As IUpdatePortalOrderLine = New UpdatePortalOrderLineFactory().Create(appDb)

            Dim Severity As Integer = iUpdatePortalOrderLineExt.UpdatePortalOrderLineSp(CoNum, CoLine, UM, PriceConv, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetPortalItemPriceSp(ByVal ItemRange As String, ByVal ItemPricingSite As String, ByVal CustNum As String, ByVal ResellerCustNum As String, ByVal CurrCode As String, ByVal IsB2B As Byte?, ByVal Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_GetPortalItemPriceExt As ICLM_GetPortalItemPrice = New CLM_GetPortalItemPriceFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?) = iCLM_GetPortalItemPriceExt.CLM_GetPortalItemPriceSp(ItemRange, ItemPricingSite, CustNum, ResellerCustNum, CurrCode, IsB2B, Infobar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetPortalOrderItemPriceChangesSp(ByVal CoNum As String, ByVal CurrCode As String, ByVal PrimarySite As String, ByVal ResellerSlsman As String, ByVal PricingPrecalculationRule As String, ByVal GenericIfNoCustSpecific As Byte?, ByRef Infobar As String) As DataTable
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim bunchedLoadCollection As IBunchedLoadCollection = New CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, CType(Me.Context.Request, LoadCollectionDataBase))
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCLM_GetPortalOrderItemPriceChangesExt As ICLM_GetPortalOrderItemPriceChanges = New CLM_GetPortalOrderItemPriceChangesFactory().Create(appDb, bunchedLoadCollection, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (Data As CSI.Data.CRUD.ICollectionLoadResponse, ReturnCode As Integer?, Infobar As String) = iCLM_GetPortalOrderItemPriceChangesExt.CLM_GetPortalOrderItemPriceChangesSp(CoNum, CurrCode, PrimarySite, ResellerSlsman, PricingPrecalculationRule, GenericIfNoCustSpecific, Infobar)
            Dim recordCollectionToDataTable As IRecordCollectionToDataTable = New RecordCollectionToDataTable()
            Dim dt As DataTable = recordCollectionToDataTable.ToDataTable(result.Data.Items)
            Infobar = result.Infobar
            Return dt
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustomerPortalCreateCustomerSp(ByVal Username As String, ByVal Name As String, ByVal Email As String, ByVal Password As String, ByVal RetypePassword As String, ByVal ResellerSlsman As String, ByVal OrderCurrency As String, ByVal CompanyName As String, ByVal LocaleId As Integer?, ByRef CustNum As String, ByVal PrimarySite As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iCustomerPortalCreateCustomerExt As ICustomerPortalCreateCustomer = New CustomerPortalCreateCustomerFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, CustNum As String, Infobar As String) = iCustomerPortalCreateCustomerExt.CustomerPortalCreateCustomerSp(Username, Name, Email, Password, RetypePassword, ResellerSlsman, OrderCurrency, CompanyName, LocaleId, CustNum, PrimarySite, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            CustNum = result.CustNum
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetPortalAlertParmsSp(
        <[Optional]> ByVal PortalType As String,
        <[Optional]> ByRef SiteRef As String,
        <[Optional]> ByRef Infobar As String,
        <[Optional], DefaultParameterValue(0)> ByRef UsePortalEmail As Integer?,
        <[Optional]> ByRef AdminUser As String,
        <[Optional]> ByRef PortalURL As String,
        <[Optional]> ByRef LocaleID As Integer?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iGetPortalAlertParmsExt As IGetPortalAlertParms = New GetPortalAlertParmsFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, SiteRef As String, Infobar As String, UsePortalEmail As String, AdminUser As String, PortalURL As String, LocaleID As Integer?) = iGetPortalAlertParmsExt.GetPortalAlertParmsSp(PortalType, SiteRef, Infobar, UsePortalEmail, AdminUser, PortalURL, LocaleID)
            Dim Severity As Integer = result.ReturnCode.Value
            SiteRef = result.SiteRef
            Infobar = result.Infobar
            UsePortalEmail = result.UsePortalEmail
            AdminUser = result.AdminUser
            PortalURL = result.PortalURL
            LocaleID = result.LocaleID
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function IdentifyCustomerPortalUserTypeSp(ByVal Username As String, ByRef IsBTB As Byte?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iIdentifyCustomerPortalUserTypeExt As IIdentifyCustomerPortalUserType = New IdentifyCustomerPortalUserTypeFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, IsBTB As Integer?, Infobar As String) = iIdentifyCustomerPortalUserTypeExt.IdentifyCustomerPortalUserTypeSp(Username, IsBTB, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            IsBTB = result.IsBTB
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalAccountCreateOrCopy_1_CanCreateUsersSp(ByVal Username As String, ByVal CustVendNum As String, ByVal Name As String, ByVal Email As String, ByVal NotificationEmail As String, ByVal EmailType As String, ByVal EmailTypeDesc As String, ByVal Password As String, ByVal AccountType As String, ByVal VendNum As String, ByVal SendEmailNotifications As Byte?, ByVal EmailNotificationsEmailType As String, ByVal EmailNotificationsEmailTypeDesc As String, ByVal PrimarySite As String, ByVal Create As Byte?, ByVal LocaleId As Integer?, ByRef Infobar As String, ByVal CanCreateUsers As Byte?, ByVal PreCanCreateUsers As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPortalAccountCreateOrCopy_1_CanCreateUsersExt As IPortalAccountCreateOrCopy_1_CanCreateUsers = New PortalAccountCreateOrCopy_1_CanCreateUsersFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPortalAccountCreateOrCopy_1_CanCreateUsersExt.PortalAccountCreateOrCopy_1_CanCreateUsersSp(Username, CustVendNum, Name, Email, NotificationEmail, EmailType, EmailTypeDesc, Password, AccountType, VendNum, SendEmailNotifications, EmailNotificationsEmailType, EmailNotificationsEmailTypeDesc, PrimarySite, Create, LocaleId, Infobar, CanCreateUsers, PreCanCreateUsers)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalAccountCreateOrCopySp(ByVal Username As String, ByVal CustVendNum As String, ByVal Name As String, ByVal Email As String, ByVal NotificationEmail As String, ByVal EmailType As String, ByVal EmailTypeDesc As String, ByVal Password As String, ByVal AccountType As String, ByVal Slsman As String, ByVal VendNum As String, ByVal SendEmailNotifications As Byte?, ByVal EmailNotificationsEmailType As String, ByVal EmailNotificationsEmailTypeDesc As String, ByVal PrimarySite As String, ByVal Create As Byte?, ByVal ResellerCommission As Decimal?, ByVal LocaleId As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPortalAccountCreateOrCopyExt As IPortalAccountCreateOrCopy = New PortalAccountCreateOrCopyFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPortalAccountCreateOrCopyExt.PortalAccountCreateOrCopySp(Username, CustVendNum, Name, Email, NotificationEmail, EmailType, EmailTypeDesc, Password, AccountType, Slsman, VendNum, SendEmailNotifications, EmailNotificationsEmailType, EmailNotificationsEmailTypeDesc, PrimarySite, Create, ResellerCommission, LocaleId, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalAccountManagementSp(ByVal Username As String, ByVal CustVendNum As String, ByVal Name As String, ByVal Email As String, ByVal Password As String, ByVal DecryptedPassword As String, ByVal AccountType As String, ByVal Slsman As String, ByVal VendNum As String, ByVal NotifyUser As Byte?, ByVal Primary As String, ByVal CreateUser As Byte?, ByVal PortalURL As String, ByVal ResellerCommission As Decimal?, ByVal LocaleId As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPortalAccountManagementExt As IPortalAccountManagement = New PortalAccountManagementFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iPortalAccountManagementExt.PortalAccountManagementSp(Username, CustVendNum, Name, Email, Password, DecryptedPassword, AccountType, Slsman, VendNum, NotifyUser, Primary, CreateUser, PortalURL, ResellerCommission, LocaleId, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalCSICompatabilityCheckSp(ByVal ExpectedCSIVersion As String, ByVal RequiredAPARs As String,
        <[Optional], DefaultParameterValue(0)> ByRef ConfigIsValid As Integer?,
        <[Optional]> ByRef ReturnMessage As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPortalCSICompatabilityCheckExt As IPortalCSICompatabilityCheck = New PortalCSICompatabilityCheckFactory().Create(Me, True)
            Dim result As (ReturnCode As Integer?, ConfigIsValid As Integer?, ReturnMessage As String) = iPortalCSICompatabilityCheckExt.PortalCSICompatabilityCheckSp(ExpectedCSIVersion, RequiredAPARs, ConfigIsValid, ReturnMessage)
            Dim Severity As Integer = result.ReturnCode.Value
            ConfigIsValid = result.ConfigIsValid
            ReturnMessage = result.ReturnMessage
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UserPasswordValidationSp(ByVal Username As String, ByVal Password As String, ByVal OldPassword As String, ByVal RetypePassword As String, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUserPasswordValidationExt As IUserPasswordValidation = New UserPasswordValidationFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Infobar As String) = iUserPasswordValidationExt.UserPasswordValidationSp(Username, Password, OldPassword, RetypePassword, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class
