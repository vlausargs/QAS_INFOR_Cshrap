//PROJECT NAME: FinanceExt
//CLASS NAME: SLTTJournals.cs

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
    [IDOExtensionClass("SLTTJournals")]
    public class SLTTJournals : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MassJourPostingPredispSP(ref DateTime? RStartDate,
                                            ref DateTime? REndDate,
                                            ref DateTime? FiscalYearStartDate,
                                            ref DateTime? FiscalYearEndDate,
                                            ref short? FiscalYear,
                                            ref string ROutOfRange,
                                            ref string RToPost,
                                            ref string RToPrint,
                                            ref string RPosted,
                                            ref string REmpty,
                                            ref string Infobar,
                                            ref byte? AvailChinFin)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iMassJourPostingPredispExt = new MassJourPostingPredispFactory().Create(appDb);

                DateType oRStartDate = RStartDate;
                DateType oREndDate = REndDate;
                DateType oFiscalYearStartDate = FiscalYearStartDate;
                DateType oFiscalYearEndDate = FiscalYearEndDate;
                FiscalYearType oFiscalYear = FiscalYear;
                InfobarType oROutOfRange = ROutOfRange;
                InfobarType oRToPost = RToPost;
                InfobarType oRToPrint = RToPrint;
                InfobarType oRPosted = RPosted;
                InfobarType oREmpty = REmpty;
                InfobarType oInfobar = Infobar;
                FlagNyType oAvailChinFin = AvailChinFin;

                int Severity = iMassJourPostingPredispExt.MassJourPostingPredispSP(ref oRStartDate,
                                                                                   ref oREndDate,
                                                                                   ref oFiscalYearStartDate,
                                                                                   ref oFiscalYearEndDate,
                                                                                   ref oFiscalYear,
                                                                                   ref oROutOfRange,
                                                                                   ref oRToPost,
                                                                                   ref oRToPrint,
                                                                                   ref oRPosted,
                                                                                   ref oREmpty,
                                                                                   ref oInfobar,
                                                                                   ref oAvailChinFin);

                RStartDate = oRStartDate;
                REndDate = oREndDate;
                FiscalYearStartDate = oFiscalYearStartDate;
                FiscalYearEndDate = oFiscalYearEndDate;
                FiscalYear = oFiscalYear;
                ROutOfRange = oROutOfRange;
                RToPost = oRToPost;
                RToPrint = oRToPrint;
                RPosted = oRPosted;
                REmpty = oREmpty;
                Infobar = oInfobar;
                AvailChinFin = oAvailChinFin;


                return Severity;
            }
        }
       



















		[IDOMethod(MethodFlags.None, "Infobar")]
		public int IsRecurringJourPosted(string JourId,
		                                 DateTime? TransactionDate,
		                                 byte? SingleDate,
		                                 [Optional] string StartingGLVoucher,
		                                 [Optional] string EndingGLVoucher,
		                                 ref string PromptButtons,
		                                 ref string PromptMessage,
		                                 ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iIsRecurringJourPostExt = new IsRecurringJourPostFactory().Create(appDb);
				
				var result = iIsRecurringJourPostExt.IsRecurringJourPosted(JourId,
				                                                           TransactionDate,
				                                                           SingleDate,
				                                                           StartingGLVoucher,
				                                                           EndingGLVoucher,
				                                                           PromptButtons,
				                                                           PromptMessage,
				                                                           Infobar);
				
				int Severity = result.ReturnCode.Value;
				PromptButtons = result.PromptButtons;
				PromptMessage = result.PromptMessage;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TTJournalGLPostSp(byte? PCompressJournals,
		                             string PCompressionLevel,
		                             byte? PDeleteJournals,
		                             DateTime? PReversingDate,
		                             byte? PSingleDateForTnx,
		                             DateTime? PSingleDateToUse,
		                             DateTime? PPostThroughDate,
		                             string PJournalId,
		                             int? PLastSeq,
		                             Guid? SessionID,
		                             byte? POverrideWarning,
		                             decimal? PJournalBatchId,
		                             decimal? UserID,
		                             ref string Message,
		                             ref string Infobar,
		                             [Optional] string FSBName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTTJournalGLPostExt = new TTJournalGLPostFactory().Create(appDb);
				
				var result = iTTJournalGLPostExt.TTJournalGLPostSp(PCompressJournals,
				                                                   PCompressionLevel,
				                                                   PDeleteJournals,
				                                                   PReversingDate,
				                                                   PSingleDateForTnx,
				                                                   PSingleDateToUse,
				                                                   PPostThroughDate,
				                                                   PJournalId,
				                                                   PLastSeq,
				                                                   SessionID,
				                                                   POverrideWarning,
				                                                   PJournalBatchId,
				                                                   UserID,
				                                                   Message,
				                                                   Infobar,
				                                                   FSBName);
				
				int Severity = result.ReturnCode.Value;
				Message = result.Message;
				Infobar = result.Infobar;
				return Severity;
			}
		}










		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TTJournalDeleteSp(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTTJournalDeleteExt = new TTJournalDeleteFactory().Create(appDb);
				
				var result = iTTJournalDeleteExt.TTJournalDeleteSp(Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TTJournalGetTextSp(ref string ROutOfRange,
		ref string RToPost,
		ref string RToPrint,
		ref string RPosted,
		ref string REmpty,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTTJournalGetTextExt = new TTJournalGetTextFactory().Create(appDb);
				
				var result = iTTJournalGetTextExt.TTJournalGetTextSp(ROutOfRange,
				RToPost,
				RToPrint,
				RPosted,
				REmpty,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				ROutOfRange = result.ROutOfRange;
				RToPost = result.RToPost;
				RToPrint = result.RToPrint;
				RPosted = result.RPosted;
				REmpty = result.REmpty;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TTJournalInitLocksSp([Optional, DefaultParameterValue(0)] int? OverrideLock,
		[Optional] ref string PromptMsg,
		[Optional] ref string PromptButtons,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] int? CallFromBG,
		[Optional, DefaultParameterValue(0)] decimal? UserId,
		[Optional] string CallFormCap)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTTJournalInitLocksExt = new TTJournalInitLocksFactory().Create(appDb);
				
				var result = iTTJournalInitLocksExt.TTJournalInitLocksSp(OverrideLock,
				PromptMsg,
				PromptButtons,
				Infobar,
				CallFromBG,
				UserId,
				CallFormCap);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TTJournalUpdate(Guid? PRowPointer,
		int? PPost,
		string PJStatus,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTTJournalUpdaExt = new TTJournalUpdaFactory().Create(appDb);
				
				var result = iTTJournalUpdaExt.TTJournalUpdate(PRowPointer,
				PPost,
				PJStatus,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TTJournalVerifyCloseFormSp(Guid? PSessionID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTTJournalVerifyCloseFormExt = new TTJournalVerifyCloseFormFactory().Create(appDb);
				
				var result = iTTJournalVerifyCloseFormExt.TTJournalVerifyCloseFormSp(PSessionID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TTJournalVerifyPrintSp(ref Guid? PSessionID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTTJournalVerifyPrintExt = new TTJournalVerifyPrintFactory().Create(appDb);
				
				var result = iTTJournalVerifyPrintExt.TTJournalVerifyPrintSp(PSessionID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PSessionID = result.PSessionID;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TTMassJournalVerifyPrintNotesSp(string PSessionID,
		ref int? CompleteFlag,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTTMassJournalVerifyPrintNotesExt = new TTMassJournalVerifyPrintNotesFactory().Create(appDb);
				
				var result = iTTMassJournalVerifyPrintNotesExt.TTMassJournalVerifyPrintNotesSp(PSessionID,
				CompleteFlag,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				CompleteFlag = result.CompleteFlag;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TTMassJournalVerifyPrintSp(Guid? PSessionID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTTMassJournalVerifyPrintExt = new TTMassJournalVerifyPrintFactory().Create(appDb);
				
				var result = iTTMassJournalVerifyPrintExt.TTMassJournalVerifyPrintSp(PSessionID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetLedgerBatchCounterSp(ref decimal? OperationCounter,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetLedgerBatchCounterExt = new GetLedgerBatchCounterFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetLedgerBatchCounterExt.GetLedgerBatchCounterSp(OperationCounter,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				OperationCounter = result.OperationCounter;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GlPostDeleteTTSp(Guid? PSessionID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGlPostDeleteTTExt = new GlPostDeleteTTFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGlPostDeleteTTExt.GlPostDeleteTTSp(PSessionID);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GlPostSp4(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGlPost4Ext = new GlPost4Factory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGlPost4Ext.GlPostSp4(Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int JournalNoTableLockJobSp(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iJournalNoTableLockJobExt = new JournalNoTableLockJobFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iJournalNoTableLockJobExt.JournalNoTableLockJobSp(Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MassJournalPostBkSp(int? CompressJournals,
		string CompressionLevel,
		int? JournalsToPost,
		int? OverrideWarning,
		decimal? UserId,
		string CurrentCultureName,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMassJournalPostBkExt = new MassJournalPostBkFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMassJournalPostBkExt.MassJournalPostBkSp(CompressJournals,
				CompressionLevel,
				JournalsToPost,
				OverrideWarning,
				UserId,
				CurrentCultureName,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable TTJournalLoadSp(int? PRebuildTable,
		DateTime? PostDate,
		[Optional] Guid? SessionID,
		[Optional, DefaultParameterValue(0)] int? CallFromBG)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTTJournalLoadExt = new TTJournalLoadFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTTJournalLoadExt.TTJournalLoadSp(PRebuildTable,
				PostDate,
				SessionID,
				CallFromBG);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TTJournalPostSp(int? PCompressJournals,
		string PCompressionLevel,
		int? PDeleteJournals,
		DateTime? PReversingDate,
		int? PSingleDateForTnx,
		DateTime? PSingleDateToUse,
		DateTime? PPostThroughDate,
		string PJournalId,
		int? PLastSeq,
		Guid? SessionID,
		int? POverrideWarning,
		ref string Message,
		decimal? PJournalBatchId,
		ref string Infobar,
		[Optional] string FSBName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTTJournalPostExt = new TTJournalPostFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTTJournalPostExt.TTJournalPostSp(PCompressJournals,
				PCompressionLevel,
				PDeleteJournals,
				PReversingDate,
				PSingleDateForTnx,
				PSingleDateToUse,
				PPostThroughDate,
				PJournalId,
				PLastSeq,
				SessionID,
				POverrideWarning,
				Message,
				PJournalBatchId,
				Infobar,
				FSBName);
				
				int Severity = result.ReturnCode.Value;
				Message = result.Message;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckForOutOfPeriodSp(string PJournalId,
		Guid? PSessionID,
		ref int? OutOfPeriod,
		ref int? Closed,
		ref int? FiscalYear,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] int? PSingleDateForTnx,
		[Optional] DateTime? PSingleDateToUse,
		ref int? TransPeriod)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCheckForOutOfPeriodExt = new CheckForOutOfPeriodFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCheckForOutOfPeriodExt.CheckForOutOfPeriodSp(PJournalId,
				PSessionID,
				OutOfPeriod,
				Closed,
				FiscalYear,
				Infobar,
				PSingleDateForTnx,
				PSingleDateToUse,
				TransPeriod);
				
				int Severity = result.ReturnCode.Value;
				OutOfPeriod = result.OutOfPeriod;
				Closed = result.Closed;
				FiscalYear = result.FiscalYear;
				Infobar = result.Infobar;
				TransPeriod = result.TransPeriod;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GlMassPostCreateTTSp(Guid? PSessionID,
		DateTime? PostThroughDate,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGlMassPostCreateTTExt = new GlMassPostCreateTTFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGlMassPostCreateTTExt.GlMassPostCreateTTSp(PSessionID,
				PostThroughDate,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LedgerPostingForJourCloseSp(Guid? PSessionID,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLedgerPostingForJourCloseExt = new LedgerPostingForJourCloseFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLedgerPostingForJourCloseExt.LedgerPostingForJourCloseSp(PSessionID,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}