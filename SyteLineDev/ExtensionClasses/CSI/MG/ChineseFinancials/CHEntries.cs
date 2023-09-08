//PROJECT NAME: ChineseFinancialsExt
//CLASS NAME: CHEntries.cs

using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance.Chinese;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.ChineseFinancials
{
    [IDOExtensionClass("CHEntries")]
    public class CHEntries : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CHSListOfAcctsValidSp(string TypeCode,
                                         decimal? DebitAmount,
                                         decimal? CreditAmount,
                                         string Acct,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCHSListOfAcctsValidExt = new CHSListOfAcctsValidFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iCHSListOfAcctsValidExt.CHSListOfAcctsValidSp(TypeCode,
                                                                             DebitAmount,
                                                                             CreditAmount,
                                                                             Acct,
                                                                             ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CHSGetExchangeRateSp(DateTime? TransDate,
                                        int? BankOrCurr,
                                        string FrgnYN,
                                        string SysCurrCode,
                                        ref string bank_code,
                                        ref string curr_code,
                                        ref decimal? exch_rate,
                                        ref byte? rate_is_divisor,
                                        ref string InfoBar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCHSGetExchangeRateExt = new CHSGetExchangeRateFactory().Create(appDb);

                BankCodeType obank_code = bank_code;
                CurrCodeType ocurr_code = curr_code;
                ExchRateType oexch_rate = exch_rate;
                ListYesNoType orate_is_divisor = rate_is_divisor;
                InfobarType oInfoBar = InfoBar;

                int Severity = iCHSGetExchangeRateExt.CHSGetExchangeRateSp(TransDate,
                                                                           BankOrCurr,
                                                                           FrgnYN,
                                                                           SysCurrCode,
                                                                           ref obank_code,
                                                                           ref ocurr_code,
                                                                           ref oexch_rate,
                                                                           ref orate_is_divisor,
                                                                           ref oInfoBar);

                bank_code = obank_code;
                curr_code = ocurr_code;
                exch_rate = oexch_rate;
                rate_is_divisor = orate_is_divisor;
                InfoBar = oInfoBar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CHSGetDomCurrCodeSp(ref string curr_code, ref string InfoBar)
        {
            var iCHSGetDomCurrCodeExt = new CHSGetDomCurrCodeFactory().Create(this, true);

            var result = iCHSGetDomCurrCodeExt.CHSGetDomCurrCodeSp(curr_code, InfoBar);

            curr_code = result.curr_code;
            InfoBar = result.InfoBar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int CHSAccountUnitCodeListSp(string DataType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCHSAccountUnitCodeListExt = new CHSAccountUnitCodeListFactory().Create(appDb);
				
				int Severity = iCHSAccountUnitCodeListExt.CHSAccountUnitCodeListSp(DataType);
				
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSGetCOrVSp(int? CorV,
		ref string Infobar,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCHSGetCOrVExt = new CHSGetCOrVFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCHSGetCOrVExt.CHSGetCOrVSp(CorV,
				Infobar,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSGetListOfAcctsSp(string TypeCode,
		decimal? DebitAmount,
		decimal? CreditAmount,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCHSGetListOfAcctsExt = new CHSGetListOfAcctsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCHSGetListOfAcctsExt.CHSGetListOfAcctsSp(TypeCode,
				DebitAmount,
				CreditAmount,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSGetListOfBanksSp(string UserName,
		string UserGroup,
		[Optional] string BackCodeFilter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCHSGetListOfBanksExt = new CHSGetListOfBanksFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCHSGetListOfBanksExt.CHSGetListOfBanksSp(UserName,
				UserGroup,
				BackCodeFilter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
