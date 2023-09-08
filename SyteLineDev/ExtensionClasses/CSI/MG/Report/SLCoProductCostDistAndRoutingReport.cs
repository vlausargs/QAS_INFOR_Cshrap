//PROJECT NAME: ReportExt
//CLASS NAME: SLCoProductCostDistAndRoutingReport.cs

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
	[IDOExtensionClass("SLCoProductCostDistAndRoutingReport")]
	public class SLCoProductCostDistAndRoutingReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_JobGenMixSp(string PJob,
		int? PSuffix,
		Guid? SessionID,
		ref string Infobar,
		[Optional] string BGSessionId,
		[Optional] int? TaskId,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_JobGenMixExt = new Rpt_JobGenMixFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_JobGenMixExt.Rpt_JobGenMixSp(PJob,
				PSuffix,
				SessionID,
				Infobar,
				BGSessionId,
				TaskId,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
	}
}
