//PROJECT NAME: FinanceExt
//CLASS NAME: SLFsbJournals.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
    [IDOExtensionClass("SLFsbJournals")]
    public class SLFsbJournals : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MultiFSBLedgerPostingForJourDisplaySp(string FSBName,
                                                          ref DateTime? RStartDate,
                                                          ref DateTime? REndDate,
                                                          ref string Infobar,
                                                          ref short? StartingFiscalYear,
                                                          ref short? EndingFiscalYear,
                                                          ref DateTime? FiscalYearStartDate,
                                                          ref DateTime? FiscalYearEndDate,
                                                          ref byte? AvailChinFin)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFsbJournalsExt = new MultiFSBLedgerPostingForJourDisplayFactory().Create(appDb);

                DateType oRStartDate = RStartDate;
                DateType oREndDate = REndDate;
                InfobarType oInfobar = Infobar;
                FiscalYearType oStartingFiscalYear = StartingFiscalYear;
                FiscalYearType oEndingFiscalYear = EndingFiscalYear;
                DateType oFiscalYearStartDate = FiscalYearStartDate;
                DateType oFiscalYearEndDate = FiscalYearEndDate;
                FlagNyType oAvailChinFin = AvailChinFin;

                int Severity = iSLFsbJournalsExt.MultiFSBLedgerPostingForJourDisplaySp(FSBName,
                                                                                       ref oRStartDate,
                                                                                       ref oREndDate,
                                                                                       ref oInfobar,
                                                                                       ref oStartingFiscalYear,
                                                                                       ref oEndingFiscalYear,
                                                                                       ref oFiscalYearStartDate,
                                                                                       ref oFiscalYearEndDate,
                                                                                       ref oAvailChinFin);

                RStartDate = oRStartDate;
                REndDate = oREndDate;
                Infobar = oInfobar;
                StartingFiscalYear = oStartingFiscalYear;
                EndingFiscalYear = oEndingFiscalYear;
                FiscalYearStartDate = oFiscalYearStartDate;
                FiscalYearEndDate = oFiscalYearEndDate;
                AvailChinFin = oAvailChinFin;

                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MultiFSBGlPostSp3(byte? DateOpt,
                                      DateTime? FixDate,
                                      DateTime? NextPer,
                                      byte? DelOpt,
                                      string ExOptacCompressLevel,
                                      DateTime? TPerStart,
                                      DateTime? TPerEnd,
                                      DateTime? TFirstDate,
                                      DateTime? TLastDate,
                                      byte? TReadonly,
                                      DateTime? TPostDate,
                                      decimal? UserID,
                                      string CurId,
                                      Guid? PSessionID,
                                      ref string Infobar,
                                      DateTime? PostThroughDate,
                                      string FSBName)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFsbJournalsExt = new MultiFSBGlPostSFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iSLFsbJournalsExt.MultiFSBGlPostSp3(DateOpt,
                                                                   FixDate,
                                                                   NextPer,
                                                                   DelOpt,
                                                                   ExOptacCompressLevel,
                                                                   TPerStart,
                                                                   TPerEnd,
                                                                   TFirstDate,
                                                                   TLastDate,
                                                                   TReadonly,
                                                                   TPostDate,
                                                                   UserID,
                                                                   CurId,
                                                                   PSessionID,
                                                                   ref oInfobar,
                                                                   PostThroughDate,
                                                                   FSBName);

                Infobar = oInfobar;

                return Severity;
            }
        }
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetNextFsbJournalSeqSp(string JournalID,
			ref int? JournalSeq)
		{
			var iGetNextFSBJournalSeqExt = new GetNextFSBJournalSeqFactory().Create(this, true);
			
			var result = iGetNextFSBJournalSeqExt.GetNextFSBJournalSeqSp(JournalID,
				JournalSeq);
			
			JournalSeq = result.JournalSeq;
			
			return result.ReturnCode??0;
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MultiFSBJournalBalanceSp(string FSBName,
                                             string JournalId,
                                             ref decimal? BalDr,
                                             ref decimal? BalCr,
                                             ref decimal? RevDr,
                                             ref decimal? RevCr,
                                             ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFsbJournalsExt = new MultiFSBJournalBalanceFactory().Create(appDb);

                AmtTotType oBalDr = BalDr;
                AmtTotType oBalCr = BalCr;
                AmtTotType oRevDr = RevDr;
                AmtTotType oRevCr = RevCr;
                InfobarType oInfobar = Infobar;

                int Severity = iSLFsbJournalsExt.MultiFSBJournalBalanceSp(FSBName,
                                                                          JournalId,
                                                                          ref oBalDr,
                                                                          ref oBalCr,
                                                                          ref oRevDr,
                                                                          ref oRevCr,
                                                                          ref oInfobar);

                BalDr = oBalDr;
                BalCr = oBalCr;
                RevDr = oRevDr;
                RevCr = oRevCr;
                Infobar = oInfobar;

                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MultiFSBCheckForOutOfPeriodSp(string FSBName,
                                                 Guid? PSessionID,
                                                 ref byte? OutOfPeriod,
                                                 ref byte? Closed,
                                                 ref short? FiscalYear,
                                                 ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLFsbJournalsExt = new MultiFSBCheckForOutOfPeriodFactory().Create(appDb);

                ListYesNoType oOutOfPeriod = OutOfPeriod;
                ListYesNoType oClosed = Closed;
                FiscalYearType oFiscalYear = FiscalYear;
                InfobarType oInfobar = Infobar;

                int Severity = iSLFsbJournalsExt.MultiFSBCheckForOutOfPeriodSp(FSBName,
                                                                               PSessionID,
                                                                               ref oOutOfPeriod,
                                                                               ref oClosed,
                                                                               ref oFiscalYear,
                                                                               ref oInfobar);

                OutOfPeriod = oOutOfPeriod;
                Closed = oClosed;
                FiscalYear = oFiscalYear;
                Infobar = oInfobar;

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MultiFSBYearEndClosingInputCheckSp(string FSBName,
		                                              [Optional, DefaultParameterValue("General")] string CurId,
		string IncomeSummaryAccount,
		byte? DeleteCurrentJournalEntries,
		byte? UnitCodeDetail,
		DateTime? FiscalYearBegDate,
		DateTime? FiscalYearEndDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMultiFSBYearEndClosingInputCheckExt = new MultiFSBYearEndClosingInputCheckFactory().Create(appDb);
				
				var result = iMultiFSBYearEndClosingInputCheckExt.MultiFSBYearEndClosingInputCheckSp(FSBName,
				                                                                                     CurId,
				                                                                                     IncomeSummaryAccount,
				                                                                                     DeleteCurrentJournalEntries,
				                                                                                     UnitCodeDetail,
				                                                                                     FiscalYearBegDate,
				                                                                                     FiscalYearEndDate,
				                                                                                     Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MultiFSBYearEndClosingSp(string FSBName,
		                                    [Optional, DefaultParameterValue("General")] string CurId,
		string IncomeSummaryAccount,
		[Optional] string IncomeSummaryAccountUnit1,
		[Optional] string IncomeSummaryAccountUnit2,
		[Optional] string IncomeSummaryAccountUnit3,
		[Optional] string IncomeSummaryAccountUnit4,
		byte? DeleteCurrentJournalEntries,
		byte? UnitCodeDetail,
		DateTime? FiscalYearBegDate,
		DateTime? FiscalYearEndDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMultiFSBYearEndClosingExt = new MultiFSBYearEndClosingFactory().Create(appDb);
				
				var result = iMultiFSBYearEndClosingExt.MultiFSBYearEndClosingSp(FSBName,
				                                                                 CurId,
				                                                                 IncomeSummaryAccount,
				                                                                 IncomeSummaryAccountUnit1,
				                                                                 IncomeSummaryAccountUnit2,
				                                                                 IncomeSummaryAccountUnit3,
				                                                                 IncomeSummaryAccountUnit4,
				                                                                 DeleteCurrentJournalEntries,
				                                                                 UnitCodeDetail,
				                                                                 FiscalYearBegDate,
				                                                                 FiscalYearEndDate,
				                                                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ChkAcctSp(string acct,
		DateTime? date,
		ref string Infobar,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iChkAcctExt = new ChkAcctFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iChkAcctExt.ChkAcctSp(acct,
				date,
				Infobar,
				Site);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GlJoucSp(DateTime? PPostDate,
		int? PLastSeq,
		string PPostLevel,
		string PJournalId,
		ref string Infobar,
		Guid? SessionID,
		string CalledFrom)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGlJoucExt = new GlJoucFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGlJoucExt.GlJoucSp(PPostDate,
				PLastSeq,
				PPostLevel,
				PJournalId,
				Infobar,
				SessionID,
				CalledFrom);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JournalCalcDomAmtSp(int? PRecalcFor,
		ref decimal? PDomAmtDr,
		ref decimal? PDomAmtCr,
		string PCurrCode,
		decimal? PForAmtDr,
		decimal? PForAmtCr,
		ref decimal? PExchRate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJournalCalcDomAmtExt = new JournalCalcDomAmtFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJournalCalcDomAmtExt.JournalCalcDomAmtSp(PRecalcFor,
				PDomAmtDr,
				PDomAmtCr,
				PCurrCode,
				PForAmtDr,
				PForAmtCr,
				PExchRate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PDomAmtDr = result.PDomAmtDr;
				PDomAmtCr = result.PDomAmtCr;
				PExchRate = result.PExchRate;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable MultiFSBJournalSumSp(string FSB,
		string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMultiFSBJournalSumExt = new MultiFSBJournalSumFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMultiFSBJournalSumExt.MultiFSBJournalSumSp(FSB,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}