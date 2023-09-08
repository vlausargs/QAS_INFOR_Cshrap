//PROJECT NAME: Data
//CLASS NAME: IJP_LastDayOfMonth.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJP_LastDayOfMonth
	{
		int? JP_LastDayOfMonthFn(
			int? Year,
			int? Month);
	}
}

