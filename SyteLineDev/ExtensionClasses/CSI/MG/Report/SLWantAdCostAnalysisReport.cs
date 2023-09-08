//PROJECT NAME: ReportExt
//CLASS NAME: SLWantAdCostAnalysisReport.cs

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
	[IDOExtensionClass("SLWantAdCostAnalysisReport")]
	public class SLWantAdCostAnalysisReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_WantAdCostAnalysisSp([Optional] int? PWaNumStarting,
		[Optional] int? PWaNumEnding,
		[Optional] DateTime? PDateStarting,
		[Optional] DateTime? PDateEnding,
		[Optional] string PSortBy,
		[Optional, DefaultParameterValue(0)] int? PPrintCost,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_WantAdCostAnalysisExt = new Rpt_WantAdCostAnalysisFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_WantAdCostAnalysisExt.Rpt_WantAdCostAnalysisSp(PWaNumStarting,
				PWaNumEnding,
				PDateStarting,
				PDateEnding,
				PSortBy,
				PPrintCost,
				PSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
