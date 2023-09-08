//PROJECT NAME: Data
//CLASS NAME: IGetCoItemTotals.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetCoItemTotals
	{
		(int? ReturnCode,
			decimal? QtyOrderedConv,
			decimal? QtyShippedConv,
			decimal? QtyRsvdConv,
			decimal? QtyInvoicedConv,
			decimal? QtyReturnedConv,
			string Infobar) GetCoItemTotalsSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			decimal? QtyOrderedConv,
			decimal? QtyShippedConv,
			decimal? QtyRsvdConv,
			decimal? QtyInvoicedConv,
			decimal? QtyReturnedConv,
			string Infobar,
			string Site = null);
	}
}

