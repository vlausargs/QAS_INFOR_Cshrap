//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLGetWorkCenterServiceOrders.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLGetWorkCenterServiceOrders
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetWorkCenterServiceOrdersSp(int? TT_Implemented = 0);
	}
}

