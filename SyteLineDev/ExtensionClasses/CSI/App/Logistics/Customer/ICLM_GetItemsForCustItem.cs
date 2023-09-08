//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GetItemsForCustItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetItemsForCustItem
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetItemsForCustItemSp(string CustItem = null,
		string CustNum = null,
		string Item = null,
		string SiteRef = null,
		string Infobar = null,
		int? RefreshList = 0);
	}
}

