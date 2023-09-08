//PROJECT NAME: Logistics
//CLASS NAME: IReserveOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IReserveOrder
	{
		(int? ReturnCode, string Infobar) ReserveOrderSp(string pSite,
		string pCoNum,
		string Infobar);
	}
}

