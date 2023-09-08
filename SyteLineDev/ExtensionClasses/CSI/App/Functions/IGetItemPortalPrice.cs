//PROJECT NAME: Data
//CLASS NAME: IGetItemPortalPrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetItemPortalPrice
	{
		Guid? GetItemPortalPriceFn(
			string Item,
			string CustNum,
			string PricingSite);
	}
}

