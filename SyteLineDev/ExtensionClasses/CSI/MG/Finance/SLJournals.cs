//PROJECT NAME: FinanceExt
//CLASS NAME: SLJournals.cs

using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance;
using CSI.MG;
using CSI.Data.SQL.UDDT;
using System.Runtime.InteropServices;
using CSI.Admin;
using CSI.Data.RecordSets;

namespace CSI.MG.Finance
{
   
    [IDOExtensionClass("SLJournals")]
    public class SLJournals : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int JournalBuilderValidateAcctSp(string Acct,
                                                DateTime? TransactionDate,
                                                string SiteRef,
                                                string GroupName,
                                                decimal? UserId,
                                                byte? IsSecureCtlAcct,
                                                ref string AccessUnit1,
                                                ref string AccessUnit2,
                                                ref string AccessUnit3,
                                                ref string AccessUnit4,
                                                ref string Description,
                                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLJournalsExt = new JournalBuilderValidateAcctFactory().Create(appDb);

                UnitCodeAccessType oAccessUnit1 = AccessUnit1;
                UnitCodeAccessType oAccessUnit2 = AccessUnit2;
                UnitCodeAccessType oAccessUnit3 = AccessUnit3;
                UnitCodeAccessType oAccessUnit4 = AccessUnit4;
                DescriptionType oDescription = Description;
                InfobarType oInfobar = Infobar;

                int Severity = iSLJournalsExt.JournalBuilderValidateAcctSp(Acct,
                                                                           TransactionDate,
                                                                           SiteRef,
                                                                           GroupName,
                                                                           UserId,
                                                                           IsSecureCtlAcct,
                                                                           ref oAccessUnit1,
                                                                           ref oAccessUnit2,
                                                                           ref oAccessUnit3,
                                                                           ref oAccessUnit4,
                                                                           ref oDescription,
                                                                           ref oInfobar);

                AccessUnit1 = oAccessUnit1;
                AccessUnit2 = oAccessUnit2;
                AccessUnit3 = oAccessUnit3;
                AccessUnit4 = oAccessUnit4;
                Description = oDescription;
                Infobar = oInfobar;

                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int IsSiteAndHasSameBaseCurrSp(ref string PSite,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLJournalsExt = new IsSiteAndHasSameBaseCurrFactory().Create(appDb);

                SiteType oPSite = PSite;
                InfobarType oInfobar = Infobar;

                int Severity = iSLJournalsExt.IsSiteAndHasSameBaseCurrSp(ref oPSite,
                                                                         ref oInfobar);

                PSite = oPSite;
                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GljousPreSp(string PId,
                                ref int? PFromSeq,
                                ref int? PToSeq,
                                ref int? PFirstSeq,
                                ref int? PStepSize,
                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLJournalsExt = new GljousPreFactory().Create(appDb);

                JournalSeqType oPFromSeq = PFromSeq;
                JournalSeqType oPToSeq = PToSeq;
                JournalSeqType oPFirstSeq = PFirstSeq;
                JournalSeqType oPStepSize = PStepSize;
                InfobarType oInfobar = Infobar;

                int Severity = iSLJournalsExt.GljousPreSp(PId,
                                                          ref oPFromSeq,
                                                          ref oPToSeq,
                                                          ref oPFirstSeq,
                                                          ref oPStepSize,
                                                          ref oInfobar);

                PFromSeq = oPFromSeq;
                PToSeq = oPToSeq;
                PFirstSeq = oPFirstSeq;
                PStepSize = oPStepSize;
                Infobar = oInfobar;

                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetNextJournalSeqSp(string JournalID,
                                       ref int? JournalSeq)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLJournalsExt = new GetNextJournalSeqFactory().Create(appDb);

                JournalSeqType oJournalSeq = JournalSeq;

                int Severity = iSLJournalsExt.GetNextJournalSeqSp(JournalID,
                                                                  ref oJournalSeq);

                JournalSeq = oJournalSeq;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_JourTransMaintSp(string pJournalId,
            ref string Infobar)
        {
            var iCLM_JourTransMaintExt = new CLM_JourTransMaintFactory().Create(this, true);

            var result = iCLM_JourTransMaintExt.CLM_JourTransMaintSp(pJournalId,
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
        public int GLYearEndClosingInputCheckSp(string CurId,
                                                string IncomeSummaryAccount,
                                                byte? DeleteCurrentJournalEntries,
                                                byte? UnitCodeDetail,
                                                DateTime? FiscalYearBegDate,
                                                DateTime? FiscalYearEndDate,
                                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLJournalsExt = new GLYearEndClosingInputCheckFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iSLJournalsExt.GLYearEndClosingInputCheckSp(CurId,
                                                                           IncomeSummaryAccount,
                                                                           DeleteCurrentJournalEntries,
                                                                           UnitCodeDetail,
                                                                           FiscalYearBegDate,
                                                                           FiscalYearEndDate,
                                                                           ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JournalChgCurrCodeSp(string PCurrCode,
		                                ref decimal? PDomAmtDr,
		                                ref decimal? PDomAmtCr,
		                                DateTime? TransDate,
		                                ref decimal? PExchRate,
		                                ref byte? PFixedEuro,
		                                decimal? PForAmtDr,
		                                decimal? PForAmtCr,
		                                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iJournalChgCurrCodeExt = new JournalChgCurrCodeFactory().Create(appDb);
				
				int Severity = iJournalChgCurrCodeExt.JournalChgCurrCodeSp(PCurrCode,
				                                                           ref PDomAmtDr,
				                                                           ref PDomAmtCr,
				                                                           TransDate,
				                                                           ref PExchRate,
				                                                           ref PFixedEuro,
				                                                           PForAmtDr,
				                                                           PForAmtCr,
				                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LedgerPostingForJourDisplaySp(ref DateTime? RStartDate,
		                                         ref DateTime? REndDate,
		                                         ref string Infobar,
		                                         ref short? StartingFiscalYear,
		                                         ref short? EndingFiscalYear,
		                                         ref DateTime? FiscalYearStartDate,
		                                         ref DateTime? FiscalYearEndDate,
		                                         ref byte? AvailChinFin)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLedgerPostingForJourDisplayExt = new LedgerPostingForJourDisplayFactory().Create(appDb);
				
				int Severity = iLedgerPostingForJourDisplayExt.LedgerPostingForJourDisplaySp(ref RStartDate,
				                                                                             ref REndDate,
				                                                                             ref Infobar,
				                                                                             ref StartingFiscalYear,
				                                                                             ref EndingFiscalYear,
				                                                                             ref FiscalYearStartDate,
				                                                                             ref FiscalYearEndDate,
				                                                                             ref AvailChinFin);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GlPostSp3(byte? DateOpt,
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
		                     [Optional] string StartingGLVoucher,
		                     [Optional] string EndingGLVoucher,
		                     Guid? PSessionID,
		                     ref string Infobar,
		                     DateTime? PostThroughDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGlPostSExt = new GlPostSFactory().Create(appDb);
				
				var result = iGlPostSExt.GlPostSp3(DateOpt,
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
				                                   StartingGLVoucher,
				                                   EndingGLVoucher,
				                                   PSessionID,
				                                   Infobar,
				                                   PostThroughDate);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GLYearEndClosingSp(string CurId,
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
				
				var iGLYearEndClosingExt = new GLYearEndClosingFactory().Create(appDb);
				
				var result = iGLYearEndClosingExt.GLYearEndClosingSp(CurId,
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
		public int JP_JournalEnableTaxSp([Optional] string Acct,
		                                 byte? Taxable,
		                                 ref byte? JPDerAccount,
		                                 ref string TaxCode,
		                                 ref decimal? TaxRate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iJP_JournalEnableTaxExt = new JP_JournalEnableTaxFactory().Create(appDb);
				
				var result = iJP_JournalEnableTaxExt.JP_JournalEnableTaxSp(Acct,
				                                                           Taxable,
				                                                           JPDerAccount,
				                                                           TaxCode,
				                                                           TaxRate);
				
				int Severity = result.ReturnCode.Value;
				JPDerAccount = result.JPDerAccount;
				TaxCode = result.TaxCode;
				TaxRate = result.TaxRate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ReverseTransactionSp([Optional] string PReverseTransactionType,
		[Optional] string Pcontrol_prefix,
		[Optional] string Pcontrol_site,
		[Optional] int? Pcontrol_year,
		[Optional] int? Pcontrol_period,
		[Optional] decimal? Pcontrol_number,
		[Optional] decimal? PUserId,
		[Optional] string GLVoucher,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iReverseTransactionExt = new ReverseTransactionFactory().Create(appDb);
				
				var result = iReverseTransactionExt.ReverseTransactionSp(PReverseTransactionType,
				Pcontrol_prefix,
				Pcontrol_site,
				Pcontrol_year,
				Pcontrol_period,
				Pcontrol_number,
				PUserId,
				GLVoucher,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AllowManualJournalEntrySp(string GroupName,
		decimal? UserId,
		string pAcctNumber,
		int? IsSecureCtlAcct,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iAllowManualJournalEntryExt = new AllowManualJournalEntryFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iAllowManualJournalEntryExt.AllowManualJournalEntrySp(GroupName,
				UserId,
				pAcctNumber,
				IsSecureCtlAcct,
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
		public int CHSCheckChinFinSp(ref int? AvailChinFin)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCHSCheckChinFinExt = new CHSCheckChinFinFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCHSCheckChinFinExt.CHSCheckChinFinSp(AvailChinFin);
				
				int Severity = result.ReturnCode.Value;
				AvailChinFin = result.AvailChinFin;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_SitesWithSameBaseCurrSp()
		{
			var iCLM_SitesWithSameBaseCurrExt = new CLM_SitesWithSameBaseCurrFactory().Create(this, true);
			
			var result = iCLM_SitesWithSameBaseCurrExt.CLM_SitesWithSameBaseCurrSp();
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EXTCHSLoadCHGLInfoSp(string Id,
		int? Seq,
		ref string CHVounum,
		ref int? LineNum,
		ref int? Rubric)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iEXTCHSLoadCHGLInfoExt = new EXTCHSLoadCHGLInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iEXTCHSLoadCHGLInfoExt.EXTCHSLoadCHGLInfoSp(Id,
				Seq,
				CHVounum,
				LineNum,
				Rubric);
				
				int Severity = result.ReturnCode.Value;
				CHVounum = result.CHVounum;
				LineNum = result.LineNum;
				Rubric = result.Rubric;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetJournalDefVarsSp([Optional] DateTime? PDate,
		[Optional] string PId,
		[Optional] ref string DefPrefix,
		[Optional] ref string DefSite,
		[Optional] ref int? DefFiscalYear,
		[Optional] ref int? DefPeriod,
		[Optional] ref decimal? DefNumber,
		[Optional, DefaultParameterValue(0)] int? GetNewNumber)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetJournalDefVarsExt = new GetJournalDefVarsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetJournalDefVarsExt.GetJournalDefVarsSp(PDate,
				PId,
				DefPrefix,
				DefSite,
				DefFiscalYear,
				DefPeriod,
				DefNumber,
				GetNewNumber);
				
				int Severity = result.ReturnCode.Value;
				DefPrefix = result.DefPrefix;
				DefSite = result.DefSite;
				DefFiscalYear = result.DefFiscalYear;
				DefPeriod = result.DefPeriod;
				DefNumber = result.DefNumber;
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
		public int GljousSp(string PId,
		int? PFromSeq,
		int? PToSeq,
		int? PFirstSeq,
		int? PStepSize,
		string PTitle,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGljousExt = new GljousFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGljousExt.GljousSp(PId,
				PFromSeq,
				PToSeq,
				PFirstSeq,
				PStepSize,
				PTitle,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ImportJournalEntriesSp(DateTime? PTransactionDate,
		string PAcct,
		decimal? PDomAmount,
		string PRef,
		string JournalID,
		string PControlSite,
		int? PControlYear,
		int? PControlPeriod,
		decimal? PControlNumber,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		string AnalysisAttributeValue01,
		string AnalysisAttributeValue02,
		string AnalysisAttributeValue03,
		string AnalysisAttributeValue04,
		string AnalysisAttributeValue05,
		string AnalysisAttributeValue06,
		string AnalysisAttributeValue07,
		string AnalysisAttributeValue08,
		string AnalysisAttributeValue09,
		string AnalysisAttributeValue10,
		string AnalysisAttributeValue11,
		string AnalysisAttributeValue12,
		string AnalysisAttributeValue13,
		string AnalysisAttributeValue14,
		string AnalysisAttributeValue15)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iImportJournalEntriesExt = new ImportJournalEntriesFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iImportJournalEntriesExt.ImportJournalEntriesSp(PTransactionDate,
				PAcct,
				PDomAmount,
				PRef,
				JournalID,
				PControlSite,
				PControlYear,
				PControlPeriod,
				PControlNumber,
				PAcctUnit1,
				PAcctUnit2,
				PAcctUnit3,
				PAcctUnit4,
				AnalysisAttributeValue01,
				AnalysisAttributeValue02,
				AnalysisAttributeValue03,
				AnalysisAttributeValue04,
				AnalysisAttributeValue05,
				AnalysisAttributeValue06,
				AnalysisAttributeValue07,
				AnalysisAttributeValue08,
				AnalysisAttributeValue09,
				AnalysisAttributeValue10,
				AnalysisAttributeValue11,
				AnalysisAttributeValue12,
				AnalysisAttributeValue13,
				AnalysisAttributeValue14,
				AnalysisAttributeValue15);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JournalBalanceSp(string JournalId,
		ref decimal? BalDr,
		ref decimal? BalCr,
		ref decimal? RevDr,
		ref decimal? RevCr,
		[Optional] string GLVouchers,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJournalBalanceExt = new JournalBalanceFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJournalBalanceExt.JournalBalanceSp(JournalId,
				BalDr,
				BalCr,
				RevDr,
				RevCr,
				GLVouchers,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				BalDr = result.BalDr;
				BalCr = result.BalCr;
				RevDr = result.RevDr;
				RevCr = result.RevCr;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JournalBuilderProcessSp(DateTime? PTransactionDate,
		string PToSite,
		string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		decimal? PDomAmount,
		string PRef,
		string PControlPrefix,
		string PControlSite,
		int? PControlYear,
		int? PControlPeriod,
		decimal? PControlNumber)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJournalBuilderProcessExt = new JournalBuilderProcessFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJournalBuilderProcessExt.JournalBuilderProcessSp(PTransactionDate,
				PToSite,
				PAcct,
				PAcctUnit1,
				PAcctUnit2,
				PAcctUnit3,
				PAcctUnit4,
				PDomAmount,
				PRef,
				PControlPrefix,
				PControlSite,
				PControlYear,
				PControlPeriod,
				PControlNumber);
				
				int Severity = result.Value;
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

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JournalCalcForAmtSp(int? PRecalcFor,
		decimal? PDomAmtDr,
		decimal? PDomAmtCr,
		string PCurrCode,
		ref decimal? PForAmtDr,
		ref decimal? PForAmtCr,
		ref decimal? PExchRate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJournalCalcForAmtExt = new JournalCalcForAmtFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJournalCalcForAmtExt.JournalCalcForAmtSp(PRecalcFor,
				PDomAmtDr,
				PDomAmtCr,
				PCurrCode,
				PForAmtDr,
				PForAmtCr,
				PExchRate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PForAmtDr = result.PForAmtDr;
				PForAmtCr = result.PForAmtCr;
				PExchRate = result.PExchRate;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JournalCreateSnapShotSp(Guid? PSessionID,
		string CurId,
		DateTime? CompressDate,
		ref string Infobar,
		ref int? MaxSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJournalCreateSnapShotExt = new JournalCreateSnapShotFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJournalCreateSnapShotExt.JournalCreateSnapShotSp(PSessionID,
				CurId,
				CompressDate,
				Infobar,
				MaxSeq);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				MaxSeq = result.MaxSeq;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JournalEntriesValidateIdSp(string PId,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string Infobar,
		[Optional] string Callfrom,
		[Optional] string GLVouchers)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJournalEntriesValidateIdExt = new JournalEntriesValidateIdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJournalEntriesValidateIdExt.JournalEntriesValidateIdSp(PId,
				PromptMsg,
				PromptButtons,
				Infobar,
				Callfrom,
				GLVouchers);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JournalGetCashAccountBankCodeSp(string PAcct,
		ref string PBankCode,
		ref string PCurrCode,
		[Optional] string AcctUnit1,
		[Optional] string AcctUnit2,
		[Optional] string AcctUnit3,
		[Optional] string AcctUnit4)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJournalGetCashAccountBankCodeExt = new JournalGetCashAccountBankCodeFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJournalGetCashAccountBankCodeExt.JournalGetCashAccountBankCodeSp(PAcct,
				PBankCode,
				PCurrCode,
				AcctUnit1,
				AcctUnit2,
				AcctUnit3,
				AcctUnit4);
				
				int Severity = result.ReturnCode.Value;
				PBankCode = result.PBankCode;
				PCurrCode = result.PCurrCode;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable JournalSumSp(string PJournalID,
		string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJournalSumExt = new JournalSumFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJournalSumExt.JournalSumSp(PJournalID,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JournalValidBankCodeSp(string PBankCode,
		string PAcct,
		ref string PCurrCode,
		ref string Infobar,
		[Optional] string AcctUnit1,
		[Optional] string AcctUnit2,
		[Optional] string AcctUnit3,
		[Optional] string AcctUnit4)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJournalValidBankCodeExt = new JournalValidBankCodeFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJournalValidBankCodeExt.JournalValidBankCodeSp(PBankCode,
				PAcct,
				PCurrCode,
				Infobar,
				AcctUnit1,
				AcctUnit2,
				AcctUnit3,
				AcctUnit4);
				
				int Severity = result.ReturnCode.Value;
				PCurrCode = result.PCurrCode;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JP_SaveJournalTaxSp(int? JPTaxable,
		Guid? RowPointer,
		string JPTaxCode,
		decimal? JPTaxRate,
		decimal? JPTaxAmount,
		int? JPEntryIsTax)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJP_SaveJournalTaxExt = new JP_SaveJournalTaxFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJP_SaveJournalTaxExt.JP_SaveJournalTaxSp(JPTaxable,
				RowPointer,
				JPTaxCode,
				JPTaxRate,
				JPTaxAmount,
				JPEntryIsTax);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LedgerDimAttributesOverrideUpdateSp(Guid? SubscriberObjectRowpointer,
		string AnalysisAttributeValue01,
		string AnalysisAttributeValue02,
		string AnalysisAttributeValue03,
		string AnalysisAttributeValue04,
		string AnalysisAttributeValue05,
		string AnalysisAttributeValue06,
		string AnalysisAttributeValue07,
		string AnalysisAttributeValue08,
		string AnalysisAttributeValue09,
		string AnalysisAttributeValue10,
		string AnalysisAttributeValue11,
		string AnalysisAttributeValue12,
		string AnalysisAttributeValue13,
		string AnalysisAttributeValue14,
		string AnalysisAttributeValue15)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLedgerDimAttributesOverrideUpdateExt = new LedgerDimAttributesOverrideUpdateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLedgerDimAttributesOverrideUpdateExt.LedgerDimAttributesOverrideUpdateSp(SubscriberObjectRowpointer,
				AnalysisAttributeValue01,
				AnalysisAttributeValue02,
				AnalysisAttributeValue03,
				AnalysisAttributeValue04,
				AnalysisAttributeValue05,
				AnalysisAttributeValue06,
				AnalysisAttributeValue07,
				AnalysisAttributeValue08,
				AnalysisAttributeValue09,
				AnalysisAttributeValue10,
				AnalysisAttributeValue11,
				AnalysisAttributeValue12,
				AnalysisAttributeValue13,
				AnalysisAttributeValue14,
				AnalysisAttributeValue15);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int NextControlNumberSp([Optional] string SubKey,
		[Optional] string JournalId,
		[Optional, DefaultParameterValue(0)] int? UpdatePeriodsSeqOnly,
		[Optional] ref string ControlPrefix,
		[Optional] ref string ControlSite,
		[Optional] DateTime? TransDate,
		[Optional] ref int? ControlYear,
		[Optional] ref int? ControlPeriod,
		[Optional] string SequenceBy,
		ref decimal? ControlNumber,
		ref string Infobar,
		[Optional] ref decimal? OldControlNumber)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iNextControlNumberExt = new NextControlNumberFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iNextControlNumberExt.NextControlNumberSp(SubKey,
				JournalId,
				UpdatePeriodsSeqOnly,
				ControlPrefix,
				ControlSite,
				TransDate,
				ControlYear,
				ControlPeriod,
				SequenceBy,
				ControlNumber,
				Infobar,
				OldControlNumber);
				
				int Severity = result.ReturnCode.Value;
				ControlPrefix = result.ControlPrefix;
				ControlSite = result.ControlSite;
				ControlYear = result.ControlYear;
				ControlPeriod = result.ControlPeriod;
				ControlNumber = result.ControlNumber;
				Infobar = result.Infobar;
				OldControlNumber = result.OldControlNumber;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UPD_JourTransMaintSp(string pJournalId,
		int? pSeq,
		DateTime? pTransDate,
		string pAcct,
		string pAcctUnit1,
		string pAcctUnit2,
		string pAcctUnit3,
		string pAcctUnit4,
		decimal? pDomAmount)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iUPD_JourTransMaintExt = new UPD_JourTransMaintFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iUPD_JourTransMaintExt.UPD_JourTransMaintSp(pJournalId,
				pSeq,
				pTransDate,
				pAcct,
				pAcctUnit1,
				pAcctUnit2,
				pAcctUnit3,
				pAcctUnit4,
				pDomAmount);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
