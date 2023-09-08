//PROJECT NAME: Logistics
//CLASS NAME: ICoitemLcrTotval.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoitemLcrTotval
	{
		(int? ReturnCode,
			decimal? RetCoPrice,
			string Infobar,
			decimal? RetShipPrice) CoitemLcrTotvalSp(
			string LcrNum,
			string CoNum,
			int? CoLine,
			int? CoRelease,
			decimal? ItemPrice,
			decimal? ItemDisc,
			decimal? QtyOrdered,
			decimal? QtyInvoiced,
			decimal? QtyReturned,
			decimal? QtyShipped,
			string CoItem,
			string CoitemTaxCode1,
			string CoitemTaxCode2,
			string ShipSite,
			string FromCurrCode,
			string ToCurrCode,
			decimal? RetCoPrice,
			string Infobar,
			int? NeedShipPrice = 0,
			decimal? RetShipPrice = 0);
	}
}

