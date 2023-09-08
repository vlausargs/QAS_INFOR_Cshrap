//PROJECT NAME: Finance
//CLASS NAME: AptrxpValidateTaxes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AP
{
	public class AptrxpValidateTaxes : IAptrxpValidateTaxes
	{
		readonly IApplicationDB appDB;
		
		public AptrxpValidateTaxes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) AptrxpValidateTaxesSp(
			decimal? TaxBal,
			int? CurrencyPlaces,
			decimal? SalesTax,
			string VendNum,
			int? Voucher,
			decimal? TaxBal2,
			decimal? SalesTax2,
			decimal? TotCr,
			decimal? InvAmt,
			string Infobar)
		{
			AmountType _TaxBal = TaxBal;
			DecimalPlacesType _CurrencyPlaces = CurrencyPlaces;
			AmountType _SalesTax = SalesTax;
			VendNumType _VendNum = VendNum;
			VoucherType _Voucher = Voucher;
			AmountType _TaxBal2 = TaxBal2;
			AmountType _SalesTax2 = SalesTax2;
			AmountType _TotCr = TotCr;
			AmountType _InvAmt = InvAmt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AptrxpValidateTaxesSp";
				
				appDB.AddCommandParameter(cmd, "TaxBal", _TaxBal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrencyPlaces", _CurrencyPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTax", _SalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxBal2", _TaxBal2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTax2", _SalesTax2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TotCr", _TotCr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvAmt", _InvAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
