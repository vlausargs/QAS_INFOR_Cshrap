//PROJECT NAME: Production
//CLASS NAME: ICLM_ProjectMetricTopPlanCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface ICLM_ProjectMetricTopPlanCost
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ProjectMetricTopPlanCostSp(
			int? Count = 5);
	}
}

