//PROJECT NAME: Logistics
//CLASS NAME: IGetOrderItemCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetOrderItemCount
	{
		int? GetOrderItemCountFn(
			string CoNum);
	}
}

