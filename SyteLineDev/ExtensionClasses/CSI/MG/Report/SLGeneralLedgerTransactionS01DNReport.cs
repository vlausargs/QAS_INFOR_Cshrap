//PROJECT NAME: MG
//CLASS NAME: SLGeneralLedgerTransactionS01DNReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
	[IDOExtensionClass("SLGeneralLedgerTransactionS01DNReport")]
	public class SLGeneralLedgerTransactionS01DNReport : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_GeneralLedgerTransactionS01DNReportSp([Optional] decimal? ExOptStartingTrans,
		[Optional] decimal? ExOptEndingTrans,
		[Optional] string ExOptStartingRef,
		[Optional] string ExOptEndingRef,
		[Optional] int? TAnalyticalLedger,
		[Optional] DateTime? ExOptStartingTransDate,
		[Optional] DateTime? ExOptEndingTransDate,
		[Optional] string ExOptStartingAcc,
		[Optional] string ExOptEndingAcc,
		[Optional] string ExOptacChartType,
		[Optional] string ExOptBegAcctUnit1,
		[Optional] string ExOptEndAcctUnit1,
		[Optional] string ExOptBegAcctUnit2,
		[Optional] string ExOptEndAcctUnit2,
		[Optional] string ExOptBegAcctUnit3,
		[Optional] string ExOptEndAcctUnit3,
		[Optional] string ExOptBegAcctUnit4,
		[Optional] string ExOptEndAcctUnit4,
		[Optional] string ExOptSortBy,
		[Optional] int? StartingTransDateOffset,
		[Optional] int? EndingTransDateOffset,
		[Optional] int? DisplayHeader,
		[Optional] int? ShowInternal,
		[Optional] int? ShowExternal,
		[Optional] string pSite)
		{
			var iRpt_GeneralLedgerTransactionS01DNReportExt = new Rpt_GeneralLedgerTransactionS01DNReportFactory().Create(this, true);
			
			var result = iRpt_GeneralLedgerTransactionS01DNReportExt.Rpt_GeneralLedgerTransactionS01DNReportSp(ExOptStartingTrans,
			ExOptEndingTrans,
			ExOptStartingRef,
			ExOptEndingRef,
			TAnalyticalLedger,
			ExOptStartingTransDate,
			ExOptEndingTransDate,
			ExOptStartingAcc,
			ExOptEndingAcc,
			ExOptacChartType,
			ExOptBegAcctUnit1,
			ExOptEndAcctUnit1,
			ExOptBegAcctUnit2,
			ExOptEndAcctUnit2,
			ExOptBegAcctUnit3,
			ExOptEndAcctUnit3,
			ExOptBegAcctUnit4,
			ExOptEndAcctUnit4,
			ExOptSortBy,
			StartingTransDateOffset,
			EndingTransDateOffset,
			DisplayHeader,
			ShowInternal,
			ShowExternal,
			pSite);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}
	}
}
