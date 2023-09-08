//PROJECT NAME: Logistics
//CLASS NAME: IHome_MetricOnTimeJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_MetricOnTimeJob
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Home_MetricOnTimeJobSp(
			int? Count = 4);
	}
}

