//PROJECT NAME: Production
//CLASS NAME: RSQC_XRefPO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_XRefPO : IRSQC_XRefPO
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_XRefPO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_ref_num,
		int? o_ref_line,
		int? o_ref_rel,
		string Infobar) RSQC_XRefPOSp(string i_item,
		string i_vend_num_orig,
		decimal? i_qty_expected,
		string i_cur_whse,
		string i_ship_code,
		string i_ref_num,
		string o_ref_num,
		int? o_ref_line,
		int? o_ref_rel,
		string Infobar)
		{
			ItemType _i_item = i_item;
			VendNumType _i_vend_num_orig = i_vend_num_orig;
			QtyUnitType _i_qty_expected = i_qty_expected;
			WhseType _i_cur_whse = i_cur_whse;
			ShipCodeType _i_ship_code = i_ship_code;
			PoNumType _i_ref_num = i_ref_num;
			PoNumType _o_ref_num = o_ref_num;
			PoLineType _o_ref_line = o_ref_line;
			PoReleaseType _o_ref_rel = o_ref_rel;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_XRefPOSp";
				
				appDB.AddCommandParameter(cmd, "i_item", _i_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_vend_num_orig", _i_vend_num_orig, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_qty_expected", _i_qty_expected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_cur_whse", _i_cur_whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ship_code", _i_ship_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ref_num", _i_ref_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_ref_num", _o_ref_num, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_ref_line", _o_ref_line, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_ref_rel", _o_ref_rel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_ref_num = _o_ref_num;
				o_ref_line = _o_ref_line;
				o_ref_rel = _o_ref_rel;
				Infobar = _Infobar;
				
				return (Severity, o_ref_num, o_ref_line, o_ref_rel, Infobar);
			}
		}
	}
}
