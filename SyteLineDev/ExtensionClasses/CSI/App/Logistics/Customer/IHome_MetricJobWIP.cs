//PROJECT NAME: Logistics
//CLASS NAME: IHome_MetricJobWIP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_MetricJobWIP
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Home_MetricJobWIPSp(
			int? Count = 5);
	}
}

