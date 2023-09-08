//PROJECT NAME: VATTransferExt
//CLASS NAME: MXAPVAT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Finance.Mexican;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.VATTransfer
{
	[IDOExtensionClass("MXAPVAT")]
	public class MXAPVAT : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MXJourLockSp(string Id,
		                        decimal? LockUserid,
		                        int? LockJournal,
		                        ref byte? JournalLocked,
		                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMXJourLockExt = new MXJourLockFactory().Create(appDb);
				
				int Severity = iMXJourLockExt.MXJourLockSp(Id,
				                                           LockUserid,
				                                           LockJournal,
				                                           ref JournalLocked,
				                                           ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MXDIOTReportValidateSp([Optional] DateTime? ReconDateStarting,
		                                  [Optional] DateTime? ReconDateEnding,
		                                  [Optional] byte? EndPeriod,
		                                  [Optional] short? FiscalYear,
		                                  [Optional, DefaultParameterValue((byte)0)] byte? Reprint,
		[Optional] ref string BGTaskName,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMXDIOTReportValidateExt = new MXDIOTReportValidateFactory().Create(appDb);
				
				var result = iMXDIOTReportValidateExt.MXDIOTReportValidateSp(ReconDateStarting,
				                                                             ReconDateEnding,
				                                                             EndPeriod,
				                                                             FiscalYear,
				                                                             Reprint,
				                                                             BGTaskName,
				                                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				BGTaskName = result.BGTaskName;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_MXAPVATTransfer([Optional] DateTime? StartingReconDate,
		[Optional] DateTime? EndingReconDate,
		[Optional] string StartingBankCode,
		[Optional] string EndingBankCode,
		[Optional, DefaultParameterValue("P")] string PrintOrCommit,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iMXVATAPTransferExt = new MXVATAPTransferFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iMXVATAPTransferExt.MXVATAPTransferSp(StartingReconDate,
				EndingReconDate,
				StartingBankCode,
				EndingBankCode,
				PrintOrCommit,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MXDIOTFileGenSp([Optional] ref string outFileName,
		[Optional] ref string outFileContent,
		[Optional] DateTime? ReconDateStarting,
		[Optional] DateTime? ReconDateEnding,
		[Optional] int? EndPeriod,
		[Optional] int? FiscalYear,
		[Optional, DefaultParameterValue(0)] int? Reprint,
		[Optional, DefaultParameterValue(0)] int? Close,
		[Optional, DefaultParameterValue("C")] string PrintOrCommit)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMXDIOTFileGenExt = new MXDIOTFileGenFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMXDIOTFileGenExt.MXDIOTFileGenSp(outFileName,
				outFileContent,
				ReconDateStarting,
				ReconDateEnding,
				EndPeriod,
				FiscalYear,
				Reprint,
				Close,
				PrintOrCommit);
				
				int Severity = result.ReturnCode.Value;
				outFileName = result.outFileName;
				outFileContent = result.outFileContent;
				return Severity;
			}
		}
    }
}
