//PROJECT NAME: Logistics
//CLASS NAME: IHome_MetricPastDue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IHome_MetricPastDue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_MetricPastDueSp();
	}
}

