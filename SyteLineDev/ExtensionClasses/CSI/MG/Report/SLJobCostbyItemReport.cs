//PROJECT NAME: ReportExt
//CLASS NAME: SLJobCostbyItemReport.cs

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
    [IDOExtensionClass("SLJobCostbyItemReport")]
    public class SLJobCostbyItemReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_JobCostbyItemSp([Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string JobStatus,
		[Optional] int? SubTotal,
		[Optional] string JobStarting,
		[Optional] string JobEnding,
		[Optional] int? SuffixStarting,
		[Optional] int? SuffixEnding,
		[Optional] string CustNumStarting,
		[Optional] string CustNumEnding,
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
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_JobCostbyItemExt = new Rpt_JobCostbyItemFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_JobCostbyItemExt.Rpt_JobCostbyItemSp(ItemStarting,
				ItemEnding,
				JobStatus,
				SubTotal,
				JobStarting,
				JobEnding,
				SuffixStarting,
				SuffixEnding,
				CustNumStarting,
				CustNumEnding,
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
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
