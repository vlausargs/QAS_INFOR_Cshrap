//PROJECT NAME: Material
//CLASS NAME: ICLM_GetItemsForPOBuilderItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_GetItemsForPOBuilderItem
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetItemsForPOBuilderItemSp(string Item = null,
		string SiteRef = null,
		string Infobar = null);
	}
}

