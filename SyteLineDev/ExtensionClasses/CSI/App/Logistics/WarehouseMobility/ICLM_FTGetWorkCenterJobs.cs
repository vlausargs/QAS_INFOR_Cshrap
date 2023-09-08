//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTGetWorkCenterJobs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTGetWorkCenterJobs
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTGetWorkCenterJobsSp(string WorkCenter,
		string FilterString = null,
		string OrderByString = null,
		string ResouceGroup = null,
		string ResourceId = null,
		int? DateInterval = null);
	}
}

