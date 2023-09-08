//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLValidateProjTask.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLValidateProjTask
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLValidateProjTaskSp(string ValidateType);
	}
}

