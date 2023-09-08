//PROJECT NAME: Finance
//CLASS NAME: IFSBGetNextFiscalYearStartDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFSBGetNextFiscalYearStartDate
	{
		(int? ReturnCode, int? NextFiscalYear,
		DateTime? NextStartDate) FSBGetNextFiscalYearStartDateSp(string PeriodName,
		int? NextFiscalYear,
		DateTime? NextStartDate);
	}
}

