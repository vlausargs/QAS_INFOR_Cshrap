//PROJECT NAME: Reporting
//CLASS NAME: IGLBudgetConsbpDoPersMatch.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IGLBudgetConsbpDoPersMatch
	{
		(int? ReturnCode,
			string Infobar) GLBudgetConsbpDoPersMatchSp(
			string ReportsToSite,
			string pTgHierarchy,
			int? StartFiscalYear,
			DateTime? StartPeriodsPerStartDate,
			string Infobar);
	}
}

