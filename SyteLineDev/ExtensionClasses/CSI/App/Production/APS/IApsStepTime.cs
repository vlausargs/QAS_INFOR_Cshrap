//PROJECT NAME: Production
//CLASS NAME: IApsStepTime.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsStepTime
	{
		decimal? ApsStepTimeFn(
			string PJob,
			int? PSuffix,
			int? POperNum,
			int? PForceFixed = 0);
	}
}

