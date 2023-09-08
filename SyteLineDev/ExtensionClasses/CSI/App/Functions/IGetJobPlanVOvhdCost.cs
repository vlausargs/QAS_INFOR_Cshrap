//PROJECT NAME: Data
//CLASS NAME: IGetJobPlanVOvhdCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetJobPlanVOvhdCost
	{
		decimal? GetJobPlanVOvhdCostFn(
			string Job,
			int? Suffix);
	}
}

