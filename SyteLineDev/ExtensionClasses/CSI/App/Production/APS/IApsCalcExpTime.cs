//PROJECT NAME: Production
//CLASS NAME: IApsCalcExpTime.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsCalcExpTime
	{
		decimal? ApsCalcExpTimeFn(
			int? PCALExists,
			string USETNFG,
			DateTime? SchDate,
			decimal? FLEADTIME,
			decimal? VLEADTIME,
			decimal? DEMAND,
			DateTime? TIMENOW,
			DateTime? LASTSYNCH);
	}
}

