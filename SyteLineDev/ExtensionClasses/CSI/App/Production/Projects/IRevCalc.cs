//PROJECT NAME: Production
//CLASS NAME: IRevCalc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevCalc
	{
		(int? ReturnCode, decimal? OActRev,
		decimal? OActMatlCost,
		decimal? OActLaborCost,
		decimal? OActOvhCost,
		decimal? OActGaCost,
		decimal? OActOtherCost,
		DateTime? OPlanDate) RevCalcSp(string IProjNum,
		string IMsNum,
		int? CalcAct,
		decimal? OActRev,
		decimal? OActMatlCost,
		decimal? OActLaborCost,
		decimal? OActOvhCost,
		decimal? OActGaCost,
		decimal? OActOtherCost,
		DateTime? OPlanDate = null);
	}
}

