//PROJECT NAME: Production
//CLASS NAME: IWcmatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IWcmatl
	{
		(int? ReturnCode, string Infobar) WcmatlSp(string TWc,
		string TItem,
		string TWhse,
		string TLoc,
		string TLot,
		decimal? TQty,
		DateTime? TTransDate,
		string TEmpNum,
		string TAcct,
		string TAcctUnit1,
		string TAcctUnit2,
		string TAcctUnit3,
		string TAcctUnit4,
		decimal? TMatlCost,
		decimal? TLbrCost,
		decimal? TFovhdCost,
		decimal? TVovhdCost,
		decimal? TOutCost,
		decimal? UmConvFactor,
		string SerialPrefix,
		string Infobar,
		string DocumentNum = null);
	}
}

