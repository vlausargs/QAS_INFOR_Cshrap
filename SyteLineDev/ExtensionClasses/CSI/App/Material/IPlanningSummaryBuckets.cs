//PROJECT NAME: Material
//CLASS NAME: IPlanningSummaryBuckets.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPlanningSummaryBuckets
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PlanningSummaryBucketsSp(string Item,
		string FilterString = null);
	}
}

