//PROJECT NAME: Data
//CLASS NAME: IGetJobPlanCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetJobPlanCost
	{
		ICollectionLoadResponse GetJobPlanCostFn(
			string Job,
			int? Suffix);
	}
}

