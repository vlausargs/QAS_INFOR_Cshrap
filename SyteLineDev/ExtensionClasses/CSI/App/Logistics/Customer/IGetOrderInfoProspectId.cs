//PROJECT NAME: Logistics
//CLASS NAME: IGetOrderInfoProspectId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetOrderInfoProspectId
	{
		string GetOrderInfoProspectIdFn(
			string OrdType,
			string OrdNum,
			string Site = null);
	}
}

