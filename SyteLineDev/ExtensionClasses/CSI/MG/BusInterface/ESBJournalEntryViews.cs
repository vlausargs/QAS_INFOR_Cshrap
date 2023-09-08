//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBJournalEntryViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBJournalEntryViews")]
	public class ESBJournalEntryViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBJournalEntrySP(decimal? BatchID,
		string ControlPrefix,
		string ControlSite,
		int? ControlYear,
		int? ControlPeriod,
		decimal? ControlNumber,
		string AdjustmentSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBJournalEntryExt = new CLM_ESBJournalEntryFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBJournalEntryExt.CLM_ESBJournalEntrySP(BatchID,
				ControlPrefix,
				ControlSite,
				ControlYear,
				ControlPeriod,
				ControlNumber,
				AdjustmentSeq);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
