//PROJECT NAME: Reporting
//CLASS NAME: IRpt_OrderBookingsSub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_OrderBookingsSub
	{
		(ICollectionLoadResponse Data, int? ReturnCode,
			string Infobar) Rpt_OrderBookingsSubSp(
			string Sortby,
			DateTime? ActivityDateStarting,
			DateTime? ActivityDateEnding,
			string ProductCodeStarting,
			string ProductCodeEnding,
			string SlsmanStarting,
			string SlsmanEnding,
			string ItemStarting,
			string ItemEnding,
			string OrdernumStarting,
			string OrdernumEnding,
			string RmaNumStarting,
			string RmaNumEnding,
			int? IncludeRma,
			int? SummaryorDetail,
			int? CheckCoForRMA = null,
			string Site = null,
			string Infobar = null);
	}
}

