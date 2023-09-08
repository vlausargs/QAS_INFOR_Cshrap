//PROJECT NAME: Logistics
//CLASS NAME: ISkipOrderLinesWithAvailableIs0.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISkipOrderLinesWithAvailableIs0
	{
		(int? ReturnCode, string Infobar) SkipOrderLinesWithAvailableIs0Sp(Guid? ProcessId,
		int? SkipOrderLineWhenQuantityAvailableIs0,
		int? IncludeZeroQuantityAvailableKitItems,
		string Infobar);
	}
}

