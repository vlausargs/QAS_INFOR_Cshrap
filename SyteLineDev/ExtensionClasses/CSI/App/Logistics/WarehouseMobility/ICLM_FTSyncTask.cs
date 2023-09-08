//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSyncTask.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSyncTask
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSyncTaskSp(string Site,
		DateTime? CutoffDate);
	}
}

