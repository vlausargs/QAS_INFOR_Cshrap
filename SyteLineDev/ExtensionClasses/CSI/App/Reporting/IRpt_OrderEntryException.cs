//PROJECT NAME: Reporting
//CLASS NAME: IRpt_OrderEntryException.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_OrderEntryException
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_OrderEntryExceptionSp(string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? OrderDateStarting = null,
		DateTime? OrderDateEnding = null,
		string OrderStarting = null,
		string OrderEnding = null,
		int? OrderLineStarting = null,
		int? OrderLineEnding = null,
		int? OrderReleaseStarting = null,
		int? OrderReleaseEnding = null,
		DateTime? ShipDateStarting = null,
		DateTime? ShipDateEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		string OrderType = null,
		string COStatus = null,
		string COItemStatus = null,
		string ExceptionType = null,
		int? OrderDateStartingOffset = null,
		int? OrderDateEndingOffset = null,
		int? ShipDateStartingOffset = null,
		int? ShipDateEndingOffset = null,
		int? DueDateStartingOffset = null,
		int? DueDateEndingOffset = null,
		int? ShowPrice = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null);
	}
}

