//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSyncHoliday.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSyncHoliday
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSyncHolidaySp(string Site,
		DateTime? CutoffDate,
		int? Alternative);
	}
}

