//PROJECT NAME: POS
//CLASS NAME: ISSSPOSTot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSTot
	{
		(int? ReturnCode,
			decimal? p_total_price,
			decimal? p_sales_tax1,
			decimal? p_sales_tax2,
			decimal? p_disc_amt,
			decimal? p_Freight,
			decimal? p_Misc_Charges,
			decimal? p_Prepaid_Amt,
			decimal? p_total_billed,
			decimal? p_total_paid,
			decimal? p_total_ordered,
			string Infobar) SSSPOSTotSp(
			string CalcType,
			string PosNum,
			string CONum,
			decimal? p_total_price,
			decimal? p_sales_tax1,
			decimal? p_sales_tax2,
			decimal? p_disc_amt,
			decimal? p_Freight,
			decimal? p_Misc_Charges,
			decimal? p_Prepaid_Amt,
			decimal? p_total_billed,
			decimal? p_total_paid,
			decimal? p_total_ordered,
			string Infobar);
	}
}

