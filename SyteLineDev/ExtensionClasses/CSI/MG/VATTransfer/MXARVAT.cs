//PROJECT NAME: VATTransferExt
//CLASS NAME: MXARVAT.cs

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
    [IDOExtensionClass("MXARVAT")]
    public class MXARVAT : ExtensionClassBase
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

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_MXVATARTransferSp([Optional] DateTime? StartingReconDate,
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
				
				var iMXVATARTransferExt = new MXVATARTransferFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iMXVATARTransferExt.MXVATARTransferSp(StartingReconDate,
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
    }
}
