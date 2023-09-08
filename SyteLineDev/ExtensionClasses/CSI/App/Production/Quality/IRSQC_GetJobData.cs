//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetJobData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetJobData
	{
		(int? ReturnCode, string o_ref_type,
		string o_ref_num,
		int? o_ref_line_suf,
		int? o_ref_release,
		string o_description,
		decimal? o_item_cost_conv,
		string o_um,
		int? o_po_line,
		int? o_po_release,
		string o_accept_to_jobtran,
		string Infobar) RSQC_GetJobDataSp(int? i_rcvr,
		string o_ref_type,
		string o_ref_num,
		int? o_ref_line_suf,
		int? o_ref_release,
		string o_description,
		decimal? o_item_cost_conv,
		string o_um,
		int? o_po_line,
		int? o_po_release,
		string o_accept_to_jobtran,
		string Infobar);
	}
}

