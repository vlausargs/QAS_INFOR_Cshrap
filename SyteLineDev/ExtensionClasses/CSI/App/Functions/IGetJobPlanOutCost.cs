//PROJECT NAME: Data
//CLASS NAME: IGetJobPlanOutCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetJobPlanOutCost
	{
		decimal? GetJobPlanOutCostFn(
			string Job,
			int? Suffix);
	}
}

