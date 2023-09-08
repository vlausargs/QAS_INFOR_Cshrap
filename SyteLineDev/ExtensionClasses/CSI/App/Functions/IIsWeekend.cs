//PROJECT NAME: Data
//CLASS NAME: IIsWeekend.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsWeekend
	{
		int? IsWeekendFn(
			DateTime? Date);
	}
}

