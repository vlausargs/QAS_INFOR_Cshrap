//PROJECT NAME: Data
//CLASS NAME: IGetCoitemLinePrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetCoitemLinePrice
	{
		(int? ReturnCode,
			decimal? CoitemLinePrice,
			string Infobar,
			decimal? LineTaxAmount) GetCoitemLinePriceSp(
			string PCoNum,
			decimal? CoitemPrice,
			decimal? CoitemDisc,
			decimal? CoitemQtyOrdered,
			decimal? CoitemLbrCost,
			decimal? CoitemMatlCost,
			decimal? CoitemFovhdCost,
			decimal? CoitemVovhdCost,
			decimal? CoitemOutCost,
			decimal? CoitemQtyInvoiced,
			decimal? CoitemQtyShipped,
			decimal? CoitemPrgBillTot,
			decimal? CoitemPrgBillApp,
			int? CoitemCoLine,
			int? CoitemCoRelease,
			string CoitemItem,
			string CoitemTaxCode1,
			string CoitemTaxCode2,
			decimal? CoitemLinePrice,
			string Infobar,
			decimal? LineTaxAmount = null,
			Guid? CoitemRowPointer = null);
	}
}

