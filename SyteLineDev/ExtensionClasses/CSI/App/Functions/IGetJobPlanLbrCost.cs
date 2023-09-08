//PROJECT NAME: Data
//CLASS NAME: IGetJobPlanLbrCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetJobPlanLbrCost
	{
		decimal? GetJobPlanLbrCostFn(
			string Job,
			int? Suffix);
	}
}

