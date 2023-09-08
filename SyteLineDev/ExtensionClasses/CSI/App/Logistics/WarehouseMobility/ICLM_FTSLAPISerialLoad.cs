//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLAPISerialLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLAPISerialLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLAPISerialLoadSp(string TransNum,
		string Item,
		string Whse,
		string Loc,
		string Lot,
		string Site,
		string ERPQueryResponseString);
	}
}

