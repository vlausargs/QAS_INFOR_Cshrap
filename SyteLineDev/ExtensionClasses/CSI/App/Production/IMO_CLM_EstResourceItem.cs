//PROJECT NAME: Production
//CLASS NAME: IMO_CLM_EstResourceItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IMO_CLM_EstResourceItem
	{
		(ICollectionLoadResponse Data, int? ReturnCode) MO_CLM_EstResourceItemSp(string selectedResource = null,
		int? productCycle = 0);
	}
}

