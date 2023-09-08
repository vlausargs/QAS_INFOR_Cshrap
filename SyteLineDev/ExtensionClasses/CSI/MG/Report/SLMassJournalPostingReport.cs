//PROJECT NAME: ReportExt
//CLASS NAME: SLMassJournalPostingReport.cs

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
    [IDOExtensionClass("SLMassJournalPostingReport")]
    public class SLMassJournalPostingReport : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_MassJournalPostingsp([Optional] string pSessionIDChar,
			[Optional] int? pSingleDate,
			[Optional] DateTime? pDateForTrans,
			[Optional] DateTime? pTransDateStart,
			[Optional] DateTime? pTransDateEnd,
			[Optional] int? pPostInBackgroundQueue,
			[Optional] int? pCompJour,
			[Optional] string pCompressionLevel,
			[Optional] int? pDeleteTransactionsAfterPost,
			[Optional] DateTime? pReversingTransactionDate,
			[Optional] string pSite)
		{
			var iRpt_MassJournalPostingExt = new Rpt_MassJournalPostingFactory().Create(this, true);
			
			var result = iRpt_MassJournalPostingExt.Rpt_MassJournalPostingSp(pSessionIDChar,
				pSingleDate,
				pDateForTrans,
				pTransDateStart,
				pTransDateEnd,
				pPostInBackgroundQueue,
				pCompJour,
				pCompressionLevel,
				pDeleteTransactionsAfterPost,
				pReversingTransactionDate,
				pSite);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}
    }
}
