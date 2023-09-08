//PROJECT NAME: Production
//CLASS NAME: CreateCurrentOperation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CreateCurrentOperation : ICreateCurrentOperation
	{
		readonly IApplicationDB appDB;
		
		public CreateCurrentOperation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string Infobar = null)
		{
			ItemType _Item = Item;
			StringType _CopyOption = CopyOption;
			OperNumType _JobrouteOperNum = JobrouteOperNum;
			WcType _JobrouteWc = JobrouteWc;
			RunBasisLbrType _JobrouteRunBasisLbr = JobrouteRunBasisLbr;
			RunBasisMchType _JobrouteRunBasisMch = JobrouteRunBasisMch;
			BflushTypeType _JobrouteBflushType = JobrouteBflushType;
			ListYesNoType _JobrouteCntrlPoint = JobrouteCntrlPoint;
			RunRateType _JobrouteSetupRate = JobrouteSetupRate;
			EfficiencyType _JobrouteEfficiency = JobrouteEfficiency;
			OverheadRateType _JobrouteFovhdRateMch = JobrouteFovhdRateMch;
			OverheadRateType _JobrouteVovhdRateMch = JobrouteVovhdRateMch;
			RunRateType _JobrouteRunRateLbr = JobrouteRunRateLbr;
			CostPrcType _JobrouteVarovhdRate = JobrouteVarovhdRate;
			CostPrcType _JobrouteFixovhdRate = JobrouteFixovhdRate;
			DateType _JobrouteEffectDate = JobrouteEffectDate;
			DateType _JobrouteObsDate = JobrouteObsDate;
			YieldType _JobrouteYield = JobrouteYield;
			TicksType _JrtSchSetupTicks = JrtSchSetupTicks;
			SchedHoursType _JrtSchSetupHrs = JrtSchSetupHrs;
			RunTicksType _JrtSchRunTicksLbr = JrtSchRunTicksLbr;
			RunHoursPiecesType _JrtSchRunLbrHrs = JrtSchRunLbrHrs;
			RunTicksType _JrtSchRunTicksMch = JrtSchRunTicksMch;
			RunHoursPiecesType _JrtSchRunMchHrs = JrtSchRunMchHrs;
			QtyUnitNoNegType _JrtSchPcsPerLbrHr = JrtSchPcsPerLbrHr;
			QtyUnitNoNegType _JrtSchPcsPerMchHr = JrtSchPcsPerMchHr;
			TicksType _JrtSchSchedTicks = JrtSchSchedTicks;
			TicksType _JrtSchSchedOff = JrtSchSchedOff;
			SchedHoursType _JrtSchOffsetHrs = JrtSchOffsetHrs;
			TicksType _JrtSchMoveTicks = JrtSchMoveTicks;
			SchedHoursType _JrtSchMoveHrs = JrtSchMoveHrs;
			TicksType _JrtSchQueueTicks = JrtSchQueueTicks;
			SchedHoursType _JrtSchQueueHrs = JrtSchQueueHrs;
			SchedHoursType _JrtSchFinishHrs = JrtSchFinishHrs;
			ApsLtypeType _JrtSchMatrixType = JrtSchMatrixType;
			ApsLtableType _JrtSchTabid = JrtSchTabid;
			ApsWhenRuleType _JrtSchWhenrule = JrtSchWhenrule;
			SchedDriverType _JrtSchSchedDrv = JrtSchSchedDrv;
			ListYesNoType _JrtSchPlannerStep = JrtSchPlannerStep;
			ApsResgroupType _JrtSchSetuprgid = JrtSchSetuprgid;
			ApsSetupRuleType _JrtSchSetuprule = JrtSchSetuprule;
			ApsJsStepexpRlType _JrtSchSchedsteprule = JrtSchSchedsteprule;
			ApsBreakRuleType _JrtSchCrsbrkrule = JrtSchCrsbrkrule;
			ListYesNoType _JrtSchAllowReallocation = JrtSchAllowReallocation;
			ApsSplitsizeType _JrtSchSplitsize = JrtSchSplitsize;
			ApsBatchType _JrtSchBatchDefinitionId = JrtSchBatchDefinitionId;
			RowPointerType _JobRouteRowPointer = JobRouteRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateCurrentOperationSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyOption", _CopyOption, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteOperNum", _JobrouteOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteWc", _JobrouteWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteRunBasisLbr", _JobrouteRunBasisLbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteRunBasisMch", _JobrouteRunBasisMch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteBflushType", _JobrouteBflushType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteCntrlPoint", _JobrouteCntrlPoint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteSetupRate", _JobrouteSetupRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteEfficiency", _JobrouteEfficiency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteFovhdRateMch", _JobrouteFovhdRateMch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteVovhdRateMch", _JobrouteVovhdRateMch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteRunRateLbr", _JobrouteRunRateLbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteVarovhdRate", _JobrouteVarovhdRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteFixovhdRate", _JobrouteFixovhdRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteEffectDate", _JobrouteEffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteObsDate", _JobrouteObsDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteYield", _JobrouteYield, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchSetupTicks", _JrtSchSetupTicks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchSetupHrs", _JrtSchSetupHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchRunTicksLbr", _JrtSchRunTicksLbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchRunLbrHrs", _JrtSchRunLbrHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchRunTicksMch", _JrtSchRunTicksMch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchRunMchHrs", _JrtSchRunMchHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchPcsPerLbrHr", _JrtSchPcsPerLbrHr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchPcsPerMchHr", _JrtSchPcsPerMchHr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchSchedTicks", _JrtSchSchedTicks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchSchedOff", _JrtSchSchedOff, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchOffsetHrs", _JrtSchOffsetHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchMoveTicks", _JrtSchMoveTicks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchMoveHrs", _JrtSchMoveHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchQueueTicks", _JrtSchQueueTicks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchQueueHrs", _JrtSchQueueHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchFinishHrs", _JrtSchFinishHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchMatrixType", _JrtSchMatrixType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchTabid", _JrtSchTabid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchWhenrule", _JrtSchWhenrule, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchSchedDrv", _JrtSchSchedDrv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchPlannerStep", _JrtSchPlannerStep, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchSetuprgid", _JrtSchSetuprgid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchSetuprule", _JrtSchSetuprule, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchSchedsteprule", _JrtSchSchedsteprule, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchCrsbrkrule", _JrtSchCrsbrkrule, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchAllowReallocation", _JrtSchAllowReallocation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchSplitsize", _JrtSchSplitsize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JrtSchBatchDefinitionId", _JrtSchBatchDefinitionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRouteRowPointer", _JobRouteRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
