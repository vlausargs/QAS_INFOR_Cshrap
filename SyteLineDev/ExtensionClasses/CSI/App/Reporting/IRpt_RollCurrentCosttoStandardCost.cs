//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RollCurrentCosttoStandardCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RollCurrentCosttoStandardCost
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RollCurrentCosttoStandardCostSp(string Post = null,
		string FromProductCode = null,
		string ToProductCode = null,
		string FromItem = null,
		string ToItem = null,
		string FromWarehouse = null,
		string ToWarehouse = null,
		string Source = null,
		string ABC = null,
		string CostMethod = null,
		string MatlType = null,
		int? DisplayHeader = null,
		decimal? UserID = null,
		string BGSessionId = null,
		string pSite = null,
        int? DebugLevel = null,
        int? TaskId = null,
        int? CommitSize = null);
	}
}

