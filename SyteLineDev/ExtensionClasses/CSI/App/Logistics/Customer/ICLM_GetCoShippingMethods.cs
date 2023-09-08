//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GetCoShippingMethods.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetCoShippingMethods
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetCoShippingMethodsSp(string ShipMethod,
		string CoNum,
		string CoPaymentMethod,
		string LangCode);
	}
}

