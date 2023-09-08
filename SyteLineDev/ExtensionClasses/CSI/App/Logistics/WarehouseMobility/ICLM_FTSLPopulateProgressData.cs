//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLPopulateProgressData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLPopulateProgressData
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLPopulateProgressDataSp(string Job,
		int? Suffix);
	}
}

