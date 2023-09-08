//PROJECT NAME: Logistics
//CLASS NAME: IHome_VchPay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_VchPay
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Home_VchPaySp(
			string FilterString = null,
			DateTime? CutoffDate = null,
			string SiteGroup = null);
	}
}

