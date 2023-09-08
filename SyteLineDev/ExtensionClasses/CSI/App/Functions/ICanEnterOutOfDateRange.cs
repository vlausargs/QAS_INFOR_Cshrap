//PROJECT NAME: Data
//CLASS NAME: ICanEnterOutOfDateRange.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICanEnterOutOfDateRange
	{
		int? CanEnterOutOfDateRangeFn();
	}
}

