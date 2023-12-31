//PROJECT NAME: Data
//CLASS NAME: IVendorInsUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IVendorInsUpd
	{
		int? VendorInsUpdSp(
			string Vendnum,
			string Contact = null,
			string Phone = null,
			string VendType = null,
			string TermsCode = null,
			string ShipCode = null,
			string FOB = null,
			int? PrintPrice = null,
			string Stat = null,
			DateTime? LastPurch = null,
			DateTime? LastPaid = null,
			decimal? Purchytd = null,
			decimal? PurchLstyr = null,
			decimal? Discytd = null,
			decimal? DiscLstyr = null,
			decimal? Payytd = null,
			string VendRemit = null,
			string Whse = null,
			string Charfld1 = null,
			string Charfld2 = null,
			string Charfld3 = null,
			decimal? Decifld1 = null,
			decimal? Decifld2 = null,
			decimal? Decifld3 = null,
			int? Logifld = null,
			DateTime? Datefld = null,
			string CurrCode = null,
			string BankCode = null,
			string PayType = null,
			decimal? PayLstyr = null,
			string BranchID = null,
			string TransNat = null,
			string DelTerm = null,
			string ProcessInd = null,
			string LangCode = null,
			string PurAcct = null,
			string PurAcctUnit1 = null,
			string PurAcctUnit2 = null,
			string PurAcctUnit3 = null,
			string PurAcctUnit4 = null,
			int? LcrReqd = null,
			string Category = null,
			string Account = null,
			string AccountName = null,
			string EFTBankNum = null,
			string PriceBy = "O",
			int? IncludeTaxInCost = null,
			string Transnat2 = null,
			int? ActiveForDataIntegration = 0,
			decimal? VchOverPOCostTolernace = null,
			decimal? VchUnderPoCostTolerance = null,
			decimal? PayFiscalytd = null,
			decimal? PayLstFiscalyr = null,
			string Name = null,
			string City = null,
			string State = null,
			string Zip = null,
			string County = null,
			string Country = null,
			string FaxNum = null,
			string TelexNum = null,
			string Addr1 = null,
			string Addr2 = null,
			string Addr3 = null,
			string Addr4 = null,
			int? PayHold = null,
			string PayHoldUser = null,
			DateTime? PayHoldDate = null,
			string PayHoldReason = null,
			string InternetEmailURL = null,
			string InternalEmailAddr = null,
			string ExternalEmailAddr = null,
			int? SupplyWebVendor = null,
			int? RequestAcknowledgement = null,
			string DepositAccountType = null,
			int? AutoVoucher = 0,
			string AutoVoucherMethod = null,
			string FlagInsertUpdate = "I",
			Guid? RowPointer = null,
			string Buyer = null,
			int? AllowToFirmPlns = 0,
			string FirmPlnTarget = "R",
			string FirmedPoitemStat = "P",
			string ReplenPoNum = null,
			string TransitReference = null,
			decimal? Misc1099Ytd = null,
			decimal? Misc1099LstYr = null,
			string SourceSite = null,
			string SourceSiteCustNum = null,
			int? AutoReceiveDemaindingSitePO = 0,
			int? AutoShipDemandingSiteCO = 0,
			string VendBank = null,
			string FiscalReportingSystem = null,
			string FiscalReportingSystemType = null,
			string BusinessIdentificationNum = null,
			string Profession = null,
			string EFTFormat = null,
			string BankAuthorityPartyId = null,
			int? ShowInDropDownList = 0,
			int? UseLongName = 0,
			string LongName = null);
	}
}

