//PROJECT NAME: Data
//CLASS NAME: IPickItemByLocLot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPickItemByLocLot
	{
		int? PickItemByLocLotSp(
			string KitItem,
			string KitComponent,
			decimal? KitCompReqdQty,
			decimal? KitCompIssuedQty,
			string Whse,
			int? PrintSecondaryLocation = null);
	}
}

