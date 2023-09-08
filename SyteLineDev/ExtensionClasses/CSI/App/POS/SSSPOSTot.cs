//PROJECT NAME: POS
//CLASS NAME: SSSPOSTot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSTot : ISSSPOSTot
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSTot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string Infobar)
		{
			StringType _CalcType = CalcType;
			POSMNumType _PosNum = PosNum;
			CoNumType _CONum = CONum;
			AmountType _p_total_price = p_total_price;
			AmountType _p_sales_tax1 = p_sales_tax1;
			AmountType _p_sales_tax2 = p_sales_tax2;
			AmountType _p_disc_amt = p_disc_amt;
			AmountType _p_Freight = p_Freight;
			AmountType _p_Misc_Charges = p_Misc_Charges;
			AmountType _p_Prepaid_Amt = p_Prepaid_Amt;
			AmountType _p_total_billed = p_total_billed;
			AmountType _p_total_paid = p_total_paid;
			AmountType _p_total_ordered = p_total_ordered;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSTotSp";
				
				appDB.AddCommandParameter(cmd, "CalcType", _CalcType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PosNum", _PosNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CONum", _CONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "p_total_price", _p_total_price, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_sales_tax1", _p_sales_tax1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_sales_tax2", _p_sales_tax2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_disc_amt", _p_disc_amt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_Freight", _p_Freight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_Misc_Charges", _p_Misc_Charges, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_Prepaid_Amt", _p_Prepaid_Amt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_total_billed", _p_total_billed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_total_paid", _p_total_paid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "p_total_ordered", _p_total_ordered, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				p_total_price = _p_total_price;
				p_sales_tax1 = _p_sales_tax1;
				p_sales_tax2 = _p_sales_tax2;
				p_disc_amt = _p_disc_amt;
				p_Freight = _p_Freight;
				p_Misc_Charges = _p_Misc_Charges;
				p_Prepaid_Amt = _p_Prepaid_Amt;
				p_total_billed = _p_total_billed;
				p_total_paid = _p_total_paid;
				p_total_ordered = _p_total_ordered;
				Infobar = _Infobar;
				
				return (Severity, p_total_price, p_sales_tax1, p_sales_tax2, p_disc_amt, p_Freight, p_Misc_Charges, p_Prepaid_Amt, p_total_billed, p_total_paid, p_total_ordered, Infobar);
			}
		}
	}
}
