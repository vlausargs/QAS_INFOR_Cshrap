//PROJECT NAME: Material
//CLASS NAME: IGetItemsPriceForCustItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetItemsPriceForCustItem
	{
		(ICollectionLoadResponse Data, int? ReturnCode) GetItemsPriceForCustItemSp(string CustItem = null,
		string CustNum = null,
		string Item = null,
		string SiteRef = null,
		string Infobar = null);
	}
}

