//PROJECT NAME: POS
//CLASS NAME: ISSSPOSGetTaxEcInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSGetTaxEcInfo
	{
		(int? ReturnCode,
			string p_tax_code1,
			string p_tax_code2,
			string p_trans_nat,
			string p_delterm,
			string p_process_ind,
			decimal? p_use_exch_rate,
			string p_curr_code,
			string Infobar) SSSPOSGetTaxEcInfoSp(
			string p_cust_num,
			int? p_cust_seq,
			string p_tax_code1,
			string p_tax_code2,
			string p_trans_nat,
			string p_delterm,
			string p_process_ind,
			decimal? p_use_exch_rate,
			string p_curr_code,
			string Infobar);
	}
}

