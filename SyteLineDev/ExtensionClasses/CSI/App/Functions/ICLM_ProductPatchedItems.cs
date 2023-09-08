//PROJECT NAME: Data
//CLASS NAME: ICLM_ProductPatchedItems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_ProductPatchedItems
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ProductPatchedItemsSp(
			string DatabaseName = null,
			string FilterString = null);
	}
}

