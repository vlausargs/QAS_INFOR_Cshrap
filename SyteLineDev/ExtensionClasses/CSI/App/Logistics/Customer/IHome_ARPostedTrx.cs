//PROJECT NAME: Logistics
//CLASS NAME: IHome_ARPostedTrx.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_ARPostedTrx
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_ARPostedTrxSp(string FilterString = null,
		DateTime? CutoffDate = null,
		string SiteGroup = null);
	}
}

