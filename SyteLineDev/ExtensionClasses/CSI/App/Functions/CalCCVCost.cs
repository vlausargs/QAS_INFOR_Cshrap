//PROJECT NAME: Data
//CLASS NAME: CalCCVCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CalCCVCost : ICalCCVCost
	{
		readonly IApplicationDB appDB;
		
		public CalCCVCost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string p_whse)
		{
			ItemType _p_item = p_item;
			CostPrcType _p_itm_unit_cst = p_itm_unit_cst;
			CostMethodType _p_itm_cst_meth = p_itm_cst_meth;
			CostPrcType _p_iteml_u_cost = p_iteml_u_cost;
			AcctType _p_inv_acct = p_inv_acct;
			AcctType _p_lbr_acct = p_lbr_acct;
			AcctType _p_fovhd_acct = p_fovhd_acct;
			AcctType _p_vovhd_acct = p_vovhd_acct;
			AcctType _p_out_acct = p_out_acct;
			CostTypeType _p_itm_cst_type = p_itm_cst_type;
			QtyUnitType _p_qty = p_qty;
			CostPrcType _p_tot_cost = p_tot_cost;
			WhseType _p_whse = p_whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalCCVCostSp";
				
				appDB.AddCommandParameter(cmd, "p_item", _p_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_itm_unit_cst", _p_itm_unit_cst, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_itm_cst_meth", _p_itm_cst_meth, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_iteml_u_cost", _p_iteml_u_cost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_inv_acct", _p_inv_acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_lbr_acct", _p_lbr_acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_fovhd_acct", _p_fovhd_acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_vovhd_acct", _p_vovhd_acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_out_acct", _p_out_acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_itm_cst_type", _p_itm_cst_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_qty", _p_qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_tot_cost", _p_tot_cost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_whse", _p_whse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				p_tot_cost = _p_tot_cost;
				
				return (Severity, p_tot_cost);
			}
		}
	}
}
