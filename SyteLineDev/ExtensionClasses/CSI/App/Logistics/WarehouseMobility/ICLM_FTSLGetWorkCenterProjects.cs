//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLGetWorkCenterProjects.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLGetWorkCenterProjects
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetWorkCenterProjectsSp(int? TT_Implemented = 0);
	}
}

