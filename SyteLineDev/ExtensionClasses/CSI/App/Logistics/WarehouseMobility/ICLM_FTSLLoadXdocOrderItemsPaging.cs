//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLLoadXdocOrderItemsPaging.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLLoadXdocOrderItemsPaging
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLLoadXdocOrderItemsPagingSp(string Item,
		string Whse,
		string Job);
	}
}

