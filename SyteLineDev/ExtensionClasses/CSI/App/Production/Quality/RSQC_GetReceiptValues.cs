//PROJECT NAME: Production
//CLASS NAME: RSQC_GetReceiptValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetReceiptValues : IRSQC_GetReceiptValues
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetReceiptValues(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? o_unit_cost,
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
		string Infobar)
		{
			ItemType _i_item = i_item;
			WhseType _i_whse = i_whse;
			LocType _i_loc = i_loc;
			CostPrcType _o_unit_cost = o_unit_cost;
			CostPrcType _o_matl_cost = o_matl_cost;
			QtyTotlType _o_qty_on_hand = o_qty_on_hand;
			AcctType _o_acct = o_acct;
			UnitCode1Type _o_account_unit1 = o_account_unit1;
			UnitCode2Type _o_account_unit2 = o_account_unit2;
			UnitCode3Type _o_account_unit3 = o_account_unit3;
			UnitCode4Type _o_account_unit4 = o_account_unit4;
			ListYesNoType _o_SerialTracked = o_SerialTracked;
			ListYesNoType _o_LotTracked = o_LotTracked;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetReceiptValuesSp";
				
				appDB.AddCommandParameter(cmd, "i_item", _i_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_whse", _i_whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_loc", _i_loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_unit_cost", _o_unit_cost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_matl_cost", _o_matl_cost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_qty_on_hand", _o_qty_on_hand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_acct", _o_acct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_account_unit1", _o_account_unit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_account_unit2", _o_account_unit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_account_unit3", _o_account_unit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_account_unit4", _o_account_unit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_SerialTracked", _o_SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_LotTracked", _o_LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_unit_cost = _o_unit_cost;
				o_matl_cost = _o_matl_cost;
				o_qty_on_hand = _o_qty_on_hand;
				o_acct = _o_acct;
				o_account_unit1 = _o_account_unit1;
				o_account_unit2 = _o_account_unit2;
				o_account_unit3 = _o_account_unit3;
				o_account_unit4 = _o_account_unit4;
				o_SerialTracked = _o_SerialTracked;
				o_LotTracked = _o_LotTracked;
				Infobar = _Infobar;
				
				return (Severity, o_unit_cost, o_matl_cost, o_qty_on_hand, o_acct, o_account_unit1, o_account_unit2, o_account_unit3, o_account_unit4, o_SerialTracked, o_LotTracked, Infobar);
			}
		}
	}
}
