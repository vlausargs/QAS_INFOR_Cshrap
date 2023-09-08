//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLLoadVSAJobAndPreSerials.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLLoadVSAJobAndPreSerials
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLLoadVSAJobAndPreSerialsSp(string Job = null,
		int? Suffix = null);
	}
}

