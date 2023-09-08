//PROJECT NAME: Data
//CLASS NAME: IGetFSBPeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetFSBPeriod
	{
		int? GetFSBPeriodFn(
			DateTime? TransDate,
			string PeriodName);
	}
}

