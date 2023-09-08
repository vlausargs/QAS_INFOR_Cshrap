//PROJECT NAME: Logistics
//CLASS NAME: IHome_POFundsCommitted.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_POFundsCommitted
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_POFundsCommittedSp(string FilterString = null,
		string POStatus = null,
		string SiteGroup = null);
	}
}

