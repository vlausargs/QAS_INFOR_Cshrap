//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetGanttResources.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetGanttResources
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetGanttResourcesSp(DateTime? StartDate,
		DateTime? EndDate,
		int? Plan0Sched1,
		int? AltNum = 0);
	}
}

