//PROJECT NAME: Production
//CLASS NAME: PostSaveCurrOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PostSaveCurrOper : IPostSaveCurrOper
	{
		readonly IApplicationDB appDB;
		
		
		public PostSaveCurrOper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PostSaveCurrOperSp(string Job,
		int? Suffix,
		int? OperNum,
		string RunBasisLbr,
		decimal? RunLbrHours,
		string RunBasisMch,
		decimal? RunMchHours,
		decimal? SchedHours,
		decimal? MoveHours,
		decimal? QueueHours,
		decimal? SetupHours,
		decimal? OffsetHours,
		DateTime? EffectDate,
		DateTime? ObsDate,
		string Item,
		DateTime? PrevEffectDate,
		DateTime? PrevObsDate,
		string JobType,
		decimal? JshFinishHrs,
		int? JshWhenRule,
		string JshMatrixType,
		string JshTabid,
		int? JshPlannerstep,
		string JshSetuprgid,
		int? JshSetuprule,
		string JshSchedStepRule,
		int? JshCrsBrkRule,
		int? JshReallocate,
		decimal? JshSplitSize,
		string JshSchedDrv,
		string Infobar,
		string UpdateResourceGroupFrom = null,
		string BatchDef = null,
		int? JshSplitRule = null,
		string JshSplitGroup = null,
		Guid? OldJobrouteRowPointer = null)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			RunBasisLbrType _RunBasisLbr = RunBasisLbr;
			RunHoursPiecesType _RunLbrHours = RunLbrHours;
			RunBasisMchType _RunBasisMch = RunBasisMch;
			RunHoursPiecesType _RunMchHours = RunMchHours;
			SchedHoursType _SchedHours = SchedHours;
			SchedHoursType _MoveHours = MoveHours;
			SchedHoursType _QueueHours = QueueHours;
			SchedHoursType _SetupHours = SetupHours;
			SchedHoursType _OffsetHours = OffsetHours;
			DateType _EffectDate = EffectDate;
			DateType _ObsDate = ObsDate;
			ItemType _Item = Item;
			DateType _PrevEffectDate = PrevEffectDate;
			DateType _PrevObsDate = PrevObsDate;
			JobTypeType _JobType = JobType;
			SchedHoursType _JshFinishHrs = JshFinishHrs;
			ApsWhenRuleType _JshWhenRule = JshWhenRule;
			ApsLtypeType _JshMatrixType = JshMatrixType;
			ApsLtableType _JshTabid = JshTabid;
			ListYesNoType _JshPlannerstep = JshPlannerstep;
			ApsResgroupType _JshSetuprgid = JshSetuprgid;
			ApsSetupRuleType _JshSetuprule = JshSetuprule;
			ApsExprType _JshSchedStepRule = JshSchedStepRule;
			ApsBreakRuleType _JshCrsBrkRule = JshCrsBrkRule;
			ListYesNoType _JshReallocate = JshReallocate;
			ApsSplitsizeType _JshSplitSize = JshSplitSize;
			SchedDriverType _JshSchedDrv = JshSchedDrv;
			Infobar _Infobar = Infobar;
			WcType _UpdateResourceGroupFrom = UpdateResourceGroupFrom;
			ApsBatchType _BatchDef = BatchDef;
			ApsSplitRuleType _JshSplitRule = JshSplitRule;
			ApsResgroupType _JshSplitGroup = JshSplitGroup;
			RowPointerType _OldJobrouteRowPointer = OldJobrouteRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PostSaveCurrOperSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RunBasisLbr", _RunBasisLbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RunLbrHours", _RunLbrHours, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RunBasisMch", _RunBasisMch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RunMchHours", _RunMchHours, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchedHours", _SchedHours, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MoveHours", _MoveHours, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QueueHours", _QueueHours, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupHours", _SetupHours, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OffsetHours", _OffsetHours, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectDate", _EffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ObsDate", _ObsDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrevEffectDate", _PrevEffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrevObsDate", _PrevObsDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JshFinishHrs", _JshFinishHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JshWhenRule", _JshWhenRule, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JshMatrixType", _JshMatrixType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JshTabid", _JshTabid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JshPlannerstep", _JshPlannerstep, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JshSetuprgid", _JshSetuprgid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JshSetuprule", _JshSetuprule, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JshSchedStepRule", _JshSchedStepRule, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JshCrsBrkRule", _JshCrsBrkRule, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JshReallocate", _JshReallocate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JshSplitSize", _JshSplitSize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JshSchedDrv", _JshSchedDrv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UpdateResourceGroupFrom", _UpdateResourceGroupFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BatchDef", _BatchDef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JshSplitRule", _JshSplitRule, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JshSplitGroup", _JshSplitGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldJobrouteRowPointer", _OldJobrouteRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
