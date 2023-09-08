//PROJECT NAME: ReportExt
//CLASS NAME: SLTransactionSummaryReport.cs

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
	[IDOExtensionClass("SLTransactionSummaryReport")]
	public class SLTransactionSummaryReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_TransactionSummarySp([Optional] string TransactionCodeStarting,
		[Optional] string TransactionCodeEnding,
		[Optional] DateTime? DateStarting,
		[Optional] DateTime? DateEnding,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] int? DateStartingOffset,
		[Optional] int? DateEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_TransactionSummaryExt = new Rpt_TransactionSummaryFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_TransactionSummaryExt.Rpt_TransactionSummarySp(TransactionCodeStarting,
				TransactionCodeEnding,
				DateStarting,
				DateEnding,
				CustomerStarting,
				CustomerEnding,
				DateStartingOffset,
				DateEndingOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
