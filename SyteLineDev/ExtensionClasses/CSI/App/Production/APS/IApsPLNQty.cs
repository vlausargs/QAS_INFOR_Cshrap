//PROJECT NAME: Production
//CLASS NAME: IApsPLNQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPLNQty
	{
		decimal? ApsPLNQtyFn(
			decimal? pSupplyQty,
			int? pPrecision,
			int? pShrinkFlag,
			decimal? pShrinkFact,
			decimal? pOrderMin,
			decimal? pOrderMult);
	}
}

