//PROJECT NAME: Data
//CLASS NAME: IGetJobPlanFOvhdCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetJobPlanFOvhdCost
	{
		decimal? GetJobPlanFOvhdCostFn(
			string Job,
			int? Suffix);
	}
}

