//PROJECT NAME: ReportExt
//CLASS NAME: SLRequisitionPOComparisonReport.cs

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
    [IDOExtensionClass("SLRequisitionPOComparisonReport")]
    public class SLRequisitionPOComparisonReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RequisitionPOComparisonSP(string ReqNumStarting,
		string ReqNumEnding,
		int? ReqLineStarting,
		int? ReqLineEnding,
		int? ShowCost,
		int? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RequisitionPOComparisonExt = new Rpt_RequisitionPOComparisonFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RequisitionPOComparisonExt.Rpt_RequisitionPOComparisonSP(ReqNumStarting,
				ReqNumEnding,
				ReqLineStarting,
				ReqLineEnding,
				ShowCost,
				DisplayHeader,
				BGSessionId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
