//PROJECT NAME: Finance
//CLASS NAME: IPerGet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IPerGet
	{
		(int? ReturnCode, int? CurrentPeriod,
		Guid? PeriodsRowPointer,
		string Infobar,
		int? PeriodsFiscalYear,
		string CurPeriodStatus) PerGetSp(DateTime? Date,
		int? CurrentPeriod = null,
		Guid? PeriodsRowPointer = null,
		string Infobar = null,
		string Site = null,
		int? PeriodsFiscalYear = null,
		string CurPeriodStatus = null);
	}
}

