//PROJECT NAME: ReportExt
//CLASS NAME: SLProjectedItemCompletionsMRPAPSReport.cs

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
	[IDOExtensionClass("SLProjectedItemCompletionsMRPAPSReport")]
	public class SLProjectedItemCompletionsMRPAPSReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProjectedItemCompletionsMrpApsSp([Optional] string PlannerCodeStarting,
		[Optional] string PlannerCodeEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] DateTime? StartDate,
		[Optional] DateTime? EndDate,
		[Optional] int? StartDateOffSet,
		[Optional] int? EndDateOffSet,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProjectedItemCompletionsMrpApsExt = new Rpt_ProjectedItemCompletionsMrpApsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProjectedItemCompletionsMrpApsExt.Rpt_ProjectedItemCompletionsMrpApsSp(PlannerCodeStarting,
				PlannerCodeEnding,
				ItemStarting,
				ItemEnding,
				StartDate,
				EndDate,
				StartDateOffSet,
				EndDateOffSet,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
