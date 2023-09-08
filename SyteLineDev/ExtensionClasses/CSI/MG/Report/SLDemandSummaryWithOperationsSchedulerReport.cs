//PROJECT NAME: ReportExt
//CLASS NAME: SLDemandSummaryWithOperationsSchedulerReport.cs

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
	[IDOExtensionClass("SLDemandSummaryWithOperationsSchedulerReport")]
	public class SLDemandSummaryWithOperationsSchedulerReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_DemandSummaryWithOperationsSchedulerSp([Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] DateTime? StartDate,
		[Optional] DateTime? EndDate,
		[Optional, DefaultParameterValue(0)] int? AltNum,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_DemandSummaryWithOperationsSchedulerExt = new Rpt_DemandSummaryWithOperationsSchedulerFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_DemandSummaryWithOperationsSchedulerExt.Rpt_DemandSummaryWithOperationsSchedulerSp(ItemStarting,
				ItemEnding,
				StartDate,
				EndDate,
				AltNum,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
