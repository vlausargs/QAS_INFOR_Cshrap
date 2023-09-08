//PROJECT NAME: Reporting
//CLASS NAME: IRpt_OrderInvoicingCreditMemoToBePrinted.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_OrderInvoicingCreditMemoToBePrinted
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_OrderInvoicingCreditMemoToBePrintedSp(string CustomerStarting,
		string CustomerEnding,
		string OrderStarting,
		string OrderEnding,
		int? OrderLineStarting,
		int? OrderLineEnding,
		int? OrderReleaseStarting,
		int? OrderReleaseEnding,
		DateTime? ShipDateStarting,
		DateTime? ShipDateEnding,
		int? CreateFromPackSlip,
		int? PackNumStarting,
		int? PackNumEnding,
		int? CreateFromShipment,
		decimal? ShipmentIdStarting,
		decimal? ShipmentIdEnding,
		DateTime? InvDate,
		string InvoiceType,
		string PrintCustomerItemItem,
		string InvoiceOrCreditMemo,
		int? PrintStandardOrderText,
		string pSite = null);
	}
}

