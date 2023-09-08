//PROJECT NAME: Data
//CLASS NAME: ICustcost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICustcost
	{
		(int? ReturnCode,
			decimal? OActMatlCost,
			decimal? OActLaborCost,
			decimal? OActOvhCost,
			decimal? OActGaCost,
			decimal? OActOtherCost) CustcostSp(
			string IProjNum,
			string IMsNum,
			int? CalcAct,
			decimal? OActMatlCost,
			decimal? OActLaborCost,
			decimal? OActOvhCost,
			decimal? OActGaCost,
			decimal? OActOtherCost);
	}
}

