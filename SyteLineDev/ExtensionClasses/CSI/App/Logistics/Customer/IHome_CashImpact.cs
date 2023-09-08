//PROJECT NAME: Logistics
//CLASS NAME: IHome_CashImpact.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_CashImpact
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_CashImpactSp(string FilterString = null,
		string SiteGroup = null);
	}
}

