//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSyncEmployee.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSyncEmployee
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSyncEmployeeSp(string Site,
		DateTime? CutoffDate);
	}
}

