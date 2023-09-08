//PROJECT NAME: ReportExt
//CLASS NAME: SLPastDueJobsReport.cs

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
    [IDOExtensionClass("SLPastDueJobsReport")]
    public class SLPastDueJobsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PastDueJobsSp([Optional] DateTime? ExOptprPastDueDate,
		[Optional] string JobStarting,
		[Optional] int? JobStartSuffix,
		[Optional] string JobEnding,
		[Optional] int? JobEndSuffix,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string CustStarting,
		[Optional] string CustEnding,
		[Optional] string ExOptgoOrdType,
		[Optional] string OrdNumStarting,
		[Optional] string OrdNumEnding,
		[Optional] DateTime? LstTrxDateStarting,
		[Optional] DateTime? LstTrxDateEnding,
		[Optional] DateTime? JobDateStarting,
		[Optional] DateTime? JobDateEnding,
		[Optional] int? LstTrxDateStartingOffset,
		[Optional] int? LstTrxDateEndingOffset,
		[Optional] int? JobDateStartingOffset,
		[Optional] int? JobDateEndingOffset,
		[Optional] int? ExOptprPastDueDateOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PastDueJobsExt = new Rpt_PastDueJobsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PastDueJobsExt.Rpt_PastDueJobsSp(ExOptprPastDueDate,
				JobStarting,
				JobStartSuffix,
				JobEnding,
				JobEndSuffix,
				ItemStarting,
				ItemEnding,
				CustStarting,
				CustEnding,
				ExOptgoOrdType,
				OrdNumStarting,
				OrdNumEnding,
				LstTrxDateStarting,
				LstTrxDateEnding,
				JobDateStarting,
				JobDateEnding,
				LstTrxDateStartingOffset,
				LstTrxDateEndingOffset,
				JobDateStartingOffset,
				JobDateEndingOffset,
				ExOptprPastDueDateOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
