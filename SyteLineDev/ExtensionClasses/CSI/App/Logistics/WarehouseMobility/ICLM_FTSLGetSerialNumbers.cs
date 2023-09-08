//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLGetSerialNumbers.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLGetSerialNumbers
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetSerialNumbersSp(Guid? SessionID,
		string Job = null,
		int? Suffix = 0,
		string TransactionType = null,
		string Item = null,
		string Whse = null,
		string Loc = null,
		string Lot = null,
		string Site = null);
	}
}

