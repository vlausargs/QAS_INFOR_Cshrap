//PROJECT NAME: Finance
//CLASS NAME: ICHSGetPeriodStartAndEndDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSGetPeriodStartAndEndDate
	{
		(int? ReturnCode, DateTime? FiscalYearStartDate,
		DateTime? FiscalYearEndDate,
		string Infobar) CHSGetPeriodStartAndEndDateSp(int? FiscalYear,
		int? FiscalPeriod,
		DateTime? FiscalYearStartDate = null,
		DateTime? FiscalYearEndDate = null,
		string Infobar = null);
	}
}

