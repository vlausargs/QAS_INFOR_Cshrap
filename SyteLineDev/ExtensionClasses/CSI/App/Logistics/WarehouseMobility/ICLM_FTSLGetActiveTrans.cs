//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLGetActiveTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLGetActiveTrans
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetActiveTransSp();
	}
}

