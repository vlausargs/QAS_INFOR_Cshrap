//PROJECT NAME: Data
//CLASS NAME: IGetFSBPeriodEndDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetFSBPeriodEndDate
	{
		DateTime? GetFSBPeriodEndDateFn(
			string PeriodName,
			int? PPeriod);
	}
}

