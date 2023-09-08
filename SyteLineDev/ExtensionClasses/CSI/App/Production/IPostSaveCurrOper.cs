//PROJECT NAME: Production
//CLASS NAME: IPostSaveCurrOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPostSaveCurrOper
	{
		(int? ReturnCode, string Infobar) PostSaveCurrOperSp(string Job,
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
		Guid? OldJobrouteRowPointer = null);
	}
}

