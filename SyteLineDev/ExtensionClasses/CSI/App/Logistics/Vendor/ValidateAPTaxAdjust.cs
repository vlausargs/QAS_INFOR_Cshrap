//PROJECT NAME: Logistics
//CLASS NAME: ValidateAPTaxAdjust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateAPTaxAdjust : IValidateAPTaxAdjust
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateAPTaxAdjust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) ValidateAPTaxAdjustSp(int? Voucher,
		decimal? DisAmt,
		int? TaxNum,
		decimal? Tax1,
		decimal? Tax2,
		string InfoBar)
		{
			VoucherType _Voucher = Voucher;
			AmountType _DisAmt = DisAmt;
			ListYesNoType _TaxNum = TaxNum;
			AmountType _Tax1 = Tax1;
			AmountType _Tax2 = Tax2;
			Infobar _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateAPTaxAdjustSp";
				
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisAmt", _DisAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxNum", _TaxNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Tax1", _Tax1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Tax2", _Tax2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
