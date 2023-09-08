//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLGetIssuedLots.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLGetIssuedLots
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetIssuedLotsSp(string Whse,
		string Item,
		string Location,
		int? FDALotTraceability = 0,
		string Job = null,
		int? Suffix = null,
		string Operation = null);
	}
}

