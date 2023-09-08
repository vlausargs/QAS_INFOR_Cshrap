//PROJECT NAME: VendorExt
//CLASS NAME: SLVchPRs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Data.SQL;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.FieldService;
using CSI.Data.RecordSets;
using CSI.Logistics.Customer;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLVchPRs")]
	public class SLVchPRs : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetVchPrSp(int? PPreRegister,
		                      string PVendNum,
		                      ref decimal? RPurchAmt,
		                      ref decimal? RFreight,
		                      ref decimal? RMiscCharges,
		                      ref decimal? RSalesTax,
		                      ref decimal? RSalesTax2,
		                      ref string RInvNum,
		                      ref DateTime? RInvDate,
		                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetVchPrExt = new GetVchPrFactory().Create(appDb);
				
				int Severity = iGetVchPrExt.GetVchPrSp(PPreRegister,
				                                       PVendNum,
				                                       ref RPurchAmt,
				                                       ref RFreight,
				                                       ref RMiscCharges,
				                                       ref RSalesTax,
				                                       ref RSalesTax2,
				                                       ref RInvNum,
				                                       ref RInvDate,
				                                       ref Infobar);
				
				return Severity;
			}
		}







		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VoucherPreRegisterVerifyInvSp(string PVendNum,
		string PInvNum,
		ref string PromptMsg,
		ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVoucherPreRegisterVerifyInvExt = new VoucherPreRegisterVerifyInvFactory().Create(appDb);
				
				var result = iVoucherPreRegisterVerifyInvExt.VoucherPreRegisterVerifyInvSp(PVendNum,
				PInvNum,
				PromptMsg,
				PromptButtons);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}








































		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VchPrDelSp(int? BegPreRegister,
		int? EndPreRegister,
		string BegVendNum,
		string EndVendNum,
		DateTime? BegVchDate,
		DateTime? EndVchDate,
		int? DateNulChk,
		ref string Infobar,
		[Optional] int? StartingVoucherDateOffset,
		[Optional] int? EndingVoucherDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iVchPrDelExt = new VchPrDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iVchPrDelExt.VchPrDelSp(BegPreRegister,
				EndPreRegister,
				BegVendNum,
				EndVendNum,
				BegVchDate,
				EndVchDate,
				DateNulChk,
				Infobar,
				StartingVoucherDateOffset,
				EndingVoucherDateOffset);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}






























		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_DomesticCurrencySp(string CurrCode,
		[Optional, DefaultParameterValue(0)] int? UseBuyRate,
		[Optional] decimal? TRate,
		[Optional] DateTime? PossibleDate,
		[Optional] decimal? Amount1,
		[Optional] decimal? Amount2,
		[Optional] decimal? Amount3,
		[Optional] decimal? Amount4,
		[Optional] decimal? Amount5,
		[Optional] decimal? Amount6,
		[Optional] decimal? Amount7,
		[Optional] decimal? Amount8,
		[Optional] decimal? Amount9,
		[Optional] decimal? Amount10,
		[Optional] decimal? Amount11,
		[Optional] decimal? Amount12,
		[Optional] decimal? Amount13,
		[Optional] decimal? Amount14,
		[Optional] decimal? Amount15,
		[Optional] decimal? Amount16,
		[Optional] decimal? Amount17,
		[Optional] decimal? Amount18,
		[Optional] decimal? Amount19,
		[Optional] decimal? Amount20,
		[Optional] decimal? Amount21,
		[Optional] decimal? Amount22,
		[Optional] decimal? Amount23,
		[Optional] decimal? Amount24,
		[Optional] decimal? Amount25,
		[Optional] decimal? Amount26,
		[Optional] decimal? Amount27,
		[Optional] decimal? Amount28,
		[Optional] decimal? Amount29,
		[Optional] decimal? Amount30,
		[Optional] decimal? Amount31,
		[Optional] decimal? Amount32,
		[Optional] decimal? Amount33,
		[Optional] decimal? Amount34,
		[Optional] decimal? Amount35,
		[Optional] decimal? Amount36,
		[Optional] decimal? Amount37,
		[Optional] decimal? Amount38,
		[Optional] decimal? Amount39,
		[Optional] decimal? Amount40)
		{
			var iCLM_DomesticCurrencyExt = new CLM_DomesticCurrencyFactory().Create(this, true);
				
			var result = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode,
				UseBuyRate,
				TRate,
				PossibleDate,
				Amount1,
				Amount2,
				Amount3,
				Amount4,
				Amount5,
				Amount6,
				Amount7,
				Amount8,
				Amount9,
				Amount10,
				Amount11,
				Amount12,
				Amount13,
				Amount14,
				Amount15,
				Amount16,
				Amount17,
				Amount18,
				Amount19,
				Amount20,
				Amount21,
				Amount22,
				Amount23,
				Amount24,
				Amount25,
				Amount26,
				Amount27,
				Amount28,
				Amount29,
				Amount30,
				Amount31,
				Amount32,
				Amount33,
				Amount34,
				Amount35,
				Amount36,
				Amount37,
				Amount38,
				Amount39,
				Amount40);
				
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CurrCnvtSingleValueSp(string CurrCode,
		int? FromDomestic,
		int? UseBuyRate,
		int? RoundResult,
		[Optional] DateTime? RateDate,
		[Optional] int? RoundPlaces,
		[Optional, DefaultParameterValue("currate")] string BRateTable,
		[Optional] int? ForceRate,
		[Optional] int? FindTTFixed,
		[Optional] ref decimal? TRate,
		ref string Infobar,
		decimal? Amount,
		ref decimal? Result,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCurrCnvtSingleValueExt = new CurrCnvtSingleValueFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCurrCnvtSingleValueExt.CurrCnvtSingleValueSp(CurrCode,
				FromDomestic,
				UseBuyRate,
				RoundResult,
				RateDate,
				RoundPlaces,
				BRateTable,
				ForceRate,
				FindTTFixed,
				TRate,
				Infobar,
				Amount,
				Result,
				Site);
				
				int Severity = result.ReturnCode.Value;
				TRate = result.TRate;
				Infobar = result.Infobar;
				Result = result.Result;
				return Severity;
			}
		}
	}
}
