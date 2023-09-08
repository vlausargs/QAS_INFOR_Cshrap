//PROJECT NAME: Finance
//CLASS NAME: IPeriodsYTD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IPeriodsYTD
	{
		(int? ReturnCode, DateTime? YearStart,
		DateTime? YearEnd,
		DateTime? PeriodStart,
		DateTime? PeriodEnd,
		DateTime? LastYearStart,
		DateTime? LastYearEnd,
		DateTime? FiscalYearStart,
		DateTime? FiscalYearEnd,
		DateTime? FiscalPeriodStart,
		DateTime? FiscalPeriodEnd,
		DateTime? FiscalLastYearStart,
		DateTime? FiscalLastYearEnd) PeriodsYTDSp(DateTime? YearStart,
		DateTime? YearEnd,
		DateTime? PeriodStart,
		DateTime? PeriodEnd,
		DateTime? LastYearStart,
		DateTime? LastYearEnd,
		DateTime? FiscalYearStart,
		DateTime? FiscalYearEnd,
		DateTime? FiscalPeriodStart,
		DateTime? FiscalPeriodEnd,
		DateTime? FiscalLastYearStart,
		DateTime? FiscalLastYearEnd);
	}
}

