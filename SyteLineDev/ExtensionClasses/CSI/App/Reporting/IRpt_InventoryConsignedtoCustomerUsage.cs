//PROJECT NAME: Reporting
//CLASS NAME: IRpt_InventoryConsignedtoCustomerUsage.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_InventoryConsignedtoCustomerUsage
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InventoryConsignedtoCustomerUsageSp(string WhseStaring = null,
		string WhseEnding = null,
		string CustStarting = null,
		string CustEnding = null,
		int? CustSeqStarting = null,
		int? CustSeqEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		int? DisplayHeader = 0,
		string pSite = null);
	}
}

