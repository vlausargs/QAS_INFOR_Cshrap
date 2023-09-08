//PROJECT NAME: Logistics
//CLASS NAME: IHome_APPostedTrx.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_APPostedTrx
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_APPostedTrxSp(string FilterString = null,
		DateTime? CutoffDate = null,
		string SiteGroup = null);
	}
}

