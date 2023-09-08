//PROJECT NAME: Material
//CLASS NAME: IRValLot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IRValLot
	{
		(int? ReturnCode, string Lot,
		int? AddLot,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string TrxRestrictCode) RValLotSP(string Item,
		string Lot,
		int? AddLot,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string Site = null,
		decimal? Quantity = null,
		string TrxRestrictCode = null);
	}
}

