//PROJECT NAME: VendorExt
//CLASS NAME: SLAptrxrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;
using CSI.Finance.AP;
using CSI.Logistics.Customer;

namespace CSI.MG.Vendor
{
    [IDOExtensionClass("SLAptrxrs")]
    public class SLAptrxrs : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ApvchgSp(string SVendNum,
                            string EVendNum,
                            int? PNewVoucherMonth,
                            int? PNewVoucherYear,
                            DateTime? PDistDate,
                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iApvchgExt = new ApvchgFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iApvchgExt.ApvchgSp(SVendNum,
                                                   EVendNum,
                                                   PNewVoucherMonth,
                                                   PNewVoucherYear,
                                                   PDistDate,
                                                   ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }








		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VendorGetVoucherNoSp(ref int? RVoucher,
		ref string RRef,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVendorGetVoucherNoExt = new VendorGetVoucherNoFactory().Create(appDb);
				
				var result = iVendorGetVoucherNoExt.VendorGetVoucherNoSp(RVoucher,
				RRef,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				RVoucher = result.RVoucher;
				RRef = result.RRef;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VendorVerifyVoucherNoSp(int? RVoucher,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVendorVerifyVoucherNoExt = new VendorVerifyVoucherNoFactory().Create(appDb);
				
				var result = iVendorVerifyVoucherNoExt.VendorVerifyVoucherNoSp(RVoucher,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}









































		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetChartInfoSp(string pChartAcct,
		ref string rChartType,
		ref string rAccessUnit1,
		ref string rAccessUnit2,
		ref string rAccessUnit3,
		ref string rAccessUnit4,
		ref string rDescription,
		ref string Infobar,
		[Optional] string Site,
		ref int? rIsControl)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetChartInfoExt = new GetChartInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetChartInfoExt.GetChartInfoSp(pChartAcct,
				rChartType,
				rAccessUnit1,
				rAccessUnit2,
				rAccessUnit3,
				rAccessUnit4,
				rDescription,
				Infobar,
				Site,
				rIsControl);
				
				int Severity = result.ReturnCode.Value;
				rChartType = result.rChartType;
				rAccessUnit1 = result.rAccessUnit1;
				rAccessUnit2 = result.rAccessUnit2;
				rAccessUnit3 = result.rAccessUnit3;
				rAccessUnit4 = result.rAccessUnit4;
				rDescription = result.rDescription;
				Infobar = result.Infobar;
				rIsControl = result.rIsControl;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VendorGetRecurVoucherInfoSp(string PVendNum,
		DateTime? PInvoiceDate,
		ref string RTaxCode1,
		ref string RTaxCode1Desc,
		ref string RTaxCode2,
		ref string RTaxCode2Desc,
		ref string RCurrCode,
		ref decimal? RExchRate,
		ref int? RProxCode,
		ref int? RProxDay,
		ref decimal? RDiscPct,
		ref int? RDiscDays,
		ref DateTime? RDiscDate,
		ref int? RDueDays,
		ref DateTime? RDueDate,
		ref string RApAcct,
		ref string RApAcctUnit1,
		ref string RApAcctUnit2,
		ref string RApAcctUnit3,
		ref string RApAcctUnit4,
		ref string RApAcctDesc,
		ref string RTermsCode,
		ref string Infobar,
		ref int? RApAcctIsControl)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iVendorGetRecurVoucherInfoExt = new VendorGetRecurVoucherInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iVendorGetRecurVoucherInfoExt.VendorGetRecurVoucherInfoSp(PVendNum,
				PInvoiceDate,
				RTaxCode1,
				RTaxCode1Desc,
				RTaxCode2,
				RTaxCode2Desc,
				RCurrCode,
				RExchRate,
				RProxCode,
				RProxDay,
				RDiscPct,
				RDiscDays,
				RDiscDate,
				RDueDays,
				RDueDate,
				RApAcct,
				RApAcctUnit1,
				RApAcctUnit2,
				RApAcctUnit3,
				RApAcctUnit4,
				RApAcctDesc,
				RTermsCode,
				Infobar,
				RApAcctIsControl);
				
				int Severity = result.ReturnCode.Value;
				RTaxCode1 = result.RTaxCode1;
				RTaxCode1Desc = result.RTaxCode1Desc;
				RTaxCode2 = result.RTaxCode2;
				RTaxCode2Desc = result.RTaxCode2Desc;
				RCurrCode = result.RCurrCode;
				RExchRate = result.RExchRate;
				RProxCode = result.RProxCode;
				RProxDay = result.RProxDay;
				RDiscPct = result.RDiscPct;
				RDiscDays = result.RDiscDays;
				RDiscDate = result.RDiscDate;
				RDueDays = result.RDueDays;
				RDueDate = result.RDueDate;
				RApAcct = result.RApAcct;
				RApAcctUnit1 = result.RApAcctUnit1;
				RApAcctUnit2 = result.RApAcctUnit2;
				RApAcctUnit3 = result.RApAcctUnit3;
				RApAcctUnit4 = result.RApAcctUnit4;
				RApAcctDesc = result.RApAcctDesc;
				RTermsCode = result.RTermsCode;
				Infobar = result.Infobar;
				RApAcctIsControl = result.RApAcctIsControl;
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
    }
}
