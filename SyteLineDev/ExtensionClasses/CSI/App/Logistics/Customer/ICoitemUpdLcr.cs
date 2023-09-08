//PROJECT NAME: Logistics
//CLASS NAME: ICoitemUpdLcr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoitemUpdLcr
	{
		(int? ReturnCode,
			string Infobar) CoitemUpdLcrSp(
			string PCoNum,
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
			int? PAddAccum,
			DateTime? PDueDate,
			string Infobar);
	}
}

