//PROJECT NAME: Production
//CLASS NAME: IApsBomPrtQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsBomPrtQty
	{
		decimal? ApsBomPrtQtyFn(
			string Job,
			int? Suffix,
			int? OperNum,
			decimal? QtyReleased,
			decimal? QtyIssued,
			string Units,
			decimal? MatlQty,
			int? Precision);
	}
}

