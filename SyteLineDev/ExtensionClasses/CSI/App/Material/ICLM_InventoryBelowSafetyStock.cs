//PROJECT NAME: Material
//CLASS NAME: ICLM_InventoryBelowSafetyStock.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_InventoryBelowSafetyStock
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_InventoryBelowSafetyStockSp(string PMTCodes = "",
		string PlanCode = null,
		string FilterString = null,
		string PSiteGroup = null);
	}
}

