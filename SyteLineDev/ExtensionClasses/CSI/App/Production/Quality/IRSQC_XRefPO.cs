//PROJECT NAME: Production
//CLASS NAME: IRSQC_XRefPO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_XRefPO
	{
		(int? ReturnCode, string o_ref_num,
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
		string Infobar);
	}
}

