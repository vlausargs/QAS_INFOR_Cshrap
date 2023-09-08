//PROJECT NAME: Logistics
//CLASS NAME: IGetOrderInfoOrderDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetOrderInfoOrderDate
	{
		DateTime? GetOrderInfoOrderDateFn(
			string OrdType,
			string OrdNum,
			int? OrdLine);
	}
}

