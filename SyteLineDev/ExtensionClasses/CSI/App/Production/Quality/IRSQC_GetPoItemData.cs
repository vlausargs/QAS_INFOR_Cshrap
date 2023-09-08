//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetPoItemData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetPoItemData
	{
		(int? ReturnCode, decimal? o_item_cost,
		decimal? o_plan_cost,
		decimal? o_unit_mat_cost,
		decimal? o_item_cost_conv,
		decimal? o_plan_cost_conv,
		decimal? o_unit_mat_cost_conv,
		string Infobar) RSQC_GetPoItemDataSp(int? i_rcvr,
		string i_po_num,
		int? i_po_line,
		int? i_po_release,
		decimal? o_item_cost,
		decimal? o_plan_cost,
		decimal? o_unit_mat_cost,
		decimal? o_item_cost_conv,
		decimal? o_plan_cost_conv,
		decimal? o_unit_mat_cost_conv,
		string Infobar);
	}
}

