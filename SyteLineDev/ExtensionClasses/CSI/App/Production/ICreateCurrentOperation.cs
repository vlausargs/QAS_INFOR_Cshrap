//PROJECT NAME: Production
//CLASS NAME: ICreateCurrentOperation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICreateCurrentOperation
	{
		(int? ReturnCode,
			string Infobar) CreateCurrentOperationSp(
			string Item,
			string CopyOption = "D",
			int? JobrouteOperNum = null,
			string JobrouteWc = null,
			string JobrouteRunBasisLbr = null,
			string JobrouteRunBasisMch = null,
			string JobrouteBflushType = null,
			int? JobrouteCntrlPoint = null,
			decimal? JobrouteSetupRate = null,
			decimal? JobrouteEfficiency = null,
			decimal? JobrouteFovhdRateMch = null,
			decimal? JobrouteVovhdRateMch = null,
			decimal? JobrouteRunRateLbr = null,
			decimal? JobrouteVarovhdRate = null,
			decimal? JobrouteFixovhdRate = null,
			DateTime? JobrouteEffectDate = null,
			DateTime? JobrouteObsDate = null,
			decimal? JobrouteYield = null,
			decimal? JrtSchSetupTicks = null,
			decimal? JrtSchSetupHrs = null,
			decimal? JrtSchRunTicksLbr = null,
			decimal? JrtSchRunLbrHrs = null,
			decimal? JrtSchRunTicksMch = null,
			decimal? JrtSchRunMchHrs = null,
			decimal? JrtSchPcsPerLbrHr = null,
			decimal? JrtSchPcsPerMchHr = null,
			decimal? JrtSchSchedTicks = null,
			decimal? JrtSchSchedOff = null,
			decimal? JrtSchOffsetHrs = null,
			decimal? JrtSchMoveTicks = null,
			decimal? JrtSchMoveHrs = null,
			decimal? JrtSchQueueTicks = null,
			decimal? JrtSchQueueHrs = null,
			decimal? JrtSchFinishHrs = null,
			string JrtSchMatrixType = null,
			string JrtSchTabid = null,
			int? JrtSchWhenrule = null,
			string JrtSchSchedDrv = null,
			int? JrtSchPlannerStep = null,
			string JrtSchSetuprgid = null,
			int? JrtSchSetuprule = null,
			int? JrtSchSchedsteprule = null,
			int? JrtSchCrsbrkrule = null,
			int? JrtSchAllowReallocation = null,
			decimal? JrtSchSplitsize = null,
			string JrtSchBatchDefinitionId = null,
			Guid? JobRouteRowPointer = null,
			string Infobar = null);
	}
}

