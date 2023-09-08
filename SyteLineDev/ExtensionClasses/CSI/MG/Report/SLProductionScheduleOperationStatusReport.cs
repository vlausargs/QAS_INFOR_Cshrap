//PROJECT NAME: ReportExt
//CLASS NAME: SLProductionScheduleOperationStatusReport.cs

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
    [IDOExtensionClass("SLProductionScheduleOperationStatusReport")]
    public class SLProductionScheduleOperationStatusReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProductionScheduleOperationStatusSp([Optional] string ScheduleIDStarting,
		[Optional] string ScheduleIDEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] DateTime? DateStarting,
		[Optional] DateTime? DateEnding,
		[Optional] string ScheduleIDStatus,
		[Optional] string ScheduleReleaseStatus,
		[Optional] int? ControlPointsOnly,
		[Optional] int? DateStartingOffset,
		[Optional] int? DateEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProductionScheduleOperationStatusExt = new Rpt_ProductionScheduleOperationStatusFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProductionScheduleOperationStatusExt.Rpt_ProductionScheduleOperationStatusSp(ScheduleIDStarting,
				ScheduleIDEnding,
				ItemStarting,
				ItemEnding,
				DateStarting,
				DateEnding,
				ScheduleIDStatus,
				ScheduleReleaseStatus,
				ControlPointsOnly,
				DateStartingOffset,
				DateEndingOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
