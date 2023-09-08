//PROJECT NAME: Material
//CLASS NAME: ICLM_PurchasedItems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_PurchasedItems
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_PurchasedItemsSp(
			string ItemFilter = null);
	}
}

