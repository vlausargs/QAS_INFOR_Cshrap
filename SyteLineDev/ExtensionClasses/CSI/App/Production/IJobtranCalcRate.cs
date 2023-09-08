//PROJECT NAME: Production
//CLASS NAME: IJobtranCalcRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobtranCalcRate
	{
		(int? ReturnCode, decimal? OutPrRate,
		decimal? OutJobRate) JobtranCalcRateSp(string InPayRate,
		string InEmpNum,
		string InShift,
		DateTime? InTransDate,
		decimal? OutPrRate,
		decimal? OutJobRate);
	}
}

