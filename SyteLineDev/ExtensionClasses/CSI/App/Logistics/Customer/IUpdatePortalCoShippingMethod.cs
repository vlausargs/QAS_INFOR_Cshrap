//PROJECT NAME: Logistics
//CLASS NAME: IUpdatePortalCoShippingMethod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IUpdatePortalCoShippingMethod
	{
		int? UpdatePortalCoShippingMethodSp(string CoNum,
		string CoShipMethod);
	}
}

