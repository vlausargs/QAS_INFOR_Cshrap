//PROJECT NAME: Data
//CLASS NAME: IGetItemOrVendItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetItemOrVendItem
	{
		string GetItemOrVendItemFn(
			string VendItem,
			string Item);
	}
}

