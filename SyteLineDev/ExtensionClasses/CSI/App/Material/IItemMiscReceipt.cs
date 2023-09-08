//PROJECT NAME: Material
//CLASS NAME: IItemMiscReceipt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemMiscReceipt
	{
		(int? ReturnCode, string Infobar) ItemMiscReceiptSp(string P_Item,
		string P_Whse,
		decimal? P_Qty,
		string P_UM,
		decimal? P_MatlCost,
		decimal? P_LbrCost,
		decimal? P_FovhdCost,
		decimal? P_VovhdCost,
		decimal? P_OutCost,
		decimal? P_UnitCost,
		string P_Loc,
		string P_Lot,
		string P_Reason,
		string P_Acct,
		string P_AcctUnit1,
		string P_AcctUnit2,
		string P_AcctUnit3,
		string P_AcctUnit4,
		DateTime? P_TransDate,
		string Infobar,
		string DocumentNum = null,
		string P_ImportDocId = null,
		string ContainerNum = null,
		string UMVendNum = null,
		string UMArea = null);
	}
}

