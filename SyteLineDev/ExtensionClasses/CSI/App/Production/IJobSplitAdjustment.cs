//PROJECT NAME: Production
//CLASS NAME: IJobSplitAdjustment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobSplitAdjustment
	{
		(int? ReturnCode, string Infobar) JobSplitAdjustmentSp(int? Mode,
		string NewJob,
		int? NewSuffix,
		int? OperNum,
		decimal? OpQtyReceived,
		decimal? OpQtyComplete,
		decimal? OpQtyMoved,
		decimal? OpSetupHrsT,
		decimal? OpRunHrsTLbr,
		decimal? OpRunHrsTMch,
		string MatlItem,
		string MatlType,
		decimal? MatlQtyIssuedConv,
		decimal? MatlAMatlCost,
		decimal? MatlALbrCost,
		decimal? MatlAOutCost,
		decimal? MatlAFovhdCost,
		decimal? MatlAVovhdCost,
		string Infobar);
	}
}

