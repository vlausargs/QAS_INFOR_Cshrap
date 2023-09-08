//PROJECT NAME: Data
//CLASS NAME: IShiftInterval.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IShiftInterval
	{
		int? ShiftIntervalFn(
			int? SDay,
			string STime,
			int? EDay,
			string ETime);
	}
}

