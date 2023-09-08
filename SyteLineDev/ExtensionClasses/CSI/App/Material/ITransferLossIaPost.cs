//PROJECT NAME: Material
//CLASS NAME: ITransferLossIaPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ITransferLossIaPost
	{
		(int? ReturnCode, string Infobar) TransferLossIaPostSp(string TrxType,
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
		string FROMSite = null,
		string ToSite = null,
		string RemoteSite = null,
		string ReasonCode = null,
		string TrnNum = null,
		int? TrnLine = null,
		string Infobar = null,
		string ImportDocId = null,
		int? MoveZeroCostItem = 0,
		DateTime? RecordDate = null,
		string DocumentNum = null);
	}
}

