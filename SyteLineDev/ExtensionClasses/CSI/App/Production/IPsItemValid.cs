//PROJECT NAME: Production
//CLASS NAME: IPsItemValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPsItemValid
	{
		(int? ReturnCode, string Item,
		string TItemDesc,
		int? TSerTracked,
		int? TLotTracked,
		string TLotPrefix,
		string TLoc,
		string TLot,
		string TUM,
		decimal? UomConvFactor,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		int? EnableContainer) PsItemValidSp(string Item,
		string Whse,
		string TItemDesc,
		int? TSerTracked,
		int? TLotTracked,
		string TLotPrefix,
		string TLoc,
		string TLot,
		string TUM,
		decimal? UomConvFactor,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		int? EnableContainer = 0);
	}
}

