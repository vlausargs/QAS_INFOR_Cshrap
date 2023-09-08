//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetReceiptValues.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetReceiptValues
	{
		(int? ReturnCode, decimal? o_unit_cost,
		decimal? o_matl_cost,
		decimal? o_qty_on_hand,
		string o_acct,
		string o_account_unit1,
		string o_account_unit2,
		string o_account_unit3,
		string o_account_unit4,
		int? o_SerialTracked,
		int? o_LotTracked,
		string Infobar) RSQC_GetReceiptValuesSp(string i_item,
		string i_whse,
		string i_loc,
		decimal? o_unit_cost,
		decimal? o_matl_cost,
		decimal? o_qty_on_hand,
		string o_acct,
		string o_account_unit1,
		string o_account_unit2,
		string o_account_unit3,
		string o_account_unit4,
		int? o_SerialTracked,
		int? o_LotTracked,
		string Infobar);
	}
}

