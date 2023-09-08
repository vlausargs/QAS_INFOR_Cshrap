//PROJECT NAME: POS
//CLASS NAME: SSSPOSGetTaxEcInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSGetTaxEcInfo : ISSSPOSGetTaxEcInfo
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSGetTaxEcInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string Infobar)
		{
			CustNumType _p_cust_num = p_cust_num;
			CustSeqType _p_cust_seq = p_cust_seq;
			TaxCodeType _p_tax_code1 = p_tax_code1;
			TaxCodeType _p_tax_code2 = p_tax_code2;
			TransNatType _p_trans_nat = p_trans_nat;
			DeltermType _p_delterm = p_delterm;
			ProcessIndType _p_process_ind = p_process_ind;
			ExchRateType _p_use_exch_rate = p_use_exch_rate;
			CurrCodeType _p_curr_code = p_curr_code;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSGetTaxEcInfoSp";
				
				appDB.AddCommandParameter(cmd, "p_cust_num", _p_cust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_cust_seq", _p_cust_seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_tax_code1", _p_tax_code1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_tax_code2", _p_tax_code2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_trans_nat", _p_trans_nat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_delterm", _p_delterm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_process_ind", _p_process_ind, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_use_exch_rate", _p_use_exch_rate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_curr_code", _p_curr_code, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				p_tax_code1 = _p_tax_code1;
				p_tax_code2 = _p_tax_code2;
				p_trans_nat = _p_trans_nat;
				p_delterm = _p_delterm;
				p_process_ind = _p_process_ind;
				p_use_exch_rate = _p_use_exch_rate;
				p_curr_code = _p_curr_code;
				Infobar = _Infobar;
				
				return (Severity, p_tax_code1, p_tax_code2, p_trans_nat, p_delterm, p_process_ind, p_use_exch_rate, p_curr_code, Infobar);
			}
		}
	}
}
