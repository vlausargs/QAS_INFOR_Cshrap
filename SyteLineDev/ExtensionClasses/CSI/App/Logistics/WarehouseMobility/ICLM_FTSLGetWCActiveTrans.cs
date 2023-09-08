//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLGetWCActiveTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLGetWCActiveTrans
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetWCActiveTransSp(string ERPQueryResponseString);
	}
}

