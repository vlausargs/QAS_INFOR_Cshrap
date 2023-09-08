//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetPlannerResGrpUtil.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetPlannerResGrpUtil
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetPlannerResGrpUtilSp(int? AltNum,
		DateTime? StartDate,
		int? IntervalCount,
		int? IntervalType,
		decimal? Threshold,
		string RGID,
		int? ExcludeInfinite,
		int? GroupAllocOnly,
		string WildCardChar,
		string FilterString = null);
	}
}

