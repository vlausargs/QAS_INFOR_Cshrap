//PROJECT NAME: Logistics
//CLASS NAME: ICoItemSumJobOperCosts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoItemSumJobOperCosts
	{
		(int? ReturnCode,
			decimal? SetupCost,
			decimal? RunCost,
			decimal? FixOvhdCost,
			decimal? VarOvhdCost,
			decimal? OutSideCost,
			string InfoBar) CoItemSumJobOperCostsSp(
			string CoNum,
			int? CoLine,
			decimal? ProdCycles,
			decimal? SetupCost,
			decimal? RunCost,
			decimal? FixOvhdCost,
			decimal? VarOvhdCost,
			decimal? OutSideCost,
			string InfoBar);
	}
}

