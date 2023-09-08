//PROJECT NAME: CSIProduct
//CLASS NAME: EngWBJobroute.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IEngWBJobroute
	{
		(int? ReturnCode, int? JobrouteOperNum, string JobrouteWc, DateTime? JrtSchStartDate, DateTime? JrtSchEndDate, byte? JobrouteCntrlPoint, string JobrouteBflushType, string JobrouteRunBasisLbr, string JobrouteRunBasisMch, byte? UseFixedSchedule, decimal? JrtSchSchedHrs, decimal? JrtSchPcsPerLbrHr, decimal? JrtSchPcsPerMchHr, decimal? JrtSchMoveHrs, decimal? JrtSchQueueHrs, decimal? JrtSchSetupHrs, byte? UseOffsetHrs, decimal? JrtSchOffsetHrs, string WcDescription, decimal? JrtSchFinishHrs, byte? JobrouteComplete, string JrtSchSchedDrv, decimal? JrtSchRunLbrHrs, decimal? JrtSchRunMchHrs, decimal? JobrouteSetupRate, decimal? JobrouteRunRateLbr, decimal? JobrouteVovhdRateMch, decimal? JobrouteFovhdRateMch, decimal? JobrouteVarovhdRate, decimal? JobrouteFixovhdRate, decimal? JobrouteEfficiency, short? JrtSchSchedsteprule, decimal? JrtYield, short? JrtSchWhenRule, string JrtSchMatrixType, string JrtSchTabid, byte? JrtSchPlannerstep, string JrtSchSetuprgid, short? JrtSchSetuprule, short? JrtSchCrsBrkRule, byte? JrtSchAllowReallocation, double? JrtSchSplitSize) EngWBJobrouteSp(Guid? JobrouteRowPointer,
		int? JobrouteOperNum,
		string JobrouteWc,
		DateTime? JrtSchStartDate,
		DateTime? JrtSchEndDate,
		byte? JobrouteCntrlPoint,
		string JobrouteBflushType,
		string JobrouteRunBasisLbr,
		string JobrouteRunBasisMch,
		byte? UseFixedSchedule,
		decimal? JrtSchSchedHrs,
		decimal? JrtSchPcsPerLbrHr,
		decimal? JrtSchPcsPerMchHr,
		decimal? JrtSchMoveHrs,
		decimal? JrtSchQueueHrs,
		decimal? JrtSchSetupHrs,
		byte? UseOffsetHrs,
		decimal? JrtSchOffsetHrs,
		string WcDescription,
		decimal? JrtSchFinishHrs,
		byte? JobrouteComplete,
		string JrtSchSchedDrv,
		decimal? JrtSchRunLbrHrs,
		decimal? JrtSchRunMchHrs,
		decimal? JobrouteSetupRate,
		decimal? JobrouteRunRateLbr,
		decimal? JobrouteVovhdRateMch,
		decimal? JobrouteFovhdRateMch,
		decimal? JobrouteVarovhdRate,
		decimal? JobrouteFixovhdRate,
		decimal? JobrouteEfficiency,
		short? JrtSchSchedsteprule,
		decimal? JrtYield = null,
		short? JrtSchWhenRule = null,
		string JrtSchMatrixType = null,
		string JrtSchTabid = null,
		byte? JrtSchPlannerstep = null,
		string JrtSchSetuprgid = null,
		short? JrtSchSetuprule = null,
		short? JrtSchCrsBrkRule = null,
		byte? JrtSchAllowReallocation = null,
		double? JrtSchSplitSize = null);
	}
	
	public class EngWBJobroute : IEngWBJobroute
	{
		readonly IApplicationDB appDB;
		
		public EngWBJobroute(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? JobrouteOperNum, string JobrouteWc, DateTime? JrtSchStartDate, DateTime? JrtSchEndDate, byte? JobrouteCntrlPoint, string JobrouteBflushType, string JobrouteRunBasisLbr, string JobrouteRunBasisMch, byte? UseFixedSchedule, decimal? JrtSchSchedHrs, decimal? JrtSchPcsPerLbrHr, decimal? JrtSchPcsPerMchHr, decimal? JrtSchMoveHrs, decimal? JrtSchQueueHrs, decimal? JrtSchSetupHrs, byte? UseOffsetHrs, decimal? JrtSchOffsetHrs, string WcDescription, decimal? JrtSchFinishHrs, byte? JobrouteComplete, string JrtSchSchedDrv, decimal? JrtSchRunLbrHrs, decimal? JrtSchRunMchHrs, decimal? JobrouteSetupRate, decimal? JobrouteRunRateLbr, decimal? JobrouteVovhdRateMch, decimal? JobrouteFovhdRateMch, decimal? JobrouteVarovhdRate, decimal? JobrouteFixovhdRate, decimal? JobrouteEfficiency, short? JrtSchSchedsteprule, decimal? JrtYield, short? JrtSchWhenRule, string JrtSchMatrixType, string JrtSchTabid, byte? JrtSchPlannerstep, string JrtSchSetuprgid, short? JrtSchSetuprule, short? JrtSchCrsBrkRule, byte? JrtSchAllowReallocation, double? JrtSchSplitSize) EngWBJobrouteSp(Guid? JobrouteRowPointer,
		int? JobrouteOperNum,
		string JobrouteWc,
		DateTime? JrtSchStartDate,
		DateTime? JrtSchEndDate,
		byte? JobrouteCntrlPoint,
		string JobrouteBflushType,
		string JobrouteRunBasisLbr,
		string JobrouteRunBasisMch,
		byte? UseFixedSchedule,
		decimal? JrtSchSchedHrs,
		decimal? JrtSchPcsPerLbrHr,
		decimal? JrtSchPcsPerMchHr,
		decimal? JrtSchMoveHrs,
		decimal? JrtSchQueueHrs,
		decimal? JrtSchSetupHrs,
		byte? UseOffsetHrs,
		decimal? JrtSchOffsetHrs,
		string WcDescription,
		decimal? JrtSchFinishHrs,
		byte? JobrouteComplete,
		string JrtSchSchedDrv,
		decimal? JrtSchRunLbrHrs,
		decimal? JrtSchRunMchHrs,
		decimal? JobrouteSetupRate,
		decimal? JobrouteRunRateLbr,
		decimal? JobrouteVovhdRateMch,
		decimal? JobrouteFovhdRateMch,
		decimal? JobrouteVarovhdRate,
		decimal? JobrouteFixovhdRate,
		decimal? JobrouteEfficiency,
		short? JrtSchSchedsteprule,
		decimal? JrtYield = null,
		short? JrtSchWhenRule = null,
		string JrtSchMatrixType = null,
		string JrtSchTabid = null,
		byte? JrtSchPlannerstep = null,
		string JrtSchSetuprgid = null,
		short? JrtSchSetuprule = null,
		short? JrtSchCrsBrkRule = null,
		byte? JrtSchAllowReallocation = null,
		double? JrtSchSplitSize = null)
		{
			RowPointerType _JobrouteRowPointer = JobrouteRowPointer;
			OperNumType _JobrouteOperNum = JobrouteOperNum;
			WcType _JobrouteWc = JobrouteWc;
			DateType _JrtSchStartDate = JrtSchStartDate;
			DateType _JrtSchEndDate = JrtSchEndDate;
			ListYesNoType _JobrouteCntrlPoint = JobrouteCntrlPoint;
			BflushTypeType _JobrouteBflushType = JobrouteBflushType;
			RunBasisLbrType _JobrouteRunBasisLbr = JobrouteRunBasisLbr;
			RunBasisMchType _JobrouteRunBasisMch = JobrouteRunBasisMch;
			ListYesNoType _UseFixedSchedule = UseFixedSchedule;
			SchedHoursType _JrtSchSchedHrs = JrtSchSchedHrs;
			QtyUnitNoNegType _JrtSchPcsPerLbrHr = JrtSchPcsPerLbrHr;
			QtyUnitNoNegType _JrtSchPcsPerMchHr = JrtSchPcsPerMchHr;
			SchedHoursType _JrtSchMoveHrs = JrtSchMoveHrs;
			SchedHoursType _JrtSchQueueHrs = JrtSchQueueHrs;
			SchedHoursType _JrtSchSetupHrs = JrtSchSetupHrs;
			ListYesNoType _UseOffsetHrs = UseOffsetHrs;
			SchedHoursType _JrtSchOffsetHrs = JrtSchOffsetHrs;
			DescriptionType _WcDescription = WcDescription;
			SchedHoursType _JrtSchFinishHrs = JrtSchFinishHrs;
			ListYesNoType _JobrouteComplete = JobrouteComplete;
			SchedDriverType _JrtSchSchedDrv = JrtSchSchedDrv;
			RunHoursPiecesType _JrtSchRunLbrHrs = JrtSchRunLbrHrs;
			RunHoursPiecesType _JrtSchRunMchHrs = JrtSchRunMchHrs;
			RunRateType _JobrouteSetupRate = JobrouteSetupRate;
			RunRateType _JobrouteRunRateLbr = JobrouteRunRateLbr;
			OverheadRateType _JobrouteVovhdRateMch = JobrouteVovhdRateMch;
			OverheadRateType _JobrouteFovhdRateMch = JobrouteFovhdRateMch;
			OverheadRateType _JobrouteVarovhdRate = JobrouteVarovhdRate;
			OverheadRateType _JobrouteFixovhdRate = JobrouteFixovhdRate;
			EfficiencyType _JobrouteEfficiency = JobrouteEfficiency;
			ApsJsStepexpRlType _JrtSchSchedsteprule = JrtSchSchedsteprule;
			YieldType _JrtYield = JrtYield;
			ApsWhenRuleType _JrtSchWhenRule = JrtSchWhenRule;
			ApsLtypeType _JrtSchMatrixType = JrtSchMatrixType;
			ApsLtableType _JrtSchTabid = JrtSchTabid;
			ListYesNoType _JrtSchPlannerstep = JrtSchPlannerstep;
			ApsResgroupType _JrtSchSetuprgid = JrtSchSetuprgid;
			ApsSetupRuleType _JrtSchSetuprule = JrtSchSetuprule;
			ApsBreakRuleType _JrtSchCrsBrkRule = JrtSchCrsBrkRule;
			ListYesNoType _JrtSchAllowReallocation = JrtSchAllowReallocation;
			ApsSplitsizeType _JrtSchSplitSize = JrtSchSplitSize;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EngWBJobrouteSp";
				
				appDB.AddCommandParameter(cmd, "JobrouteRowPointer", _JobrouteRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobrouteOperNum", _JobrouteOperNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobrouteWc", _JobrouteWc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchStartDate", _JrtSchStartDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchEndDate", _JrtSchEndDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobrouteCntrlPoint", _JobrouteCntrlPoint, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobrouteBflushType", _JobrouteBflushType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobrouteRunBasisLbr", _JobrouteRunBasisLbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobrouteRunBasisMch", _JobrouteRunBasisMch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseFixedSchedule", _UseFixedSchedule, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchSchedHrs", _JrtSchSchedHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchPcsPerLbrHr", _JrtSchPcsPerLbrHr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchPcsPerMchHr", _JrtSchPcsPerMchHr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchMoveHrs", _JrtSchMoveHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchQueueHrs", _JrtSchQueueHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchSetupHrs", _JrtSchSetupHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseOffsetHrs", _UseOffsetHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchOffsetHrs", _JrtSchOffsetHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WcDescription", _WcDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchFinishHrs", _JrtSchFinishHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobrouteComplete", _JobrouteComplete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchSchedDrv", _JrtSchSchedDrv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchRunLbrHrs", _JrtSchRunLbrHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchRunMchHrs", _JrtSchRunMchHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobrouteSetupRate", _JobrouteSetupRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobrouteRunRateLbr", _JobrouteRunRateLbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobrouteVovhdRateMch", _JobrouteVovhdRateMch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobrouteFovhdRateMch", _JobrouteFovhdRateMch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobrouteVarovhdRate", _JobrouteVarovhdRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobrouteFixovhdRate", _JobrouteFixovhdRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobrouteEfficiency", _JobrouteEfficiency, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchSchedsteprule", _JrtSchSchedsteprule, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtYield", _JrtYield, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchWhenRule", _JrtSchWhenRule, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchMatrixType", _JrtSchMatrixType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchTabid", _JrtSchTabid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchPlannerstep", _JrtSchPlannerstep, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchSetuprgid", _JrtSchSetuprgid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchSetuprule", _JrtSchSetuprule, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchCrsBrkRule", _JrtSchCrsBrkRule, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchAllowReallocation", _JrtSchAllowReallocation, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JrtSchSplitSize", _JrtSchSplitSize, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				JobrouteOperNum = _JobrouteOperNum;
				JobrouteWc = _JobrouteWc;
				JrtSchStartDate = _JrtSchStartDate;
				JrtSchEndDate = _JrtSchEndDate;
				JobrouteCntrlPoint = _JobrouteCntrlPoint;
				JobrouteBflushType = _JobrouteBflushType;
				JobrouteRunBasisLbr = _JobrouteRunBasisLbr;
				JobrouteRunBasisMch = _JobrouteRunBasisMch;
				UseFixedSchedule = _UseFixedSchedule;
				JrtSchSchedHrs = _JrtSchSchedHrs;
				JrtSchPcsPerLbrHr = _JrtSchPcsPerLbrHr;
				JrtSchPcsPerMchHr = _JrtSchPcsPerMchHr;
				JrtSchMoveHrs = _JrtSchMoveHrs;
				JrtSchQueueHrs = _JrtSchQueueHrs;
				JrtSchSetupHrs = _JrtSchSetupHrs;
				UseOffsetHrs = _UseOffsetHrs;
				JrtSchOffsetHrs = _JrtSchOffsetHrs;
				WcDescription = _WcDescription;
				JrtSchFinishHrs = _JrtSchFinishHrs;
				JobrouteComplete = _JobrouteComplete;
				JrtSchSchedDrv = _JrtSchSchedDrv;
				JrtSchRunLbrHrs = _JrtSchRunLbrHrs;
				JrtSchRunMchHrs = _JrtSchRunMchHrs;
				JobrouteSetupRate = _JobrouteSetupRate;
				JobrouteRunRateLbr = _JobrouteRunRateLbr;
				JobrouteVovhdRateMch = _JobrouteVovhdRateMch;
				JobrouteFovhdRateMch = _JobrouteFovhdRateMch;
				JobrouteVarovhdRate = _JobrouteVarovhdRate;
				JobrouteFixovhdRate = _JobrouteFixovhdRate;
				JobrouteEfficiency = _JobrouteEfficiency;
				JrtSchSchedsteprule = _JrtSchSchedsteprule;
				JrtYield = _JrtYield;
				JrtSchWhenRule = _JrtSchWhenRule;
				JrtSchMatrixType = _JrtSchMatrixType;
				JrtSchTabid = _JrtSchTabid;
				JrtSchPlannerstep = _JrtSchPlannerstep;
				JrtSchSetuprgid = _JrtSchSetuprgid;
				JrtSchSetuprule = _JrtSchSetuprule;
				JrtSchCrsBrkRule = _JrtSchCrsBrkRule;
				JrtSchAllowReallocation = _JrtSchAllowReallocation;
				JrtSchSplitSize = _JrtSchSplitSize;
				
				return (Severity, JobrouteOperNum, JobrouteWc, JrtSchStartDate, JrtSchEndDate, JobrouteCntrlPoint, JobrouteBflushType, JobrouteRunBasisLbr, JobrouteRunBasisMch, UseFixedSchedule, JrtSchSchedHrs, JrtSchPcsPerLbrHr, JrtSchPcsPerMchHr, JrtSchMoveHrs, JrtSchQueueHrs, JrtSchSetupHrs, UseOffsetHrs, JrtSchOffsetHrs, WcDescription, JrtSchFinishHrs, JobrouteComplete, JrtSchSchedDrv, JrtSchRunLbrHrs, JrtSchRunMchHrs, JobrouteSetupRate, JobrouteRunRateLbr, JobrouteVovhdRateMch, JobrouteFovhdRateMch, JobrouteVarovhdRate, JobrouteFixovhdRate, JobrouteEfficiency, JrtSchSchedsteprule, JrtYield, JrtSchWhenRule, JrtSchMatrixType, JrtSchTabid, JrtSchPlannerstep, JrtSchSetuprgid, JrtSchSetuprule, JrtSchCrsBrkRule, JrtSchAllowReallocation, JrtSchSplitSize);
			}
		}
	}
}
