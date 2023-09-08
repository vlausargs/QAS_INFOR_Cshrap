//PROJECT NAME: ReportExt
//CLASS NAME: SLMultiFSBJournalTransactionReport.cs

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
    [IDOExtensionClass("SLMultiFSBJournalTransactionReport")]
    public class SLMultiFSBJournalTransactionReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_MultiFSBJournalTransactionSp([Optional] string CurId,
		[Optional] string FSBName,
		[Optional] int? StartingSeq,
		[Optional] int? EndingSeq,
		[Optional] DateTime? StartingTransDate,
		[Optional] DateTime? EndingTransDate,
		[Optional] int? StartingTransDateOffset,
		[Optional] int? EndingTransDateOffset,
		[Optional] DateTime? StartingPeriod,
		[Optional] DateTime? EndingPeriod,
		[Optional] int? StartingPeriodOffset,
		[Optional] int? EndingPeriodOffset,
		[Optional] string StartingAcct,
		[Optional] string EndingAcct,
		[Optional] string StartingAcctUnit1,
		[Optional] string EndingAcctUnit1,
		[Optional] string StartingAcctUnit2,
		[Optional] string EndingAcctUnit2,
		[Optional] string StartingAcctUnit3,
		[Optional] string EndingAcctUnit3,
		[Optional] string StartingAcctUnit4,
		[Optional] string EndingAcctUnit4,
		[Optional] string StartingRef,
		[Optional] string EndingRef,
		[Optional] string SortBy,
		[Optional, DefaultParameterValue(1)] int? ShowInternal,
		[Optional, DefaultParameterValue(1)] int? ShowExternal,
		[Optional] int? ShowDetail,
		[Optional, DefaultParameterValue(0)] int? GroupBy,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_MultiFSBJournalTransactionExt = new Rpt_MultiFSBJournalTransactionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_MultiFSBJournalTransactionExt.Rpt_MultiFSBJournalTransactionSp(CurId,
				FSBName,
				StartingSeq,
				EndingSeq,
				StartingTransDate,
				EndingTransDate,
				StartingTransDateOffset,
				EndingTransDateOffset,
				StartingPeriod,
				EndingPeriod,
				StartingPeriodOffset,
				EndingPeriodOffset,
				StartingAcct,
				EndingAcct,
				StartingAcctUnit1,
				EndingAcctUnit1,
				StartingAcctUnit2,
				EndingAcctUnit2,
				StartingAcctUnit3,
				EndingAcctUnit3,
				StartingAcctUnit4,
				EndingAcctUnit4,
				StartingRef,
				EndingRef,
				SortBy,
				ShowInternal,
				ShowExternal,
				ShowDetail,
				GroupBy,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
