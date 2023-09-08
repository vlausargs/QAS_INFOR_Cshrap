//PROJECT NAME: Logistics
//CLASS NAME: IGetOrderInfoOrderQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetOrderInfoOrderQty
	{
		decimal? GetOrderInfoOrderQtyFn(
			string OrderType,
			string OrderNum,
			int? OrderLine,
			int? OrderRelease);
	}
}

