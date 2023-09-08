//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLVisualDispatch.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLVisualDispatch
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLVisualDispatchSp(string ResGrp = null,
		string Job = null);
	}
}

