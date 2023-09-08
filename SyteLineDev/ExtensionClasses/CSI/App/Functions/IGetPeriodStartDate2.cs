//PROJECT NAME: Data
//CLASS NAME: IGetPeriodStartDate2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetPeriodStartDate2
	{
		DateTime? GetPeriodStartDate2Fn(
			int? PPeriod,
			int? FiscalYear);
	}
}

