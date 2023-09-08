//PROJECT NAME: Finance
//CLASS NAME: IAptrxpValidateTaxes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AP
{
	public interface IAptrxpValidateTaxes
	{
		(int? ReturnCode,
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
			string Infobar);
	}
}

