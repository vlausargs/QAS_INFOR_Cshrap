//PROJECT NAME: ReportExt
//CLASS NAME: SLPastDueJobOperationsReport.cs

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
    [IDOExtensionClass("SLPastDueJobOperationsReport")]
    public class SLPastDueJobOperationsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PastDueJobOperationsSp([Optional] string JobStarting,
		[Optional] string JobEnding,
		[Optional] int? JobSuffixStarting,
		[Optional] int? JobSuffixEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] string Ord_type,
		[Optional] string RefStarting,
		[Optional] string RefEnding,
		[Optional] DateTime? LastTrxDateStarting,
		[Optional] DateTime? LastTrxDateEnding,
		[Optional] int? LastTrxDateStartingOffset,
		[Optional] int? LastTrxDateEndingOffset,
		[Optional] DateTime? JobDateStarting,
		[Optional] DateTime? JobDateEnding,
		[Optional] int? JobDateStartingOffset,
		[Optional] int? JobDateEndingOffset,
		[Optional] DateTime? PastDueDate,
		[Optional] int? PastDueOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PastDueJobOperationsExt = new Rpt_PastDueJobOperationsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PastDueJobOperationsExt.Rpt_PastDueJobOperationsSp(JobStarting,
				JobEnding,
				JobSuffixStarting,
				JobSuffixEnding,
				ItemStarting,
				ItemEnding,
				CustomerStarting,
				CustomerEnding,
				Ord_type,
				RefStarting,
				RefEnding,
				LastTrxDateStarting,
				LastTrxDateEnding,
				LastTrxDateStartingOffset,
				LastTrxDateEndingOffset,
				JobDateStarting,
				JobDateEnding,
				JobDateStartingOffset,
				JobDateEndingOffset,
				PastDueDate,
				PastDueOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
