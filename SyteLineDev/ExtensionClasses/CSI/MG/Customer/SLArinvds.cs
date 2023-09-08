//PROJECT NAME: CustomerExt
//CLASS NAME: SLArinvds.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Finance.AR;
//using CSI.Logistics.Vendor;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLArinvds")]
    public class SLArinvds : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArinvdDefaultSp(string CustNum,
                                   string InvNum,
                                   int? InvSeq,
                                   ref DateTime? InvDate,
                                   ref DateTime? DueDate,
                                   ref string CoNum,
                                   ref byte? PostedFromCo,
                                   ref string DoNum,
                                   ref string TermsCode,
                                   ref string TaxCode1,
                                   ref string TaxCode2,
                                   ref string CurrCode,
                                   ref decimal? ExchRate,
                                   ref byte? FixedRate,
                                   ref byte? UseExchRate,
                                   ref decimal? Amount,
                                   ref decimal? Freight,
                                   ref decimal? MiscCharges,
                                   ref decimal? SalesTax,
                                   ref decimal? SalesTax2,
                                   ref decimal? TotalInvAmt,
                                   ref decimal? TotalDist,
                                   ref decimal? TotalRem,
                                   ref Guid? arinvRowPointer,
                                   ref string ApplyToInvNum,
                                   ref string CNVATInvNum,
                                   ref decimal? CNVATSalesTax,
                                   ref string CNVATStatus,
                                   ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArinvdDefaultExt = new ArinvdDefaultFactory().Create(appDb);

                DateType oInvDate = InvDate;
                DateType oDueDate = DueDate;
                CoNumType oCoNum = CoNum;
                ListYesNoType oPostedFromCo = PostedFromCo;
                DoNumType oDoNum = DoNum;
                TermsCodeType oTermsCode = TermsCode;
                TaxCodeType oTaxCode1 = TaxCode1;
                TaxCodeType oTaxCode2 = TaxCode2;
                CurrCodeType oCurrCode = CurrCode;
                ExchRateType oExchRate = ExchRate;
                ListYesNoType oFixedRate = FixedRate;
                ListYesNoType oUseExchRate = UseExchRate;
                AmountType oAmount = Amount;
                AmountType oFreight = Freight;
                AmountType oMiscCharges = MiscCharges;
                AmountType oSalesTax = SalesTax;
                AmountType oSalesTax2 = SalesTax2;
                AmountType oTotalInvAmt = TotalInvAmt;
                AmountType oTotalDist = TotalDist;
                AmountType oTotalRem = TotalRem;
                RowPointer oarinvRowPointer = arinvRowPointer;
                InvNumType oApplyToInvNum = ApplyToInvNum;
                InvNumType oCNVATInvNum = CNVATInvNum;
                AmountType oCNVATSalesTax = CNVATSalesTax;
                CNVATStatusType oCNVATStatus = CNVATStatus;
                Infobar oInfobar = Infobar;

                int Severity = iArinvdDefaultExt.ArinvdDefaultSp(CustNum,
                                                                 InvNum,
                                                                 InvSeq,
                                                                 ref oInvDate,
                                                                 ref oDueDate,
                                                                 ref oCoNum,
                                                                 ref oPostedFromCo,
                                                                 ref oDoNum,
                                                                 ref oTermsCode,
                                                                 ref oTaxCode1,
                                                                 ref oTaxCode2,
                                                                 ref oCurrCode,
                                                                 ref oExchRate,
                                                                 ref oFixedRate,
                                                                 ref oUseExchRate,
                                                                 ref oAmount,
                                                                 ref oFreight,
                                                                 ref oMiscCharges,
                                                                 ref oSalesTax,
                                                                 ref oSalesTax2,
                                                                 ref oTotalInvAmt,
                                                                 ref oTotalDist,
                                                                 ref oTotalRem,
                                                                 ref oarinvRowPointer,
                                                                 ref oApplyToInvNum,
                                                                 ref oCNVATInvNum,
                                                                 ref oCNVATSalesTax,
                                                                 ref oCNVATStatus,
                                                                 ref oInfobar);

                InvDate = oInvDate;
                DueDate = oDueDate;
                CoNum = oCoNum;
                PostedFromCo = oPostedFromCo;
                DoNum = oDoNum;
                TermsCode = oTermsCode;
                TaxCode1 = oTaxCode1;
                TaxCode2 = oTaxCode2;
                CurrCode = oCurrCode;
                ExchRate = oExchRate;
                FixedRate = oFixedRate;
                UseExchRate = oUseExchRate;
                Amount = oAmount;
                Freight = oFreight;
                MiscCharges = oMiscCharges;
                SalesTax = oSalesTax;
                SalesTax2 = oSalesTax2;
                TotalInvAmt = oTotalInvAmt;
                TotalDist = oTotalDist;
                TotalRem = oTotalRem;
                arinvRowPointer = oarinvRowPointer;
                ApplyToInvNum = oApplyToInvNum;
                CNVATInvNum = oCNVATInvNum;
                CNVATSalesTax = oCNVATSalesTax;
                CNVATStatus = oCNVATStatus;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArinvdGetTaxAcctSp(byte? TaxSystem,
                                      string TaxCodeR,
                                      string TaxCodeE,
                                      ref string TaxAcct,
                                      ref string TaxAcctUnit1,
                                      ref string TaxAcctUnit2,
                                      ref string TaxAcctUnit3,
                                      ref string TaxAcctUnit4,
                                      ref string AccessUnit1,
                                      ref string AccessUnit2,
                                      ref string AccessUnit3,
                                      ref string AccessUnit4,
                                      ref string Infobar,
                                      ref byte? TaxAcctIsControl)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArinvdGetTaxAcctExt = new ArinvdGetTaxAcctFactory().Create(appDb);

                AcctType oTaxAcct = TaxAcct;
                UnitCode1Type oTaxAcctUnit1 = TaxAcctUnit1;
                UnitCode2Type oTaxAcctUnit2 = TaxAcctUnit2;
                UnitCode3Type oTaxAcctUnit3 = TaxAcctUnit3;
                UnitCode4Type oTaxAcctUnit4 = TaxAcctUnit4;
                UnitCodeAccessType oAccessUnit1 = AccessUnit1;
                UnitCodeAccessType oAccessUnit2 = AccessUnit2;
                UnitCodeAccessType oAccessUnit3 = AccessUnit3;
                UnitCodeAccessType oAccessUnit4 = AccessUnit4;
                Infobar oInfobar = Infobar;
                ListYesNoType oTaxAcctIsControl = TaxAcctIsControl;

                int Severity = iArinvdGetTaxAcctExt.ArinvdGetTaxAcctSp(TaxSystem,
                                                                       TaxCodeR,
                                                                       TaxCodeE,
                                                                       ref oTaxAcct,
                                                                       ref oTaxAcctUnit1,
                                                                       ref oTaxAcctUnit2,
                                                                       ref oTaxAcctUnit3,
                                                                       ref oTaxAcctUnit4,
                                                                       ref oAccessUnit1,
                                                                       ref oAccessUnit2,
                                                                       ref oAccessUnit3,
                                                                       ref oAccessUnit4,
                                                                       ref oInfobar,
                                                                       ref oTaxAcctIsControl);

                TaxAcct = oTaxAcct;
                TaxAcctUnit1 = oTaxAcctUnit1;
                TaxAcctUnit2 = oTaxAcctUnit2;
                TaxAcctUnit3 = oTaxAcctUnit3;
                TaxAcctUnit4 = oTaxAcctUnit4;
                AccessUnit1 = oAccessUnit1;
                AccessUnit2 = oAccessUnit2;
                AccessUnit3 = oAccessUnit3;
                AccessUnit4 = oAccessUnit4;
                Infobar = oInfobar;
                TaxAcctIsControl = oTaxAcctIsControl;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArinvdTaxAmtSp(string Action,
                                  DateTime? InvDate,
                                  string TermsCode,
                                  string CurrCode,
                                  decimal? ExchRate,
                                  byte? UseExchRate,
                                  byte? TaxSystem,
                                  string TaxCodeR,
                                  string TaxCodeE,
                                  decimal? TaxBasis,
                                  decimal? DistAmount,
                                  ref decimal? TaxAmount,
                                  ref string PromptMsg,
                                  ref string PromptBtns,
                                  ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArinvdTaxAmtExt = new ArinvdTaxAmtFactory().Create(appDb);

                AmountType oTaxAmount = TaxAmount;
                Infobar oPromptMsg = PromptMsg;
                Infobar oPromptBtns = PromptBtns;
                Infobar oInfobar = Infobar;

                int Severity = iArinvdTaxAmtExt.ArinvdTaxAmtSp(Action,
                                                               InvDate,
                                                               TermsCode,
                                                               CurrCode,
                                                               ExchRate,
                                                               UseExchRate,
                                                               TaxSystem,
                                                               TaxCodeR,
                                                               TaxCodeE,
                                                               TaxBasis,
                                                               DistAmount,
                                                               ref oTaxAmount,
                                                               ref oPromptMsg,
                                                               ref oPromptBtns,
                                                               ref oInfobar);

                TaxAmount = oTaxAmount;
                PromptMsg = oPromptMsg;
                PromptBtns = oPromptBtns;
                Infobar = oInfobar;

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
