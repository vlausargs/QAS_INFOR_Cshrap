//PROJECT NAME: Logistics
//CLASS NAME: IRMALineItemsOrders.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRMALineItemsOrders
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RMALineItemsOrdersSp(string CoNumFilter = null,
		string CurrCode = null);
	}
}

