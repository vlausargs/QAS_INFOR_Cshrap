//PROJECT NAME: Logistics
//CLASS NAME: IFTSLItemCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLItemCount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FTSLItemCountSp(string Whse,
		string Item,
		string UnCount,
		string Loc);
	}
}

