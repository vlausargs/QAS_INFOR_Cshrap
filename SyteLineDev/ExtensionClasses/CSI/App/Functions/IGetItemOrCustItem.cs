//PROJECT NAME: Data
//CLASS NAME: IGetItemOrCustItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetItemOrCustItem
	{
		string GetItemOrCustItemFn(
			string CustItem,
			string Item);
	}
}

