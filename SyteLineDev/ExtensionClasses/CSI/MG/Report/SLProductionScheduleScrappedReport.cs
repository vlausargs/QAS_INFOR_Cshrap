//PROJECT NAME: ReportExt
//CLASS NAME: SLProductionScheduleScrappedReport.cs

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
    [IDOExtensionClass("SLProductionScheduleScrappedReport")]
    public class SLProductionScheduleScrappedReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProductionScheduleScrappedSp([Optional] DateTime? TransDateStarting,
		[Optional] DateTime? TransDateEnding,
		[Optional] string ScheduleIdStarting,
		[Optional] string ScheduleIdEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] int? TransDateStartingOffset,
		[Optional] int? TransDateEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite,
		[Optional] string DocumentNumStarting,
		[Optional] string DocumentNumEnding)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProductionScheduleScrappedExt = new Rpt_ProductionScheduleScrappedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProductionScheduleScrappedExt.Rpt_ProductionScheduleScrappedSp(TransDateStarting,
				TransDateEnding,
				ScheduleIdStarting,
				ScheduleIdEnding,
				ItemStarting,
				ItemEnding,
				TransDateStartingOffset,
				TransDateEndingOffset,
				DisplayHeader,
				pSite,
				DocumentNumStarting,
				DocumentNumEnding);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
