//PROJECT NAME: Material
//CLASS NAME: IHome_MetricCycleCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IHome_MetricCycleCount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_MetricCycleCountSp();
	}
}

