//PROJECT NAME: ChineseFinancialsExt
//CLASS NAME: CHLedgers.cs

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
    [IDOExtensionClass("CHLedgers")]
    public class CHLedgers : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CHSCLM_VoucherTrxnSummaryByAc(short? FiscalYear,
                                                       byte? Period,
                                                       byte? SortMethod,
                                                       string Acct,
                                                       string Unit1,
                                                       string Unit2,
                                                       string Unit3,
                                                       string Unit4,
                                                       string CurrCode,
                                                       Guid? SessionId,
                                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCHSCLM_VoucherTrxnSummaryByExt = new CHSCLM_VoucherTrxnSummaryByFactory().Create(appDb, bunchedLoadCollection);

                InfobarType oInfobar = Infobar;

                DataTable dt = iCHSCLM_VoucherTrxnSummaryByExt.CHSCLM_VoucherTrxnSummaryByAc(FiscalYear,
                                                                                             Period,
                                                                                             SortMethod,
                                                                                             Acct,
                                                                                             Unit1,
                                                                                             Unit2,
                                                                                             Unit3,
                                                                                             Unit4,
                                                                                             CurrCode,
                                                                                             SessionId,
                                                                                             ref oInfobar);

                Infobar = oInfobar;


                return dt;
            }
        }
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CHSCLM_ShowLedgerSp(DateTime? BegDate,
                                             DateTime? EndDate,
                                             string BegCHVounum,
                                             string EndCHVounum,
                                             ref string InfoBar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCHSCLM_ShowLedgerExt = new CHSCLM_ShowLedgerFactory().Create(appDb, bunchedLoadCollection);

                InfobarType oInfoBar = InfoBar;

                DataTable dt = iCHSCLM_ShowLedgerExt.CHSCLM_ShowLedgerSp(BegDate,
                                                                         EndDate,
                                                                         BegCHVounum,
                                                                         EndCHVounum,
                                                                         ref oInfoBar);

                InfoBar = oInfoBar;


                return dt;
            }
        }
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CHSCLM_PostedVchTrnxByVucherSp(string StartingVoucherNumber,
                                                        string EndingVoucherNumber,
                                                        DateTime? Trans_Date,
                                                        byte? Rubric,
                                                        Guid? SessionId,
                                                        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCHSCLM_PostedVchTrnxByVucherExt = new CHSCLM_PostedVchTrnxByVucherFactory().Create(appDb, bunchedLoadCollection);

                InfobarType oInfobar = Infobar;

                DataTable dt = iCHSCLM_PostedVchTrnxByVucherExt.CHSCLM_PostedVchTrnxByVucherSp(StartingVoucherNumber,
                                                                                               EndingVoucherNumber,
                                                                                               Trans_Date,
                                                                                               Rubric,
                                                                                               SessionId,
                                                                                               ref oInfobar);

                Infobar = oInfobar;


                return dt;
            }
        }
        

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CHSUpdateLedgerCustVendNumSp(decimal? TransNum,
		                                        Guid? RowPointer,
		                                        string CustVendNum,
		                                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCHSUpdateLedgerCustVendNumExt = new CHSUpdateLedgerCustVendNumFactory().Create(appDb);
				
				int Severity = iCHSUpdateLedgerCustVendNumExt.CHSUpdateLedgerCustVendNumSp(TransNum,
				                                                                           RowPointer,
				                                                                           CustVendNum,
				                                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSCLM_LoadLedgerEntriesSp([Optional] DateTime? StartDate,
		                                            [Optional] DateTime? EndDate,
		                                            [Optional] string AcctFrom,
		                                            [Optional] string Unit1From,
		                                            [Optional] string Unit2From,
		                                            [Optional] string Unit3From,
		                                            [Optional] string Unit4From,
		                                            [Optional] string AcctTo,
		                                            [Optional] string Unit1To,
		                                            [Optional] string Unit2To,
		                                            [Optional] string Unit3To,
		                                            [Optional] string Unit4To)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCHSCLM_LoadLedgerEntriesExt = new CHSCLM_LoadLedgerEntriesFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCHSCLM_LoadLedgerEntriesExt.CHSCLM_LoadLedgerEntriesSp(StartDate,
				                                                                     EndDate,
				                                                                     AcctFrom,
				                                                                     Unit1From,
				                                                                     Unit2From,
				                                                                     Unit3From,
				                                                                     Unit4From,
				                                                                     AcctTo,
				                                                                     Unit1To,
				                                                                     Unit2To,
				                                                                     Unit3To,
				                                                                     Unit4To);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSCLM_LoadPstdSysVouchersSp([Optional] short? FiscalYear,
		                                              [Optional] byte? Period,
		                                              [Optional] string FromVoucherNum,
		                                              [Optional] string ToVoucherNum,
		                                              [Optional] string TypeCode,
		                                              Guid? SessionId,
		                                              string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCHSCLM_LoadPstdSysVouchersExt = new CHSCLM_LoadPstdSysVouchersFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCHSCLM_LoadPstdSysVouchersExt.CHSCLM_LoadPstdSysVouchersSp(FiscalYear,
				                                                                         Period,
				                                                                         FromVoucherNum,
				                                                                         ToVoucherNum,
				                                                                         TypeCode,
				                                                                         SessionId,
				                                                                         Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CHSValidateTransAmountSp([Optional] DateTime? BegTransDate,
		                                    [Optional] DateTime? EndTransDate,
		                                    [Optional] decimal? BegTransNum,
		                                    [Optional] decimal? EndTransNum,
		                                    [Optional] string JournalId,
		                                    ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCHSValidateTransAmountExt = new CHSValidateTransAmountFactory().Create(appDb);
				
				var result = iCHSValidateTransAmountExt.CHSValidateTransAmountSp(BegTransDate,
				                                                                 EndTransDate,
				                                                                 BegTransNum,
				                                                                 EndTransNum,
				                                                                 JournalId,
				                                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CHSGetPeriodStartAndEndDateSp(int? FiscalYear,
		int? FiscalPeriod,
		[Optional] ref DateTime? FiscalYearStartDate,
		[Optional] ref DateTime? FiscalYearEndDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCHSGetPeriodStartAndEndDateExt = new CHSGetPeriodStartAndEndDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCHSGetPeriodStartAndEndDateExt.CHSGetPeriodStartAndEndDateSp(FiscalYear,
				FiscalPeriod,
				FiscalYearStartDate,
				FiscalYearEndDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				FiscalYearStartDate = result.FiscalYearStartDate;
				FiscalYearEndDate = result.FiscalYearEndDate;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}

