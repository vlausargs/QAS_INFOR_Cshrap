//PROJECT NAME: Data
//CLASS NAME: IEndOfMonth.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEndOfMonth
	{
		DateTime? EndOfMonthFn(
			DateTime? Date);
	}
}

