//PROJECT NAME: Logistics
//CLASS NAME: IAppmtLeaveVendAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtLeaveVendAmt
	{
		(int? ReturnCode, decimal? PDomCheckAmt,
		decimal? PExchRate,
		decimal? PDomApplied,
		decimal? PForApplied,
		decimal? PDomRemaining,
		decimal? PForRemaining,
		string Infobar) AppmtLeaveVendAmtSp(string PVendCurrCode = null,
		string PDomCurrCode = null,
		decimal? PDomCheckAmt = null,
		DateTime? PRecptDate = null,
		int? PCheckSeq = null,
		string PBankCode = null,
		string PVendNum = null,
		decimal? PExchRate = null,
		decimal? PForCheckAmt = null,
		decimal? PDomApplied = null,
		decimal? PForApplied = null,
		decimal? PPayApplied = 0,
		decimal? PDomRemaining = null,
		decimal? PForRemaining = null,
		string Infobar = null,
		int? PPayLeave = 0);
	}
}

