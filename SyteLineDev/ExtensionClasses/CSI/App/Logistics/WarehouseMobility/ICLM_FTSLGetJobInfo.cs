//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLGetJobInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLGetJobInfo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetJobInfoSp(string CallForm,
		int? TAImplement = 0,
		string Job = null,
		int? Suffix = null);
	}
}

