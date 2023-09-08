//PROJECT NAME: Production
//CLASS NAME: IApsUpdatePlannerStats.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsUpdatePlannerStats
	{
		int? ApsUpdatePlannerStatsSp(
			int? AltNo = 0);
	}
}

