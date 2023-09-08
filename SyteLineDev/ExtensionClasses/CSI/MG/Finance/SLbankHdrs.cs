//PROJECT NAME: FinanceExt
//CLASS NAME: SLBankHdrs.cs

using System;
using System.Data;
using CSI.Data.SQL.UDDT;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Finance.AP;
using CSI.Finance.Bank;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLBankHdrs")]
    public class SLBankHdrs : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int VerifyPaymentExistsSp(DateTime? CheckDate,
                                          int? CheckNumber,
                                          decimal? CheckAmt,
                                          string RefNum,
                                          ref string CustCurrCode,
                                          ref byte? Exists,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLBankHdrsExt = new VerifyPaymentExistsFactory().Create(appDb);

                CurrCodeType oCustCurrCode = CustCurrCode;
                ListYesNoType oExists = Exists;
                InfobarType oInfobar = Infobar;

                int Severity = iSLBankHdrsExt.VerifyPaymentExistsSp(CheckDate,
                                                                    CheckNumber,
                                                                    CheckAmt,
                                                                    RefNum,
                                                                    ref oCustCurrCode,
                                                                    ref oExists,
                                                                    ref oInfobar);

                CustCurrCode = oCustCurrCode;
                Exists = oExists;
                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateInternationalBankAccountSp(string IBAN,
                                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLBankHdrsExt = new ValidateInternationalBankAccountFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iSLBankHdrsExt.ValidateInternationalBankAccountSp(IBAN,
                                                                                 ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PayrollValidateBankSp(string pBankCode,
                                         ref int? rNextCheckNumber,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLBankHdrsExt = new PayrollValidateBankFactory().Create(appDb);

                GlCheckNumType orNextCheckNumber = rNextCheckNumber;
                Infobar oInfobar = Infobar;

                int Severity = iSLBankHdrsExt.PayrollValidateBankSp(pBankCode,
                                                                    ref orNextCheckNumber,
                                                                    ref oInfobar);

                rNextCheckNumber = orNextCheckNumber;
                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetDefaultBankCodeSp(ref string BankCode)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLBankHdrsExt = new GetDefaultBankCodeFactory().Create(appDb);

                BankCodeType oBankCode = BankCode;

                int Severity = iSLBankHdrsExt.GetDefaultBankCodeSp(ref oBankCode);

                BankCode = oBankCode;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int Ap01P1Sp(string BankHdrBankCode,
                            string PayTypeCodeCt,
                            int? ExOptCheckNum,
                            ref int? TCurCheckN,
                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLBankHdrsExt = new Ap01P1Factory().Create(appDb);

                GlCheckNumType oTCurCheckN = TCurCheckN;
                Infobar oInfobar = Infobar;

                int Severity = iSLBankHdrsExt.Ap01P1Sp(BankHdrBankCode,
                                                       PayTypeCodeCt,
                                                       ExOptCheckNum,
                                                       ref oTCurCheckN,
                                                       ref oInfobar);

                TCurCheckN = oTCurCheckN;
                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int BankCodeAlwaysValidSp(string BankCode,
                                         ref string BankName,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLBankHdrsExt = new BankCodeAlwaysValidFactory().Create(appDb);

                NameType oBankName = BankName;
                Infobar oInfobar = Infobar;

                int Severity = iSLBankHdrsExt.BankCodeAlwaysValidSp(BankCode,
                                                                    ref oBankName,
                                                                    ref oInfobar);

                BankName = oBankName;
                Infobar = oInfobar;


                return Severity;
            }
        }



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GlbankBankBalanceSp(string BankCode,
		                               ref string Infobar,
		                               [Optional] ref decimal? NewDomBalance,
		                               [Optional] ref decimal? NewForBalance)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGlbankBankBalanceExt = new GlbankBankBalanceFactory().Create(appDb);
				
				var result = iGlbankBankBalanceExt.GlbankBankBalanceSp(BankCode,
				                                                       Infobar,
				                                                       NewDomBalance,
				                                                       NewForBalance);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				NewDomBalance = result.NewDomBalance;
				NewForBalance = result.NewForBalance;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int BankBalSp(string BankCode,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iBankBalExt = new BankBalFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iBankBalExt.BankBalSp(BankCode,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable RevalueSp(int? PPostTransactions,
		string BBankCode,
		string EBankCode,
		decimal? PUserID,
		[Optional] string UseType,
		[Optional] int? UseCheckNum,
		[Optional] decimal? UseExchangeRate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRevalueExt = new RevalueFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRevalueExt.RevalueSp(PPostTransactions,
				BBankCode,
				EBankCode,
				PUserID,
				UseType,
				UseCheckNum,
				UseExchangeRate);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}

