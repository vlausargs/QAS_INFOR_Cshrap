//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLQCSGetTesteachDetails.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLQCSGetTesteachDetails
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLQCSGetTesteachDetailsSp(string RcvrNum,
		int? Page);
	}
}

