//PROJECT NAME: Production
//CLASS NAME: SetItemValuesForCurrOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class SetItemValuesForCurrOper : ISetItemValuesForCurrOper
	{
		readonly IApplicationDB appDB;
		
		
		public SetItemValuesForCurrOper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? OperNum,
		string Wc,
		string WcDescription,
		DateTime? EffectDate,
		DateTime? ObsDate,
		int? CntrlPoint,
		string BflushType,
		decimal? JshSchedHrs,
		string RunBasisMch,
		string RunBasisLbr,
		decimal? JshRunMchHrs,
		decimal? JshRunLbrHrs,
		decimal? JshMoveHrs,
		decimal? JshQueueHrs,
		decimal? JshSetupHrs,
		decimal? JshOffsetHrs,
		decimal? Efficiency,
		decimal? SetupRate,
		decimal? RunRateLbr,
		decimal? VovhdRateMch,
		decimal? FovhdRateMch,
		decimal? VarovhdRate,
		decimal? FixovhdRate,
		string Infobar) SetItemValuesForCurrOperSp(string Item,
		int? OperNum,
		string Wc,
		string WcDescription,
		DateTime? EffectDate,
		DateTime? ObsDate,
		int? CntrlPoint,
		string BflushType,
		decimal? JshSchedHrs,
		string RunBasisMch,
		string RunBasisLbr,
		decimal? JshRunMchHrs,
		decimal? JshRunLbrHrs,
		decimal? JshMoveHrs,
		decimal? JshQueueHrs,
		decimal? JshSetupHrs,
		decimal? JshOffsetHrs,
		decimal? Efficiency,
		decimal? SetupRate,
		decimal? RunRateLbr,
		decimal? VovhdRateMch,
		decimal? FovhdRateMch,
		decimal? VarovhdRate,
		decimal? FixovhdRate,
		string Infobar)
		{
			ItemType _Item = Item;
			OperNumType _OperNum = OperNum;
			WcType _Wc = Wc;
			DescriptionType _WcDescription = WcDescription;
			DateType _EffectDate = EffectDate;
			DateType _ObsDate = ObsDate;
			ListYesNoType _CntrlPoint = CntrlPoint;
			BflushTypeType _BflushType = BflushType;
			SchedHoursType _JshSchedHrs = JshSchedHrs;
			RunBasisMchType _RunBasisMch = RunBasisMch;
			RunBasisLbrType _RunBasisLbr = RunBasisLbr;
			RunHoursPiecesType _JshRunMchHrs = JshRunMchHrs;
			RunHoursPiecesType _JshRunLbrHrs = JshRunLbrHrs;
			SchedHoursType _JshMoveHrs = JshMoveHrs;
			SchedHoursType _JshQueueHrs = JshQueueHrs;
			SchedHoursType _JshSetupHrs = JshSetupHrs;
			SchedHoursType _JshOffsetHrs = JshOffsetHrs;
			EfficiencyType _Efficiency = Efficiency;
			RunRateType _SetupRate = SetupRate;
			RunRateType _RunRateLbr = RunRateLbr;
			OverheadRateType _VovhdRateMch = VovhdRateMch;
			OverheadRateType _FovhdRateMch = FovhdRateMch;
			OverheadRateType _VarovhdRate = VarovhdRate;
			OverheadRateType _FixovhdRate = FixovhdRate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetItemValuesForCurrOperSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WcDescription", _WcDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EffectDate", _EffectDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ObsDate", _ObsDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CntrlPoint", _CntrlPoint, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BflushType", _BflushType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JshSchedHrs", _JshSchedHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RunBasisMch", _RunBasisMch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RunBasisLbr", _RunBasisLbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JshRunMchHrs", _JshRunMchHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JshRunLbrHrs", _JshRunLbrHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JshMoveHrs", _JshMoveHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JshQueueHrs", _JshQueueHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JshSetupHrs", _JshSetupHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JshOffsetHrs", _JshOffsetHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Efficiency", _Efficiency, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SetupRate", _SetupRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RunRateLbr", _RunRateLbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdRateMch", _VovhdRateMch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdRateMch", _FovhdRateMch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VarovhdRate", _VarovhdRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FixovhdRate", _FixovhdRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OperNum = _OperNum;
				Wc = _Wc;
				WcDescription = _WcDescription;
				EffectDate = _EffectDate;
				ObsDate = _ObsDate;
				CntrlPoint = _CntrlPoint;
				BflushType = _BflushType;
				JshSchedHrs = _JshSchedHrs;
				RunBasisMch = _RunBasisMch;
				RunBasisLbr = _RunBasisLbr;
				JshRunMchHrs = _JshRunMchHrs;
				JshRunLbrHrs = _JshRunLbrHrs;
				JshMoveHrs = _JshMoveHrs;
				JshQueueHrs = _JshQueueHrs;
				JshSetupHrs = _JshSetupHrs;
				JshOffsetHrs = _JshOffsetHrs;
				Efficiency = _Efficiency;
				SetupRate = _SetupRate;
				RunRateLbr = _RunRateLbr;
				VovhdRateMch = _VovhdRateMch;
				FovhdRateMch = _FovhdRateMch;
				VarovhdRate = _VarovhdRate;
				FixovhdRate = _FixovhdRate;
				Infobar = _Infobar;
				
				return (Severity, OperNum, Wc, WcDescription, EffectDate, ObsDate, CntrlPoint, BflushType, JshSchedHrs, RunBasisMch, RunBasisLbr, JshRunMchHrs, JshRunLbrHrs, JshMoveHrs, JshQueueHrs, JshSetupHrs, JshOffsetHrs, Efficiency, SetupRate, RunRateLbr, VovhdRateMch, FovhdRateMch, VarovhdRate, FixovhdRate, Infobar);
			}
		}
	}
}
