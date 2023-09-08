//PROJECT NAME: Finance
//CLASS NAME: IGetFiscalYearStartAndEndDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGetFiscalYearStartAndEndDate
	{
		(int? ReturnCode, DateTime? FiscalYearStartDate,
		DateTime? FiscalYearEndDate,
		int? FiscalYear,
		string Infobar) GetFiscalYearStartAndEndDateSp(DateTime? FiscalYearStartDate,
		DateTime? FiscalYearEndDate,
		int? FiscalYear,
		string Infobar);
	}
}

