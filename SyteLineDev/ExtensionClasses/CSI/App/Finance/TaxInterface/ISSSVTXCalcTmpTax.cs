//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXCalcTmpTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXCalcTmpTax
	{
		(int? ReturnCode,
			decimal? oSalesTax,
			decimal? oSalesTax2,
			string Infobar) SSSVTXCalcTmpTaxSp(
			Guid? RowPointer,
			decimal? oSalesTax,
			decimal? oSalesTax2,
			string Infobar);
	}
}

