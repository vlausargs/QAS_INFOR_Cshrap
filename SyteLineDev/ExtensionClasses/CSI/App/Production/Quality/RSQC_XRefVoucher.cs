//PROJECT NAME: Production
//CLASS NAME: RSQC_XRefVoucher.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_XRefVoucher : IRSQC_XRefVoucher
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_XRefVoucher(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? o_voucher,
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
		string Infobar)
		{
			QCRcvrNumType _i_vrma = i_vrma;
			VendNumType _i_vend_num_orig = i_vend_num_orig;
			DateType _i_dist_date = i_dist_date;
			DateType _i_inv_date = i_inv_date;
			DecimalType _i_purch_amt = i_purch_amt;
			DecimalType _i_misc_charges = i_misc_charges;
			DecimalType _i_freight = i_freight;
			DecimalType _i_inv_amt = i_inv_amt;
			DecimalType _i_vrma_pend = i_vrma_pend;
			VoucherType _o_voucher = o_voucher;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_XRefVoucherSp";
				
				appDB.AddCommandParameter(cmd, "i_vrma", _i_vrma, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_vend_num_orig", _i_vend_num_orig, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_dist_date", _i_dist_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_inv_date", _i_inv_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_purch_amt", _i_purch_amt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_misc_charges", _i_misc_charges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_freight", _i_freight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_inv_amt", _i_inv_amt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_vrma_pend", _i_vrma_pend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_voucher", _o_voucher, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_voucher = _o_voucher;
				Infobar = _Infobar;
				
				return (Severity, o_voucher, Infobar);
			}
		}
	}
}
