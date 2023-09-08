//PROJECT NAME: Data
//CLASS NAME: IFloorStkReplenCel06L2I.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFloorStkReplenCel06L2I
	{
		(int? ReturnCode,
			string InfobarType) FloorStkReplenCel06L2ISp(
			string pJobType,
			decimal? pJobQtyReleased,
			decimal? pJobrouteQtyComplete,
			string pJobmatlUnits,
			decimal? pJobmatlQtyIssued,
			string pJobmatlItem,
			decimal? pJobmatlMatlQty,
			decimal? pJobmatlScrapFact,
			string pItemlocWhse,
			string pItemlocLoc,
			decimal? pItemlocQtyOnHand,
			decimal? pItemlocQtyRsvd,
			int? pSubtractFlrQty,
			string InfobarType);
	}
}

