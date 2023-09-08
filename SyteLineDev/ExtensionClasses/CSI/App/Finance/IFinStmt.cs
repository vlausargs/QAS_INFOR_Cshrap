//PROJECT NAME: Finance
//CLASS NAME: IFinStmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinStmt
	{
		(int? ReturnCode,
			string Infobar,
			string InfobarAcct) FinStmtSp(
			string FinStmtRptId = null,
			int? FinStmtAcctDetail = null,
			int? FinStmtUnit1Detail = null,
			int? FinStmtUnit2Detail = null,
			int? FinStmtUnit3Detail = null,
			int? FinStmtUnit4Detail = null,
			string FinStmtReportType = null,
			string FinStmtCurrCode = null,
			DateTime? FinStmtCurrTransDate = null,
			int? CurrTransDateOffset = null,
			string FinStmtSiteGroup = null,
			string FinStmtLineSummaryLevel = null,
			DateTime? FinStmtYrStart = null,
			int? YrStartOffset = null,
			int? FinStmtPeriod = null,
			DateTime? FinStmtPerStart = null,
			int? PerStartOffset = null,
			DateTime? FinStmtPerEnd = null,
			int? PerEndOffset = null,
			string FinStmtSAcctUnit1 = null,
			string FinStmtSAcctUnit2 = null,
			string FinStmtSAcctUnit3 = null,
			string FinStmtSAcctUnit4 = null,
			string FinStmtEAcctUnit1 = null,
			string FinStmtEAcctUnit2 = null,
			string FinStmtEAcctUnit3 = null,
			string FinStmtEAcctUnit4 = null,
			string FinStmtAcctSort = null,
			string Infobar = null,
			string InfobarAcct = null,
			Guid? RptSessionId = null);
	}
}

