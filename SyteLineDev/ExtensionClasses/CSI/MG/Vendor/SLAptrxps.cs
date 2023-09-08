//PROJECT NAME: VendorExt
//CLASS NAME: SLAptrxps.cs

using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Vendor;
using CSI.MG;
using CSI.Data.SQL.UDDT;
using CSI.Finance.AP;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Logistics.Customer;

namespace CSI.MG.Vendor
{
    [IDOExtensionClass("SLAptrxps")]
    public class SLAptrxps : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable ApcmprSp(DateTime? ThruDate,
                                  string BVendNum,
                                  string EVendNum,
                                  byte? PurgeNonAP,
                                  byte? Commit)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iApcmprExt = new ApcmprFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iApcmprExt.ApcmprSp(ThruDate,
                                                   BVendNum,
                                                   EVendNum,
                                                   PurgeNonAP,
                                                   Commit);

                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int APVchAdjDetailSp(string VendNum,
                                    int? Voucher,
                                    string Type,
                                    ref string PoNum,
                                    ref string InvNum,
                                    ref int? DueDays,
                                    ref byte? ProxDay,
                                    ref DateTime? DueDate,
                                    ref int? DiscDays,
                                    ref DateTime? DiscDate,
                                    ref decimal? DiscPct,
                                    ref string ApAcct,
                                    ref string ApAcctUnit1,
                                    ref string ApAcctUnit2,
                                    ref string ApAcctUnit3,
                                    ref string ApAcctUnit4,
                                    ref string TaxCode1,
                                    ref string TaxCode2,
                                    ref string CurrCode,
                                    ref decimal? ExchRate,
                                    ref byte? FixedRate,
                                    ref string GrnNum,
                                    ref string ChartDescription,
                                    ref string BuilderPoOrigSite,
                                    ref string BuilderPoNum,
                                    ref string BuilderVoucherOrigSite,
                                    ref string BuilderVoucher,
                                    ref string Infobar,
                                    ref DateTime? TaxDate)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAPVchAdjDetailExt = new APVchAdjDetailFactory().Create(appDb);

                PoNumType oPoNum = PoNum;
                VendInvNumType oInvNum = InvNum;
                DueDaysType oDueDays = DueDays;
                ProxDayType oProxDay = ProxDay;
                DateType oDueDate = DueDate;
                DiscDaysType oDiscDays = DiscDays;
                DateType oDiscDate = DiscDate;
                ApDiscType oDiscPct = DiscPct;
                AcctType oApAcct = ApAcct;
                UnitCode1Type oApAcctUnit1 = ApAcctUnit1;
                UnitCode2Type oApAcctUnit2 = ApAcctUnit2;
                UnitCode3Type oApAcctUnit3 = ApAcctUnit3;
                UnitCode4Type oApAcctUnit4 = ApAcctUnit4;
                TaxCodeType oTaxCode1 = TaxCode1;
                TaxCodeType oTaxCode2 = TaxCode2;
                CurrCodeType oCurrCode = CurrCode;
                ExchRateType oExchRate = ExchRate;
                ListYesNoType oFixedRate = FixedRate;
                GrnNumType oGrnNum = GrnNum;
                DescriptionType oChartDescription = ChartDescription;
                SiteType oBuilderPoOrigSite = BuilderPoOrigSite;
                BuilderPoNumType oBuilderPoNum = BuilderPoNum;
                SiteType oBuilderVoucherOrigSite = BuilderVoucherOrigSite;
                BuilderVoucherType oBuilderVoucher = BuilderVoucher;
                InfobarType oInfobar = Infobar;
                DateType oTaxDate = TaxDate;

                int Severity = iAPVchAdjDetailExt.APVchAdjDetailSp(VendNum,
                                                                   Voucher,
                                                                   Type,
                                                                   ref oPoNum,
                                                                   ref oInvNum,
                                                                   ref oDueDays,
                                                                   ref oProxDay,
                                                                   ref oDueDate,
                                                                   ref oDiscDays,
                                                                   ref oDiscDate,
                                                                   ref oDiscPct,
                                                                   ref oApAcct,
                                                                   ref oApAcctUnit1,
                                                                   ref oApAcctUnit2,
                                                                   ref oApAcctUnit3,
                                                                   ref oApAcctUnit4,
                                                                   ref oTaxCode1,
                                                                   ref oTaxCode2,
                                                                   ref oCurrCode,
                                                                   ref oExchRate,
                                                                   ref oFixedRate,
                                                                   ref oGrnNum,
                                                                   ref oChartDescription,
                                                                   ref oBuilderPoOrigSite,
                                                                   ref oBuilderPoNum,
                                                                   ref oBuilderVoucherOrigSite,
                                                                   ref oBuilderVoucher,
                                                                   ref oInfobar,
                                                                   ref oTaxDate);

                PoNum = oPoNum;
                InvNum = oInvNum;
                DueDays = oDueDays;
                ProxDay = oProxDay;
                DueDate = oDueDate;
                DiscDays = oDiscDays;
                DiscDate = oDiscDate;
                DiscPct = oDiscPct;
                ApAcct = oApAcct;
                ApAcctUnit1 = oApAcctUnit1;
                ApAcctUnit2 = oApAcctUnit2;
                ApAcctUnit3 = oApAcctUnit3;
                ApAcctUnit4 = oApAcctUnit4;
                TaxCode1 = oTaxCode1;
                TaxCode2 = oTaxCode2;
                CurrCode = oCurrCode;
                ExchRate = oExchRate;
                FixedRate = oFixedRate;
                GrnNum = oGrnNum;
                ChartDescription = oChartDescription;
                BuilderPoOrigSite = oBuilderPoOrigSite;
                BuilderPoNum = oBuilderPoNum;
                BuilderVoucherOrigSite = oBuilderVoucherOrigSite;
                BuilderVoucher = oBuilderVoucher;
                Infobar = oInfobar;
                TaxDate = oTaxDate;

                return Severity;
            }
        }




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApActSp(byte? ActivateDeactivate,
		                   string StartingVendor,
		                   string EndingVendor,
		                   DateTime? StartingLastActDate,
		                   DateTime? EndingLastActDate,
		                   DateTime? StartingInvoiceDate,
		                   DateTime? EndingInvoiceDate,
		                   byte? AffectNonAPPayments,
		                   ref string Infobar,
		                   [Optional] decimal? UserID,
		                   [Optional] int? BGTaskID,
		                   [Optional, DefaultParameterValue((byte)0)] byte? ReturnCounts,
		[Optional, DefaultParameterValue((byte)0)] byte? CountOnly,
		[Optional, DefaultParameterValue(0)] ref int? ActiveCount,
		[Optional, DefaultParameterValue(0)] ref int? InactiveCount)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApActExt = new ApActFactory().Create(appDb);
				
				var result = iApActExt.ApActSp(ActivateDeactivate,
				                               StartingVendor,
				                               EndingVendor,
				                               StartingLastActDate,
				                               EndingLastActDate,
				                               StartingInvoiceDate,
				                               EndingInvoiceDate,
				                               AffectNonAPPayments,
				                               Infobar,
				                               UserID,
				                               BGTaskID,
				                               ReturnCounts,
				                               CountOnly,
				                               ActiveCount,
				                               InactiveCount);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				ActiveCount = result.ActiveCount;
				InactiveCount = result.InactiveCount;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_APBalanceSp(int? FiscalYear,
            int? Period,
            string SiteGroup,
            [Optional] string FilterString,
            ref string Infobar)
        {
            var iCLM_APBalanceExt = new CLM_APBalanceFactory().Create(this, true);

            var result = iCLM_APBalanceExt.CLM_APBalanceSp(FiscalYear,
                Period,
                SiteGroup,
                FilterString,
                Infobar);

            Infobar = result.Infobar;

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int VoucherValidSp(int? Voucher,
		string VendNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVoucherValidExt = new VoucherValidFactory().Create(appDb);
				
				var result = iVoucherValidExt.VoucherValidSp(Voucher,
				VendNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}






































		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenerateTHAWHTFileSp(string THAWHTList,
		string THAWHTSeqList,
		DateTime? LastWHTDate,
		string WHTType,
		[Optional] ref string WHTFileName,
		[Optional] ref string WHTContent,
		[Optional] ref string WHTExportLogicalFolder,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGenerateTHAWHTFileExt = new GenerateTHAWHTFileFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGenerateTHAWHTFileExt.GenerateTHAWHTFileSp(THAWHTList,
				THAWHTSeqList,
				LastWHTDate,
				WHTType,
				WHTFileName,
				WHTContent,
				WHTExportLogicalFolder,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				WHTFileName = result.WHTFileName;
				WHTContent = result.WHTContent;
				WHTExportLogicalFolder = result.WHTExportLogicalFolder;
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
    }
}
