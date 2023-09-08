//PROJECT NAME: Logistics
//CLASS NAME: IHome_MetricItemShortage.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_MetricItemShortage
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_MetricItemShortageSp(int? Count = 5);
	}
}

