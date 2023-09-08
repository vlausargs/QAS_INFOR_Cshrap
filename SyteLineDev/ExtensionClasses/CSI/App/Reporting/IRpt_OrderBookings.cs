//PROJECT NAME: Reporting
//CLASS NAME: IRpt_OrderBookings.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_OrderBookings
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_OrderBookingsSp(string Sortby = null,
		DateTime? ActivityDateStarting = null,
		DateTime? ActivityDateEnding = null,
		string ProductCodeStarting = null,
		string ProductCodeEnding = null,
		string SlsmanStarting = null,
		string SlsmanEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string OrdernumStarting = null,
		string OrdernumEnding = null,
		string RmaNumStarting = null,
		string RmaNumEnding = null,
		int? IncludeRma = null,
		int? SummaryorDetail = null,
		int? ActivityDateStartingOffset = null,
		int? ActivityDateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

