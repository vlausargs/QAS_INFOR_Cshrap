//PROJECT NAME: Material
//CLASS NAME: IItemPortalPrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemPortalPrice
	{
		(int? ReturnCode, string Infobar) ItemPortalPriceSp(string StartingItem,
		string EndingItem,
		string Infobar = null,
		int? BGTaskID = null);
	}
}

