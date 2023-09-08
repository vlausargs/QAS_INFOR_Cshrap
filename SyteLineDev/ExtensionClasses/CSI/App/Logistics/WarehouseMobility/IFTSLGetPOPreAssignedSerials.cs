//PROJECT NAME: Logistics
//CLASS NAME: IFTSLGetPOPreAssignedSerials.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLGetPOPreAssignedSerials
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) FTSLGetPOPreAssignedSerialsSp(string Item,
		string Whse,
		string Loc,
		string Lot,
		string InPutSerials,
		string InfoBar);
	}
}

