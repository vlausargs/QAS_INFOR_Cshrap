//PROJECT NAME: Logistics
//CLASS NAME: IGetOrderHeaderStatusForPortal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetOrderHeaderStatusForPortal
	{
		string GetOrderHeaderStatusForPortalFn(
			string CoNum);
	}
}

