//PROJECT NAME: ReportExt
//CLASS NAME: SLIndentedProjectedJobCosttoCompleteReport.cs

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
	[IDOExtensionClass("SLIndentedProjectedJobCosttoCompleteReport")]
	public class SLIndentedProjectedJobCosttoCompleteReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_IndentedProjectedJobCosttoCompleteSp([Optional] string PStartingJob,
		[Optional] string PEndingJob,
		[Optional] int? PStartingSubJob,
		[Optional] int? PEndingSubJob,
		[Optional] string PJobStatus,
		[Optional] decimal? PUnderPlanVar,
		[Optional] decimal? POverPlanVar,
		[Optional] string PStartingItem,
		[Optional] string PEndingItem,
		[Optional, DefaultParameterValue(1)] int? PDisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_IndentedProjectedJobCosttoCompleteExt = new Rpt_IndentedProjectedJobCosttoCompleteFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_IndentedProjectedJobCosttoCompleteExt.Rpt_IndentedProjectedJobCosttoCompleteSp(PStartingJob,
				PEndingJob,
				PStartingSubJob,
				PEndingSubJob,
				PJobStatus,
				PUnderPlanVar,
				POverPlanVar,
				PStartingItem,
				PEndingItem,
				PDisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
