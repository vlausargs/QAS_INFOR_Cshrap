//PROJECT NAME: Production
//CLASS NAME: IApsPrecisionQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPrecisionQty
	{
		decimal? ApsPrecisionQtyFn(
			decimal? pQty,
			int? pPrecision,
			int? pUpFlag);
	}
}

