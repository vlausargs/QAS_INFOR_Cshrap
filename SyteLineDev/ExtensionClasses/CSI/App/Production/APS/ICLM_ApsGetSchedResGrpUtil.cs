//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetSchedResGrpUtil.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetSchedResGrpUtil
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetSchedResGrpUtilSp(int? AltNum,
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

