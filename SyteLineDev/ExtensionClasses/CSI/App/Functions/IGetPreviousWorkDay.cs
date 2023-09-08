//PROJECT NAME: Data
//CLASS NAME: IGetPreviousWorkDay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetPreviousWorkDay
	{
		DateTime? GetPreviousWorkDayFn(
			DateTime? CalcDate);
	}
}

