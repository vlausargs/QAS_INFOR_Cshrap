//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLOperationDropDownHybrid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLOperationDropDownHybrid
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLOperationDropDownHybridSp(
			int? TTImplemented = 0,
			string Job = null,
			int? Suffix = null);
	}
}

