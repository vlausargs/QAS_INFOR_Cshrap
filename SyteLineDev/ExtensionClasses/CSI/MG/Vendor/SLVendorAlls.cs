//PROJECT NAME: VendorExt
//CLASS NAME: SLVendorAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLVendorAlls")]
	public class SLVendorAlls : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetAPAgingInfoBySiteGroupSp(string PVendNum,
		                                       string PCurrCode,
		                                       byte? PTransDom,
		                                       byte? PSiteQuery,
		                                       string PSiteGroup,
		                                       ref string PAgeDesc1,
		                                       ref string PAgeDesc2,
		                                       ref string PAgeDesc3,
		                                       ref string PAgeDesc4,
		                                       ref string PAgeDesc5,
		                                       ref decimal? PAgeBal1,
		                                       ref decimal? PAgeBal2,
		                                       ref decimal? PAgeBal3,
		                                       ref decimal? PAgeBal4,
		                                       ref decimal? PAgeBal5,
		                                       ref decimal? PAgeBal6,
		                                       ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetAPAgingInfoBySiteGroupExt = new GetAPAgingInfoBySiteGroupFactory().Create(appDb);
				
				int Severity = iGetAPAgingInfoBySiteGroupExt.GetAPAgingInfoBySiteGroupSp(PVendNum,
				                                                                         PCurrCode,
				                                                                         PTransDom,
				                                                                         PSiteQuery,
				                                                                         PSiteGroup,
				                                                                         ref PAgeDesc1,
				                                                                         ref PAgeDesc2,
				                                                                         ref PAgeDesc3,
				                                                                         ref PAgeDesc4,
				                                                                         ref PAgeDesc5,
				                                                                         ref PAgeBal1,
				                                                                         ref PAgeBal2,
				                                                                         ref PAgeBal3,
				                                                                         ref PAgeBal4,
				                                                                         ref PAgeBal5,
				                                                                         ref PAgeBal6,
				                                                                         ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetDefaultsForSiteSp(string Site,
		                                ref string CurrCode,
		                                ref decimal? VchrToleranceOver,
		                                ref decimal? VchrToleranceUnder,
		                                ref byte? VchrAuthorize,
		                                ref string EFTBankCode,
		                                ref byte? EcReporting,
		                                ref string EFTFormat)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetDefaultsForSiteExt = new GetDefaultsForSiteFactory().Create(appDb);
				
				int Severity = iGetDefaultsForSiteExt.GetDefaultsForSiteSp(Site,
				                                                           ref CurrCode,
				                                                           ref VchrToleranceOver,
				                                                           ref VchrToleranceUnder,
				                                                           ref VchrAuthorize,
				                                                           ref EFTBankCode,
				                                                           ref EcReporting,
				                                                           ref EFTFormat);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int IsVendorDeactivationValidAllSp(string VendNum,
		[Optional, DefaultParameterValue(1)] int? Active,
		string SiteRef,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iIsVendorDeactivationValidAllExt = new IsVendorDeactivationValidAllFactory().Create(appDb);
				
				var result = iIsVendorDeactivationValidAllExt.IsVendorDeactivationValidAllSp(VendNum,
				Active,
				SiteRef,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidatePayTypeAllSp(string EntityPayType,
		string EntityCurrCode,
		string EntityBankCode,
		string Site,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidatePayTypeAllExt = new ValidatePayTypeAllFactory().Create(appDb);
				
				var result = iValidatePayTypeAllExt.ValidatePayTypeAllSp(EntityPayType,
				EntityCurrCode,
				EntityBankCode,
				Site,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VendorInsUpdRemCallSP(string Site,
		ref string Vendnum,
		[Optional] string Contact,
		[Optional] string Phone,
		[Optional] string VendType,
		[Optional] string TermsCode,
		[Optional] string ShipCode,
		[Optional] string FOB,
		[Optional] int? PrintPrice,
		[Optional] string Stat,
		[Optional] DateTime? LastPurch,
		[Optional] DateTime? LastPaid,
		[Optional] decimal? Purchytd,
		[Optional] decimal? PurchLstyr,
		[Optional] decimal? Discytd,
		[Optional] decimal? DiscLstyr,
		[Optional] decimal? Payytd,
		[Optional] string VendRemit,
		[Optional] string Whse,
		[Optional] string Charfld1,
		[Optional] string Charfld2,
		[Optional] string Charfld3,
		[Optional] decimal? Decifld1,
		[Optional] decimal? Decifld2,
		[Optional] decimal? Decifld3,
		[Optional] int? Logifld,
		[Optional] DateTime? Datefld,
		[Optional] string CurrCode,
		[Optional] string BankCode,
		[Optional] string PayType,
		[Optional] decimal? PayLstyr,
		[Optional] string BranchID,
		[Optional] string TransNat,
		[Optional] string DelTerm,
		[Optional] string ProcessInd,
		[Optional] string LangCode,
		[Optional] string PurAcct,
		[Optional] string PurAcctUnit1,
		[Optional] string PurAcctUnit2,
		[Optional] string PurAcctUnit3,
		[Optional] string PurAcctUnit4,
		[Optional] int? LcrReqd,
		[Optional] string Category,
		[Optional] string Account,
		[Optional] string AccountName,
		[Optional] string EFTBankNum,
		[Optional, DefaultParameterValue("O")] string PriceBy,
		[Optional] int? IncludeTaxInCost,
		[Optional] string Transnat2,
		[Optional, DefaultParameterValue(0)] int? ActiveForDataIntegration,
		[Optional] decimal? VchOverPOCostTolernace,
		[Optional] decimal? VchUnderPoCostTolerance,
		[Optional] decimal? PayFiscalytd,
		[Optional] decimal? PayLstFiscalyr,
		[Optional] string Name,
		[Optional] string City,
		[Optional] string State,
		[Optional] string Zip,
		[Optional] string County,
		[Optional] string Country,
		[Optional] string FaxNum,
		[Optional] string TelexNum,
		[Optional] string Addr1,
		[Optional] string Addr2,
		[Optional] string Addr3,
		[Optional] string Addr4,
		[Optional] int? PayHold,
		[Optional] string PayHoldUser,
		[Optional] DateTime? PayHoldDate,
		[Optional] string PayHoldReason,
		[Optional] string InternetEmailURL,
		[Optional] string InternalEmailAddr,
		[Optional] string ExternalEmailAddr,
		[Optional, DefaultParameterValue(0)] int? SupplyWebVendor,
		[Optional, DefaultParameterValue(0)] int? RequestAcknowledgement,
		[Optional] string DepositAccountType,
		[Optional, DefaultParameterValue(0)] int? AutoVoucher,
		[Optional] string AutoVoucherMethod,
		[Optional, DefaultParameterValue("I")] string FlagInsertUpdate,
		[Optional] string Buyer,
		[Optional, DefaultParameterValue(0)] int? AllowToFirmPlns,
		[Optional, DefaultParameterValue("R")] string FirmPlnTarget,
		[Optional, DefaultParameterValue("P")] string FirmedPoitemStat,
		[Optional] string ReplenPoNum,
		[Optional] string TransitReference,
		[Optional] decimal? Misc1099Ytd,
		[Optional] decimal? Misc1099LstYr,
		[Optional] string SourceSite,
		[Optional] string SourceSiteCustNum,
		[Optional, DefaultParameterValue(0)] int? AutoReceiveDemaindingSitePO,
		[Optional, DefaultParameterValue(0)] int? AutoShipDemandingSiteCO,
		[Optional] ref string Infobar,
		[Optional] string VendBank,
		[Optional] string FiscalReportingSystem,
		[Optional] string FiscalReportingSystemType,
		[Optional] string BusinessIdentificationNum,
		[Optional] string Profession,
		[Optional] string EFTFormat,
		[Optional] string BankAuthorityPartyId,
		[Optional, DefaultParameterValue(0)] int? ShowInDropDownList,
		[Optional, DefaultParameterValue(0)] int? UseLongName,
		[Optional] string LongName,
		[Optional] string VenBankTransitNum,
		[Optional] int? OverrideBankTransitNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iVendorInsUpdRemCallExt = new VendorInsUpdRemCallFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iVendorInsUpdRemCallExt.VendorInsUpdRemCallSP(Site,
				Vendnum,
				Contact,
				Phone,
				VendType,
				TermsCode,
				ShipCode,
				FOB,
				PrintPrice,
				Stat,
				LastPurch,
				LastPaid,
				Purchytd,
				PurchLstyr,
				Discytd,
				DiscLstyr,
				Payytd,
				VendRemit,
				Whse,
				Charfld1,
				Charfld2,
				Charfld3,
				Decifld1,
				Decifld2,
				Decifld3,
				Logifld,
				Datefld,
				CurrCode,
				BankCode,
				PayType,
				PayLstyr,
				BranchID,
				TransNat,
				DelTerm,
				ProcessInd,
				LangCode,
				PurAcct,
				PurAcctUnit1,
				PurAcctUnit2,
				PurAcctUnit3,
				PurAcctUnit4,
				LcrReqd,
				Category,
				Account,
				AccountName,
				EFTBankNum,
				PriceBy,
				IncludeTaxInCost,
				Transnat2,
				ActiveForDataIntegration,
				VchOverPOCostTolernace,
				VchUnderPoCostTolerance,
				PayFiscalytd,
				PayLstFiscalyr,
				Name,
				City,
				State,
				Zip,
				County,
				Country,
				FaxNum,
				TelexNum,
				Addr1,
				Addr2,
				Addr3,
				Addr4,
				PayHold,
				PayHoldUser,
				PayHoldDate,
				PayHoldReason,
				InternetEmailURL,
				InternalEmailAddr,
				ExternalEmailAddr,
				SupplyWebVendor,
				RequestAcknowledgement,
				DepositAccountType,
				AutoVoucher,
				AutoVoucherMethod,
				FlagInsertUpdate,
				Buyer,
				AllowToFirmPlns,
				FirmPlnTarget,
				FirmedPoitemStat,
				ReplenPoNum,
				TransitReference,
				Misc1099Ytd,
				Misc1099LstYr,
				SourceSite,
				SourceSiteCustNum,
				AutoReceiveDemaindingSitePO,
				AutoShipDemandingSiteCO,
				Infobar,
				VendBank,
				FiscalReportingSystem,
				FiscalReportingSystemType,
				BusinessIdentificationNum,
				Profession,
				EFTFormat,
				BankAuthorityPartyId,
				ShowInDropDownList,
				UseLongName,
				LongName,
				VenBankTransitNum,
				OverrideBankTransitNum);
				
				int Severity = result.ReturnCode.Value;
				Vendnum = result.Vendnum;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetAverageVendOnTimeDelPercentSp(string pVendNum,
		int? pNumberOfMonths,
		ref decimal? pAverageOnTimeDelPercent)
		{
			var iGetAverageVendOnTimeDelPercentExt = new GetAverageVendOnTimeDelPercentFactory().Create(this, true);
			
			var result = iGetAverageVendOnTimeDelPercentExt.GetAverageVendOnTimeDelPercentSp(pVendNum,
			pNumberOfMonths,
			pAverageOnTimeDelPercent);
			
			int Severity = result.ReturnCode.Value;
			pAverageOnTimeDelPercent = result.pAverageOnTimeDelPercent;
			return Severity;
		}

	}
}
