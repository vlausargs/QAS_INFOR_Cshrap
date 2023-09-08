//PROJECT NAME: Production
//CLASS NAME: IRevMsInit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMsInit
	{
		(int? ReturnCode, string RevCalcMethod,
		decimal? RevCalcPct,
		decimal? RevCalcAmt,
		string CostCalcMethod,
		decimal? CostCalcPct,
		decimal? CostCalcAmt) RevMsInitSp(string ProjNum,
		string RevCalcMethod,
		decimal? RevCalcPct,
		decimal? RevCalcAmt,
		string CostCalcMethod,
		decimal? CostCalcPct,
		decimal? CostCalcAmt);
	}
}

