//PROJECT NAME: ReportExt
//CLASS NAME: SLRollCurrentCosttoStandardCostReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLRollCurrentCosttoStandardCostReport")]
    public class SLRollCurrentCosttoStandardCostReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RollCurrentCosttoStandardCostSp([Optional] string Post,
		[Optional] string FromProductCode,
		[Optional] string ToProductCode,
		[Optional] string FromItem,
		[Optional] string ToItem,
		[Optional] string FromWarehouse,
		[Optional] string ToWarehouse,
		[Optional] string Source,
		[Optional] string ABC,
		[Optional] string CostMethod,
		[Optional] string MatlType,
		[Optional] int? DisplayHeader,
		[Optional] decimal? UserID,
		[Optional] string BGSessionId,
		[Optional] string pSite,
        [Optional] int? DebugLevel,
        [Optional] int? TaskId,
        [Optional] int? CommitSize)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RollCurrentCosttoStandardCostExt = new Rpt_RollCurrentCosttoStandardCostFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RollCurrentCosttoStandardCostExt.Rpt_RollCurrentCosttoStandardCostSp(Post,
				FromProductCode,
				ToProductCode,
				FromItem,
				ToItem,
				FromWarehouse,
				ToWarehouse,
				Source,
				ABC,
				CostMethod,
				MatlType,
				DisplayHeader,
				UserID,
				BGSessionId,
				pSite,
                DebugLevel,
                TaskId,
                CommitSize);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
