//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLGetItemsNonInventoryItems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLGetItemsNonInventoryItems
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetItemsNonInventoryItemsSp();
	}
}

