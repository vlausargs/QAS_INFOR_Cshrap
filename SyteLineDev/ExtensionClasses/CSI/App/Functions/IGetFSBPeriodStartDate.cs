//PROJECT NAME: Data
//CLASS NAME: IGetFSBPeriodStartDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetFSBPeriodStartDate
	{
		DateTime? GetFSBPeriodStartDateFn(
			string PeriodName,
			int? PPeriod);
	}
}

