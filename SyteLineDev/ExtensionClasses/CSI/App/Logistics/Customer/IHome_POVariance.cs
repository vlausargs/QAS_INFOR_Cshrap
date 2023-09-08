//PROJECT NAME: Logistics
//CLASS NAME: IHome_POVariance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_POVariance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_POVarianceSp(string FilterString = null,
		string Item = null,
		string SiteGroup = null,
		string Site = null);
	}
}

