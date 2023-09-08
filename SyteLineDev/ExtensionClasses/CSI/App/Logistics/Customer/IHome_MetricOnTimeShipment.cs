//PROJECT NAME: Logistics
//CLASS NAME: IHome_MetricOnTimeShipment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_MetricOnTimeShipment
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Home_MetricOnTimeShipmentSp(
			int? Count = 4,
			int? MultipleSites = 0,
			string SiteGroup = null);
	}
}

