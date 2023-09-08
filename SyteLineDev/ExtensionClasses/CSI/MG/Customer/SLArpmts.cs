//PROJECT NAME: CustomerExt
//CLASS NAME: SLArpmts.cs

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
    [IDOExtensionClass("SLArpmts")]
    public class SLArpmts : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ARPayPostDeleteTmpSp(Guid? PSessionID)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iARPayPostDeleteTmpExt = new ARPayPostDeleteTmpFactory().Create(appDb);

                int Severity = iARPayPostDeleteTmpExt.ARPayPostDeleteTmpSp(PSessionID);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ARPayPostVerifyCloseFormSp(Guid? PSessionID,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iARPayPostVerifyCloseFormExt = new ARPayPostVerifyCloseFormFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iARPayPostVerifyCloseFormExt.ARPayPostVerifyCloseFormSp(PSessionID,
                                                                                       ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArpmtExchRateLeaveSP(byte? PDomOfEuro,
                                        byte? PBankOfEuro,
                                        string PPaymentCurrCode,
                                        byte? PFixedEuro,
                                        string PBnkCurrCode,
                                        string PDomCurrCode,
                                        ref decimal? PDomCheckAmt,
                                        DateTime? PRecptDate,
                                        int? PCheckNum,
                                        string PBankCode,
                                        string PCustNum,
                                        string PType,
                                        string PCreditMemoNum,
                                        ref decimal? PExchRate,
                                        ref decimal? PForCheckAmt,
                                        ref decimal? PEuroAmt,
                                        ref decimal? PDomApplied,
                                        ref decimal? PForApplied,
                                        ref decimal? PDomRemaining,
                                        ref decimal? PForRemaining,
                                        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArpmtExchRateLeaveExt = new ArpmtExchRateLeaveFactory().Create(appDb);

                AmountType oPDomCheckAmt = PDomCheckAmt;
                ExchRateType oPExchRate = PExchRate;
                AmountType oPForCheckAmt = PForCheckAmt;
                AmountType oPEuroAmt = PEuroAmt;
                AmountType oPDomApplied = PDomApplied;
                AmountType oPForApplied = PForApplied;
                AmountType oPDomRemaining = PDomRemaining;
                AmountType oPForRemaining = PForRemaining;
                InfobarType oInfobar = Infobar;

                int Severity = iArpmtExchRateLeaveExt.ArpmtExchRateLeaveSP(PDomOfEuro,
                                                                           PBankOfEuro,
                                                                           PPaymentCurrCode,
                                                                           PFixedEuro,
                                                                           PBnkCurrCode,
                                                                           PDomCurrCode,
                                                                           ref oPDomCheckAmt,
                                                                           PRecptDate,
                                                                           PCheckNum,
                                                                           PBankCode,
                                                                           PCustNum,
                                                                           PType,
                                                                           PCreditMemoNum,
                                                                           ref oPExchRate,
                                                                           ref oPForCheckAmt,
                                                                           ref oPEuroAmt,
                                                                           ref oPDomApplied,
                                                                           ref oPForApplied,
                                                                           ref oPDomRemaining,
                                                                           ref oPForRemaining,
                                                                           ref oInfobar);

                PDomCheckAmt = oPDomCheckAmt;
                PExchRate = oPExchRate;
                PForCheckAmt = oPForCheckAmt;
                PEuroAmt = oPEuroAmt;
                PDomApplied = oPDomApplied;
                PForApplied = oPForApplied;
                PDomRemaining = oPDomRemaining;
                PForRemaining = oPForRemaining;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArpmtLeaveDomAmtSp(byte? PDomOfEuro,
                                      byte? PBankOfEuro,
                                      byte? PDomIsEuro,
                                      string PPaymentCurrCode,
                                      byte? PCurPayPartOfEuro,
                                      byte? PFixedEuro,
                                      string PBnkCurrCode,
                                      string PDomCurrCode,
                                      decimal? PDomCheckAmt,
                                      DateTime? PRecptDate,
                                      int? PCheckNum,
                                      string PBankCode,
                                      string PCustNum,
                                      string PType,
                                      string PCreditMemoNum,
                                      ref decimal? PExchRate,
                                      ref decimal? PForCheckAmt,
                                      ref decimal? PEuroAmt,
                                      ref decimal? PDomApplied,
                                      ref decimal? PForApplied,
                                      ref decimal? PDomRemaining,
                                      ref decimal? PForRemaining,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArpmtLeaveDomAmtExt = new ArpmtLeaveDomAmtFactory().Create(appDb);

                ExchRateType oPExchRate = PExchRate;
                AmountType oPForCheckAmt = PForCheckAmt;
                AmountType oPEuroAmt = PEuroAmt;
                AmountType oPDomApplied = PDomApplied;
                AmountType oPForApplied = PForApplied;
                AmountType oPDomRemaining = PDomRemaining;
                AmountType oPForRemaining = PForRemaining;
                InfobarType oInfobar = Infobar;

                int Severity = iArpmtLeaveDomAmtExt.ArpmtLeaveDomAmtSp(PDomOfEuro,
                                                                       PBankOfEuro,
                                                                       PDomIsEuro,
                                                                       PPaymentCurrCode,
                                                                       PCurPayPartOfEuro,
                                                                       PFixedEuro,
                                                                       PBnkCurrCode,
                                                                       PDomCurrCode,
                                                                       PDomCheckAmt,
                                                                       PRecptDate,
                                                                       PCheckNum,
                                                                       PBankCode,
                                                                       PCustNum,
                                                                       PType,
                                                                       PCreditMemoNum,
                                                                       ref oPExchRate,
                                                                       ref oPForCheckAmt,
                                                                       ref oPEuroAmt,
                                                                       ref oPDomApplied,
                                                                       ref oPForApplied,
                                                                       ref oPDomRemaining,
                                                                       ref oPForRemaining,
                                                                       ref oInfobar);

                PExchRate = oPExchRate;
                PForCheckAmt = oPForCheckAmt;
                PEuroAmt = oPEuroAmt;
                PDomApplied = oPDomApplied;
                PForApplied = oPForApplied;
                PDomRemaining = oPDomRemaining;
                PForRemaining = oPForRemaining;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArpmtLeaveForToPayAppliedSp(string PayCurrCode,
                                               string BankCurrCode,
                                               string DomCurrCode,
                                               decimal? PayCheckAmt,
                                               DateTime? RecptDate,
                                               decimal? PayExchRate,
                                               ref decimal? PayApplied,
                                               decimal? ForApplied,
                                               decimal? DomApplied,
                                               ref decimal? PayRemaining,
                                               ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArpmtLeaveForToPayAppliedExt = new ArpmtLeaveForToPayAppliedFactory().Create(appDb);

                AmountType oPayApplied = PayApplied;
                AmountType oPayRemaining = PayRemaining;
                InfobarType oInfobar = Infobar;

                int Severity = iArpmtLeaveForToPayAppliedExt.ArpmtLeaveForToPayAppliedSp(PayCurrCode,
                                                                                         BankCurrCode,
                                                                                         DomCurrCode,
                                                                                         PayCheckAmt,
                                                                                         RecptDate,
                                                                                         PayExchRate,
                                                                                         ref oPayApplied,
                                                                                         ForApplied,
                                                                                         DomApplied,
                                                                                         ref oPayRemaining,
                                                                                         ref oInfobar);

                PayApplied = oPayApplied;
                PayRemaining = oPayRemaining;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArpmtLeavePayExchRateAmtSp(string PFromCurrCode,
                                              string PToCurrCode,
                                              string DomCurrCode,
                                              ref decimal? PToCheckAmt,
                                              DateTime? PRecptDate,
                                              int? PCheckNum,
                                              string PBankCode,
                                              string PCustNum,
                                              string PType,
                                              string PCreditMemoNum,
                                              ref decimal? PExchRate,
                                              decimal? PFromCheckAmt,
                                              ref decimal? PToApplied,
                                              ref decimal? PFromApplied,
                                              decimal? DomApplied,
                                              ref decimal? PToRemaining,
                                              ref decimal? PFromRemaining,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArpmtLeavePayExchRateAmtExt = new ArpmtLeavePayExchRateAmtFactory().Create(appDb);

                AmountType oPToCheckAmt = PToCheckAmt;
                ExchRateType oPExchRate = PExchRate;
                AmountType oPToApplied = PToApplied;
                AmountType oPFromApplied = PFromApplied;
                AmountType oPToRemaining = PToRemaining;
                AmountType oPFromRemaining = PFromRemaining;
                InfobarType oInfobar = Infobar;

                int Severity = iArpmtLeavePayExchRateAmtExt.ArpmtLeavePayExchRateAmtSp(PFromCurrCode,
                                                                                       PToCurrCode,
                                                                                       DomCurrCode,
                                                                                       ref oPToCheckAmt,
                                                                                       PRecptDate,
                                                                                       PCheckNum,
                                                                                       PBankCode,
                                                                                       PCustNum,
                                                                                       PType,
                                                                                       PCreditMemoNum,
                                                                                       ref oPExchRate,
                                                                                       PFromCheckAmt,
                                                                                       ref oPToApplied,
                                                                                       ref oPFromApplied,
                                                                                       DomApplied,
                                                                                       ref oPToRemaining,
                                                                                       ref oPFromRemaining,
                                                                                       ref oInfobar);

                PToCheckAmt = oPToCheckAmt;
                PExchRate = oPExchRate;
                PToApplied = oPToApplied;
                PFromApplied = oPFromApplied;
                PToRemaining = oPToRemaining;
                PFromRemaining = oPFromRemaining;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArpmtLeavePayToCustAmtSp(string PFromCurrCode,
                                            string PToCurrCode,
                                            string DomCurrCode,
                                            ref decimal? PToCheckAmt,
                                            DateTime? PRecptDate,
                                            int? PCheckNum,
                                            string PBankCode,
                                            string PCustNum,
                                            string PType,
                                            string PCreditMemoNum,
                                            ref decimal? PExchRate,
                                            decimal? PFromCheckAmt,
                                            ref decimal? PToApplied,
                                            ref decimal? PFromApplied,
                                            decimal? DomApplied,
                                            ref decimal? PToRemaining,
                                            ref decimal? PFromRemaining,
                                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArpmtLeavePayToCustAmtExt = new ArpmtLeavePayToCustAmtFactory().Create(appDb);

                AmountType oPToCheckAmt = PToCheckAmt;
                ExchRateType oPExchRate = PExchRate;
                AmountType oPToApplied = PToApplied;
                AmountType oPFromApplied = PFromApplied;
                AmountType oPToRemaining = PToRemaining;
                AmountType oPFromRemaining = PFromRemaining;
                InfobarType oInfobar = Infobar;

                int Severity = iArpmtLeavePayToCustAmtExt.ArpmtLeavePayToCustAmtSp(PFromCurrCode,
                                                                                   PToCurrCode,
                                                                                   DomCurrCode,
                                                                                   ref oPToCheckAmt,
                                                                                   PRecptDate,
                                                                                   PCheckNum,
                                                                                   PBankCode,
                                                                                   PCustNum,
                                                                                   PType,
                                                                                   PCreditMemoNum,
                                                                                   ref oPExchRate,
                                                                                   PFromCheckAmt,
                                                                                   ref oPToApplied,
                                                                                   ref oPFromApplied,
                                                                                   DomApplied,
                                                                                   ref oPToRemaining,
                                                                                   ref oPFromRemaining,
                                                                                   ref oInfobar);

                PToCheckAmt = oPToCheckAmt;
                PExchRate = oPExchRate;
                PToApplied = oPToApplied;
                PFromApplied = oPFromApplied;
                PToRemaining = oPToRemaining;
                PFromRemaining = oPFromRemaining;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArpmtRecptDateSp(string PCustNum,
                                    string PBankCurrCode,
                                    int? PCheckNum,
                                    string PType,
                                    DateTime? PRecptDate,
                                    decimal? PDomCheckAmt,
                                    ref string POpenType,
                                    ref string POpenCode,
                                    ref DateTime? PDueDate,
                                    ref decimal? PExchRate,
                                    ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArpmtRecptDateExt = new ArpmtRecptDateFactory().Create(appDb);

                LongListType oPOpenType = POpenType;
                LongListType oPOpenCode = POpenCode;
                DateType oPDueDate = PDueDate;
                ExchRateType oPExchRate = PExchRate;
                InfobarType oInfobar = Infobar;

                int Severity = iArpmtRecptDateExt.ArpmtRecptDateSp(PCustNum,
                                                                   PBankCurrCode,
                                                                   PCheckNum,
                                                                   PType,
                                                                   PRecptDate,
                                                                   PDomCheckAmt,
                                                                   ref oPOpenType,
                                                                   ref oPOpenCode,
                                                                   ref oPDueDate,
                                                                   ref oPExchRate,
                                                                   ref oInfobar);

                POpenType = oPOpenType;
                POpenCode = oPOpenCode;
                PDueDate = oPDueDate;
                PExchRate = oPExchRate;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArpmtValidateCheckNumSp(int? PCheckNum,
                                           string PCustNum,
                                           string PBankCode,
                                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArpmtValidateCheckNumExt = new ArpmtValidateCheckNumFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iArpmtValidateCheckNumExt.ArpmtValidateCheckNumSp(PCheckNum,
                                                                                 PCustNum,
                                                                                 PBankCode,
                                                                                 ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArPmtValidateCreditMemoSp(string CustNum,
                                             string CreditMemoNum,
                                             string CurrentCurrCode,
                                             ref int? InvSeq,
                                             ref decimal? Amount,
                                             ref DateTime? InvDate,
                                             ref string CurrCode,
                                             ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArPmtValidateCreditMemoExt = new ArPmtValidateCreditMemoFactory().Create(appDb);

                InvSeqType oInvSeq = InvSeq;
                AmountType oAmount = Amount;
                DateType oInvDate = InvDate;
                CurrCodeType oCurrCode = CurrCode;
                InfobarType oInfobar = Infobar;

                int Severity = iArPmtValidateCreditMemoExt.ArPmtValidateCreditMemoSp(CustNum,
                                                                                     CreditMemoNum,
                                                                                     CurrentCurrCode,
                                                                                     ref oInvSeq,
                                                                                     ref oAmount,
                                                                                     ref oInvDate,
                                                                                     ref oCurrCode,
                                                                                     ref oInfobar);

                InvSeq = oInvSeq;
                Amount = oAmount;
                InvDate = oInvDate;
                CurrCode = oCurrCode;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ArpmtValidateTypeSp(string PType,
                                       string PCustNum,
                                       int? PCheckNum,
                                       ref DateTime? PRecptDate,
                                       ref decimal? PForCheckAmt,
                                       ref decimal? PExchRate,
                                       ref DateTime? PDueDate,
                                       ref string PInfobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iArpmtValidateTypeExt = new ArpmtValidateTypeFactory().Create(appDb);

                DateType oPRecptDate = PRecptDate;
                AmountType oPForCheckAmt = PForCheckAmt;
                ExchRateType oPExchRate = PExchRate;
                DateType oPDueDate = PDueDate;
                InfobarType oPInfobar = PInfobar;

                int Severity = iArpmtValidateTypeExt.ArpmtValidateTypeSp(PType,
                                                                         PCustNum,
                                                                         PCheckNum,
                                                                         ref oPRecptDate,
                                                                         ref oPForCheckAmt,
                                                                         ref oPExchRate,
                                                                         ref oPDueDate,
                                                                         ref oPInfobar);

                PRecptDate = oPRecptDate;
                PForCheckAmt = oPForCheckAmt;
                PExchRate = oPExchRate;
                PDueDate = oPDueDate;
                PInfobar = oPInfobar;

                return Severity;
            }
        }
















		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARPayPostUpdateTmpSp(Guid? PSessionID,
		                                string PCustNum,
		                                string PBankCode,
		                                string PType,
		                                int? PCheckNum,
		                                int? PProcessSel,
		                                int? PUpdPrepaid,
		                                [Optional] string CreditMemoNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iARPayPostUpdateTmpExt = new Logistics.Customer.ARPayPostUpdateTmpFactory().Create(appDb);
				
				var result = iARPayPostUpdateTmpExt.ARPayPostUpdateTmpSp(PSessionID,
				                                                         PCustNum,
				                                                         PBankCode,
				                                                         PType,
				                                                         PCheckNum,
				                                                         PProcessSel,
				                                                         PUpdPrepaid,
				                                                         CreditMemoNum);
				
				
				return result.Value;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArpmtCustNumValidSp(ref string PCustNum,
		                               int? PCheckNum,
		                               ref int? PCorpCust,
		                               ref string PCustName,
		                               ref string PType,
		                               ref string PBankCode,
		                               ref string PCustCurr,
		                               ref int? PBnkCurrPartOfEuro,
		                               ref int? PFixedEuro,
		                               ref string PBankCurrCode,
		                               ref DateTime? PRecptDate,
		                               ref decimal? PExchRate,
		                               [Optional] ref string BankAmtFormat,
		                               ref int? PDraftPrint,
		                               ref string PPayCurrCode,
		                               [Optional] ref string PPayAmtFormat,
		                               ref decimal? PPaymentExchRate,
		                               ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iArpmtCustNumValidExt = new Logistics.Customer.ArpmtCustNumValidFactory().Create(appDb);
				
				var result = iArpmtCustNumValidExt.ArpmtCustNumValidSp(PCustNum,
				                                                       PCheckNum,
				                                                       PCorpCust,
				                                                       PCustName,
				                                                       PType,
				                                                       PBankCode,
				                                                       PCustCurr,
				                                                       PBnkCurrPartOfEuro,
				                                                       PFixedEuro,
				                                                       PBankCurrCode,
				                                                       PRecptDate,
				                                                       PExchRate,
				                                                       BankAmtFormat,
				                                                       PDraftPrint,
				                                                       PPayCurrCode,
				                                                       PPayAmtFormat,
				                                                       PPaymentExchRate,
				                                                       Infobar);
				
				int Severity = result.ReturnCode.Value;
				PCustNum = result.PCustNum;
				PCorpCust = result.PCorpCust;
				PCustName = result.PCustName;
				PType = result.PType;
				PBankCode = result.PBankCode;
				PCustCurr = result.PCustCurr;
				PBnkCurrPartOfEuro = result.PBnkCurrPartOfEuro;
				PFixedEuro = result.PFixedEuro;
				PBankCurrCode = result.PBankCurrCode;
				PRecptDate = result.PRecptDate;
				PExchRate = result.PExchRate;
				BankAmtFormat = result.BankAmtFormat;
				PDraftPrint = result.PDraftPrint;
				PPayCurrCode = result.PPayCurrCode;
				PPayAmtFormat = result.PPayAmtFormat;
				PPaymentExchRate = result.PPaymentExchRate;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArpmtGetCurrInfoSp(string PCurrCode,
		                              [Optional] ref string PEuroCurrCode,
		                              [Optional] ref string PEuroAmtFormat,
		                              [Optional] ref int? PDomPartofEuro)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iArpmtGetCurrInfoExt = new Logistics.Customer.ArpmtGetCurrInfoFactory().Create(appDb);
				
				var result = iArpmtGetCurrInfoExt.ArpmtGetCurrInfoSp(PCurrCode,
				                                                     PEuroCurrCode,
				                                                     PEuroAmtFormat,
				                                                     PDomPartofEuro);
				
				int Severity = result.ReturnCode.Value;
				PEuroCurrCode = result.PEuroCurrCode;
				PEuroAmtFormat = result.PEuroAmtFormat;
				PDomPartofEuro = result.PDomPartofEuro;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArpmtLeaveCustAmtSp(int? PDomOfEuro,
		                                int? PBankOfEuro,
		                                int? PBankCurrtIsEuro,
		                                string PPaymentCurrCode,
		                                int? PCurPayPartOfEuro,
		                                int? PFixedEuro,
		                                string PBnkCurrCode,
		                                string PDomCurrCode,
		                                ref decimal? PDomCheckAmt,
		                                DateTime? PRecptDate,
		                                int? PCheckNum,
		                                string PBankCode,
		                                string PCustNum,
		                                string PType,
		                                string PCreditMemoNum,
		                                ref decimal? PExchRate,
		                                [Optional, DefaultParameterValue(0)] decimal? PPaymentCheckAmount,
										decimal? PForCheckAmt,
										ref decimal? PEuroAmt,
										ref decimal? PDomApplied,
										ref decimal? PForApplied,
										[Optional, DefaultParameterValue(0)] decimal? PPayApplied,
										ref decimal? PDomRemaining,
										ref decimal? PForRemaining,
										ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iArpmtLeaveCustAmtExt = new Logistics.Customer.ArpmtLeaveCustAmtFactory().Create(appDb);
				
				var result = iArpmtLeaveCustAmtExt.ArpmtLeaveCustAmtSp(PDomOfEuro,
				                                                       PBankOfEuro,
				                                                       PBankCurrtIsEuro,
				                                                       PPaymentCurrCode,
				                                                       PCurPayPartOfEuro,
				                                                       PFixedEuro,
				                                                       PBnkCurrCode,
				                                                       PDomCurrCode,
				                                                       PDomCheckAmt,
				                                                       PRecptDate,
				                                                       PCheckNum,
				                                                       PBankCode,
				                                                       PCustNum,
				                                                       PType,
				                                                       PCreditMemoNum,
				                                                       PExchRate,
				                                                       PPaymentCheckAmount,
				                                                       PForCheckAmt,
				                                                       PEuroAmt,
				                                                       PDomApplied,
				                                                       PForApplied,
				                                                       PPayApplied,
				                                                       PDomRemaining,
				                                                       PForRemaining,
				                                                       Infobar);
				
				int Severity = result.ReturnCode.Value;
				PDomCheckAmt = result.PDomCheckAmt;
				PExchRate = result.PExchRate;
				PEuroAmt = result.PEuroAmt;
				PDomApplied = result.PDomApplied;
				PForApplied = result.PForApplied;
				PDomRemaining = result.PDomRemaining;
				PForRemaining = result.PForRemaining;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArpmtLeaveCustToPayAmtSp(string PFromCurrCode,
		                                    string PToCurrCode,
		                                    [Optional] string PDomCurrCode,
		                                    ref decimal? PToCheckAmt,
		                                    DateTime? PRecptDate,
		                                    int? PCheckNum,
		                                    string PBankCode,
		                                    string PCustNum,
		                                    string PType,
		                                    string PCreditMemoNum,
		                                    ref decimal? PExchRate,
		                                    decimal? PFromCheckAmt,
		                                    [Optional, DefaultParameterValue(0)] decimal? PDomCheckAmt,
											ref decimal? PToApplied,
											decimal? PFromApplied,
											[Optional, DefaultParameterValue(0)] decimal? PDomApplied,
											ref decimal? PToRemaining,
											ref decimal? PFromRemaining,
											ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iArpmtLeaveCustToPayAmtExt = new Logistics.Customer.ArpmtLeaveCustToPayAmtFactory().Create(appDb);
				
				var result = iArpmtLeaveCustToPayAmtExt.ArpmtLeaveCustToPayAmtSp(PFromCurrCode,
				                                                                 PToCurrCode,
				                                                                 PDomCurrCode,
				                                                                 PToCheckAmt,
				                                                                 PRecptDate,
				                                                                 PCheckNum,
				                                                                 PBankCode,
				                                                                 PCustNum,
				                                                                 PType,
				                                                                 PCreditMemoNum,
				                                                                 PExchRate,
				                                                                 PFromCheckAmt,
				                                                                 PDomCheckAmt,
				                                                                 PToApplied,
				                                                                 PFromApplied,
				                                                                 PDomApplied,
				                                                                 PToRemaining,
				                                                                 PFromRemaining,
				                                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				PToCheckAmt = result.PToCheckAmt;
				PExchRate = result.PExchRate;
				PToApplied = result.PToApplied;
				PToRemaining = result.PToRemaining;
				PFromRemaining = result.PFromRemaining;
				Infobar = result.Infobar;
				return Severity;
			}
		}















		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARPaymentDistPostingSp(string CorpSite,
		string ReApplyType,
		string ReApplyBankCode,
		decimal? ReApplyDisc,
		decimal? WireExchangeRate,
		DateTime? TIssueDate,
		int? TInvSeq,
		string CorpSiteCurrCode,
		string CorpSiteName,
		Guid? ArpmtRowPointer,
		string ArpmtCustNum,
		string ArpmtBankCode,
		string ArpmtType,
		string ArpmtCreditMemoNum,
		int? ArpmtCheckNum,
		DateTime? ArpmtRecptDate,
		DateTime? ArpmtDueDate,
		string ArpmtRef,
		int? ArpmtNoteExistsFlag,
		string ArpmtDescription,
		int? ArpmtTransferCash,
		string ArpmtdInvNum,
		string ArpmtdSite,
		string ArpmtdApplyCustNum,
		decimal? ArpmtdExchRate,
		decimal? ArpmtdDomDiscAmt,
		decimal? ArpmtdForDiscAmt,
		decimal? ArpmtdDomAllowAmt,
		decimal? ArpmtdForAllowAmt,
		decimal? ArpmtdDomAmtApplied,
		decimal? ArpmtdForAmtApplied,
		string ArpmtdCoNum,
		string ArpmtdDoNum,
		string ArpmtdDiscAcct,
		string ArpmtdDiscAcctUnit1,
		string ArpmtdDiscAcctUnit2,
		string ArpmtdDiscAcctUnit3,
		string ArpmtdDiscAcctUnit4,
		string ArpmtdAllowAcct,
		string ArpmtdAllowAcctUnit1,
		string ArpmtdAllowAcctUnit2,
		string ArpmtdAllowAcctUnit3,
		string ArpmtdAllowAcctUnit4,
		string ArpmtdDepositAcct,
		string ArpmtdDepositAcctUnit1,
		string ArpmtdDepositAcctUnit2,
		string ArpmtdDepositAcctUnit3,
		string ArpmtdDepositAcctUnit4,
		string CorpCustaddrCurrCode,
		int? CorpCustaddrCorpCred,
		string CorpCustaddrCorpCust,
		int? UpdatePrepaidAmt,
		string ControlPrefix,
		string ControlSite,
		int? ControlYear,
		int? ControlPeriod,
		decimal? ControlNumber,
		ref string Infobar,
		decimal? ArpmtdForTaxAmt1,
		decimal? ArpmtdForTaxAmt2,
		decimal? ArpmtdDomTaxAmt1,
		decimal? ArpmtdDomTaxAmt2,
		[Optional, DefaultParameterValue(0)] int? ArpmtdFsSroDeposit,
		[Optional] string DepositDebitAcct,
		[Optional] string DepositDebitUnit1,
		[Optional] string DepositDebitUnit2,
		[Optional] string DepositDebitUnit3,
		[Optional] string DepositDebitUnit4,
		[Optional] decimal? ArpmtdShipmentId,
		[Optional] string TCoNum,
		[Optional, DefaultParameterValue(0)] int? TRma,
		[Optional] DateTime? OrigArpmtRecptDate,
		[Optional] Guid? ArtranHoldNotesRowPointer,
        [Optional] string ArpmtPaymentNumber,
        [Optional] string ArpmtCurrCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iARPaymentDistPostingExt = new ARPaymentDistPostingFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iARPaymentDistPostingExt.ARPaymentDistPostingSp(CorpSite,
				ReApplyType,
				ReApplyBankCode,
				ReApplyDisc,
				WireExchangeRate,
				TIssueDate,
				TInvSeq,
				CorpSiteCurrCode,
				CorpSiteName,
				ArpmtRowPointer,
				ArpmtCustNum,
				ArpmtBankCode,
				ArpmtType,
				ArpmtCreditMemoNum,
				ArpmtCheckNum,
				ArpmtRecptDate,
				ArpmtDueDate,
				ArpmtRef,
				ArpmtNoteExistsFlag,
				ArpmtDescription,
				ArpmtTransferCash,
				ArpmtdInvNum,
				ArpmtdSite,
				ArpmtdApplyCustNum,
				ArpmtdExchRate,
				ArpmtdDomDiscAmt,
				ArpmtdForDiscAmt,
				ArpmtdDomAllowAmt,
				ArpmtdForAllowAmt,
				ArpmtdDomAmtApplied,
				ArpmtdForAmtApplied,
				ArpmtdCoNum,
				ArpmtdDoNum,
				ArpmtdDiscAcct,
				ArpmtdDiscAcctUnit1,
				ArpmtdDiscAcctUnit2,
				ArpmtdDiscAcctUnit3,
				ArpmtdDiscAcctUnit4,
				ArpmtdAllowAcct,
				ArpmtdAllowAcctUnit1,
				ArpmtdAllowAcctUnit2,
				ArpmtdAllowAcctUnit3,
				ArpmtdAllowAcctUnit4,
				ArpmtdDepositAcct,
				ArpmtdDepositAcctUnit1,
				ArpmtdDepositAcctUnit2,
				ArpmtdDepositAcctUnit3,
				ArpmtdDepositAcctUnit4,
				CorpCustaddrCurrCode,
				CorpCustaddrCorpCred,
				CorpCustaddrCorpCust,
				UpdatePrepaidAmt,
				ControlPrefix,
				ControlSite,
				ControlYear,
				ControlPeriod,
				ControlNumber,
				Infobar,
				ArpmtdForTaxAmt1,
				ArpmtdForTaxAmt2,
				ArpmtdDomTaxAmt1,
				ArpmtdDomTaxAmt2,
				ArpmtdFsSroDeposit,
				DepositDebitAcct,
				DepositDebitUnit1,
				DepositDebitUnit2,
				DepositDebitUnit3,
				DepositDebitUnit4,
				ArpmtdShipmentId,
				TCoNum,
				TRma,
				OrigArpmtRecptDate,
				ArtranHoldNotesRowPointer,
                ArpmtPaymentNumber,
                ArpmtCurrCode);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARPaymentPostingBGSp([Optional, DefaultParameterValue(1)] int? DisplayHeader,
		[Optional, DefaultParameterValue(1)] int? DisplayDetail,
		[Optional] string StartingCustNum,
		[Optional] string EndingCustNum,
		string StartBnkCode,
		string EndBnkCode,
		DateTime? StartRecDate,
		DateTime? EndRecDate,
		int? StartChkNum,
		int? EndChkNum,
		Guid? PSessionID,
		[Optional] string StartCreditMemo,
		[Optional] string EndCreditMemo,
		[Optional] string PSite,
		[Optional] string PayType,
		[Optional] decimal? UserId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iARPaymentPostingBGExt = new ARPaymentPostingBGFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iARPaymentPostingBGExt.ARPaymentPostingBGSp(DisplayHeader,
				DisplayDetail,
				StartingCustNum,
				EndingCustNum,
				StartBnkCode,
				EndBnkCode,
				StartRecDate,
				EndRecDate,
				StartChkNum,
				EndChkNum,
				PSessionID,
				StartCreditMemo,
				EndCreditMemo,
				PSite,
				PayType,
				UserId);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARPaymentPostingCleanupSp(Guid? PProcessID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iARPaymentPostingCleanupExt = new ARPaymentPostingCleanupFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iARPaymentPostingCleanupExt.ARPaymentPostingCleanupSp(PProcessID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARPaymentPostingSp(Guid? PSessionID,
		Guid? PProcessID,
		string PCustNum,
		string PBankCode,
		string PType,
		int? PCheckNum,
		ref string Infobar,
		[Optional] string CreditMemoNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iARPaymentPostingExt = new ARPaymentPostingFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iARPaymentPostingExt.ARPaymentPostingSp(PSessionID,
				PProcessID,
				PCustNum,
				PBankCode,
				PType,
				PCheckNum,
				Infobar,
				CreditMemoNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ARPayPostCreateTmpSp(string PStartCustNum,
		string PEndCustNum,
		string PStartBnkCode,
		string PEndBnkCode,
		DateTime? StartDate,
		DateTime? EndDate,
		int? StartChkNum,
		int? EndChkNum,
		string StartCreditMemo,
		string EndCreditMemo,
		string PType,
		Guid? PSessionID,
		[Optional, DefaultParameterValue(0)] int? CalledFromBackground)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iARPayPostCreateTmpExt = new ARPayPostCreateTmpFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iARPayPostCreateTmpExt.ARPayPostCreateTmpSp(PStartCustNum,
				PEndCustNum,
				PStartBnkCode,
				PEndBnkCode,
				StartDate,
				EndDate,
				StartChkNum,
				EndChkNum,
				StartCreditMemo,
				EndCreditMemo,
				PType,
				PSessionID,
				CalledFromBackground);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARPayPostLockJourSp(Guid? PSessionID,
		decimal? PUserID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iARPayPostLockJourExt = new ARPayPostLockJourFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iARPayPostLockJourExt.ARPayPostLockJourSp(PSessionID,
				PUserID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ARPayPostVerifyPrintSp(ref Guid? PSessionID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iARPayPostVerifyPrintExt = new ARPayPostVerifyPrintFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iARPayPostVerifyPrintExt.ARPayPostVerifyPrintSp(PSessionID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PSessionID = result.PSessionID;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArpmtGetCurrentExchangeRateSp(string PBankCurrCode,
		DateTime? PRecptDate,
		ref decimal? PExchRate,
		ref string PInfobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iArpmtGetCurrentExchangeRateExt = new ArpmtGetCurrentExchangeRateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iArpmtGetCurrentExchangeRateExt.ArpmtGetCurrentExchangeRateSp(PBankCurrCode,
				PRecptDate,
				PExchRate,
				PInfobar);
				
				int Severity = result.ReturnCode.Value;
				PExchRate = result.PExchRate;
				PInfobar = result.PInfobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArpmtGetDomEuroCurrSp(string PDomCurr,
		ref string PEuroCurr,
		ref int? PDomOfEuro)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iArpmtGetDomEuroCurrExt = new ArpmtGetDomEuroCurrFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iArpmtGetDomEuroCurrExt.ArpmtGetDomEuroCurrSp(PDomCurr,
				PEuroCurr,
				PDomOfEuro);
				
				int Severity = result.ReturnCode.Value;
				PEuroCurr = result.PEuroCurr;
				PDomOfEuro = result.PDomOfEuro;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArpmtValidateDraftNumSp(int? PDraftNum,
		string PCustNum,
		ref decimal? PCheckAmt,
		ref decimal? PExchRate,
		ref DateTime? PDueDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iArpmtValidateDraftNumExt = new ArpmtValidateDraftNumFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iArpmtValidateDraftNumExt.ArpmtValidateDraftNumSp(PDraftNum,
				PCustNum,
				PCheckAmt,
				PExchRate,
				PDueDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PCheckAmt = result.PCheckAmt;
				PExchRate = result.PExchRate;
				PDueDate = result.PDueDate;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ArpmtValidatePaymentSp(string PCustNum,
		int? PCheckNum,
		string PType,
		ref string PBankCode,
		ref DateTime? PReceiptDate,
		ref string PPayCurrCode,
		ref string POpenType,
		ref string POpenCode,
		ref int? POpenDraft,
		ref decimal? PCheckAmt,
		ref decimal? PExchRate,
		ref DateTime? PDueDate,
		ref string Infobar,
		ref string PromptMsg,
		ref string PromptButtons,
		string CreditMemoNum,
		[Optional] ref decimal? PaymentCheckAmt,
		[Optional] ref decimal? PaymentExchRate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iArpmtValidatePaymentExt = new ArpmtValidatePaymentFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iArpmtValidatePaymentExt.ArpmtValidatePaymentSp(PCustNum,
				PCheckNum,
				PType,
				PBankCode,
				PReceiptDate,
				PPayCurrCode,
				POpenType,
				POpenCode,
				POpenDraft,
				PCheckAmt,
				PExchRate,
				PDueDate,
				Infobar,
				PromptMsg,
				PromptButtons,
				CreditMemoNum,
				PaymentCheckAmt,
				PaymentExchRate);
				
				int Severity = result.ReturnCode.Value;
				PBankCode = result.PBankCode;
				PReceiptDate = result.PReceiptDate;
				PPayCurrCode = result.PPayCurrCode;
				POpenType = result.POpenType;
				POpenCode = result.POpenCode;
				POpenDraft = result.POpenDraft;
				PCheckAmt = result.PCheckAmt;
				PExchRate = result.PExchRate;
				PDueDate = result.PDueDate;
				Infobar = result.Infobar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				PaymentCheckAmt = result.PaymentCheckAmt;
				PaymentExchRate = result.PaymentExchRate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ExchRateValidSp(string CurrCode,
		DateTime? TransDate,
		decimal? ExchRate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iExchRateValidExt = new ExchRateValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iExchRateValidExt.ExchRateValidSp(CurrCode,
				TransDate,
				ExchRate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetExchRate2Sp(string FromCurrCode,
		string ToCurrCode,
		DateTime? InvoiceDate,
		ref decimal? ExchRate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetExchRate2Ext = new GetExchRate2Factory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetExchRate2Ext.GetExchRate2Sp(FromCurrCode,
				ToCurrCode,
				InvoiceDate,
				ExchRate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				ExchRate = result.ExchRate;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetNextDraftNumberSp(ref int? NextDraftNumber)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetNextDraftNumberExt = new GetNextDraftNumberFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetNextDraftNumberExt.GetNextDraftNumberSp(NextDraftNumber);
				
				int Severity = result.ReturnCode.Value;
				NextDraftNumber = result.NextDraftNumber;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetNextDraftNumberWrapperSp(string Type,
		ref int? NextDraftNumber)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetNextDraftNumberWrapperExt = new GetNextDraftNumberWrapperFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetNextDraftNumberWrapperExt.GetNextDraftNumberWrapperSp(Type,
				NextDraftNumber);
				
				int Severity = result.ReturnCode.Value;
				NextDraftNumber = result.NextDraftNumber;
				return Severity;
			}
		}
    }
}
