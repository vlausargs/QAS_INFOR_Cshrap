//PROJECT NAME: Production
//CLASS NAME: IRSQC_XRefVoucher.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_XRefVoucher
	{
		(int? ReturnCode, int? o_voucher,
		string Infobar) RSQC_XRefVoucherSp(int? i_vrma,
		string i_vend_num_orig,
		DateTime? i_dist_date,
		DateTime? i_inv_date,
		decimal? i_purch_amt,
		decimal? i_misc_charges,
		decimal? i_freight,
		decimal? i_inv_amt,
		decimal? i_vrma_pend,
		int? o_voucher,
		string Infobar);
	}
}

