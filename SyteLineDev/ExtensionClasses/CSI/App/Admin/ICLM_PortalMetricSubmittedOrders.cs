//PROJECT NAME: Admin
//CLASS NAME: ICLM_PortalMetricSubmittedOrders.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ICLM_PortalMetricSubmittedOrders
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PortalMetricSubmittedOrdersSp(int? NumberOfRows = 12,
		string FilterString = null);
	}
}

