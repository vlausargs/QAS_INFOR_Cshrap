//PROJECT NAME: ReportExt
//CLASS NAME: SLJobsAffectedByEngineeringChangeNoticesReport.cs

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
    [IDOExtensionClass("SLJobsAffectedByEngineeringChangeNoticesReport")]
    public class SLJobsAffectedByEngineeringChangeNoticesReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_JobsAffectedByEngineeringChangeNoticesSp([Optional] int? ECNStarting,
		[Optional] int? ECNEnding,
		[Optional] string ECNStatus,
		[Optional] string JobType,
		[Optional] int? ECNPrintWHEREUsed,
		[Optional] int? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_JobsAffectedByEngineeringChangeNoticesExt = new Rpt_JobsAffectedByEngineeringChangeNoticesFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_JobsAffectedByEngineeringChangeNoticesExt.Rpt_JobsAffectedByEngineeringChangeNoticesSp(ECNStarting,
				ECNEnding,
				ECNStatus,
				JobType,
				ECNPrintWHEREUsed,
				DisplayHeader,
				BGSessionId,
				TaskId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
