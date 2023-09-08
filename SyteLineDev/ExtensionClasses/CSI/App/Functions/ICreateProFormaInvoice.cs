//PROJECT NAME: Data
//CLASS NAME: ICreateProFormaInvoice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICreateProFormaInvoice
	{
		(int? ReturnCode,
			string Infobar) CreateProFormaInvoiceSp(
			string TransactionType,
			Guid? SessionID = null,
			string OrderNumber = null,
			DateTime? TransactionDate = null,
			string CustNum = null,
			string InvoiceNumber = null,
			decimal? ShipmentIdStarting = null,
			decimal? ShipmentIdEnding = null,
			string CustNumStarting = null,
			string CustNumEnding = null,
			int? ShipToStarting = null,
			int? ShipToEnding = null,
			DateTime? PickupDateStarting = null,
			DateTime? PickupDateEnding = null,
			string Infobar = null,
			string InvNumStarting = null,
			string InvNumEnding = null,
			string ApplyToInvoice = null);
	}
}

