//PROJECT NAME: Finance
//CLASS NAME: ICHSGetPeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSGetPeriod
	{
		(int? ReturnCode,
			int? FiscalYear,
			int? Period,
			DateTime? FiscalYearStartDate,
			DateTime? FiscalYearEndDate,
			int? CurPer,
			int? Closed,
			string Infobar) CHSGetPeriodSp(
			DateTime? RefDate = null,
			int? FiscalYear = 0,
			int? Period = 0,
			DateTime? FiscalYearStartDate = null,
			DateTime? FiscalYearEndDate = null,
			int? CurPer = 0,
			int? Closed = 0,
			string Infobar = "");
	}
}

