//PROJECT NAME: Logistics
//CLASS NAME: IAppmtLeaveVendToPayAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtLeaveVendToPayAmt
	{
		(int? ReturnCode, decimal? PToCheckAmt,
		decimal? PExchRate,
		decimal? PToApplied,
		decimal? PFromApplied,
		decimal? PToRemaining,
		decimal? PFromRemaining,
		string Infobar) AppmtLeaveVendToPayAmtSp(string PFromCurrCode,
		string PToCurrCode,
		string PBanCurrCode,
		string PDomCurrCode = null,
		decimal? PToCheckAmt = null,
		DateTime? PRecptDate = null,
		int? PCheckSeq = null,
		string PBankCode = null,
		string PVendNum = null,
		string PType = null,
		string PCreditMemoNum = null,
		decimal? PExchRate = null,
		decimal? PFromCheckAmt = null,
		decimal? PDomCheckAmt = 0,
		decimal? PToApplied = null,
		decimal? PFromApplied = null,
		decimal? PDomApplied = 0,
		decimal? PToRemaining = null,
		decimal? PFromRemaining = null,
		string Infobar = null);
	}
}

