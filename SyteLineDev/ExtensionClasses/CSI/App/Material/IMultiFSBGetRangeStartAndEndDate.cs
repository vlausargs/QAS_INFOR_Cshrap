//PROJECT NAME: Finance
//CLASS NAME: IMultiFSBGetRangeStartAndEndDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiFSBGetRangeStartAndEndDate
	{
		(int? ReturnCode,
			string FSBName,
			int? StartingFiscalYear,
			int? EndingFiscalYear,
			DateTime? FiscalYearStartDate,
			DateTime? FiscalYearEndDate,
			string Infobar) MultiFSBGetRangeStartAndEndDateSp(
			string FSBName,
			int? StartingFiscalYear,
			int? EndingFiscalYear,
			DateTime? FiscalYearStartDate,
			DateTime? FiscalYearEndDate,
			string Infobar);
	}
}

