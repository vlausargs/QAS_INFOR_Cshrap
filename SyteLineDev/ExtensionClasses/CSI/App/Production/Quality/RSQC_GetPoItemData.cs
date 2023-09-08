//PROJECT NAME: Production
//CLASS NAME: RSQC_GetPoItemData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetPoItemData : IRSQC_GetPoItemData
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetPoItemData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? o_item_cost,
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
		string Infobar)
		{
			QCRcvrNumType _i_rcvr = i_rcvr;
			PoNumType _i_po_num = i_po_num;
			PoLineType _i_po_line = i_po_line;
			PoReleaseType _i_po_release = i_po_release;
			CostPrcType _o_item_cost = o_item_cost;
			CostPrcType _o_plan_cost = o_plan_cost;
			CostPrcType _o_unit_mat_cost = o_unit_mat_cost;
			CostPrcType _o_item_cost_conv = o_item_cost_conv;
			CostPrcType _o_plan_cost_conv = o_plan_cost_conv;
			CostPrcType _o_unit_mat_cost_conv = o_unit_mat_cost_conv;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetPoItemDataSp";
				
				appDB.AddCommandParameter(cmd, "i_rcvr", _i_rcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_po_num", _i_po_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_po_line", _i_po_line, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_po_release", _i_po_release, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_item_cost", _o_item_cost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_plan_cost", _o_plan_cost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_unit_mat_cost", _o_unit_mat_cost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_item_cost_conv", _o_item_cost_conv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_plan_cost_conv", _o_plan_cost_conv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_unit_mat_cost_conv", _o_unit_mat_cost_conv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_item_cost = _o_item_cost;
				o_plan_cost = _o_plan_cost;
				o_unit_mat_cost = _o_unit_mat_cost;
				o_item_cost_conv = _o_item_cost_conv;
				o_plan_cost_conv = _o_plan_cost_conv;
				o_unit_mat_cost_conv = _o_unit_mat_cost_conv;
				Infobar = _Infobar;
				
				return (Severity, o_item_cost, o_plan_cost, o_unit_mat_cost, o_item_cost_conv, o_plan_cost_conv, o_unit_mat_cost_conv, Infobar);
			}
		}
	}
}
