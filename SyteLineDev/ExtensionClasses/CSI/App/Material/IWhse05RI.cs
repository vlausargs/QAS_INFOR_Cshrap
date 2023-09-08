//PROJECT NAME: Material
//CLASS NAME: IWhse05RI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IWhse05RI
	{
		(int? ReturnCode,
			decimal? ItemlifoQty,
			Guid? ItemlifoRowPointer,
			decimal? ItemlifoUnitCost,
			decimal? TcAmtExtCost,
			decimal? TcCprUnitCost,
			decimal? TcQttTotTrans,
			decimal? TcQtuQtyOnHand,
			decimal? TcTotCost,
			decimal? TcTotLocCost,
			decimal? TcTotWhseCost,
			decimal? TQtyMove,
			decimal? TQtyRem,
			int? NextRank,
			string Infobar) Whse05RISp(
			decimal? FileQtyOnHand,
			decimal? FileUnitCost,
			int? CurrencyPlaces,
			string ItemCostMethod,
			int? ItemLotTracked,
			decimal? ItemUnitCost,
			string ItemLocWhse,
			string ItemLocItem,
			string ItemLocLoc,
			string XItemlocWhse,
			string XItemlocLoc,
			string Lot,
			int? ItemSerialTracked,
			string ItemCostType,
			string ItemlocInvAcct,
			string ItemlocLbrAcct,
			string ItemlocFovhdAcct,
			string ItemlocVovhdAcct,
			string ItemlocOutAcct,
			decimal? ItemlifoQty,
			Guid? ItemlifoRowPointer,
			decimal? ItemlifoUnitCost,
			decimal? TcAmtExtCost,
			decimal? TcCprUnitCost,
			decimal? TcQttTotTrans,
			decimal? TcQtuQtyOnHand,
			decimal? TcTotCost,
			decimal? TcTotLocCost,
			decimal? TcTotWhseCost,
			decimal? TQtyMove,
			decimal? TQtyRem,
			int? NextRank,
			string Infobar,
			DateTime? Today = null,
			Guid? SessionId = null);
	}
}

