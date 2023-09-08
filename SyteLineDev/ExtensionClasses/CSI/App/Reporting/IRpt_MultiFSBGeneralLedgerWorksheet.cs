//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MultiFSBGeneralLedgerWorksheet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MultiFSBGeneralLedgerWorksheet
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MultiFSBGeneralLedgerWorksheetSp(DateTime? ExOptacAsOfDate = null,
		string ExStartingAccount = null,
		string ExEndingAccount = null,
		string ExOptacChartType = null,
		int? TAnalyticalLedger = null,
		int? DateOffset = null,
		int? DisplayHeader = null,
		string FSBName = null,
		string pSite = null);
	}
}

