//PROJECT NAME: PmfExt
//CLASS NAME: PmfVPoReceiptTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.ProcessManufacturing;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.PMF
{
    [IDOExtensionClass("PmfVPoReceiptTrans")]
    public class PmfVPoReceiptTrans : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable LoadFromRecall([Optional] ref string InfoBar,
		                                Guid? RecallRp,
		                                [Optional] string Lineage,
		                                [Optional, DefaultParameterValue(1)] int? Forward,
		                                [Optional, DefaultParameterValue(0)] int? Backward)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iPmfRecallLoadPoReceiptExt = new PmfRecallLoadPoReceiptFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iPmfRecallLoadPoReceiptExt.PmfRecallLoadPoReceiptSp(InfoBar,
				                                                                 RecallRp,
				                                                                 Lineage,
				                                                                 Forward,
				                                                                 Backward);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				InfoBar = result.InfoBar;
				return dt;
			}
		}
    }
}
