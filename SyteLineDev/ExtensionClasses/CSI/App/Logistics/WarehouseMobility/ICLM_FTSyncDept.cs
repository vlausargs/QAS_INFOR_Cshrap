//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSyncDept.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSyncDept
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSyncDeptSp(string Site,
		DateTime? CutoffDate);
	}
}

