//PROJECT NAME: Data
//CLASS NAME: ILivePortalItemBrkQtyPricesExist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILivePortalItemBrkQtyPricesExist
	{
		int? LivePortalItemBrkQtyPricesExistFn(
			string CustNum,
			string Item,
			string CurrCode);
	}
}

