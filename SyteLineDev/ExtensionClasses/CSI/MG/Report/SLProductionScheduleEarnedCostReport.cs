//PROJECT NAME: ReportExt
//CLASS NAME: SLProductionScheduleEarnedCostReport.cs

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
    [IDOExtensionClass("SLProductionScheduleEarnedCostReport")]
    public class SLProductionScheduleEarnedCostReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProductionScheduleEarnedCostSp([Optional] DateTime? TransDateStarting,
		[Optional] DateTime? TransDateEnding,
		[Optional] string ScheduleIdStarting,
		[Optional] string ScheduleIdEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] int? TransDateStartingOffset,
		[Optional] int? TransDateEndingOffset,
		[Optional, DefaultParameterValue(0)] int? PrintCost,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProductionScheduleEarnedCostExt = new Rpt_ProductionScheduleEarnedCostFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProductionScheduleEarnedCostExt.Rpt_ProductionScheduleEarnedCostSp(TransDateStarting,
				TransDateEnding,
				ScheduleIdStarting,
				ScheduleIdEnding,
				ItemStarting,
				ItemEnding,
				TransDateStartingOffset,
				TransDateEndingOffset,
				PrintCost,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
