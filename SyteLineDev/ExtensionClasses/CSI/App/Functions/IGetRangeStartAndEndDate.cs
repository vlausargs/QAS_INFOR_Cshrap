//PROJECT NAME: Data
//CLASS NAME: IGetRangeStartAndEndDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetRangeStartAndEndDate
	{
		(int? ReturnCode,
			int? StartingFiscalYear,
			int? EndingFiscalYear,
			DateTime? FiscalYearStartDate,
			DateTime? FiscalYearEndDate,
			string Infobar) GetRangeStartAndEndDateSp(
			int? StartingFiscalYear,
			int? EndingFiscalYear,
			DateTime? FiscalYearStartDate,
			DateTime? FiscalYearEndDate,
			string Infobar);
	}
}

