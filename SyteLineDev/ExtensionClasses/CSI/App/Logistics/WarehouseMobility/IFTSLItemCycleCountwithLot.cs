//PROJECT NAME: Logistics
//CLASS NAME: IFTSLItemCycleCountwithLot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLItemCycleCountwithLot
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FTSLItemCycleCountwithLotSp(
			string Whse,
			string Item,
			string UnCount,
			string Loc,
			string Lot);
	}
}

