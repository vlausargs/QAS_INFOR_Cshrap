//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSyncTimeOffGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSyncTimeOffGroup
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSyncTimeOffGroupSp(string Site,
		DateTime? CutoffDate);
	}
}

