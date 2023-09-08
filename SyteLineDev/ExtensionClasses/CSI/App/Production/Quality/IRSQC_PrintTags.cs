//PROJECT NAME: Production
//CLASS NAME: IRSQC_PrintTags.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_PrintTags
	{
		int? RSQC_PrintTagssp(int? i_rcvrnum,
		string i_item,
		string i_itmdesc,
		string i_reftype,
		string i_entity,
		string i_entityname,
		string i_insp,
		string i_inspname,
		DateTime? i_inspdate,
		string i_refnum,
		int? i_refline,
		int? i_refrel,
		decimal? i_acceptqty,
		string i_a_reason,
		string i_a_reason_descr,
		string i_a_dcode,
		string i_a_dcode_descr,
		int? i_accepttags,
		int? i_acceptnum,
		decimal? i_rejectqty,
		string i_r_reason,
		string i_r_reason_descr,
		string i_r_dcode,
		string i_r_dcode_descr,
		string i_r_cause,
		string i_r_cause_descr,
		int? i_rejecttags,
		int? i_rejectnum,
		decimal? i_holdqty,
		string i_h_reason,
		string i_h_reason_descr,
		int? i_holdtags,
		int? i_holdnum,
		string i_lot,
		string i_psnum,
		string i_wcdescr);
	}
}

