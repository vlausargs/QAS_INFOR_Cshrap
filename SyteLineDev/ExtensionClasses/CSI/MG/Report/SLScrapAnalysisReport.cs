//PROJECT NAME: ReportExt
//CLASS NAME: SLScrapAnalysisReport.cs

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
    [IDOExtensionClass("SLScrapAnalysisReport")]
    public class SLScrapAnalysisReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ScrapAnalysisSp([Optional] string PStartingItem,
		[Optional] string PEndingItem,
		[Optional] string PStartingProdCode,
		[Optional] string PEndingProdCode,
		[Optional] DateTime? PStartingJobDate,
		[Optional] DateTime? PEndingJobDate,
		[Optional, DefaultParameterValue("RSCH")] string PJobStatus,
		[Optional, DefaultParameterValue(1)] int? PPageBetweenItem,
		[Optional, DefaultParameterValue(1)] int? PShowDetail,
		[Optional, DefaultParameterValue("I")] string PSortBy,
		[Optional] int? PStartingJobDateOffset,
		[Optional] int? PEndingJobDateOffset,
		[Optional, DefaultParameterValue(1)] int? PDisplayHeader,
		[Optional] string PStartingJob,
		[Optional] string PEndingJob,
		[Optional] int? PStartingJobSuffix,
		[Optional] int? PEndingJobSuffix,
		[Optional] string PStartingWorkCenter,
		[Optional] string PEndingWorkCenter,
		[Optional] string PStartingReason,
		[Optional] string PEndingReason,
		[Optional] DateTime? PStartingTransDate,
		[Optional] DateTime? PEndingTransDate,
		[Optional] int? PStartingTransDateOffset,
		[Optional] int? PEndingTransDateOffset,
		[Optional] string BGSessionId,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ScrapAnalysisExt = new Rpt_ScrapAnalysisFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ScrapAnalysisExt.Rpt_ScrapAnalysisSp(PStartingItem,
				PEndingItem,
				PStartingProdCode,
				PEndingProdCode,
				PStartingJobDate,
				PEndingJobDate,
				PJobStatus,
				PPageBetweenItem,
				PShowDetail,
				PSortBy,
				PStartingJobDateOffset,
				PEndingJobDateOffset,
				PDisplayHeader,
				PStartingJob,
				PEndingJob,
				PStartingJobSuffix,
				PEndingJobSuffix,
				PStartingWorkCenter,
				PEndingWorkCenter,
				PStartingReason,
				PEndingReason,
				PStartingTransDate,
				PEndingTransDate,
				PStartingTransDateOffset,
				PEndingTransDateOffset,
				BGSessionId,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
