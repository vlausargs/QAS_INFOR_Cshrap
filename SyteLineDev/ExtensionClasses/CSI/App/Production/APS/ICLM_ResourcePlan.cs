//PROJECT NAME: Production
//CLASS NAME: ICLM_ResourcePlan.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ResourcePlan
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ResourcePlanSp(
			int? AltNum = 0,
			string FilterString = null);
	}
}

