//PROJECT NAME: VendorExt
//CLASS NAME: SLAptrxs.cs

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
using CSI.ExternalContracts.Portals;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Vendor
{
    [IDOExtensionClass("SLAptrxs")]
    public class SLAptrxs : CSIExtensionClassBase, ISLAptrxs
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AptrxVerifyInvNumSp(string PVendNum,
                                       string PInvNum,
                                       ref string Infobar)
        {
            var iAptrxVerifyInvNumExt = this.GetService<IAptrxVerifyInvNum>();

            var result = iAptrxVerifyInvNumExt.AptrxVerifyInvNumSp(PVendNum,
                PInvNum,
                Infobar);

            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int APVchAdjForCancellationSp(string VendNum,
                                             int? Voucher,
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
                                             ref decimal? PurchAmt,
                                             ref decimal? Freight,
                                             ref decimal? Duty_amt,
                                             ref decimal? BrokerageAmt,
                                             ref decimal? InsuranceAmt,
                                             ref decimal? LocFrtAmt,
                                             ref decimal? MiscCharges,
                                             ref decimal? SalesTax,
                                             ref decimal? SalesTax2,
                                             ref decimal? InvAmt,
                                             ref decimal? NonDiscAmt,
                                             ref decimal? DiscAmt,
                                             ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAPVchAdjForCancellationExt = new APVchAdjForCancellationFactory().Create(appDb);

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
                AmountType oPurchAmt = PurchAmt;
                AmountType oFreight = Freight;
                AmountType oDuty_amt = Duty_amt;
                AmountType oBrokerageAmt = BrokerageAmt;
                AmountType oInsuranceAmt = InsuranceAmt;
                AmountType oLocFrtAmt = LocFrtAmt;
                AmountType oMiscCharges = MiscCharges;
                AmountType oSalesTax = SalesTax;
                AmountType oSalesTax2 = SalesTax2;
                AmountType oInvAmt = InvAmt;
                AmountType oNonDiscAmt = NonDiscAmt;
                AmountType oDiscAmt = DiscAmt;
                InfobarType oInfobar = Infobar;

                int Severity = iAPVchAdjForCancellationExt.APVchAdjForCancellationSp(VendNum,
                                                                                     Voucher,
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
                                                                                     ref oPurchAmt,
                                                                                     ref oFreight,
                                                                                     ref oDuty_amt,
                                                                                     ref oBrokerageAmt,
                                                                                     ref oInsuranceAmt,
                                                                                     ref oLocFrtAmt,
                                                                                     ref oMiscCharges,
                                                                                     ref oSalesTax,
                                                                                     ref oSalesTax2,
                                                                                     ref oInvAmt,
                                                                                     ref oNonDiscAmt,
                                                                                     ref oDiscAmt,
                                                                                     ref oInfobar);

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
                PurchAmt = oPurchAmt;
                Freight = oFreight;
                Duty_amt = oDuty_amt;
                BrokerageAmt = oBrokerageAmt;
                InsuranceAmt = oInsuranceAmt;
                LocFrtAmt = oLocFrtAmt;
                MiscCharges = oMiscCharges;
                SalesTax = oSalesTax;
                SalesTax2 = oSalesTax2;
                InvAmt = oInvAmt;
                NonDiscAmt = oNonDiscAmt;
                DiscAmt = oDiscAmt;
                Infobar = oInfobar;

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetAptrxSp(string PVendNum,
		                      int? PVoucher,
		                      ref string RVendName,
		                      ref byte? RPostFromPo,
		                      ref string RType,
		                      ref string RGrnNum,
		                      ref string RInvNum,
		                      ref string RTaxCode1,
		                      ref string RTaxCode2,
		                      ref DateTime? RDistDate,
		                      ref string RPoNum,
		                      ref int? RPreRegister,
		                      ref DateTime? RInvDate,
		                      ref decimal? RExchRate,
		                      ref string RCurrCode,
		                      ref decimal? RPurchAmt,
		                      ref decimal? RFreight,
		                      ref decimal? RDutyAmt,
		                      ref decimal? RBrokerageAmt,
		                      ref decimal? RInsuranceAmt,
		                      ref decimal? RLocFrtAmt,
		                      ref decimal? RMiscCharges,
		                      ref decimal? RSalesTax,
		                      ref decimal? RSalesTax2,
		                      ref decimal? RInvAmt,
		                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetAptrxExt = new GetAptrxFactory().Create(appDb);
				
				int Severity = iGetAptrxExt.GetAptrxSp(PVendNum,
				                                       PVoucher,
				                                       ref RVendName,
				                                       ref RPostFromPo,
				                                       ref RType,
				                                       ref RGrnNum,
				                                       ref RInvNum,
				                                       ref RTaxCode1,
				                                       ref RTaxCode2,
				                                       ref RDistDate,
				                                       ref RPoNum,
				                                       ref RPreRegister,
				                                       ref RInvDate,
				                                       ref RExchRate,
				                                       ref RCurrCode,
				                                       ref RPurchAmt,
				                                       ref RFreight,
				                                       ref RDutyAmt,
				                                       ref RBrokerageAmt,
				                                       ref RInsuranceAmt,
				                                       ref RLocFrtAmt,
				                                       ref RMiscCharges,
				                                       ref RSalesTax,
				                                       ref RSalesTax2,
				                                       ref RInvAmt,
				                                       ref Infobar);
				
				return Severity;
			}
		}














		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AptrxVerifyVoucherNoSp(string PVendNum,
		                                  string PType,
		                                  ref int? RVoucher,
		                                  ref string CurrCode,
		                                  ref int? FixedRate,
		                                  ref decimal? ExchRate,
		                                  ref string Infobar,
		                                  [Optional, DefaultParameterValue(0)] int? Cancellation)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iAptrxVerifyVoucherNoExt = new Logistics.Vendor.AptrxVerifyVoucherNoFactory().Create(appDb);
				
				var result = iAptrxVerifyVoucherNoExt.AptrxVerifyVoucherNoSp(PVendNum,
				                                                             PType,
				                                                             RVoucher,
				                                                             CurrCode,
				                                                             FixedRate,
				                                                             ExchRate,
				                                                             Infobar,
				                                                             Cancellation);
				
				int Severity = result.ReturnCode.Value;
				RVoucher = result.RVoucher;
				CurrCode = result.CurrCode;
				FixedRate = result.FixedRate;
				ExchRate = result.ExchRate;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int APVoucherandAdjustmentSp(string PVendNum,
		                                    DateTime? PInvoiceDate,
		                                    string pChartAcct,
		                                    [Optional] string Site,
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
		                                    ref string rChartType,
		                                    ref string rAccessUnit1,
		                                    ref string rAccessUnit2,
		                                    ref string rAccessUnit3,
		                                    ref string rAccessUnit4,
		                                    ref int? PPartOfEuro,
		                                    ref int? POIncludeCost,
		                                    ref string Infobar,
		                                    ref int? RApAcctIsControl)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iAPVoucherandAdjustmentExt = new Logistics.Vendor.APVoucherandAdjustmentFactory().Create(appDb);
				
				var result = iAPVoucherandAdjustmentExt.APVoucherandAdjustmentSp(PVendNum,
				                                                                 PInvoiceDate,
				                                                                 pChartAcct,
				                                                                 Site,
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
				                                                                 rChartType,
				                                                                 rAccessUnit1,
				                                                                 rAccessUnit2,
				                                                                 rAccessUnit3,
				                                                                 rAccessUnit4,
				                                                                 PPartOfEuro,
				                                                                 POIncludeCost,
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
				rChartType = result.rChartType;
				rAccessUnit1 = result.rAccessUnit1;
				rAccessUnit2 = result.rAccessUnit2;
				rAccessUnit3 = result.rAccessUnit3;
				rAccessUnit4 = result.rAccessUnit4;
				PPartOfEuro = result.PPartOfEuro;
				POIncludeCost = result.POIncludeCost;
				Infobar = result.Infobar;
				RApAcctIsControl = result.RApAcctIsControl;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetRateSp(string ForCurrCode,
		                     byte? UseBuyRate,
		                     [Optional] DateTime? TransDate,
		                     [Optional, DefaultParameterValue((byte)0)] byte? SetResultantRateDiv,
		[Optional, DefaultParameterValue((byte)0)] byte? UseCustomsAndExciseRates,
		[Optional] string Site,
		[Optional] string DomCurrCode,
		[Optional] ref decimal? ResultantRate,
		[Optional] ref byte? ResultantRateDiv,
		[Optional] ref decimal? DomToEuro,
		[Optional] ref byte? DomToEuroDiv,
		[Optional] ref decimal? ForToEuro,
		[Optional] ref byte? ForToEuroDiv,
		[Optional] ref byte? EuroBasis,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetRateExt = new GetRateFactory().Create(this);
				
				var result = iGetRateExt.GetRateSp(ForCurrCode,
				                                   UseBuyRate,
				                                   TransDate,
				                                   SetResultantRateDiv,
				                                   UseCustomsAndExciseRates,
				                                   Site,
				                                   DomCurrCode,
				                                   ResultantRate,
				                                   ResultantRateDiv,
				                                   DomToEuro,
				                                   DomToEuroDiv,
				                                   ForToEuro,
				                                   ForToEuroDiv,
				                                   EuroBasis,
				                                   Infobar);
				
				int Severity = result.ReturnCode.Value;
				ResultantRate = result.ResultantRate;
				ResultantRateDiv = result.ResultantRateDiv;
				DomToEuro = result.DomToEuro;
				DomToEuroDiv = result.DomToEuroDiv;
				ForToEuro = result.ForToEuro;
				ForToEuroDiv = result.ForToEuroDiv;
				EuroBasis = result.EuroBasis;
				Infobar = result.Infobar;
				return Severity;
			}
		}








		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidatePoNumWarningSp(string PoNum,
		ref string PromptMsg,
		ref string Buttons,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidatePoNumWarningExt = new ValidatePoNumWarningFactory().Create(appDb);
				
				var result = iValidatePoNumWarningExt.ValidatePoNumWarningSp(PoNum,
				PromptMsg,
				Buttons,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				Buttons = result.Buttons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateSiteSSameBaseCurrSharedVendSameCurrSp(ref string PSite,
		string PVendNum,
		ref int? PEnableSalesTax,
		ref int? PEnableSalesTax2,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateSiteSSameBaseCurrSharedVendSameCurrExt = new ValidateSiteSSameBaseCurrSharedVendSameCurrFactory().Create(appDb);
				
				var result = iValidateSiteSSameBaseCurrSharedVendSameCurrExt.ValidateSiteSSameBaseCurrSharedVendSameCurrSp(PSite,
				PVendNum,
				PEnableSalesTax,
				PEnableSalesTax2,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PSite = result.PSite;
				PEnableSalesTax = result.PEnableSalesTax;
				PEnableSalesTax2 = result.PEnableSalesTax2;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AptrxGetVoucherNoSp(ref int? RVoucher,
		ref string RRef,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAptrxGetVoucherNoExt = new AptrxGetVoucherNoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAptrxGetVoucherNoExt.AptrxGetVoucherNoSp(RVoucher,
				RRef,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				RVoucher = result.RVoucher;
				RRef = result.RRef;
				Infobar = result.Infobar;
				return Severity;
			}
		}







































		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetVoucherNoSp(string PVendNum,
		[Optional, DefaultParameterValue(0)] int? Cancellation)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_GetVoucherNoExt = new CLM_GetVoucherNoFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_GetVoucherNoExt.CLM_GetVoucherNoSp(PVendNum,
				Cancellation);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ToSiteForManualVoucherBuilderSp(string PVendNum)
		{
			var iCLM_ToSiteForManualVoucherBuilderExt = this.GetService<ICLM_ToSiteForManualVoucherBuilder>();

			var result = iCLM_ToSiteForManualVoucherBuilderExt.CLM_ToSiteForManualVoucherBuilderSp(PVendNum);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CostCodeGetAccountSp(string CostCode,
		string ProjNum,
		ref string Acct,
		ref string AcctUnit1,
		ref string AcctUnit2,
		ref string AcctUnit3,
		ref string AcctUnit4,
		ref string Description,
		ref int? IsControlAcct)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCostCodeGetAccountExt = new CostCodeGetAccountFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCostCodeGetAccountExt.CostCodeGetAccountSp(CostCode,
				ProjNum,
				Acct,
				AcctUnit1,
				AcctUnit2,
				AcctUnit3,
				AcctUnit4,
				Description,
				IsControlAcct);
				
				int Severity = result.ReturnCode.Value;
				Acct = result.Acct;
				AcctUnit1 = result.AcctUnit1;
				AcctUnit2 = result.AcctUnit2;
				AcctUnit3 = result.AcctUnit3;
				AcctUnit4 = result.AcctUnit4;
				Description = result.Description;
				IsControlAcct = result.IsControlAcct;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DelVocuhAdjNumSp(int? LasttranKey,
		string Action,
		ref decimal? LasttranLastTran,
		string VoucherType,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDelVocuhAdjNumExt = new DelVocuhAdjNumFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDelVocuhAdjNumExt.DelVocuhAdjNumSp(LasttranKey,
				Action,
				LasttranLastTran,
				VoucherType,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				LasttranLastTran = result.LasttranLastTran;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ManualVoucherBuilderProcessSp(string PToSite,
		string PVendNum,
		string PInvNum,
		DateTime? PInvDate,
		DateTime? PDistDate,
		string PTxt,
		int? PGenerateDistributions,
		int? PFixedRate,
		decimal? PExchRate,
		decimal? PPurchAmt,
		decimal? PFreight,
		decimal? PDuty,
		decimal? PBrokerage,
		decimal? PInsurance,
		decimal? PLocFrt,
		decimal? PMiscCharges,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		string PBuilderVoucherOrigSite,
		string PBuilderVoucher,
		DateTime? PTaxDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iManualVoucherBuilderProcessExt = new ManualVoucherBuilderProcessFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iManualVoucherBuilderProcessExt.ManualVoucherBuilderProcessSp(PToSite,
				PVendNum,
				PInvNum,
				PInvDate,
				PDistDate,
				PTxt,
				PGenerateDistributions,
				PFixedRate,
				PExchRate,
				PPurchAmt,
				PFreight,
				PDuty,
				PBrokerage,
				PInsurance,
				PLocFrt,
				PMiscCharges,
				PSalesTax,
				PSalesTax2,
				PBuilderVoucherOrigSite,
				PBuilderVoucher,
				PTaxDate);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int NextBuilderVoucherSp(ref string Key,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iNextBuilderVoucherExt = new NextBuilderVoucherFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iNextBuilderVoucherExt.NextBuilderVoucherSp(Key,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Key = result.Key;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable VchAuthSp(string PText,
		string PStartingAuthorizer,
		string PEndingAuthorizer,
		int? PStartingVoucher,
		int? PEndingVoucher,
		DateTime? PStartingInvoiceDate,
		DateTime? PEndingInvoiceDate,
		string PStartingVendor,
		string PEndingVendor,
		string PAuthStatus,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iVchAuthExt = new VchAuthFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iVchAuthExt.VchAuthSp(PText,
				PStartingAuthorizer,
				PEndingAuthorizer,
				PStartingVoucher,
				PEndingVoucher,
				PStartingInvoiceDate,
				PEndingInvoiceDate,
				PStartingVendor,
				PEndingVendor,
				PAuthStatus,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}























		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AptrxpSp(string PVendNum,
		int? PVoucher,
		Guid? PSessionID,
		ref int? PostExtFin,
		ref decimal? ExtFinOperationCounter,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAptrxpExt = new AptrxpFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAptrxpExt.AptrxpSp(PVendNum,
				PVoucher,
				PSessionID,
				PostExtFin,
				ExtFinOperationCounter,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PostExtFin = result.PostExtFin;
				ExtFinOperationCounter = result.ExtFinOperationCounter;
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
