//PROJECT NAME: Logistics
//CLASS NAME: IGetOrderLineStatusForPortal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetOrderLineStatusForPortal
	{
		string GetOrderLineStatusForPortalFn(
			string CoNum,
			int? CoLine,
			int? CoRelease);
	}
}

