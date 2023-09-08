//PROJECT NAME: Logistics
//CLASS NAME: ICLM_PortalOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_PortalOrder
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PortalOrderSp(string CoNum,
		int? LocaleID,
		string ResellerCustNum);
	}
}

