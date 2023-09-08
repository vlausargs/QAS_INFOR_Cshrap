//PROJECT NAME: Data
//CLASS NAME: IMsCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMsCost
	{
		(int? ReturnCode,
			decimal? OActMatlCost,
			decimal? OActLaborCost,
			decimal? OActOvhCost,
			decimal? OActGaCost,
			decimal? OActOtherCost,
			decimal? TTotCost) MsCostSp(
			string IProjNum,
			string IMsNum,
			int? CalcAct,
			decimal? OActMatlCost,
			decimal? OActLaborCost,
			decimal? OActOvhCost,
			decimal? OActGaCost,
			decimal? OActOtherCost,
			decimal? TTotCost);
	}
}

