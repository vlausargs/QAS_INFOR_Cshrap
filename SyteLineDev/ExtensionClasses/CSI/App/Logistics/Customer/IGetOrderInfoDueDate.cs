//PROJECT NAME: Logistics
//CLASS NAME: IGetOrderInfoDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetOrderInfoDueDate
	{
		DateTime? GetOrderInfoDueDateFn(
			string OrdType,
			string OrdNum,
			int? OrdLine,
			int? OrdRelease,
			string Site = null);
	}
}

