//PROJECT NAME: Logistics
//CLASS NAME: IEstimateLinesValidateAllItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEstimateLinesValidateAllItem
	{
		(int? ReturnCode, string PItem,
		string PUM,
		decimal? PDisc,
		string PCustItem,
		string PItemDesc,
		string PRefType,
		string PRefNum,
		int? PRefLineSuf,
		int? PRefRelease,
		int? PRepriceChecked,
		string PTaxCode1,
		string PTaxCode2,
		string ItemFeatStr,
		decimal? PCostConv,
		int? PStocked,
		int? PNoChange,
		int? PProdCfg,
		decimal? PMatlCost,
		decimal? PLbrCost,
		decimal? PFovhdCost,
		decimal? PVovhdCost,
		decimal? POutCost,
		decimal? PTotCost,
		string ItemFeatTempl,
		int? PItemSerialTracked,
		int? PItemExists,
		string Infobar,
		string Prompt,
		string PromptButtons) EstimateLinesValidateAllItemSp(string PItem,
		string PCoNum,
		int? PCoLine,
		int? PCoRelease,
		string PCustNum,
		decimal? PQtyOrdered,
		string PUM,
		decimal? PDisc,
		string PCustItem,
		string PItemDesc,
		string PRefType,
		string PRefNum,
		int? PRefLineSuf,
		int? PRefRelease,
		int? PRepriceChecked,
		string PTaxCode1,
		string PTaxCode2,
		string ItemFeatStr,
		decimal? PCostConv,
		int? PStocked,
		int? PNoChange,
		int? PProdCfg,
		decimal? PMatlCost,
		decimal? PLbrCost,
		decimal? PFovhdCost,
		decimal? PVovhdCost,
		decimal? POutCost,
		decimal? PTotCost,
		string ItemFeatTempl,
		int? PItemSerialTracked,
		int? PItemExists,
		int? WarnIfSlowMoving = 1,
		int? ErrorIfSlowMoving = 0,
		int? WarnIfObsolete = 0,
		int? ErrorIfObsolete = 1,
		string Infobar = null,
		string Prompt = null,
		string PromptButtons = null,
		string Site = null);
	}
}

