//PROJECT NAME: Production
//CLASS NAME: IMO_CLM_ResourceItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IMO_CLM_ResourceItem
	{
		(ICollectionLoadResponse Data, int? ReturnCode) MO_CLM_ResourceItemSp(string selectedResource = null,
		int? productCycle = 0);
	}
}

