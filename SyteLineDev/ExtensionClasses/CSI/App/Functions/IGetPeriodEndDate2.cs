//PROJECT NAME: Data
//CLASS NAME: IGetPeriodEndDate2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetPeriodEndDate2
	{
		DateTime? GetPeriodEndDate2Fn(
			int? PPeriod,
			int? FiscalYear);
	}
}

