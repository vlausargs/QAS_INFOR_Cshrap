//PROJECT NAME: Finance
//CLASS NAME: IFinRptOutputGetPeriod2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptOutputGetPeriod2
	{
		(int? ReturnCode, DateTime? PeriodStart,
		DateTime? PeriodEnd,
		string Infobar) FinRptOutputGetPeriod2Sp(DateTime? YearStart,
		int? Period,
		DateTime? PeriodStart,
		DateTime? PeriodEnd,
		string Site = null,
		string Infobar = null);
	}
}

