//PROJECT NAME: Logistics
//CLASS NAME: GetDefaultAPTaxAdjust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetDefaultAPTaxAdjust : IGetDefaultAPTaxAdjust
	{
		readonly IApplicationDB appDB;
		
		
		public GetDefaultAPTaxAdjust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? DfltTax1Val,
		decimal? DfltTax2Val) GetDefaultAPTaxAdjustSp(int? Voucher,
		decimal? DisAmt,
		decimal? DfltTax1Val,
		decimal? DfltTax2Val)
		{
			VoucherType _Voucher = Voucher;
			AmountType _DisAmt = DisAmt;
			AmountType _DfltTax1Val = DfltTax1Val;
			AmountType _DfltTax2Val = DfltTax2Val;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetDefaultAPTaxAdjustSp";
				
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisAmt", _DisAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DfltTax1Val", _DfltTax1Val, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DfltTax2Val", _DfltTax2Val, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DfltTax1Val = _DfltTax1Val;
				DfltTax2Val = _DfltTax2Val;
				
				return (Severity, DfltTax1Val, DfltTax2Val);
			}
		}
	}
}
