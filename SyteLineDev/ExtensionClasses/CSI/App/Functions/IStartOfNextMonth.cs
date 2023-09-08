//PROJECT NAME: Data
//CLASS NAME: IStartOfNextMonth.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IStartOfNextMonth
	{
		DateTime? StartOfNextMonthFn(
			DateTime? Date);
	}
}

