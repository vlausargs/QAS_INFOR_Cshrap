//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_OrdersShippedAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_OrdersShippedAmount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_OrdersShippedAmountSp(string Range = "T");
	}
}

