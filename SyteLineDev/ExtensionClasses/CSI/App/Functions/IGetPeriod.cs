//PROJECT NAME: Data
//CLASS NAME: IGetPeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetPeriod
	{
		int? GetPeriodFn(
			DateTime? TransDate);
	}
}

