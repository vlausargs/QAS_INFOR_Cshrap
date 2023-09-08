//PROJECT NAME: VendorExt
//CLASS NAME: SLGenAPTransFilterString.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Logistics.Customer;

namespace CSI.MG.Vendor
{
	[IDOExtensionClass("SLGenAPTransFilterString")]
	public class SLGenAPTransFilterString : CSIExtensionClassBase
	{
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int FindVendorAndCurrencyByPOSp(string PoNum,
			ref string VendNum,
			ref string CurrCode)
        {
            var iFindVendorAndCurrencyByPOExt = new FindVendorAndCurrencyByPOFactory().Create(this, true);

            var result = iFindVendorAndCurrencyByPOExt.FindVendorAndCurrencyByPOSp(PoNum,
            VendNum,
            CurrCode);

            VendNum = result.VendNum;
            CurrCode = result.CurrCode;

            return result.ReturnCode ?? 0;
        }






        [IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateVoucherSp(string PVendNum,
		int? PVoucher,
		[Optional] string SiteRef,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateVoucherExt = new ValidateVoucherFactory().Create(appDb);
				
				var result = iValidateVoucherExt.ValidateVoucherSp(PVendNum,
				PVoucher,
				SiteRef,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}







































		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PoapGenSp(string PVendNum,
		string PVchAdj,
		int? PVoucher,
		DateTime? PDistDate,
		int? PIsEdi,
		int? PSeqNum,
		int? PPreRegister,
		decimal? PPurchAmt,
		decimal? PFreight,
		decimal? PMiscCharges,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		string PInvNum,
		DateTime? PInvDate,
		string PTermsCode,
		string PAuthorizer,
		int? PFixedRate,
		decimal? PExchRate,
		string PFormTitle,
		[Optional] string CalledFrom,
		[Optional] Guid? PProcessId,
		int? PAutoVoucher,
		ref int? PoVoucher,
		ref string Infobar,
		[Optional] string CurrCode,
		[Optional] DateTime? PTaxDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPoapGenExt = new PoapGenFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPoapGenExt.PoapGenSp(PVendNum,
				PVchAdj,
				PVoucher,
				PDistDate,
				PIsEdi,
				PSeqNum,
				PPreRegister,
				PPurchAmt,
				PFreight,
				PMiscCharges,
				PSalesTax,
				PSalesTax2,
				PInvNum,
				PInvDate,
				PTermsCode,
				PAuthorizer,
				PFixedRate,
				PExchRate,
				PFormTitle,
				CalledFrom,
				PProcessId,
				PAutoVoucher,
				PoVoucher,
				Infobar,
				CurrCode,
				PTaxDate);
				
				int Severity = result.ReturnCode.Value;
				PoVoucher = result.PoVoucher;
				Infobar = result.Infobar;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable VendorSharedSitesSp([Optional] string SiteFilter)
		{
			var iVendorSharedSitesExt = new VendorSharedSitesFactory().Create(this, true);
				
			var result = iVendorSharedSitesExt.VendorSharedSitesSp(SiteFilter);
				
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
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
	}
}
