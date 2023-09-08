//PROJECT NAME: Production
//CLASS NAME: ICLM_ProjectCostingActivity.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface ICLM_ProjectCostingActivity
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ProjectCostingActivitySp(string ProjMgr = null,
		string PeriodType = "M",
		string FilterString = null,
		string SiteGroup = null);
	}
}

