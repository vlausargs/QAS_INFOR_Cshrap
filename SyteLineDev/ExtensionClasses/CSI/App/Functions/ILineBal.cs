//PROJECT NAME: Data
//CLASS NAME: ILineBalSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILineBal
	{
		decimal? LineBalSp(
			decimal? QtyOrdered,
			decimal? QtyInvoiced,
			decimal? QtyReturned,
			decimal? Price,
			decimal? Disc,
			decimal? PrgBillTot,
			decimal? PrgBillApp,
			int? Places);
	}
}

