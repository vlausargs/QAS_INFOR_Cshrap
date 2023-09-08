//PROJECT NAME: Production
//CLASS NAME: ICLM_ProjectMetricTopRevenue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface ICLM_ProjectMetricTopRevenue
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ProjectMetricTopRevenueSp(
			int? Count = 5);
	}
}

