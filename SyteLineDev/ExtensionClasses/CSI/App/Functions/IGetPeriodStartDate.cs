//PROJECT NAME: Data
//CLASS NAME: IGetPeriodStartDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetPeriodStartDate
	{
		DateTime? GetPeriodStartDateFn(
			int? PPeriod);
	}
}

