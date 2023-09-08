//PROJECT NAME: Data
//CLASS NAME: IMaxMultipleDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMaxMultipleDate
	{
		DateTime? MaxMultipleDateFn(
			DateTime? Date1,
			DateTime? Date2,
			DateTime? Date3,
			DateTime? Date4,
			DateTime? Date5,
			DateTime? Date6);
	}
}

