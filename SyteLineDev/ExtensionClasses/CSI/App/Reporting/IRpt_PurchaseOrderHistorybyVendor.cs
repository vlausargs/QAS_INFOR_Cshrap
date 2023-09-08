//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PurchaseOrderHistorybyVendor.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PurchaseOrderHistorybyVendor
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PurchaseOrderHistorybyVendorSp(string OrderStarting = null,
		string OrderEnding = null,
		DateTime? OrderDateStarting = null,
		DateTime? OrderDateEnding = null,
		string VendorStarting = null,
		string VendorEnding = null,
		string VendOrderStarting = null,
		string VendOrderEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string VendItemStarting = null,
		string VendItemEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		DateTime? LastRcvdDateStarting = null,
		DateTime? LastRcvdDateEnding = null,
		string WhseStarting = null,
		string WhseEnding = null,
		string POType = null,
		int? IncludeGRN = null,
		int? TranslateToDomesticCurrency = null,
		int? OrderDateStartingOffset = null,
		int? OrderDateEndingOffset = null,
		int? LastRcvdDateStartingOffset = null,
		int? LastRcvdDateEndingOffset = null,
		int? DueDateStartingOffset = null,
		int? DueDateEndingOffset = null,
		int? ShowCost = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null);
	}
}

