//PROJECT NAME: Logistics
//CLASS NAME: ICoitemCalcTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoitemCalcTax
	{
		(int? ReturnCode,
			decimal? CoSalesTax,
			decimal? CoSalesTax2,
			string Infobar) CoitemCalcTaxSp(
			string PCoNum,
			int? PCoLine,
			int? PCoRelease,
			string CoitemShipSite,
			string CoitemUM,
			string CoitemItem,
			decimal? CoitemPriceConv,
			decimal? CoitemPrice,
			decimal? CoitemQtyOrderedConv,
			decimal? CoitemQtyOrdered,
			decimal? CoitemDisc,
			decimal? CoitemQtyInvoiced,
			decimal? CoitemQtyShipped,
			decimal? CoitemPrgBillTot,
			decimal? CoitemPrgBillApp,
			string CoitemTaxCode1,
			string CoitemTaxCode2,
			decimal? CoSalesTax,
			decimal? CoSalesTax2,
			string Infobar);
	}
}

