//PROJECT NAME: Reporting
//CLASS NAME: IRpt_FinancialStatementOutput.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_FinancialStatementOutput
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_FinancialStatementOutputSp(
			string ReportID = null,
			int? AcctDetail = null,
			int? Unit1Detail = null,
			int? Unit2Detail = null,
			int? Unit3Detail = null,
			int? Unit4Detail = null,
			string ReportType = null,
			string CurrCode = null,
			DateTime? CurrTransDate = null,
			int? CurrTransDateOffset = null,
			string SiteGroup = null,
			string LineSummaryLevel = null,
			DateTime? YrStart = null,
			int? YrStartOffset = null,
			int? Period = null,
			DateTime? PerStart = null,
			int? PerStartOffset = null,
			DateTime? PerEnd = null,
			int? PerEndOffset = null,
			string SAcctUnit1 = null,
			string SAcctUnit2 = null,
			string SAcctUnit3 = null,
			string SAcctUnit4 = null,
			string EAcctUnit1 = null,
			string EAcctUnit2 = null,
			string EAcctUnit3 = null,
			string EAcctUnit4 = null,
			string AcctSortRaw = null,
			string BGSessionId = null,
			int? TaskId = null,
			string pSite = null);
	}
}

