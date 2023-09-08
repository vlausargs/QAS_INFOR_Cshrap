//PROJECT NAME: Data
//CLASS NAME: IGetJobPlanMatlCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetJobPlanMatlCost
	{
		decimal? GetJobPlanMatlCostFn(
			string Job,
			int? Suffix);
	}
}

