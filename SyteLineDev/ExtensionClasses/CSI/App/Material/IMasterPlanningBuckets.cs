//PROJECT NAME: Material
//CLASS NAME: IMasterPlanningBuckets.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMasterPlanningBuckets
	{
		(ICollectionLoadResponse Data, int? ReturnCode) MasterPlanningBucketsSp(string Item,
		string FilterString = null);
	}
}

