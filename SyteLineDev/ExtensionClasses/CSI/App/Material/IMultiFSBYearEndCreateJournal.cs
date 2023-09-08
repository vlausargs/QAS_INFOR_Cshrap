//PROJECT NAME: Finance
//CLASS NAME: IMultiFSBYearEndCreateJournal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiFSBYearEndCreateJournal
	{
		(int? ReturnCode,
			decimal? Summary,
			decimal? JournalDomAmount,
			string Infobar) MultiFSBYearEndCreateJournalSp(
			string FSBName,
			string PeriodName = null,
			string CurId = "General",
			DateTime? FiscalYearBegDate = null,
			DateTime? FiscalYearEndDate = null,
			string PAcctUnit1 = null,
			string PAcctUnit2 = null,
			string PAcctUnit3 = null,
			string PAcctUnit4 = null,
			string PSortFields = null,
			int? PSortMethod = null,
			string ChartAcct = null,
			string ChartType = null,
			string CurrCode = null,
			string Site = null,
			decimal? Summary = null,
			decimal? JournalDomAmount = null,
			string Infobar = null);
	}
}

