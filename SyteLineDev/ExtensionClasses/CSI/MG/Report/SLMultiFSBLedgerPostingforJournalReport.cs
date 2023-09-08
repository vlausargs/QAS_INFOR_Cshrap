//PROJECT NAME: ReportExt
//CLASS NAME: SLMultiFSBLedgerPostingforJournalReport.cs

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
    [IDOExtensionClass("SLMultiFSBLedgerPostingforJournalReport")]
    public class SLMultiFSBLedgerPostingforJournalReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_MultiFSBLedgerPostingforJournalSp([Optional] string pSessionIDChar,
		[Optional] string pCurId,
		[Optional] int? pSingleDate,
		[Optional] DateTime? pDateForTrans,
		[Optional] DateTime? pPostThroughDate,
		[Optional] string FSBName,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_MultiFSBLedgerPostingforJournalExt = new Rpt_MultiFSBLedgerPostingforJournalFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_MultiFSBLedgerPostingforJournalExt.Rpt_MultiFSBLedgerPostingforJournalSp(pSessionIDChar,
				pCurId,
				pSingleDate,
				pDateForTrans,
				pPostThroughDate,
				FSBName,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
