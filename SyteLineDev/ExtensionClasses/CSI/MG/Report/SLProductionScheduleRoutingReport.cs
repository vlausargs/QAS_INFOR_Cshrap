//PROJECT NAME: ReportExt
//CLASS NAME: SLProductionScheduleRoutingReport.cs

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
    [IDOExtensionClass("SLProductionScheduleRoutingReport")]
    public class SLProductionScheduleRoutingReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProductionScheduleRoutingSp([Optional] string StartScheduleID,
		[Optional] string EndScheduleID,
		[Optional] string StartItem,
		[Optional] string EndItem,
		[Optional] DateTime? StartDueDate,
		[Optional] DateTime? EndDueDate,
		[Optional] string ScheduleIDStat,
		[Optional] string ScheduleReleaseStat,
		[Optional] int? PrintBarcodeFmt,
		[Optional] string BarcodeWhichOper,
		[Optional] int? ShowInternal,
		[Optional] int? ShowExternal,
		[Optional] int? JobRouteNotes,
		[Optional] int? JobMatlNotes,
		[Optional] int? IncludePSRel,
		[Optional] int? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProductionScheduleRoutingExt = new Rpt_ProductionScheduleRoutingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProductionScheduleRoutingExt.Rpt_ProductionScheduleRoutingSp(StartScheduleID,
				EndScheduleID,
				StartItem,
				EndItem,
				StartDueDate,
				EndDueDate,
				ScheduleIDStat,
				ScheduleReleaseStat,
				PrintBarcodeFmt,
				BarcodeWhichOper,
				ShowInternal,
				ShowExternal,
				JobRouteNotes,
				JobMatlNotes,
				IncludePSRel,
				DisplayHeader,
				BGSessionId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
