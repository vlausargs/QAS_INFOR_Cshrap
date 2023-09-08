//PROJECT NAME: Logistics
//CLASS NAME: IHome_Accounts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_Accounts
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_AccountsSp(string FilterString = null,
			DateTime? StartDate = null,
			DateTime? EndDate = null,
			string SiteGroup = null);
	}
}

