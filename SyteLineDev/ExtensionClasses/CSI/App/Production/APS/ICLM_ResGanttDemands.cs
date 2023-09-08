//PROJECT NAME: Production
//CLASS NAME: ICLM_ResGanttDemands.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ResGanttDemands
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ResGanttDemandsSp(int? AltNum = 0,
		int? PlannerFg = 1);
	}
}

