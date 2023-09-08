//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GetPortalCoShippingMethods.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetPortalCoShippingMethods
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetPortalCoShippingMethodsSp(string CoNum,
		string CoPaymentMethod,
		int? LocaleID,
		string Filter);
	}
}

