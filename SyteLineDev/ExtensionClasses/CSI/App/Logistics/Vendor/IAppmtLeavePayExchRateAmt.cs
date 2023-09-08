//PROJECT NAME: Logistics
//CLASS NAME: IAppmtLeavePayExchRateAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtLeavePayExchRateAmt
	{
		(int? ReturnCode, decimal? PToCheckAmt,
		decimal? PExchRate,
		decimal? PToApplied,
		decimal? PFromApplied,
		decimal? PToRemaining,
		decimal? PFromRemaining,
		string Infobar) AppmtLeavePayExchRateAmtSp(string PFromCurrCode,
		string PToCurrCode,
		string PBanCurrCode,
		decimal? PToCheckAmt,
		DateTime? PRecptDate,
		int? PCheckSeq,
		string PBankCode,
		string PVendtNum,
		string PType,
		string PCreditMemoNum,
		decimal? PExchRate,
		decimal? PFromCheckAmt,
		decimal? PToApplied,
		decimal? PFromApplied,
		decimal? PToRemaining,
		decimal? PFromRemaining,
		string Infobar);
	}
}

