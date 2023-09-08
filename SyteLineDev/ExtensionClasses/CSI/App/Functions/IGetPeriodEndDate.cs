//PROJECT NAME: Data
//CLASS NAME: IGetPeriodEndDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetPeriodEndDate
	{
		DateTime? GetPeriodEndDateFn(
			int? PPeriod);
	}
}

