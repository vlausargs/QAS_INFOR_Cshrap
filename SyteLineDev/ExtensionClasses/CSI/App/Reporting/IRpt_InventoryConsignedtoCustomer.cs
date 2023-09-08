//PROJECT NAME: Reporting
//CLASS NAME: IRpt_InventoryConsignedtoCustomer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_InventoryConsignedtoCustomer
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InventoryConsignedtoCustomerSp(string WhseStaring = null,
		string WhseEnding = null,
		string CustStarting = null,
		string CustEnding = null,
		int? CustSeqStarting = null,
		int? CustSeqEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string SortBy = "C",
		int? DisplayHeader = 0,
		string pSite = null);
	}
}

