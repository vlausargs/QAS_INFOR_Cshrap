//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MXShipmentProFormaInvoice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MXShipmentProFormaInvoice
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MXShipmentProFormaInvoiceSp(
			int? PrintBlankPickupDate = null,
			int? PrintShipmentSequenceText = null,
			int? IncludeSerialNumbers = null,
			decimal? ShipmentStarting = null,
			decimal? ShipmentEnding = null,
			string CustomerStarting = null,
			string CustomerEnding = null,
			int? ShipToStarting = null,
			int? ShipToEnding = null,
			DateTime? PickupDateStarting = null,
			DateTime? PickupDateEnding = null,
			int? DateStartingOffset = null,
			int? DateENDingOffset = null,
			int? ShowInternal = null,
			int? ShowExternal = null,
			int? DisplayHeader = null,
			string pSite = null,
			int? Print = null);
	}
}

