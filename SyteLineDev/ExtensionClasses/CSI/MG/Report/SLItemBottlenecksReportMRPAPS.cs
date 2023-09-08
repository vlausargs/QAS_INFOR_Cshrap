//PROJECT NAME: ReportExt
//CLASS NAME: SLItemBottlenecksReportMRPAPS.cs

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
	[IDOExtensionClass("SLItemBottlenecksReportMRPAPS")]
	public class SLItemBottlenecksReportMRPAPS : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItemBottlenecksMRPAPSSp([Optional] string SourceType,
		[Optional] int? ListDelayedDemands,
		[Optional] string PlannerCodeStarting,
		[Optional] string PlannerCodeEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] int? DisplayHeader,
		[Optional] int? ALTNO,
		[Optional] string pSite,
		[Optional] DateTime? StartDate,
		[Optional] DateTime? EndDate,
		[Optional] string BuyerStart,
		[Optional] string BuyerEnd)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ItemBottlenecksMRPAPSExt = new Rpt_ItemBottlenecksMRPAPSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ItemBottlenecksMRPAPSExt.Rpt_ItemBottlenecksMRPAPSSp(SourceType,
				ListDelayedDemands,
				PlannerCodeStarting,
				PlannerCodeEnding,
				ItemStarting,
				ItemEnding,
				DisplayHeader,
				ALTNO,
				pSite,
				StartDate,
				EndDate,
				BuyerStart,
				BuyerEnd);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
