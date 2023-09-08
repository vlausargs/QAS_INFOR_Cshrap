//PROJECT NAME: CustomerExt
//CLASS NAME: SLArpmtds.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Finance.AR;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLArpmtds")]
    public class SLArpmtds : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ARPaymentDistributeChargebacksSp(string PCustNum,
                                                    string PType,
                                                    int? PCheckNum,
                                                    string PInvNum,
                                                    Guid? ArpmtdRowpointer,
                                                    string ArpmtdForCurrCode,
                                                    decimal? ArpmtdExchRate,
                                                    string ArpmtdSite,
                                                    DateTime? ArpmtRecptDate,
                                                    ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iARPaymentDistributeChargebacksExt = new ARPaymentDistributeChargebacksFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iARPaymentDistributeChargebacksExt.ARPaymentDistributeChargebacksSp(PCustNum,
                                                                                                   PType,
                                                                                                   PCheckNum,
                                                                                                   PInvNum,
                                                                                                   ArpmtdRowpointer,
                                                                                                   ArpmtdForCurrCode,
                                                                                                   ArpmtdExchRate,
                                                                                                   ArpmtdSite,
                                                                                                   ArpmtRecptDate,
                                                                                                   ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArpmtdChgArpmtdTypeSp(string PArpmtCustNum,
		int? PArpmtCheckNum,
		string PArpmtCreditMemoNum,
		string PArpmtdType,
		string PArpmtBankCode,
		string PArpmtdSite,
		int? PAddMode,
		decimal? PArpmtExchRate,
		DateTime? PArpmtRecptDate,
		string PCustCurrCode,
		int? PReApp,
		string POpenType,
		decimal? PDerPayAmtRem,
		decimal? PDerForAmtRem,
		decimal? PDerDomAmtRem,
		ref string PArpmtdInvNum,
		ref decimal? PArpmtdExchRate,
		ref int? PUpdateRate,
		ref string PArpmtdDepositAcct,
		ref string PArpmtdDepositAcctUnit1,
		ref string PArpmtdDepositAcctUnit2,
		ref string PArpmtdDepositAcctUnit3,
		ref string PArpmtdDepositAcctUnit4,
		ref decimal? PArpmtdForAmtApplied,
		ref decimal? PArpmtdDomAmtApplied,
		ref string Infobar,
		ref int? PArpmtdDepositIsControl,
		[Optional] string PArpmtPaymentCurrCode,
		[Optional] decimal? PArpmtPaymentExchRate)
		{
			var iArpmtdChgArpmtdTypeExt = new CSI.Logistics.Customer.ArpmtdChgArpmtdTypeFactory().Create(this, true);
			
			var result = iArpmtdChgArpmtdTypeExt.ArpmtdChgArpmtdTypeSp(PArpmtCustNum,
			PArpmtCheckNum,
			PArpmtCreditMemoNum,
			PArpmtdType,
			PArpmtBankCode,
			PArpmtdSite,
			PAddMode,
			PArpmtExchRate,
			PArpmtRecptDate,
			PCustCurrCode,
			PReApp,
			POpenType,
			PDerPayAmtRem,
			PDerForAmtRem,
			PDerDomAmtRem,
			PArpmtdInvNum,
			PArpmtdExchRate,
			PUpdateRate,
			PArpmtdDepositAcct,
			PArpmtdDepositAcctUnit1,
			PArpmtdDepositAcctUnit2,
			PArpmtdDepositAcctUnit3,
			PArpmtdDepositAcctUnit4,
			PArpmtdForAmtApplied,
			PArpmtdDomAmtApplied,
			Infobar,
			PArpmtdDepositIsControl,
			PArpmtPaymentCurrCode,
			PArpmtPaymentExchRate);
			
			int Severity = result.ReturnCode.Value;
			PArpmtdInvNum = result.PArpmtdInvNum;
			PArpmtdExchRate = result.PArpmtdExchRate;
			PUpdateRate = result.PUpdateRate;
			PArpmtdDepositAcct = result.PArpmtdDepositAcct;
			PArpmtdDepositAcctUnit1 = result.PArpmtdDepositAcctUnit1;
			PArpmtdDepositAcctUnit2 = result.PArpmtdDepositAcctUnit2;
			PArpmtdDepositAcctUnit3 = result.PArpmtdDepositAcctUnit3;
			PArpmtdDepositAcctUnit4 = result.PArpmtdDepositAcctUnit4;
			PArpmtdForAmtApplied = result.PArpmtdForAmtApplied;
			PArpmtdDomAmtApplied = result.PArpmtdDomAmtApplied;
			Infobar = result.Infobar;
			PArpmtdDepositIsControl = result.PArpmtdDepositIsControl;
			return Severity;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArpmtdChgCoNumSp(string PArpmtdSite,
		string PArpmtdCoNum,
		string PArpmtdInvNum,
		string PArpmtCustNum,
		string PDerCustCurrCode,
		int? PAddMode,
		int? PReApp,
		string POpenType,
		string PArpmtdType,
		decimal? PArpmtExchRate,
		DateTime? PArpmtRecptDate,
		decimal? PForAmtRem,
		ref string PArpmtdApplyCustNum,
		ref string PApplCustName,
		ref int? PFixedEuro,
		ref decimal? PArpmtdExchRate,
		ref int? PUpdateRate,
		ref decimal? PArpmtdForAmtApplied,
		ref decimal? PArpmtdForDiscAmt,
		ref decimal? PArpmtdDomAmtApplied,
		ref decimal? PArpmtdDomDiscAmt,
		ref string PArpmtdDiscAcct,
		ref string PArpmtdDiscAcctUnit1,
		ref string PArpmtdDiscAcctUnit2,
		ref string PArpmtdDiscAcctUnit3,
		ref string PArpmtdDiscAcctUnit4,
		ref string Infobar,
		ref int? PArpmtdDiscIsControl,
		[Optional] string PArpmtBankCode,
		[Optional] string PArpmtPaymentCurrCode,
		[Optional] decimal? PArpmtPaymentExchRate)
		{
			var iArpmtdChgCoNumExt = new CSI.Logistics.Customer.ArpmtdChgCoNumFactory().Create(this, true);
			
			var result = iArpmtdChgCoNumExt.ArpmtdChgCoNumSp(PArpmtdSite,
			PArpmtdCoNum,
			PArpmtdInvNum,
			PArpmtCustNum,
			PDerCustCurrCode,
			PAddMode,
			PReApp,
			POpenType,
			PArpmtdType,
			PArpmtExchRate,
			PArpmtRecptDate,
			PForAmtRem,
			PArpmtdApplyCustNum,
			PApplCustName,
			PFixedEuro,
			PArpmtdExchRate,
			PUpdateRate,
			PArpmtdForAmtApplied,
			PArpmtdForDiscAmt,
			PArpmtdDomAmtApplied,
			PArpmtdDomDiscAmt,
			PArpmtdDiscAcct,
			PArpmtdDiscAcctUnit1,
			PArpmtdDiscAcctUnit2,
			PArpmtdDiscAcctUnit3,
			PArpmtdDiscAcctUnit4,
			Infobar,
			PArpmtdDiscIsControl,
			PArpmtBankCode,
			PArpmtPaymentCurrCode,
			PArpmtPaymentExchRate);
			
			int Severity = result.ReturnCode.Value;
			PArpmtdApplyCustNum = result.PArpmtdApplyCustNum;
			PApplCustName = result.PApplCustName;
			PFixedEuro = result.PFixedEuro;
			PArpmtdExchRate = result.PArpmtdExchRate;
			PUpdateRate = result.PUpdateRate;
			PArpmtdForAmtApplied = result.PArpmtdForAmtApplied;
			PArpmtdForDiscAmt = result.PArpmtdForDiscAmt;
			PArpmtdDomAmtApplied = result.PArpmtdDomAmtApplied;
			PArpmtdDomDiscAmt = result.PArpmtdDomDiscAmt;
			PArpmtdDiscAcct = result.PArpmtdDiscAcct;
			PArpmtdDiscAcctUnit1 = result.PArpmtdDiscAcctUnit1;
			PArpmtdDiscAcctUnit2 = result.PArpmtdDiscAcctUnit2;
			PArpmtdDiscAcctUnit3 = result.PArpmtdDiscAcctUnit3;
			PArpmtdDiscAcctUnit4 = result.PArpmtdDiscAcctUnit4;
			Infobar = result.Infobar;
			PArpmtdDiscIsControl = result.PArpmtdDiscIsControl;
			return Severity;
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArpmtdChgDomAmtAppliedSp(string PArpmtdSite,
                                            string PArpmtdType,
                                            string PDerCustCurrCode,
                                            DateTime? PArpmtRecptDate,
                                            decimal? PArpmtdForAmtApplied,
                                            decimal? PArpmtdForDiscAmt,
                                            decimal? PArpmtdForAllowAmt,
                                            decimal? PArpmtdDomAmtApplied,
                                            ref decimal? PArpmtdExchRate,
                                            ref decimal? PArpmtdDomDiscAmt,
                                            ref decimal? PArpmtdDomAllowAmt,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArpmtdChgDomAmtAppliedExt = new ArpmtdChgDomAmtAppliedFactory().Create(appDb);

                ExchRateType oPArpmtdExchRate = PArpmtdExchRate;
                AmountType oPArpmtdDomDiscAmt = PArpmtdDomDiscAmt;
                AmountType oPArpmtdDomAllowAmt = PArpmtdDomAllowAmt;
                InfobarType oInfobar = Infobar;

                int Severity = iArpmtdChgDomAmtAppliedExt.ArpmtdChgDomAmtAppliedSp(PArpmtdSite,
                                                                                   PArpmtdType,
                                                                                   PDerCustCurrCode,
                                                                                   PArpmtRecptDate,
                                                                                   PArpmtdForAmtApplied,
                                                                                   PArpmtdForDiscAmt,
                                                                                   PArpmtdForAllowAmt,
                                                                                   PArpmtdDomAmtApplied,
                                                                                   ref oPArpmtdExchRate,
                                                                                   ref oPArpmtdDomDiscAmt,
                                                                                   ref oPArpmtdDomAllowAmt,
                                                                                   ref oInfobar);

                PArpmtdExchRate = oPArpmtdExchRate;
                PArpmtdDomDiscAmt = oPArpmtdDomDiscAmt;
                PArpmtdDomAllowAmt = oPArpmtdDomAllowAmt;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArpmtdChgDomDiscAmtSp(string PArpmtdSite,
                                         string PDerCustCurrCode,
                                         DateTime? PArpmtRecptDate,
                                         decimal? PArpmtdForDiscAmt,
                                         decimal? PArpmtdForAllowAmt,
                                         decimal? PArpmtdDomDiscAmt,
                                         ref decimal? PArpmtdExchRate,
                                         ref decimal? PArpmtdDomAllowAmt,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArpmtdChgDomDiscAmtExt = new ArpmtdChgDomDiscAmtFactory().Create(appDb);

                ExchRateType oPArpmtdExchRate = PArpmtdExchRate;
                AmountType oPArpmtdDomAllowAmt = PArpmtdDomAllowAmt;
                InfobarType oInfobar = Infobar;

                int Severity = iArpmtdChgDomDiscAmtExt.ArpmtdChgDomDiscAmtSp(PArpmtdSite,
                                                                             PDerCustCurrCode,
                                                                             PArpmtRecptDate,
                                                                             PArpmtdForDiscAmt,
                                                                             PArpmtdForAllowAmt,
                                                                             PArpmtdDomDiscAmt,
                                                                             ref oPArpmtdExchRate,
                                                                             ref oPArpmtdDomAllowAmt,
                                                                             ref oInfobar);

                PArpmtdExchRate = oPArpmtdExchRate;
                PArpmtdDomAllowAmt = oPArpmtdDomAllowAmt;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArpmtdChgExchRateSp(string PArpmtdSite,
                                       string PArpmtdType,
                                       string PDerCustCurrCode,
                                       DateTime? PArpmtRecptDate,
                                       decimal? PArpmtdExchRate,
                                       decimal? PArpmtdForAmtApplied,
                                       decimal? PArpmtdForDiscAmt,
                                       decimal? PArpmtdForAllowAmt,
                                       ref decimal? PArpmtdDomAmtApplied,
                                       ref decimal? PArpmtdDomDiscAmt,
                                       ref decimal? PArpmtdDomAllowAmt,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArpmtdChgExchRateExt = new ArpmtdChgExchRateFactory().Create(appDb);

                AmountType oPArpmtdDomAmtApplied = PArpmtdDomAmtApplied;
                AmountType oPArpmtdDomDiscAmt = PArpmtdDomDiscAmt;
                AmountType oPArpmtdDomAllowAmt = PArpmtdDomAllowAmt;
                InfobarType oInfobar = Infobar;

                int Severity = iArpmtdChgExchRateExt.ArpmtdChgExchRateSp(PArpmtdSite,
                                                                         PArpmtdType,
                                                                         PDerCustCurrCode,
                                                                         PArpmtRecptDate,
                                                                         PArpmtdExchRate,
                                                                         PArpmtdForAmtApplied,
                                                                         PArpmtdForDiscAmt,
                                                                         PArpmtdForAllowAmt,
                                                                         ref oPArpmtdDomAmtApplied,
                                                                         ref oPArpmtdDomDiscAmt,
                                                                         ref oPArpmtdDomAllowAmt,
                                                                         ref oInfobar);

                PArpmtdDomAmtApplied = oPArpmtdDomAmtApplied;
                PArpmtdDomDiscAmt = oPArpmtdDomDiscAmt;
                PArpmtdDomAllowAmt = oPArpmtdDomAllowAmt;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArpmtdValidArpmtdTypeSp(string PArpmtCustNum,
                                           string PArpmtType,
                                           int? PArpmtCheckNum,
                                           string PArpmtdType,
                                           ref byte? PTAvailCustDrft,
                                           ref string PArpmtdInvNum,
                                           ref string PArpmtdCoNum,
                                           ref string PArpmtdSite,
                                           ref string PApplCustName,
                                           ref decimal? PArpmtdForAmtApplied,
                                           ref string PArpmtdApplyCustNum,
                                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArpmtdValidArpmtdTypeExt = new ArpmtdValidArpmtdTypeFactory().Create(appDb);

                FlagNyType oPTAvailCustDrft = PTAvailCustDrft;
                InvNumType oPArpmtdInvNum = PArpmtdInvNum;
                CoNumType oPArpmtdCoNum = PArpmtdCoNum;
                SiteType oPArpmtdSite = PArpmtdSite;
                NameType oPApplCustName = PApplCustName;
                AmountType oPArpmtdForAmtApplied = PArpmtdForAmtApplied;
                CustNumType oPArpmtdApplyCustNum = PArpmtdApplyCustNum;
                InfobarType oInfobar = Infobar;

                int Severity = iArpmtdValidArpmtdTypeExt.ArpmtdValidArpmtdTypeSp(PArpmtCustNum,
                                                                                 PArpmtType,
                                                                                 PArpmtCheckNum,
                                                                                 PArpmtdType,
                                                                                 ref oPTAvailCustDrft,
                                                                                 ref oPArpmtdInvNum,
                                                                                 ref oPArpmtdCoNum,
                                                                                 ref oPArpmtdSite,
                                                                                 ref oPApplCustName,
                                                                                 ref oPArpmtdForAmtApplied,
                                                                                 ref oPArpmtdApplyCustNum,
                                                                                 ref oInfobar);

                PTAvailCustDrft = oPTAvailCustDrft;
                PArpmtdInvNum = oPArpmtdInvNum;
                PArpmtdCoNum = oPArpmtdCoNum;
                PArpmtdSite = oPArpmtdSite;
                PApplCustName = oPApplCustName;
                PArpmtdForAmtApplied = oPArpmtdForAmtApplied;
                PArpmtdApplyCustNum = oPArpmtdApplyCustNum;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArpmtdValidCustdrftSp(int? CheckNum,
                                         string CustNum,
                                         string InvNum,
                                         DateTime? DueDate,
                                         string ArpmtdType,
                                         string ArpmtType,
                                         ref string PromptMsg,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArpmtdValidCustdrftExt = new ArpmtdValidCustdrftFactory().Create(appDb);

                Infobar oPromptMsg = PromptMsg;
                Infobar oInfobar = Infobar;

                int Severity = iArpmtdValidCustdrftExt.ArpmtdValidCustdrftSp(CheckNum,
                                                                             CustNum,
                                                                             InvNum,
                                                                             DueDate,
                                                                             ArpmtdType,
                                                                             ArpmtType,
                                                                             ref oPromptMsg,
                                                                             ref oInfobar);

                PromptMsg = oPromptMsg;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArpmtdValidSiteSp(string PArpmtdSite,
                                     string PArpmtCustNum,
                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArpmtdValidSiteExt = new ArpmtdValidSiteFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iArpmtdValidSiteExt.ArpmtdValidSiteSp(PArpmtdSite,
                                                                     PArpmtCustNum,
                                                                     ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetTaxInfoSp(ref byte? EnableTax1,
                                ref byte? EnableTax2)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetTaxInfoExt = new GetTaxInfoFactory().Create(appDb);

                ListYesNoType oEnableTax1 = EnableTax1;
                ListYesNoType oEnableTax2 = EnableTax2;

                int Severity = iGetTaxInfoExt.GetTaxInfoSp(ref oEnableTax1,
                                                           ref oEnableTax2);

                EnableTax1 = oEnableTax1;
                EnableTax2 = oEnableTax2;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateTaxAdjustSp(decimal? ForTax,
                                       decimal? ForTaxVar,
                                       ref string InfoBar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iValidateTaxAdjustExt = new ValidateTaxAdjustFactory().Create(appDb);

                Infobar oInfoBar = InfoBar;

                int Severity = iValidateTaxAdjustExt.ValidateTaxAdjustSp(ForTax,
                                                                         ForTaxVar,
                                                                         ref oInfoBar);

                InfoBar = oInfoBar;

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArpmtdValidArpmtSp(string CustNum,
		                              string Level,
		                              string Site,
		                              string BankCode,
		                              ref string BankCurrCode,
		                              ref string PaymentCurrCode,
		                              ref string PayType,
		                              ref int? CheckNum,
		                              ref string CustName,
		                              ref string CustCurrCode,
		                              ref string CustBalMethod,
		                              ref int? CorpCust,
		                              ref DateTime? RecptDate,
		                              ref decimal? ExchRate,
		                              ref decimal? PaymentExchRate,
		                              ref decimal? ForCheckAmt,
		                              ref decimal? DomCheckAmt,
		                              ref decimal? PaymentCheckAmt,
		                              ref decimal? ForAmtBal,
		                              ref decimal? DomAmtBal,
		                              ref decimal? PaymentAmtBal,
		                              ref decimal? ForAmtRem,
		                              ref decimal? DomAmtRem,
		                              ref decimal? PaymentAmtRem,
		                              ref string DefaultType,
		                              ref int? ReApp,
		                              ref string OpenType,
		                              ref int? FixedEuro,
		                              ref int? ChkTransferCash,
		                              ref string PaymentCurrAmtFormat,
		                              ref string CreditMemoNum,
		                              [Optional] ref string BankAmtFormat,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iArpmtdValidArpmtExt = new Logistics.Customer.ArpmtdValidArpmtFactory().Create(appDb);
				
				var result = iArpmtdValidArpmtExt.ArpmtdValidArpmtSp(CustNum,
				                                                     Level,
				                                                     Site,
				                                                     BankCode,
				                                                     BankCurrCode,
				                                                     PaymentCurrCode,
				                                                     PayType,
				                                                     CheckNum,
				                                                     CustName,
				                                                     CustCurrCode,
				                                                     CustBalMethod,
				                                                     CorpCust,
				                                                     RecptDate,
				                                                     ExchRate,
				                                                     PaymentExchRate,
				                                                     ForCheckAmt,
				                                                     DomCheckAmt,
				                                                     PaymentCheckAmt,
				                                                     ForAmtBal,
				                                                     DomAmtBal,
				                                                     PaymentAmtBal,
				                                                     ForAmtRem,
				                                                     DomAmtRem,
				                                                     PaymentAmtRem,
				                                                     DefaultType,
				                                                     ReApp,
				                                                     OpenType,
				                                                     FixedEuro,
				                                                     ChkTransferCash,
				                                                     PaymentCurrAmtFormat,
				                                                     CreditMemoNum,
				                                                     BankAmtFormat,
				                                                     Infobar);
				
				int Severity = result.ReturnCode.Value;
				BankCurrCode = result.BankCurrCode;
				PaymentCurrCode = result.PaymentCurrCode;
				PayType = result.PayType;
				CheckNum = result.CheckNum;
				CustName = result.CustName;
				CustCurrCode = result.CustCurrCode;
				CustBalMethod = result.CustBalMethod;
				CorpCust = result.CorpCust;
				RecptDate = result.RecptDate;
				ExchRate = result.ExchRate;
				PaymentExchRate = result.PaymentExchRate;
				ForCheckAmt = result.ForCheckAmt;
				DomCheckAmt = result.DomCheckAmt;
				PaymentCheckAmt = result.PaymentCheckAmt;
				ForAmtBal = result.ForAmtBal;
				DomAmtBal = result.DomAmtBal;
				PaymentAmtBal = result.PaymentAmtBal;
				ForAmtRem = result.ForAmtRem;
				DomAmtRem = result.DomAmtRem;
				PaymentAmtRem = result.PaymentAmtRem;
				DefaultType = result.DefaultType;
				ReApp = result.ReApp;
				OpenType = result.OpenType;
				FixedEuro = result.FixedEuro;
				ChkTransferCash = result.ChkTransferCash;
				PaymentCurrAmtFormat = result.PaymentCurrAmtFormat;
				CreditMemoNum = result.CreditMemoNum;
				BankAmtFormat = result.BankAmtFormat;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARDistribDomAmtsSp(Guid? pRowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iARDistribDomAmtsExt = new ARDistribDomAmtsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iARDistribDomAmtsExt.ARDistribDomAmtsSp(pRowPointer,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARPaymentDistGenSp(string PBankCode,
		string PCustNum,
		string PType,
		int? PCheckNum,
		int? PReapplication,
		string POpenType,
		ref string CallVar,
		ref string ParmsSite,
		ref string Infobar,
		[Optional] string CreditMemoNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iARPaymentDistGenExt = new ARPaymentDistGenFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iARPaymentDistGenExt.ARPaymentDistGenSp(PBankCode,
				PCustNum,
				PType,
				PCheckNum,
				PReapplication,
				POpenType,
				CallVar,
				ParmsSite,
				Infobar,
				CreditMemoNum);
				
				int Severity = result.ReturnCode.Value;
				CallVar = result.CallVar;
				ParmsSite = result.ParmsSite;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArpmtdChgInvNumSp(string PArpmtdSite,
		string PArpmtdInvNum,
		string PArpmtCustNum,
		string PBankCurrCode,
		ref string PDerTransctionCurrCode,
		int? PAddMode,
		int? PReApp,
		string POpenType,
		string PArpmtdType,
		decimal? PArpmtExchRate,
		DateTime? PArpmtRecptDate,
		decimal? PForAmtRem,
		decimal? PAllowAmt,
		ref string PArpmtdApplyCustNum,
		ref string PApplCustName,
		ref int? PFixedEuro,
		ref string PArpmtdCoNum,
		ref string PArpmtdDoNum,
		ref decimal? PArpmtdExchRate,
		ref int? PUpdateRate,
		ref decimal? PArpmtdForAmtApplied,
		ref decimal? PArpmtdForDiscAmt,
		ref decimal? PArpmtdDomAmtApplied,
		ref decimal? PArpmtdDomDiscAmt,
		ref string PArpmtdDiscAcct,
		ref string PArpmtdDiscAcctUnit1,
		ref string PArpmtdDiscAcctUnit2,
		ref string PArpmtdDiscAcctUnit3,
		ref string PArpmtdDiscAcctUnit4,
		ref decimal? DfltTax1Val,
		decimal? DfltTax1Var,
		ref decimal? DfltTax2Val,
		decimal? DfltTax2Var,
		ref decimal? PArpmtdShipmentId,
		ref int? PArpmtdDiscIsControl,
		ref string Infobar,
		[Optional] string PArpmtBankCode,
		[Optional] string PArpmtPaymentCurrCode,
		[Optional] decimal? PArpmtPaymentExchRate,
		[Optional] ref int? PFixedRate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iArpmtdChgInvNumExt = new ArpmtdChgInvNumFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iArpmtdChgInvNumExt.ArpmtdChgInvNumSp(PArpmtdSite,
				PArpmtdInvNum,
				PArpmtCustNum,
				PBankCurrCode,
				PDerTransctionCurrCode,
				PAddMode,
				PReApp,
				POpenType,
				PArpmtdType,
				PArpmtExchRate,
				PArpmtRecptDate,
				PForAmtRem,
				PAllowAmt,
				PArpmtdApplyCustNum,
				PApplCustName,
				PFixedEuro,
				PArpmtdCoNum,
				PArpmtdDoNum,
				PArpmtdExchRate,
				PUpdateRate,
				PArpmtdForAmtApplied,
				PArpmtdForDiscAmt,
				PArpmtdDomAmtApplied,
				PArpmtdDomDiscAmt,
				PArpmtdDiscAcct,
				PArpmtdDiscAcctUnit1,
				PArpmtdDiscAcctUnit2,
				PArpmtdDiscAcctUnit3,
				PArpmtdDiscAcctUnit4,
				DfltTax1Val,
				DfltTax1Var,
				DfltTax2Val,
				DfltTax2Var,
				PArpmtdShipmentId,
				PArpmtdDiscIsControl,
				Infobar,
				PArpmtBankCode,
				PArpmtPaymentCurrCode,
				PArpmtPaymentExchRate,
				PFixedRate);
				
				int Severity = result.ReturnCode.Value;
				PDerTransctionCurrCode = result.PDerTransctionCurrCode;
				PArpmtdApplyCustNum = result.PArpmtdApplyCustNum;
				PApplCustName = result.PApplCustName;
				PFixedEuro = result.PFixedEuro;
				PArpmtdCoNum = result.PArpmtdCoNum;
				PArpmtdDoNum = result.PArpmtdDoNum;
				PArpmtdExchRate = result.PArpmtdExchRate;
				PUpdateRate = result.PUpdateRate;
				PArpmtdForAmtApplied = result.PArpmtdForAmtApplied;
				PArpmtdForDiscAmt = result.PArpmtdForDiscAmt;
				PArpmtdDomAmtApplied = result.PArpmtdDomAmtApplied;
				PArpmtdDomDiscAmt = result.PArpmtdDomDiscAmt;
				PArpmtdDiscAcct = result.PArpmtdDiscAcct;
				PArpmtdDiscAcctUnit1 = result.PArpmtdDiscAcctUnit1;
				PArpmtdDiscAcctUnit2 = result.PArpmtdDiscAcctUnit2;
				PArpmtdDiscAcctUnit3 = result.PArpmtdDiscAcctUnit3;
				PArpmtdDiscAcctUnit4 = result.PArpmtdDiscAcctUnit4;
				DfltTax1Val = result.DfltTax1Val;
				DfltTax2Val = result.DfltTax2Val;
				PArpmtdShipmentId = result.PArpmtdShipmentId;
				PArpmtdDiscIsControl = result.PArpmtdDiscIsControl;
				PFixedEuro = result.PFixedEuro;
				PFixedRate = result.PFixedRate;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArpmtdCnvtAmtSp(string PArpmtdSite,
		DateTime? PArpmtRecptDate,
		string PDerCustCurrCode,
		decimal? PArpmtdExchRate,
		decimal? PAmount1,
		ref decimal? PResult1,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iArpmtdCnvtAmtExt = new ArpmtdCnvtAmtFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iArpmtdCnvtAmtExt.ArpmtdCnvtAmtSp(PArpmtdSite,
				PArpmtRecptDate,
				PDerCustCurrCode,
				PArpmtdExchRate,
				PAmount1,
				PResult1,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PResult1 = result.PResult1;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArpmtdGetAcctValuesSp(decimal? PAmt,
		string PType,
		string PArpmtdType,
		string PCustCurrCode,
		int? PReapp,
		string POpenType,
		string PArpmtdSite,
		ref string PAcct,
		ref string PAcctUnit1,
		ref string PAcctUnit2,
		ref string PAcctUnit3,
		ref string PAcctUnit4,
		ref string Infobar,
		ref int? PIsControl)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iArpmtdGetAcctValuesExt = new ArpmtdGetAcctValuesFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iArpmtdGetAcctValuesExt.ArpmtdGetAcctValuesSp(PAmt,
				PType,
				PArpmtdType,
				PCustCurrCode,
				PReapp,
				POpenType,
				PArpmtdSite,
				PAcct,
				PAcctUnit1,
				PAcctUnit2,
				PAcctUnit3,
				PAcctUnit4,
				Infobar,
				PIsControl);
				
				int Severity = result.ReturnCode.Value;
				PAcct = result.PAcct;
				PAcctUnit1 = result.PAcctUnit1;
				PAcctUnit2 = result.PAcctUnit2;
				PAcctUnit3 = result.PAcctUnit3;
				PAcctUnit4 = result.PAcctUnit4;
				Infobar = result.Infobar;
				PIsControl = result.PIsControl;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArpmtdSetGloVarSp(int? TransferCash)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iArpmtdSetGloVarExt = new ArpmtdSetGloVarFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iArpmtdSetGloVarExt.ArpmtdSetGloVarSp(TransferCash);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArpmtdValidDueDateSp(string InvNum,
		ref DateTime? DueDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iArpmtdValidDueDateExt = new ArpmtdValidDueDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iArpmtdValidDueDateExt.ArpmtdValidDueDateSp(InvNum,
				DueDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				DueDate = result.DueDate;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetDefaultTaxAdjustSp(string InvoiceNumber,
		decimal? DisAmt,
		decimal? AllowAmt,
		ref decimal? DfltTax1Val,
		ref decimal? DfltTax1Var,
		ref decimal? DfltTax2Val,
		ref decimal? DfltTax2Var)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetDefaultTaxAdjustExt = new GetDefaultTaxAdjustFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetDefaultTaxAdjustExt.GetDefaultTaxAdjustSp(InvoiceNumber,
				DisAmt,
				AllowAmt,
				DfltTax1Val,
				DfltTax1Var,
				DfltTax2Val,
				DfltTax2Var);
				
				int Severity = result.ReturnCode.Value;
				DfltTax1Val = result.DfltTax1Val;
				DfltTax1Var = result.DfltTax1Var;
				DfltTax2Val = result.DfltTax2Val;
				DfltTax2Var = result.DfltTax2Var;
				return Severity;
			}
		}
    }
}
