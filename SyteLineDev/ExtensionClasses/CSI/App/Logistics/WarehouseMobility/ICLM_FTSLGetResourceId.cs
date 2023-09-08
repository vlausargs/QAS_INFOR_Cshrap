//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLGetResourceId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLGetResourceId
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetResourceIdSp(int? DisplayResourceId,
		string Job,
		int? Suffix,
		int? Operation);
	}
}

