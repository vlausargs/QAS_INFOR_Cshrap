//PROJECT NAME: Production
//CLASS NAME: ISetItemValuesForCurrOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ISetItemValuesForCurrOper
	{
		(int? ReturnCode, int? OperNum,
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
		string Infobar);
	}
}

