//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PrintDeliveryOrderProFormaInvoice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PrintDeliveryOrderProFormaInvoice
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PrintDeliveryOrderProFormaInvoiceSp(string DOStarting = null,
		string DOEnding = null,
		int? PrintBlankPickupDate = null,
		int? PrintDOSeqText = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		int? CustSeqStarting = null,
		int? CustSeqEnding = null,
		DateTime? PickupDateStarting = null,
		DateTime? PickupDateEnding = null,
		int? PickupDateStartingOffset = null,
		int? PickupDateEndingOffset = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? PrintItemOverview = null,
		int? DisplayHeader = null,
		string pSite = null,
		string BGUser = null);
	}
}

