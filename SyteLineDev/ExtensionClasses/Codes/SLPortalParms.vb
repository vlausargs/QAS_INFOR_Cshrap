Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.Runtime.InteropServices
Imports CSI.Codes
Imports CSI.MG
Imports CSI.Data.RecordSets
Imports CSI.ExternalContracts.Portals
Imports Microsoft.Extensions.DependencyInjection

<IDOExtensionClass("SLPortalParms")>
Public Class SLPortalParms
    Inherits CSIExtensionClassBase
    Implements ISLPortalParms

    ' this one takes the name of the parm to retrieve
    <IDOMethod(MethodFlags.None)>
    Public Function GetOAUTHKeyandSecret(ByVal pUri As Uri, ByRef oAuthKey As String, ByRef oAuthSecret As String) As Integer


        Dim ResultSet As IDataReader = Nothing
        Dim url As String = pUri.ToString().Substring(0, pUri.ToString().IndexOf("/ipf/svc/au_wcf"))

        Try
            Using db As ApplicationDB = IDORuntime.Context.CreateApplicationDB()

                '' Check customer url
                Using cmd As IDbCommand = db.CreateCommand()
                    cmd.CommandText = "SELECT " &
                                       " customer_portal_consumer_key, customer_portal_consumer_secret " &
                                        " FROM portal_parms " &
                                        String.Format(" WHERE customer_portal_url = '{0}'", url)

                    ResultSet = db.ExecuteReader(cmd)

                    If ResultSet.Read() Then
                        If Not IsDBNull(ResultSet.Item("customer_portal_consumer_key")) Then
                            oAuthKey = ResultSet.Item("customer_portal_consumer_key").ToString()
                            oAuthSecret = ResultSet.Item("customer_portal_consumer_secret").ToString()
                        End If

                        If Not ResultSet Is Nothing AndAlso Not ResultSet.IsClosed Then
                            ResultSet.Close()
                        End If
                        Return 0
                    End If
                    If Not ResultSet Is Nothing AndAlso Not ResultSet.IsClosed Then
                        ResultSet.Close()
                    End If
                End Using
                Using cmd As IDbCommand = db.CreateCommand()
                    '' Check reseller url
                    cmd.CommandText = "SELECT " &
                                       " reseller_portal_consumer_key, reseller_portal_consumer_secret " &
                                        " FROM portal_parms " &
                                        String.Format(" WHERE reseller_portal_url = '{0}'", url)

                    ResultSet = db.ExecuteReader(cmd)

                    If ResultSet.Read() Then
                        If Not IsDBNull(ResultSet.Item("reseller_portal_consumer_key")) Then
                            oAuthKey = ResultSet.Item("reseller_portal_consumer_key").ToString()
                            oAuthSecret = ResultSet.Item("reseller_portal_consumer_secret").ToString()
                        End If
                        If Not ResultSet Is Nothing AndAlso Not ResultSet.IsClosed Then
                            ResultSet.Close()
                        End If
                        Return 0
                    End If
                    If Not ResultSet Is Nothing AndAlso Not ResultSet.IsClosed Then
                        ResultSet.Close()
                    End If
                End Using
                '' Check Vendor url
                Using cmd As IDbCommand = db.CreateCommand()
                    cmd.CommandText = "SELECT " &
                                      " vendor_portal_consumer_key, vendor_portal_consumer_secret " &
                                       " FROM portal_parms " &
                                       String.Format(" WHERE vendor_portal_url = '{0}'", url)

                    ResultSet = db.ExecuteReader(cmd)

                    If ResultSet.Read() Then
                        If Not IsDBNull(ResultSet.Item("vendor_portal_consumer_key")) Then
                            oAuthKey = ResultSet.Item("vendor_portal_consumer_key").ToString()
                            oAuthSecret = ResultSet.Item("vendor_portal_consumer_secret").ToString()
                        End If
                        If Not ResultSet Is Nothing AndAlso Not ResultSet.IsClosed Then
                            ResultSet.Close()
                        End If
                        Return 0
                    End If
                    If Not ResultSet Is Nothing AndAlso Not ResultSet.IsClosed Then
                        ResultSet.Close()
                    End If
                End Using
            End Using
            Return 0

        Catch ex As Exception
            MGException.Throw(MGException.ExtractMessages(ex))
        End Try
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
<[Optional]> ByRef CoLine As Integer?,
<[Optional]> ByRef CoLineRowPointer As Guid?, ByRef ItemNotPriced As Integer?,
<[Optional]> ByRef ItmAutoJob As String,
<[Optional]> ByRef CfgModel As String,
<[Optional]> ByRef CustName As String,
<[Optional], DefaultParameterValue(CByte(0))> ByRef B2B As Integer?,
<[Optional]> ByRef CatalogRowPointer As Guid?,
<[Optional]> ByRef Infobar As String) As Integer Implements ISLPortalParms.AddToPortalOrderSp
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
    Public Function ClearTrackRowsSp(ByVal SessionID As Guid?, ByVal TrackedOperType As String, <[Optional]> ByRef Infobar As String) As Integer Implements ISLPortalParms.ClearTrackRowsSp
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
    Public Function CreatePortalUserEmailAddressSp(ByVal Username As String, ByVal Email As String, ByRef Infobar As String) As Integer Implements ISLPortalParms.CreatePortalUserEmailAddressSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCreatePortalUserEmailAddressExt As ICreatePortalUserEmailAddress = New CreatePortalUserEmailAddressFactory().Create(appDb)

            Dim Severity As Integer = iCreatePortalUserEmailAddressExt.CreatePortalUserEmailAddressSp(Username, Email, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustomerPortalCreateCustomer_1_CanCreateUsersSp(ByVal Username As String, ByVal Name As String, ByVal Email As String, ByVal Password As String, ByVal RetypePassword As String, ByVal ResellerSlsman As String, ByVal OrderCurrency As String, ByVal CompanyName As String, ByVal LocaleId As Integer?, ByRef CustNum As String, ByVal PrimarySite As String, ByRef Infobar As String, ByVal CanCreateUsers As Byte?, ByVal PreCanCreateUsers As Byte?) As Integer Implements ISLPortalParms.CustomerPortalCreateCustomer_1_CanCreateUsersSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iCustomerPortalCreateCustomer_1_CanCreateUsersExt As ICustomerPortalCreateCustomer_1_CanCreateUsers = New CustomerPortalCreateCustomer_1_CanCreateUsersFactory().Create(appDb)

            Dim Severity As Integer = iCustomerPortalCreateCustomer_1_CanCreateUsersExt.CustomerPortalCreateCustomer_1_CanCreateUsersSp(Username, Name, Email, Password, RetypePassword, ResellerSlsman, OrderCurrency, CompanyName, LocaleId, CustNum, PrimarySite, Infobar, CanCreateUsers, PreCanCreateUsers)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CustomerPortalCreateCustomerShipToSp(ByVal CustNum As String, ByRef CustSeq As String, ByVal Name As String, ByVal Addr1 As String, ByVal Addr2 As String, ByVal Addr3 As String, ByVal Addr4 As String, ByVal City As String, ByVal County As String, ByVal State As String, ByVal PostalCode As String, ByVal Country As String, ByVal ResellerSlsman As String, ByVal ShipToContactName As String, ByVal ShipToContactPhone As String, ByVal ShipToContactFax As String, ByVal ShipToContactEmail As String, ByVal PrimarySiteFlag As Integer?, ByVal BillToFlag As Integer?, ByVal AddressChanged As Integer?, ByRef Infobar As String) As Integer Implements ISLPortalParms.CustomerPortalCreateCustomerShipToSp
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
    Public Function CustSpecificUnitPriceExistsSp(ByVal CurrCode As String, ByVal CustNum As String, ByVal Item As String, ByRef CustSpecificUnitPriceExists As Integer?, ByRef Infobar As String) As Integer Implements ISLPortalParms.CustSpecificUnitPriceExistsSp
        Dim iCustSpecificUnitPriceExistsExt As ICustSpecificUnitPriceExists = Me.GetService(Of ICustSpecificUnitPriceExists)()
        Dim result As (ReturnCode As Integer?, CustSpecificUnitPriceExists As Integer?, Infobar As String) = iCustSpecificUnitPriceExistsExt.CustSpecificUnitPriceExistsSp(CurrCode, CustNum, Item, CustSpecificUnitPriceExists, Infobar)
        CustSpecificUnitPriceExists = result.CustSpecificUnitPriceExists
        Infobar = result.Infobar
        Dim Severity As Integer = result.ReturnCode.Value
        Return Severity
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCustPortalCoRowPointerSp(ByVal CustNum As String, ByVal EstCoNum As String, ByRef CoNum As String, ByRef CoRowPointer As Guid?, ByRef Infobar As String) As Integer Implements ISLPortalParms.GetCustPortalCoRowPointerSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetCustPortalCoRowPointerExt As IGetCustPortalCoRowPointer = New GetCustPortalCoRowPointerFactory().Create(appDb)

            Dim Severity As Integer = iGetCustPortalCoRowPointerExt.GetCustPortalCoRowPointerSp(CustNum, EstCoNum, CoNum, CoRowPointer, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCustPortalOrderInfoSp(ByVal CustNum As String, ByVal ResellerPortalFlag As Byte?, ByVal ResellerCustNum As String, ByRef CoRowPointer As Guid?, ByRef CustSeq As Integer?, ByRef CustName As String, ByRef B2B As Byte?, ByRef CoType As String, ByRef CurrCode As String, ByRef CoNum As String, ByRef PaymentMethod As String, ByRef ShippingMethod As String, ByRef CustomerCatalogRowPointer As Guid?, ByRef SubTotal As Decimal?, ByRef SalesTax As Decimal?, ByRef ShippingCost As Decimal?, ByRef ItemCnt As Integer?, ByRef CommissionAmountTotal As Decimal?, ByRef Infobar As String) As Integer Implements ISLPortalParms.GetCustPortalOrderInfoSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetCustPortalOrderInfoExt As IGetCustPortalOrderInfo = New GetCustPortalOrderInfoFactory().Create(appDb)

            Dim Severity As Integer = iGetCustPortalOrderInfoExt.GetCustPortalOrderInfoSp(CustNum, ResellerPortalFlag, ResellerCustNum, CoRowPointer, CustSeq, CustName, B2B, CoType, CurrCode, CoNum, PaymentMethod, ShippingMethod, CustomerCatalogRowPointer, SubTotal, SalesTax, ShippingCost, ItemCnt, CommissionAmountTotal, Infobar)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetCustPortalUserInfoSp(ByRef CoRowPointer As Guid?, ByRef GlobalCustNum As String, ByRef GlobalCustSeq As Integer?, ByRef GlobalCustName As String, ByRef GlobalB2B As Byte?, ByRef GlobalCoType As String, ByRef GlobalUserId As String, ByRef GlobalUserDesc As String, ByRef GlobalCurrCode As String, ByRef GlobalResellerCustNum As String, ByRef GlobalResellerSlsman As String, ByRef GlobalPrimarySite As String, ByRef GlobalCoNum As String, ByRef GlobalPaymentMethod As String, ByRef GlobalShippingMethod As String, ByRef GlobalAPSMode As String, ByRef GlobalSupportPhone As String, ByRef GlobalHasCCI As Byte?, ByRef GlobalHasFSP As Byte?, ByRef GlobalUserEmailAddress As String, ByRef GlobalCreateUserPrivilege As Byte?, ByRef GlobalIsAdmin As Byte?, ByRef GlobalEnableCategoryBrowsing As Byte?, ByRef GlobalResellerCurrCode As String, ByRef GlobalGroupName As String, ByRef GlobalSuperUserFlag As Byte?, ByRef GlobalB2BCOCustNum As String, ByRef GlobalIsPreLogin As Byte?, ByRef GlobalPricingPreCalculationRule As String, ByRef GlobalPricingDisplayRule As String, ByRef GlobalDisplayPriceOnRequest As Byte?, ByRef GlobalCustomerCatalogRowPointer As Guid?, ByRef GlobalResellerCatalogRowPointer As Guid?, ByRef GlobalPreLoginCatalogRowPointer As Guid?, ByVal MergeCart As Byte?, ByVal ToOrderType As String, ByVal PreLoginCoNum As String, ByVal PostLoginCoNum As String,
<[Optional], DefaultParameterValue("N")> ByRef ConfiguratorUserInterface As String, ByRef Infobar As String) As Integer Implements ISLPortalParms.GetCustPortalUserInfoSp
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
    Public Function GetPortalOrderItemPriceSp(ByVal CurrCode As String, ByVal Item As String, ByVal OrderQtyConv As Decimal?, ByVal GenericIfNoCustSpecific As Byte?, ByVal PricingPrecalRule As String, ByVal ShipFromSite As String, ByVal CustNum As String, ByVal CustItem As String, ByRef CustItemUM As String, ByRef CustPriceConv As Decimal?, ByRef Infobar As String) As Integer Implements ISLPortalParms.GetPortalOrderItemPriceSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetPortalOrderItemPriceExt As IGetPortalOrderItemPrice = New GetPortalOrderItemPriceFactory().Create(appDb)

            Dim Severity As Integer = iGetPortalOrderItemPriceExt.GetPortalOrderItemPriceSp(CurrCode, Item, OrderQtyConv, GenericIfNoCustSpecific, PricingPrecalRule, ShipFromSite, CustNum, CustItem, CustItemUM, CustPriceConv, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function GetResellerCreatedCustomerCOSp(ByVal CustNum As String, ByVal Username As String, ByRef CustSeq As Integer?, ByRef CoRowPointer As Guid?, ByRef CoNum As String, ByRef B2B As Byte?, ByRef CurrCode As String, ByRef CoType As String, ByRef PaymentMethod As String, ByRef ShippingMethod As String, ByRef Infobar As String) As Integer Implements ISLPortalParms.GetResellerCreatedCustomerCOSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iGetResellerCreatedCustomerCOExt As IGetResellerCreatedCustomerCO = New GetResellerCreatedCustomerCOFactory().Create(appDb)

            Dim Severity As Integer = iGetResellerCreatedCustomerCOExt.GetResellerCreatedCustomerCOSp(CustNum, Username, CustSeq, CoRowPointer, CoNum, B2B, CurrCode, CoType, PaymentMethod, ShippingMethod, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function HasPreAndPostLoginCartSp(ByVal CoRowPointer As Guid?, ByRef GlobalCustNum As String, ByRef GlobalUserId As String, ByRef GlobalIsPreLogin As Byte?, ByRef ToOrderType As String, ByRef MergeCart As Byte?, ByRef HasConfig As Byte?, ByRef PreLoginCoNum As String, ByRef PostLoginCoNum As String, ByRef GlobalPrimarySite As String, ByRef Infobar As String) As Integer Implements ISLPortalParms.HasPreAndPostLoginCartSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iHasPreAndPostLoginCartExt As IHasPreAndPostLoginCart = New HasPreAndPostLoginCartFactory().Create(appDb)

            Dim Severity As Integer = iHasPreAndPostLoginCartExt.HasPreAndPostLoginCartSp(CoRowPointer, GlobalCustNum, GlobalUserId, GlobalIsPreLogin, ToOrderType, MergeCart, HasConfig, PreLoginCoNum, PostLoginCoNum, GlobalPrimarySite, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalAccountCorrectionSp(ByVal Username As String, ByVal CustVendNum As String, ByVal Portal As String, ByRef Infobar As String) As Integer Implements ISLPortalParms.PortalAccountCorrectionSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortalAccountCorrectionExt As IPortalAccountCorrection = New PortalAccountCorrectionFactory().Create(appDb)

            Dim Severity As Integer = iPortalAccountCorrectionExt.PortalAccountCorrectionSp(Username, CustVendNum, Portal, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalAccountManagement_1_CanCreateUsersSp(ByVal Username As String, ByVal CustVendNum As String, ByVal Name As String, ByVal Email As String, ByVal Password As String, ByVal DecryptedPassword As String, ByVal AccountType As String, ByVal VendNum As String, ByVal NotifyUser As Byte?, ByVal Primary As String, ByVal CreateUser As Byte?, ByVal PortalURL As String, ByVal LocaleId As Integer?, ByRef Infobar As String, ByVal CanCreateUsers As Byte?, ByVal PreCanCreateUsers As Byte?) As Integer Implements ISLPortalParms.PortalAccountManagement_1_CanCreateUsersSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortalAccountManagement_1_CanCreateUsersExt As IPortalAccountManagement_1_CanCreateUsers = New PortalAccountManagement_1_CanCreateUsersFactory().Create(appDb)

            Dim Severity As Integer = iPortalAccountManagement_1_CanCreateUsersExt.PortalAccountManagement_1_CanCreateUsersSp(Username, CustVendNum, Name, Email, Password, DecryptedPassword, AccountType, VendNum, NotifyUser, Primary, CreateUser, PortalURL, LocaleId, Infobar, CanCreateUsers, PreCanCreateUsers)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalEstimateToHistorySp(ByVal CoNum As String, ByVal pCpFOrdType As String, ByRef Infobar As String) As Integer Implements ISLPortalParms.PortalEstimateToHistorySp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortalEstimateToHistoryExt As IPortalEstimateToHistory = New PortalEstimateToHistoryFactory().Create(appDb)

            Dim Severity As Integer = iPortalEstimateToHistoryExt.PortalEstimateToHistorySp(CoNum, pCpFOrdType, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalOrderStatusChangeSp(ByVal CoNum As String, ByRef Infobar As String) As Integer Implements ISLPortalParms.PortalOrderStatusChangeSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPortalOrderStatusChangeExt As IPortalOrderStatusChange = New PortalOrderStatusChangeFactory().Create(appDb)

            Dim Severity As Integer = iPortalOrderStatusChangeExt.PortalOrderStatusChangeSp(CoNum, Infobar)

            Return Severity
        End Using
    End Function


    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalUpdateOrderLineQuantitiesSp(ByVal CoNum As String,
<[Optional]> ByVal CoLineList As String, ByVal QtyOrderedConvList As String, ByRef Infobar As String) As Integer Implements ISLPortalParms.PortalUpdateOrderLineQuantitiesSp
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
    Public Function PurgeTmpPortalAccountStatusSp(ByVal Portal As String, ByVal Username As String, ByRef Infobar As String) As Integer Implements ISLPortalParms.PurgeTmpPortalAccountStatusSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iPurgeTmpPortalAccountStatusExt As IPurgeTmpPortalAccountStatus = New PurgeTmpPortalAccountStatusFactory().Create(appDb)

            Dim Severity As Integer = iPurgeTmpPortalAccountStatusExt.PurgeTmpPortalAccountStatusSp(Portal, Username, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdatePortalOrderLineSp(ByVal CoNum As String, ByVal CoLine As Short?, ByVal UM As String, ByVal PriceConv As Decimal?, ByRef Infobar As String) As Integer Implements ISLPortalParms.UpdatePortalOrderLineSp
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())

            Dim iUpdatePortalOrderLineExt As IUpdatePortalOrderLine = New UpdatePortalOrderLineFactory().Create(appDb)

            Dim Severity As Integer = iUpdatePortalOrderLineExt.UpdatePortalOrderLineSp(CoNum, CoLine, UM, PriceConv, Infobar)

            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.CustomLoad, "Infobar")>
    Public Function CLM_GetPortalItemPriceSp(ByVal ItemRange As String, ByVal ItemPricingSite As String, ByVal CustNum As String, ByVal ResellerCustNum As String, ByVal CurrCode As String, ByVal IsB2B As Byte?, ByVal Infobar As String) As DataTable Implements ISLPortalParms.CLM_GetPortalItemPriceSp
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
    Public Function CLM_GetPortalOrderItemPriceChangesSp(ByVal CoNum As String, ByVal CurrCode As String, ByVal PrimarySite As String, ByVal ResellerSlsman As String, ByVal PricingPrecalculationRule As String, ByVal GenericIfNoCustSpecific As Byte?, ByRef Infobar As String) As DataTable Implements ISLPortalParms.CLM_GetPortalOrderItemPriceChangesSp
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
            Dim result As (ReturnCode As Integer?, CustNum As String, InfoBar As String) = iCustomerPortalCreateCustomerExt.CustomerPortalCreateCustomerSp(Username, Name, Email, Password, RetypePassword, ResellerSlsman, OrderCurrency, CompanyName, LocaleId, CustNum, PrimarySite, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            CustNum = result.CustNum
            Infobar = result.InfoBar
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
            Dim result As (ReturnCode As Integer?, SiteRef As String, Infobar As String, UsePortalEmail As Integer?, AdminUser As String, PortalURL As String, LocaleID As Integer?) = iGetPortalAlertParmsExt.GetPortalAlertParmsSp(PortalType, SiteRef, Infobar, UsePortalEmail, AdminUser, PortalURL, LocaleID)
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
    Public Function IdentifyCustomerPortalUserTypeSp(ByVal Username As String, ByRef IsBTB As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iIdentifyCustomerPortalUserTypeExt As IIdentifyCustomerPortalUserType = New IdentifyCustomerPortalUserTypeFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, IsBTB As Integer?, InfoBar As String) = iIdentifyCustomerPortalUserTypeExt.IdentifyCustomerPortalUserTypeSp(Username, IsBTB, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            IsBTB = result.IsBTB
            Infobar = result.InfoBar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalAccountCreateOrCopy_1_CanCreateUsersSp(ByVal Username As String, ByVal CustVendNum As String, ByVal Name As String, ByVal Email As String, ByVal NotificationEmail As String, ByVal EmailType As String, ByVal EmailTypeDesc As String, ByVal Password As String, ByVal AccountType As String, ByVal VendNum As String, ByVal SendEmailNotifications As Byte?, ByVal EmailNotificationsEmailType As String, ByVal EmailNotificationsEmailTypeDesc As String, ByVal PrimarySite As String, ByVal Create As Byte?, ByVal LocaleId As Integer?, ByRef Infobar As String, ByVal CanCreateUsers As Byte?, ByVal PreCanCreateUsers As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPortalAccountCreateOrCopy_1_CanCreateUsersExt As IPortalAccountCreateOrCopy_1_CanCreateUsers = New PortalAccountCreateOrCopy_1_CanCreateUsersFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, InfoBar As String) = iPortalAccountCreateOrCopy_1_CanCreateUsersExt.PortalAccountCreateOrCopy_1_CanCreateUsersSp(Username, CustVendNum, Name, Email, NotificationEmail, EmailType, EmailTypeDesc, Password, AccountType, VendNum, SendEmailNotifications, EmailNotificationsEmailType, EmailNotificationsEmailTypeDesc, PrimarySite, Create, LocaleId, Infobar, CanCreateUsers, PreCanCreateUsers)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.InfoBar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalAccountCreateOrCopySp(ByVal Username As String, ByVal CustVendNum As String, ByVal Name As String, ByVal Email As String, ByVal NotificationEmail As String, ByVal EmailType As String, ByVal EmailTypeDesc As String, ByVal Password As String, ByVal AccountType As String, ByVal Slsman As String, ByVal VendNum As String, ByVal SendEmailNotifications As Byte?, ByVal EmailNotificationsEmailType As String, ByVal EmailNotificationsEmailTypeDesc As String, ByVal PrimarySite As String, ByVal Create As Byte?, ByVal ResellerCommission As Decimal?, ByVal LocaleId As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPortalAccountCreateOrCopyExt As IPortalAccountCreateOrCopy = New PortalAccountCreateOrCopyFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, InfoBar As String) = iPortalAccountCreateOrCopyExt.PortalAccountCreateOrCopySp(Username, CustVendNum, Name, Email, NotificationEmail, EmailType, EmailTypeDesc, Password, AccountType, Slsman, VendNum, SendEmailNotifications, EmailNotificationsEmailType, EmailNotificationsEmailTypeDesc, PrimarySite, Create, ResellerCommission, LocaleId, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.InfoBar
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function PortalAccountManagementSp(ByVal Username As String, ByVal CustVendNum As String, ByVal Name As String, ByVal Email As String, ByVal Password As String, ByVal DecryptedPassword As String, ByVal AccountType As String, ByVal Slsman As String, ByVal VendNum As String, ByVal NotifyUser As Byte?, ByVal Primary As String, ByVal CreateUser As Byte?, ByVal PortalURL As String, ByVal ResellerCommission As Decimal?, ByVal LocaleId As Integer?, ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iPortalAccountManagementExt As IPortalAccountManagement = New PortalAccountManagementFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, InfoBar As String) = iPortalAccountManagementExt.PortalAccountManagementSp(Username, CustVendNum, Name, Email, Password, DecryptedPassword, AccountType, Slsman, VendNum, NotifyUser, Primary, CreateUser, PortalURL, ResellerCommission, LocaleId, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.InfoBar
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
            Dim result As (ReturnCode As Integer?, InfoBar As String) = iUserPasswordValidationExt.UserPasswordValidationSp(Username, Password, OldPassword, RetypePassword, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            Infobar = result.InfoBar
            Return Severity
        End Using
    End Function

End Class

