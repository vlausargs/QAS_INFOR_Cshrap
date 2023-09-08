using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface ISLPortalParms
    {
        int AddToPortalOrderSp(string CoCustNum, DateTime? CoOrderDate, string CoWhse, byte? CoConsignment, string ColItem, string ColUM, decimal? ColQtyOrdered, string CoShipFromSite, decimal? ItemPriceConv, string PortalUsername, DateTime? ColProjectedDate, DateTime? ColDueDate, DateTime? ColPromiseDate, ref int? CoCustSeq, ref string CoType, ref Guid? CoRowPointer, ref string CoNum, ref string PaymentMethod, ref string CurrCode, ref string ShippingMethod, ref int? CoLine, ref Guid? CoLineRowPointer, ref int? ItemNotPriced, ref string ItmAutoJob, ref string CfgModel, ref string CustName, ref int? B2B, ref Guid? CatalogRowPointer, ref string Infobar);

        int ClearTrackRowsSp(Guid? SessionID, string TrackedOperType, ref string Infobar);

        int CreatePortalUserEmailAddressSp(string Username, string Email, ref string Infobar);

        int CustomerPortalCreateCustomer_1_CanCreateUsersSp(string Username, string Name, string Email, string Password, string RetypePassword, string ResellerSlsman, string OrderCurrency, string CompanyName, int? LocaleId, ref string CustNum, string PrimarySite, ref string Infobar, byte? CanCreateUsers, byte? PreCanCreateUsers);

        int CustomerPortalCreateCustomerShipToSp(string CustNum, ref string CustSeq, string Name, string Addr1, string Addr2, string Addr3, string Addr4, string City, string County, string State, string PostalCode, string Country, string ResellerSlsman, string ShipToContactName, string ShipToContactPhone, string ShipToContactFax, string ShipToContactEmail, int? PrimarySiteFlag, int? BillToFlag, int? AddressChanged, ref string Infobar);

        int CustSpecificUnitPriceExistsSp(string CurrCode, string CustNum, string Item, ref int? CustSpecificUnitPriceExists, ref string Infobar);

        int GetCustPortalCoRowPointerSp(string CustNum, string EstCoNum, ref string CoNum, ref Guid? CoRowPointer, ref string Infobar);

        int GetCustPortalOrderInfoSp(string CustNum, byte? ResellerPortalFlag, string ResellerCustNum, ref Guid? CoRowPointer, ref int? CustSeq, ref string CustName, ref byte? B2B, ref string CoType, ref string CurrCode, ref string CoNum, ref string PaymentMethod, ref string ShippingMethod, ref Guid? CustomerCatalogRowPointer, ref decimal? SubTotal, ref decimal? SalesTax, ref decimal? ShippingCost, ref int? ItemCnt, ref decimal? CommissionAmountTotal, ref string Infobar);

        int GetCustPortalUserInfoSp(ref Guid? CoRowPointer, ref string GlobalCustNum, ref int? GlobalCustSeq, ref string GlobalCustName, ref byte? GlobalB2B, ref string GlobalCoType, ref string GlobalUserId, ref string GlobalUserDesc, ref string GlobalCurrCode, ref string GlobalResellerCustNum, ref string GlobalResellerSlsman, ref string GlobalPrimarySite, ref string GlobalCoNum, ref string GlobalPaymentMethod, ref string GlobalShippingMethod, ref string GlobalAPSMode, ref string GlobalSupportPhone, ref byte? GlobalHasCCI, ref byte? GlobalHasFSP, ref string GlobalUserEmailAddress, ref byte? GlobalCreateUserPrivilege, ref byte? GlobalIsAdmin, ref byte? GlobalEnableCategoryBrowsing, ref string GlobalResellerCurrCode, ref string GlobalGroupName, ref byte? GlobalSuperUserFlag, ref string GlobalB2BCOCustNum, ref byte? GlobalIsPreLogin, ref string GlobalPricingPreCalculationRule, ref string GlobalPricingDisplayRule, ref byte? GlobalDisplayPriceOnRequest, ref Guid? GlobalCustomerCatalogRowPointer, ref Guid? GlobalResellerCatalogRowPointer, ref Guid? GlobalPreLoginCatalogRowPointer, byte? MergeCart, string ToOrderType, string PreLoginCoNum, string PostLoginCoNum, ref string ConfiguratorUserInterface, ref string Infobar);

        int GetPortalOrderItemPriceSp(string CurrCode, string Item, decimal? OrderQtyConv, byte? GenericIfNoCustSpecific, string PricingPrecalRule, string ShipFromSite, string CustNum, string CustItem, ref string CustItemUM, ref decimal? CustPriceConv, ref string Infobar);

        int GetResellerCreatedCustomerCOSp(string CustNum, string Username, ref int? CustSeq, ref Guid? CoRowPointer, ref string CoNum, ref byte? B2B, ref string CurrCode, ref string CoType, ref string PaymentMethod, ref string ShippingMethod, ref string Infobar);

        int HasPreAndPostLoginCartSp(Guid? CoRowPointer, ref string GlobalCustNum, ref string GlobalUserId, ref byte? GlobalIsPreLogin, ref string ToOrderType, ref byte? MergeCart, ref byte? HasConfig, ref string PreLoginCoNum, ref string PostLoginCoNum, ref string GlobalPrimarySite, ref string Infobar);

        int PortalAccountCorrectionSp(string Username, string CustVendNum, string Portal, ref string Infobar);

        int PortalAccountManagement_1_CanCreateUsersSp(string Username, string CustVendNum, string Name, string Email, string Password, string DecryptedPassword, string AccountType, string VendNum, byte? NotifyUser, string Primary, byte? CreateUser, string PortalURL, int? LocaleId, ref string Infobar, byte? CanCreateUsers, byte? PreCanCreateUsers);

        int PortalEstimateToHistorySp(string CoNum, string pCpFOrdType, ref string Infobar);

        int PortalOrderStatusChangeSp(string CoNum, ref string Infobar);

        int PortalUpdateOrderLineQuantitiesSp(string CoNum, string CoLineList, string QtyOrderedConvList, ref string Infobar);

        int PurgeTmpPortalAccountStatusSp(string Portal, string Username, ref string Infobar);

        int UpdatePortalOrderLineSp(string CoNum, short? CoLine, string UM, decimal? PriceConv, ref string Infobar);

        System.Data.DataTable CLM_GetPortalItemPriceSp(string ItemRange, string ItemPricingSite, string CustNum, string ResellerCustNum, string CurrCode, byte? IsB2B, string Infobar);

        System.Data.DataTable CLM_GetPortalOrderItemPriceChangesSp(string CoNum, string CurrCode, string PrimarySite, string ResellerSlsman, string PricingPrecalculationRule, byte? GenericIfNoCustSpecific, ref string Infobar);
    }
}
