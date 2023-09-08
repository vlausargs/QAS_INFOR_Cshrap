//PROJECT NAME: ReportExt
//CLASS NAME: SLJobOperationStatusReport.cs

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
    [IDOExtensionClass("SLJobOperationStatusReport")]
    public class SLJobOperationStatusReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_JobOperationStatusSp([Optional] string JobStarting,
		[Optional] string JobEnding,
		[Optional] int? SuffixStarting,
		[Optional] int? SuffixEnding,
		[Optional] string JobStatus,
		[Optional] string LbrMatlBoth,
		[Optional] string CustNum,
		[Optional] string CustPo,
		[Optional] string CustItem,
		[Optional] int? ControlPoint,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string OrdType,
		[Optional] string OrdNumStarting,
		[Optional] string OrdNumEnding,
		[Optional] DateTime? LastTrxDateStarting,
		[Optional] DateTime? LastTrxDateEnding,
		[Optional] int? LastTrxDateStartingOffset,
		[Optional] int? LastTrxDateEndingOffset,
		[Optional] DateTime? JobDateStarting,
		[Optional] DateTime? JobDateEnding,
		[Optional] int? JobDateStartingOffset,
		[Optional] int? JobDateEndingOffset,
		[Optional, DefaultParameterValue(1)] int? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_JobOperationStatusExt = new Rpt_JobOperationStatusFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_JobOperationStatusExt.Rpt_JobOperationStatusSp(JobStarting,
				JobEnding,
				SuffixStarting,
				SuffixEnding,
				JobStatus,
				LbrMatlBoth,
				CustNum,
				CustPo,
				CustItem,
				ControlPoint,
				ItemStarting,
				ItemEnding,
				OrdType,
				OrdNumStarting,
				OrdNumEnding,
				LastTrxDateStarting,
				LastTrxDateEnding,
				LastTrxDateStartingOffset,
				LastTrxDateEndingOffset,
				JobDateStarting,
				JobDateEnding,
				JobDateStartingOffset,
				JobDateEndingOffset,
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
