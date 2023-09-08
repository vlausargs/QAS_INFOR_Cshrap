//PROJECT NAME: App.Logistics.Customer
//CLASS NAME: IGetOrderInfoCustNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetOrderInfoCustNum
	{
		string GetOrderInfoCustNumFn(string OrdType, string OrdNum, string Site = null);
	}
}

