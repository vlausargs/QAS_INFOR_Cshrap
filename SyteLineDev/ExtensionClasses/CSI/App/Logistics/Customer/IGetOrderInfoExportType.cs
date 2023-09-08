//PROJECT NAME: Logistics
//CLASS NAME: IGetOrderInfoExportType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetOrderInfoExportType
	{
		string GetOrderInfoExportTypeFn(
			string OrdType,
			string OrdNum);
	}
}

