//PROJECT NAME: Logistics
//CLASS NAME: IFTSLItemCountVerify.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLItemCountVerify
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FTSLItemCountVerifySp(string Whse,
		string Mismatch,
		string Serial,
		string Lot);
	}
}

