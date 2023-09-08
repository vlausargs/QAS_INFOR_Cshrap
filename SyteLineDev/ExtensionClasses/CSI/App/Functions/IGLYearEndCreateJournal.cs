//PROJECT NAME: Data
//CLASS NAME: IGLYearEndCreateJournal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGLYearEndCreateJournal
	{
		(int? ReturnCode,
			decimal? Summary,
			decimal? JournalDomAmount,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string Infobar) GLYearEndCreateJournalSp(
			string CurId,
			DateTime? FiscalYearBegDate,
			DateTime? FiscalYearEndDate,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PSortFields,
			int? PSortMethod,
			string ChartAcct,
			string ChartType,
			string CurrCode,
			string Site,
			decimal? Summary,
			decimal? JournalDomAmount,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string Infobar);
	}
}

