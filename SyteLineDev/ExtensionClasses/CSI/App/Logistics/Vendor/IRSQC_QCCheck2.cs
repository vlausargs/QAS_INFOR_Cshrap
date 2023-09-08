//PROJECT NAME: Logistics
//CLASS NAME: IRSQC_QCCheck2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IRSQC_QCCheck2
	{
		(int? ReturnCode, string o_Loc,
		int? o_IsQC,
		int? o_IsCertified,
		string Infobar) RSQC_QCCheck2Sp(string i_PoNum,
		int? i_PoLine,
		string i_PoRelease,
		decimal? i_Qty,
		string i_Loc,
		string i_Lot,
		int? i_Seq,
		string i_Whse,
		string o_Loc,
		int? o_IsQC,
		int? o_IsCertified,
		string Infobar);
	}
}

