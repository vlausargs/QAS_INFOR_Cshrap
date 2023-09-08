//PROJECT NAME: Data
//CLASS NAME: ICalCCVCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICalCCVCost
	{
		(int? ReturnCode,
			decimal? p_tot_cost) CalCCVCostSp(
			string p_item,
			decimal? p_itm_unit_cst,
			string p_itm_cst_meth,
			decimal? p_iteml_u_cost,
			string p_inv_acct,
			string p_lbr_acct,
			string p_fovhd_acct,
			string p_vovhd_acct,
			string p_out_acct,
			string p_itm_cst_type,
			decimal? p_qty,
			decimal? p_tot_cost,
			string p_whse);
	}
}

