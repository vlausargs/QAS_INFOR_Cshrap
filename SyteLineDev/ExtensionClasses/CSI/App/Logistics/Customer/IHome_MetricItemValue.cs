//PROJECT NAME: Logistics
//CLASS NAME: IHome_MetricItemValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_MetricItemValue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_MetricItemValueSp(int? Count = 5);
	}
}

