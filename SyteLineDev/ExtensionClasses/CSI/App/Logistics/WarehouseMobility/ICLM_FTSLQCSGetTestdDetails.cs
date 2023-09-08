//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLQCSGetTestdDetails.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLQCSGetTestdDetails
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLQCSGetTestdDetailsSp(string RcvrNum,
		int? Page);
	}
}

