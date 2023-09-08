//PROJECT NAME: Data
//CLASS NAME: ICLM_GetItemUMConvs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_GetItemUMConvs
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetItemUMConvsSp(
			string Item);
	}
}

