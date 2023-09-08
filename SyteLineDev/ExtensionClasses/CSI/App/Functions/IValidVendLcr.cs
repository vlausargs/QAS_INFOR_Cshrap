//PROJECT NAME: Data
//CLASS NAME: IValidVendLcr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValidVendLcr
	{
		(int? ReturnCode,
			string Infobar) ValidVendLcrSp(
			string PoNum,
			string VendLcrNum,
			string VendNum,
			decimal? ExchangeRate,
			decimal? MiscCharges,
			decimal? MChargesT,
			decimal? SalesTax,
			decimal? SalesTaxT,
			decimal? SalesTax2,
			decimal? SalesTaxT2,
			decimal? Freight,
			decimal? FreightT,
			string Infobar);
	}
}

