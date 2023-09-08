//PROJECT NAME: Logistics
//CLASS NAME: IHome_MetricDPO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_MetricDPO
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Home_MetricDPOSp(
			int? MultipleSites = 0,
			string SiteGroup = null,
			int? NumPeriods = 6);
	}
}

