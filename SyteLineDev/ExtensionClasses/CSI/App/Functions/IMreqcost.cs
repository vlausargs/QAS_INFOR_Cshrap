//PROJECT NAME: Data
//CLASS NAME: IMreqcost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMreqcost
	{
		(int? ReturnCode,
			decimal? MatlCost,
			decimal? LaborCost,
			decimal? OtherCost,
			decimal? OvhCost,
			decimal? GaCost,
			decimal? TTotCost) MreqcostSp(
			string IProjNum,
			string IMsNum,
			int? CalcAct,
			decimal? MatlCost,
			decimal? LaborCost,
			decimal? OtherCost,
			decimal? OvhCost,
			decimal? GaCost,
			decimal? TTotCost);
	}
}

