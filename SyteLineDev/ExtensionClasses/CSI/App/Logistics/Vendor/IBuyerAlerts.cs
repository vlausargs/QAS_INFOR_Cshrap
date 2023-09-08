//PROJECT NAME: Logistics
//CLASS NAME: IBuyerAlerts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IBuyerAlerts
	{
		(int? ReturnCode,
		int? OverDuePOLines,
		int? OverDuePOReleases,
		int? NumberOfUserTasks,
		int? NumberOfEventMessages) BuyerAlertsSp(
			int? OverDuePOLines,
			int? OverDuePOReleases,
			int? NumberOfUserTasks,
			int? NumberOfEventMessages);
	}
}

