//PROJECT NAME: Finance
//CLASS NAME: IFinRptOutputGetPeriod1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptOutputGetPeriod1
	{
		(int? ReturnCode, DateTime? YearStart,
		int? Period,
		DateTime? PeriodStart,
		DateTime? PeriodEnd,
		string Infobar) FinRptOutputGetPeriod1Sp(DateTime? YearStart,
		int? Period,
		DateTime? PeriodStart,
		DateTime? PeriodEnd,
		string Site = null,
		string Infobar = null);
	}
}

