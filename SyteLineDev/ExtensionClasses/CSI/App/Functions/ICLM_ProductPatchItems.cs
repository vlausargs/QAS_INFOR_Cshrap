//PROJECT NAME: Data
//CLASS NAME: ICLM_ProductPatchItems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_ProductPatchItems
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ProductPatchItemsSp(
			string filterString = null,
			string DatabaseName = null);
	}
}

