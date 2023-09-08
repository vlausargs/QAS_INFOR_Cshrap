//PROJECT NAME: Data
//CLASS NAME: IGetPeriodStartAndEndDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetPeriodStartAndEndDate
	{
		(int? ReturnCode,
			DateTime? PeriodStartDate,
			DateTime? PeriodEndDate) GetPeriodStartAndEndDateSp(
			DateTime? TransactionDate,
			DateTime? PeriodStartDate,
			DateTime? PeriodEndDate);
	}
}

