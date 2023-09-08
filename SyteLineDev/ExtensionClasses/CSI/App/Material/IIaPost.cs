//PROJECT NAME: Material
//CLASS NAME: IIaPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IIaPost
	{
		(int? ReturnCode, decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		decimal? TotalCost,
		decimal? ProfitMarkup,
		string Infobar) IaPostSp(string TrxType,
		DateTime? TransDate,
		string Acct = null,
		string AcctUnit1 = null,
		string AcctUnit2 = null,
		string AcctUnit3 = null,
		string AcctUnit4 = null,
		decimal? TransQty = null,
		string Whse = null,
		string Item = null,
		string Loc = null,
		string Lot = null,
		string FromSite = null,
		string ToSite = null,
		string ReasonCode = null,
		string TrnNum = null,
		int? TrnLine = null,
		decimal? TransNum = null,
		decimal? RsvdNum = null,
		string SerialStat = "I",
		string Workkey = null,
		int? Override = 0,
		decimal? MatlCost = null,
		decimal? LbrCost = null,
		decimal? FovhdCost = null,
		decimal? VovhdCost = null,
		decimal? OutCost = null,
		decimal? TotalCost = null,
		decimal? ProfitMarkup = null,
		string Infobar = null,
		string ToWhse = null,
		string ToLoc = null,
		string ToLot = null,
		string TransferTrxType = null,
		Guid? TmpSerId = null,
		int? UseExistingSerials = null,
		string SerialPrefix = null,
		string RemoteSiteLot = null,
		string DocumentNum = null,
		string ImportDocId = null,
		int? MoveZeroCostItem = 0,
		string EmpNum = null,
		int? SkipItemlocDelete = 0);
	}
}

