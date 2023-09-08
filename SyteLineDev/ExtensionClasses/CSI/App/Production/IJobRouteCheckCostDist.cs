//PROJECT NAME: Production
//CLASS NAME: IJobRouteCheckCostDist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobRouteCheckCostDist
	{
		(int? ReturnCode, string Infobar) JobRouteCheckCostDistSp(string PJob,
		int? PSuffix,
		string Infobar);
	}
}

